---
title: Verwalten von Folienmastern in Präsentationen mit Java
linktitle: Folienmaster
type: docs
weight: 70
url: /de/java/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT-Masterfolie
- mehrere Masterfolien
- Masterfolien vergleichen
- Hintergrund
- Platzhalter
- Masterfolie klonen
- Masterfolie kopieren
- Masterfolie duplizieren
- unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Java: Zugriff, Bearbeitung, Klonen, Vergleichen und Entfernen von Masterfolien in PowerPoint- und OpenDocument‑Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert gemeinsam genutzte Designeinstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Designthemen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters die übliche Methode, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für Java unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Masterfolien enthalten, und jede Masterfolie kann mehrere Layoutfolien enthalten. Normale Folien verweisen normalerweise nicht direkt auf eine Masterfolie. Stattdessen verwendet eine normale Folie eine Layoutfolie, und diese Layoutfolie gehört zu einer Masterfolie.

Die Hierarchie lautet:

1. **Folienmaster** – definiert das gemeinsam genutzte Design und Design‑Thema.
2. **Layoutfolie** – definiert eine bestimmte Anordnung von Platzhaltern und Layout‑Formatierungen.
3. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layoutfolie.

![Die Hierarchie von Masterfolien, Layoutfolien und Normalfolien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch das Interface [IMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) repräsentiert. Alle Masterfolien einer Präsentation sind über die Sammlung [Presentation.getMasters](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getMasters--) zugänglich, die das Interface [IMasterSlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/) implementiert.

{{% alert color="info" title="Vererbung" %}}

Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Beispielsweise, wenn eine Masterfolie und eine Layoutfolie beide einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layoutfolien finden Sie unter [Apply or Change Slide Layouts](/slides/de/java/slide-layout/).

{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Befehl Folienmaster auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Sammlung `getMasters()`, um Masterfolien zu adressieren:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Sie können die von einer normalen Folie verwendete Masterfolie auch über deren Layout ermitteln:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Inhalt einer Folienmaster**

Eine Masterfolie ist ein folienähnliches Objekt. Sie implementiert [IBaseSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/), sodass sie viele der gleichen Folieneigenschaften bereitstellt, die von normalen und Layout‑Folien verwendet werden. Master‑spezifische Mitglieder sind auf der API‑Seite [IMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) aufgelistet.

Häufig genutzte Masterfolien‑Mitglieder umfassen:

| Member | Zweck |
| --- | --- |
| `getBackground()` | Legt den master‑übergreifenden Folienhintergrund fest. |
| `getShapes()` | Speichert Formen, die auf dem Master platziert sind, wie Logos, Bildrahmen und gemeinsamen Text. |
| `getLayoutSlides()` | Enthält die Layoutfolien, die zum Master gehören. |
| `getThemeManager()` | Bietet Zugriff auf die Master‑Theme‑APIs. |
| `getHeaderFooterManager()` | Steuert Kopf‑ und Fußzeilen, Datum und Foliennummern für den Master und seine untergeordneten Layouts. |
| `getDependingSlides()` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zum Folienmaster hinzufügen**

Wenn Sie ein Bild zu einer Masterfolie hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende Bildelemente.

Das folgende Beispiel fügt das Logo zur ersten Masterfolie hinzu:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Weitere Informationen zu Bildrahmen finden Sie unter [Picture Frame](/slides/de/java/picture-frame/).

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layoutfolien definiert. Der Folienmaster stellt den gemeinsamen Stil und das Design bereit, das von diesen Layouts geerbt wird, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint stehen Platzhalter‑Befehle in der Folienmaster‑Ansicht zur Verfügung.

![Der Befehl Platzhalter einfügen in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layoutfolie, die zum Master gehört:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sie können auch Platzhalterformen formatieren, die bereits auf einer Masterfolie vorhanden sind. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatierter Titel‑Platzhalter, der von normalen Folien geerbt wird](slide-master_8.png)

Weitere Optionen zur Platzhalter‑ und Textformatierung finden Sie unter [Set Prompt Text in Placeholder](/slides/de/java/manage-placeholder/) und [Text Formatting](/slides/de/java/text-formatting/).

## **Hintergrund einer Folienmaster ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für die erste Masterfolie:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwandte Themen finden Sie unter [Presentation Background](/slides/de/java/presentation-background/) und [Presentation Theme](/slides/de/java/presentation-theme/).

## **Eine Folienmaster in eine andere Präsentation kopieren**

Verwenden Sie [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-), um eine Masterfolie in eine andere Präsentation zu kopieren. Die kopierte Masterfolie kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Wenn Sie normale Folien zusammen mit ihrem Master klonen müssen, siehe [Clone Slides](/slides/de/java/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Masterfolien enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenauftritte, Seitenstrukturen oder Designeinstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Masterfolien](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Folienmaster vergleichen**

Masterfolien können mit der von [IBaseSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/) geerbten `equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt, wie Formen, Text, Formatierung, Animationen und andere Foliens‑Einstellungen. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Weitere Informationen finden Sie unter [Compare Presentation Slides](/slides/de/java/compare-slides/).

## **Folienmaster‑Ansicht als Standardansicht festlegen**

Verwenden Sie die Methode `setLastView` auf [ViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Weitere Ansichtseinstellungen finden Sie unter [Save Presentation](/slides/de/java/save-presentation/).

## **Unbenutzte Masterfolien entfernen**

Präsentationen enthalten manchmal Masterfolien, die von keinen normalen Folien mehr verwendet werden. Das Entfernen unbenutzter Masterfolien kann die Dateigröße reduzieren und die Pflege von Vorlagen vereinfachen.

Verwenden Sie `removeUnused`, um unbenutzte Masterfolien aus der Sammlung `getMasters()` zu entfernen:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sie können auch die Low‑Code‑Methode [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) verwenden:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einer Folienmaster und einer Layoutfolie?**

Eine Folienmaster definiert gemeinsam genutzte Designeinstellungen wie Thema, Hintergrund, gemeinsame Formen und Textstile. Eine Layoutfolie gehört zu einer Masterfolie und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layoutfolie und erbt somit sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Markenauftritte benötigen.

**Soll ich Platzhalter einer Masterfolie oder einer Layoutfolie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layoutfolien hinzu. Gemeinsame Bildelemente und Formatierungen kommen auf die Masterfolie, während Inhalts‑Platzhalter auf die Layouts gehören, die von normalen Folien verwendet werden.

**Kann ich eine Masterfolie löschen, die noch verwendet wird?**

Nein. Eine Masterfolie, die abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zunächst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Bereinigungs‑Methode, die nur unbenutzte Master entfernt.