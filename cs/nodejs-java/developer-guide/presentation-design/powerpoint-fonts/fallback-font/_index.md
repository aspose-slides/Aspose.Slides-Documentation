---
title: Spravujte záložní písma pro prezentace v JavaScriptu
linktitle: Záložní písmo
type: docs
weight: 50
url: /cs/nodejs-java/fallback-font/
keywords:
- záložní písmo
- dostupné písmo
- náhrada glifu
- určit písmo
- určit pravidlo
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Podívejte se, jak Aspose.Slides pro Node.js používá záložní písma k zachování čitelnosti textu v prezentacích PowerPoint a OpenDocument, když originální písma nejsou k dispozici."
---
## **Úvod**

Záložní písma se používají, když je písmo určené pro text v systému dostupné, ale neobsahuje požadovaný znak. V takovém případě může Aspose.Slides použít jedno ze zadaných záložních písem k nahrazení chybějícího znaku.

## **Záložní písmo**

Aspose.Slides umožňuje vytvářet záložní písma, přidávat je do kolekce záložních písem, nastavit kolekci záložních písem pro konkrétní prezentaci, odebrat záložní písma z prezentace, určit pravidla pro použití záložních písem a další.

Pro seznámení s těmito funkcemi použijte následující odkazy:

- [Vytvořit záložní písmo](/slides/cs/nodejs-java/create-fallback-font)
- [Vytvořit kolekci záložních písem](/slides/cs/nodejs-java/create-fallback-fonts-collection)
- [Vykreslit prezentaci se záložním písmem](/slides/cs/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**Jak se záložní písma liší od substituce písem?**

Záložní písmo se aplikuje na jednotlivý znak nebo na rozsah Unicode, když primární písmo postrádá konkrétní znaky; doplňuje jen chybějící znaky. [Substituce](/slides/cs/nodejs-java/font-substitution/) nahrazuje chybějící nebo nedostupné písmo pro celý úsek či část textu jiným písmem. Mohou být kombinovány, ale jejich rozsah a logika výběru jsou odlišné.

**Ukládají se nastavení záložních písem do souboru prezentace?**

Ne. Konfigurace záložních písem existuje pouze během zpracování/vykreslování v knihovně a není serializována do souboru PPTX. Prezentace neukládá vaše pravidla záložních písem.

**Ovlivňuje záložní písmo prvky vytvořené objekty PowerPoint (SmartArt, grafy, WordArt)?**

Ano. Text v těchto objektech prochází stejným vykreslovacím potrubím, takže se na něj vztahují stejná pravidla záložního písma jako na běžný text.