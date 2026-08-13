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
description: "PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen mühelos mit Aspose.Slides für .NET zusammenführen und Ihren Arbeitsablauf optimieren."
---
## **Übersicht**

Aspose.Slides ermöglicht das Zusammenführen von Präsentationen, indem Folien einer Präsentation in eine andere geklont werden. Dieser Artikel erklärt, wie man gesamte Präsentationen oder ausgewählte Folien zusammenführt, während des Zusammenführens ein Folienmaster oder ein bestimmtes Layout verwendet, Präsentationen mit unterschiedlichen Foliengrößen behandelt und zusammengeführte Folien zu einem Präsentationsabschnitt hinzufügt. Außerdem werden praktische Hinweise zu zusammengeführten Inhalten behandelt, einschließlich Referentennotizen, Kommentaren, passwortgeschützten Quelldateien und Thread‑Nutzung.

## **Optimieren Sie das Zusammenführen von Präsentationen**

Mit [Aspose.Slides for .NET](https://products.aspose.com/slides/de/net/) können PowerPoint‑Präsentationen nahtlos kombiniert werden, wobei Stil‑, Layout‑ und alle Elemente erhalten bleiben. Im Gegensatz zu anderen Tools fügt Aspose.Slides Präsentationen zusammen, ohne Qualität zu beeinträchtigen oder Daten zu verlieren. Fügen Sie komplette Präsentationen, bestimmte Folien und sogar verschiedene Dateiformate (PPT zu PPTX usw.) zusammen.

### **Zusammenführungsfunktionen**

- **Vollständige Präsentationszusammenführung:** Alle Folien zu einer einzigen Datei zusammenstellen.  
- **Spezifische Folienzusammenführung:** Ausgewählte Folien auswählen und kombinieren.  
- **Formatübergreifende Zusammenführung:** Präsentationen unterschiedlicher Formate integrieren und dabei die Integrität wahren.  

{{% alert title="Tipp" color="info" %}}  

Suchen Sie ein schnelles und **kostenloses Online‑Tool**, um **PowerPoint‑Präsentationen zusammenzufügen**? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/de/merger).  

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Fügen Sie **PPT zu PPTX**, **PPTX zu ODP** und weitere Formate zusammen.  
- **Keine Installation erforderlich**: Funktioniert direkt in Ihrem Browser, schnell und sicher.  

