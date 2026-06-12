---
title: Správa záložních fontů pro prezentace v Pythonu
linktitle: Záložní font
type: docs
weight: 50
url: /cs/python-net/fallback-font/
keywords:
- záložní font
- dostupný font
- náhrada glifu
- určení fontu
- určení pravidla
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Podívejte se, jak Aspose.Slides pro Python via .NET používá záložní fonty k tomu, aby text v prezentacích PowerPoint a OpenDocument byl čitelný, když originální fonty nejsou k dispozici."
---
## **Úvod**

Záložní fonty jsou používány, když je font určený pro text v systému dostupný, ale neobsahuje požadovaný znak. V takovém případě může Aspose.Slides použít jeden ze zadaných záložních fontů k nahrazení chybějícího znaku.

## **Záložní font**

Aspose.Slides umožňuje vytvořit záložní fonty, přidat je do kolekce záložních fontů, nastavit kolekci záložních fontů pro konkrétní prezentaci, odebrat záložní fonty z prezentace, specifikovat pravidla pro použití záložních fontů a další.

Abyste se seznámili s těmito funkcemi, použijte následující odkazy:

- [Vytvořit záložní font](/slides/cs/python-net/create-fallback-font)
- [Vytvořit kolekci záložních fontů](/slides/cs/python-net/create-fallback-fonts-collection)
- [Vykreslit prezentaci se záložním fontem](/slides/cs/python-net/render-presentation-with-fallback-font)

## **Často kladené otázky**

**Jak se liší záložní fonty od substituce fontů?**

Záložní fonty jsou aplikovány po jednotlivých znacích nebo na rozsah Unicode, když primární font postrádá konkrétní znaky; doplňují jen chybějící znaky. [Substituce](/slides/cs/python-net/font-substitution/) nahradí chybějící nebo nedostupný font pro celý úsek nebo část textu jiným fontem. Mohou být kombinovány, ale jejich rozsah a logika výběru jsou odlišné.

**Ukládají se nastavení záložních fontů do souboru prezentace?**

Ne. Konfigurace záložních fontů existuje pouze během zpracování/vykreslování v knihovně a není serializována do souboru PPTX. Prezentace neukládá vaše pravidla pro záložní fonty.

**Ovlivňuje záložní fonty prvky vytvořené objekty PowerPointu (SmartArt, grafy, WordArt)?**

Ano. Text uvnitř těchto objektů prochází stejným vykreslovacím kanálem, takže se na něj vztahují stejná pravidla záložních fontů jako na běžný text.