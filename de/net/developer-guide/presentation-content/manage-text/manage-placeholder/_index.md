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
- Aufforderungstext
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text-, Bild-, Diagramm- und Inhaltsplatzhalter untersuchen und bearbeiten sowie die Platzhaltervererbung mit Aspose.Slides für .NET verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die in einer Präsentationsvorlage eine Position für eine bestimmte Art von Inhalt reserviert. Häufige Beispiele sind Titel-, Text-, Bild-, Diagramm- und allgemein‑zweckmäßige Inhaltsplatzhalter. Im Gegensatz zu einer gewöhnlichen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folien‑ oder Master‑Folie erben.

Aspose.Slides stellt Platzhalterinformationen über die Eigenschaft [IShape.Placeholder](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/placeholder/) zur Verfügung. Die Eigenschaft gibt ein [IPlaceholder](https://reference.aspose.com/slides/de/net/aspose.slides/iplaceholder/)‑Objekt zurück oder `null` für eine normale Form. Verwenden Sie [IPlaceholder.Type](https://reference.aspose.com/slides/de/net/aspose.slides/iplaceholder/type/), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Die Form‑Schnittstelle bleibt auch nach Kenntnis des Platzhaltertyps relevant:

- Ein leerer Text‑, Bild‑, Diagramm‑ oder Inhalts‑Platzhalter wird üblicherweise durch ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) dargestellt.
- Ein gefüllter Bild‑Platzhalter kann durch ein [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) dargestellt werden.
- Ein gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/) dargestellt werden.
- Ein Inhalts‑Platzhalter kann mehrere Arten von Inhalt enthalten. Prüfen Sie sowohl [IPlaceholder.Type](https://reference.aspose.com/slides/de/net/aspose.slides/iplaceholder/type/) als auch die Laufzeit‑Form‑Schnittstelle, anstatt anzunehmen, dass jeder Platzhalter ein [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/de/net/aspose.slides/iplaceholder/type/) beschreibt die Rolle eines Platzhalters; sie garantiert nicht den Laufzeit‑Typ der Form. Verwenden Sie immer eine Typprüfung, bevor Sie auf Text‑, Bild‑, Diagramm‑, Tabellen‑ oder medien‑spezifische Mitglieder zugreifen.
{{% /alert %}}

## **Verstehen von Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Master‑Folie definiert wiederverwendbare Stile und, in manchen Fällen, Master‑Platzhalter.
2. Eine Layout‑Folie definiert die Anordnung, die von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/getbaseplaceholder/) auf, um eine Ebene in dieser Hierarchie nach oben zu gehen. Ein Folien‑Platzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode liefert `null`, wenn die Form keinen Basis‑Platzhalter besitzt.

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

Das Bearbeiten eines Platzhalters auf einer normalen Folie erzeugt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale gewöhnliche Form hat keinen Basis‑Platzhalter und beginnt nicht mit der Vererbung nur weil sie dieselben Koordinaten belegt.

## **Text in einem Platzhalter ändern**

Titel-, zentrierte‑Titel‑, Untertitel‑, Text‑ und Text‑Platzhalter unterstützen normalerweise Text. Prüfen Sie auf [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/), bevor Sie dessen [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/textframe/)‑Eigenschaft verwenden.

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

Dieses Muster vermeidet das Casten von Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhaltern zu [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/). Es identifiziert den Platzhalter außerdem nach Zweck statt sich auf einen fragilen Form‑Index zu verlassen.

## **Prompt‑Text im Layout festlegen**

