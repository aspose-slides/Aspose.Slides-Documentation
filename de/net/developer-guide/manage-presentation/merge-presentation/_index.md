---
title: Merge PowerPoint-Präsentationen PPT, PPTX mit C#
linktitle: Präsentation zusammenführen
type: docs
weight: 40
url: /de/net/merge-presentation/
keywords: "PowerPoint zusammenführen, PPTX, PPT, PowerPoint kombinieren, Präsentation zusammenführen, Präsentation kombinieren, C#, Csharp, .NET"
description: "Merge oder kombiniere PowerPoint-Präsentationen in C# oder .NET"
---

{{% alert  title="Hinweis" color="primary" %}} 

Sie möchten möglicherweise die **Aspose kostenlose Online** [Merger-App](https://products.aspose.app/slides/merger) ausprobieren. Sie ermöglicht es den Benutzern, PowerPoint-Präsentationen im gleichen Format (PPT zu PPT, PPTX zu PPTX, usw.) zusammenzuführen und Präsentationen in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP, usw.) zu kombinieren.

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Präsentationen zusammenführen**

Wenn Sie [eine Präsentation mit einer anderen zusammenführen](https://products.aspose.com/slides/net/merger/ppt/), kombinieren Sie effektiv deren Folien in einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, mit denen Benutzer Präsentationen auf diese Weise kombinieren können. 

[**Aspose.Slides für .NET**](https://products.aspose.com/slides/net/), ermöglicht es jedoch, Präsentationen auf verschiedene Arten zusammenzuführen. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um den Verlust von Qualität oder Daten Sorgen machen zu müssen. 

**Siehe auch**

[Folien klonen](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie 

* gesamte Präsentationen. Alle Folien aus den Präsentationen enden in einer Präsentation
* spezifische Folien. Ausgewählte Folien enden in einer Präsentation
* Präsentationen im gleichen Format (PPT zu PPT, PPTX zu PPTX, usw.) und in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP, usw.) miteinander. 

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen ermöglicht es Ihnen Aspose.Slides, andere Dateien zusammenzuführen:

* [Bilder](https://products.aspose.com/slides/net/merger/image-to-image/), wie [JPG zu JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* Dokumente, wie [PDF zu PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* Und zwei verschiedene Dateien wie [Bild zu PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) oder [JPG zu PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgabpräsentation einen einzigartigen Stil beibehält
* ein spezifischer Stil für alle Folien in der Ausgabpräsentation verwendet wird. 

Zum Zusammenführen von Präsentationen stellt Aspose.Slides [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) Interface) zur Verfügung. Es gibt mehrere Implementierungen der `AddClone` Methoden, die die Parameter des Präsentationszusammenführungsprozesses festlegen. Jedes Präsentationsobjekt hat eine [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) Sammlung, sodass Sie eine `AddClone` Methode von der Präsentation aufrufen können, mit der Sie Folien zusammenführen möchten. 

Die Methode `AddClone` gibt ein `ISlide` Objekt zurück, das eine Kopie der Quellfolie ist. Die Folien in der Ausgabpräsentation sind einfach eine Kopie der Folien aus der Quelle. Daher können Sie die resultierenden Folien bearbeiten (zum Beispiel Stile, Formatierungsoptionen oder Layouts anwenden), ohne sich Sorgen machen zu müssen, dass die Quellpräsentationen betroffen sind. 

## **Präsentationen zusammenführen** 

Aspose.Slides bietet die [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) Methode, mit der Sie Folien kombinieren können, während die Folien ihre Layouts und Stile beibehalten (Standardparameter). 

Dieser C#-Code zeigt Ihnen, wie man Präsentationen zusammenführt:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Präsentationen mit Folienmaster zusammenführen**

Aspose.Slides bietet die [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) Methode, mit der Sie Folien zusammenführen können, während Sie eine Folienmaster-Präsentationsvorlage anwenden. Auf diese Weise können Sie, falls erforderlich, den Stil für Folien in der Ausgabpräsentation ändern. 

Dieser C#-Code demonstriert die beschriebene Operation:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Hinweis" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch bestimmt. Wenn ein passendes Layout nicht bestimmt werden kann, wird, wenn der boolesche Parameter `allowCloneMissingLayout` der Methode `AddClone` auf true gesetzt ist, das Layout für die Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) ausgelöst. 

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabpräsentation ein anderes Folienlayout haben, verwenden Sie stattdessen die [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) Methode beim Zusammenführen. 

## **Spezifische Folien aus Präsentationen zusammenführen**

Dieser C#-Code zeigt Ihnen, wie Sie spezifische Folien aus verschiedenen Präsentationen auswählen und kombinieren, um eine Ausgabpräsentation zu erhalten:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Präsentationen mit Folienlayout zusammenführen**

Dieser C#-Code zeigt Ihnen, wie Sie Folien aus Präsentationen kombinieren können, während Sie Ihr bevorzugtes Folienlayout anwenden, um eine Ausgabpräsentation zu erhalten:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

{{% alert title="Hinweis" color="warning" %}} 

Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen anpassen, damit ihre Größe mit der der anderen Präsentation übereinstimmt. 

Dieser Beispielcode demonstriert die beschriebene Operation:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Folien zu einem Präsentationsabschnitt hinzufügen**

Dieser C#-Code zeigt Ihnen, wie Sie eine spezifische Folie zu einem Abschnitt in einer Präsentation zusammenführen:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

Die Folie wird am Ende des Abschnitts hinzugefügt. 

{{% alert title="Hinweis" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage-Webanwendung](https://products.aspose.app/slides/collage). Mit diesem Online-Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG-Bildern zusammenführen, [Foto-Raster](https://products.aspose.app/slides/collage/photo-grid) erstellen usw. 

{{% /alert %}}