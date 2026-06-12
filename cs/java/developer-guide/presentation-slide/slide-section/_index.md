---
title: Správa sekcí snímků v prezentacích pomocí Javy
linktitle: Sekce snímku
type: docs
weight: 90
url: /cs/java/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zefektivněte sekce snímků v PowerPointu a OpenDocument pomocí Aspose.Slides pro Java — rozdělujte, přejmenujte a přeskupujte pro optimalizaci pracovních postupů PPTX a ODP."
---
## **Úvod**

S Aspose.Slides pro Java můžete organizovat prezentaci PowerPoint do sekcí. Můžete vytvářet sekce, které obsahují konkrétní snímky.  

Můžete chtít vytvořit sekce a použít je k organizaci nebo rozdělení snímků v prezentaci do logických částí v těchto situacích:

- Když pracujete na velké prezentaci s dalšími lidmi nebo týmem – a potřebujete přiřadit určité snímky kolegovi nebo některým členům týmu.  
- Když se potýkáte s prezentací, která obsahuje mnoho snímků – a máte potíže spravovat nebo upravovat její obsah najednou.  

Ideálně byste měli vytvořit sekci, která bude obsahovat podobné snímky – snímky mají něco společného nebo mohou existovat ve skupině na základě pravidla – a dát sekci název, který popisuje snímky uvnitř ní.  

## **Vytváření sekcí v prezentacích**

Chcete‑li přidat sekci, která bude obsahovat snímky v prezentaci, poskytuje Aspose.Slides pro Java metodu [addSection()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-), která vám umožní zadat název sekce, kterou chcete vytvořit, a snímek, od kterého sekce začíná.  

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
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 bude ukončena na newSlide2 a poté začne section2   

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

Po vytvoření sekce v prezentaci PowerPoint můžete rozhodnout změnit její název.  

Tento ukázkový kód vám ukazuje, jak v Javě pomocí Aspose.Slides změnit název sekce v prezentaci:

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

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí se při ukládání do .ppt ztratí.  

**Lze celou sekci "skrýt"?**

Ne. Skrýt lze pouze jednotlivé snímky. Sekce jako celek nemá stav "skrytý".  

**Mohu rychle najít sekci podle snímku a naopak první snímek sekce?**

Ano. Sekce je jednoznačně určena svým úvodním snímkem; na základě snímku můžete zjistit, do které sekce patří, a pro sekci můžete získat její první snímek.