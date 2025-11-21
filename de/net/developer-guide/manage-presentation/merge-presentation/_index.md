---
title: Präsentationen in .NET effizient zusammenführen
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
description: "Müheloses Zusammenführen von PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mit Aspose.Slides für .NET, zur Optimierung Ihres Workflows."
---

## **Optimieren Sie das Zusammenführen Ihrer Präsentationen**

Mit [Aspose.Slides for .NET](https://products.aspose.com/slides/net/) können Sie PowerPoint‑Präsentationen nahtlos kombinieren und dabei Stile, Layouts und alle Elemente erhalten. Anders als bei anderen Werkzeugen fügt Aspose.Slides Präsentationen zusammen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Zusammenführen ganzer Präsentationen, bestimmter Folien und sogar verschiedener Dateiformate (PPT zu PPTX usw.).

### **Funktionen zum Zusammenführen**

- **Vollständiges Präsentations‑Merge:** Alle Folien zu einer einzigen Datei zusammenstellen.
- **Gezieltes Folien‑Merge:** Ausgewählte Folien auswählen und kombinieren.
- **Cross‑Format‑Merge:** Präsentationen unterschiedlicher Formate integrieren und die Integrität bewahren.

{{% alert title="Hinweis" color="primary" %}}  

Suchen Sie ein schnelles und **kostenloses Online‑Tool** zum **Zusammenführen von PowerPoint‑Präsentationen**? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).  

- **PowerPoint‑Dateien einfach zusammenführen**: Mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei kombinieren.  
- **Unterstützt verschiedene Formate**: **PPT zu PPTX**, **PPTX zu ODP** und mehr zusammenführen.  
- **Keine Installation nötig**: Läuft direkt im Browser, schnell und sicher.  

[![PowerPoint‑Dateien online zusammenführen](slides-merger.png)](https://products.aspose.app/slides/merger)  

Starten Sie noch heute das Zusammenführen Ihrer PowerPoint‑Dateien mit dem **kostenlosen Aspose‑Online‑Tool**!  

{{% /alert %}}

## **Präsentationen zusammenführen**

Wenn Sie eine [Präsentation zu einer anderen zusammenführen](https://products.aspose.com/slides/net/merger/ppt/), kombinieren Sie deren Folien zu einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, mit denen Benutzer Präsentationen auf diese Weise kombinieren können. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit allen Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts‑ oder Datenverlust sorgen zu müssen. 

**Siehe auch**

[Folien klonen](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie  

* ganze Präsentationen zusammenführen. Alle Folien der Präsentationen landen in einer Präsentation  
* bestimmte Folien zusammenführen. Ausgewählte Folien landen in einer Präsentation  
* Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander kombinieren. 

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateitypen:

* [Bilder](https://products.aspose.com/slides/net/merger/image-to-image/), z. B. [JPG zu JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/net/merger/png-to-png/)  
* Dokumente, z. B. [PDF zu PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/net/merger/html-to-html/)  
* Und zwei unterschiedliche Dateien, z. B. [Bild zu PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/). 

{{% /alert %}}

### **Optionen beim Zusammenführen**

Sie können Optionen festlegen, die bestimmen, ob  

* jede Folie in der Ausgabepäsentation einen eigenen Stil behält  
* ein einheitlicher Stil für alle Folien in der Ausgabepäsentation verwendet wird.  

Um Präsentationen zusammenzuführen, bietet Aspose.Slides die [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)-Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)-Interface). Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Zusammenführungsprozesses definieren. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)-Sammlung, sodass Sie die `AddClone`‑Methode der Präsentation aufrufen können, zu der Sie Folien hinzufügen möchten. 

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in der Ausgabepäsentation sind einfach Kopien der Quellfolien. Daher können Sie die resultierenden Folien ändern (z. B. Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen beeinflusst werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)-Methode bereit, mit der Sie Folien kombinieren können, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter). 

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


## **Präsentationen mit Folienmaster zusammenführen**

Aspose.Slides bietet die [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2)-Methode, mit der Sie Folien kombinieren und dabei eine Folienmaster‑Vorlage anwenden können. So können Sie bei Bedarf den Stil der Folien in der Ausgabepäsentation ändern. 

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


{{% alert title="Hinweis" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein geeignetes Layout bestimmt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf **true** gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) ausgelöst. 

{{% /alert %}}

Möchten Sie, dass die Folien in der Ausgabepäsentation ein anderes Layout erhalten, verwenden Sie stattdessen die Methode [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) beim Zusammenführen. 

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das gezielte Zusammenführen von Folien aus mehreren Präsentationen ist nützlich für die Erstellung individueller Foliensets. Aspose.Slides for .NET ermöglicht es, nur die benötigten Folien auszuwählen und zu importieren. Die API bewahrt Formatierung, Layout und Design der Originalfolien. 

Der folgende C#‑Code erzeugt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:
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

Dieser C#‑Code zeigt, wie Sie Folien aus Präsentationen kombinieren und dabei das gewünschte Folienlayout anwenden, um eine Ausgabepäsentation zu erhalten:
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

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zu kombinieren, müssen Sie eine der Präsentationen so skalieren, dass ihre Größe der anderen entspricht. 

Dieser Beispielcode demonstriert den Vorgang:
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

Dieser C#‑Code zeigt, wie eine bestimmte Folie zu einem Abschnitt in einer Präsentation hinzugefügt wird:
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

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG‑zu‑PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

**Werden Notizen der Redner beim Zusammenführen erhalten?**  

Ja. Beim Klonen von Folien überträgt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

**Werden Kommentare und deren Autoren übernommen?**  

Kommentare, als Teil des Folieninhalts, werden mit der Folie kopiert. Autorenkennzeichnungen bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

**Was passiert, wenn die Quellpräsentation passwortgeschützt ist?**  

Sie muss [mit dem Passwort geöffnet werden](/slides/de/net/password-protected-presentation/) über [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/); nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.

**Wie thread‑sicher ist der Zusammenführungs‑Vorgang?**  

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Instanz aus [mehreren Threads](/slides/de/net/multithreading/). Empfohlen wird die Regel „ein Dokument – ein Thread“; verschiedene Dateien können parallel in eigenen Threads verarbeitet werden.