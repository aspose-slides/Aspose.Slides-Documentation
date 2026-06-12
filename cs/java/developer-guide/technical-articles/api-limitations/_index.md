---
title: "Omezení API"
type: docs
weight: 320
url: /cs/java/api-limitations/
keywords:
- "Omezení API"
- "formát exportu"
- "aplikace"
- "producent"
- "vlastnosti dokumentu"
- "metadata"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Java"
- "Aspose.Slides"
description: "Zjistěte omezení Aspose.Slides pro Java: exporty nastavují pevná metadata Application/Producer v souborech PPT, PPTX, ODP a PDF - pomáhá vám plánovat integrace bez neočekávaných překvapení."
---
## **Přehled**

Když jsou prezentace vytvářeny nebo exportovány pomocí Aspose.Slides, do výstupního souboru jsou zapsána určitá technická metadata. Tento článek vysvětluje omezení související s poli metadat `Application`, `Creator` a `Producer` v souborech PPTX a PDF.

## **Aplikace a Producent**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides pro Java, do souboru jsou zapsána některá technická metadata. Dvě pole často vyvolávají otázky:

**Application** identifikuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides pro Java je tato hodnota pevná a zobrazuje dodavatele knihovny místo názvu vaší aplikace, i když použijete [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifikuje renderovací engine, který během exportu vygeneroval finální soubor. V exportech **PDF** metadata používají pole **Creator** a **Producer**. V Aspose.Slides pro Java jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

**Co je omezeno**

Tyto položky nelze pomocí API přepsat pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako "Aspose.Slides for Java". Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako "Aspose.Slides for Java x.x.x." Toto chování je navrženo tak, aby platilo bez ohledu na to, jak soubor načítáte nebo ukládáte, a bez ohledu na hodnoty přiřazené pomocí [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).