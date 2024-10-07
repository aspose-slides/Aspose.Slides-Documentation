---
title: Folienlayout
type: docs
weight: 60
url: /java/slide-layout/
keyword: "Foliengröße festlegen, Folienoptionen festlegen, Foliengröße angeben, Fußzeilen Sichtbarkeit, Kinderfußzeile, Inhalts skalierung, Seitengröße, Java, Aspose.Slides"
description: "PowerPoint-Foliengröße und Optionen in Java festlegen"
---

Ein Folienlayout enthält die Platzhalterkästchen und Formatierungsinformationen für alle Inhalte, die auf einer Folie erscheinen. Das Layout bestimmt die verfügbaren Inhalteplatzhalter und deren Platzierung.

Folienlayouts ermöglichen es Ihnen, Präsentationen schnell zu erstellen und zu gestalten (ob einfach oder komplex). Dies sind einige der beliebtesten Folienlayouts, die in PowerPoint-Präsentationen verwendet werden:

* **Titel-Folienlayout**. Dieses Layout besteht aus zwei Textplatzhaltern. Ein Platzhalter ist für den Titel und der andere für den Untertitel.
* **Titel- und Inhaltslayout**. Dieses Layout enthält einen relativ kleinen Platzhalter oben für den Titel und einen größeren Platzhalter für den Hauptinhalt (Diagramm, Absätze, Aufzählungsliste, nummerierte Liste, Bilder usw.).
* **Leeres Layout**. Dieses Layout hat keine Platzhalter, sodass Sie Elemente von Grund auf neu erstellen können.

Da ein Folienmaster die oberste hierarchische Folie ist, die Informationen über Folienlayouts speichert, können Sie die Masterfolie verwenden, um auf Folienlayouts zuzugreifen und Änderungen daran vorzunehmen. Eine Layoutfolie kann nach Typ oder Name aufgerufen werden. Jedes Folie hat ebenfalls eine eindeutige ID, die zu ihrem Zugriff verwendet werden kann.

Alternativ können Sie Änderungen direkt an einem bestimmten Folienlayout in einer Präsentation vornehmen.

* Um Ihnen die Arbeit mit Folienlayouts (einschließlich denen in Master-Folien) zu ermöglichen, bietet Aspose.Slides Eigenschaften wie [getLayoutSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) und [getMasters()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) in der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
* Um verwandte Aufgaben durchzuführen, bietet Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/baseslideheaderfootermanager/) und viele andere Typen.

{{% alert title="Info" color="info" %}}

