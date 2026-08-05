---
title: Spravovat záložní fonty pro prezentace v C++
linktitle: Záložní font
type: docs
weight: 50
url: /cs/cpp/fallback-font/
keywords:
- záložní font
- dostupný font
- nahrazení znaků
- určit font
- určit pravidlo
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Podívejte se, jak Aspose.Slides pro C++ používá záložní fonty k zachování čitelnosti textu v prezentacích PowerPoint a OpenDocument, když nejsou k dispozici originální fonty."
---
## **Úvod**

Záložní fonty se používají, když je pro text určený font v systému dostupný, ale neobsahuje požadovaný znak. V takovém případě může Aspose.Slides použít jeden ze zadaných záložních fontů k nahrazení chybějícího znaku.

## **Záložní font**
Záložní font se používá, když je pro text určený font v systému dostupný, ale tento font neobsahuje potřebný znak. V takovém případě je možné použít jeden ze zadaných záložních fontů pro nahrazení znaku.

Aspose.Slides umožňuje vytvářet záložní fonty, přidávat je do kolekce záložních fontů, nastavit kolekci záložních fontů pro konkrétní prezentaci, odebrat záložní fonty z prezentace, definovat pravidla pro použití záložních fontů a další.

Abyste se seznámili s těmito funkcemi, použijte následující odkazy:

- [Vytvořit záložní font](/slides/cs/cpp/create-fallback-font)
- [Vytvořit kolekci záložních fontů](/slides/cs/cpp/create-fallback-fonts-collection)
- [Renderovat prezentaci se záložním fontem](/slides/cs/cpp/render-presentation-with-fallback-font)

## **Často kladené otázky**

**Jak se záložní fonty liší od nahrazení fontu?**

Záložní font se aplikuje na jednotlivé znaky nebo na rozsah Unicode, když primární font postrádá konkrétní znaky; vyplní pouze chybějící znaky. [Substitution](/slides/cs/cpp/font-substitution/) nahradí chybějící nebo nedostupný font pro celý úsek nebo část textu jiným fontem. Lze je kombinovat, ale jejich rozsah a logika výběru jsou odlišné.

**Ukládají se nastavení záložních fontů do souboru prezentace?**

Ne. Konfigurace záložního fontu existuje pouze během zpracování/vykreslování v knihovně a není serializována do souboru PPTX. Prezentace neukládá vaše pravidla záložního fontu.

**Ovlivňuje záložní fonty prvky vytvořené objekty PowerPoint (SmartArt, grafy, WordArt)?**

Ano. Text v těchto objektech prochází stejným vykreslovacím řetězcem, takže se na něj vztahují stejná pravidla záložního fontu jako na běžný text.