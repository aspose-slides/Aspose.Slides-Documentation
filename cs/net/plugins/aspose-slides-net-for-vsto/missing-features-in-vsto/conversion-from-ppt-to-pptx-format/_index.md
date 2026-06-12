---
title: Konverze z formátu PPT do PPTX
type: docs
weight: 20
url: /cs/net/conversion-from-ppt-to-pptx-format/
---
Jedinečná funkce Aspose.Slides, která poskytuje flexibilitu při konverzi verzí bez ovlivnění práce.
SaveFormat je výčtový typ, který umožňuje převádět dokumenty do rozšíření uvedených níže v tabulce.

|**Název člena**|**Hodnota**|**Popis**|
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
Níže je ukázkový kód, který ukazuje konverzi z PPT do PPTX; můžete provést i opačnou konverzi.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Instancujte objekt Presentation, který představuje soubor PPTX

Presentation pres = new Presentation(srcFileName);

//Ukládání prezentace PPTX do formátu PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Stáhněte ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)