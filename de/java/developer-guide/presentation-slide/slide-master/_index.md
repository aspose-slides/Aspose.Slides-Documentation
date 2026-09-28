---
title: Verwalten von Präsentations‑Slide‑Mastern in Java
linktitle: Slide‑Master
type: docs
weight: 70
url: /de/java/slide-master/
keywords:
- Slide‑Master
- Master‑Folie
- PPT‑Master‑Folie
- Mehrere Master‑Folien
- Master‑Folien vergleichen
- Hintergrund
- Platzhalter
- Master‑Folie klonen
- Master‑Folie kopieren
- Master‑Folie duplizieren
- Unbenutzte Master‑Folie
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten von Slide-Mastern in Aspose.Slides für Java: Zugriff, Bearbeitung, Klonen, Vergleichen und Entfernen von Master‑Folien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Slide-Master** definiert gemeinsame Design‑Einstellungen für eine Gruppe von Folien. Er kann gängige Formen, Logos, Hintergründe, Textstile, Theme‑Einstellungen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Slide‑Masters die übliche Methode, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides for Java unterstützt dasselbe Modell. Eine Präsentation kann ein oder mehrere Master‑Folien enthalten, und jede Master‑Folie kann mehrere Layout‑Folien enthalten. Normalfolien verweisen normalerweise nicht direkt auf eine Master‑Folie. Stattdessen verwendet eine Normalfolie eine Layout‑Folie, und diese Layout‑Folie gehört zu einer Master‑Folie.

Die Hierarchie ist:

1. **Slide-Master** – definiert das gemeinsame Design und Theme.  
2. **Layout‑Folie** – definiert eine spezifische Anordnung von Platzhaltern und layoutbezogene Formatierung.  
3. **Normalfolie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layout‑Folie.

![Die Hierarchie von Master‑Folien, Layout‑Folien und Normalfolien](slide-master_2.jpg)

In Aspose.Slides wird ein Slide‑Master durch das Interface [IMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) repräsentiert. Alle Master‑Folien in einer Präsentation sind über die Sammlung [Presentation.getMasters](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getMasters--) verfügbar, die [IMasterSlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/) implementiert.

{{% alert color="info" title="Inheritance" %}}
Wenn dieselbe Eigenschaft auf mehreren Ebenen definiert ist, gewinnt die spezifischere Ebene. Beispiel: Wenn sowohl eine Master‑Folie als auch eine Layout‑Folie einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layout‑Folien finden Sie unter [Apply or Change Slide Layouts](/slides/de/java/slide-layout/).
{{% /alert %}}

## **Zugriff auf Slide-Master**

In PowerPoint können Sie die Slide‑Master‑Ansicht über **Ansicht** > **Slide Master** öffnen.

![Der Slide-Master‑Befehl auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Sammlung `getMasters()`, um Master‑Folien zuzugreifen:

```java
import com.aspose.slides.*;

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

Sie können die von einer Normalfolie verwendete Master‑Folie auch über deren Layout abrufen:

```java
import com.aspose.slides.*;

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

Ein Master‑Slide ist ein slide‑ähnliches Objekt. Es implementiert [IBaseSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/), sodass es viele der gleichen Folieneigenschaften bereitstellt, die von Normal‑ und Layout‑Folien verwendet werden. Master‑spezifische Mitglieder sind auf der API‑Seite [IMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslide/) aufgeführt.

Häufig verwendete Master‑Folie‑Mitglieder umfassen:

| Mitglied | Zweck |
| --- | --- |
| `getBackground()` | Setzt den Master‑Ebene Folienhintergrund. |
| `getShapes()` | Speichert Formen, die auf dem Master platziert sind, wie Logos, Bildrahmen und gemeinsamen Text. |
| `getLayoutSlides()` | Speichert die Layout‑Folien, die zum Master gehören. |
| `getThemeManager()` | Bietet Zugriff auf die Master‑Theme‑APIs. |
| `getHeaderFooterManager()` | Steuert Kopf‑ und Fußzeilen, Datumsangaben und Folienzahlen für den Master und seine untergeordneten Layouts. |
| `getDependingSlides()` | Gibt Normalfolien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Slide-Master hinzufügen**

Wenn Sie ein Bild zu einer Master‑Folie hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende Bildelemente.

Das folgende Beispiel fügt dem ersten Master‑Slide ein Logo hinzu:

```java
import com.aspose.slides.*;

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

## **Sichtbarkeit von Master‑Grafiken steuern**

Verwenden Sie [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-), um geerbte Master‑Grafiken, wie Logos oder dekorative Formen, auszublenden, ohne sie aus dem Master zu löschen. Übergeben Sie `false` an [Slide.setShowMasterShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) auf der Folie, die diese Grafiken weglassen soll, und lassen Sie sie `true` auf Folien, die sie anzeigen sollen.

Das folgende eigenständige Beispiel erstellt ein blaues dekoratives Band auf einem Master und zwei Folien, die das gleiche leere Layout verwenden. Das Band ist auf der ersten Folie sichtbar und auf der zweiten ausgeblendet. Keine Eingabepräsentation oder Bild ist erforderlich.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Beispiel verwendet das mit einer neuen Präsentation gelieferte **Blank**‑Layout und entfernt die eigenen Platzhalter der Ausgangsfolie.

### **Den Geltungsbereich der Einstellung wählen**

Eine Normalfolie verwendet ihren Master über [ISlide.getLayoutSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getLayoutSlide--) und [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Das Setzen der Eigenschaft auf einer einzelnen Folie wirkt nur auf dieser Folie. Das Übergeben von `false` an [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) blendet Master‑Grafiken für Folien aus, die dieses gemeinsam genutzte Layout verwenden, selbst wenn deren eigene Einstellung `true` ist. Um Grafiken nur auf einer Folie auszublenden, ändern Sie die Folien‑Eigenschaft und lassen das gemeinsam genutzte Layout unverändert.

Die Einstellung wird nicht als Sichtbarkeitssteuerung auf dem Master‑Slide selbst unterstützt. Auf einem Master gibt [getShowMasterShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/masterslide/#getShowMasterShapes--) immer `false` zurück, und das Übergeben von `true` an [setShowMasterShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) wirft eine Ausnahme. Wenden Sie sie stattdessen auf eine Normalfolie oder ein Layout an.

### **Grafiken vom Hintergrund unterscheiden**

| Vorgang | Wirkung |
| --- | --- |
| Master‑Grafiken ausblenden | Steuert die Sichtbarkeit geerbter Master‑Formen, ohne sie zu löschen oder die eigenen Formen der Folie zu ändern. |
| Hintergrundfüllung der Folie ändern | Ändert die Hintergrundfarbe, den Verlauf oder das Bild. Master‑Grafiken sind separate Formen und können über diesem Hintergrund sichtbar bleiben. Siehe [Presentation Background](/slides/de/java/presentation-background/). |
| Eine Form vom Master löschen | Entfernt die gemeinsame Quellform, sodass sie für keine Folie, die diesen Master verwendet, mehr verfügbar ist. |

## **Mit Platzhaltern arbeiten**

Platzhalter werden normalerweise auf Layout‑Folien definiert. Der Master‑Slide stellt den gemeinsamen Stil und das Theme bereit, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalterbefehle in der Slide‑Master‑Ansicht verfügbar.

![Der Befehl 'Platzhalter einfügen' in der Slide‑Master‑Ansicht von PowerPoint](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layout‑Folie, die zum Master gehört:

```java
import com.aspose.slides.*;

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

Sie können auch Platzhalterformen formatieren, die bereits auf einer Master‑Folie existieren. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatierter Titelsplatzhalter, der von Normalfolien geerbt wird](slide-master_8.png)

