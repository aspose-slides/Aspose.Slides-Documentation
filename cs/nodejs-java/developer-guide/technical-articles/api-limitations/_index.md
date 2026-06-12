---
title: Omezení API
type: docs
weight: 320
url: /cs/nodejs-java/api-limitations/
keywords:
- Omezení API
- formát exportu
- aplikace
- producent
- vlastnosti dokumentu
- metadata
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte omezení Aspose.Slides pro Node.js: exporty nastavují pevná metadata Application/Producer v PPT, PPTX, ODP a PDF—pomáhá vám plánovat integrace bez překvapení."
---
## **Přehled**

Když jsou prezentace vytvořeny nebo exportovány pomocí Aspose.Slides, určité technické metadata jsou zapsána do výstupního souboru. Tento článek vysvětluje omezení související s metadaty `Application`, `Creator` a `Producer` v souborech PPTX a PDF.

## **Aplikace a Producent**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides for Node.js via Java, některá technická metadata jsou zapsána do souboru. Dvě pole často vyvolávají otázky:

**Application** identifikuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides for Node.js via Java je tato hodnota pevná a zobrazuje dodavatele knihovny místo názvu vaší aplikace, i když použijete [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifikuje vykreslovací engine, který během exportu vygeneroval finální soubor. V exportech **PDF** metadata používají pole **Creator** a **Producer**. V Aspose.Slides for Node.js via Java jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

**Co je omezeno**

Tyto pole nelze pomocí API přepsat pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako "Aspose.Slides for Node.js via Java". Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako "Aspose.Slides for Node.js via Java x.x.x." Toto chování je záměrné a platí bez ohledu na to, jak soubor načítáte nebo ukládáte, a bez ohledu na hodnoty přiřazené pomocí [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).