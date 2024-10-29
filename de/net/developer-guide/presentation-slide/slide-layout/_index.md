---
title: Folienlayout
type: docs
weight: 60
url: /de/net/slide-layout/
keyword: "Foliengröße festlegen, Folienoptionen festlegen, Foliengröße angeben, Fußzeilen-Sichtbarkeit, untere Fußzeile, Inhaltsverhältnis, Seitenformat, C#, Csharp, .NET, Aspose.Slides"
description: "Foliengröße und -optionen in C# oder .NET festlegen"
---

Ein Folienlayout enthält die Platzhalter und Formatierungsinformationen für alle Inhalte, die auf einer Folie erscheinen. Das Layout bestimmt die verfügbaren Platzhalter für Inhalte und deren Platzierung.

Folienlayouts ermöglichen es Ihnen, Präsentationen schnell zu erstellen und zu gestalten (egal ob einfach oder komplex). Dies sind einige der beliebtesten Folienlayouts, die in PowerPoint-Präsentationen verwendet werden:

* **Titelfolienlayout**. Dieses Layout besteht aus zwei Textplatzhaltern. Ein Platzhalter ist für den Titel und der andere ist für den Untertitel.
* **Titel- und Inhaltslayout**. Dieses Layout enthält oben einen relativ kleinen Platzhalter für den Titel und einen größeren Platzhalter für den Hauptinhalt (Diagramm, Absätze, Aufzählungsliste, nummerierte Liste, Bilder usw.).
* **Leeres Layout**. Dieses Layout hat keine Platzhalter, sodass Sie Elemente von Grund auf neu erstellen können.

Da eine Masterfolie die oberste hierarchische Folie ist, die Informationen über Folienlayouts speichert, können Sie die Masterfolie verwenden, um auf Folienlayouts zuzugreifen und Änderungen an ihnen vorzunehmen. Ein Layout-Folie kann nach Typ oder Name aufgerufen werden. Ebenso hat jede Folie eine eindeutige ID, die verwendet werden kann, um darauf zuzugreifen.

Alternativ können Sie Änderungen direkt an einem bestimmten Folienlayout in einer Präsentation vornehmen.

* Um Ihnen die Arbeit mit Folienlayouts (einschließlich der in Masterfolien) zu ermöglichen, bietet Aspose.Slides Eigenschaften wie [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) und [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) innerhalb der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
* Um verwandte Aufgaben auszuführen, stellt Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/) und viele andere Typen zur Verfügung.

{{% alert title="Info" color="info" %}}