Für weitere Informationen zur Arbeit mit Master-Folien im Besonderen siehe den Artikel [Slide Master](https://docs.aspose.com/slides/java/slide-master/).

{{% /alert %}}

## **Folie Layout zur Präsentation hinzufügen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die [MasterSlide-Sammlung](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/) zu.
1. Durchlaufen Sie die vorhandenen Layoutfolien, um zu bestätigen, dass die erforderliche Layoutfolie bereits in der Layoutfoliensammlung vorhanden ist. Andernfalls fügen Sie die gewünschte Layoutfolie hinzu.
1. Fügen Sie eine leere Folie basierend auf der neuen Layoutfolie hinzu.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein Folienlayout zu einer PowerPoint-Präsentation hinzufügen:

```java
// Erstellt eine Presentation-Klasse, die die Präsentationsdatei darstellt
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // Geht durch die Layout-Folientypen
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Die Situation, in der eine Präsentation nicht über einige Layouttypen verfügt.
        // Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layouttypen.
        // Aber Layoutfolien mit benutzerdefinierten Typen haben unterschiedliche Foliennamen,
        // wie "Titel", "Titel und Inhalt" usw. Und es ist möglich, diese
       // Namen für die Auswahl von Layoutfolien zu verwenden.
        // Sie können auch eine Reihe von Platzhalterformtypen verwenden. Zum Beispiel,
        // Das Titel-Layout sollte nur den Platzhaltertiteltyp haben usw.
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

    // Fügt leere Folie mit hinzugefügtem Layout-Folie hinzu
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // Speichert die Präsentation auf der Festplatte
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Nicht verwendetes Layout-Folie entfernen**

Aspose.Slides bietet die [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) Methode der [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) Klasse, um Ihnen zu ermöglichen, unerwünschte und unbenutzte Layoutfolien zu löschen. Dieser Java-Code zeigt Ihnen, wie Sie eine Layoutfolie aus einer PowerPoint-Präsentation entfernen:

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

Um Ihnen zu erlauben, die Größe und den Typ für eine bestimmte Layoutfolie festzulegen, bietet Aspose.Slides die Eigenschaften [getType()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--) und [getSize()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getSize--) (aus der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse). Dieser Java demonstriert den Vorgang:

```java
// Erstellt ein Presentation-Objekt, das die Präsentationsdatei darstellt
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis auf eine Folie über ihren Index.
1. Setzen Sie den Platzhalter für die Folienfußzeile auf sichtbar.
1. Setzen Sie den Platzhalter für Datum und Uhrzeit auf sichtbar.
1. Speichern Sie die Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie die Sichtbarkeit für eine Folienfußzeile festlegen (und verwandte Aufgaben ausführen):

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // Die Methode isFooterVisible wird verwendet um anzugeben, dass ein Folienfußzeilenplatzhalter fehlt
    {
        headerFooterManager.setFooterVisibility(true); // Die Methode setFooterVisibility wird verwendet, um einen Folienfußzeilenplatzhalter sichtbar zu machen
    }
    if (!headerFooterManager.isSlideNumberVisible()) // Die Methode isSlideNumberVisible wird verwendet um anzugeben, dass ein Folienseitennummerplatzhalter fehlt
    {
        headerFooterManager.setSlideNumberVisibility(true); // Die Methode setSlideNumberVisibility wird verwendet, um einen Folienseitennummerplatzhalter sichtbar zu machen
    }
    if (!headerFooterManager.isDateTimeVisible()) // Die Methode isDateTimeVisible wird verwendet um anzugeben, dass ein Folien-Datum-Uhrzeit-Platzhalter fehlt
    {
        headerFooterManager.setDateTimeVisibility(true); // Die Methode SetFooterVisibility wird verwendet, um einen Folien-Datum-Uhrzeit-Platzhalter sichtbar zu machen
    }
    headerFooterManager.setFooterText("Fußzeilentext"); // Die Methode SetFooterText wird verwendet, um einen Text für einen Folienfußzeilenplatzhalter festzulegen.
    headerFooterManager.setDateTimeText("Datum und Uhrzeit Text"); // Die Methode SetDateTimeText wird verwendet, um einen Text für einen Folien-Datum-Uhrzeit-Platzhalter festzulegen.
} finally {
    presentation.dispose();
}
```

## **Sichtbarkeit der Kinderfußzeile innerhalb der Folie festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Verweis für die Masterfolie über ihren Index.
1. Setzen Sie die Masterfolie und alle Kinderfußzeilenplatzhalter auf sichtbar.
1. Setzen Sie einen Text für die Masterfolie und alle Kinderfußzeilenplatzhalter.
1. Setzen Sie einen Text für die Masterfolie und alle Kinder-Datum-Uhrzeit-Platzhalter.
1. Speichern Sie die Präsentation.

Dieser Java-Code demonstriert den Vorgang:

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // Die Methode setFooterAndChildFootersVisibility wird verwendet, um die Masterfolie und alle Kinderfußzeilenplatzhalter sichtbar zu machen
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // Die Methode setSlideNumberAndChildSlideNumbersVisibility wird verwendet, um die Masterfolie und alle Kinderseitennummerplatzhalter sichtbar zu machen
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // Die Methode setDateTimeAndChildDateTimesVisibility wird verwendet, um die Masterfolie und alle Kinder-Datum-Uhrzeit-Platzhalter sichtbar zu machen

    headerFooterManager.setFooterAndChildFootersText("Fußzeilentext"); // Die Methode setFooterAndChildFootersText wird verwendet, um Texte für die Masterfolie und alle Kinderfußzeilenplatzhalter festzulegen
    headerFooterManager.setDateTimeAndChildDateTimesText("Datum und Uhrzeit Text"); // Die Methode setDateTimeAndChildDateTimesText wird verwendet, um einen Text für die Masterfolie und alle Kinder-Datum-Uhrzeit-Platzhalter festzulegen
} finally {
    presentation.dispose();
}
```

## **Foliengröße in Bezug auf Inhalts skalierung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse und laden Sie die Präsentation, die die Folie enthält, deren Größe Sie festlegen möchten.
1. Erstellen Sie eine andere Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse, um eine neue Präsentation zu generieren.
1. Holen Sie sich den Verweis auf die Folie (aus der ersten Präsentation) über ihren Index.
1. Setzen Sie den Platzhalter für die Folienfußzeile auf sichtbar.
1. Setzen Sie den Platzhalter für Datum und Uhrzeit auf sichtbar.
1. Speichern Sie die Präsentation.

Dieser Java-Code demonstriert den Vorgang:

```java
// Erstellt ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation presentation = new Presentation("demo.pptx");
try {
    // Setzt die Foliengröße für die generierten Präsentationen auf die der Quelle
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // Die Methode SetSize wird verwendet, um die Foliengröße mit Inhalts skalierung auf fit sicherzustellen
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // Die Methode SetSize wird verwendet, um die Foliengröße auf die maximale Größe des Inhalts festzulegen

    // Speichert die Präsentation auf der Festplatte
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Seitengröße beim Erstellen von PDF festlegen**

Bestimmte Präsentationen (wie Poster) werden häufig in PDF-Dokumente umgewandelt. Wenn Sie Ihre PowerPoint in PDF konvertieren möchten, um die besten Druck- und Zugänglichkeitsoptionen zu nutzen, möchten Sie Ihre Folien auf Größen einstellen, die für PDF-Dokumente geeignet sind (zum Beispiel A4).

Aspose.Slides bietet die [SlideSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/) Klasse, um Ihnen zu ermöglichen, Ihre bevorzugten Einstellungen für Folien anzugeben. Dieser Java-Code zeigt Ihnen, wie Sie die [getType()](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#getType--) Eigenschaft (aus der `SlideSize` Klasse) verwenden, um eine bestimmte Papiergröße für die Folien in einer Präsentation festzulegen:

```java
// Erstellt ein Presentation-Objekt, das eine Präsentationsdatei darstellt 
Presentation presentation = new Presentation();
try {
    // Setzt die SlideSize.Type-Eigenschaft  
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