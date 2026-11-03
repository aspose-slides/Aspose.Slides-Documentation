---
title: "Verwalten von Präsentationsplatzhaltern in Java"
linktitle: "Platzhalter verwalten"
type: docs
weight: 10
url: /de/java/manage-placeholder/
keywords:
- "Platzhalter"
- "Text‑Platzhalter"
- "Bild‑Platzhalter"
- "Diagramm‑Platzhalter"
- "Inhalts‑Platzhalter"
- "Hinweistext"
- "PowerPoint"
- "Präsentation"
- "Java"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie Text‑, Bild‑, Diagramm‑ und Inhalts‑Platzhalter untersuchen und bearbeiten sowie die Platzhalter‑Vererbung mit Aspose.Slides für Java verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die in einer Präsentationsvorlage eine Position für eine bestimmte Art von Inhalt reserviert. Häufige Beispiele sind Titel‑, Text‑, Bild‑, Diagramm‑ und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑ oder Master‑Folie erben.

Aspose.Slides stellt Platzhalterinformationen über die [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)‑Methode bereit. Die Methode gibt ein [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/)‑Objekt oder `null` für eine normale Form zurück. Verwenden Sie [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Die Form‑Schnittstelle bleibt auch nach Kenntnis des Platzhaltertyps wichtig:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird üblicherweise durch ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) dargestellt.
- Ein bereits befüllter Bildplatzhalter kann durch ein [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) dargestellt werden.
- Ein bereits befüllter Diagrammplatzhalter kann durch ein [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann mehrere Arten von Inhalt enthalten. Prüfen Sie sowohl [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) als auch die Laufzeit‑Form‑Schnittstelle, anstatt anzunehmen, dass jeder Platzhalter ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) beschreibt die Rolle eines Platzhalters; sie garantiert nicht den Laufzeit‑Typ der Form. Verwenden Sie immer eine Typprüfung, bevor Sie auf Text‑, Bild‑, Diagramm‑, Tabellen‑ oder medien‑spezifische Member zugreifen.
{{% /alert %}}

## **Verstehen der Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folie definiert wiederverwendbare Stile und in manchen Fällen Master‑Platzhalter.
2. Eine Layout‑Folie definiert die Anordnung, die von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) auf, um eine Ebene höher in dieser Hierarchie zu gehen. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode gibt `null` zurück, wenn die Form keinen Basis‑Platzhalter hat.

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

Das Bearbeiten eines Platzhalters auf einer normalen Folie erstellt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale normale Form hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil sie dieselben Koordinaten einnimmt.

## **Platzhalterstatus entfernen**

Wenn Sie eine Vorlage anpassen, verwenden Sie [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) , um ein vorhandenes Objekt als normale Form zu behalten. Seine [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--)‑Methode gibt `null` zurück, aber die Form bleibt in der Sammlung der Folie. Im Gegensatz dazu löscht [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) die Form aus dieser Sammlung.

Das folgende Beispiel erfordert `template.pptx` mit mindestens einer Folie und einem nicht leeren Text‑Platzhalter auf der ersten Folie. Verwenden Sie einen Platzhalter mit von seinem Layout oder Master vererbter Formatierung, um die Wirkung des Entfernens dieser Beziehung zu sehen. Das Beispiel prüft, dass die gleiche Form erhalten bleibt, ruft die Methode erneut auf der nun normalen Form auf und speichert das Ergebnis.

{{% alert color="warning" title="Warning" %}}
Das Entfernen des Platzhalterstatus bewahrt nicht automatisch vererbte Anzeigeeinstellungen. Das untenstehende Beispiel lässt diese Einstellungen bewusst unverändert, sodass die Ausgabe anders aussehen kann. Eine Form, deren Position und Größe vollständig vererbt sind, kann nach dem Aufruf Null‑Koordinaten und -Abmessungen haben und unsichtbar werden, obwohl sie in der Sammlung bleibt.
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

        // Aufrufen der Methode an einer normalen Form hat keine Auswirkung.
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

Für einen passenden Platzhalter geben alle drei Prüfungen `true` aus. Der Text bleibt erhalten, aber vererbte Position, Größe, Drehung, Schriftart, Absatz‑Ausrichtung, Text‑Rahmen‑Abstände, vertikales Ankern, Füll‑ und Linien‑Einstellungen können sich ändern, wenn die Platzhalter‑Beziehung entfernt wird. Beispielsweise kann die vererbte Titelformatierung zu einer normalen Textformatierung zurückfallen. Siehe [Slide Layout](/slides/de/java/slide-layout/) für weitere Informationen zu Layouts.

Um das beabsichtigte Aussehen zu bewahren, erfassen Sie die aufgelöste Position, Größe und Drehung vor dem Aufruf und kopieren Sie die erforderlichen effektiven Formatierungswerte in separate Variablen. Rufen Sie diese Werte über [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--), und [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) ab. Verlassen Sie sich nicht nur auf die effektiven Format‑Objekte, da deren Text‑Formatierungswerte nach dem Entfernen der Beziehung geändert werden können. Wenden Sie die erfassten Werte anschließend explizit auf die normale Form an, einschließlich Schriftfamilie, Größe, Stil, Farbe, Absatz‑Einstellungen, Text‑Rahmen‑Einstellungen, Füll‑ und Linien‑Eigenschaften Ihrer Vorlage.

