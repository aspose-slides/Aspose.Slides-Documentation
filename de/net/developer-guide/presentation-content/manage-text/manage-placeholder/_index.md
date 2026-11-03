---
title: Verwalten von Präsentationsplatzhaltern in .NET
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/net/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Inhaltsplatzhalter
- Hinweistext
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text-, Bild-, Diagramm- und Inhaltsplatzhalter inspizieren und bearbeiten und die Platzhaltervererbung mit Aspose.Slides für .NET verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die in einer Präsentationsvorlage eine Position für eine bestimmte Art von Inhalt reserviert. Häufige Beispiele sind Titel-, Text‑, Bild‑, Diagramm‑ und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folien‑ oder Master‑Folienvorlage erben.

Aspose.Slides stellt Platzhalterinformationen über die Eigenschaft [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) bereit. Die Eigenschaft liefert ein [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/)‑Objekt oder `null` für eine normale Form. Verwenden Sie [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Die Form‑Schnittstelle bleibt wichtig, nachdem Sie den Platzhaltertyp kennen:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhaltsplatzhalter wird häufig durch ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) dargestellt.
- Ein gefüllter Bild‑Platzhalter kann durch ein [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) dargestellt werden.
- Ein gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann mehrere Arten von Inhalten enthalten. Überprüfen Sie sowohl [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) als auch die Laufzeit‑Form‑Schnittstelle, anstatt anzunehmen, dass jeder Platzhalter ein [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) beschreibt die Rolle eines Platzhalters; sie garantiert nicht den Laufzeit‑Typ der Form. Verwenden Sie immer eine Typprüfung, bevor Sie auf Text‑, Bild‑, Diagramm‑, Tabellen‑ oder medienspezifische Member zugreifen.
{{% /alert %}}

## **Platzhalter‑Vererbung verstehen**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folienvorlage definiert wiederverwendbare Stile und in einigen Fällen Master‑Platzhalter.
2. Eine Layout‑Folienvorlage definiert das Layout, das von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) auf, um eine Ebene höher in dieser Hierarchie zu wechseln. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode liefert `null`, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Das Bearbeiten eines Platzhalters auf einer normalen Folie erstellt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale reguläre Form hat keinen Basis‑Platzhalter und beginnt nicht mit der Vererbung, nur weil sie dieselben Koordinaten einnimmt.

## **Platzhalter‑Status entfernen**

Beim Anpassen einer Vorlage verwenden Sie [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/), um ein vorhandenes Objekt als reguläre Form zu behalten. Seine [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/)‑Eigenschaft wird zu `null`, aber die Form bleibt in der Folien‑Sammlung. Im Gegensatz dazu löscht [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) die Form aus dieser Sammlung.

Das folgende Beispiel erfordert `template.pptx` mit mindestens einer Folie und einem nicht leeren Text‑Platzhalter auf der ersten Folie. Verwenden Sie einen Platzhalter mit vom Layout oder Master geerbter Formatierung, um die Auswirkung des Entfernens dieser Beziehung zu sehen. Das Beispiel prüft, dass dieselbe Form erhalten bleibt, ruft die Methode erneut auf der nun regulären Form auf und speichert das Ergebnis.

{{% alert color="warning" title="Warning" %}}
Das Entfernen des Platzhalter‑Status bewahrt nicht automatisch die geerbten Darstellungseinstellungen. Das untenstehende Beispiel lässt diese Einstellungen bewusst unverändert, sodass die Ausgabe anders aussehen kann. Eine Form, deren Position und Größe vollständig geerbt sind, kann nach dem Aufruf Null‑Koordinaten und -Abmessungen haben und unsichtbar werden, obwohl sie in der Sammlung verbleibt.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Aufrufen der Methode auf einer normalen Form hat keine Wirkung.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Für einen passenden Platzhalter geben alle drei Prüfungen `True` aus. Der Text bleibt erhalten, aber vererbte Position, Größe, Drehung, Schriftart, Absatzausrichtung, Textfeld‑Abstände, vertikale Verankerung, Füll‑ und Linien‑Einstellungen können sich ändern, wenn die Platzhalter‑Beziehung entfernt wird. Beispielsweise kann die vererbte Titel‑Formatierung auf die reguläre Textformatierung zurückfallen. Siehe [Folienlayout](/slides/de/net/slide-layout/) für weitere Informationen zu Layouts.

Um das beabsichtigte Aussehen zu erhalten, erfassen Sie vor dem Aufruf die ermittelte Position, Größe und Drehung und kopieren die erforderlichen effektiven Formatierungswerte in separate Variablen. Rufen Sie diese Werte über [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), und [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) ab. Verlassen Sie sich nicht ausschließlich auf die effektiven Formatobjekte, da sich deren Text‑Formatierungswerte nach dem Entfernen der Beziehung ändern können. Wenden Sie die erfassten Werte anschließend explizit auf die reguläre Form an, einschließlich Schriftfamilie, Größe, Stil, Farbe, Absatz‑Einstellungen, Textfeld‑Einstellungen, Füll‑ und Linieneigenschaften Ihrer Vorlage.

