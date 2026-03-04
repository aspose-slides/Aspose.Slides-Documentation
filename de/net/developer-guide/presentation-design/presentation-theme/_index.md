---
title: Präsentationsdesigns in .NET verwalten
linktitle: Präsentationsdesign
type: docs
weight: 10
url: /de/net/presentation-theme/
keywords:
- PowerPoint-Design
- Präsentationsdesign
- Folien-Design
- Design festlegen
- Design ändern
- Design verwalten
- Designfarbe
- Zusätzliche Palette
- Designschriftart
- Designstil
- Designeffekt
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Master-Präsentationsdesigns in Aspose.Slides für .NET erstellen, anpassen und PowerPoint-Dateien mit konsistenter Markenbildung konvertieren."
---
Ein Präsentationsdesign definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsdesign auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Design aus Farben, [Schriften](/slides/de/net/powerpoint-fonts/), [Hintergrundstilen](/slides/de/net/presentation-background/) und Effekten.

![theme-constituents](theme-constituents.png)

## **Designfarbe ändern**

Ein PowerPoint-Design verwendet einen bestimmten Satz von Farben für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Design anwenden. Damit Sie eine neue Designfarbe auswählen können, stellt Aspose.Slides Werte der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) bereit.

Der folgende C#‑Code zeigt, wie Sie die Akzentfarbe für ein Design ändern:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

So können Sie den effektiven Wert der resultierenden Farbe bestimmen:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Farbe [A=255, R=128, G=100, B=162])
```

Um die Farbänderungs‑Operation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Anschließend ändern wir die Farbe im Design:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Die neue Farbe wird automatisch auf beiden Elementen angewendet.

### **Designfarbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanz‑Transformationen auf die Haupt‑Designfarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Sie können diese Designfarben dann festlegen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** – Haupt‑Designfarben

**2** – Farben aus der zusätzlichen Palette.

Der folgende C#‑Code demonstriert eine Operation, bei der zusätzliche Palettenfarben aus der Haupt‑Designfarbe abgeleitet und anschließend in Formen verwendet werden:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Akzent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Akzent 4, Aufgehellt 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akzent 4, Aufgehellt 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akzent 4, Aufgehellt 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akzent 4, Dunkler 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akzent 4, Dunkler 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **`SchemeColor` zu `IColorScheme`‑Farben zuordnen**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) arbeiten, werden Sie feststellen, dass es die folgenden Designfarbwerte enthält:

`Background1`, `Background2`, `Text1` und `Text2`.

Allerdings liefert `Presentation.MasterTheme.ColorScheme` [IColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/icolorscheme/), das die entsprechenden Farben wie folgt bereitstellt:

`Dark1`, `Dark2`, `Light1` und `Light2`.

Es gibt keine dynamische Konvertierung zwischen `Text`/`Background` und `Dark`/`Light`. Sie sind lediglich alternative Bezeichnungen für dieselben Designfarben.

Diese Namensdifferenz stammt aus der Terminologie von Microsoft Office. Ältere Office‑Versionen verwendeten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere UI‑Versionen dieselben Slots als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Designschriftart ändern**

Um Ihnen die Auswahl von Schriften für Designs und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen in PowerPoint):

* **+mn-lt** – Körperschrift Latin (Minor Latin Font)
* **+mj-lt** – Überschriftsschrift Latin (Major Latin Font)
* **+mn-ea** – Körperschrift Ostasiatisch (Minor East Asian Font)
* **+mj-ea** – Überschriftsschrift Ostasiatisch (Minor East Asian Font)

Der folgende C#‑Code zeigt, wie Sie die Latin‑Schrift einem Designelement zuweisen:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Der folgende C#‑Code zeigt, wie Sie die Schrift des Präsentationsdesigns ändern:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Die Schrift in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} Vielleicht möchten Sie sich [PowerPoint-Schriften](/slides/de/net/powerpoint-fonts/) ansehen. {{% /alert %}}

## **Design‑Hintergrundstil ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, von denen jedoch nur 3 in einer typischen Präsentation gespeichert werden.

![todo:image_alt_text](presentation-design_8.png)

Beispiel: Nachdem Sie eine Präsentation in der PowerPoint‑App gespeichert haben, können Sie diesen C#‑Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) der Klasse [FormatScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/) können Sie den Hintergrundstil in einem PowerPoint‑Design hinzufügen oder darauf zugreifen. {{% /alert %}}

Der folgende C#‑Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Index‑Hinweis**: 0 steht für keine Füllung. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} Vielleicht möchten Sie sich [PowerPoint‑Hintergrund](/slides/de/net/presentation-background/) ansehen. {{% /alert %}}

## **Design‑Effekt ändern**

Ein PowerPoint‑Design enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Beispielhaft ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/effectstyles)) der Klasse [FormatScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme) können Sie die Elemente in einem Design ändern (noch flexibler als die Optionen in PowerPoint).

Der folgende C#‑Code zeigt, wie Sie einen Design‑Effekt ändern, indem Sie Teile der Elemente anpassen:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

Die daraus resultierenden Änderungen bei Füllfarbe, Fülltyp, Schatteneffekt usw.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kann ich ein Design auf eine einzelne Folie anwenden, ohne den Master zu ändern?**

Ja. Aspose.Slides unterstützt Themen‑Überschreibungen auf Folienebene, sodass Sie ein lokales Design nur auf dieser Folie anwenden können, während das Master‑Design unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/net/aspose.slides.theme/slidethememanager/)).

**Was ist der sicherste Weg, ein Design von einer Präsentation zur anderen zu übertragen?**

[Folien klonen](/slides/de/net/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Das bewahrt den ursprünglichen Master, Layouts und das zugehörige Design, sodass das Aussehen konsistent bleibt.

**Wie kann ich die »effektiven« Werte nach allen Vererbungen und Überschreibungen sehen?**

Verwenden Sie die „effektiven“ Ansichten der API (/slides/de/net/shape-effective-properties/) für Theme/Farbe/Schrift/Effekt. Diese geben die aufgelösten, finalen Eigenschaften nach Anwendung des Masters und eventueller lokaler Überschreibungen zurück.