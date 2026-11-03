---
title: Verwalten von Präsentationsplatzhaltern in Python
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/python-java/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Inhaltsplatzhalter
- Aufforderungstext
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text-, Bild-, Diagramm- und Inhaltsplatzhalter inspizieren und bearbeiten und das Erben von Platzhaltern mit Aspose.Slides für Python über Java verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die in einer Präsentationsvorlage eine Position für eine bestimmte Art von Inhalt reserviert. Häufige Beispiele sind Titel-, Text-, Bild-, Diagramm- und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folie oder einer Master‑Folie erben.

Aspose.Slides stellt Platzhalterinformationen über die Methode [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) bereit. Die Methode gibt ein [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/)‑Objekt oder `None` für eine normale Form zurück. Verwenden Sie [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Der Formtyp ist weiterhin relevant, nachdem Sie den Platzhaltertyp kennen:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird üblicherweise durch eine [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) repräsentiert.
- Ein gefüllter Bildplatzhalter kann durch einen [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) dargestellt werden.
- Ein gefüllter Diagrammplatzhalter kann durch ein [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann verschiedene Inhaltsarten enthalten. Prüfen Sie sowohl [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) als auch den Laufzeit‑Formtyp, anstatt anzunehmen, dass jeder Platzhalter eine [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) beschreibt die Rolle eines Platzhalters; sie garantiert nicht den Laufzeit‑Formtyp. Verwenden Sie immer eine Typprüfung, bevor Sie auf Text‑, Bild‑, Diagramm‑, Tabellen‑ oder medienspezifische Mitglieder zugreifen.
{{% /alert %}}

## **Verstehen von Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folie definiert wiederverwendbare Stile und in manchen Fällen Master‑Platzhalter.
2. Eine Layout‑Folie definiert die Anordnung, die von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) auf, um eine Ebene in dieser Hierarchie nach oben zu gehen. Ein Folien‑Platzhalter liefert normalerweise seinen Layout‑Platzhalter; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode gibt `None` zurück, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter auf der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Das Bearbeiten eines Platzhalters auf einer normalen Folie erzeugt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale, gewöhnliche Form hat keinen Basis‑Platzhalter und beginnt nicht mit dem Erben, nur weil sie dieselben Koordinaten einnimmt.

## **Platzhalterstatus entfernen**

Beim Anpassen einer Vorlage verwenden Sie [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder), um ein vorhandenes Objekt als gewöhnliche Form zu behalten. Seine [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder)-Methode gibt `None` zurück, aber die Form bleibt in der Folien‑Sammlung. Im Gegensatz dazu löscht [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) die Form aus dieser Sammlung.

Das folgende Beispiel erfordert `template.pptx` mit mindestens einer Folie und einem nicht leeren Text‑Platzhalter auf der ersten Folie. Verwenden Sie einen Platzhalter mit vom Layout oder Master geerbter Formatierung, um die Auswirkung des Entfernens dieser Beziehung zu sehen. Das Beispiel prüft, dass dieselbe Form erhalten bleibt, ruft die Methode erneut auf der nun gewöhnlichen Form auf und speichert das Ergebnis.

{{% alert color="warning" title="Warning" %}}
Das Entfernen des Platzhalterstatus bewahrt die geerbten Anzeigeeinstellungen nicht automatisch. Das untenstehende Beispiel lässt diese Einstellungen bewusst unverändert, sodass die Ausgabe unterschiedlich aussehen kann. Eine Form, deren Position und Größe vollständig geerbt sind, kann nach dem Aufruf null Koordinaten und Abmessungen haben und unsichtbar werden, obwohl sie in der Sammlung verbleibt.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Der Aufruf der Methode auf einer gewöhnlichen Form hat keine Wirkung.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Für einen passenden Platzhalter geben alle drei Prüfungen `True` zurück. Der Text bleibt erhalten, aber vererbte Position, Größe, Drehung, Schriftart, Absatzausrichtung, Textfeld‑Abstände, vertikale Verankerung, Füll‑ und Linieneinstellungen können sich ändern, wenn die Platzhalter‑Beziehung entfernt wird. Beispielsweise kann die vererbte Titel‑Formatierung zur normalen Text‑Formatierung zurückfallen. Siehe [Folienlayout](/slides/de/python-java/slide-layout/) für weitere Informationen zu Layouts.

Um das gewünschte Aussehen beizubehalten, erfassen Sie vor dem Aufruf die aufgelöste Position, Größe und Drehung und kopieren die erforderlichen effektiven Formatierungswerte in separate Variablen. Rufen Sie diese Werte über [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) und [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) ab. Verlassen Sie sich nicht ausschließlich auf die effektiven Format-Objekte, da deren Textformatierungswerte nach dem Entfernen der Beziehung geändert werden können. Wenden Sie die erfassten Werte anschließend explizit auf die gewöhnliche Form an, einschließlich Schriftfamilie, Größe, Stil, Farbe, Absatz‑Einstellungen, Text‑Frame‑Einstellungen, Füllung und Linie, die in Ihrer Vorlage verwendet werden.

Vererbte Formgeometrie muss möglicherweise ebenfalls explizit über [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType) zugewiesen werden. Für einen rechteckigen Text‑Platzhalter bedeutet dies die Zuweisung von [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); das Wiederherstellen von nur Füllung und Linie stellt das sichtbare Rechteck möglicherweise nicht wieder her. Vorlagen mit zusätzlichen Effekten oder komplexerer Formatierung erfordern ebenfalls die Behandlung dieser Einstellungen.

## **Text in einem Platzhalter ändern**

Titel‑, zentrierte Titel‑, Untertitel‑, Text‑ und Inhalts‑Platzhalter unterstützen normalerweise Text. Prüfen Sie auf [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), bevor Sie dessen [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame)-Methode verwenden.

Dieses Beispiel aktualisiert den ersten Titel‑Platzhalter auf der ersten Folie und speichert das Ergebnis:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dieses Muster verhindert, dass Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhalter als [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) behandelt werden. Es identifiziert den Platzhalter außerdem nach Zweck, anstatt sich auf einen anfälligen Form‑Index zu verlassen.

## **Aufforderungstext in einem Layout festlegen**

Aufforderungstext ist die Design‑Zeit‑Anweisung, die in einem leeren Platzhalter angezeigt wird, z. B. *Click to add title*. Setzen Sie benutzerdefinierten Aufforderungstext auf dem Layout‑Platzhalter, anstatt zu versuchen, über die Form‑Sammlung einer normalen Folie darauf zuzugreifen. Greifen Sie über [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) auf das Layout zu und iterieren Sie über die von [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) zurückgegebene Sammlung.

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Aufforderungen im Layout, das von der ersten Folie verwendet wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aufforderungstext ist kein normaler Folieninhalt. Er ist für leere Platzhalter in Bearbeitungs‑Anwendungen wie PowerPoint vorgesehen. Sobald ein Benutzer oder ein Programm echten Inhalt bereitstellt, wird die Aufforderung nicht mehr angezeigt. Das Ändern einer Aufforderung ersetzt ebenfalls nicht den bestehenden Text auf Folien, die das Layout verwenden.

## **Bild‑Platzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bild‑Platzhalter bereits gefüllt ist und durch einen [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) repräsentiert wird, ersetzen Sie das Bild über [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) und [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie einen Bildrahmen an den Koordinaten des Platzhalters mit [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) hinzu und entfernen den leeren Platzhalter.

Das folgende Beispiel unterstützt beide Fälle und speichert die Präsentation:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der für einen leeren Platzhalter erstellte Ersatz ist ein lokaler Bildrahmen, kein neuer Platzhalter, da [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) keinen Setter bereitstellt. Er behält die reservierte Position bei, erbt jedoch nicht mehr das platzhalterspezifische Verhalten. Wenn das Beibehalten der Platzhalter‑Beziehung entscheidend ist, bereiten Sie den Platzhalter zuerst in PowerPoint vor und füllen ihn, dann aktualisieren Sie das resultierende [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) mit Aspose.Slides.

Für Bildtransparenz, Zuschneiden und andere bildspezifische Effekte siehe [Bildrahmen verwalten](/slides/de/python-java/picture-frame/). Diese Vorgänge betreffen den Bildrahmen oder das Bild‑Füllformat, nicht die Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhalts‑Platzhaltern**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) repräsentiert werden. Dieses Beispiel findet ein solches Diagramm sowohl nach Platzhaltertyp als auch nach Laufzeit‑Typ, ändert dessen Titel und speichert die Datei:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ein allgemeiner Inhalts‑Platzhalter hat in der Regel [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). In PowerPoint dient er als Launcher für mehrere Inhaltstypen, einschließlich Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er gefüllt wurde, untersuchen Sie den tatsächlichen Formtyp, um zu erfahren, was er enthält. Spezialisierte Layouts können auch [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) oder [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram) aus.

