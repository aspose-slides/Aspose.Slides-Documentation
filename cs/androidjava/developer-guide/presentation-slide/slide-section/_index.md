---
title: Správa sekcí snímků v prezentacích na Androidu
linktitle: Sekce snímků
type: docs
weight: 90
url: /cs/androidjava/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Zjednodušte sekce snímků v PowerPointu a OpenDocumentu pomocí Aspose.Slides pro Android přes Java - rozdělujte, přejmenovávejte a přeuspořádávejte pro optimalizaci pracovních postupů PPTX a ODP."
---
## **Úvod**

With Aspose.Slides for Android via Java, můžete organizovat prezentaci PowerPoint do sekcí. Můžete vytvářet sekce, které obsahují konkrétní snímky.

Můžete chtít vytvořit sekce a použít je k organizaci nebo rozdělení snímků v prezentaci do logických částí v následujících situacích:

- Když pracujete na velké prezentaci s jinými lidmi nebo týmem – a potřebujete přiřadit určité snímky kolegovi nebo některým členům týmu. 
- Když se zabýváte prezentací, která obsahuje mnoho snímků – a máte potíže spravovat nebo upravit její obsah najednou.

Ideálně byste měli vytvořit sekci, která obsahuje podobné snímky – snímky mají něco společného nebo mohou existovat ve skupině na základě pravidla – a dát sekci název, který popisuje snímky v ní. 

## **Vytvoření sekcí v prezentacích**

Chcete‑li přidat sekci, která bude obsahovat snímky v prezentaci, Aspose.Slides for Android via Java poskytuje metodu [addSection()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) , která vám umožní zadat název sekce, kterou chcete vytvořit, a snímek, od kterého sekce začíná.

Tento ukázkový kód vám ukazuje, jak vytvořit sekci v prezentaci v Javě:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 bude ukončena na newSlide2 a po ní začne section2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Změna názvů sekcí**

Po vytvoření sekce v prezentaci PowerPoint můžete rozhodnout o změně jejího názvu. 

Tento ukázkový kód vám ukazuje, jak změnit název sekce v prezentaci v Javě pomocí Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Zůstávají sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí je při ukládání do .ppt ztraceno.

**Může být celá sekce „skrytá“?**

Ne. Lze skrýt pouze jednotlivé snímky. Sekce jako entita nemá stav „skrytá“.

**Mohu rychle najít sekci podle snímku a naopak první snímek sekce?**

Ano. Sekce je jednoznačně určena svým úvodním snímkem; pokud znáte snímek, můžete určit, do které sekce patří, a u sekce můžete získat její první snímek.