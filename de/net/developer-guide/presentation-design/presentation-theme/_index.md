---
title: "Präsentationsthemen in .NET verwalten"
linktitle: "Präsentationsthema"
type: docs
weight: 10
url: /de/net/presentation-theme/
keywords:
- "PowerPoint-Thema"
- "Präsentationsthema"
- "Folienthema"
- "Thema festlegen"
- "Thema ändern"
- "Thema verwalten"
- "Themenfarbe"
- "Zusätzliche Palette"
- "Themen-Schriftart"
- "Themenstil"
- "Themen-Effekt"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Master-Präsentationsthemen in Aspose.Slides für .NET zum Erstellen, Anpassen und Konvertieren von PowerPoint-Dateien mit konsistenter Markenbildung."
---
## **Einführung**

Ein Präsentationsthema definiert die Eigenschaften von Designelementen. Wenn Sie ein Präsentationsthema auswählen, wählen Sie im Wesentlichen einen bestimmten Satz visueller Elemente und deren Eigenschaften.

In PowerPoint besteht ein Thema aus Farben, [Schriftarten](/slides/de/net/powerpoint-fonts/), [Hintergrundstile](/slides/de/net/presentation-background/), und Effekten.

![theme-constituents](theme-constituents.png)

## **Themafarbe ändern**

Ein PowerPoint-Thema verwendet einen bestimmten Satz von Farben für verschiedene Elemente einer Folie. Wenn Ihnen die Farben nicht gefallen, ändern Sie sie, indem Sie neue Farben für das Thema anwenden. Damit Sie eine neue Themafarbe auswählen können, stellt Aspose.Slides Werte aus der Aufzählung [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) bereit.

Dieser C#‑Code zeigt, wie Sie die Akzentfarbe eines Themas ändern:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

So können Sie den effektiven Wert der resultierenden Farbe bestimmen:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Farbe [A=255, R=128, G=100, B=162])
}
```

Um die Farbänderungs‑Operation weiter zu demonstrieren, erstellen wir ein weiteres Element und weisen ihm die Akzentfarbe (aus der ersten Operation) zu. Anschließend ändern wir die Farbe im Thema:

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.FillFormat.FillType = FillType.Solid;

    otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
}
```

Die neue Farbe wird automatisch auf beiden Elementen angewendet.

### **Themafarbe aus einer zusätzlichen Palette festlegen**

Wenn Sie Luminanztransformationen auf die Hauptthemafarbe (1) anwenden, entstehen Farben aus der zusätzlichen Palette (2). Diese Themafarben können Sie dann setzen und abrufen.

![additional-palette-colors](additional-palette-colors.png)

**1** – Hauptthemafarben  
**2** – Farben aus der zusätzlichen Palette.

Dieser C#‑Code demonstriert eine Operation, bei der zusätzliche Palettenfarben aus der Hauptthemafarbe gewonnen und anschließend in Formen verwendet werden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **`SchemeColor` auf `IColorScheme`‑Farben abbilden**

