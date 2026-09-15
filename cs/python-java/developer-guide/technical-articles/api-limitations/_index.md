---
title: "Omezení API"
type: docs
weight: 320
url: /cs/python-java/api-limitations/
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
- "Python"
- "Java"
- "Aspose.Slides"
description: "Zjistěte omezení Aspose.Slides for Python via Java: pevná metadata Application, Creator a Producer v souborech PPTX a PDF."
---
## **Přehled**

Když jsou prezentace vytvářeny nebo exportovány pomocí Aspose.Slides, do výstupního souboru jsou zapsána určitá technická metadata. Tento článek vysvětluje omezení související s metadata poli `Application`, `Creator` a `Producer` v souborech PPTX a PDF.

## **Aplikace a Producent**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides for Python via Java, některá technická metadata jsou zapsána do souboru. Dvě pole často vyvolávají otázky:

**Application** určuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides for Python via Java je tato hodnota pevná a zobrazuje dodavatele knihovny místo názvu vaší aplikace, i když použijete [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** určuje renderovací engine, který během exportu vygeneroval finální soubor. V **PDF** exportech metadata používají pole **Creator** a **Producer**. V Aspose.Slides for Python via Java jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

**Co je omezeno**

Nemůžete tato pole přepsat pomocí API pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako „Aspose.Slides for Java“. Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako „Aspose.Slides for Java x.x.x.“. Toto chování je záměrné a platí bez ohledu na to, jak soubor načtete nebo uložíte, a bez ohledu na hodnoty přiřazené pomocí [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **Často kladené otázky**

**Mohu nahradit hodnotu Application v souboru PPTX názvem své aplikace?**

Ne. Hodnota je pevná, i když použijete [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Mohu přepsat pole Creator a Producer při exportu do PDF?**

Ne. Obě pole jsou pevná a odrážejí knihovnu a její verzi, bez ohledu na to, jak načtete nebo uložíte prezentaci.