---
title: Efficient Präsentationen zusammenführen in .NET
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/net/merge-presentation/
keywords:
- PowerPoint zusammenführen
- Präsentationen zusammenführen
- Folien zusammenführen
- PPT zusammenführen
- PPTX zusammenführen
- ODP zusammenführen
- PowerPoint kombinieren
- Präsentationen kombinieren
- Folien kombinieren
- PPT kombinieren
- PPTX kombinieren
- ODP kombinieren
- .NET
- C#
- Aspose.Slides
description: "Müheloses Zusammenführen von PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mit Aspose.Slides für .NET, wodurch Ihr Workflow optimiert wird."
---

## **Präsentationszusammenführung optimieren**

Mit [Aspose.Slides for .NET](https://products.aspose.com/slides/net/) können Sie PowerPoint‑Präsentationen nahtlos kombinieren und dabei Stile, Layouts und alle Elemente erhalten. Im Gegensatz zu anderen Tools fügt Aspose.Slides Präsentationen zusammen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Zusammenführen ganzer Präsentationen, ausgewählter Folien und sogar verschiedener Dateiformate (PPT zu PPTX usw.).

### **Zusammenführungs‑Features**

- **Vollständiges Präsentations‑Merge:** Alle Folien zu einer einzigen Datei zusammenstellen.
- **Selektives Folien‑Merge:** Ausgewählte Folien wählen und kombinieren.
- **Cross‑Format‑Merge:** Präsentationen unterschiedlicher Formate integrieren und dabei die Integrität wahren.

{{% alert title="Tipp" color="primary" %}}  

Suchen Sie ein schnelles und **kostenloses Online‑Tool** zum **Zusammenführen von PowerPoint‑Präsentationen**? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).  

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Merge **PPT zu PPTX**, **PPTX zu ODP** und mehr.  
- **Keine Installation nötig**: Läuft direkt im Browser, schnell und sicher.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Starten Sie noch heute das Zusammenführen Ihrer PowerPoint‑Dateien mit dem **Aspose kostenlosen Online‑Tool**!  

{{% /alert %}}

## **Präsentations‑Merge**

Wenn Sie [eine Präsentation mit einer anderen zusammenführen](https://products.aspose.com/slides/net/merger/ppt/), kombinieren Sie deren Folien zu einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Den meisten Präsentationsprogrammen (PowerPoint oder OpenOffice) fehlen Funktionen, mit denen Benutzer Präsentationen auf diese Weise kombinieren können. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit allen Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne Qualitäts- oder Datenverlust befürchten zu müssen. 

**Siehe auch**

[Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie

* komplette Präsentationen zusammenführen. Alle Folien der Quellpräsentationen landen in einer Präsentation
* ausgewählte Folien zusammenführen. Gewählte Folien landen in einer Präsentation
* Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zueinander zusammenführen. 

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateitypen:

* [Bilder](https://products.aspose.com/slides/net/merger/image-to-image/), z. B. [JPG zu JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* Dokumente, z. B. [PDF zu PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* Und unterschiedliche Dateitypen, z. B. [Bild zu PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Merge‑Optionen**

Sie können Optionen festlegen, die bestimmen, ob

* jede Folie in der Ausgabedatei einen eigenen Stil behält
* ein einheitlicher Stil für alle Folien in der Ausgabedatei verwendet wird. 

Zum Zusammenführen von Präsentationen stellt Aspose.Slides die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)‑Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)‑Interface) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Merge‑Vorgangs definieren. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)‑Sammlung, sodass Sie eine `AddClone`‑Methode von der Präsentation aus aufrufen können, in die Sie Folien einfügen möchten. 

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das eine Kopie der Quellfolie ist. Die Folien in der Ausgabedatei sind im Grunde Kopien der Quellfolien. Somit können Sie die resultierenden Folien (z. B. Stile, Formatierungsoptionen oder Layouts) ändern, ohne dass die Quellpräsentationen beeinflusst werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides bietet die [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)‑Methode, mit der Sie Folien zusammenführen können, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter). 

Dieser C#‑Code zeigt, wie Präsentationen zusammengeführt werden:
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


## **Präsentationen mit Slide‑Master zusammenführen**

Aspose.Slides stellt die [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2)‑Methode bereit, mit der Sie Folien zusammenführen und dabei ein Slide‑Master‑Vorlagendokument anwenden können. So können Sie bei Bedarf den Stil der Folien in der Ausgabedatei ändern. 

Der folgende C#‑Code demonstriert diesen Vorgang:
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

Das Layout der Folie für den Slide‑Master wird automatisch ermittelt. Wenn kein passendes Layout bestimmt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf **true** gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) ausgelöst. 

{{% /alert %}}

Möchten Sie, dass die Folien in der Ausgabedatei ein anderes Layout erhalten, verwenden Sie stattdessen die [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1)‑Methode beim Merge. 

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen ausgewählter Folien aus mehreren Präsentationen ist praktisch, um maßgeschneiderte Slide‑Decks zu erstellen. Aspose.Slides for .NET ermöglicht das Auswählen und Importieren genau der Folien, die Sie benötigen. Die API bewahrt Formatierung, Layout und Design der Originalfolien.

Der folgende C#‑Code erzeugt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis:
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


## **Präsentationen mit Slide‑Layout zusammenführen**

Dieser C#‑Code zeigt, wie Sie Folien aus Präsentationen zusammenführen und dabei ein bevorzugtes Slide‑Layout anwenden, um eine einheitliche Ausgabedatei zu erhalten:
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

Präsentationen mit unterschiedlichen Foliengrößen können nicht zusammengeführt werden. 

{{% /alert %}}

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie die Größe einer Präsentation an die der anderen anpassen. 

Der folgende Beispielcode demonstriert diesen Vorgang:
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

Dieser C#‑Code zeigt, wie Sie eine bestimmte Folie zu einem Abschnitt einer Präsentation hinzufügen:
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

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Werden Sprecher‑Notizen beim Merge erhalten?**

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

**Werden Kommentare und deren Autoren übertragen?**

Kommentare werden als Teil des Folieninhalts kopiert. Die Autorenangaben bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

**Was ist, wenn die Quellpräsentation durch ein Passwort geschützt ist?**

Sie muss [mit dem Passwort geöffnet werden](/slides/de/net/password-protected-presentation/) über [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/); nach dem Laden können diese Folien sicher in eine ungeschützte Ziel‑Datei (oder ebenfalls in eine geschützte) geklont werden.

**Wie thread‑sicher ist der Merge‑Vorgang?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz aus [mehreren Threads](/slides/de/net/multithreading/). Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.