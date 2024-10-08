---
title: Folienlayout
type: docs
weight: 60
url: /de/androidjava/slide-layout/
keyword: "Foliegröße festlegen, Folienoptionen festlegen, Foliengröße angeben, Fußzeilen Sichtbarkeit, Kind-Fußzeile, Inhaltsvergrößerung, Seitengröße, Java, Aspose.Slides"
description: "Foliegröße und Optionen in Java festlegen"
---

Ein Folienlayout enthält die Platzhalterkästen und Formatierungsinformationen für alle Inhalte, die auf einer Folie erscheinen. Das Layout bestimmt die verfügbaren Inhaltsplatzhalter und deren Platzierung.

Folienlayouts ermöglichen es Ihnen, Präsentationen schnell zu erstellen und zu gestalten (ob einfach oder komplex). Dies sind einige der beliebtesten Folienlayouts, die in PowerPoint-Präsentationen verwendet werden:

* **Titelfolienlayout**. Dieses Layout besteht aus zwei Textplatzhaltern. Ein Platzhalter ist für den Titel und der andere für den Untertitel.
* **Titel- und Inhaltslayout**. Dieses Layout enthält einen relativ kleinen Platzhalter oben für den Titel und einen größeren Platzhalter für den Hauptinhalt (Diagramm, Absätze, Aufzählungsliste, nummerierte Liste, Bilder usw.).
* **Leeres Layout**. Dieses Layout hat keine Platzhalter, sodass Sie Elemente von Grund auf neu erstellen können.

Da eine Foliendesignvorlage die oberste hierarchische Folie ist, die Informationen über Folienlayouts speichert, können Sie die Masterfolie verwenden, um auf Folienlayouts zuzugreifen und Änderungen vorzunehmen. Eine Layoutfolie kann durch Typ oder Name aufgerufen werden. Ebenso hat jede Folie eine eindeutige ID, die verwendet werden kann, um auf sie zuzugreifen.

Alternativ können Sie Änderungen direkt an einem bestimmten Folienlayout in einer Präsentation vornehmen.

* Um Ihnen die Arbeit mit Folienlayouts (einschließlich der in Masterfolien) zu ermöglichen, bietet Aspose.Slides Eigenschaften wie [getLayoutSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) und [getMasters()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) in der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
* Um verwandte Aufgaben durchzuführen, bietet Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslideheaderfootermanager/) und viele andere Typen.

{{% alert title="Info" color="info" %}}

