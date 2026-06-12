---
title: Správa prezentačních motivů v PHP
linktitle: Prezentační motiv
type: docs
weight: 10
url: /cs/php-java/presentation-theme/
keywords:
- PowerPoint motiv
- prezentační motiv
- motiv snímku
- nastavit motiv
- změnit motiv
- spravovat motiv
- barva motivu
- dodatečná paleta
- písmo motivu
- styl motivu
- efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte prezentační motivy v Aspose.Slides pro PHP přes Java a vytvářejte, přizpůsobujte a převádějte soubory PowerPoint s jednotnou značkou."
---
## **Úvod**

Prezentační motiv určuje vlastnosti návrhových prvků. Když vyberete prezentační motiv, ve skutečnosti volíte konkrétní sadu vizuálních prvků a jejich vlastnosti.

V PowerPointu motiv zahrnuje barvy, [fonts](/slides/cs/php-java/powerpoint-fonts/), [background styles](/slides/cs/php-java/presentation-background/) a efekty.

![složky-tématu](theme-constituents.png)

## **Změna barvy motivu**

Motiv PowerPointu používá konkrétní sadu barev pro různé prvky na snímku. Pokud se vám barvy nelíbí, změníte je tím, že použijete nové barvy pro motiv. Pro výběr nové barvy motivu poskytuje Aspose.Slides hodnoty v enumeraci [SchemeColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SchemeColor).

Tento PHP kód ukazuje, jak změnit akcentní barvu motivu:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Efektivní hodnotu výsledné barvy můžete určit takto:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

Abychom dále demonstrovali operaci změny barvy, vytvoříme další prvek a přiřadíme mu akcentní barvu (z předchozí operace). Pak změníme barvu v motivě:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

Nová barva se automaticky použije na oba prvky.

### **Nastavení barvy motivu z další palety**

Když na hlavní barvu motivu (1) aplikujete transformace luminance, vzniknou barvy z další palety (2). Tyto barvy motivu pak můžete nastavit i získat.

![barvy‑dodatečné‑palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu  

**2** – Barvy z dodatečné palety.

Tento PHP kód ukazuje operaci, kde jsou barvy dodatečné palety získány z hlavní barvy motivu a následně použity ve tvarech:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Akcent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Akcent 4, Světlejší 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Akcent 4, Světlejší 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Akcent 4, Světlejší 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Akcent 4, Tmavší 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Akcent 4, Tmavší 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Mapování `SchemeColor` na barvy `ColorScheme`**

Když pracujete s [SchemeColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/schemecolor/), můžete si všimnout, že obsahuje následující hodnoty motivu:

`Background1`, `Background2`, `Text1` a `Text2`.

Nicméně `Presentation::getMasterTheme()::getColorScheme()` vrací [ColorScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colorscheme/), který vystavuje odpovídající barvy jako:

`Dark1`, `Dark2`, `Light1` a `Light2`.

Tento rozdíl spočívá jen v názvech. Tyto hodnoty odkazují na stejné sloty motivu a mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Mezi `Text`/`Background` a `Dark`/`Light` neexistuje žádná dynamická konverze. Jedná se jen o alternativní názvy stejných barev motivu.

Tento rozdíl v názvosloví pochází z terminologie Microsoft Office. Starší verze Office používaly `Dark 1`, `Light 1`, `Dark 2` a `Light 2`, zatímco novější uživatelské rozhraní zobrazuje stejné sloty jako `Text 1`, `Background 1`, `Text 2` a `Background 2`.

## **Změna písma motivu**

Aby bylo možné vybírat písma pro motivy a další účely, Aspose.Slides používá tyto speciální identifikátory (podobně jako v PowerPointu):

* **+mn-lt** – Body Font Latin (Minor Latin Font)
* **+mj-lt** – Heading Font Latin (Major Latin Font)
* **+mn-ea** – Body Font East Asian (Minor East Asian Font)
* **+mj-ea** – Body Font East Asian (Major East Asian Font)

Tento PHP kód ukazuje, jak přiřadit latinské písmo k prvku motivu:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```

Tento PHP kód ukazuje, jak změnit písmo prezentačního motivu:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```

Písmo ve všech textových polích bude aktualizováno.

{{% alert color="primary" title="TIP" %}} 
Možná budete chtít zobrazit [PowerPoint fonts](/slides/cs/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Změna stylu pozadí motivu**

Ve výchozím nastavení aplikace PowerPoint poskytuje 12 předdefinovaných pozadí, ale v typické prezentaci jsou uložena jen 3 z těchto 12.

![todo:image_alt_text](presentation-design_8.png)

Například po uložení prezentace v aplikaci PowerPoint můžete spustit tento PHP kód, abyste zjistili počet předdefinovaných pozadí v prezentaci:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Pomocí vlastnosti [BackgroundFillStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FormatScheme) můžete do motivu PowerPointu přidat nebo získat styl pozadí.
{{% /alert %}} 

Tento PHP kód ukazuje, jak nastavit pozadí pro prezentaci:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Průvodce indexy**: 0 znamená žádné vyplnění. Index začíná od 1.

{{% alert color="primary" title="TIP" %}} 
Možná budete chtít zobrazit [PowerPoint Background](/slides/cs/php-java/presentation-background/).
{{% /alert %}}

## **Změna efektu motivu**

Motiv PowerPointu obvykle obsahuje 3 hodnoty pro každý stylový pole. Tyto pole jsou sloučena do 3 efektů: subtle, moderate a intense. Například takto vypadá výsledek, když jsou efekty aplikovány na konkrétní tvar:

![todo:image_alt_text](presentation-design_10.png)

Pomocí 3 vlastností ([FillStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FormatScheme#getEffectStyles--)) ze třídy [FormatScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/FormatScheme) můžete měnit prvky v motivu (ještě flexibilněji než možnosti v PowerPointu).

Tento PHP kód ukazuje, jak změnit efekt motivu úpravou částí prvků:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Výsledné změny ve výplňové barvě, typu výplně, stínu atd.:

![todo:image_alt_text](presentation-design_11.png)

## **Časté dotazy**

**Mohu aplikovat motiv na jediný snímek bez změny masteru?**

Ano. Aspose.Slides podporuje přepsání motivu na úrovni snímku, takže můžete aplikovat lokální motiv jen na tento snímek a přitom zachovat master motiv nezměněn (pomocí [SlideThemeManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidethememanager/)).

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

[Clone slides](/slides/cs/php-java/clone-slides/) spolu s jejich masterem do cílové prezentace. Tím se zachová původní master, rozvržení i přidružený motiv, takže vzhled zůstane konzistentní.

**Jak mohu zobrazit „efektivní“ hodnoty po veškerém dědění a přepsání?**

Použijte API „effective“ pohledy](/slides/cs/php-java/shape-effective-properties/) pro motiv/barvu/písmo/efekt. Tyto vrací vyřešené, finální vlastnosti po aplikaci masteru a případných lokálních přepsání.