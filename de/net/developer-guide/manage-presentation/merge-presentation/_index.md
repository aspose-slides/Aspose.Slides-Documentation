---
title: Effizientes Zusammenführen von Präsentationen in .NET
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

## **Optimieren Sie das Zusammenführen von Präsentationen**

Mit [Aspose.Slides für .NET](https://products.aspose.com/slides/net/) können Sie PowerPoint‑Präsentationen nahtlos kombinieren und dabei Stile, Layouts und alle Elemente erhalten. Im Gegensatz zu anderen Werkzeugen fügt Aspose.Slides Präsentationen zusammen, ohne die Qualität zu beeinträchtigen oder Daten zu verlieren. Fügen Sie ganze Präsentationen, einzelne Folien und sogar unterschiedliche Dateiformate (PPT zu PPTX usw.) zusammen.

### **Funktionen zum Zusammenführen**

- **Vollständiges Präsentations‑Zusammenführen:** Alle Folien zu einer einzigen Datei zusammenstellen.  
- **Einzelne Folien zusammenführen:** Ausgewählte Folien auswählen und kombinieren.  
- **Cross‑Format‑Zusammenführen:** Präsentationen verschiedener Formate integrieren und dabei die Integrität bewahren.  

{{% alert title="Tip" color="primary" %}}  

Sie suchen ein schnelles und **kostenloses Online‑Tool**, um **PowerPoint‑Präsentationen zusammenzuführen**? Probieren Sie den [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).  

- **PowerPoint‑Dateien einfach zusammenführen**: Kombinieren Sie mehrere **PPT, PPTX, ODP**‑Präsentationen zu einer einzigen Datei.  
- **Unterstützt verschiedene Formate**: Führen Sie **PPT zu PPTX**, **PPTX zu ODP** und mehr zusammen.  
- **Keine Installation erforderlich**: Arbeitet direkt in Ihrem Browser, schnell und sicher.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Starten Sie das Zusammenführen Ihrer PowerPoint‑Dateien noch heute mit dem **kostenlosen Online‑Tool von Aspose**!  

{{% /alert %}}

## **Präsentations‑Zusammenführung**

Wenn Sie eine Präsentation mit einer anderen [zusammenführen](https://products.aspose.com/slides/net/merger/ppt/), kombinieren Sie deren Folien effektiv zu einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, mit denen Benutzer Präsentationen auf diese Weise kombinieren können.  

[**Aspose.Slides für .NET**](https://products.aspose.com/slides/net/) ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts- oder Datenverlust sorgen zu müssen.  

**Siehe auch**  

[Folien klonen](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie

* ganze Präsentationen zusammenführen. Alle Folien aus den Präsentationen landen in einer einzigen Präsentation  
* einzelne Folien zusammenführen. Ausgewählte Folien landen in einer einzigen Präsentation  
* Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) sowie in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander verbinden. 

{{% alert title="Note" color="warning" %}} 

Zusätzlich zu Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateien:

* [Bilder](https://products.aspose.com/slides/net/merger/image-to-image/), wie z. B. [JPG zu JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/net/merger/png-to-png/)  
* Dokumente, wie z. B. [PDF zu PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/net/merger/html-to-html/)  
* Und zwei unterschiedliche Dateien wie [Bild zu PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/). 

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen festlegen, die bestimmen, ob

* jede Folie in der Ausgabepresentation einen einzigartigen Stil behält  
* ein einheitlicher Stil für alle Folien der Ausgabepresentation verwendet wird.  

Um Präsentationen zusammenzuführen, stellt Aspose.Slides [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)‑Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)‑Interface) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Präsentations‑Zusammenführungsprozesses definieren. Jedes Presentation‑Objekt verfügt über eine [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)‑Sammlung, sodass Sie eine `AddClone`‑Methode von der Präsentation aufrufen können, zu der Sie Folien zusammenführen möchten.  

Die `AddClone`‑Methode liefert ein `ISlide`‑Objekt zurück, das eine Kopie der Quellfolie ist. Die Folien in einer Ausgabepresentation sind einfach Kopien der Folien der Quelle. Daher können Sie die resultierenden Folien ändern (z. B. Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen beeinflusst werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)‑Methode bereit, mit der Sie Folien kombinieren können, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter).  

Dieser C#‑Code zeigt, wie Sie Präsentationen zusammenführen:  
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


## **Präsentationen mit einem Folienmaster zusammenführen** 

Aspose.Slides stellt die [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2)‑Methode bereit, mit der Sie Folien kombinieren können, während Sie eine Folienmaster‑Präsentationsvorlage anwenden. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabepresentation ändern.  

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

Das Folienlayout für den Folienmaster wird automatisch bestimmt. Wenn kein passendes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf true gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) ausgelöst. 

{{% /alert %}}

Wenn die Folien in der Ausgabepresentation ein anderes Folienlayout erhalten sollen, verwenden Sie stattdessen die [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1)‑Methode beim Zusammenführen. 

## **Bestimmte Folien aus Präsentationen zusammenführen** 

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Foliensets zu erstellen. Aspose.Slides für .NET ermöglicht es Ihnen, nur die benötigten Folien auszuwählen und zu importieren. Die API erhält Formatierung, Layout und Design der ursprünglichen Folien.  

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
  

## **Präsentationen mit einem Folienlayout zusammenführen** 

Dieser C#‑Code zeigt, wie Sie Folien aus Präsentationen kombinieren und dabei Ihr bevorzugtes Folienlayout anwenden, um eine einzige Ausgabepresentation zu erhalten:  
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

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so skalieren, dass ihre Größe der der anderen Präsentation entspricht.  

Dieser Beispielcode demonstriert den beschriebenen Vorgang:  
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

Dieser C#‑Code zeigt, wie Sie eine bestimmte Folie zu einem Abschnitt in einer Präsentation zusammenführen:  
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

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage) an. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}  

## **FAQ**  

**Are speaker notes preserved during merge?**  

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierung und Animationen.  

**Are comments and their authors transferred?**  

Kommentare werden als Teil des Folieninhalts mitkopiert. Die Autorbezeichnungen der Kommentare bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.  

**What if the source presentation is password-protected?**  

Sie muss über das [Passwort geöffnet werden](/slides/de/net/password-protected-presentation/) mittels [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/); nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.  

**How thread-safe is the merge operation?**  

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Instanz aus mehreren Threads (/slides/de/net/multithreading/). Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.