Für weitere Informationen zur Arbeit mit Masterfolien im Besonderen siehe den Artikel [Slide Master](https://docs.aspose.com/slides/net/slide-master/).

{{% /alert %}}

## **Folienlayout zur Präsentation hinzufügen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die [MasterSlide-Sammlung](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/) zu.
1. Gehen Sie durch die vorhandenen Layoutfolien, um zu bestätigen, dass die erforderliche Layoutfolie bereits in der Layoutfoliensammlung vorhanden ist. Andernfalls fügen Sie die gewünschte Layoutfolie hinzu.
1. Fügen Sie eine leere Folie basierend auf der neuen Layoutfolie hinzu.
1. Speichern Sie die Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie ein Folienlayout zu einer PowerPoint-Präsentation hinzufügen:

```c#
// Instanziiert eine Präsentationsklasse, die die Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Geht durch die Layoutfolien-Typen
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Die Situation, in der eine Präsentation einige Layouttypen nicht enthält.
        // Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layouttypen.
        // Aber Layoutfolien mit benutzerdefinierten Typen haben unterschiedliche Foliennamen,
        // wie "Titel", "Titel und Inhalt" usw. Und es ist möglich, diese
        // Namen zur Auswahl der Layoutfolie zu verwenden.
        // Sie können auch eine Reihe von Platzhaltertformtypen verwenden. Zum Beispiel,
        // sollte die Titelfolie nur den Platzhaltertyp für den Titel haben usw.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Titel und Objekt")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Titel")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Titel und Objekt");
                }
            }
        }
    }

    // Fügt eine leere Folie mit der hinzugefügten Layoutfolie hinzu
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Speichert die Präsentation auf der Festplatte  
    presentation.Save("AddLayoutSlides_out.pptx", SaveFormat.Pptx);
}
```

## **Nicht verwendete Layoutfolie entfernen**

Aspose.Slides bietet die [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) Methode aus der [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) Klasse, um Ihnen zu ermöglichen, unerwünschte und nicht verwendete Layoutfolien zu löschen. Dieser C#-Code zeigt Ihnen, wie Sie eine Layoutfolie aus einer PowerPoint-Präsentation entfernen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Größe und Typ für Folienlayout festlegen**

Um Ihnen zu ermöglichen, die Größe und den Typ für eine bestimmte Layoutfolie festzulegen, bietet Aspose.Slides die Eigenschaften [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/type) und [Size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/size) (aus der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse) an. Dieser C#-Code demonstriert den Vorgang:

```c#
// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Legt die Foliengröße für die generierte Präsentation auf die des Quellformats fest
auxPresentation.SlideSize.SetSize(presentation.SlideSize.Type,SlideSizeScaleType.EnsureFit);

auxPresentation.Slides.InsertClone(0, slide);
auxPresentation.Slides.RemoveAt(0);
// Speichert die Präsentation auf der Festplatte
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Sichtbarkeit der Fußzeile innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich einen Verweis auf die Folie über ihren Index.
1. Stellen Sie sicher, dass der Platzhalter für die Fußzeile sichtbar ist. 
1. Stellen Sie sicher, dass der Platzhalter für das Datum und die Uhrzeit sichtbar ist. 
1. Speichern Sie die Präsentation. 

Dieser C#-Code zeigt Ihnen, wie Sie die Sichtbarkeit für eine Folienfußzeile (und verwandte Aufgaben) festlegen:

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[0].HeaderFooterManager;
    if (!headerFooterManager.IsFooterVisible) // Eigenschaft IsFooterVisible wird verwendet, um anzugeben, dass ein Platzhalter für die Folienfußzeile fehlt
    {
        headerFooterManager.SetFooterVisibility(true); // Methode SetFooterVisibility wird verwendet, um einen Platzhalter für die Folienfußzeile sichtbar zu machen
    }
    if (!headerFooterManager.IsSlideNumberVisible) // Eigenschaft IsSlideNumberVisible wird verwendet, um anzugeben, dass ein Platzhalter für die Foliennummer fehlt
    {
        headerFooterManager.SetSlideNumberVisibility(true); // Methode SetSlideNumberVisibility wird verwendet, um einen Platzhalter für die Foliennummer sichtbar zu machen
    }
    if (!headerFooterManager.IsDateTimeVisible) // Eigenschaft IsDateTimeVisible wird verwendet, um anzugeben, dass ein Platzhalter für das Datum und die Uhrzeit fehlt
    {
        headerFooterManager.SetDateTimeVisibility(true); // Methode SetFooterVisibility wird verwendet, um einen Platzhalter für Datum und Uhrzeit sichtbar zu machen
    }
    headerFooterManager.SetFooterText("Fußzeilentext"); // Methode SetFooterText wird verwendet, um einen Text für den Platzhalter der Folienfußzeile festzulegen
    headerFooterManager.SetDateTimeText("Datum und Uhrzeit Text"); // Methode SetDateTimeText wird verwendet, um einen Text für den Platzhalter für Datum und Uhrzeit festzulegen.

	presentation.Save("Presentation.ppt",SaveFormat.ppt);
}
```

## **Sichtbarkeit der unteren Fußzeile innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich einen Verweis auf die Masterfolie über ihren Index. 
1. Stellen Sie sicher, dass die Masterfolie und alle unteren Fußzeilenplatzhalter sichtbar sind.
1. Legen Sie einen Text für die Masterfolie und alle unteren Fußzeilenplatzhalter fest. 
1. Legen Sie einen Text für die Masterfolie und alle unteren Datum- und Uhrzeitplatzhalter fest. 
1. Speichern Sie die Präsentation. 

Dieser C#-Code demonstriert den Vorgang:

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
    headerFooterManager.SetFooterAndChildFootersVisibility(true); // Methode SetFooterAndChildFootersVisibility wird verwendet, um die Masterfolie und alle unteren Fußzeilenplatzhalter sichtbar zu machen
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // Methode SetSlideNumberAndChildSlideNumbersVisibility wird verwendet, um die Masterfolie und alle unteren Seitenzahlplatzhalter sichtbar zu machen
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // Methode SetDateTimeAndChildDateTimesVisibility wird verwendet, um eine Masterfolie und alle unteren Datum- und Uhrzeitplatzhalter sichtbar zu machen

    headerFooterManager.SetFooterAndChildFootersText("Fußzeilentext"); // Methode SetFooterAndChildFootersText wird verwendet, um Texte für die Masterfolie und alle unteren Fußzeilenplatzhalter festzulegen
    headerFooterManager.SetDateTimeAndChildDateTimesText("Datum und Uhrzeit Text"); // Methode SetDateTimeAndChildDateTimesText wird verwendet, um Text für die Masterfolie und alle unteren Datum- und Uhrzeitplatzhalter festzulegen
}
```

## **Foliengröße in Bezug auf Inhaltsverhältnis festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse und laden Sie die Präsentation, die die Folie enthält, deren Größe Sie festlegen möchten. 
1. Erstellen Sie eine weitere Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse, um eine neue Präsentation zu generieren. 
1. Holen Sie sich den Verweis auf die Folie (aus der ersten Präsentation) über ihren Index.
1. Stellen Sie sicher, dass der Platzhalter für die Fußzeile sichtbar ist. 
1. Stellen Sie sicher, dass der Platzhalter für das Datum und die Uhrzeit sichtbar ist. 
1. Speichern Sie die Präsentation. 

Dieser C#-Code demonstriert den Vorgang:

```c#
// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Setzt die Foliengröße für die generierten Präsentationen auf die des Quellformats
presentation.SlideSize.SetSize(540, 720, SlideSizeScaleType.EnsureFit); // Methode SetSize wird verwendet, um die Foliengröße mit Inhaltsskala festzulegen
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // Methode SetSize wird verwendet, um die Foliengröße auf die maximale Größe des Inhalts festzulegen
           
// Speichert die Präsentation auf der Festplatte
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Seitenformat beim Erstellen von PDF festlegen**

Bestimmte Präsentationen (wie Poster) werden oft in PDF-Dokumente konvertiert. Wenn Sie Ihre PowerPoint in PDF konvertieren möchten, um die besten Druck- und Zugänglichkeitsoptionen zu nutzen, sollten Sie Ihre Folien auf Formate einstellen, die für PDF-Dokumente geeignet sind (z.B. A4).

Aspose.Slides bietet die [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/) Klasse, um Ihnen zu ermöglichen, Ihre bevorzugten Einstellungen für Folien anzugeben. Dieser C#-Code zeigt Ihnen, wie Sie die [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/type/) Eigenschaft (aus der `SlideSize` Klasse) verwenden, um eine bestimmte Papiergröße für die Folien in einer Präsentation festzulegen:

```c#
// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation();

// Setzt die SlideSize.Type Eigenschaft 
presentation.SlideSize.SetSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);

// Setzt verschiedene Eigenschaften für PDF-Optionen
PdfOptions opts = new  PdfOptions();
opts.SufficientResolution = 600;

// Speichert die Präsentation auf der Festplatte
presentation.Save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
```