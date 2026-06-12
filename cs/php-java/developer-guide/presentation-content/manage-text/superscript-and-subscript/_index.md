---
title: Spravovat horní a dolní index v prezentacích pomocí PHP
linktitle: Horní a dolní index
type: docs
weight: 80
url: /cs/php-java/superscript-and-subscript/
keywords:
- horní index
- dolní index
- přidat horní index
- přidat dolní index
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Ovládněte horní a dolní index v Aspose.Slides pro PHP pomocí Javy a vylepšete své prezentace profesionálním formátováním textu pro maximální dopad."
---
## **Přehled**

Aspose.Slides poskytuje funkce pro integraci textu s horním a dolním indexem do vašich prezentací PowerPoint (PPT, PPTX) a OpenDocument (ODP). Ať už potřebujete zvýraznit chemické vzorce, matematické rovnice nebo doplnit obsah o poznámky pod čarou, tyto speciální možnosti formátování pomáhají zachovat srozumitelnost a přesnost. V tomto článku se naučíte, jak hladce použít styly horního a dolního indexu a zajistit profesionální výsledek na každém snímku.

## **Správa textu s horním a dolním indexem**
Text s horním a dolním indexem můžete přidat do libovolné části odstavce. Pro přidání horního nebo dolního indexu v textovém rámci Aspose.Slides je třeba použít metodu [**setEscapement**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setEscapement) třídy [PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PortionFormat).

Tato vlastnost vrací nebo nastavuje text s horním nebo dolním indexem (hodnota od -100 % (dolní index) do 100 % (horní index)). Například:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) typu [Rectangle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ShapeType#Rectangle) na snímek.
- Přistupte k [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) přidruženému k [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
- Vyprázdněte existující odstavce.
- Vytvořte nový objekt odstavce pro uchování textu s horním indexem a přidejte jej do kolekce [IParagraphs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/#getParagraphs) [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/).
- Vytvořte nový objekt části.
- Nastavte vlastnost Escapement pro část na hodnotu od 0 do 100 pro přidání horního indexu. (0 znamená žádný horní index)
- Nastavte text pro [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Portion) a poté jej přidejte do kolekce částí odstavce.
- Vytvořte nový objekt odstavce pro uchování textu s dolním indexem a přidejte jej do kolekce IParagraphs ITextFrame.
- Vytvořte nový objekt části.
- Nastavte vlastnost Escapement pro část na hodnotu od 0 do -100 pro přidání dolního indexu. (0 znamená žádný dolní index)
- Nastavte text pro [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Portion) a poté jej přidejte do kolekce částí odstavce.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je uvedena níže.

```php
  # Vytvořte instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získat snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Vytvořit textové pole
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Vytvořit odstavec pro text s horním indexem
    $superPar = new Paragraph();
    # Vytvořit část s běžným textem
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Vytvořit část s textem v horním indexu
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Vytvořit odstavec pro text s dolním indexem
    $paragraph2 = new Paragraph();
    # Vytvořit část s běžným textem
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Vytvořit část s textem v dolním indexu
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Přidat odstavce do textového pole
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Zůstane horní a dolní index zachován při exportu do PDF nebo jiných formátů?**

Ano, Aspose.Slides správně zachovává formátování horního a dolního indexu při exportu prezentací do PDF, PPT/PPTX, obrázků a dalších podporovaných formátů. Speciální formátování zůstává nedotčeno ve všech výstupních souborech.

**Lze kombinovat horní a dolní index s dalšími styly formátování, jako je tučné nebo kurzíva?**

Ano, Aspose.Slides umožňuje kombinovat různé styly textu v jedné části. Můžete povolit tučný, kurzíva, podtržení a současně použít horní nebo dolní index nastavením příslušných vlastností v [PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/).

**Funguje formátování horního a dolního indexu pro text uvnitř tabulek, grafů nebo SmartArt?**

Ano, Aspose.Slides podporuje formátování ve většině objektů, včetně tabulek a prvků grafů. Při práci se SmartArt musíte získat přístup k odpovídajícím elementům (například [SmartArtNode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartartnode/)) a jejich textovým kontejnerům a poté nakonfigurovat vlastnosti [PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/) obdobně.