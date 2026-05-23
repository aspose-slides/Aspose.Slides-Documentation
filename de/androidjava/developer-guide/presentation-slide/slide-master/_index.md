---
title: Verwalten von Folienmastern auf Android
linktitle: Folienmaster
type: docs
weight: 70
url: /de/androidjava/slide-master/
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
- Android
- Java
- Aspose.Slides
description: "Verwalten von Folienmastern in Aspose.Slides für Android via Java: Zugriff, Bearbeitung, Klonen, Vergleichen und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Slide-Master** definiert gemeinsam genutzte Designeinstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Theme-Einstellungen und Fußzeileneinstellungen enthalten. In PowerPoint ist die Bearbeitung eines Slide-Masters der übliche Weg, um eine Präsentation konsistent zu halten, ohne die gleiche Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für Android via Java unterstützt dasselbe Modell. Eine Präsentation kann ein oder mehrere Master‑Folien enthalten, und jede Master‑Folie kann mehrere Layout‑Folien enthalten. Normale Folien verweisen normalerweise nicht direkt auf eine Master‑Folie. Stattdessen verwendet eine normale Folie eine Layout‑Folie, und diese Layout‑Folie gehört zu einer Master‑Folie.

The hierarchy is:

1. **Slide-Master** - definiert das gemeinsam genutzte Design und Theme.
1. **Layout slide** - definiert eine spezifische Anordnung von Platzhaltern und Layout‑formatierungen.
1. **Normal slide** - enthält den eigentlichen Präsentationsinhalt und verwendet eine Layout‑Folie.

![Die Hierarchie von Master‑Folien, Layout‑Folien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Slide‑Master durch das Interface [IMasterSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/) dargestellt. Alle Master‑Folien in einer Präsentation sind über die Sammlung [Presentation.getMasters](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getMasters--) verfügbar, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/) implementiert. Für die vollständige Android‑via‑Java‑API-Referenz siehe die [com.aspose.slides API reference](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Beispiel: Wenn sowohl eine Master‑Folie als auch eine Layout‑Folie einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layout‑Folien finden Sie unter [Apply or Change Slide Layouts](/slides/de/androidjava/slide-layout/).
{{% /alert %}}

## **Zugriff auf Slide-Master**

In PowerPoint können Sie die Slide‑Master‑Ansicht über **Ansicht** > **Slide Master** öffnen.

![Der Slide-Master-Befehl im PowerPoint-Register „Ansicht“](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die `getMasters()`‑Sammlung, um Master‑Folien zuzugreifen:

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

Sie können auch die Master‑Folie, die von einer normalen Folie verwendet wird, über deren Layout erhalten:

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

## **Was ein Slide-Master enthält**

Eine Master‑Folie ist ein folienähnliches Objekt. Sie implementiert [IBaseSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/), sodass sie viele der gleichen Folieneigenschaften bereitstellt, die von normalen und Layout‑Folien verwendet werden.

Häufig verwendete Master‑Folie‑Member umfassen:

| Member | Zweck |
| --- | --- |
| `getBackground()` | Legt den master‑seitigen Folienhintergrund fest. |
| `getShapes()` | Speichert Formen, die auf dem Master platziert sind, wie Logos, Bildrahmen und gemeinsamen Text. |
| `getLayoutSlides()` | Speichert die Layout‑Folien, die zum Master gehören. |
| `getThemeManager()` | Stellt Zugriff auf die Master‑Theme‑APIs bereit. |
| `getHeaderFooterManager()` | Steuert Kopf‑ und Fußzeilen, Datumsangaben und Foliennummern für den Master und seine untergeordneten Layouts. |
| `getDependingSlides()` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Slide-Master hinzufügen**

Wenn Sie ein Bild zu einer Master‑Folie hinzufügen, erscheint es auf Folien, die Layout‑Folien dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederholte Bildelemente.

Das folgende Beispiel fügt dem ersten Master‑Slide ein Logo hinzu:

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

Weitere Informationen zu Bildrahmen finden Sie unter [Picture Frame](/slides/de/androidjava/picture-frame/).

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layout‑Folien definiert. Die Master‑Folie stellt den gemeinsamen Stil und das Theme bereit, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalter‑Befehle in der Slide‑Master‑Ansicht verfügbar.

![Der Befehl „Platzhalter einfügen“ in der PowerPoint‑Slide‑Master‑Ansicht](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layout‑Folie, die zum Master gehört:

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

Sie können auch Platzhalter‑Formen formatieren, die bereits auf einer Master‑Folie vorhanden sind. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

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
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatierter Titel‑Platzhalter, der von normalen Folien geerbt wird](slide-master_8.png)

Weitere Optionen für Platzhalter‑ und Textformatierung finden Sie unter [Set Prompt Text in Placeholder](/slides/de/androidjava/manage-placeholder/) und [Text Formatting](/slides/de/androidjava/text-formatting/).

## **Slide-Master-Hintergrund ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für den ersten Master‑Slide:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwandte Themen finden Sie unter [Presentation Background](/slides/de/androidjava/presentation-background/) und [Presentation Theme](/slides/de/androidjava/presentation-theme/).

## **Einen Slide-Master in eine andere Präsentation klonen**

Verwenden Sie [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-), um eine Master‑Folie in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layout‑ und Folien in der Zielpräsentation verwendet werden.

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

Wenn Sie normale Folien zusammen mit ihrem Master klonen müssen, siehe [Clone Slides](/slides/de/androidjava/clone-slides/).

## **Mehrere Slide-Master hinzufügen**

Eine Präsentation kann mehrere Master‑Folien enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenauftritte, Seitenstrukturen oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Master‑Folien](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

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

## **Slide-Master vergleichen**

Master‑Folien können mit der von [IBaseSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/) geerbten `equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt, wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht keine eindeutigen Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

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

Weitere Informationen finden Sie unter [Compare Presentation Slides](/slides/de/androidjava/compare-slides/).

## **Slide-Master-Ansicht als Standardansicht festlegen**

Verwenden Sie die `setLastView`‑Methode auf [ViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Slide‑Master‑Ansicht:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Weitere Ansichtseinstellungen finden Sie unter [Save Presentation](/slides/de/androidjava/save-presentation/).

## **Unbenutzte Master‑Folien entfernen**

Präsentationen enthalten manchmal Master‑Folien, die von keinen normalen Folien mehr verwendet werden. Das Entfernen ungenutzter Master‑Folien kann die Dateigröße verringern und die Wartung von Vorlagen vereinfachen.

Verwenden Sie `removeUnused`, um ungenutzte Master aus der `getMasters()`‑Sammlung zu entfernen:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sie können auch die Low‑Code‑Methode [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) verwenden:

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

**Was ist der Unterschied zwischen einem Slide-Master und einer Layout‑Folie?**

Ein Slide‑Master definiert gemeinsam genutzte Designeinstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layout‑Folie gehört zu einem Slide‑Master und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layout‑Folie und erbt somit sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Slide-Master enthalten?**

Ja. Eine Präsentation kann mehrere Slide‑Master enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Markenauftritte benötigen.

**Sollte ich Platzhalter zu einer Master‑Folie oder einer Layout‑Folie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layout‑Folien hinzu. Platzieren Sie gemeinsam genutzte visuelle Elemente und Formatierungen auf der Master‑Folie und die Inhalts‑Platzhalter auf den Layout‑Folien, die von normalen Folien verwendet werden.

**Kann ich eine Master‑Folie löschen, die noch verwendet wird?**

Nein. Eine Master‑Folie, die abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zunächst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Bereinigungs‑Methode für unbenutzte Master, die nur nicht verwendete Master entfernt.