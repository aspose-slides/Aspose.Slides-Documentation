---
title: Spravovat písma v prezentacích pomocí PHP
linktitle: Spravovat písma
type: docs
weight: 10
url: /cs/php-java/manage-fonts/
keywords:
- spravovat písma
- vlastnosti písma
- odstavec
- formátování textu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Kontrolujte písma v PHP pomocí Aspose.Slides: vkládejte, nahrazujte a načítejte vlastní písma, aby prezentace PPT, PPTX a ODP byly jasné, bezpečné pro značku a konzistentní."
---
## **Spravovat vlastnosti související s písmem**
{{% alert color="primary" %}} 

Prezentace obvykle obsahují jak text, tak obrázky. Text lze formátovat různými způsoby, buď pro zvýraznění konkrétních částí a slov, nebo aby odpovídal firemním stylům. Formátování textu pomáhá uživatelům měnit vzhled a dojem z obsahu prezentace. Tento článek ukazuje, jak pomocí Aspose.Slides pro PHP prostřednictvím Javy nastavit vlastnosti písma odstavců textu na snímcích.

{{% /alert %}} 

Pro správu vlastností písma odstavce pomocí Aspose.Slides pro PHP prostřednictvím Javy:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přistupte k tvarům [Placeholder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/placeholder/) na snímku a přetypujte je na [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Získejte [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) poskytovaného objektem [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Zarovnejte odstavec do bloku.
1. Přistupte k [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) textu [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/).
1. Definujte písmo pomocí [FontData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontdata/) a podle toho nastavte **Font** textové [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/).
   1. Nastavte písmo na tučné.
   1. Nastavte písmo na kurzívu.
1. Nastavte barvu písma pomocí [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/) poskytovaného objektem [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/).
1. Uložte upravenou prezentaci do souboru PPTX.

Implementace výše uvedených kroků je uvedena níže. Bere nepřizpůsobenou prezentaci a formátuje písma na jednom ze snímků. Následující snímky obrazovky ukazují vstupní soubor a jak jej kódové úryvky mění. Kód mění písmo, barvu a styl písma.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Obrázek: Text ve vstupním souboru**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Obrázek: Stejný text s aktualizovaným formátováním**|

```php
  # Vytvořte objekt Presentation, který představuje soubor PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Přístup k snímku pomocí jeho pozice
    $slide = $pres->getSlides()->get_Item(0);
    # Přístup k prvnímu a druhému placeholderu na snímku a přetypování na AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Přístup k prvnímu odstavci
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Zarovnat odstavec do bloku
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Přístup k prvnímu úseku
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definovat nová písma
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Přiřadit nová písma k úseku
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Nastavit písmo na tučné
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Nastavit písmo na kurzívu
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Nastavit barvu písma
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Uložit PPTX na disk
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavit vlastnosti písma textu**
{{% alert color="primary" %}} 

Jak je zmíněno v **Spravovat vlastnosti související s písmem**, se [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) používá k uchování textu se stejným stylem formátování v odstavci. Tento článek ukazuje, jak pomocí Aspose.Slides pro PHP prostřednictvím Javy vytvořit textové pole s nějakým textem a poté definovat konkrétní písmo a další vlastnosti kategorie rodiny písem.

{{% /alert %}} 

Pro vytvoření textového pole a nastavení vlastností písma textu v něm:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) typu **Rectangle**.
1. Odstraňte výplňový styl spojený s [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) objektu [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Přidejte nějaký text do [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/).
1. Přistupte k objektu [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) souvisejícímu s [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/).
1. Definujte písmo, které se použije pro [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/).
1. Nastavte další vlastnosti písma, jako tučné, kurzíva, podtržení, barva a výška, pomocí příslušných vlastností zpřístupněných objektem [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je uvedena níže.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Obrázek: Text s některými nastavenými vlastnostmi písma pomocí Aspose.Slides pro PHP prostřednictvím Javy**|

```php
  # Vytvořit objekt Presentation, který představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získat první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Přidat AutoShape typu Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Odebrat jakýkoli výplňový styl spojený s AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Přístup k TextFrame spojenému s AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Přístup k Portion spojenému s TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Nastavit písmo pro Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Nastavit vlastnost tučného písma
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Nastavit vlastnost kurzívy písma
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Nastavit vlastnost podtržení písma
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Nastavit výšku písma
    $port->getPortionFormat()->setFontHeight(25);
    # Nastavit barvu písma
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Uložit prezentaci na disk
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```