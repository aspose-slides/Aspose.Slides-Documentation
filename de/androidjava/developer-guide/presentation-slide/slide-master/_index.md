---
title: Verwalten von Folienmastern in Präsentationen auf Android
linktitle: Folienmaster
type: docs
weight: 70
url: /de/androidjava/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT Masterfolie
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
description: "Verwalten von Folienmastern in Aspose.Slides für Android via Java: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Masterfolien in PowerPoint- und OpenDocument‑Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert gemeinsam genutzte Design‑Einstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Designeinstellungen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters der übliche Weg, um eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides for Android via Java unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Folienmaster enthalten, und jeder Folienmaster kann mehrere Layoutfolien enthalten. Normalfolien verweisen normalerweise nicht direkt auf einen Folienmaster. Stattdessen verwendet eine Normalfolie eine Layoutfolie, und diese Layoutfolie gehört zu einem Folienmaster.

Die Hierarchie ist:

1. **Folienmaster** – definiert das gemeinsame Design und das Theme.  
1. **Layoutfolie** – definiert eine spezifische Anordnung von Platzhaltern und Layout‑Level‑Formatierungen.  
1. **Normalfolie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layoutfolie.

![Die Hierarchie von Folienmastern, Layoutfolien und Normalfolien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch die Schnittstelle [IMasterSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslide/) repräsentiert. Alle Folienmaster in einer Präsentation sind über die Sammlung [Presentation.getMasters](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getMasters--) verfügbar, die das Interface [IMasterSlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/) implementiert. Für die vollständige Android‑via‑Java‑API‑Oberfläche siehe die [com.aspose.slides API‑Referenz](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Beispielsweise gilt bei einer Hintergrunddefinition sowohl im Folienmaster als auch in der Layoutfolie der Hintergrund der Layoutfolie für Folien, die auf diesem Layout basieren. Weitere Informationen zu Layoutfolien finden Sie unter [Folienlayouts anwenden oder ändern](/slides/de/androidjava/slide-layout/).
{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Folienmaster‑Befehl auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Sammlung `getMasters()`, um Folienmaster zuzugreifen:

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

Sie können den von einer Normalfolie verwendeten Folienmaster auch über ihr Layout erhalten:

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

## **Was ein Folienmaster enthält**

Ein Folienmaster ist ein folienähnliches Objekt. Er implementiert [IBaseSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/), sodass er viele der gleichen Folieneigenschaften bereitstellt, die von Normal‑ und Layoutfolien verwendet werden.

Häufig genutzte Folienmaster‑Mitglieder umfassen:

| Element | Zweck |
| --- | --- |
| `getBackground()` | Setzt den Folienhintergrund auf Master‑Ebene. |
| `getShapes()` | Speichert Formen, die auf dem Master platziert wurden, wie Logos, Bildrahmen und gemeinsam genutzten Text. |
| `getLayoutSlides()` | Speichert die Layoutfolien, die zum Master gehören. |
| `getThemeManager()` | Stellt Zugriff auf die Master‑Theme‑APIs bereit. |
| `getHeaderFooterManager()` | Steuert Kopf‑ und Fußzeilen, Datum und Foliennummern für den Master und seine untergeordneten Layouts. |
| `getDependingSlides()` | Gibt Normalfolien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederkehrende Bildelemente.

Das folgende Beispiel fügt dem ersten Folienmaster ein Logo hinzu:

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

Weitere Informationen zu Bildrahmen finden Sie unter [Bildrahmen](/slides/de/androidjava/picture-frame/).

## **Die Sichtbarkeit von Master‑Grafiken steuern**

Verwenden Sie [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-), um geerbte Master‑Grafiken wie Logos oder dekorative Formen auszublenden, ohne sie aus dem Master zu löschen. Übergeben Sie `false` an [Slide.setShowMasterShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) auf der Folie, die diese Grafiken weglassen soll, und lassen Sie den Wert `true` auf Folien, die sie anzeigen sollen.

Das folgende eigenständige Beispiel erstellt ein blaues dekoratives Band auf einem Master und zwei Folien, die dasselbe leere Layout verwenden. Das Band ist auf der ersten Folie sichtbar und auf der zweiten ausgeblendet. Keine Eingabe‑Präsentation oder Bild ist erforderlich.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

Das Beispiel verwendet das **Blank**‑Layout, das einer neuen Präsentation beigefügt ist, und entfernt die eigenen Platzhalter der Ausgangsfolie.

### **Den Geltungsbereich der Einstellung wählen**

Eine Normalfolie verwendet ihren Master über [ISlide.getLayoutSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#getLayoutSlide--) und [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). Das Setzen der Eigenschaft auf einer einzelnen Folie wirkt nur auf diese Folie. Das Übergeben von `false` an [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) blendet Master‑Grafiken für alle Folien aus, die dieses gemeinsame Layout verwenden, selbst wenn deren eigene Einstellung `true` ist. Um Grafiken nur auf einer Folie auszublenden, ändern Sie die Folien‑Eigenschaft und lassen das geteilte Layout unverändert.

Die Einstellung wird auf dem Folienmaster selbst nicht als Sichtbarkeitssteuerung unterstützt. Auf einem Master gibt [getShowMasterShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) stets `false` zurück, und das Übergeben von `true` an [setShowMasterShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) löst eine Ausnahme aus. Wenden Sie sie stattdessen auf eine Normalfolie oder ein Layout an.

### **Grafiken vom Hintergrund unterscheiden**

| Vorgang | Auswirkung |
| --- | --- |
| Master‑Grafiken ausblenden | Steuert die Sichtbarkeit geerbter Master‑Formen, ohne sie zu löschen oder die eigenen Formen der Folie zu ändern. |
| Hintergrundfüllung der Folie ändern | Ändert die Hintergrundfarbe, den Farbverlauf oder das Bild. Master‑Grafiken sind separate Formen und können über diesem Hintergrund sichtbar bleiben. Siehe [Presentation Background](/slides/de/androidjava/presentation-background/). |
| Form vom Master löschen | Entfernt die gemeinsam genutzte Ausgangsform, sodass sie für keine Folie mehr verfügbar ist, die diesen Master verwendet. |

## **Mit Platzhaltern arbeiten**

Platzhalter werden normalerweise auf Layoutfolien definiert. Der Folienmaster stellt den gemeinsam genutzten Stil und das Theme bereit, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalter‑Befehle in der Folienmaster‑Ansicht verfügbar.

![Der Platzhalter‑Einfügen‑Befehl in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layoutfolie, die zum Master gehört:

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

Sie können auch Platzhalterformen formatieren, die bereits auf einem Folienmaster vorhanden sind. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

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

![Formatierter Titel‑Platzhalter, der von Normalfolien geerbt wird](slide-master_8.png)

Weitere Optionen für Platzhalter‑ und Textformatierung finden Sie unter [Platzhalter‑Eingabetext festlegen](/slides/de/androidjava/manage-placeholder/) und [Textformatierung](/slides/de/androidjava/text-formatting/).

## **Hintergrund eines Folienmasters ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einheitliche Hintergrundfarbe für den ersten Folienmaster:

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

Weitere verwandte Themen finden Sie unter [Presentation Background](/slides/de/androidjava/presentation-background/) und [Presentation Theme](/slides/de/androidjava/presentation-theme/).

## **Einen Folienmaster in eine andere Präsentation klonen**

Verwenden Sie [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-), um einen Folienmaster in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

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

Wenn Sie Normalfolien zusammen mit ihrem Master klonen möchten, siehe [Folien klonen](/slides/de/androidjava/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Folienmaster enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Marken‑, Seiten‑Strukturen oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Folienmastern](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

Folienmaster können mit der von [IBaseSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/) geerbten `equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalter‑Werte wie das aktuelle Datum.

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

Weitere Informationen finden Sie unter [Präsentationsfolien vergleichen](/slides/de/androidjava/compare-slides/).

## **Folienmaster‑Ansicht als Standardansicht festlegen**

Verwenden Sie die Methode `setLastView` auf [ViewProperties](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

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

Weitere Ansichtseinstellungen finden Sie unter [Präsentation speichern](/slides/de/androidjava/save-presentation/).

## **Unbenutzte Folienmaster entfernen**

Präsentationen enthalten manchmal Folienmaster, die von keiner Normalfolie mehr verwendet werden. Das Entfernen unbenutzter Master kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie `removeUnused`, um unbenutzte Master aus der Sammlung `getMasters()` zu entfernen:

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

Sie können außerdem die Low‑Code‑Methode [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) verwenden:

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

**Was ist der Unterschied zwischen einem Folienmaster und einer Layoutfolie?**

Ein Folienmaster definiert gemeinsam genutzte Design‑Einstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layoutfolie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine Normalfolie verwendet eine Layoutfolie und erbt somit sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Marken benötigen.

**Soll ich Platzhalter zu einem Folienmaster oder zu einer Layoutfolie hinzufügen?**

In den meisten Fällen fügen Sie Platzhalter zu Layoutfolien hinzu. Gemeinsame visuelle Elemente und gemeinsame Formatierungen kommen auf den Folienmaster, während Inhalts‑Platzhalter auf den Layouts liegen, die von Normalfolien verwendet werden.

**Kann ich einen Folienmaster löschen, der noch verwendet wird?**

Nein. Ein Folienmaster, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zunächst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Aufräummethode, die nur ungenutzte Master entfernt.