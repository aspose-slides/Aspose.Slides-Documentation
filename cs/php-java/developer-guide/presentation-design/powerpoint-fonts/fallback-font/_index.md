---
title: Spravovat záložní písma pro prezentace v PHP
linktitle: Záložní písmo
type: docs
weight: 50
url: /cs/php-java/fallback-font/
keywords:
- záložní písmo
- dostupné písmo
- nahrazení znaků
- určit písmo
- určit pravidlo
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Podívejte se, jak Aspose.Slides pro PHP používá záložní písma k tomu, aby text byl čitelný v prezentacích PowerPoint a OpenDocument, když nejsou k dispozici původní písma."
---
## **Úvod**

Záložní písma se používají, když je písmo určené pro text v systému k dispozici, ale neobsahuje požadovaný znak. V takovém případě může Aspose.Slides použít jedno ze zadaných záložních písem k nahrazení chybějícího znaku.

## **Záložní písmo**
Záložní písmo se používá, když je písmo určené pro text v systému k dispozici, ale toto písmo neobsahuje potřebný znak. V takovém případě je možné použít jedno ze zadaných záložních písem pro nahrazení znaku.

Aspose.Slides umožňuje vytvářet záložní písma, přidávat je do kolekce záložních písem, nastavit kolekci záložních písem pro konkrétní prezentaci, odstraňovat záložní písma z prezentace, určit pravidla pro použití záložních písem a další.

Abyste se seznámili s těmito funkcemi, použijte následující odkazy:

- [Vytvořit záložní písmo](/slides/cs/php-java/create-fallback-font)
- [Vytvořit kolekci záložních písem](/slides/cs/php-java/create-fallback-fonts-collection)
- [Vykreslit prezentaci se záložním písmem](/slides/cs/php-java/render-presentation-with-fallback-font)

## **Často kladené otázky**

**Jak se liší záložní písma od substituce písma?**

Záložní písmo se používá po jednotlivých znacích nebo po rozsahu Unicode, když primární písmo postrádá konkrétní znaky; doplní pouze chybějící znaky. [Substituce](/slides/cs/php-java/font-substitution/) nahrazuje chybějící nebo nedostupné písmo pro celý úsek nebo část textu jiným písmem. Mohou být kombinovány, ale jejich rozsah a logika výběru se liší.

**Ukládají se nastavení záložních písem do souboru prezentace?**

Ne. Konfigurace záložních písem existuje pouze během zpracování/vykreslování v knihovně a není serializována do souboru PPTX. Prezentace neukládá vaše pravidla záložních písem.

**Ovlivňuje záložní písmo prvky vytvořené objekty PowerPointu (SmartArt, grafy, WordArt)?**

Ano. Text v těchto objektech prochází stejným vykreslovacím potrubím, takže se na něj vztahují stejné pravidla záložních písem jako na běžný text.