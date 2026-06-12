---
title: Správa záložních písem pro prezentace v .NET
linktitle: Záložní písmo
type: docs
weight: 50
url: /cs/net/fallback-font/
keywords:
- záložní písmo
- dostupné písmo
- nahrazení glifu
- specifikovat písmo
- specifikovat pravidlo
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Viz, jak Aspose.Slides pro .NET používá záložní písma k udržení čitelnosti textu v prezentacích PowerPoint a OpenDocument, když původní písma nejsou k dispozici."
---
## **Úvod**

Záložní písma se používají, když je specifikované písmo pro text v systému dostupné, ale neobsahuje požadovaný glif. V takovém případě může Aspose.Slides použít jedno ze zadaných záložních písem k nahrazení chybějícího glifu.

## **Záložní písmo**

Aspose.Slides umožňuje vytvářet záložní písma, přidávat je do kolekce záložních písem, nastavit kolekci záložních písem pro konkrétní prezentaci, odstraňovat záložní písma z prezentace, specifikovat pravidla pro aplikaci záložních písem a další.

Pro seznámení s těmito funkcemi použijte následující odkazy:

- [Vytvořit záložní písmo](/slides/cs/net/create-fallback-font)
- [Vytvořit kolekci záložních písem](/slides/cs/net/create-fallback-fonts-collection)
- [Vykreslit prezentaci se záložním písmem](/slides/cs/net/render-presentation-with-fallback-font)

## **Často kladené otázky**

**Jak se záložní písma liší od nahrazení písma?**

Záložní písmo se použije na úrovni jednotlivého znaku nebo rozsahu Unicode, když primární písmo postrádá konkrétní glify; doplní pouze chybějící znaky. [Substitution](/slides/cs/net/font-substitution/) nahradí chybějící nebo nedostupné písmo pro celou běh nebo část textu jiným písmem. Mohou být kombinována, ale jejich rozsah a logika výběru jsou odlišné.

**Jsou nastavení záložního písma uložena v souboru prezentace?**

Ne. Konfigurace záložního písma existuje pouze během zpracování/vykreslování v knihovně a není serializována do formátu PPTX. Prezentace neukládá vaše pravidla záložního písma.

**Ovlivňuje záložní písmo prvky vytvořené objekty PowerPoint (SmartArt, grafy, WordArt)?**

Ano. Text v těchto objektech prochází stejným vykreslovacím kanálem, takže se na něj vztahují stejná pravidla záložního písma jako na běžný text.