---
title: Spravovat záložní písma pro prezentace v Jave
linktitle: Záložní písmo
type: docs
weight: 50
url: /cs/java/fallback-font/
keywords:
- záložní písmo
- dostupné písmo
- nahrazení glifu
- určit písmo
- určit pravidlo
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Podívejte se, jak Aspose.Slides pro Javu používá záložní písma k zachování čitelnosti textu v prezentacích PowerPoint a OpenDocument, když původní písma nejsou k dispozici."
---
## **Úvod**

Záložní písma se používají, když je písmo určené pro text dostupné v systému, ale neobsahuje požadovaný znak. V takovém případě může Aspose.Slides použít jedno ze zadaných záložních písem k nahrazení chybějícího znaku.

## **Záložní písmo**

Aspose.Slides umožňuje vytvářet záložní písma, přidávat je do kolekce záložních písem, nastavit kolekci záložních písem pro konkrétní prezentaci, odstraňovat záložní písma z prezentace, specifikovat pravidla pro použití záložních písem a další.

Pro seznámení s těmito funkcemi použijte následující odkazy:

- [Vytvořit záložní písmo](/slides/cs/java/create-fallback-font)
- [Vytvořit kolekci záložních písem](/slides/cs/java/create-fallback-fonts-collection)
- [Vykreslit prezentaci se záložním písmem](/slides/cs/java/render-presentation-with-fallback-font)

## **Často kladené otázky**

**Jak se záložní písma liší od náhrady písem?**

Záložní písmo se aplikuje na jednotlivý znak nebo rozsah Unicode, když primární písmo postrádá konkrétní znaky; doplňuje pouze chybějící znaky. [Náhrada](/slides/cs/java/font-substitution/) nahrazuje chybějící nebo nedostupné písmo pro celý úsek nebo část textu jiným písmem. Lze je kombinovat, ale jejich rozsah a logika výběru jsou odlišné.

**Ukládají se nastavení záložních písem do souboru prezentace?**

Ne. Konfigurace záložních písem existuje pouze během zpracování/vykreslování v knihovně a není serializována do souboru PPTX. Prezentace neukládá vaše pravidla záložních písem.

**Ovlivňují záložní písma prvky vytvořené objekty PowerPoint (SmartArt, grafy, WordArt)?**

Ano. Text v těchto objektech prochází stejným vykreslovacím procesem, takže se na něj vztahují stejná pravidla záložních písem jako na běžný text.