[![PowerPoint‑Dateien online zusammenführen](slides-merger.png)](https://products.aspose.app/slides/de/merger)  

Beginnen Sie noch heute mit dem **kostenlosen Online‑Tool von Aspose** Ihre PowerPoint‑Dateien zusammenzuführen!  

{{% /alert %}}

## **Präsentationszusammenführung**

Wenn Sie [eine Präsentation in eine andere zusammenführen](https://products.aspose.com/slides/de/net/merger/ppt/), kombinieren Sie effektiv deren Folien zu einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) bieten keine Funktionen, mit denen Benutzer Präsentationen auf diese Weise kombinieren können. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/de/net/) ermöglicht das Zusammenführen von Präsentationen auf verschiedene Weise. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts‑ oder Datenverlust sorgen zu müssen. 

**Siehe auch**

[Folien klonen](https://docs.aspose.com/slides/de/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie  

* komplette Präsentationen zusammenführen. Alle Folien der Präsentationen landen in einer Präsentation.  
* spezifische Folien zusammenführen. Ausgewählte Folien landen in einer Präsentation.  
* Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zueinander zusammenführen.  

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen erlaubt Aspose.Slides das Zusammenführen weiterer Dateien:  

* [Bilder](https://products.aspose.com/slides/de/net/merger/image-to-image/), z. B. [JPG zu JPG](https://products.aspose.com/slides/de/net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/de/net/merger/png-to-png/)  
* Dokumente, z. B. [PDF zu PDF](https://products.aspose.com/slides/de/net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/de/net/merger/html-to-html/)  
* Und zwei unterschiedliche Dateien, z. B. [Bild zu PDF](https://products.aspose.com/slides/de/net/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/de/net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/de/net/merger/tiff-to-pdf/).  

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen festlegen, die bestimmen, ob  

* jede Folie in der Ausgabepäsentation einen einzigartigen Stil behält  
* ein einheitlicher Stil für alle Folien in der Ausgabepäsentation verwendet wird.  

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [AddClone](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone)‑Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection)‑Interface) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Zusammenführungsprozesses definieren. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/properties/slides)‑Auflistung, sodass Sie die `AddClone`‑Methode von der Präsentation aus aufrufen können, in die Sie Folien einfügen möchten.  

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in der Ausgabepäsentation sind einfach Kopien der Quellfolien. Daher können Sie die resultierenden Folien ändern (z. B. Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen beeinflusst werden.  

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [**AddClone (ISlide)**](https://reference.aspose.com/slides/de/net/aspose.slides/islidecollection/methods/addclone)‑Methode bereit, mit der Sie Folien kombinieren können, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter).  

Der folgende C#‑Code zeigt, wie Sie Präsentationen zusammenführen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Präsentationen mit einem Folienmaster zusammenführen**

Aspose.Slides stellt die [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/de/net/aspose.slides.islidecollection/addclone/methods/2)‑Methode bereit, mit der Sie Folien kombinieren können, während Sie eine Folienmaster‑Vorlage anwenden. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabepäsentation ändern.  

Dieser C#‑Code demonstriert den beschriebenen Vorgang:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein geeignetes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf `true` gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/de/net/aspose.slides/pptxeditexception) ausgelöst. 

{{% /alert %}}

Wenn die Folien in der Ausgabepäsentation ein anderes Folienlayout erhalten sollen, verwenden Sie stattdessen die [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/de/net/aspose.slides.islidecollection/addclone/methods/1)‑Methode beim Zusammenführen.  

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen ausgewählter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Foliensets zu erstellen. Aspose.Slides for .NET ermöglicht es, nur die benötigten Folien auszuwählen und zu importieren. Die API bewahrt Formatierung, Layout und Design der Ursprungfolien.  

Der folgende C#‑Code erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
```cs
using Aspose.Slides;

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

## **Präsentationen mit einem Folienlayout zusammenführen**

Dieser C#‑Code zeigt, wie Sie Folien aus Präsentationen kombinieren und dabei Ihr bevorzugtes Folienlayout anwenden, um eine Ausgabepäsentation zu erhalten:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Das Zusammenführen von Präsentationen mit unterschiedlichen Foliengrößen löst keinen Fehler aus, jedoch übernehmen die zusammengeführten Folien die Foliengröße der Zielpräsentation, während ihre Formen ihre ursprünglichen Positionen und Größen beibehalten. Inhalte können dadurch verschoben oder außerhalb der Folienränder liegen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen und ihre Inhalte korrekt anzuordnen, passen Sie die Größe einer der Präsentationen an, sodass sie der Größe der anderen entspricht.  

Der folgende Beispielcode demonstriert den beschriebenen Vorgang:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Dieser C#‑Code zeigt, wie Sie eine bestimmte Folie zu einem Abschnitt in einer Präsentation hinzufügen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Tipp" color="info" %}}

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/de/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/de/collage/jpg) oder PNG‑zu‑PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/de/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}

## **FAQ**

### Werden Referentennotizen beim Zusammenführen erhalten?

Ja. Beim Klonen von Folien überträgt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierung und Animationen.

### Werden Kommentare und ihre Autoren übernommen?

Kommentare, als Teil des Folieninhalts, werden mit der Folie kopiert. Die Autor‑Labels bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

### Was ist, wenn die Quellpräsentation passwortgeschützt ist?

Sie muss über das Passwort mit [LoadOptions.Password](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/password/) geöffnet werden ([mehr erfahren](/slides/de/net/password-protected-presentation/)). Nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.

### Wie thread‑sicher ist der Zusammenführungs‑Vorgang?

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Instanz von mehreren Threads ([mehr erfahren](/slides/de/net/multithreading/)). Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.