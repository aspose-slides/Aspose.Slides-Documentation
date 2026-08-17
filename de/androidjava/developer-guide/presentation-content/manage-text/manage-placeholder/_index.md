---
title: Platzhalter in Präsentationen auf Android verwalten
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/androidjava/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Inhaltsplatzhalter
- Hinweistext
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text‑, Bild‑, Diagramm‑ und Inhaltsplatzhalter untersuchen und bearbeiten sowie die Platzhalter‑Vererbung mit Aspose.Slides für Android über Java verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die eine Position für eine bestimmte Art von Inhalt in einer Präsentationsvorlage reserviert. Häufige Beispiele sind Titel‑, Textkörper‑, Bild‑, Diagramm‑ und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folie oder einer Master‑Folie erben.

Aspose.Slides stellt Platzhalter‑Informationen über die Methode [IShape.getPlaceholder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) bereit. Die Methode gibt ein [IPlaceholder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholder/)‑Objekt zurück oder `null` für eine normale Form. Verwenden Sie [IPlaceholder.getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholder/), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Die Form‑Schnittstelle bleibt nach Kenntnis des Platzhaltertyps relevant:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird üblicherweise durch ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) dargestellt.
- Ein gefüllter Bildplatzhalter kann durch ein [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) dargestellt werden.
- Ein gefüllter Diagrammplatzhalter kann durch ein [IChart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann mehrere Arten von Inhalt enthalten. Prüfen Sie sowohl [IPlaceholder.getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholder/) als auch die Laufzeit‑Form‑Schnittstelle, anstatt davon auszugehen, dass jeder Platzhalter ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholder/) beschreibt die Rolle eines Platzhalters; es garantiert nicht den Laufzeittyp der Form. Verwenden Sie stets eine Typprüfung, bevor Sie auf text‑, bild‑, diagramm‑, tabellen‑ oder medienspezifische Mitglieder zugreifen.
{{% /alert %}}

## **Verstehen der Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folie definiert wiederverwendbare Stile und, in einigen Fällen, Master‑Platzhalter.
2. Eine Layout‑Folie definiert die Anordnung, die von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [IShape.getBasePlaceholder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) auf, um eine Ebene in dieser Hierarchie nach oben zu gehen. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode gibt `null` zurück, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter auf der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

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

Das Bearbeiten eines Platzhalters auf einer normalen Folie erzeugt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale normale Form hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil sie dieselben Koordinaten belegt.

## **Text in einem Platzhalter ändern**

Titel‑, zentrierter Titel‑, Untertitel‑, Textkörper‑ und Text‑Platzhalter unterstützen normalerweise Text. Prüfen Sie, ob es sich um ein [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) handelt, bevor Sie seine [getTextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/)‑Methode verwenden.

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

Dieses Muster vermeidet das Casten von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern zu [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/). Es identifiziert den Platzhalter zudem nach seiner Zweckbestimmung, anstatt sich auf einen fragilen Form‑Index zu verlassen.

## **Prompt‑Text auf einem Layout festlegen**

Prompt‑Text ist die Design‑Zeit‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken Sie, um Titel hinzuzufügen*. Setzen Sie benutzerdefinierten Prompt‑Text auf dem Layout‑Platzhalter, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [ISlide.getLayoutSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/) auf das Layout zu und iterieren Sie über die Sammlung, die von [ILayoutSlide.getShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ibaseslide/) zurückgegeben wird.

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

Prompt‑Text ist kein normaler Folieninhalt. Er ist für leere Platzhalter in Bearbeitungsprogrammen wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt bereitstellt, wird der Prompt nicht mehr angezeigt. Das Ändern eines Prompts ersetzt außerdem nicht den vorhandenen Text auf Folien, die das Layout verwenden.

## **Ein Bildplatzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bildplatzhalter bereits gefüllt ist und durch ein [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) dargestellt wird, ersetzen Sie das Bild über [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/) und [ISlidesPicture.setImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidespicture/).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie an den Koordinaten des Platzhalters einen Bildrahmen mit [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/) hinzu und entfernen Sie den leeren Platzhalter.

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

Der für einen leeren Platzhalter erstellte Ersatz ist ein lokaler Bildrahmen, kein neuer Platzhalter, weil [IShape.getPlaceholder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) keinen Setter bietet. Er behält die reservierte Position bei, erbt jedoch nicht mehr das Platzhalter‑spezifische Verhalten. Wenn die Beibehaltung der Platzhalter‑Beziehung entscheidend ist, bereiten Sie den Platzhalter in PowerPoint vor und füllen Sie dann den entstehenden [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) mit Aspose.Slides.

Für Bildtransparenz, Zuschneiden und andere bild‑spezifische Effekte siehe [Manage Picture Frames](/slides/de/androidjava/picture-frame/). Diese Vorgänge gehören zum Bildrahmen bzw. zum Bild‑Füllformat, nicht zu den Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhaltsplatzhaltern**

Ein gefüllter Diagrammplatzhalter kann durch ein [IChart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl nach Platzhaltertyp als auch nach Laufzeit‑Schnittstelle, ändert seinen Titel und speichert die Datei:

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

Ein allgemeiner Inhaltsplatzhalter hat normalerweise [PlaceholderType.Object](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholdertype/). In PowerPoint fungiert er als Starter für mehrere Inhaltsarten, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er befüllt wurde, prüfen Sie die tatsächliche Form‑Schnittstelle, um zu erfahren, was er enthält. Spezialisierte Layouts können auch [PlaceholderType.Chart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholdertype/) oder [PlaceholderType.Diagram](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholdertype/) aufweisen.

Aspose.Slides konvertiert einen leeren [IAutoShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iautoshape/) Platzhalter nicht in ein [IChart](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/), nur durch Ändern von [IPlaceholder.getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/placeholder/); der Typ kann über die Schnittstelle nicht geändert werden. Um ein leeres Diagramm‑ oder Inhaltsfeld programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters ein und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel macht das für ein Diagramm:

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

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die dedizierten [chart management articles](/slides/de/androidjava/powerpoint-charts/), wenn Sie Kategorien, Serien oder Arbeitsmappendaten ersetzen müssen.

## **Vollständiges Beispiel: Text- oder Bildinhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Form‑Typen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst Annahmen über einen Form‑Index oder das Casten jedes Platzhalters zur selben Schnittstelle.

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

Ein Basis‑Platzhalter ist die entsprechende Form im Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [IShape.getBasePlaceholder](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/), um ihn abzurufen. Eine gewöhnliche lokale Form gibt `null` zurück, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout formatierte Einstellungen oder Prompt‑Texte ändern, aber vorhandene Titelinhalte werden auf den normalen Folien gespeichert. Um den tatsächlichen Titeltext einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren Sie jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fuß‑Platzhalter?**

Verwenden Sie die Header‑ und Footer‑Manager im entsprechenden Umfang (Folien‑, Layout‑, Master‑, Notizen‑ oder Handout‑Bereich). Siehe [Manage Presentation Header and Footer](/slides/de/androidjava/presentation-header-and-footer/) für vollständige Beispiele.