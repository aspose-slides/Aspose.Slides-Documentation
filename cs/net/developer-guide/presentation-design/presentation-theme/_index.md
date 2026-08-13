---
title: Správa témat prezentací v .NET
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/net/presentation-theme/
keywords:
- Téma PowerPoint
- téma prezentace
- téma snímku
- nastavit téma
- změnit téma
- spravovat téma
- barva tématu
- dodatečná paleta
- písmo tématu
- styl tématu
- efekt tématu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte hlavní témata prezentací v Aspose.Slides pro .NET a vytvářejte, přizpůsobujte a převádějte soubory PowerPoint s jednotnou vizuální identitou."
---
## **Úvod**

Téma prezentace definuje vlastnosti návrhových prvků. Když vyberete téma prezentace, v podstatě vybíráte konkrétní sadu vizuálních prvků a jejich vlastnosti.

V PowerPointu téma zahrnuje barvy, [písma](/slides/cs/net/powerpoint-fonts/), [styly pozadí](/slides/cs/net/presentation-background/) a efekty.

![theme-constituents](theme-constituents.png)

## **Změna barvy tématu**

Téma PowerPointu používá konkrétní sadu barev pro různé prvky na snímku. Pokud se vám barvy nelíbí, můžete je změnit aplikací nových barev pro téma. Pro výběr nové barvy tématu poskytuje Aspose.Slides hodnoty v enumeraci [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/).

Tento C# kód ukazuje, jak změnit akcentní barvu pro téma:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Takto můžete zjistit efektivní hodnotu výsledné barvy:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    var fillEffective = shape.FillFormat.GetEffective();

    Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Barva [A=255, R=128, G=100, B=162])
}
```

Abychom dále demonstrovali operaci změny barvy, vytvoříme další prvek a přiřadíme mu akcentní barvu (z počáteční operace). Pak změníme barvu v tématu:

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

Nová barva se automaticky použije na obou prvcích.

### **Nastavení barvy tématu z další palety**

Když aplikujete transformace jasu na hlavní barvu tématu (1), vznikají barvy z další palety (2). Pak můžete tyto barvy tématu nastavit a získat.

![additional-palette-colors](additional-palette-colors.png)

**1** – Hlavní barvy tématu  
**2** – Barvy z další palety.

Tento C# kód demonstruje operaci, kdy jsou barvy další palety získány z hlavní barvy tématu a poté použity ve tvarech:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Akcent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Akcent 4, světlejší 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcent 4, světlejší 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcent 4, světlejší 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcent 4, tmavší 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcent 4, tmavší 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

### **Mapovat `SchemeColor` na barvy `IColorScheme`**

Když pracujete s [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/), můžete si všimnout, že obsahuje následující hodnoty barev tématu:

`Background1`, `Background2`, `Text1`, and `Text2`.

Nicméně `Presentation.MasterTheme.ColorScheme` vrací [IColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/), který poskytuje odpovídající barvy jako:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Tento rozdíl je jen v pojmenování. Tyto hodnoty odkazují na stejné sloty barev tématu a mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Neexistuje žádná dynamická konverze mezi `Text`/`Background` a `Dark`/`Light`. Jedná se jen o alternativní názvy pro stejné barvy tématu.

Tento rozdíl v pojmenování pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější verze UI zobrazují stejné sloty jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma tématu**

Aby vám umožnil vybrat písma pro témata a další účely, Aspose.Slides používá tyto speciální identifikátory (podobně jako v PowerPointu):

* **+mn-lt** – tělo písma Latin (menší latinské písmo)
* **+mj-lt** – nadpis písma Latin (větší latinské písmo)
* **+mn-ea** – tělo písma Východní Asie (menší asijské písmo)
* **+mj-ea** – tělo písma Východní Asie (menší asijské písmo)

Tento C# kód ukazuje, jak přiřadit latinské písmo k prvku tématu:

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

Tento C# kód ukazuje, jak změnit písmo tématu prezentace:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation())
{
    pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
}
```

Písmo ve všech textových polích bude aktualizováno.

{{% alert color="info" title="TIP" %}} 
Možná budete chtít zobrazit [písma PowerPointu](/slides/cs/net/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí tématu**

Ve výchozím nastavení aplikace PowerPoint poskytuje 12 předdefinovaných pozadí, ale pouze 3 z těchto 12 pozadí jsou uložena v typické prezentaci.

![todo:image_alt_text](presentation-design_8.png)

Například po uložení prezentace v aplikaci PowerPoint můžete spustit tento C# kód, abyste zjistili počet předdefinovaných pozadí v prezentaci:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Pomocí vlastnosti [BackgroundFillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/) můžete přidat nebo získat styl pozadí v tématu PowerPointu. 
{{% /alert %}}

Tento C# kód ukazuje, jak nastavit pozadí pro prezentaci:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Masters[0].Background.StyleIndex = 2;
}
```

**Průvodce indexem**: 0 se používá pro žádnou výplň. Index začíná od 1.

{{% alert color="info" title="TIP" %}} 
Možná budete chtít zobrazit [pozadí PowerPointu](/slides/cs/net/presentation-background/).
{{% /alert %}}

## **Změna efektu tématu**

Téma PowerPointu obvykle obsahuje 3 hodnoty pro každé pole stylů. Tyto pole jsou sloučeny do 3 efektů: jemný, střední a intenzivní. Například toto je výsledek, když jsou efekty aplikovány na konkrétní tvar:

![todo:image_alt_text](presentation-design_10.png)

Pomocí 3 vlastností ([FillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/effectstyles)) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme) můžete měnit prvky v tématu (ještě flexibilněji než v PowerPointu).

Tento C# kód ukazuje, jak změnit efekt tématu úpravou částí prvků:

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

Výsledné změny ve výplňové barvě, typu výplně, stínovém efektu atd.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

### Mohu použít téma na jediný snímek bez změny masteru?

Ano. Aspose.Slides podporuje přepsání tématu na úrovni snímku, takže můžete použít lokální téma jen na tento snímek a přitom zachovat master téma nedotčené (pomocí [SlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/slidethememanager/)).

### Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?

[Klonování snímků](/slides/cs/net/clone-slides/) spolu s jejich masterem do cílové prezentace. Tím se zachová původní master, rozvržení a související téma, takže vzhled zůstane konzistentní.

### Jak mohu zobrazit „efektivní“ hodnoty po veškerém dědictví a přepsání?

Použijte ["efektivní" pohledy](/slides/cs/net/shape-effective-properties/) API pro téma/barvu/písmo/efekt. Tyto vracejí vyřešené, konečné vlastnosti po aplikaci masteru a všech lokálních přepsání.