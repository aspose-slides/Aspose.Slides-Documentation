---
title: Správa ink objektů v prezentaci v Javě
linktitle: Správa Ink
type: docs
weight: 95
url: /cs/java/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- správa ink
- kreslení ink
- kreslení
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Spravujte ink objekty PowerPoint — vytvářejte, upravujte a stylizujte digitální ink pomocí Aspose.Slides pro Java. Získejte ukázky kódu pro stopy, barvu a velikost štětce."
---
## **Úvod**

PowerPoint poskytuje ink funkci, která vám umožňuje kreslit nestandardní tvary, jež lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku. 

Aspose.Slides poskytuje všechny typy Ink (např. [Ink](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ink/) třída), které potřebujete k vytvoření a správě ink objektů. 

## **Rozdíly mezi běžnými objekty a objekty Ink**

Objekty na snímku PowerPointu jsou obvykle reprezentovány objekty tvaru. Objekt tvaru je ve své nejjednodušší formě kontejner, který definuje oblast samotného objektu (jeho rámeček) spolu s jeho vlastnostmi. Poslední zahrnují velikost oblasti kontejneru, tvar kontejneru, pozadí kontejneru atd. Pro další informace viz [Shape Layout Format](https://docs.aspose.com/slides/cs/java/shape-manipulations/#access-layout-formats-for-shape).

Když však PowerPoint pracuje s ink objektem, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními hodnotami `width` a `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape stopy**

Stopa je základní prvek nebo standard používaný k zaznamenání trajektorie pera, když uživatel zapisuje digitální ink. Stopy jsou záznamy popisující sekvence spojených bodů. 

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkovacího bodu. Když jsou všechny spojené body vykresleny, vytvoří se obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Můžete použít štětec k nakreslení čar spojujících body prvků stopy. Štětec má vlastní barvu a velikost, odpovídající vlastnostem `Brush.Color` a `Brush.Size`. 

### **Nastavit barvu štětce Ink**

Tento Java kód ukazuje, jak nastavit barvu pro štětec:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Nastavit velikost štětce Ink** 

Tento Java kód ukazuje, jak nastavit velikost pro štětec:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

Obecně šířka a výška štětce nejsou shodné, takže PowerPoint nezobrazuje velikost štětce (sekce dat je šedá). Když jsou šířka a výška štětce shodné, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku ink objektu a podíváme se na důležité rozměry: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nezohledňuje velikost štětců – vždy předpokládá, že tloušťka čáry je nulová (viz poslední obrázek). 

Proto musíme pro určení viditelné oblasti celého ink objektu zohlednit velikost štětce objektů stopy. Zde byl cílový objekt (objekt stopy ručně psaného textu) změněn na velikost kontejneru (rámce). Když se změní velikost kontejneru (rámce), velikost štětce zůstává konstantní a naopak. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vykazuje stejné chování při práci s texty:

![ink_powerpoint6](ink_powerpoint6.png)

**Další čtení**

* Pro obecné informace o tvarech si přečtěte sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/java/powerpoint-shapes/). 
* Další informace o efektivních hodnotách najdete v [Shape Effective Properties](https://docs.aspose.com/slides/cs/java/shape-effective-properties/#getting-effective-font-height-value).