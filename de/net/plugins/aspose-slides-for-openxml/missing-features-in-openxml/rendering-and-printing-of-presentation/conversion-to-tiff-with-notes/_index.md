---
title: Konvertierung zu Tiff mit Notizen
type: docs
weight: 10
url: /de/net/conversion-to-tiff-with-notes/
---

TIFF ist eines der mehreren weit verbreiteten Bildformate, die Aspose.Slides für .NET unterstützt, um eine Präsentation mit Notizen in Bilder zu konvertieren. Sie können auch Folienminiaturen in der Notizfolienansicht erzeugen. Im Folgenden finden Sie zwei Code‑Snippets, die zeigen, wie TIFF‑Bilder einer Präsentation in der Notizfolienansicht generiert werden.

Die **Save**‑Methode, die von der **Presentation**‑Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in der Notizfolienansicht in TIFF zu konvertieren. Sie können auch eine Folienminiatur in der Notizfolienansicht für einzelne Folien erzeugen.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Beispielcode herunterladen**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)