---
title: Konvertierung zu Tiff mit Notizen
type: docs
weight: 10
url: /net/conversion-to-tiff-with-notes/
---

TIFF ist eines von mehreren weit verbreiteten Bildformaten, die Aspose.Slides für .NET unterstützt, um eine Präsentation mit Notizen in Bilder zu konvertieren. Sie können auch Folien-Thumbnails im Notizenfolienansicht generieren. Im Folgenden finden Sie zwei Codebeispiele, die zeigen, wie man TIFF-Bilder einer Präsentation in der Notizenfolienansicht erstellt.

Die **Save**-Methode, die von der **Presentation**-Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in der Notizenfolienansicht in TIFF zu konvertieren. Sie können auch ein Folien-Thumbnails in der Notizenfolienansicht für einzelne Folien erstellen.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Erstellen eines Presentation-Objekts, das eine Präsentationsdatei darstellt

Presentation pres = new Presentation(srcFileName);

//Speichern der Präsentation als TIFF mit Notizen

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)