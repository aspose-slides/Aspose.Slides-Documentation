---
title: Správa ink objektů prezentace na Androidu
linktitle: Spravovat Ink
type: docs
weight: 95
url: /cs/androidjava/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- spravovat ink
- kreslit ink
- kreslení
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte ink objekty PowerPointu — vytvářejte, upravujte a stylizujte digitální ink pomocí Aspose.Slides pro Android. Získáte Java ukázky kódu pro stopy, barvu a velikost štětce."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která vám umožňuje kreslit nestandardní tvary, jež lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku. 

Aspose.Slides poskytuje všechny typy Ink (např. třída [Ink](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ink/)), které potřebujete k vytváření a správě objektů ink.

## **Rozdíly mezi běžnými objekty a objekty Ink**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. Objekt tvaru, v nejjednodušší podobě, je kontejner, který definuje oblast samotného objektu (jeho rámec) spolu s jeho vlastnostmi. To zahrnuje velikost oblasti kontejneru, tvar kontejneru, pozadí kontejneru atd. Další informace naleznete v [Shape Layout Format](https://docs.aspose.com/slides/cs/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Nicméně, když PowerPoint pracuje s objektem ink, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními hodnotami `width` a `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Stopy Inkshape**

Stopa je základní prvek nebo standard používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopy jsou záznamy, které popisují sekvence spojených bodů. 

Nejjednodušší forma kódování určuje souřadnice X a Y každého bodu vzorku. Když jsou všechny spojené body vykresleny, vytvoří obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Můžete použít štětec k nakreslení čar spojujících body prvků stopy. Štětec má vlastní barvu a velikost, odpovídající vlastnostem `Brush.Color` a `Brush.Size`.

### **Nastavení barvy štětce Ink**

Tento Java kód vám ukáže, jak nastavit barvu pro štětec:

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

### **Nastavení velikosti štětce Ink** 

Tento Java kód vám ukáže, jak nastavit velikost pro štětec:

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

Obecně šířka a výška štětce nejsou shodné, takže PowerPoint nezobrazuje velikost štětce (sekce dat je šedá). Ale když se šířka a výška štětce shodují, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku objektu ink a podíváme se na důležité rozměry: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců – vždy předpokládá, že tloušťka čáry je nula (viz poslední obrázek). 

Proto je třeba při určování viditelné oblasti celého objektu ink zohlednit velikost štětce objektů stopy. Zde byl cílový objekt (objekt stopy ručně psaného textu) škálován na velikost kontejneru (rámce). Když se změní velikost kontejneru (rámce), velikost štětce zůstává konstantní a naopak. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vykazuje stejné chování při práci s texty:

![ink_powerpoint6](ink_powerpoint6.png)

**Další informace**

* Pro obecné informace o tvarech viz sekce [PowerPoint Shapes](https://docs.aspose.com/slides/cs/androidjava/powerpoint-shapes/).
* Pro více informací o efektivních hodnotách viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/androidjava/shape-effective-properties/#getting-effective-font-height-value).