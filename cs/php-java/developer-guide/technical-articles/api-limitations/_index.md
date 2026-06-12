---
title: Omezení API
type: docs
weight: 320
url: /cs/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Poznejte omezení Aspose.Slides for PHP: exporty nastavují pevná metadata Application/Producer v PPT, PPTX, ODP a PDF - pomáhá vám plánovat integrace bez překvapení."
---
## **Přehled**

Když jsou prezentace vytvářeny nebo exportovány pomocí Aspose.Slides, zapisuje se do výstupního souboru určitá technická metadata. Tento článek vysvětluje omezení související s poli metadat `Application`, `Creator` a `Producer` v souborech PPTX a PDF.

## **Aplikace a Producent**

Když vytváříte nebo exportujete prezentace s Aspose.Slides for PHP via Java, zapisuje se do souboru určitá technická metadata. Dvě pole často vyvolávají otázky:

**Application** identifikuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides for PHP via Java je tato hodnota pevná a zobrazuje dodavatele knihovny místo názvu vaší aplikace, i když použijete [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifikuje vykreslovací engine, který během exportu vygeneroval finální soubor. Při exportech do **PDF** metadata používá pole **Creator** a **Producer**. V Aspose.Slides for PHP via Java jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

**Co je omezeno**

Nemůžete tato pole přepsat pomocí API pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako "Aspose.Slides for PHP via Java". Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako "Aspose.Slides for PHP via Java x.x.x." Toto chování je navrženo a platí bez ohledu na to, jak soubor načtete nebo uložíte, a bez ohledu na hodnoty přiřazené pomocí [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/setnameofapplication/).