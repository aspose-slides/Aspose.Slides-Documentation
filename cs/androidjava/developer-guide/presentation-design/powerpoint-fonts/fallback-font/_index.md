---
title: Správa záložních písem pro prezentace na Androidu
linktitle: Záložní písmo
type: docs
weight: 50
url: /cs/androidjava/fallback-font/
keywords:
- záložní písmo
- dostupné písmo
- náhrada znaku
- určení písma
- určení pravidla
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Podívejte se, jak Aspose.Slides pro Android pomocí Javy používá záložní písma k zachování čitelnosti textu v prezentacích PowerPoint a OpenDocument, když nejsou k dispozici původní písma."
---
## **Úvod**

Záložní písmo se používá, když je zadané písmo pro text v systému k dispozici, ale toto písmo neobsahuje potřebný znak. V takovém případě je možné použít jedno ze zadaných záložních písem pro nahrazení znaku.

## **Záložní písmo**

Aspose.Slides umožňuje vytvářet záložní písma, přidávat je do kolekce záložních písem, nastavit kolekci záložních písem pro konkrétní prezentaci, odstraňovat záložní písma z prezentace, určit pravidla pro použití záložních písem a další.

Pro seznámení s těmito funkcemi použijte následující odkazy:

- [Vytvořit záložní písmo](/slides/cs/androidjava/create-fallback-font)
- [Vytvořit kolekci záložních písem](/slides/cs/androidjava/create-fallback-fonts-collection)
- [Vykreslit prezentaci se záložním písmem](/slides/cs/androidjava/render-presentation-with-fallback-font)

## **Často kladené otázky**

**Jak se liší záložní písma od náhrady písma?**

Záložní písmo se použije na úrovni jednotlivých znaků nebo rozsahu Unicode, když primární písmo postrádá konkrétní znaky; doplní pouze chybějící znaky. [Substitution](/slides/cs/androidjava/font-substitution/) nahradí chybějící nebo nedostupné písmo pro celý běh nebo část textu jiným písmem. Mohou být kombinovány, ale jejich rozsah a logika výběru se liší.

**Jsou nastavení záložního písma uložena v souboru prezentace?**

Ne. Konfigurace záložního písma existuje pouze v době zpracování/vykreslování v knihovně a není serializována do souboru PPTX. Prezentace neukládá vaše pravidla záložního písma.

**Ovlivňuje záložní písmo prvky vytvořené objekty PowerPoint (SmartArt, grafy, WordArt)?**

Ano. Text v těchto objektech prochází stejným vykreslovacím procesem, takže na něj platí stejná pravidla záložního písma jako na běžný text.