---
title: Folie aus der Präsentation entfernen
type: docs
weight: 30
url: /net/remove-slide-from-presentation/
keywords: "Folie entfernen, Folie löschen, PowerPoint, Präsentation, C#, Csharp, .NET, Aspose.Slides"
description: "Folie aus PowerPoint über Referenz oder Index in C# oder .NET entfernen"

---

Wenn eine Folie (oder deren Inhalte) überflüssig wird, können Sie sie löschen. Aspose.Slides bietet die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse, die die [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) kapselt, die ein Repository für alle Folien in einer Präsentation ist. Mit Hilfe von Zeigern (Referenz oder Index) für ein bekanntes [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) Objekt können Sie die Folie angeben, die Sie entfernen möchten.

## **Folie durch Referenz entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie eine Referenz auf die Folie, die Sie entfernen möchten, durch ihre ID oder ihren Index.
1. Entfernen Sie die referenzierte Folie aus der Präsentation.
1. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie eine Folie über ihre Referenz entfernen:

```c#
// Erstellt ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Greift auf eine Folie über ihren Index in der Folienkollektion zu
    ISlide slide = pres.Slides[0];

    // Entfernt eine Folie über ihre Referenz
    pres.Slides.Remove(slide);

    // Speichert die modifizierte Präsentation
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Folie durch Index entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Entfernen Sie die Folie aus der Präsentation über ihre Indexposition.
1. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie eine Folie über ihren Index entfernen:

```c#
// Erstellt ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Entfernt eine Folie über ihren Folienindex
    pres.Slides.RemoveAt(0);

    // Speichert die modifizierte Präsentation
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Unbenutzte Layout-Folie entfernen**

Aspose.Slides bietet die [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) Methode (aus der [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) Klasse), um unerwünschte und unbenutzte Layout-Folien zu löschen. Dieser C#-Code zeigt Ihnen, wie Sie eine Layout-Folie aus einer PowerPoint-Präsentation entfernen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Unbenutzte Master-Folie entfernen**

Aspose.Slides bietet die [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) Methode (aus der [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) Klasse), um unerwünschte und unbenutzte Master-Folien zu löschen. Dieser C#-Code zeigt Ihnen, wie Sie eine Master-Folie aus einer PowerPoint-Präsentation entfernen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```