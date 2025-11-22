---
title: Effizientes Zusammenführen von PowerPoint‑Präsentationen (PPT, PPTX) mit C#
linktitle: Präsentation zusammenführen
type: docs
weight: 40
url: /de/net/merge-presentation/
keywords: "PowerPoint zusammenführen, PPTX, PPT, PowerPoint kombinieren, Präsentation zusammenführen, Präsentation kombinieren, C#, Csharp, .NET"
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen in C# oder .NET mühelos zusammenführen oder kombinieren."
---

## **Optimieren Sie das Zusammenführen von Präsentationen**

Mit [Aspose.Slides for .NET](https://products.aspose.com/slides/net/), kombinieren Sie nahtlos PowerPoint‑Präsentationen und erhalten dabei Stile, Layouts und alle Elemente. Im Gegensatz zu anderen Werkzeugen fügt Aspose.Slides Präsentationen zusammen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Fassen Sie ganze Präsentationen, bestimmte Folien und sogar verschiedene Dateiformate (PPT zu PPTX usw.) zusammen.

### **Zusammenführungsfunktionen**

- **Vollständige Präsentationszusammenführung:** Alle Folien zu einer einzigen Datei zusammenstellen.  
- **Spezifische Folienzusammenführung:** Ausgewählte Folien auswählen und kombinieren.  
- **Formatübergreifende Zusammenführung:** Präsentationen unterschiedlicher Formate integrieren und dabei die Integrität wahren.  

{{% alert title="Tip" color="primary" %}}  
Suchen Sie ein schnelles und **kostenloses Online‑Tool**, um **PowerPoint‑Präsentationen zusammenzuführen**? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).  

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Führen Sie **PPT zu PPTX**, **PPTX zu ODP** und weitere Formate zusammen.  
- **Keine Installation erforderlich**: Funktioniert direkt in Ihrem Browser, schnell und sicher.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Beginnen Sie noch heute mit dem Zusammenführen Ihrer PowerPoint‑Dateien mit dem **kostenlosen Online‑Tool von Aspose**!  
{{% /alert %}}

## **Präsentationszusammenführung**

Wenn Sie [eine Präsentation mit einer anderen zusammenführen](https://products.aspose.com/slides/net/merger/ppt/), kombinieren Sie im Wesentlichen deren Folien zu einer einzigen Präsentation, um eine Datei zu erhalten.  

{{% alert title="Info" color="info" %}}  
Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, mit denen Benutzer Präsentationen auf diese Weise kombinieren können.  

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) ermöglicht Ihnen jedoch, Präsentationen auf verschiedene Arten zusammenzuführen.  
Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts‑ oder Datenverlust sorgen zu müssen.  

**Siehe auch**  

[Folien duplizieren](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  
{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie  

* ganze Präsentationen. Alle Folien aus den Präsentationen werden in einer einzigen Präsentation zusammengeführt  
* bestimmte Folien. Ausgewählte Folien landen in einer einzigen Präsentation  
* Präsentationen in einem Format (PPT zu PPT, PPTX zu PPTX usw.) und in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander.  

{{% alert title="Note" color="warning" %}}  
Neben Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateien:  

* [Bilder](/slides/de/net/merger/image-to-image/), zum Beispiel [JPG zu JPG](/slides/de/net/merger/jpg-to-jpg/) oder [PNG zu PNG](/slides/de/net/merger/png-to-png/)  
* [Dokumente](/slides/de/net/merger/pdf-to-pdf/), zum Beispiel [PDF zu PDF](/slides/de/net/merger/pdf-to-pdf/) oder [HTML zu HTML](/slides/de/net/merger/html-to-html/)  
* Und zwei verschiedene Dateitypen, wie zum Beispiel [Bild zu PDF](/slides/de/net/merger/image-to-pdf/) oder [JPG zu PDF](/slides/de/net/merger/jpg-to-pdf/) oder [TIFF zu PDF](/slides/de/net/merger/tiff-to-pdf/)  

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen festlegen, die bestimmen, ob  

* jede Folie in der Ausgabepäsentation einen einzigartigen Stil beibehält  
* ein bestimmter Stil für alle Folien in der Ausgabepäsentation verwendet wird.  

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)-Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Interface) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Zusammenführungsprozesses definieren. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)-Sammlung, sodass Sie die `AddClone`‑Methode von der Präsentation aus aufrufen können, in die Sie Folien einfügen möchten.  

`AddClone` gibt ein `ISlide`‑Objekt zurück, das ein Klon der Quellfolie ist. Die Folien einer Ausgabepäsentation sind einfach Kopien der Folien der Quelle. Daher können Sie Änderungen an den resultierenden Folien vornehmen (z. B. Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen beeinflusst werden.  

## **Präsentationen zusammenführen** 

Aspose.Slides bietet die [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)-Methode, die es Ihnen ermöglicht, Folien zu kombinieren, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter).  

Dieser C#‑Code zeigt, wie man Präsentationen zusammenführt:  
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

Aspose.Slides stellt die [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2)-Methode bereit, die es Ihnen ermöglicht, Folien zu kombinieren und dabei eine Folienmaster‑Vorlage anzuwenden. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabepäsentation ändern.  

Dieser C#‑Code demonstriert den beschriebenen Vorgang:  
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


{{% alert title="Note" color="warning" %}}  
Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein passendes Layout bestimmt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf true gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) ausgelöst.  
{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabepäsentation ein anderes Folienlayout haben, verwenden Sie stattdessen die [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1)-Methode beim Zusammenführen.  

## **Bestimmte Folien aus Präsentationen zusammenführen** 

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Folienpakete zu erstellen. Aspose.Slides for .NET ermöglicht Ihnen, nur die Folien auszuwählen und zu importieren, die Sie benötigen. Die API bewahrt Formatierung, Layout und Design der Originalfolien.  

Der folgende C#‑Code erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:  
```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```
  
```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```


## **Präsentationen mit Folienlayout zusammenführen** 

Dieser C#‑Code zeigt, wie man Folien aus Präsentationen kombiniert und dabei das bevorzugte Folienlayout anwendet, um eine Ausgabepäsentation zu erhalten:  
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

{{% alert title="Note" color="warning" %}}  
Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen.  
{{% /alert %}}  

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen skalieren, sodass ihre Größe der der anderen Präsentation entspricht.  

Dieses Beispielcode demonstriert den beschriebenen Vorgang:  
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


## **Folien zu einem Präsentationsabschnitt zusammenführen** 

Dieser C#‑Code zeigt, wie man eine bestimmte Folie zu einem Abschnitt in einer Präsentation zusammenführt:  
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


Die Folie wird am Ende des Abschnitts eingefügt.  

{{% alert title="Tip" color="primary" %}}  
Aspose bietet eine [FREE Collage web app](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Foto‑Raster](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr.  
{{% /alert %}}

## **FAQ**

**Werden Sprechernotizen beim Zusammenführen erhalten?**  

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierung und Animationen.  

**Werden Kommentare und deren Autoren übertragen?**  

Kommentare, die Teil des Folieninhalts sind, werden zusammen mit der Folie kopiert. Die Autorenbezeichnungen der Kommentare bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.  

**Was ist, wenn die Quellpräsentation passwortgeschützt ist?**  

Sie muss [mit dem Passwort geöffnet](/slides/de/net/password-protected-presentation/) über [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) werden; nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.  

**Wie thread‑sicher ist der Zusammenführungsvorgang?**  

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Instanz aus [mehreren Threads](/slides/de/net/multithreading/). Die empfohlene Regel lautet "ein Dokument – ein Thread"; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.