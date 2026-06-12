---
title: Spravovat náhradní písma pro prezentace v C++
linktitle: Náhradní písmo
type: docs
weight: 50
url: /cs/cpp/fallback-font/
keywords:
- náhradní písmo
- dostupné písmo
- nahrazení glifu
- určit písmo
- určit pravidlo
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Podívejte se, jak Aspose.Slides pro C++ používá náhradní písma k zachování čitelnosti textu v prezentacích PowerPoint a OpenDocument, když nejsou k dispozici původní písma."
---
## **Úvod**

Náhradní písma se používají, když je písmo určené pro text v systému dostupné, ale neobsahuje požadovaný znak. V takovém případě může Aspose.Slides použít jedno z určených náhradních písem k nahrazení chybějícího znaku.

## **Náhradní písmo**
Náhradní písmo se používá, když je písmo určené pro text v systému dostupné, ale neobsahuje potřebný znak. V takovém případě je možné použít jedno z určených náhradních písem k nahrazení znaku.

Aspose.Slides umožňuje vytvářet náhradní písma, přidávat je do kolekce náhradních písem, nastavit kolekci náhradních písem pro konkrétní prezentaci, odstraňovat náhradní písma z prezentace, definovat pravidla pro použití náhradních písem a další.

Seznámení s těmito funkcemi získáte pomocí následujících odkazů:

- [Vytvořit náhradní písmo](/slides/cs/cpp/create-fallback-font)
- [Vytvořit kolekci náhradních písem](/slides/cs/cpp/create-fallback-fonts-collection)
- [Vykreslit prezentaci s náhradním písmem](/slides/cs/cpp/render-presentation-with-fallback-font)

## **Často kladené otázky**

**Jak se náhradní písma liší od substituce písma?**

Náhradní písmo se aplikuje na jednotlivý znak nebo na rozsah Unicode, když primární písmo postrádá konkrétní znaky; doplňuje jen chybějící znaky. [Substituce](/slides/cs/cpp/font-substitution/) nahrazuje chybějící nebo nedostupné písmo pro celý úsek nebo část textu jiným písmem. Mohou být kombinovány, ale jejich rozsah a logika výběru jsou odlišné.

**Ukládají se nastavení náhradního písma do souboru prezentace?**

Ne. Konfigurace náhradního písma existuje pouze během zpracování/vykreslování v knihovně a není serializována do souboru PPTX. Prezentace neukládá vaše pravidla náhradního písma.

**Ovlivňuje náhradní písmo prvky vytvořené objekty PowerPointu (SmartArt, grafy, WordArt)?**

Ano. Text v těchto objektech prochází stejným vykreslovacím kanálem, takže se na něj vztahují stejné pravidla náhradního písma jako na běžný text.