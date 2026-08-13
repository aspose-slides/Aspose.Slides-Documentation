---
title: Hantera presentations-teman i .NET
linktitle: Presentations-tema
type: docs
weight: 10
url: /sv/net/presentation-theme/
keywords:
- PowerPoint-tema
- presentationstema
- bildtema
- sätt tema
- ändra tema
- hantera tema
- temafärg
- extra palett
- temateckensnitt
- temastil
- temaeffekt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska presentations-teman i Aspose.Slides för .NET för att skapa, anpassa och konvertera PowerPoint-filer med konsekvent varumärkesprofil."
---
## **Introduktion**

Ett presentations‑tema definierar egenskaperna för designelement. När du väljer ett presentations‑tema väljer du i praktiken en specifik uppsättning visuella element och deras egenskaper.

I PowerPoint består ett tema av färger, [teckensnitt](/slides/sv/net/powerpoint-fonts/), [bakgrundsstilar](/slides/sv/net/presentation-background/) och effekter.

![theme-constituents](theme-constituents.png)

## **Ändra temafärg**

Ett PowerPoint‑tema använder en specifik uppsättning färger för olika element på en bild. Om du inte gillar färgerna ändrar du dem genom att tillämpa nya färger för temat. För att låta dig välja en ny temafärg erbjuder Aspose.Slides värden under uppräkningen [SchemeColor](https://reference.aspose.com/slides/sv/net/aspose.slides/schemecolor/).

Den här C#‑koden visar hur du ändrar accentfärgen för ett tema:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Du kan bestämma den resulterande färgens effektiva värde på följande sätt:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Färg [A=255, R=128, G=100, B=162])
}
```

För att ytterligare demonstrera färgändringsoperationen skapar vi ett annat element och tilldelar accentfärgen (från den ursprungliga operationen) till det. Sedan ändrar vi färgen i temat:

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

Den nya färgen tillämpas automatiskt på båda elementen.

### **Ställ in temafärg från ett extra färgpalett**

När du tillämpar luminans‑transformeringar på huvudtemafärgen(1) bildas färger från den extra paletten(2). Du kan sedan ställa in och hämta dessa temafärger.

![additional-palette-colors](additional-palette-colors.png)

**1** - Huvudtemafärger  

**2** - Färger från den extra paletten.

Den här C#‑koden demonstrerar en operation där färger från den extra paletten hämtas från huvudtemafärgen och sedan används i former:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Accent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Accent 4, ljusare 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, ljusare 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, ljusare 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, mörkare 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, mörkare 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Mappa `SchemeColor` till `IColorScheme`‑färger**

När du arbetar med [SchemeColor](https://reference.aspose.com/slides/sv/net/aspose.slides/schemecolor/) kan du märka att den innehåller följande temafärgvärden:

`Background1`, `Background2`, `Text1` och `Text2`.

Dock returnerar `Presentation.MasterTheme.ColorScheme` ett [IColorScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/icolorscheme/) som exponerar motsvarande färger som:

`Dark1`, `Dark2`, `Light1` och `Light2`.

Denna skillnad är bara i namn. Dessa värden hänvisar till samma temafärg‑platser och mappningen är fast:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Det finns ingen dynamisk konvertering mellan `Text`/`Background` och `Dark`/`Light`. De är helt enkelt alternativa namn för samma temafärger.

Denna namnskillnad kommer från Microsoft Office‑terminologi. Äldre Office‑versioner använde `Dark 1`, `Light 1`, `Dark 2` och `Light 2`, medan nyare UI‑versioner visar samma platser som `Text 1`, `Background 1`, `Text 2` och `Background 2`.

## **Ändra temafont**

För att låta dig välja teckensnitt för teman och andra ändamål använder Aspose.Slides dessa specialidentifierare (liknande de som används i PowerPoint):

* **+mn-lt** – Body Font Latin (Minor Latin Font)
* **+mj-lt** – Heading Font Latin (Major Latin Font)
* **+mn-ea** – Body Font East Asian (Minor East Asian Font)
* **+mj-ea** – Body Font East Asian (Minor East Asian Font)

Den här C#‑koden visar hur du tilldelar det latinska teckensnittet till ett temaelement:

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

Den här C#‑koden visar hur du ändrar presentations‑temats teckensnitt:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

Teckensnittet i alla textrutor uppdateras.

{{% alert color="info" title="TIP" %}} 

Du kanske vill titta på [PowerPoint-teckensnitt](/slides/sv/net/powerpoint-fonts/).

{{% /alert %}}

## **Ändra temats bakgrundsstil**

Som standard erbjuder PowerPoint‑appen 12 fördefinierade bakgrunder men bara 3 av dessa 12 sparas i en typisk presentation.

![todo:image_alt_text](presentation-design_8.png)

Till exempel, efter att du sparat en presentation i PowerPoint‑appen, kan du köra den här C#‑koden för att ta reda på hur många fördefinierade bakgrunder som finns i presentationen:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

Genom att använda egenskapen [BackgroundFillStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) från klassen [FormatScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/) kan du lägga till eller komma åt bakgrundsstilen i ett PowerPoint‑tema. 

{{% /alert %}}

Den här C#‑koden visar hur du anger bakgrunden för en presentation:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Indexguide**: 0 betyder ingen fyllning. Indexet börjar på 1.

{{% alert color="info" title="TIP" %}} 

Du kanske vill titta på [PowerPoint‑bakgrund](/slides/sv/net/presentation-background/).

{{% /alert %}}

## **Ändra temaeffekt**

Ett PowerPoint‑tema innehåller vanligtvis 3 värden för varje stil‑array. Dessa arrayer kombineras till dessa 3 effekter: subtil, måttlig och intensiv. Till exempel är detta resultatet när effekterna tillämpas på en specifik form:

![todo:image_alt_text](presentation-design_10.png)

Genom att använda 3 egenskaper ([FillStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme/effectstyles)) från klassen [FormatScheme](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/formatscheme) kan du ändra elementen i ett tema (ännu mer flexibelt än alternativen i PowerPoint).

Den här C#‑koden visar hur du ändrar en temaeffekt genom att ändra delar av element:

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

De resulterande förändringarna i fyllningsfärg, fyllningstyp, skuggeffekt osv.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Kan jag tillämpa ett tema på en enskild bild utan att ändra master?

Ja. Aspose.Slides stöder bild‑nivå tema‑överskrivningar, så du kan tillämpa ett lokalt tema på just den bilden samtidigt som master‑temat förblir oförändrat (via [SlideThemeManager](https://reference.aspose.com/slides/sv/net/aspose.slides.theme/slidethememanager/)).

### Vad är det säkraste sättet att föra över ett tema från en presentation till en annan?

[Klon‑bilder](/slides/sv/net/clone-slides/) tillsammans med deras master till mål‑presentationen. Detta bevarar den ursprungliga mastern, layouterna och det associerade temat så att utseendet förblir konsekvent.

### Hur kan jag se de ”effektiva” värdena efter all arv och överskrivning?

Använd API:ets ["effektiva"](/slides/sv/net/shape-effective-properties/) visningar för tema/färg/font/effekt. Dessa returnerar de lösta, slutgiltiga egenskaperna efter att ha tillämpat mastern samt eventuella lokala överskrivningar.