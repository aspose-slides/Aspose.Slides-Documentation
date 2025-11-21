---
title: Verwalten von Präsentationsthemen in .NET
linktitle: Präsentationsthema
type: docs
weight: 10
url: /de/net/presentation-theme/
keywords:
- PowerPoint-Thema
- Präsentationsthema
- Folienthema
- Thema festlegen
- Thema ändern
- Thema verwalten
- Themenfarbe
- zusätzliche Palette
- Themen-Schriftart
- Themenstil
- Themen-Effekt
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Master-Präsentationsthemen in Aspose.Slides für .NET erstellen, anpassen und PowerPoint-Dateien mit konsistentem Branding konvertieren."
---

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriften](/slides/de/net/powerpoint-fonts/), [Hintergrundstile](/slides/de/net/presentation-background/), und Effekten.

![theme-constituents](theme-constituents.png)

## **Themefarbe ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Um Ihnen die Auswahl einer neuen Themefarbe zu ermöglichen, stellt Aspose.Slides Werte aus der [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/)-Aufzählung bereit.

Dieser C#-Code zeigt, wie Sie die Akzentfarbe für ein Thema ändern:
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


Um die Farbänderungsoperation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der Ausgangsoperation) zu. Anschließend ändern wir die Farbe im Thema:
```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```


Die neue Farbe wird automatisch auf beide Elemente angewendet.

### **Themefarbe aus zusätzlicher Palette festlegen**

Wenn Sie Leuchtdichte-Transformationen auf die Haupt-Themefarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Sie können diese Themefarben dann setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** - Haupt-Themefarben  
**2** - Farben aus der zusätzlichen Palette.

Dieser C#-Code demonstriert eine Operation, bei der Farben der zusätzlichen Palette aus der Haupt-Themefarbe gewonnen und anschließend in Formen verwendet werden:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Akzent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Akzent 4, Aufhellung 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akzent 4, Aufhellung 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akzent 4, Aufhellung 40%
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


## **Theme-Schriftart ändern**

Um Ihnen die Auswahl von Schriften für Themen und andere Zwecke zu ermöglichen, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen, die in PowerPoint verwendet werden):

* **+mn-lt** - Fließtextschrift Latein (Minor Latin Font)
* **+mj-lt** - Überschriftschrift Latein (Major Latin Font)
* **+mn-ea** - Fließtextschrift Ostasiatisch (Minor East Asian Font)
* **+mj-ea** - Body Font East Asian (Minor East Asian Font)

Dieser C#-Code zeigt, wie Sie die lateinische Schrift einem Theme-Element zuweisen:
```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```


Dieser C#-Code zeigt, wie Sie die Präsentations-Theme-Schriftart ändern:
```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```


Die Schrift in allen Textfeldern wird aktualisiert.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie [PowerPoint-Schriften](/slides/de/net/powerpoint-fonts/) sehen. 
{{% /alert %}}

## **Theme-Hintergrundstil ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, aber in einer typischen Präsentation werden nur 3 dieser 12 Hintergründe gespeichert.

![todo:image_alt_text](presentation-design_8.png)

Zum Beispiel können Sie nach dem Speichern einer Präsentation in der PowerPoint‑App diesen C#‑Code ausführen, um die Anzahl vordefinierter Hintergründe in der Präsentation zu ermitteln:
```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```


{{% alert color="warning" %}} 
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) der Klasse [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) können Sie den Hintergrundstil in einem PowerPoint‑Theme hinzufügen oder darauf zugreifen. 
{{% /alert %}}

Dieser C#‑Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:
```c#
pres.Masters[0].Background.StyleIndex = 2;
```


**Index‑Leitfaden**: 0 bedeutet kein Füllung. Der Index beginnt bei 1.

{{% alert color="primary" title="TIP" %}} 
Vielleicht möchten Sie [PowerPoint-Hintergrund](/slides/de/net/presentation-background/) sehen. 
{{% /alert %}}

## **Theme‑Effekt ändern**

Ein PowerPoint‑Theme enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Zum Beispiel ist dies das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Durch die Verwendung von 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) der Klasse [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) können Sie die Elemente in einem Theme ändern (noch flexibler als die Optionen in PowerPoint).

Dieser C#‑Code zeigt, wie Sie einen Theme‑Effekt ändern, indem Sie Teile von Elementen anpassen:
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


Die resultierenden Änderungen in Füllfarbe, Fülltyp, Schatteneffekt usw.:
![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Kann ich ein Theme auf eine einzelne Folie anwenden, ohne den Master zu ändern?**  
Ja. Aspose.Slides unterstützt Theme‑Überschreibungen auf Folienebene, sodass Sie ein lokales Theme nur auf diese Folie anwenden können, während das Master‑Theme unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)).

**Was ist der sicherste Weg, ein Theme von einer Präsentation in eine andere zu übertragen?**  
[Slides klonen](/slides/de/net/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben der ursprüngliche Master, die Layouts und das zugehörige Theme erhalten, sodass das Aussehen konsistent bleibt.

**Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Overrides sehen?**  
Verwenden Sie die "effektiven" Ansichten der API [/slides/net/shape-effective-properties/](/slides/de/net/shape-effective-properties/) für Theme/Farbe/Schrift/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem der Master plus alle lokalen Overrides angewendet wurden.