Wenn Sie mit [SchemeColor](https://reference.aspose.com/slides/de/net/aspose.slides/schemecolor/) arbeiten, werden Sie feststellen, dass es die folgenden Themenfarbwerte enthält: `Background1`, `Background2`, `Text1` und `Text2`.

Allerdings gibt `Presentation.MasterTheme.ColorScheme` [IColorScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/icolorscheme/) zurück, das die entsprechenden Farben wie folgt bereitstellt: `Dark1`, `Dark2`, `Light1` und `Light2`.

Dieser Unterschied besteht nur in der Benennung. Diese Werte beziehen sich auf dieselben Themenfarbplätze und die Zuordnung ist festgelegt:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Es gibt keine dynamische Umwandlung zwischen `Text`/`Background` und `Dark`/`Light`. Es handelt sich lediglich um alternative Bezeichnungen für dieselben Themenfarben.

Dieser Namensunterschied stammt aus der Terminologie von Microsoft Office. Ältere Office‑Versionen verwendeten `Dark 1`, `Light 1`, `Dark 2` und `Light 2`, während neuere UI‑Versionen dieselben Plätze als `Text 1`, `Background 1`, `Text 2` und `Background 2` anzeigen.

## **Thema‑Schriftart ändern**

Damit Sie Schriftarten für Themen und andere Zwecke auswählen können, verwendet Aspose.Slides diese speziellen Bezeichner (ähnlich denen, die in PowerPoint verwendet werden):

* **+mn-lt** – Körper‑Schriftart Lateinisch (Minor Latin Font)
* **+mj-lt** – Überschrifts‑Schriftart Lateinisch (Major Latin Font)
* **+mn-ea** – Körper‑Schriftart Ostasiatisch (Minor East Asian Font)
* **+mj-ea** – Körper‑Schriftart Ostasiatisch (Minor East Asian Font)

Dieser C#‑Code zeigt, wie Sie die lateinische Schriftart einem Theme‑Element zuweisen:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.Portions.Add(portion);

    shape.TextFrame.Paragraphs.Add(paragraph);

    portion.PortionFormat.LatinFont = new FontData("+mn-lt");
}
```

Dieser C#‑Code zeigt, wie Sie die Schriftart des Präsentationsthemas ändern:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

Die Schriftart in allen Textfeldern wird aktualisiert.

{{% alert color="info" title="TIP" %}} 
Sie möchten vielleicht die [PowerPoint-Schriftarten](/slides/de/net/powerpoint-fonts/) sehen. 
{{% /alert %}}

## **Hintergrundstil des Themas ändern**

Standardmäßig stellt die PowerPoint‑App 12 vordefinierte Hintergründe bereit, von denen in einer typischen Präsentation jedoch nur 3 gespeichert werden. 

![todo:image_alt_text](presentation-design_8.png)

Beispiel: Nachdem Sie eine Präsentation in der PowerPoint‑App gespeichert haben, können Sie diesen C#‑Code ausführen, um die Anzahl der vordefinierten Hintergründe in der Präsentation zu ermitteln:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Mit der Eigenschaft [BackgroundFillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) aus der Klasse [FormatScheme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/) können Sie den Hintergrundstil in einem PowerPoint‑Theme hinzufügen oder darauf zugreifen. 
{{% /alert %}}

Dieser C#‑Code zeigt, wie Sie den Hintergrund für eine Präsentation festlegen:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Index‑Leitfaden**: 0 bedeutet keine Füllung. Der Index beginnt bei 1.

{{% alert color="info" title="TIP" %}} 
Sie möchten vielleicht den [PowerPoint‑Hintergrund](/slides/de/net/presentation-background/) sehen. 
{{% /alert %}}

## **Thema‑Effekt ändern**

Ein PowerPoint‑Theme enthält normalerweise 3 Werte für jedes Stil‑Array. Diese Arrays werden zu den 3 Effekten subtil, moderat und intensiv kombiniert. Beispielhaft das Ergebnis, wenn die Effekte auf eine bestimmte Form angewendet werden:

![todo:image_alt_text](presentation-design_10.png)

Mit den 3 Eigenschaften ([FillStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/de/net/aspose.slides.theme/formatscheme/effectstyles)) aus der Klasse [FormatScheme] können Sie die Elemente eines Themes ändern (noch flexibler als die Optionen in PowerPoint).

Dieser C#‑Code zeigt, wie Sie einen Theme‑Effekt ändern, indem Sie Teile von Elementen anpassen:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **FAQ**

### Kann ich ein Thema auf eine einzelne Folie anwenden, ohne das Master‑Thema zu ändern?

Ja. Aspose.Slides unterstützt Themen‑Überschreibungen auf Folienebene, sodass Sie ein lokales Thema nur auf diese Folie anwenden können, während das Master‑Thema unverändert bleibt (über den [SlideThemeManager](https://reference.aspose.com/slides/de/net/aspose.slides.theme/slidethememanager/)).

### Was ist die sicherste Methode, ein Thema von einer Präsentation in eine andere zu übernehmen?

[Klonen Sie Folien](/slides/de/net/clone-slides/) zusammen mit ihrem Master in die Zielpräsentation. Dadurch bleiben das ursprüngliche Master‑Layout, die Layouts und das zugehörige Thema erhalten, sodass das Aussehen konsistent bleibt.

### Wie kann ich die „effektiven“ Werte nach allen Vererbungen und Überschreibungen sehen?

Verwenden Sie die ["effektiven" Ansichten](/slides/de/net/shape-effective-properties/) der API für Thema/Farbe/Schriftart/Effekt. Diese geben die aufgelösten, endgültigen Eigenschaften zurück, nachdem der Master sowie alle lokalen Überschreibungen angewendet wurden.