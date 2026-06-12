---
title: Správa témat prezentací v .NET
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/net/presentation-theme/
keywords:
- téma PowerPoint
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
description: "Spravujte hlavní témata prezentací v Aspose.Slides pro .NET, abyste vytvářeli, přizpůsobovali a převáděli soubory PowerPoint s jednotnou značkou."
---
## **Úvod**

Prezentace téma definuje vlastnosti designových prvků. Když vyberete téma prezentace, v podstatě si volíte konkrétní sadu vizuálních prvků a jejich vlastností.

V PowerPointu téma zahrnuje barvy, [fonts](/slides/cs/net/powerpoint-fonts/), [background styles](/slides/cs/net/presentation-background/) a efekty.

![theme-constituents](theme-constituents.png)

## **Změna barvy tématu**

Téma PowerPointu používá konkrétní sadu barev pro různé elementy na snímku. Pokud se vám barvy nelíbí, můžete je změnit aplikací nových barev pro téma. Pro výběr nové barvy tématu poskytuje Aspose.Slides hodnoty v enumeraci [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/).

Tento C# kód ukazuje, jak změnit akcentní barvu tématu:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

Můžete tak zjistit efektivní hodnotu výsledné barvy:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Barva [A=255, R=128, G=100, B=162])
```

Pro další demonstraci operace změny barvy vytvoříme další prvek a přiřadíme mu akcentní barvu (z počáteční operace). Potom změníme barvu v tématu:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

Nová barva se aplikuje automaticky na oba prvky.

### **Nastavení barvy tématu z dodatečné palety**

Když aplikujete transformace jasu na hlavní barvu tématu(1), vznikají barvy z dodatečné palety(2). Tyto barvy tématu můžete následně nastavit a získat.

![additional-palette-colors](additional-palette-colors.png)

**1** – Hlavní barvy tématu  

**2** – Barvy z dodatečné palety.

Tento C# kód demonstruje operaci, při níž jsou barvy dodatečné palety získány z hlavní barvy tématu a poté použity ve tvarech:

```c#
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

### **Mapování `SchemeColor` na barvy `IColorScheme`**

Když pracujete s [SchemeColor](https://reference.aspose.com/slides/cs/net/aspose.slides/schemecolor/), můžete si všimnout, že obsahuje následující hodnoty barvy tématu:

`Background1`, `Background2`, `Text1` a `Text2`.

Nicméně `Presentation.MasterTheme.ColorScheme` vrací [IColorScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/icolorscheme/), který vystavuje odpovídající barvy jako:

`Dark1`, `Dark2`, `Light1` a `Light2`.

Tento rozdíl je jen v názvech. Tyto hodnoty odkazují na stejné sloty barvy tématu a mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Mezi `Text`/`Background` a `Dark`/`Light` neexistuje žádná dynamická konverze. Jedná se jen o alternativní názvy pro stejné barvy tématu.

Tento rozdíl v názvosloví pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější UI verze zobrazují stejné sloty jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma tématu**

Aby vám Aspose.Slides umožnil vybírat písma pro témata a další účely, používá tyto speciální identifikátory (podobně jako v PowerPointu):

* **+mn-lt** – Tělo písma Latin (Minor Latin Font)
* **+mj-lt** – Nadpis písma Latin (Major Latin Font)
* **+mn-ea** – Tělo písma Východní Asie (Minor East Asian Font)
* **+mj-ea** – Nadpis písma Východní Asie (Major East Asian Font)

Tento C# kód ukazuje, jak přiřadit latinské písmo k prvku tématu:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

Tento C# kód ukazuje, jak změnit písmo tématu prezentace:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

Písmo ve všech textových polích bude aktualizováno.

{{% alert color="primary" title="TIP" %}} 
Možná budete chtít zobrazit [PowerPoint fonts](/slides/cs/net/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí tématu**

Ve výchozím nastavení aplikace PowerPoint poskytuje 12 předdefinovaných pozadí, ale pouze 3 z těchto 12 jsou uložena v typické prezentaci.

![todo:image_alt_text](presentation-design_8.png)

Například po uložení prezentace v aplikaci PowerPoint můžete spustit tento C# kód a zjistit počet předdefinovaných pozadí v prezentaci:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 
Pomocí vlastnosti [BackgroundFillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/) můžete do tématu PowerPointu přidat nebo získat styl pozadí. 
{{% /alert %}}

Tento C# kód ukazuje, jak nastavit pozadí pro prezentaci:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Průvodce indexy**: 0 znamená žádnou výplň. Index začíná od 1.

{{% alert color="primary" title="TIP" %}} 
Možná budete chtít zobrazit [PowerPoint Background](/slides/cs/net/presentation-background/).
{{% /alert %}}

## **Změna efektu tématu**

Téma PowerPointu obvykle obsahuje 3 hodnoty pro každé pole stylu. Tyto pole jsou kombinována do 3‑ech efektů: subtle, moderate a intense. Například takto vypadá výsledek, když jsou efekty aplikovány na konkrétní tvar:

![todo:image_alt_text](presentation-design_10.png)

Pomocí 3 vlastností ([FillStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme/effectstyles)) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/formatscheme) můžete měnit prvky v tématu (ještě flexibilněji než možnosti v PowerPointu).

Tento C# kód ukazuje, jak změnit efekt tématu úpravou částí prvků:

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

Výsledné změny ve výplni barvy, typu výplně, stínu atd.:

![todo:image_alt_text](presentation-design_11.png)

## **Časté otázky**

**Mohu použít téma jen pro jeden snímek, aniž bych změnil master?**

Ano. Aspose.Slides podporuje přepsání tématu na úrovni snímku, takže můžete aplikovat lokální téma jen na daný snímek a zachovat master téma nedotčené (prostřednictvím [SlideThemeManager](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/slidethememanager/)).

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

[Clone slides](/slides/cs/net/clone-slides/) spolu s jejich masterem do cílové prezentace. Tím zachováte originální master, rozvržení i přidružené téma, takže vzhled zůstane konzistentní.

**Jak mohu zobrazit „efektivní“ hodnoty po veškerém dědění a přepsání?**

Použijte API‑ho ["effective" views](/slides/cs/net/shape-effective-properties/) pro theme/color/font/effect. Tyto metody vrací vyřešené, konečné vlastnosti po aplikaci masteru a případných lokálních přepsání.