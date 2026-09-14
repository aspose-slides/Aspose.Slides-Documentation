---
title: Správa záložních písem pro prezentace v Pythonu přes Java
linktitle: Záložní písmo
type: docs
weight: 50
url: /cs/python-java/fallback-font/
keywords:
- záložní písmo
- dostupné písmo
- náhrada glyfu
- určit písmo
- určit pravidlo
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Viz, jak Aspose.Slides pro Python přes Java používá záložní písma k udržení čitelnosti textu v prezentacích PowerPoint a OpenDocument, když původní písma nejsou k dispozici."
---
## **Úvod**

Záložní písma se používají, když je specifikované písmo pro text v systému dostupné, ale neobsahuje požadovaný glyf. V takovém případě může Aspose.Slides použít jedno ze zadaných záložních písem k nahrazení chybějícího glyfu.

Aspose.Slides vám umožňuje vytvářet záložní písma, přidávat je do kolekce záložních písem, nastavit kolekci záložních písem pro konkrétní prezentaci, odstraňovat záložní písma z prezentace, specifikovat pravidla pro použití záložních písem a provádět další související operace.

Pro seznámení s těmito funkcemi použijte následující odkazy:

- [Vytvořit záložní písmo](/slides/cs/python-java/create-fallback-font/)
- [Vytvořit kolekci záložních písem](/slides/cs/python-java/create-fallback-fonts-collection/)
- [Vykreslit prezentaci se záložním písmem](/slides/cs/python-java/render-presentation-with-fallback-font/)

## **Často kladené otázky**

**Jak se liší záložní písma od substituce písma?**

Záložní písmo se aplikuje po znaku nebo po rozsahu Unicode, když primární písmo postrádá konkrétní glyfy; doplňuje pouze chybějící znaky. [Substituce](/slides/cs/python-java/font-substitution/) nahrazuje chybějící nebo nedostupné písmo pro celý úsek či část textu jiným písmem. Mohou být kombinovány, ale jejich rozsah a logika výběru jsou odlišné.

**Ukládají se nastavení záložního písma uvnitř souboru prezentace?**

Ne. Konfigurace záložního písma existuje pouze v době zpracování/vykreslování v knihovně a není serializována do souboru PPTX. Prezentace neukládá vaše pravidla záložního písma.

**Ovlivňuje záložní písmo prvky vytvořené objekty PowerPointu (SmartArt, grafy, WordArt)?**

Ano. Text uvnitř těchto objektů prochází stejným vykreslovacím procesem, takže se na něj vztahují stejné zásady záložního písma jako na běžný text.