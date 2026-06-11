---
title: Konvertering från PPT till PPTX-format
type: docs
weight: 20
url: /sv/net/conversion-from-ppt-to-pptx-format/
---
Aspose.Slides unik funktion som ger flexibilitet vid versionkonverteringar utan att påverka arbetet.  
SaveFormat är en uppräkning som kan konvertera dokument till de filändelser som anges i tabellen nedan.

|**Medlemsnamn**|**Värde**|**Beskrivning**|
| :- | :- | :- |
|HTML|13||
|ODP|6||
|PDF|1||
|PDF Notes|12||
|POTM|11||
|POTX|10||
|PPS|0||
|PPSM|9||
|PPSX|4||
|PPT|0||
|PPTM|7||
|PPTX|3||
|TIFF|5||
|TiffNotes|14||
|XPS|2||

Nedan visas ett kodexempel som visar konvertering från PPT till PPTX; du kan även göra det omvänt.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Instansiera ett Presentation-objekt som representerar en PPTX-fil

Presentation pres = new Presentation(srcFileName);

//Sparar PPTX-presentationen i PPTX-format

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)