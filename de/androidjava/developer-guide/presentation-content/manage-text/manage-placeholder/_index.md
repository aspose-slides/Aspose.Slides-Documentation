---
title: Verwalten von Präsentations-Platzhaltern auf Android
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/androidjava/manage-placeholder/
keywords:
- Platzhalter
- Text‑Platzhalter
- Bild‑Platzhalter
- Diagramm‑Platzhalter
- Inhalts‑Platzhalter
- Eingabetext
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text‑, Bild‑, Diagramm‑ und Inhalts‑Platzhalter inspizieren und bearbeiten sowie die Platzhaltervererbung mit Aspose.Slides für Android über Java verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die in einer Präsentationsvorlage eine Position für eine bestimmte Art von Inhalt reserviert. Häufige Beispiele sind Titel‑, Text‑, Bild‑, Diagramm‑ und allgemeine Inhalts‑Platzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑ oder Master‑Folien‑Vorlage erben.

Aspose.Slides stellt Platzhalterinformationen über die [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)‑Methode bereit. Die Methode liefert ein [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/)‑Objekt oder `null` für eine normale Form. Verwenden Sie [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/), um zu bestimmen, welchen Inhalt der Platzhalter aufnehmen soll.

Die Form‑Schnittstelle ist weiterhin relevant, nachdem Sie den Platzhaltertyp kennen:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhalts‑Platzhalter wird meist durch ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) repräsentiert.
- Ein gefüllter Bild‑Platzhalter kann durch ein [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) dargestellt werden.
- Ein gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) dargestellt werden.
- Ein Inhalts‑Platzhalter kann verschiedene Arten von Inhalt enthalten. Prüfen Sie sowohl [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) als auch die Laufzeit‑Form‑Schnittstelle, anstatt anzunehmen, dass jeder Platzhalter ein [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ist.

{{% alert color="warning" title="Warnung" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) beschreibt die Rolle eines Platzhalters; sie garantiert nicht den Laufzeit‑Typ der Form. Verwenden Sie immer eine Typprüfung, bevor Sie auf Text‑, Bild‑, Diagramm‑, Tabellen‑ oder medienspezifische Mitglieder zugreifen.
{{% /alert %}}

## **Verstehen der Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folien definiert wiederverwendbare Stile und ggf. Master‑Platzhalter.
2. Eine Layout‑Folien definiert die Anordnung, die von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) auf, um eine Ebene höher in dieser Hierarchie zu gelangen. Ein Folien‑Platzhalter liefert normalerweise seinen Layout‑Platzhalter; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode liefert `null`, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Das Bearbeiten eines Platzhalters auf einer normalen Folie erzeugt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine normale lokale Form hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil sie dieselben Koordinaten belegt.

## **Platzhalterstatus entfernen**

Beim Anpassen einer Vorlage verwenden Sie [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) , um ein vorhandenes Objekt als normale Form zu behalten. Seine [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--)‑Methode liefert `null`, aber die Form bleibt in der Folien‑Sammlung. Im Gegensatz dazu löscht [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) die Form aus dieser Sammlung.

Das folgende Beispiel setzt `template.pptx` mit mindestens einer Folie und einem nicht leeren Text‑Platzhalter auf der ersten Folie voraus. Verwenden Sie einen Platzhalter, dessen Formatierung vom Layout oder Master geerbt wird, um die Wirkung des Entfernens dieser Beziehung zu sehen. Das Beispiel prüft, dass dieselbe Form erhalten bleibt, ruft die Methode erneut für die nun normale Form auf und speichert das Ergebnis.

{{% alert color="warning" title="Warnung" %}}
Das Entfernen des Platzhalterstatus bewahrt nicht automatisch vererbte Erscheinungseinstellungen. Das nachfolgende Beispiel lässt diese Einstellungen bewusst unverändert, sodass die Ausgabe anders aussehen kann. Eine Form, deren Position und Größe vollständig vererbt wurden, kann nach dem Aufruf Null‑Koordinaten und -Abmessungen besitzen und unsichtbar werden, obwohl sie in der Sammlung bleibt.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Der Aufruf der Methode auf einer normalen Form hat keine Auswirkung.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Für einen passenden Platzhalter geben alle drei Prüfungen `true` zurück. Der Text bleibt erhalten, aber vererbte Position, Größe, Drehung, Schrift, Absatz‑Ausrichtung, Text‑Frame‑Abstände, vertikale Verankerung, Füll‑ und Linieneinstellungen können sich ändern, wenn die Platzhalter‑Beziehung entfernt wird. Beispielsweise kann die vererbte Titel‑Formatierung wieder auf normale Text‑Formatierung zurückfallen. Siehe [Slide Layout](/slides/de/androidjava/slide-layout/) für weitere Informationen zu Layouts.

Um das gewünschte Erscheinungsbild zu bewahren, erfassen Sie vor dem Aufruf die aufgelösten Position, Größe und Drehung und kopieren die erforderlichen effektiven Formatierungswerte in separate Variablen. Rufen Sie diese Werte über [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), und [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) ab. Verlassen Sie sich nicht ausschließlich auf die effektiven Format‑Objekte, da deren Text‑Formatierungswerte nach Entfernen der Beziehung ändern können. Wenden Sie die erfassten Werte anschließend explizit auf die normale Form an, einschließlich Schriftfamilie, -größe, -stil, -farbe, Absatz‑Einstellungen, Text‑Frame‑Einstellungen, Füll‑ und Linieneinstellungen, die Ihre Vorlage verwendet.

Vererbte Formgeometrie muss möglicherweise ebenfalls über [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-) explizit zugewiesen werden. Für einen rechteckigen Text‑Platzhalter bedeutet das, [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle) zu setzen; das Wiederherstellen nur von Füll‑ und Linieneinstellungen stellt das sichtbare Rechteck nicht wieder her. Vorlagen mit zusätzlichen Effekten oder komplexerer Formatierung erfordern ebenfalls die Behandlung dieser Einstellungen.

## **Text in einem Platzhalter ändern**

Titel‑, Zentriert‑Titel‑, Untertitel‑, Text‑ und Inhalts‑Platzhalter unterstützen normalerweise Text. Prüfen Sie vor der Verwendung von [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) auf einen [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

Dieses Beispiel aktualisiert den ersten Titel‑Platzhalter auf der ersten Folie und speichert das Ergebnis:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dieses Muster vermeidet das Casten von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern zu [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Es identifiziert den Platzhalter zudem nach seiner Aufgabe statt sich auf einen zerbrechlichen Form‑Index zu verlassen.

## **Eingabetext für ein Layout festlegen**

Eingabetext ist die Design‑Zeit‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken Sie hier, um einen Titel hinzuzufügen*. Setzen Sie benutzerdefinierten Eingabetext auf den Layout‑Platzhalter, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) auf das Layout zu und iterieren Sie über die Sammlung, die [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/) liefert.

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Hinweise im Layout, das von der ersten Folie verwendet wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Eingabetext ist kein normaler Folieninhalt. Er ist für leere Platzhalter in Bearbeitungs‑Apps wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt liefert, wird der Hinweis nicht mehr angezeigt. Das Ändern eines Hinweises ersetzt außerdem keinen bereits vorhandenen Text auf Folien, die das Layout verwenden.

## **Bild‑Platzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bild‑Platzhalter bereits gefüllt ist und durch ein [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) repräsentiert wird, ersetzen Sie das Bild über [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) und [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie an den Koordinaten des Platzhalters einen Bild‑Frame mit [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) hinzu und entfernen Sie den leeren Platzhalter.

Das nächste Beispiel unterstützt beide Fälle und speichert die Präsentation:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Ersatz, der für einen leeren Platzhalter erstellt wird, ist ein lokaler Bild‑Frame, kein neuer Platzhalter, da [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) keinen Setter bereitstellt. Er behält die reservierte Position bei, erbt jedoch nicht länger das platzhalterspezifische Verhalten. Wenn das Beibehalten der Platzhalter‑Beziehung wichtig ist, erstellen und füllen Sie den Platzhalter zuerst in PowerPoint und aktualisieren Sie anschließend das resultierende [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) mit Aspose.Slides.

Für Bildtransparenz, Zuschneiden und andere bild‑spezifische Effekte siehe [Manage Picture Frames](/slides/de/androidjava/picture-frame/). Diese Vorgänge gehören zum Bild‑Frame bzw. Bild‑Füllformat, nicht zu Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhalts‑Platzhaltern**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl über den Platzhaltertyp als auch über die Laufzeit‑Schnittstelle, ändert dessen Titel und speichert die Datei:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ein allgemeiner Inhalts‑Platzhalter hat meist [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). In PowerPoint fungiert er als Launcher für mehrere Inhaltstypen, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er gefüllt ist, prüfen Sie die tatsächliche Form‑Schnittstelle, um zu erfahren, was er enthält. Spezialisierte Layouts können zudem [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), oder [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) bereitstellen.

Aspose.Slides konvertiert einen leeren [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) Platzhalter nicht in ein [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) allein durch Ändern von [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); der Typ kann über die Schnittstelle nicht geändert werden. Um ein leeres Diagramm‑ oder Inhalts‑Bereich programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters ein und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel demonstriert dies für ein Diagramm:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die speziellen [Diagramm‑Verwaltungs‑Artikel](/slides/de/androidjava/powerpoint-charts/), wenn Sie Kategorien, Reihen oder Arbeitsblatt‑Daten ersetzen müssen.

## **Vollständiges Beispiel: Text‑ oder Bild‑Inhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft Platzhalter‑ und Form‑Typen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst Annahmen über Form‑Indizes oder das Casten jedes Platzhalters zur gleichen Schnittstelle.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was ist ein Basis‑Platzhalter?**

Ein Basis‑Platzhalter ist die entsprechende Form im Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/), um ihn abzurufen. Eine gewöhnliche lokale Form liefert `null`, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können vererbte Formatierung oder Eingabetext über ein Layout ändern, aber vorhandene Titel‑Inhalte werden in den normalen Folien gespeichert. Um tatsächlichen Titel‑Text in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fuß‑Platzhalter?**

Verwenden Sie die Header‑ und Footer‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notiz‑ oder Handout‑Umfang. Siehe [Manage Presentation Header and Footer](/slides/de/androidjava/presentation-header-and-footer/) für vollständige Beispiele.