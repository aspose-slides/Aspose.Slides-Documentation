---
title: Přidání snímků do prezentací v JavaScriptu
linktitle: Přidat snímek
type: docs
weight: 10
url: /cs/nodejs-java/add-slide-to-presentation/
keywords:
- přidat snímek
- vytvořit snímek
- prázdný snímek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše přidejte snímky do svých PowerPoint a OpenDocument prezentací pomocí Aspose.Slides pro Node.js přes Java — plynulé a efektivní vkládání snímků během několika sekund."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat snímky do prezentací PowerPoint. Prezentace obsahuje snímky Master/Layout a normální snímky a normální snímky jsou uspořádány pomocí nulového indexu. Každý snímek má jedinečné ID a soubory prezentací bez snímků nejsou podporovány.

Tento článek vysvětluje, jak vytvořit objekt `Presentation`, získat jeho kolekci snímků, přidat prázdný snímek, pracovat s nově přidaným snímkem a uložit aktualizovanou prezentaci. Také pokrývá související témata, jako je vkládání snímků na konkrétní pozici, používání rozvržení a pochopení prázdného snímku, který existuje v nově vytvořené prezentaci.

## **Přidání snímku do prezentace**

Než se zaměříme na přidávání snímků do souborů prezentací, proberme několik faktů o snímcích. Každý soubor prezentace PowerPoint obsahuje **Master / Layout** snímek a další **Normální** snímky. To znamená, že soubor prezentace obsahuje alespoň jeden snímek. Je důležité vědět, že soubory prezentací bez snímků nejsou podporovány Aspose.Slides for Node.js via Java. Každý snímek má jedinečné Id a všechny Normální snímky jsou uspořádány v pořadí určeném nulovým indexem.

Aspose.Slides for Node.js via Java umožňuje vývojářům přidávat prázdné snímky do své prezentace. Chcete‑li přidat prázdný snímek do prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
- Instanciujte třídu [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection) nastavením odkazu na vlastnost [Slides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) (kolekce objektů Slide) vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
- Přidejte prázdný snímek do prezentace na konec kolekce obsahových snímků voláním metod [**addEmptySlide**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) vystavených objektem [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection).
- Proveďte potřebné operace s nově přidaným prázdným snímkem.
- Nakonec zapište soubor prezentace pomocí objektu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).

```javascript
// Instancování třídy Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation();
try {
    // Instancování třídy SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Přidání prázdného snímku do kolekce Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Proveďte nějakou práci s nově přidaným snímkem
    // Uložte soubor PPTX na disk
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Mohu vložit nový snímek na konkrétní pozici, ne jen na konec?**

Ano. Knihovna podporuje kolekce snímků a operace [insert](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/insertclone/), takže můžete přidat snímek na požadovaný index místo pouze na konec.

**Zachovají se motivy a styly při přidání snímku založeného na rozvržení?**

Ano. Rozvržení dědí formátování ze svého masteru a nový snímek dědí formátování z vybraného rozvržení a jeho souvisejícího masteru.

**Jaký snímek je obsažen v nově vytvořené „prázdné“ prezentaci před přidáním snímků?**

Nově vytvořená prezentace již obsahuje jeden prázdný snímek s indexem nula. To je důležité vzít v úvahu při výpočtu indexů vkládání.

**Jak si vybrat „správné“ rozvržení pro nový snímek, pokud má master mnoho možností?**

Obvykle vyberte [LayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/), který odpovídá požadované struktuře ([Title and Content, Two Content, atd.](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidelayouttype/)). Pokud takové rozvržení chybí, můžete ho [add it to the master](/slides/cs/nodejs-java/slide-layout/) a poté jej použít.