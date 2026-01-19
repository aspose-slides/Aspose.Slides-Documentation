---
title: Konvertierung von PPT zu PPTX-Format
type: docs
weight: 20
url: /de/net/conversion-from-ppt-to-pptx-format/
---

Einzigartige Funktion von Aspose.Slides, die Flexibilität bei Versionskonvertierungen bietet, ohne die Arbeit zu beeinträchtigen.
SaveFormat ist eine Aufzählung, die Dokumente in die unten in der Tabelle angegebenen Erweiterungen konvertieren kann.

|**Membername**|**Wert**|**Beschreibung**|
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

Unten finden Sie ein Code‑Snippet, das die Konvertierung von PPT zu PPTX zeigt; Sie können dies auch umgekehrt ausführen.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Instantiate a Presentation object that represents a PPTX file

Presentation pres = new Presentation(srcFileName);

//Saving the PPTX presentation to PPTX format

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)