---
title: Präsentationsthema
type: docs
weight: 10
url: /net/presentation-theme/
keywords: "Thema, PowerPoint-Thema, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint-Präsentationsthema in C# oder .NET"
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften aus.

In PowerPoint umfasst ein Thema Farben, [Schriften](/slides/net/powerpoint-fonts/), [Hintergrundstile](/slides/net/presentation-background/) und Effekte.

![theme-constituents](theme-constituents.png)

## **Themenfarbe ändern**

Ein PowerPoint-Thema verwendet einen spezifischen Satz von Farben für verschiedene Elemente auf einer Folie. Wenn Ihnen die Farben nicht gefallen, können Sie die Farben ändern, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Themenfarbe zu ermöglichen, bietet Aspose.Slides Werte unter der [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) Enumeration.

Dieser C#-Code zeigt Ihnen, wie Sie die Akzentfarbe für ein Thema ändern:

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

Um die Farbänderungsoperation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ursprünglichen Operation) zu. Dann ändern wir die Farbe im Thema:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themenfarbe aus zusätzlicher Palette festlegen**

Wenn Sie Luminanztransformationen auf die Hauptthemenfarbe(1) anwenden, werden Farben aus der zusätzlichen Palette(2) gebildet. Sie können diese Themenfarben dann festlegen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hauptthemenfarben

**2** - Farben aus der zusätzlichen Palette.

Dieser C#-Code demonstriert eine Operation, bei der zusätzliche Palettenfarben aus der Hauptthemenfarbe abgerufen und dann in Formen verwendet werden:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Akzent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Akzent 4, Heller 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akzent 4, Heller 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akzent 4, Heller 40%
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

## **Themen Schriftart ändern**

Um Ihnen die Auswahl von Schriftarten für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Identifikatoren (ähnlich denen, die in PowerPoint verwendet werden):

* **+mn-lt** - Schriftart Haupttext Latein (Minor Latin Font)
* **+mj-lt** - Überschrift Schriftart Latein (Major Latin Font)
* **+mn-ea** - Schriftart Haupttext Ostasiatisch (Minor East Asian Font)
* **+mj-ea** - Schriftart Überschrift Ostasiatisch (Major East Asian Font)

Dieser C#-Code zeigt Ihnen, wie Sie die lateinische Schriftart einem Themenelement zuweisen:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Formatierung des Thema-Texts");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Dieser C#-Code zeigt Ihnen, wie Sie die Schriftart des Präsentationsthemas ändern:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten möglicherweise [PowerPoint-Schriften](/slides/net/powerpoint-fonts/) ansehen.

{{% /alert %}}

## **Hintergrundstil des Themas ändern**

Standardmäßig bietet die PowerPoint-App 12 vordefinierte Hintergründe, aber nur 3 dieser 12 Hintergründe werden in einer typischen Präsentation gespeichert.

![todo:image_alt_text](presentation-design_8.png)

Wenn Sie beispielsweise eine Präsentation in der PowerPoint-App speichern, können Sie diesen C#-Code ausführen, um die Anzahl vordefinierter Hintergründe in der Präsentation herauszufinden:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Anzahl der Hintergrundfüllstile für das Thema ist {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

Durch die Verwendung der [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) Eigenschaft aus der [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) Klasse können Sie den Hintergrundstil in einem PowerPoint-Thema hinzufügen oder darauf zugreifen. 

{{% /alert %}}

Dieser C#-Code zeigt Ihnen, wie Sie den Hintergrund für eine Präsentation festlegen:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Index-Leitfaden**: 0 wird für keine Füllung verwendet. Der Index beginnt bei 1.

{{% alert color="primary" title="TIPP" %}} 

Sie möchten möglicherweise [PowerPoint-Hintergrund](/slides/net/presentation-background/) ansehen.

{{% /alert %}}

## **Themeneffekt ändern**

Ein PowerPoint-Thema enthält normalerweise 3 Werte für jedes Stil-Array. Diese Arrays werden in diese 3 Effekte kombiniert: subtil, moderat und intensiv. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) aus der [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) Klasse können Sie die Elemente in einem Thema (sogar flexibler als die Optionen in PowerPoint) ändern.

Dieser C#-Code zeigt Ihnen, wie Sie einen Thema-Effekt ändern, indem Sie Teile von Elementen ändern:

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

Die resultierenden Änderungen bei Füllfarbe, Fülltyp, Schatteneffekt usw.:

![todo:image_alt_text](presentation-design_11.png)