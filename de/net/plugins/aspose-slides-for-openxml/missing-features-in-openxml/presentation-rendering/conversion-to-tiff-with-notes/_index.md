---
title: Konvertierung zu Tiff mit Notizen
type: docs
weight: 10
url: /de/net/conversion-to-tiff-with-notes/
---
TIFF ist eines der mehreren weit verbreiteten Bildformate, die Aspose.Slides für .NET unterstützt, um eine Präsentation mit Notizen in Bilder zu konvertieren. Sie können außerdem Folien-Miniaturansichten in der Ansicht Notizfolie erzeugen. Im Folgenden finden Sie zwei Code-Snippets, die zeigen, wie TIFF-Bilder einer Präsentation in der Ansicht Notizfolie erzeugt werden.

Die von der **Presentation**-Klasse bereitgestellte **Save**-Methode kann verwendet werden, um die gesamte Präsentation in der Ansicht Notizfolie in TIFF zu konvertieren. Sie können außerdem für einzelne Folien in der Ansicht Notizfolie eine Folien-Miniaturansicht erzeugen.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation(srcFileName))
{
    //Platzieren Sie die Rednernotizen unter jeder gerenderten Folie
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Speichern der Präsentation als TIFF mit Notizen
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
```
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)