Geerbte Formgeometrie muss möglicherweise ebenfalls explizit über [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/) zugewiesen werden. Für einen rechteckigen Text‑Platzhalter bedeutet das die Zuordnung von [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); das Wiederherstellen nur von Füll‑ und Linienwerten stellt das sichtbare Rechteck möglicherweise nicht wieder her. Vorlagen mit zusätzlichen Effekten oder komplexerer Formatierung erfordern ebenfalls die entsprechende Behandlung dieser Einstellungen.

## **Text in einem Platzhalter ändern**

Titel-, zentrierte Titel‑, Untertitel‑, Text‑ und Inhalts‑Platzhalter unterstützen normalerweise Text. Prüfen Sie auf [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/), bevor Sie dessen [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/)‑Eigenschaft verwenden.

Dieses Beispiel aktualisiert den ersten Titel‑Platzhalter auf der ersten Folie und speichert das Ergebnis:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Dieses Muster vermeidet das Casten von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern zu [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Es identifiziert den Platzhalter außerdem nach seiner Zweckbestimmung, anstatt sich auf einen anfälligen Form‑Index zu verlassen.

## **Hinweistext in einem Layout festlegen**

Hinweistext ist die Anweisung zur Entwurfszeit, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken, um Titel hinzuzufügen*. Legen Sie den benutzerdefinierten Hinweistext im Layout‑Platzhalter fest, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) auf das Layout zu und iterieren Sie über [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Hinweistexte im Layout, das von der ersten Folie verwendet wird:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Hinweistext ist kein normaler Folieninhalt. Er ist für leere Platzhalter in Bearbeitungsprogrammen wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt bereitstellt, wird der Hinweis nicht mehr angezeigt. Das Ändern eines Hinweises ersetzt außerdem nicht den vorhandenen Text auf Folien, die das Layout verwenden.

## **Bild‑Platzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bild‑Platzhalter bereits gefüllt ist und durch ein [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) dargestellt wird, ersetzen Sie das Bild über [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) und [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Falls er noch ein leerer Platzhalter ist, fügen Sie mit [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) ein Bildrahmen an den Koordinaten des Platzhalters hinzu und entfernen Sie den leeren Platzhalter.

Das folgende Beispiel unterstützt beide Fälle und speichert die Präsentation:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Der Ersatz, der für einen leeren Platzhalter erzeugt wird, ist ein lokaler Bildrahmen, kein neuer Platzhalter, da [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) schreibgeschützt ist. Er behält die reservierte Position bei, erbt jedoch nicht mehr das platzhalterspezifische Verhalten. Wenn das Beibehalten der Platzhalter‑Beziehung essenziell ist, erstellen und füllen Sie den Platzhalter zuerst in PowerPoint und aktualisieren anschließend das resultierende [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) mit Aspose.Slides.

Für Bildtransparenz, Beschnitt und andere bildspezifische Effekte siehe [Bildrahmen verwalten](/slides/de/net/picture-frame/). Diese Vorgänge betreffen den Bildrahmen oder die Bildfüllung, nicht die Platzhalter‑Metadaten.

## **Mit Diagramm‑ und Inhalts‑Platzhaltern arbeiten**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl nach Platzhaltertyp als auch nach Laufzeit‑Schnittstelle, ändert dessen Titel und speichert die Datei:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Ein allgemeiner Inhalts‑Platzhalter hat üblicherweise [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). In PowerPoint fungiert er als Startpunkt für verschiedene Inhaltstypen, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er gefüllt wurde, prüfen Sie die tatsächliche Form‑Schnittstelle, um zu erfahren, was er enthält. Spezialisierte Layouts können auch [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) oder [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/) bereitstellen.

Aspose.Slides wandelt einen leeren [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)‑Platzhalter nicht einfach durch Ändern von [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) in ein [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) um; der Typ ist schreibgeschützt. Um ein leeres Diagramm‑ oder Inhaltsfeld programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters hinzu und entfernen dann den leeren Platzhalter. Das folgende Beispiel macht das für ein Diagramm:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die speziellen [Diagramm‑Verwaltungsartikel](/slides/de/net/powerpoint-charts/), wenn Sie dessen Kategorien, Datenreihen oder Arbeitsblattdaten ersetzen müssen.

## **Vollständiges Beispiel: Text‑ oder Bildinhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Form‑Typen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst die Annahme eines Form‑Indexes oder das Casten jedes Platzhalters zur selben Schnittstelle.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Was ist ein Basis‑Platzhalter?**

Ein Basis‑Platzhalter ist die entsprechende Form im Layout oder Master, von dem ein anderer Platzhalter erbt. Verwenden Sie [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/), um ihn abzurufen. Eine gewöhnliche lokale Form liefert `null`, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können die geerbte Formatierung oder den Hinweistext über ein Layout ändern, aber der vorhandene Titelinhalt wird in den normalen Folien gespeichert. Um den tatsächlichen Titeltext in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fußzeilen‑Platzhalter?**

Verwenden Sie die Kopf‑ und Fußzeilen‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notizen‑ oder Handzettel‑Umfang. Siehe [Präsentationskopf‑ und Fußzeile verwalten](/slides/de/net/presentation-header-and-footer/) für vollständige Beispiele.