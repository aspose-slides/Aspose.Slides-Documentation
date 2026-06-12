---
title: Správa motivů prezentací na Androidu
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/androidjava/presentation-theme/
keywords:
- Motiv PowerPoint
- Motiv prezentace
- Motiv snímku
- Nastavit motiv
- Změnit motiv
- Spravovat motiv
- Barva motivu
- Další paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte motivy prezentací v Aspose.Slides pro Android pomocí Javy k vytváření, přizpůsobení a převodu souborů PowerPoint s konzistentní značkou."
---
## **Úvod**

Motiv prezentace určuje vlastnosti návrhových prvků. Když vyberete motiv prezentace, v podstatě zvolíte konkrétní sadu vizuálních prvků a jejich vlastností.

V PowerPointu motiv zahrnuje barvy, [fonts](/slides/cs/androidjava/powerpoint-fonts/), [background styles](/slides/cs/androidjava/presentation-background/) a efekty.

![theme-constituents](theme-constituents.png)

## **Změna barvy motivu**

Motiv PowerPointu používá konkrétní sadu barev pro různé prvky na snímku. Pokud se vám barvy nelíbí, můžete je změnit aplikací nových barev pro motiv. Aby bylo možné vybrat novou barvu motivu, Aspose.Slides poskytuje hodnoty v enumeraci [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SchemeColor).

Tento Java kód ukazuje, jak změnit akcentní barvu motivu:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Efektivní hodnotu výsledné barvy můžete zjistit takto:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Pro další demonstraci operace změny barvy vytvoříme další prvek a přiřadíme mu akcentní barvu (z počáteční operace). Pak změníme barvu v motivu:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Nová barva se automaticky použije na oba prvky.

### **Nastavení barvy motivu z další palety**

Když aplikujete transformace jasu na hlavní barvu motivu(1), vznikají barvy z další palety(2). Tyto barvy motivu pak můžete nastavit a získat.

![additional-palette-colors](additional-palette-colors.png)

**1** – Hlavní barvy motivu  

**2** – Barvy z další palety.

Tento Java kód demonstruje operaci, kde jsou barvy další palety získány z hlavní barvy motivu a poté použity ve tvarech:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Akcent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Akcent 4, světlejší 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Akcent 4, světlejší 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Akcent 4, světlejší 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Akcent 4, tmavší 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Akcent 4, tmavší 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Mapování `SchemeColor` na barvy `IColorScheme`**

Když pracujete s [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/schemecolor/), můžete si všimnout, že obsahuje následující hodnoty barvy motivu:

`Background1`, `Background2`, `Text1` a `Text2`.

Nicméně `Presentation.getMasterTheme().getColorScheme()` vrací [IColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icolorscheme/), který vystavuje odpovídající barvy jako:

`Dark1`, `Dark2`, `Light1` a `Light2`.

Tento rozdíl je jen v pojmenování. Tyto hodnoty odkazují na stejné sloty barvy motivu a mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Mezi `Text`/`Background` a `Dark`/`Light` neexistuje žádná dynamická konverze. Jedná se jen o alternativní názvy pro stejné barvy motivu.

Tento rozdíl v názvech pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější UI verze zobrazují stejné sloty jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma motivu**

Aby bylo možné vybrat písma pro motivy a další účely, Aspose.Slides používá tyto speciální identifikátory (podobné těm, které jsou použity v PowerPointu):

* **+mn-lt** – Body Font Latin (Minor Latin Font)
* **+mj-lt** – Heading Font Latin (Major Latin Font)
* **+mn-ea** – Body Font East Asian (Minor East Asian Font)
* **+mj-ea** – Body Font East Asian (Major East Asian Font)

Tento Java kód ukazuje, jak přiřadit latinské písmo k prvku motivu:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Tento Java kód ukazuje, jak změnit písmo motivu prezentace:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Písmo ve všech textových polích bude aktualizováno.

{{% alert color="primary" title="TIP" %}} 
Můžete si také prohlédnout [PowerPoint fonts](/slides/cs/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí motivu**

Ve výchozím nastavení aplikace PowerPoint poskytuje 12 předdefinovaných pozadí, ale ve typické prezentaci jsou uloženy jen 3 z těchto 12 pozadí.

![todo:image_alt_text](presentation-design_8.png)

Například po uložení prezentace v aplikaci PowerPoint můžete spustit tento Java kód a zjistit počet předdefinovaných pozadí v prezentaci:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Pomocí vlastnosti [BackgroundFillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) třídy [FormatScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme) můžete přidat nebo přistupovat ke stylu pozadí v motivu PowerPoint.
{{% /alert %}} 

Tento Java kód ukazuje, jak nastavit pozadí pro prezentaci:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Průvodce indexy**: 0 znamená žádnou výplň. Index začíná od 1.

{{% alert color="primary" title="TIP" %}} 
Můžete si také prohlédnout [PowerPoint Background](/slides/cs/androidjava/presentation-background/).
{{% /alert %}}

## **Změna efektu motivu**

Motiv PowerPointu obvykle obsahuje 3 hodnoty pro každý pole stylů. Tyto pole jsou kombinovány do 3 efektů: subtilní, střední a intenzivní. Například takto vypadá výsledek, když jsou efekty aplikovány na konkrétní tvar:

![todo:image_alt_text](presentation-design_10.png)

Pomocí 3 vlastností ([FillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) třídy [FormatScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme) můžete měnit prvky v motivu (ještě flexibilněji než možnosti v PowerPointu).

Tento Java kód ukazuje, jak změnit efekt motivu úpravou částí prvků:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Výsledné změny ve výplňové barvě, typu výplně, stínovacím efektu atd.:

![todo:image_alt_text](presentation-design_11.png)

## **Často kladené otázky**

**Mohu aplikovat motiv na jediný snímek bez změny masteru?**

Ano. Aspose.Slides podporuje přepis motivu na úrovni snímku, takže můžete aplikovat lokální motiv jen na tento snímek a zároveň ponechat master motiv nezměněný (prostřednictvím [SlideThemeManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidethememanager/)).

**Jaký je nejoblíbenější způsob, jak přenést motiv z jedné prezentace do druhé?**

[Clone slides](/slides/cs/androidjava/clone-slides/) spolu s jejich masterem do cílové prezentace. Tím se zachová původní master, rozvržení a související motiv, takže vzhled zůstane konzistentní.

**Jak mohu zobrazit „efektivní“ hodnoty po veškerém dědění a přepsání?**

Použijte API „effective“ pohledy](/slides/cs/androidjava/shape-effective-properties/) pro motiv/barvu/písmo/efekt. Vrací vyřešené, finální vlastnosti po aplikaci masteru a všech lokálních přepisů.