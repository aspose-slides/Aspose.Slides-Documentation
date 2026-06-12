---
title: Vylepšete své prezentace pomocí AutoFit v PHP
linktitle: Nastavení Autofit
type: docs
weight: 30
url: /cs/php-java/manage-autofit-settings/
keywords:
- textové pole
- autofit
- neautofit
- přizpůsobit text
- zmenšit text
- zalamovat text
- změnit velikost tvaru
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte nastavení AutoFit v Aspose.Slides pro PHP, abyste optimalizovali zobrazení textu ve svých prezentacích PowerPoint a OpenDocument a zlepšili čitelnost obsahu."
---
## **Úvod**

Ve výchozím nastavení, když přidáte textové pole, Microsoft PowerPoint používá nastavení **Resize shape to fix text** pro textové pole – automaticky mění velikost textového pole, aby jeho text vždy do něj zapadl. 

![textové pole v PowerPointu](textbox-in-powerpoint.png)

* Když se text v textovém poli prodlouží nebo zvětší, PowerPoint automaticky zvětší textové pole – zvýší jeho výšku – aby pojmul více textu. 
* Když se text v textovém poli zkrátí nebo zmenší, PowerPoint automaticky zmenší textové pole – sníží jeho výšku – aby odstranil nadbytečný prostor. 

V PowerPointu jsou to 4 důležité parametry nebo možnosti, které řídí chování autofitu pro textové pole: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![možnosti autofitu v PowerPointu](autofit-options-powerpoint.png)

Aspose.Slides pro PHP prostřednictvím Java poskytuje podobné možnosti – některé vlastnosti ve třídě [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrameFormat) – které vám umožní ovládat chování autofitu pro textová pole v prezentacích.

## **Změna velikosti tvaru tak, aby text odpovídal**

Pokud chcete, aby text v rámečku vždy po úpravách textu zapadal do tohoto rámečku, musíte použít možnost **Resize shape to fix text**. Pro nastavení této volby nastavte vlastnost [AutofitType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrameFormat)) na `Shape`.

![nastavení vždy zapadá v PowerPointu](alwaysfit-setting-powerpoint.png)

Tento PHP kód ukazuje, jak nastavit, aby text vždy zapadal do svého rámečku v prezentaci PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Pokud se text prodlouží nebo zvětší, textové pole bude automaticky změněno (zvýší se výška), aby do něj veškerý text zapadl. Pokud se text zkrátí, nastane opačný efekt. 

## **Neaplikovat automatické přizpůsobení**

Pokud chcete, aby textové pole nebo tvar zachovalo své rozměry bez ohledu na změny textu, který obsahuje, musíte použít možnost **Do not Autofit**. Pro nastavení této volby nastavte vlastnost [AutofitType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrameFormat)) na `None`.

![nastavení nerobit autofit v PowerPointu](donotautofit-setting-powerpoint.png)

Tento PHP kód ukazuje, jak nastavit, aby textové pole v prezentaci PowerPoint vždy zachovávalo své rozměry:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Když se text stane příliš dlouhým pro svůj rámeček, přeteče. 

## **Zmenšit text při přetečení**

Pokud se text stane příliš dlouhým pro svůj rámeček, můžete pomocí možnosti **Shrink text on overflow** určit, že velikost a mezery textu musí být zmenšeny, aby se vešel do rámečku. Pro nastavení této volby nastavte vlastnost [AutofitType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrameFormat)) na `Normal`.

![nastavení zmenšení textu při přetečení v PowerPointu](shrinktextonoverflow-setting-powerpoint.png)

Tento PHP kód ukazuje, jak nastavit, aby byl text při přetečení zmenšen v prezentaci PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Když je použita možnost **Shrink text on overflow**, nastavení se aplikuje pouze v případě, že text je příliš dlouhý pro svůj rámeček. 
{{% /alert %}}

## **Zalamovat text**

Pokud chcete, aby se text v tvaru zalamoval uvnitř tohoto tvaru, když přesáhne hranici tvaru (pouze šířka), musíte použít parametr **Wrap text in shape**. Pro nastavení této volby je třeba nastavit vlastnost [WrapText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrameFormat#getWrapText--) (třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/TextFrameFormat)) na `true`.

Tento PHP kód ukazuje, jak použít nastavení Wrap Text v prezentaci PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Pokud nastavíte vlastnost `WrapText` na `False` pro tvar, když text uvnitř tvaru přesáhne šířku tvaru, text se rozšíří za hranice tvaru v jedné řadě. 
{{% /alert %}}

## **Často kladené otázky**

**Ovlivňují vnitřní okraje textového rámce AutoFit?**

Ano. Vnitřní okraje (padding) snižují použitelné místo pro text, takže AutoFit se aktivuje dříve – font se zmenší nebo se dříve změní velikost tvaru. Zkontrolujte a upravte okraje před laděním AutoFit.

**Jak AutoFit spolupracuje s manuálními a měkkými konci řádků?**

Vynucené konce řádků zůstávají na místě a AutoFit upravuje velikost písma a mezery kolem nich. Odstranění zbytečných konců řádků často snižuje agresivitu, s jakou AutoFit musí text zmenšovat.

**Mění změna písma motivu nebo spuštění náhrady písma výsledky AutoFit?**

Ano. Nahrazení písma fontem s odlišnými metrikami glyfů mění šířku/výšku textu, což může ovlivnit konečnou velikost písma a zalamování řádků. Po jakékoli změně nebo nahrazení písma je potřeba prezentace znovu zkontrolovat.