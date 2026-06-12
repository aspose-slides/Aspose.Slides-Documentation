---
title: Přidání snímků do prezentací na Androidu
linktitle: Přidat snímek
type: docs
weight: 10
url: /cs/androidjava/add-slide-to-presentation/
keywords:
- přidat snímek
- vytvořit snímek
- prázdný snímek
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Snadno přidejte snímky do svých prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Android prostřednictvím Java — bezproblémové, efektivní vkládání snímků během několika sekund."
---
## **Přehled**

Aspose.Slides umožňuje programově přidávat snímky do prezentací PowerPoint. Prezentace obsahuje snímky typu master/layout a běžné snímky a běžné snímky jsou uspořádány podle nulového indexu. Každý snímek má jedinečné ID a soubory prezentací bez snímků nejsou podporovány.

Tento článek vysvětluje, jak vytvořit objekt `Presentation`, získat přístup k jeho kolekci snímků, přidat prázdný snímek, pracovat s nově přidaným snímkem a uložit aktualizovanou prezentaci. Také se zabývá souvisejícími body, jako je vkládání snímků na konkrétní pozici, používání rozvržení a pochopení prázdného snímku, který existuje v nově vytvořené prezentaci.

## **Přidání snímku do prezentace**

Než se budeme zabývat přidáváním snímků do souborů prezentací, projděme si některá fakta o snímcích. Každý soubor prezentace PowerPoint obsahuje **Master / Layout** snímek a další **Normal** snímky. To znamená, že soubor prezentace obsahuje alespoň jeden nebo více snímků. Je důležité vědět, že soubory prezentací bez snímků nejsou podporovány v Aspose.Slides pro Android prostřednictvím Java. Každý snímek má jedinečné Id a všechny Normální snímky jsou uspořádány v pořadí určeném nulovým indexem.

Aspose.Slides pro Android prostřednictvím Java umožňuje vývojářům přidávat prázdné snímky do jejich prezentace. Pro přidání prázdného snímku do prezentace postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
- Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection) nastavením odkazu na vlastnost [Slides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) (kolekce objektů Slide) vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
- Přidejte prázdný snímek do prezentace na konec kolekce obsahových snímků voláním metod [**addEmptySlide**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) vystavených objektem [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection).
- Proveďte nějakou práci s nově přidaným prázdným snímkem.
- Nakonec zapište soubor prezentace pomocí objektu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).

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

## **FAQ**

**Mohu vložit nový snímek na konkrétní pozici, ne jen na konec?**

Ano. Knihovna podporuje kolekce snímků a operace [insert](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), takže můžete přidat snímek na požadovaný index namísto pouze na konec.

**Jsou motivy/styly zachovány při přidávání snímku na základě rozvržení?**

Ano. Rozvržení dědí formátování ze svého masteru a nový snímek dědí od vybraného rozvržení a jeho přidruženého masteru.

**Který snímek je přítomen v nové "prázdné" prezentaci před přidáním snímků?**

Nově vytvořená prezentace již obsahuje jeden prázdný snímek s indexem nula. To je důležité vzít v úvahu při výpočtu indexů vkládání.

**Jak si vybrat "správné" rozvržení pro nový snímek, pokud master má mnoho možností?**

Obecně zvolte [LayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/layoutslide/), který odpovídá požadované struktuře ([Title and Content, Two Content, atd.](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidelayouttype/)). Pokud takové rozvržení chybí, můžete jej [přidat do masteru](/slides/cs/androidjava/slide-layout/) a poté jej použít.