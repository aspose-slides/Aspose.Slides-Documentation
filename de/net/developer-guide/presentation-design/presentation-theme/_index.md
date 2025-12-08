---
title: Präsentationsthema
type: docs
weight: 10
url: /de/net/presentation-theme/
keywords: "Thema, PowerPoint-Thema, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint-Präsentationsthema in C# oder .NET"
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriften](/slides/de/net/powerpoint-fonts/), [Hintergrundstilen](/slides/de/net/presentation-background/) und Effekten.

![Themenbestandteile](theme-constituents.png)

## **Themafarbe ändern**

Ein PowerPoint‑Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Damit Sie eine neue Themenfarbe auswählen können, stellt Aspose.Slides Werte aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) bereit.

Dieser C#‑Code zeigt, wie Sie die Akzentfarbe für ein Thema ändern:
```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```


Sie können den tatsächlichen Wert der resultierenden Farbe auf diese Weise bestimmen:
```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Color [A=255, R=128, G=100, B=162])
```


Um die Farbänderungsoperation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Anschließend ändern wir die Farbe im Thema:
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themafarbe aus zusätzlicher Palette festlegen**

Wenn Sie Luminanz‑Transformationen auf die Hauptthemenfarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Diese Themenfarben können Sie anschließend setzen und abrufen.

![Farben der zusätzlichen Palette](additional-palette-colors.png)

**1** – Hauptthemenfarben  
**2** – Farben aus der zusätzlichen Palette.

Dieser C#‑Code demonstriert einen Vorgang, bei dem Farben aus der zusätzlichen Palette aus der Hauptthemenfarbe gewonnen und anschließend in Formen verwendet werden:
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


## **Themen‑Schriftart ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen, die in PowerPoint verwendet werden):

* **+mn-lt** – Fließtextschrift Latin (Minor Latin Font)
* **+mj-lt** – Überschriftschrift Latin (Major Latin Font)
* **+mn-ea** – Fließtextschrift Ostasiatisch (Minor East Asian Font)
* **+mj-ea** – Fließtextschrift Ostasiatisch (Minor East Asian Font)

Dieser C#‑Code zeigt, wie Sie die Latin‑Schrift einem Themen‑Element zuweisen:
```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


Dieser C#‑Code zeigt, wie Sie die Präsentationsthema‑Schriftart ändern:
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIPP" %}} 
Vielleicht möchten Sie sich die [PowerPoint‑Schriften](/slides/de/net/powerpoint-fonts/) ansehen.
{{% /alert %}}

## **Hintergrundstil des Themas ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, aber nur 3 dieser 12 Hintergründe werden in einer typischen Präsentation gespeichert.

![todo:image_alt_text](presentation-design_8.png)

Zum Beispiel können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App diesen C#‑Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) der Klasse [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) können Sie den Hintergrundstil in einem PowerPoint‑Thema hinzufügen oder darauf zugreifen.
{{% /alert %}}

Dieser C#‑Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:
```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**Index‑Leitfaden**: 0 steht für keine Füllung. Der Index beginnt bei 1.

{{% alert color="primary" title="TIPP" %}} 
Vielleicht möchten Sie sich den [PowerPoint‑Hintergrund](/slides/de/net/presentation-background/) ansehen.
{{% /alert %}}

## **Themaeffekt ändern**

Ein PowerPoint‑Thema enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Mit den 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) der Klasse [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) können Sie die Elemente in einem Thema ändern (noch flexibler als die Optionen in PowerPoint).

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

**Kann ich ein Thema auf eine einzelne Folie anwenden, ohne die Master‑Folien zu ändern?**  
Ja. Aspose.Slides unterstützt themenbezogene Überschreibungen auf Folien‑Ebene, sodass Sie ein lokales Thema nur auf dieser Folie anwenden können, während das Master‑Thema unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)).

**Was ist der sicherste Weg, ein Thema von einer Präsentation in eine andere zu übernehmen?**  
[Folien klonen](/slides/de/net/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben der ursprüngliche Master, die Layouts und das zugehörige Thema erhalten, sodass das Erscheinungsbild konsistent bleibt.

**Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?**  
Verwenden Sie die ["effektiven" Ansichten](/slides/de/net/shape-effective-properties/) der API für Thema/Farbe/Schrift/Effekt. Diese geben die aufgelösten, finalen Eigenschaften zurück, nachdem der Master sowie eventuelle lokale Überschreibungen angewendet wurden.