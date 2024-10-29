---
title: Präsentation mit Notizen in Tiff konvertieren
type: docs
weight: 50
url: /de/net/convert-presentation-to-tiff-with-notes/
---

TIFF ist eines von mehreren weit verbreiteten Bildformaten, die Aspose.Slides für .NET unterstützt, um eine Präsentation mit Notizen in Bilder zu konvertieren. Sie können auch Miniaturansichten von Folien im Notizen-Folienansicht erzeugen. Im Folgenden finden Sie zwei Codeausschnitte, die zeigen, wie man TIFF-Bilder einer Präsentation in der Notizen-Folienansicht erzeugt.

Die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) Methode, die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in der Notizen-Folienansicht in TIFF zu konvertieren. Sie können auch eine Miniaturansicht einer Folie in der Notizen-Folienansicht für einzelne Folien erzeugen.
## **Beispiel**

``` 

  //Erstellen Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt

 Presentation pres = new Presentation("Conversion.pptx");

 //Speichern der Präsentation als TIFF Notizen

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Laden Sie ein lauffähiges Beispiel herunter**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Tiff conversion with note/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Beispielcode herunterladen**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [Präsentation mit Notizen konvertieren](/slides/de/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/).

{{% /alert %}}