---
title: Správa motivů prezentací v Javě
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/java/presentation-theme/
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
- Java
- Aspose.Slides
description: "Spravujte motivy prezentací v Aspose.Slides pro Javu pro vytváření, přizpůsobování a konverzi souborů PowerPoint s jednotnou vizuální identitou."
---
## **Úvod**

Prezentační motiv určuje vlastnosti návrhových prvků. Když vyberete prezentační motiv, v podstatě volíte konkrétní sadu vizuálních prvků a jejich vlastností.

V PowerPointu motiv zahrnuje barvy, [fonts](/slides/cs/java/powerpoint-fonts/), [background styles](/slides/cs/java/presentation-background/) a efekty.

![složky motivu](theme-constituents.png)

## **Změna barvy motivu**

Motiv PowerPointu používá konkrétní sadu barev pro různé prvky na snímku. Pokud se vám barvy nelíbí, můžete je změnit použitím nových barev pro motiv. Pro výběr nové barvy motivu poskytuje Aspose.Slides hodnoty ze výčtu [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SchemeColor).

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

Efektivní hodnotu výsledné barvy můžete zjistit takto:

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

Pro další demonstraci operace změny barvy vytvoříme další prvek a přiřadíme mu akcentní barvu (z počáteční operace). Pak změníme barvu v motivu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

Nová barva se automaticky použije na oba prvky.

### **Nastavení barvy motivu z další palety**

Když na hlavní barvu motivu (1) použijete transformace jasu, vytvoří se barvy z další palety (2). Tyto barvy motivu můžete následně nastavit a získat.

![další barvy palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu  

**2** – Barvy z další palety.

Tento Java kód ukazuje operaci, při které jsou barvy další palety získány z hlavní barvy motivu a poté použity ve tvarech:

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

Při práci s [SchemeColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/schemecolor/) můžete zaznamenat, že obsahuje následující hodnoty barvy motivu:

`Background1`, `Background2`, `Text1` a `Text2`.

Nicméně `Presentation.getMasterTheme().getColorScheme()` vrací [IColorScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icolorscheme/), který poskytuje odpovídající barvy jako:

`Dark1`, `Dark2`, `Light1` a `Light2`.

Tento rozdíl je jen v pojmenování. Hodnoty odkazují na stejné sloty motivu a mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Mezi `Text`/`Background` a `Dark`/`Light` neexistuje dynamická konverze. Jedná se jen o alternativní názvy stejných barev motivu.

Toto pojmenování pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější UI verze zobrazují stejné sloty jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma motivu**

Pro výběr písem pro motivy a další účely používá Aspose.Slides tyto speciální identifikátory (podobně jako v PowerPointu):

* **+mn-lt** – Tělo písma Latin (Minor Latin Font)
* **+mj-lt** – Nadpis písma Latin (Major Latin Font)
* **+mn-ea** – Tělo písma Východní Asie (Minor East Asian Font)
* **+mj-ea** – Tělo písma Východní Asie (Major East Asian Font)

Tento Java kód ukazuje, jak přiřadit latinské písmo k prvku motivu:

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
Možná budete chtít zobrazit [PowerPoint fonts](/slides/cs/java/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí motivu**

Ve výchozím nastavení aplikace PowerPoint poskytuje 12 předdefinovaných pozadí, ale v typické prezentaci jsou uložena jen 3 z těchto 12 pozadí.

![prezentace‑design_8](presentation-design_8.png)

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
Pomocí vlastnosti [BackgroundFillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme) můžete přidat nebo získat styl pozadí v motivu PowerPointu.
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

**Průvodce indexem**: 0 značí žádné vyplnění. Index začíná od 1.

{{% alert color="info" title="TIP" %}} 
Možná budete chtít zobrazit [PowerPoint Background](/slides/cs/java/presentation-background/).
{{% /alert %}}

## **Změna efektu motivu**

Motiv PowerPointu obvykle obsahuje 3 hodnoty pro každé pole stylu. Tato pole jsou kombinována do 3 efektů: jemný, střední a intenzivní. Například takto vypadá výsledek, když jsou efekty aplikovány na konkrétní tvar:

![prezentace‑design_10](presentation-design_10.png)

Použitím 3 vlastností ([FillStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme#getEffectStyles--)) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FormatScheme) můžete měnit prvky v motivu (dokonce flexibilněji než možnosti v PowerPointu).

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

Výsledné změny ve výplňové barvě, typu výplně, stínu atd.:

![prezentace‑design_11](presentation-design_11.png)

## **Často kladené otázky**

### Mohu aplikovat motiv na jeden snímek bez změny masteru?

Ano. Aspose.Slides podporuje přepsání motivu na úrovni snímku, takže můžete na konkrétní snímek použít místní motiv a přitom zachovat master motiv (prostřednictvím [SlideThemeManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidethememanager/)).

### Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?

[Clone slides](/slides/cs/java/clone-slides/) spolu s jejich masterem do cílové prezentace. Tím se zachová původní master, rozvržení a související motiv, takže vzhled zůstane konzistentní.

### Jak mohu zobrazit „efektivní“ hodnoty po veškerém dědění a přepsání?

Použijte API „effective“ zobrazení (/slides/cs/java/shape-effective-properties/) pro motiv/barvu/písmo/efekt. Tato zobrazení vrací rozebrané finální vlastnosti po aplikaci masteru a všech místních přepsání.