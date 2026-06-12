---
title: Správa sekcí snímků v prezentacích pomocí PHP
linktitle: Sekce snímků
type: docs
weight: 90
url: /cs/php-java/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Zefektivněte spravování sekcí snímků v PowerPointu a OpenDocument pomocí Aspose.Slides pro PHP via Java — rozdělte, přejmenujte a přeřaďte pro optimalizaci pracovních postupů PPTX a ODP."
---
## **Úvod**

S Aspose.Slides for PHP via Java můžete organizovat prezentaci PowerPoint do sekcí. Můžete vytvářet sekce, které obsahují konkrétní snímky.

Můžete chtít vytvořit sekce a použít je k organizaci nebo rozdělení snímků v prezentaci na logické části v těchto situacích:

- Když pracujete na velké prezentaci s dalšími lidmi nebo týmem – a potřebujete přiřadit určité snímky kolegovi nebo některým členům týmu. 
- Když máte prezentaci, která obsahuje mnoho snímků – a máte potíže spravovat nebo upravovat její obsah najednou.

Ideálně byste měli vytvořit sekci, která obsahuje podobné snímky – snímky mají něco společného nebo mohou existovat ve skupině podle pravidla – a dát sekci název, který popisuje snímky uvnitř ní. 

## **Vytváření sekcí v prezentacích**

Pro přidání sekce, která bude obsahovat snímky v prezentaci, poskytuje Aspose.Slides for PHP via Java metodu [addSection()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sectioncollection/#addSection), která vám umožní zadat název sekce, kterou chcete vytvořit, a snímek, od kterého sekce začíná.

Tento ukázkový kód vám ukazuje, jak vytvořit sekci v prezentaci :

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// section1 bude ukončena na newSlide2 a po ní začne section2

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Změna názvů sekcí**

Po vytvoření sekce v prezentaci PowerPoint můžete rozhodnout se změnit její název. 

Tento ukázkový kód vám ukazuje, jak změnit název sekce v prezentaci pomocí Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jsou sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí je při ukládání do .ppt ztraceno.

**Lze celou sekci „skrýt“?**

Ne. Lze skrýt pouze jednotlivé snímky. Sekce jako entita nemá stav „skrytá“.

**Mohu rychle najít sekci podle snímku a naopak první snímek sekce?**

Ano. Sekce je jednoznačně určena svým počátečním snímkem; pokud máte snímek, můžete určit, do které sekce patří, a pro sekci můžete získat její první snímek.