Für weitere Informationen zur Arbeit mit Masterfolien im Besonderen siehe den Artikel [Slide Master](https://docs.aspose.com/slides/androidjava/slide-master/).

{{% /alert %}}

## **Folienlayout zur Präsentation hinzufügen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die [MasterSlide-Sammlung](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/) zu.
1. Durchlaufen Sie die vorhandenen Layoutfolien, um zu bestätigen, dass die benötigte Layoutfolie bereits in der Layoutfolie-Sammlung vorhanden ist. Andernfalls fügen Sie die gewünschte Layoutfolie hinzu.
1. Fügen Sie eine leere Folie basierend auf der neuen Layoutfolie hinzu.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein Folienlayout zu einer PowerPoint-Präsentation hinzufügen:

```java
// Erstellt eine Präsentationsklasse, die die Präsentationsdatei repräsentiert
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // Durchläuft die Layoutfolientypen
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Die Situation, in der eine Präsentation einige Layouttypen nicht enthält.
        // Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layouttypen.
        // Aber Layoutfolien mit benutzerdefinierten Typen haben unterschiedliche Foliennamen,
        // wie "Titel", "Titel und Inhalt" usw. Und es ist möglich, diese
        // Namen für die Auswahl von Layoutfolien zu verwenden.
        // Sie können auch eine Reihe von Platzhalterformtypen verwenden. Zum Beispiel,
        // sollte die Titelfolie nur den Platzhaltertyp Titel haben, usw.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName() == "Titel und Objekt") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName() == "Titel") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Titel und Objekt");
                }
            }
        }
    }

    // Fügt eine leere Folie mit dem hinzugefügten Layout hinzu
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // Speichert die Präsentation auf der Festplatte
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ungenutzte Layoutfolie entfernen**

Aspose.Slides bietet die [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) Methode der [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) Klasse, um unerwünschte und ungenutzte Layoutfolien zu löschen. Dieser Java-Code zeigt Ihnen, wie Sie eine Layoutfolie von einer PowerPoint-Präsentation entfernen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Größe und Typ für Folienlayout festlegen**

Um Ihnen zu ermöglichen, die Größe und den Typ für eine bestimmte Layoutfolie festzulegen, stellt Aspose.Slides die Eigenschaften [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) und [getSize()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getSize--) (aus der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse) zur Verfügung. Dieses Java-Demo zeigt die Operation:

```java
// Erstellt ein Präsentationsobjekt, das die Präsentationsdatei repräsentiert
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // Setzt die Foliengröße für die generierte Präsentation auf die der Quelle
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // Klont die erforderliche Folie
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        
        // Speichert die Präsentation auf der Festplatte
        auxPresentation.save("size.pptx", SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Sichtbarkeit der Fußzeile innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Setzen Sie den Platzhalter für die Folienfußzeile auf sichtbar. 
1. Setzen Sie den Platzhalter für Datum und Uhrzeit auf sichtbar. 
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie die Sichtbarkeit für eine Folienfußzeile festlegen (und verwandte Aufgaben durchführen):

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // Methode isFooterVisible wird verwendet um anzugeben, dass ein Platzhalter für die Folienfußzeile fehlt
    {
        headerFooterManager.setFooterVisibility(true); // Methode setFooterVisibility wird verwendet um einen Platzhalter für die Folienfußzeile sichtbar zu machen
    }
    if (!headerFooterManager.isSlideNumberVisible()) // Methode isSlideNumberVisible wird verwendet um anzugeben, dass ein Platzhalter für die Folienseitenzahl fehlt
    {
        headerFooterManager.setSlideNumberVisibility(true); // Methode setSlideNumberVisibility wird verwendet um einen Platzhalter für die Folienseitenzahl sichtbar zu machen
    }
    if (!headerFooterManager.isDateTimeVisible()) // Methode isDateTimeVisible wird verwendet um anzugeben, dass ein Platzhalter für das Folien-Datum und die Uhrzeit fehlt
    {
        headerFooterManager.setDateTimeVisibility(true); // Methode SetFooterVisibility wird verwendet um einen Platzhalter für das Folien-Datum und die Uhrzeit sichtbar zu machen
    }
    headerFooterManager.setFooterText("Fußzeilentext"); // Methode SetFooterText wird verwendet um einen Text für einen Platzhalter der Folienfußzeile festzulegen.
    headerFooterManager.setDateTimeText("Datum und Uhrzeit Text"); // Methode SetDateTimeText wird verwendet um einen Text für einen Platzhalter der Folien-Datum und -Uhrzeit festzulegen.
} finally {
    presentation.dispose();
}
```

## **Sichtbarkeit der Kind-Fußzeile innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf die Masterfolie über ihren Index.
1. Setzen Sie die Masterfolie und alle Kind-Fußzeilen Platzhalter auf sichtbar.
1. Setzen Sie einen Text für die Masterfolie und alle Kind-Fußzeilen Platzhalter. 
1. Setzen Sie einen Text für die Masterfolie und alle Kind-Datum-Uhrzeit Platzhalter. 
1. Speichern Sie die Präsentation.

Dieser Java-Code demonstriert die Operation:

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // Methode setFooterAndChildFootersVisibility wird verwendet um die Masterfolie und alle Kind-Fußzeilen Platzhalter sichtbar zu machen
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // Methode setSlideNumberAndChildSlideNumbersVisibility wird verwendet um die Masterfolie und alle Kind-Seitenzahl Platzhalter sichtbar zu machen
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // Methode setDateTimeAndChildDateTimesVisibility wird verwendet um die Masterfolie und alle Kind-Datum-Uhrzeit Platzhalter sichtbar zu machen

    headerFooterManager.setFooterAndChildFootersText("Fußzeilentext"); // Methode setFooterAndChildFootersText wird verwendet um Texte für die Masterfolie und alle Kind-Fußzeilen Platzhalter festzulegen
    headerFooterManager.setDateTimeAndChildDateTimesText("Datum und Uhrzeit Text"); // Methode setDateTimeAndChildDateTimesText wird verwendet um einen Text für die Masterfolie und alle Kind-Datum-Uhrzeit Platzhalter festzulegen
} finally {
    presentation.dispose();
}
```

## **Foliegröße im Hinblick auf Inhaltsvergrößerung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die die Folie enthält, deren Größe Sie festlegen möchten.
1. Erstellen Sie eine weitere Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse, um eine neue Präsentation zu generieren.
1. Holen Sie sich den Verweis auf die Folie (aus der ersten Präsentation) über ihren Index.
1. Setzen Sie den Platzhalter für die Folienfußzeile auf sichtbar. 
1. Setzen Sie den Platzhalter für Datum und Uhrzeit auf sichtbar. 
1. Speichern Sie die Präsentation. 

Dieser Java-Code demonstriert die Operation:

```java
// Erstellt ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
Presentation presentation = new Presentation("demo.pptx");
try {
    // Setzt die Foliengröße für die generierte Präsentationen auf die der Quelle
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // Methode SetSize wird verwendet um die Foliengröße mit skaliertem Inhalt festzulegen, um sicherzustellen, dass sie passt
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // Methode SetSize wird verwendet um die Foliengröße mit maximaler Größe des Inhalts festzulegen

    // Speichert die Präsentation auf der Festplatte
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Seitengröße beim Generieren von PDF festlegen**

Bestimmte Präsentationen (wie Poster) werden häufig in PDF-Dokumente umgewandelt. Wenn Sie Ihre PowerPoint in PDF umwandeln möchten, um die besten Druck- und Zugänglichkeitsoptionen zu erhalten, sollten Sie Ihre Folien auf Größen einstellen, die zu PDF-Dokumenten passen (zum Beispiel A4).

Aspose.Slides bietet die [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/) Klasse, um Ihnen zu ermöglichen, Ihre bevorzugten Einstellungen für Folien festzulegen. Dieser Java-Code zeigt Ihnen, wie Sie die [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) Eigenschaft (aus der `SlideSize` Klasse) verwenden, um eine bestimmte Papiergröße für die Folien in einer Präsentation festzulegen:

```java
// Erstellt ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert 
Presentation presentation = new Presentation();
try {
    // Setzt die SlideSize.Type Eigenschaft  
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // Setzt verschiedene Eigenschaften für PDF-Optionen
    PdfOptions opts = new  PdfOptions();
    opts.setSufficientResolution(600);
    
    // Speichert die Präsentation auf der Festplatte
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```