---
title: Spravovat ink objekty prezentace v C++
linktitle: Spravovat ink
type: docs
weight: 95
url: /cs/cpp/manage-ink/
keywords:
- ink
- ink objekt
- ink stopa
- spravovat ink
- kreslit ink
- kreslení
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Spravujte ink objekty PowerPoint—vytvářejte, upravujte a stylizujte digitální ink pomocí Aspose.Slides pro C++. Získejte ukázkové kódy pro stopy, barvu a velikost štětce."
---
## **Úvod**

PowerPoint nabízí funkci ink, která vám umožňuje kreslit nestandardní tvary, jež lze použít k zvýraznění dalších objektů, zobrazení spojení a procesů a upoutání pozornosti na konkrétní položky na snímku. 

Aspose.Slides poskytuje rozhraní [Aspose.Slides.Ink](https://reference.aspose.com/slides/cs/cpp/aspose.slides.ink/) , které obsahuje typy potřebné k vytvoření a správě ink objektů. 

## **Rozdíly mezi běžnými objekty a ink objekty**

Objekty na snímku PowerPointu jsou typicky reprezentovány objekty tvaru. Objekt tvaru, v jeho nejjednodušší podobě, je kontejner, který definuje oblast samotného objektu (jeho rám) spolu s jeho vlastnostmi. Ty zahrnují velikost oblasti kontejneru, tvar kontejneru, pozadí kontejneru atd. Další informace najdete v [Shape Layout Format](https://docs.aspose.com/slides/cs/cpp/shape-manipulations/#access-layout-formats-for-shape).

Nicméně, když PowerPoint pracuje s ink objektem, ignoruje všechny vlastnosti rámu objektu (kontejneru) kromě jeho velikosti. Velikost oblasti kontejneru je určena standardními hodnotami `width` a `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape stopy**

Stopa je základní prvek nebo standard používaný k zaznamenání trajektorie pera, když uživatel píše digitální ink. Stopy jsou záznamy, které popisují sekvence spojených bodů. 

Nejjednodušší forma kódování určuje souřadnice X a Y každého vzorkového bodu. Když jsou všechny spojené body vykresleny, vytvoří obrázek jako tento:

![ink_powerpoint2](ink_powerpoint2.png)

## **Vlastnosti štětce pro kreslení**

Můžete použít štětec k nakreslení čar spojujících body prvků stopy. Štětec má svou vlastní barvu a velikost, odpovídající vlastnostem `Brush.Color` a `Brush.Size`. 

### **Nastavení barvy ink štětce**

Tento C++ kód ukazuje, jak nastavit barvu pro štětec:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Nastavení velikosti ink štětce**

Tento C++ kód ukazuje, jak nastavit velikost pro štětec:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

Obecně se šířka a výška štětce neshodují, takže PowerPoint nezobrazuje velikost štětce (datová sekce je šedá). Ale když se šířka a výška štětce shodují, PowerPoint zobrazí jeho velikost takto:

![ink_powerpoint3](ink_powerpoint3.png)

Pro přehlednost zvýšíme výšku ink objektu a podíváme se na důležité rozměry: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontejner (rám) nezohledňuje velikost štětců – vždy předpokládá, že tloušťka čáry je nula (viz poslední obrázek). 

Proto musíme při určování viditelné oblasti celého ink objektu vzít v úvahu velikost štětce stopových objektů. Zde byl cílový objekt (stopa ručně psaného textu) přizpůsoben velikosti kontejneru (rámu). Když se změní velikost kontejneru (rámu), velikost štětce zůstává konstantní a naopak. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint vykazuje stejné chování při práci s texty:

![ink_powerpoint6](ink_powerpoint6.png)

**Další čtení**

* Pro obecné informace o tvarech si přečtěte sekci [PowerPoint Shapes](https://docs.aspose.com/slides/cs/cpp/powerpoint-shapes/). 
* Pro více informací o efektivních hodnotách navštivte [Shape Effective Properties](https://docs.aspose.com/slides/cs/cpp/shape-effective-properties/#get-effective-font-height-value).