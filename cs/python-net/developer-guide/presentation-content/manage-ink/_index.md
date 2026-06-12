---
title: Správa ink objektů v prezentacích s Pythonem
linktitle: Správa Ink
type: docs
weight: 95
url: /cs/python-net/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- správa ink
- kreslení ink
- kreslení
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Spravujte ink objekty v PowerPointu - vytvářejte, upravujte a stylizujte digitální ink pomocí Aspose.Slides pro Python v .NET. Získejte ukázkové kódy pro stopy, barvu a velikost štětce."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která umožňuje kreslit nestandardní tvary, jež lze použít k zvýraznění jiných objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku.

Aspose.Slides poskytuje [aspose.slides.ink](https://reference.aspose.com/slides/cs/python-net/aspose.slides.ink/) jmenný prostor, který obsahuje typy potřebné k vytváření a správě ink objektů.

## **Rozdíly mezi běžnými objekty a ink objekty**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. Objekt tvaru v nejjednodušší podobě představuje kontejner, který definuje oblast samotného objektu (jeho rámec) spolu s jeho vlastnostmi. Poslední zahrnují velikost oblasti kontejneru, tvar kontejneru, pozadí kontejneru atd. Pro informace viz [Shape Layout Format](https://docs.aspose.com/slides/cs/python-net/shape-manipulations/#access-layout-formats-for-shape).

Nicméně když PowerPoint pracuje s ink objektem, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními hodnotami `width` a `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Stopy**

Stopa je základní prvek nebo standard používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopy jsou záznamy popisující sekvence propojených bodů.

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkovacího bodu. Když jsou všechny propojené body vykresleny, vznikne obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## Vlastnosti štětce pro kreslení

Pro kreslení čar spojujících body elementů stopy můžete použít štětec. Štětec má svou vlastní barvu a velikost, odpovídající vlastnostem `Brush.color` a `Brush.size`.

### **Nastavení barvy ink štětce**

Tento Python kód ukazuje, jak nastavit barvu pro štětec:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Nastavení velikosti ink štětce**

Tento Python kód ukazuje, jak nastavit velikost pro štětec:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Obecně šířka a výška štětce nemusí součinit, takže PowerPoint nezobrazuje velikost štětce (datová část je šedá). Když se šířka a výška štětce rovnají, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku ink objektu a podíváme se na důležité rozměry:

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců — vždy předpokládá, že tloušťka čáry je nulová (viz poslední obrázek).

Proto pro určení viditelné oblasti celého ink objektu musíme zohlednit velikost štětce objektů stopy. Zde byl cílový objekt (stopa ručně psaného textu) měněn na velikost kontejneru (rámečku). Když se změní velikost kontejneru (rámečku), velikost štětce zůstává konstantní a naopak.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vykazuje stejné chování při práci s texty:

![ink_powerpoint6](ink_powerpoint6.png)

**Další čtení**

* Pro obecné informace o tvarech viz sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/python-net/powerpoint-shapes/). 
* Pro více informací o efektivních hodnotách viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/python-net/shape-effective-properties/#get-effective-font-height-value).