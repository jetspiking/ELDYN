# <img src="https://raw.githubusercontent.com/jetspiking/ELDYN/main/Images/EldynFavicon.png" width="64" height="64"> ELDYN LaTeX Dynamic
<img src="https://raw.githubusercontent.com/jetspiking/ELDYN/main/Images/Eldyn.jpg" Width="400">

# Description
ELDYN is a tool that allows manipulating files by priorly defining variables or templates that should be injected dynamically. This works ideal for LaTeX, due to the nature of the WYSIWYM writing approach. ELDYN allows inputting a JSON file containing (custom) properties (variables) and outputting these into personalized templates. ELDYN is best usable for documents adhering to a strict format specification. This makes ELDYN a candidate for dynamically creating certificates, invoices, documentation, labels and more.

# Usage
ELDYN requires three arguments:
- Path to JSON file
- Path to template directory
- Path to output file

E.g., ```ELDYN "C:\Users\dusti\Desktop\ELDYNPub\Learn\Entry-certificate\Certificate.json" "C:\Users\dusti\Desktop\ELDYNPub\Learn\Entry-certificate\Temp" "C:\Users\dusti\Desktop\ELDYNPub\Learn\Entry-certificate\Out\Certificate.tex"```

On Windows reference the executable using command prompt. On MacOS and Linux set execute permissions prior to attempting to run the application.

```chmod +x ELDYN-osx-x64```

```./ELDYN-osx-x64 arg0 arg1 arg2```

# Documentation
ELDYN differentiates between properties and templates.
- A property is a string value that should be inputted when matching a key.
- A template can contain more lines that should be injected when referenced. This is especially useful for dynamically generating lists and pieces of text / code not solely relying or matching with the user input. A template requires the ".eldyn" extension.

ELDYN searches and replaces all matching occurances of properties with data in the JSON, and if relevant, injects templates as well.
- ```$ELDYN:Property;```
- ```$ELDYN::Template;```

A single colon symbol ```:``` matches for properties, while a double colon symbol ```::``` matches for templates. A semi colon symbol ```;``` is used to mark the end of the string.

## Minimal Example
The following JSON-file (in.json) is an example of assigning a value to a property and generating output following the constraints of a template:
```
{
    "Template": "Template",
    "Properties": 
    [
        {
            "Id": "Property",
            "Assign": "My property value"
        }
    ]
}
```
The referenced template file (Template.eldyn) could state:
```
$ELDYN:Property;
```
This would then generate the following file:
```
My property value
```

# Certificate
Get your ELDYN certificate by cloning the repository and running the included example "Entry-certificate". Adjust "Certificate.json" to feature your own name, then run ELDYN for arguments:
- "Certificate.json" (JSON-file)
- "Temp" (Template directory)
- "Certificate.tex" (Output file)

Then compile the Certificate.tex output using your favorite LaTeX software stack.

<img src="https://raw.githubusercontent.com/jetspiking/ELDYN/main/Images/Certificate.png" Width="800">

# Requirements
- .NET Framework Installed

# Thank you for using ELDYN
If you enjoy this software series, you could consider supporting me by purchasing application [Colorpick - PRO](https://store.steampowered.com/app/1388790/Colorpick__PRO). For a few dollars (depending on Steam pricing in region) you receive a DRM-free Colorpick application.

<a href="https://www.buymeacoffee.com/DustinHendriks" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a>

