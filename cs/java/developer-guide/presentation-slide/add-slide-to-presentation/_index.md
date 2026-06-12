---
title: Přidání snímků do prezentací v Javě
linktitle: Přidat snímek
type: docs
weight: 10
url: /cs/java/add-slide-to-presentation/
keywords:
- přidat snímek
- vytvořit snímek
- prázdný snímek
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Jednoduše přidejte snímky do svých prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Java—plynulé, efektivní vkládání snímků během několika sekund."
---
## **Přehled**

Aspose.Slides umožňuje programově přidávat snímky do prezentací PowerPoint. Prezentace obsahuje snímky typu master/layout i běžné snímky a běžné snímky jsou uspořádány pomocí nulového indexu. Každý snímek má jedinečné ID a soubory prezentací bez snímků nejsou podporovány.

Tento článek vysvětluje, jak vytvořit objekt `Presentation`, získat přístup k jeho kolekci snímků, přidat prázdný snímek, pracovat s nově přidaným snímkem a uložit aktualizovanou prezentaci. Také se zabývá souvisejícími tématy, jako je vkládání snímků na konkrétní pozici, použití rozvržení a pochopení prázdného snímku, který existuje v nově vytvořené prezentaci.

## **Přidání snímku do prezentace**

Než se budeme zabývat přidáváním snímků do souborů prezentací, pojďme si probrat některé skutečnosti o snímcích. Každý soubor prezentace PowerPoint obsahuje snímek **Master / Layout** a další **Normální** snímky. To znamená, že soubor prezentace obsahuje alespoň jeden snímek. Je důležité vědět, že soubory prezentací bez snímků nejsou podporovány produktem Aspose.Slides pro Java. Každý snímek má jedinečné Id a všechny Normální snímky jsou uspořádány v pořadí určeném nulovým indexem.

Aspose.Slides pro Java umožňuje vývojářům přidávat prázdné snímky do jejich prezentace. Pro přidání prázdného snímku do prezentace postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
- Vytvořte instanci třídy [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection) nastavením odkazu na vlastnost [Slides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation#getSlides--) (kolekce objektů Slide) poskytovanou objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
- Přidejte prázdný snímek do prezentace na konec kolekce obsahových snímků voláním metody [**addEmptySlide**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) poskytované objektem [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlideCollection).
- Proveďte nějakou operaci s nově přidaným prázdným snímkem.
- Nakonec zapište soubor prezentace pomocí objektu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation();
try {
    // Vytvořte instanci třídy SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Přidejte prázdný snímek do kolekce Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Proveďte nějakou práci s nově přidaným snímkem

    // Uložte soubor PPTX na disk
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Často kladené otázky**

**Mohu vložit nový snímek na konkrétní pozici, nejen na konec?**

Ano. Knihovna podporuje kolekce snímků a operace [insert](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), takže můžete přidat snímek na požadovaný index místo pouze na konec.

**Jsou motivy/styly zachovány při přidávání snímku na základě rozvržení?**

Ano. Rozvržení dědí formátování ze svého masteru a nový snímek dědí formátování ze zvoleného rozvržení a jeho přidruženého masteru.

**Který snímek je přítomen v nové „prázdné“ prezentaci před přidáním snímků?**

Nově vytvořená prezentace již obsahuje jeden prázdný snímek s indexem nula. To je důležité vzít v úvahu při výpočtu indexů vkládání.

**Jak si vybrat „správné“ rozvržení pro nový snímek, pokud master má mnoho možností?**

Obecně vyberte [LayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/layoutslide/), který odpovídá požadované struktuře ([Title and Content, Two Content, atd.](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidelayouttype/)). Pokud takové rozvržení chybí, můžete ho [přidat jej do masteru](/slides/cs/java/slide-layout/) a poté jej použít.