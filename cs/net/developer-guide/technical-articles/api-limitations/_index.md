---
title: Omezení API
type: docs
weight: 320
url: /cs/net/api-limitations/
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
- .NET
- C#
- Aspose.Slides
description: "Poznejte omezení Aspose.Slides pro .NET: exporty nastavují pevná metadata Application/Producer v PPT, PPTX, ODP a PDF - pomáhá vám naplánovat integrace bez neočekávaných překvapení."
---
## **Přehled**

Když jsou prezentace vytvářeny nebo exportovány pomocí Aspose.Slides, jsou do výstupního souboru zapsána určitá technická metadata. Tento článek vysvětluje omezení související s poli metadat `Application`, `Creator` a `Producer` v souborech PPTX a PDF.

## **Aplikace a Producent**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides pro .NET, jsou do souboru zapsána některá technická metadata. Dvě pole často vyvolávají otázky:

**Application** určuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides pro .NET je tato hodnota pevná a zobrazuje dodavatele knihovny místo názvu vaší aplikace, i když nastavíte [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/cs/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** určuje vykreslovací engine, který během exportu vygeneroval finální soubor. V **PDF** exportech metadata používají pole **Creator** a **Producer**. S Aspose.Slides pro .NET jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

**Co je omezeno**

Nemůžete tato pole přepsat pomocí API pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako „Aspose.Slides for .NET“. Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako „Aspose.Slides for .NET x.x.x“. Toto chování je záměrné a platí bez ohledu na to, jak soubor načtete nebo uložíte, a bez ohledu na hodnoty přiřazené k [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/cs/net/aspose.slides/documentproperties/nameofapplication/).