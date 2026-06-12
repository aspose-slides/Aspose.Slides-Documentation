---
title: Správa témat prezentací v Javě
linktitle: Téma prezentace
type: docs
weight: 10
url: /cs/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Spravujte témata prezentací v Aspose.Slides pro Javu, abyste vytvořili, upravili a převáděli soubory PowerPoint s jednotným značkováním."
---
## **Úvod**

Téma prezentace definuje vlastnosti designových prvků. Když vyberete téma prezentace, v podstatě volíte konkrétní sadu vizuálních prvků a jejich vlastnosti.

V PowerPointu téma zahrnuje barvy, [písma](/slides/cs/java/powerpoint-fonts/), [styly pozadí](/slides/cs/java/presentation-background/) a efekty.

![theme-constituents](theme-constituents.png)

## **Změna barvy tématu**

Téma PowerPointu používá specifickou sadu barev pro různé prvky na snímku. Pokud se vám barvy nelíbí, můžete je změnit aplikací nových barev pro téma. Aby bylo možné vybrat novou barvu tématu, Aspose.Slides poskytuje hodnoty v enumeraci [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SchemeColor).

Tento Java kód ukazuje, jak změnit akcentní barvu pro téma:

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

Takto můžete určit efektivní hodnotu výsledné barvy:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

Pro další demonstraci operace změny barvy vytvoříme další prvek a přiřadíme mu akcentní barvu (z počáteční operace). Pak změníme barvu v tématu:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

Nová barva se automaticky aplikuje na oba prvky.

### **Nastavení barvy tématu z další palety**

Při aplikaci transformací jasu na hlavní barvu tématu (1) se vytvoří barvy z další palety (2). Pak můžete tyto barvy tématu nastavit a získat.

![additional-palette-colors](additional-palette-colors.png)

**1** - Hlavní barvy tématu  
**2** - Barvy z další palety.

Tento Java kód demonstruje operaci, kde jsou barvy z další palety získány z hlavní barvy tématu a následně použity ve tvarech:

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

Když pracujete s [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/schemecolor/), můžete si všimnout, že obsahuje následující hodnoty barev tématu:

`Background1`, `Background2`, `Text1`, and `Text2`.

Nicméně `Presentation.getMasterTheme().getColorScheme()` vrací [IColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorscheme/), který zpřístupňuje odpovídající barvy jako:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

Tento rozdíl je pouze v pojmenování. Tyto hodnoty odkazují na stejné sloty barev tématu a mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Není žádná dynamická konverze mezi `Text`/`Background` a `Dark`/`Light`. Jedná se jen o alternativní názvy pro stejné barvy tématu.

Tento rozdíl v pojmenování pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější UI verze zobrazují stejné sloty jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma tématu**

Aby bylo možné vybrat písma pro témata a další účely, Aspose.Slides používá tyto speciální identifikátory (podobné těm používaným v PowerPointu):

* **+mn-lt** - tělové písmo Latin (Minor Latin Font)
* **+mj-lt** - nadpisové písmo Latin (Major Latin Font)
* **+mn-ea** - tělové písmo East Asian (Minor East Asian Font)
* **+mj-ea** - tělové písmo East Asian (Major East Asian Font)

Tento Java kód ukazuje, jak přiřadit latinské písmo k prvku tématu:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

Tento Java kód ukazuje, jak změnit písmo tématu prezentace:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

Písmo ve všech textových polích bude aktualizováno.

{{% alert color="primary" title="TIP" %}} 
Můžete se podívat na [písma PowerPointu](/slides/cs/java/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí tématu**

Ve výchozím nastavení aplikace PowerPoint poskytuje 12 předdefinovaných pozadí, ale v typické prezentaci jsou uložena pouze 3 z těchto 12 pozadí.

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
Pomocí vlastnosti [BackgroundFillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) třídy [FormatScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme) můžete přidat nebo získat styl pozadí v tématu PowerPoint.
{{% /alert %}} 

Tento Java kód ukazuje, jak nastavit pozadí pro prezentaci:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Průvodce indexem**: 0 se používá pro žádné výplň. Index začíná od 1.

{{% alert color="primary" title="TIP" %}} 
Můžete se podívat na [Pozadí PowerPointu](/slides/cs/java/presentation-background/).
{{% /alert %}}

## **Změna efektu tématu**

Téma PowerPointu obvykle obsahuje 3 hodnoty pro každé pole stylu. Tato pole jsou kombinována do těchto 3 efektů: jemný, střední a intenzivní. Například toto je výsledek, když jsou efekty aplikovány na konkrétní tvar:

![todo:image_alt_text](presentation-design_10.png)

Pomocí 3 vlastností ([FillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme#getEffectStyles--)) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme) můžete měnit prvky v tématu (ještě flexibilněji než možnosti v PowerPointu).

Tento Java kód ukazuje, jak změnit efekt tématu úpravou částí prvků:

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

Následující změny ve výplni barvy, typu výplně, stínu atd.:

![todo:image_alt_text](presentation-design_11.png)

## **Často kladené otázky**

**Mohu použít téma na jediný snímek bez změny masteru?**

Ano. Aspose.Slides podporuje přepsání tématu na úrovni snímku, takže můžete použít lokální téma pouze na tento snímek, přičemž zachováte hlavní téma beze změny (pomocí [SlideThemeManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidethememanager/)).

**Jaký je nejbezpečnější způsob, jak přenést téma z jedné prezentace do druhé?**

[Klonovat snímky](/slides/cs/java/clone-slides/) spolu s jejich masterem do cílové prezentace. To zachová původní master, rozvržení a přidružené téma, takže vzhled zůstane konzistentní.

**Jak mohu zobrazit „efektivní“ hodnoty po veškerém dědictví a přepsání?**

Použijte [efektivní zobrazení](/slides/cs/java/shape-effective-properties/) pro téma/barvu/písmo/efekt. Tato vrací vyřešené, konečné vlastnosti po aplikaci masteru a jakýchkoli lokálních přepisů.