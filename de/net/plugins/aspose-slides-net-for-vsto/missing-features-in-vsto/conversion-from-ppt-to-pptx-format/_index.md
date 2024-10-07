---
title: Konvertierung von PPT in PPTX-Format
type: docs
weight: 20
url: /net/conversion-from-ppt-to-pptx-format/
---

Aspose.Slides ist ein einzigartiges Merkmal, das Flexibilität bei Versionen bietet, ohne die Arbeit zu beeinträchtigen. 
SaveFormat ist eine Enumeration, die Dokumente in den untenstehenden Erweiterungen konvertieren kann.

|**Mitgliedsname**|**Wert**|**Beschreibung**|
| :- | :- | :- |
|HTML|13| |
|ODP|6| |
|PDF|1| |
|PDF-Notizen|12| |
|POTM|11| |
|POTX|10| |
|PPS|0| |
|PPSM|9| |
|PPSX|4| |
|PPT|0| |
|PPTM|7| |
|PPTX|3| |
|TIFF|5| |
|TiffNotizen|14| |
|XPS|2| |
Unten finden Sie ein Codebeispiel, das die Konvertierung von PPT in PPTX zeigt; Sie können es auch umgekehrt tun.

``` csharp

 string FilePath = @"..\..\..\Beispieldateien\";

string srcFileName = FilePath + "Konvertierung PPT zu PPTX.ppt";

string destFileName = FilePath + "Konvertierung PPT zu PPTX.pptx";

//Erstellen Sie ein Präsentationsobjekt, das eine PPTX-Datei darstellt

Presentation pres = new Presentation(srcFileName);

//Speichern der PPTX-Präsentation im PPTX-Format

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)