Vererbte Form‑Geometrie muss eventuell ebenfalls explizit über [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-) zugewiesen werden. Für einen rechteckigen Text‑Platzhalter bedeutet das, [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle) zu setzen; das Wiederherstellen nur von Füll‑ und Linien‑Eigenschaften stellt das sichtbare Rechteck nicht wieder her. Vorlagen mit zusätzlichen Effekten oder komplexerer Formatierung erfordern ebenfalls die Behandlung dieser Einstellungen.

## **Text in einem Platzhalter ändern**

Titel‑, Zentriert‑Titel‑, Untertitel‑, Text‑ und Inhaltsplatzhalter unterstützen normalerweise Text. Prüfen Sie vor der Verwendung von [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) , ob es sich um ein [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) handelt.

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

Dieses Muster vermeidet das Casten von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern zu [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/). Es identifiziert den Platzhalter zudem nach Zweck statt nach einem anfälligen Form‑Index.

## **Prompt‑Text auf einem Layout festlegen**

Prompt‑Text ist die Design‑Zeit‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken Sie, um Titel hinzuzufügen*. Legen Sie benutzerdefinierten Prompt‑Text auf dem Layout‑Platzhalter fest, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) auf das Layout zu und iterieren Sie über die Sammlung, die von [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/) zurückgegeben wird.

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Prompts im Layout, das von der ersten Folie verwendet wird:

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

Prompt‑Text ist kein regulärer Folien‑Inhalt. Er ist für leere Platzhalter in Bearbeitungs‑Anwendungen wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt liefert, wird der Prompt nicht mehr angezeigt. Das Ändern eines Prompts ersetzt außerdem nicht den bereits vorhandenen Text auf Folien, die das Layout verwenden.

## **Ein Bildplatzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bild‑Platzhalter bereits befüllt ist und durch ein [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) repräsentiert wird, ersetzen Sie das Bild über [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) und [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie an den Koordinaten des Platzhalters ein Bild‑Frame mit [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) hinzu und entfernen Sie den leeren Platzhalter.

Das nächste Beispiel unterstützt beide Fälle und speichert die Präsentation:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

Der für einen leeren Platzhalter erzeugte Ersatz ist ein lokales Bild‑Frame, kein neuer Platzhalter, weil [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) keinen Setter bietet. Er bewahrt die reservierte Position, erbt aber nicht länger das platzhalter‑spezifische Verhalten. Wenn das Beibehalten der Platzhalter‑Beziehung wichtig ist, erstellen Sie den Platzhalter zuerst in PowerPoint und aktualisieren dann das resultierende [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) mit Aspose.Slides.

Für Bild‑Transparenz, Zuschneiden und andere bild‑spezifische Effekte siehe [Manage Picture Frames](/slides/de/java/picture-frame/). Diese Vorgänge betreffen das Bild‑Frame bzw. die Bild‑Füllung, nicht die Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhaltsplatzhaltern**

Ein befüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl nach Platzhalter‑Typ als auch nach Laufzeit‑Schnittstelle, ändert dessen Titel und speichert die Datei:

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

Ein allgemeiner Inhaltsplatzhalter hat in der Regel [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/). In PowerPoint dient er als Launcher für mehrere Inhaltsarten, einschließlich Diagrammen, Tabellen, Diagrammen, Bildern und Medien. Nachdem er befüllt wurde, inspizieren Sie die tatsächliche Form‑Schnittstelle, um zu erfahren, was er enthält. Spezialisierte Layouts können auch [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/), oder [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) ausweisen.

Aspose.Slides wandelt einen leeren [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)‑Platzhalter nicht in ein [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) um, nur indem [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) geändert wird; der Typ kann über die Schnittstelle nicht geändert werden. Um ein leeres Diagramm‑ oder Inhaltsfeld programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters ein und entfernen dann den leeren Platzhalter. Das folgende Beispiel macht das für ein Diagramm:

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

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die dedizierten [Diagramm‑Verwaltungs‑Artikel](/slides/de/java/powerpoint-charts/), wenn Sie Kategorien, Serien oder Workbook‑Daten ersetzen müssen.

## **Vollständiges Beispiel: Text‑ oder Bildinhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, sucht auf der ersten Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Form‑Typen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst Annahmen über einen Form‑Index oder das Casten jedes Platzhalters zu derselben Schnittstelle.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

Ein Basis‑Platzhalter ist die entsprechende Form im Layout oder Master, von dem ein anderer Platzhalter erbt. Verwenden Sie [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), um ihn abzurufen. Eine normale lokale Form gibt `null` zurück, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout vererbte Formatierungen oder Prompt‑Texte ändern, aber vorhandener Titelinhalt wird auf den normalen Folien gespeichert. Um den echten Titeltext in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fußzeilen‑Platzhalter?**

Verwenden Sie die Kopf‑ und Fußzeilen‑Manager im entsprechenden Folien‑, Layout‑, Master‑, Notiz‑ oder Handzettel‑Umfang. Siehe [Manage Presentation Header and Footer](/slides/de/java/presentation-header-and-footer/) für vollständige Beispiele.