Weitere Optionen für Platzhalter‑ und Textformatierung finden Sie unter [Set Prompt Text in Placeholder](/slides/de/java/manage-placeholder/) und [Text Formatting](/slides/de/java/text-formatting/).

## **Slide-Master-Hintergrund ändern**

Ein Master‑Hintergrund wird von Layouts und Folien übernommen, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für die erste Master‑Folie:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Ein Slide-Master in eine andere Präsentation klonen**

Verwenden Sie [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-), um eine Master‑Folie in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```java
import com.aspose.slides.*;

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

Wenn Sie Normalfolien zusammen mit ihrem Master klonen müssen, siehe [Clone Slides](/slides/de/java/clone-slides/).

## **Mehrere Slide-Master hinzufügen**

Eine Präsentation kann mehrere Master‑Folien enthalten. Das ist nützlich, wenn unterschiedliche Abschnitte verschiedene Marken, Seitenstrukturen oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Master‑Folien](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Slide-Master vergleichen**

Master‑Folien können mit der von [IBaseSlide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ibaseslide/) geerbten `equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt, wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

```java
import com.aspose.slides.*;

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

## **Slide-Master-Ansicht als Standardansicht festlegen**

Verwenden Sie die Methode `setLastView` auf [ViewProperties](https://reference.aspose.com/slides/de/java/com.aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Slide‑Master‑Ansicht:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Weitere Ansichtseinstellungen finden Sie unter [Save Presentation](/slides/de/java/save-presentation/).

## **Unbenutzte Master‑Folien entfernen**

Präsentationen enthalten manchmal Master‑Folien, die von keiner Normalfolie mehr verwendet werden. Das Entfernen unbenutzter Master‑Folien kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie `removeUnused`, um unbenutzte Master‑Folien aus der Sammlung `getMasters()` zu entfernen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sie können auch die Low‑Code‑Methode [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) nutzen:

```java
import com.aspose.slides.*;

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

Ein Slide‑Master definiert gemeinsame Design‑Einstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layout‑Folie gehört zu einem Slide‑Master und definiert eine spezifische Anordnung von Platzhaltern. Eine Normalfolie verwendet eine Layout‑Folie, sodass sie sowohl vom Layout als auch vom Master erbt.

**Kann eine Präsentation mehrere Slide-Master enthalten?**

Ja. Eine Präsentation kann mehrere Slide‑Master enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Marken benötigen.

**Soll ich Platzhalter zu einem Slide-Master oder zu einer Layout‑Folie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layout‑Folien hinzu. Gemeinsame visuelle Elemente und gemeinsame Formatierungen kommen auf den Slide‑Master, die Inhalts‑Platzhalter kommen auf die Layout‑Folien, die von Normalfolien verwendet werden.

**Kann ich einen Slide-Master löschen, der noch verwendet wird?**

Nein. Ein Slide‑Master, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zuerst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Bereinigungs‑Methode für unbenutzte Master, die nur Master entfernt, die nicht verwendet werden.