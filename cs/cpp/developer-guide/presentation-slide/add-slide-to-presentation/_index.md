---
title: Přidání snímků do prezentací v C++
linktitle: Přidat snímek
type: docs
weight: 10
url: /cs/cpp/add-slide-to-presentation/
keywords:
- přidat snímek
- vytvořit snímek
- prázdný snímek
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Jednoduše přidávejte snímky do svých prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro C++ — bezproblémové a efektivní vkládání snímků během několika sekund."
---
## **Přehled**

Aspose.Slides umožňuje programově přidávat snímky do prezentací PowerPoint. Prezentace obsahuje hlavní/rozložení snímky a běžné snímky a běžné snímky jsou uspořádány podle nulově indexovaného pořadí. Každý snímek má jedinečné ID a soubory prezentací bez snímků nejsou podporovány.

Tento článek vysvětluje, jak vytvořit objekt `Presentation`, získat jeho kolekci snímků, přidat prázdný snímek, pracovat s nově přidaným snímkem a uložit aktualizovanou prezentaci. Také se zabývá souvisejícími body, jako je vkládání snímků na konkrétní pozici, používání rozložení a pochopení prázdného snímku, který existuje v nově vytvořené prezentaci.

## **Přidání snímku do prezentace**
Než se budeme bavit o přidávání snímků do souborů prezentací, projďme si některá fakta o snímcích. Každý soubor prezentace PowerPoint obsahuje hlavní/rozložení snímek a další běžné snímky. To znamená, že soubor prezentace obsahuje alespoň jeden nebo více snímků. Je důležité vědět, že soubory prezentací bez snímků nejsou podporovány Aspose.Slides for C++. Každý snímek má jedinečné Id a všechny běžné snímky jsou uspořádány v pořadí určeném nulově založeným indexem. Aspose.Slides for C++ umožňuje vývojářům přidávat prázdné snímky do jejich prezentace. Chcete‑li přidat prázdný snímek do prezentace, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
- Instancujte třídu [ISlideCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/) nastavením reference na vlastnost Slides (kolekce objektů Slide) vystavenou objektem Presentation.
- Přidejte prázdný snímek do prezentace na konci kolekce obsahových snímků voláním metod AddEmptySlide, které jsou součástí objektu ISlideCollection.
- Proveďte požadované operace s nově přidaným prázdným snímkem.
- Nakonec zapište soubor prezentace pomocí objektu [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **Často kladené otázky**

**Mohu vložit nový snímek na konkrétní pozici, a ne jen na konec?**

Ano. Knihovna podporuje kolekce snímků a operace [insert](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidecollection/insertclone/) , takže můžete přidat snímek na požadovaný index místo pouze na konec.

**Zachovají se motivy/styly při přidávání snímku na základě rozložení?**

Ano. Rozložení dědí formátování ze svého hlavního snímku a nový snímek dědí formátování z vybraného rozložení a jeho přidruženého hlavního snímku.

**Který snímek je přítomen v nové „prázdné“ prezentaci před přidáním snímků?**

Nově vytvořená prezentace již obsahuje jeden prázdný snímek s indexem nula. To je důležité zohlednit při výpočtu indexů vkládání.

**Jak si vybrat „správné“ rozložení pro nový snímek, pokud má master mnoho možností?**

Obecně vyberte [LayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/layoutslide/) , který odpovídá požadované struktuře ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidelayouttype/)). Pokud takové rozložení chybí, můžete jej [add it to the master](/slides/cs/cpp/slide-layout/) a poté jej použít.