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
- Doplňková paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte motivy prezentací v Aspose.Slides pro Android pomocí Javy pro vytváření, přizpůsobení a konverzi souborů PowerPoint s jednotnou značkou."
---
## **Úvod**

Motiv prezentace určuje vlastnosti návrhových prvků. Když vyberete motiv prezentace, v podstatě vybíráte konkrétní sadu vizuálních prvků a jejich vlastnosti.

V PowerPointu motiv zahrnuje barvy, [písma](/slides/cs/androidjava/powerpoint-fonts/), [styly pozadí](/slides/cs/androidjava/presentation-background/) a efekty.

![theme-constituents](theme-constituents.png)

## **Změna barvy motivu**

Motiv PowerPointu používá konkrétní sadu barev pro různé prvky na snímku. Pokud se vám barvy nelíbí, můžete je změnit aplikací nových barev pro motiv. Pro výběr nové barvy motivu poskytuje Aspose.Slides hodnoty v enumeraci [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SchemeColor).

Tento Java kód ukazuje, jak změnit akcentní barvu motivu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

Můžete takto zjistit efektivní hodnotu výsledné barvy:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

Pro další demonstraci operace změny barvy vytvoříme další prvek a přiřadíme mu akcentní barvu (z počáteční operace). Poté změníme barvu v motivu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Nová barva se automaticky použije na oba prvky.

### **Nastavení barvy motivu z doplňkové palety**

Když aplikujete transformace jasu na hlavní barvu motivu (1), vzniknou barvy z doplňkové palety (2). Pak můžete tyto barvy motivu nastavit i načíst.

![additional-palette-colors](additional-palette-colors.png)

**1** – Hlavní barvy motivu  
**2** – Barvy z doplňkové palety.

Tento Java kód demonstruje operaci, kde jsou barvy doplňkové palety získány z hlavní barvy motivu a následně použity ve tvarech:

```java
import com.aspose.slides.*;

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

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **Mapování `SchemeColor` na barvy `IColorScheme`**

Když pracujete s [SchemeColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/schemecolor/), můžete si všimnout, že obsahuje následující hodnoty barev motivu: `Background1`, `Background2`, `Text1` a `Text2`.

Nicméně `Presentation.getMasterTheme().getColorScheme()` vrací [IColorScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icolorscheme/), která poskytuje odpovídající barvy jako: `Dark1`, `Dark2`, `Light1` a `Light2`.

Tento rozdíl je jen v pojmenování. Tyto hodnoty odkazují na stejné sloty barev motivu a mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Neexistuje žádná dynamická konverze mezi `Text`/`Background` a `Dark`/`Light`. Jedná se pouze o alternativní názvy pro stejné barvy motivu.

Tento rozdíl v pojmenování pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější UI verze zobrazují stejné sloty jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma motivu**

Aby bylo možné vybírat písma pro motivy a další účely, Aspose.Slides používá tyto speciální identifikátory (podobné těm používaným v PowerPointu):

* **+mn-lt** – Tělesné písmo Latin (Minor Latin Font)
* **+mj-lt** – Nadpisové písmo Latin (Major Latin Font)
* **+mn-ea** – Tělesné písmo East Asian (Minor East Asian Font)
* **+mj-ea** – Tělesné písmo East Asian (Major East Asian Font)

Tento Java kód ukazuje, jak přiřadit písmo Latin k prvku motivu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

Tento Java kód ukazuje, jak změnit písmo motivu prezentace:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

Písmo ve všech textových polích bude aktualizováno.

{{% alert color="info" title="TIP" %}} 
Možná budete chtít zobrazit [písma PowerPoint](/slides/cs/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí motivu**

Ve výchozím nastavení aplikace PowerPoint poskytuje 12 předdefinovaných pozadí, ale pouze 3 z těchto 12 pozadí jsou uložena v typické prezentaci. 

![todo:image_alt_text](presentation-design_8.png)

Například po uložení prezentace v aplikaci PowerPoint můžete spustit tento Java kód a zjistit počet předdefinovaných pozadí v prezentaci:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
Pomocí vlastnosti [BackgroundFillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme) můžete přidat nebo získat styl pozadí v motivu PowerPoint.
{{% /alert %}} 

Tento Java kód ukazuje, jak nastavit pozadí pro prezentaci:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Průvodce indexem**: 0 slouží pro žádné vyplnění. Index začíná od 1.

{{% alert color="info" title="TIP" %}} 
Možná budete chtít zobrazit [Pozadí PowerPoint](/slides/cs/androidjava/presentation-background/).
{{% /alert %}}

## **Změna efektu motivu**

Motiv PowerPointu obvykle obsahuje 3 hodnoty pro každé pole stylu. Tato pole jsou kombinována do 3 efektů: jemný, střední a intenzivní. Například toto je výsledek, když jsou efekty použity na konkrétní tvar:

![todo:image_alt_text](presentation-design_10.png)

Pomocí 3 vlastností ([FillStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FormatScheme) můžete měnit prvky v motivu (ještě pružněji než možnosti v PowerPointu).

Tento Java kód ukazuje, jak změnit efekt motivu úpravou částí prvků:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Výsledné změny v barvě výplně, typu výplně, stínovém efektu atd.:

![todo:image_alt_text](presentation-design_11.png)

## **Často kladené otázky**

### Mohu použít motiv na jediný snímek bez změny masteru?

Ano. Aspose.Slides podporuje přepsání motivu na úrovni snímku, takže můžete použít místní motiv jen na tento snímek a zároveň zachovat hlavní motiv nedotčený (pomocí [SlideThemeManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidethememanager/)).

### Jaký je nejbezpečnější způsob přenést motiv z jedné prezentace do druhé?

[Klonovat snímky](/slides/cs/androidjava/clone-slides/) společně s jejich masterem do cílové prezentace. Tím se zachová původní master, rozvržení a související motiv, takže vzhled zůstane konzistentní.

### Jak mohu zobrazit „efektivní“ hodnoty po veškerém dědictví a přepsání?

Použijte v API zobrazení ["efektivní" pohledy](/slides/cs/androidjava/shape-effective-properties/) pro motiv/barvu/písmo/efekt. Tyto vracejí vyřešené, konečné vlastnosti po aplikaci masteru a případných lokálních přepsání.