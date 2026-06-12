---
title: Správa sekcí snímků v prezentacích pomocí JavaScriptu
linktitle: Sekce snímků
type: docs
weight: 90
url: /cs/nodejs-java/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjednodušte sekce snímků v PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js — rozdělujte, přejmenovávejte a přeskupujte pro optimalizaci pracovních postupů PPTX a ODP."
---
## **Úvod**

S Aspose.Slides pro Node.js přes Java můžete uspořádat prezentaci PowerPoint do sekcí. Můžete vytvářet sekce, které obsahují konkrétní snímky.

Můžete chtít vytvářet sekce a používat je k organizaci nebo rozdělení snímků v prezentaci do logických částí v těchto situacích:

- Když pracujete na velké prezentaci s dalšími lidmi nebo týmem — a potřebujete přiřadit určité snímky kolegovi nebo některým členům týmu. 
- Když máte prezentaci s mnoha snímky — a potýkáte se s obtížemi při správě nebo úpravě jejího obsahu najednou.

Ideální je vytvořit sekci, která obsahuje podobné snímky — snímky mají něco společného nebo mohou existovat ve skupině podle pravidla — a přiřadit sekci název, který popisuje snímky uvnitř ní. 

## **Vytváření sekcí v prezentacích**

Chcete‑li přidat sekci, která bude obsahovat snímky v prezentaci, poskytuje Aspose.Slides pro Node.js přes Java metodu [addSection()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) , která vám umožní zadat název sekce, kterou chcete vytvořit, a snímek, od kterého sekce začíná.

Tento ukázkový kód vám ukáže, jak vytvořit sekci v prezentaci v JavaScriptu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 bude ukončena u newSlide2 a po ní začne section2
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Změna názvů sekcí**

Po vytvoření sekce v prezentaci PowerPoint můžete rozhodnout o změně jejího názvu. 

Tento ukázkový kód vám ukáže, jak změnit název sekce v prezentaci v JavaScriptu pomocí Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Zachovají se sekce při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže při ukládání do .ppt se seskupení sekcí ztratí.

**Lze celou sekci „skrýt“?**

Ne. Lze skrýt pouze jednotlivé snímky. Sekce jako celek nemá stav „skrytá“.

**Mohu rychle najít sekci podle snímku a naopak první snímek sekce?**

Ano. Sekce je jednoznačně definována svým úvodním snímkem; pokud znáte snímek, můžete určit, do které sekce patří, a pro sekci můžete získat její první snímek.