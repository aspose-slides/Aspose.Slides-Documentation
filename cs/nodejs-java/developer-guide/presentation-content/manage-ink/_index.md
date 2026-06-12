---
title: Správa ink objektů v prezentaci v JavaScriptu
linktitle: Správa ink
type: docs
weight: 95
url: /cs/nodejs-java/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- správa ink
- kreslení ink
- kreslení
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte ink objekty v PowerPointu — vytvářejte, upravujte a stylizujte digitální ink pomocí Aspose.Slides pro Node.js. Získejte ukázky kódu v JavaScriptu pro stopy, barvu a velikost štětce."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která vám umožňuje kreslit nestandardní tvary, jež lze použít k zvýraznění dalších objektů, zobrazení propojení a procesů a upoutání pozornosti na konkrétní položky na snímku.

Aspose.Slides poskytuje všechny typy Ink (např. třídu [Ink](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ink/)), které potřebujete k vytvoření a správě ink objektů.

## **Rozdíly mezi běžnými objekty a objekty Ink**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. Objekt tvaru je v nejjednodušší podobě kontejner, který definuje oblast samotného objektu (jeho rámec) spolu s jeho vlastnostmi. Patří sem velikost oblasti kontejneru, tvar kontejneru, pozadí kontejneru atd. Další informace najdete v [Shape Layout Format](https://docs.aspose.com/slides/cs/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Při práci s ink objektem však PowerPoint ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními hodnotami `width` a `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Stopy**

Stopa je základní prvek nebo standard používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopy jsou záznamy popisující sekvence spojených bodů.

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkovacího bodu. Když jsou všechny spojené body vykresleny, vytvoří obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## Vlastnosti štětce pro kreslení

Můžete použít štětec k nakreslení čar spojujících body prvků stopy. Štětec má vlastní barvu a velikost, odpovídající metodám `Brush.setColor` a `Brush.setSize`.

### **Nastavení barvy štětce Ink**

Tento JavaScriptový kód ukazuje, jak nastavit barvu pro štětec:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Nastavení velikosti štětce Ink**

Tento JavaScriptový kód ukazuje, jak nastavit velikost pro štětec:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Obecně šířka a výška štětce neodpovídají, takže PowerPoint nezobrazuje velikost štětce (sekce dat je šedá). Když se šířka a výška štětce shodují, PowerPoint zobrazuje jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku ink objektu a podíváme se na důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců – vždy předpokládá, že síla čáry je nula (viz poslední obrázek).

Proto musíme při určování viditelné oblasti celého ink objektu zohlednit velikost štětce stopových objektů. Zde byl cílový objekt (stopový objekt ručně psaného textu) přizpůsoben velikosti kontejneru (rámce). Když se velikost kontejneru (rámce) změní, velikost štětce zůstane konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vykazuje stejné chování při práci s texty:

![ink_powerpoint6](ink_powerpoint6.png)

**Další čtení**

* Pro obecné informace o tvarech si přečtěte sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/nodejs-java/powerpoint-shapes/).
* Pro více informací o efektivních hodnotách viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).