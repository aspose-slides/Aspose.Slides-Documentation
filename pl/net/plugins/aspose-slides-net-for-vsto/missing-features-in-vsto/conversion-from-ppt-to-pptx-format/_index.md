---
title: Konwersja z formatu PPT do PPTX
type: docs
weight: 20
url: /pl/net/conversion-from-ppt-to-pptx-format/
---
Unikalna funkcja Aspose.Slides, która zapewnia elastyczność w konwersjach wersji bez wpływu na pracę.
SaveFormat jest wyliczeniem, które może konwertować dokumenty do rozszerzeń podanych w tabeli poniżej.

|**Nazwa elementu**|**Wartość**|**Opis**|
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
Poniżej znajduje się fragment kodu pokazujący konwersję z PPT do PPTX; możesz ją wykonać również w odwrotną stronę.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Utwórz obiekt Presentation, który reprezentuje plik PPTX

Presentation pres = new Presentation(srcFileName);

//Zapisz prezentację PPTX w formacie PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)