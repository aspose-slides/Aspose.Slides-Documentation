---
title: Přidání snímků do prezentací v .NET
linktitle: Přidat snímek
type: docs
weight: 10
url: /cs/net/add-slide-to-presentation/
keywords:
- přidat snímek
- vytvořit snímek
- prázdný snímek
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Jednoduše přidávejte snímky do svých PowerPoint a OpenDocument prezentací pomocí Aspose.Slides pro .NET—plynulé, efektivní vkládání snímků během několika sekund."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat snímky do prezentací PowerPoint. Prezentace obsahuje snímky Master/Layout a běžné snímky a běžné snímky jsou uspořádány podle indexu začínajícího od nuly. Každý snímek má jedinečné ID a soubory prezentací bez snímků nejsou podporovány.

Tento článek vysvětluje, jak vytvořit objekt `Presentation`, přistupovat k jeho kolekci snímků, přidat prázdný snímek, pracovat s nově přidaným snímkem a uložit aktualizovanou prezentaci. Také zahrnuje související body, jako je vkládání snímků na konkrétní pozici, používání rozvržení a pochopení prázdného snímku, který existuje v nově vytvořené prezentaci.

## **Přidání snímku do prezentace**
Než se budeme bavit o přidávání snímků do souborů prezentací, proberme několik faktů o snímcích. Každý soubor prezentace PowerPoint obsahuje snímek Master / Layout a další normální snímky. To znamená, že soubor prezentace obsahuje alespoň jeden nebo více snímků. Je důležité vědět, že soubory prezentací bez snímků nejsou podporovány produktem Aspose.Slides pro .NET. Každý snímek má jedinečné Id a všechny normální snímky jsou uspořádány v pořadí určeném indexem začínajícím od nuly. Aspose.Slides pro .NET umožňuje vývojářům přidávat prázdné snímky do jejich prezentace. Pro přidání prázdného snímku v prezentaci postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
- Vytvořte instanci třídy [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) nastavením reference na vlastnost Slides (kolekce objektů Slide) exposovanou objektem Presentation.
- Přidejte prázdný snímek do prezentace na konec kolekce obsahových snímků voláním metod AddEmptySlide exposovaných objektem ISlideCollection.
- Proveďte nějakou práci s nově přidaným prázdným snímkem.
- Nakonec zapište soubor prezentace pomocí objektu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **Často kladené otázky**

**Mohu vložit nový snímek na konkrétní pozici, nejen na konec?**

Ano. Knihovna podporuje kolekce snímků a operace [insert](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/insertclone/) , takže můžete přidat snímek na požadovaný index, nikoli jen na konec.

**Zůstávají motivy/styly zachovány při přidávání snímku na základě rozvržení?**

Ano. Rozvržení dědí formátování ze svého masteru a nový snímek dědí od vybraného rozvržení a jeho přidruženého masteru.

**Který snímek je přítomen v nové „prázdné“ prezentaci před přidáním snímků?**

Nově vytvořená prezentace již obsahuje jeden prázdný snímek s indexem nula. To je důležité vzít v úvahu při výpočtu indexů vkládání.

**Jak si vybrat „správné“ rozvržení pro nový snímek, pokud má master mnoho možností?**

Obecně zvolte [LayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutslide/), který odpovídá požadované struktuře ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/cs/net/aspose.slides/slidelayouttype/)). Pokud takové rozvržení chybí, můžete jej [přidat do masteru](/slides/cs/net/slide-layout/) a poté jej použít.