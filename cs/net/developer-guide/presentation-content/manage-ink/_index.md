---
title: Správa ink objektů v prezentaci v .NET
linktitle: Správa ink
type: docs
weight: 95
url: /cs/net/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- správa ink
- kreslení ink
- kreslení
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte ink objekty v PowerPointu – vytvářejte, upravujte a stylizujte digitální ink pomocí Aspose.Slides pro .NET. Získejte ukázky kódu pro stopy, barvu a velikost štětce."
---
## **Úvod**

PowerPoint poskytuje funkci ink, která vám umožní kreslit nestandardní tvary, jež lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku. 

Aspose.Slides poskytuje rozhraní [Aspose.Slides.Ink](https://reference.aspose.com/slides/cs/net/aspose.slides.ink/), které obsahuje typy potřebné k vytváření a správě ink objektů. 

## **Rozdíly mezi běžnými objekty a ink objekty**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. Objekt tvaru, v nejjednodušší podobě, je kontejner, který definuje oblast samotného objektu (jeho rámec) spolu s jeho vlastnostmi. Poslední zahrnují velikost oblasti kontejneru, tvar kontejneru, pozadí kontejneru atd. Pro informace viz [Shape Layout Format](https://docs.aspose.com/slides/cs/net/shape-manipulations/#access-layout-formats-for-shape).

Nicméně, když PowerPoint pracuje s ink objektem, ignoruje všechny vlastnosti rámce objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními hodnotami `width` a `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Stopy**

Stopa je základní prvek nebo standard používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopy jsou nahrávky, které popisují sekvence propojených bodů. 

Nejjednodušší forma kódování udává souřadnice X a Y každého vzorkového bodu. Když jsou všechny propojené body vykresleny, vytvoří obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Můžete použít štětec k nakreslení čar spojujících body elementů stopy. Štětec má vlastní barvu a velikost, odpovídající vlastnostem `Brush.Color` a `Brush.Size`. 

### **Nastavit barvu ink štětce**

Tento C# kód vám ukazuje, jak nastavit barvu pro štětec:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **Nastavit velikost ink štětce** 

Tento C# kód vám ukazuje, jak nastavit velikost pro štětec:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

Obecně se šířka a výška štětce neshodují, takže PowerPoint nezobrazuje velikost štětce (datová část je šedá). Ale když se šířka a výška štětce shodují, PowerPoint zobrazuje jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku ink objektu a zkontrolujeme důležité rozměry: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rámec) nebere v úvahu velikost štětců – vždy předpokládá, že tloušťka čáry je nulová (viz poslední obrázek). 

Proto je pro určení viditelné oblasti celého ink objektu nutné zohlednit velikost štětce objektů stopy. Zde byl cílový objekt (objekt stopy ručně psaného textu) přepočítán na velikost kontejneru (rámce). Když se velikost kontejneru (rámce) změní, velikost štětce zůstane konstantní a naopak. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vykazuje stejný přístup při práci s texty:

![ink_powerpoint6](ink_powerpoint6.png)

**Další čtení**

* Pro čtení o tvarech obecně, viz sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/net/powerpoint-shapes/). 
* Pro více informací o efektivních hodnotách viz [Shape Effective Properties](https://docs.aspose.com/slides/cs/net/shape-effective-properties/#get-effective-font-height-value).