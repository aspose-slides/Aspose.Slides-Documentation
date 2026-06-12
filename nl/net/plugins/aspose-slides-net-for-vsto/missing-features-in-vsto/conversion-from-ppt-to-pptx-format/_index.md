---
title: Conversie van PPT naar PPTX-formaat
type: docs
weight: 20
url: /nl/net/conversion-from-ppt-to-pptx-format/
---
Unieke functie van Aspose.Slides die flexibiliteit biedt bij versieconversies zonder het werk te beïnvloeden.  
SaveFormat is een enumeratie die documenten kan converteren naar de onderstaande extensies in de tabel.

|**Lidnaam**|**Waarde**|**Beschrijving**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF Notes|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotes|14| |
|XPS|2| |

Hieronder staat een codefragment dat de conversie van PPT naar PPTX toont; je kunt dit ook omgekeerd doen.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Initialiseer een Presentation-object dat een PPTX-bestand vertegenwoordigt

Presentation pres = new Presentation(srcFileName);

//Opslaan van de PPTX-presentatie in PPTX-formaat

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Download voorbeeldcode**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)