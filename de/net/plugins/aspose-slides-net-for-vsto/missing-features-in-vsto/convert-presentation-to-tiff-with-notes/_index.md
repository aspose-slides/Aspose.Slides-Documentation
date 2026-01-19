---
title: Präsentation mit Notizen in Tiff konvertieren
type: docs
weight: 50
url: /de/net/convert-presentation-to-tiff-with-notes/
---

TIFF ist eines der mehrere weit verbreiteten Bildformate, die Aspose.Slides für .NET unterstützt, um eine Präsentation mit Notizen in Bilder zu konvertieren. Sie können außerdem Miniaturansichten von Folien in der Notizfolienansicht erzeugen. Nachfolgend finden Sie zwei Code‑Snippets, die zeigen, wie TIFF‑Bilder einer Präsentation in der Notizfolienansicht generiert werden.

Die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)-Methode, die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in der Notizfolienansicht in TIFF zu konvertieren. Sie können außerdem eine Folienminiatur in der Notizfolienansicht für einzelne Folien erzeugen.
## **Beispiel**

```csharp

  //Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt

 Presentation pres = new Presentation("Conversion.pptx");

 //Speichern der Präsentation als TIFF-Notizen

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Laufendes Beispiel herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Beispielcode herunterladen**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Für weitere Details besuchen Sie [PowerPoint-Präsentationen in TIFF mit Notizen in .NET konvertieren](/slides/de/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}