Prompt‑Text ist die zur Entwurfszeit angezeigte Anweisung in einem leeren Platzhalter, z. B. *Klicken Sie, um einen Titel hinzuzufügen*. Legen Sie benutzerdefinierten Prompt‑Text auf dem Layout‑Platzhalter fest, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [ISlide.LayoutSlide](https://reference.aspose.com/slides/de/net/aspose.slides/islide/layoutslide/) auf das Layout zu und iterieren Sie über [ILayoutSlide.Shapes](https://reference.aspose.com/slides/de/net/aspose.slides/ibaseslide/shapes/).

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Prompts im Layout, das von der ersten Folie verwendet wird:

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

Prompt‑Text ist kein gewöhnlicher Folieninhalt. Er ist für leere Platzhalter in Bearbeitungs‑Anwendungen wie PowerPoint vorgesehen. Sobald ein Benutzer oder ein Programm echten Inhalt bereitstellt, wird der Prompt nicht mehr angezeigt. Das Ändern eines Prompts ersetzt außerdem keinen bereits vorhandenen Text auf Folien, die das Layout verwenden.

## **Ein Bild‑Platzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bild‑Platzhalter bereits gefüllt ist und durch ein [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) dargestellt wird, ersetzen Sie das Bild über [IPictureFillFormat.Picture](https://reference.aspose.com/slides/de/net/aspose.slides/ipicturefillformat/picture/) und [ISlidesPicture.Image](https://reference.aspose.com/slides/de/net/aspose.slides/islidespicture/image/).
- Wenn er noch ein leerer Platzhalter ist, fügen Sie an den Koordinaten des Platzhalters einen Bildrahmen mit [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addpictureframe/) hinzu und entfernen Sie den leeren Platzhalter.

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

Der für einen leeren Platzhalter erstellte Ersatz ist ein lokaler Bildrahmen, kein neuer Platzhalter, weil [IShape.Placeholder](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/placeholder/) schreibgeschützt ist. Er behält die reservierte Position bei, erbt jedoch nicht mehr das platzhalterspezifische Verhalten. Wenn das Beibehalten der Platzhalter‑Beziehung wesentlich ist, erstellen und füllen Sie den Platzhalter zuerst in PowerPoint und aktualisieren anschließend das resultierende [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) mit Aspose.Slides.

Informationen zu Bildtransparenz, Zuschneiden und anderen bild‑spezifischen Effekten finden Sie unter [Manage Picture Frames](/slides/de/net/picture-frame/). Diese Vorgänge betreffen den Bildrahmen oder das Bildfüllformat, nicht die Platzhalter‑Metadaten.

## **Arbeiten mit Diagramm‑ und Inhalts‑Platzhaltern**

Ein gefüllter Diagramm‑Platzhalter kann durch ein [IChart](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl nach Platzhaltertyp als auch nach Laufzeit‑Schnittstelle, ändert dessen Titel und speichert die Datei:

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

Ein allgemeiner Inhalts‑Platzhalter hat normalerweise [PlaceholderType.Object](https://reference.aspose.com/slides/de/net/aspose.slides/placeholdertype/). In PowerPoint fungiert er als Startpunkt für verschiedene Inhaltstypen, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er gefüllt wurde, prüfen Sie die tatsächliche Form‑Schnittstelle, um zu erfahren, was er enthält. Spezialisierte Layouts können zudem [PlaceholderType.Chart](https://reference.aspose.com/slides/de/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/de/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/de/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/de/net/aspose.slides/placeholdertype/) oder [PlaceholderType.Diagram](https://reference.aspose.com/slides/de/net/aspose.slides/placeholdertype/) bereitstellen.

Aspose.Slides wandelt einen leeren [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/)‑Platzhalter nicht einfach durch Ändern von [IPlaceholder.Type](https://reference.aspose.com/slides/de/net/aspose.slides/iplaceholder/type/) in ein [IChart](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/) um; der Typ ist schreibgeschützt. Um ein leeres Diagramm‑ oder Inhalts‑Bereich programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters hinzu und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel erledigt dies für ein Diagramm:

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

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die dedizierten [chart management articles](/slides/de/net/powerpoint-charts/), wenn Sie dessen Kategorien, Serien oder Arbeitsmappendaten ersetzen müssen.

## **Komplettes Beispiel: Text‑ oder Bildinhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Formtypen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst die Annahme eines Form‑Index oder das Casten jedes Platzhalters in dieselbe Schnittstelle.

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

Ein Basis‑Platzhalter ist die entsprechende Form im Layout oder Master, von der ein anderer Platzhalter erbt. Verwenden Sie [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/getbaseplaceholder/), um ihn abzurufen. Eine gewöhnliche lokale Form gibt `null` zurück, weil sie nicht Teil der Platzhalter‑Hierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout die vererbte Formatierung oder den Prompt‑Text ändern, aber der vorhandene Titelinhalt ist in den normalen Folien gespeichert. Um den tatsächlichen Titeltext in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren jeden Titel‑Platzhalter.

**Wie verwalte ich Platzhalter für Datum, Folien‑Nummer, Kopf‑ und Fußzeile?**

Verwenden Sie die Header‑ und Footer‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notiz‑ oder Handout‑Bereich. Siehe [Manage Presentation Header and Footer](/slides/de/net/presentation-header-and-footer/) für vollständige Beispiele.