Aspose.Slides konvertiert einen leeren [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)‑Platzhalter nicht in ein [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/), nur indem [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) geändert wird; der Typ kann über die API nicht geändert werden. Um ein leeres Diagramm‑ oder Inhaltsfeld programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters hinzu und entfernen dann den leeren Platzhalter. Das folgende Beispiel macht dies für ein Diagramm:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die speziellen [Diagramm‑Verwaltungsartikel](/slides/de/python-java/powerpoint-charts/), wenn Sie dessen Kategorien, Reihen oder Arbeitsbuch‑Daten ersetzen müssen.

## **Vollständiges Beispiel: Text- oder Bildinhalt aktualisieren**

Das folgende End‑to‑End‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Formtypen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel verzichtet bewusst darauf, einen Form‑Index anzunehmen oder jeden Platzhalter als denselben Typ zu behandeln.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Was ist ein Basis‑Platzhalter?**

Ein Basis‑Platzhalter ist die entsprechende Form im Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder), um ihn abzurufen. Eine gewöhnliche lokale Form gibt `None` zurück, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können die geerbte Formatierung oder den Aufforderungstext über ein Layout ändern, aber der vorhandene Titelinhalt ist in den normalen Folien gespeichert. Um den tatsächlichen Titeltext in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fuß‑Platzhalter?**

Verwenden Sie die Kopf‑ und Fußzeilen‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notiz‑ oder Handout‑Bereich. Siehe [Präsentationskopf‑ und Fußzeilen verwalten](/slides/de/python-java/presentation-header-and-footer/) für vollständige Beispiele.