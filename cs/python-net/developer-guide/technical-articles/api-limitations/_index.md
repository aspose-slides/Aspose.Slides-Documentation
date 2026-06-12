---
title: Omezení API
type: docs
weight: 210
url: /cs/python-net/api-limitations/
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
- Python
- Aspose.Slides
description: "Poznejte omezení Aspose.Slides pro Python: exporty nastavují pevná metadata Application/Producer v PPT, PPTX, ODP a PDF - pomáhá vám plánovat integrace bez překvapení."
---
## **Přehled**

Když jsou prezentace vytvořeny nebo exportovány pomocí Aspose.Slides, do výstupního souboru jsou zapsána určitá technická metadata. Tento článek vysvětluje omezení související s poli metadat `Application`, `Creator` a `Producer` v souborech PPTX a PDF.

## **Aplikace a producent**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides for Python via .NET, do souboru jsou zapsána některá technická metadata. Dvě pole často vyvolávají dotazy:

**Application** určuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides for Python via .NET je tato hodnota pevná a zobrazuje dodavatele knihovny místo názvu vaší aplikace, i když nastavíte [DocumentProperties.name_of_application](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** určuje vykreslovací engine, který během exportu vygeneroval výsledný soubor. V exportech **PDF** metadata používají pole **Creator** a **Producer**. U Aspose.Slides for Python via .NET jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

**Co je omezeno**

Tyto pole nelze přepsat pomocí API pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako "Aspose.Slides for Python via .NET". Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako "Aspose.Slides for Python via .NET x.x.x". Toto chování je záměrné a platí bez ohledu na to, jak soubor načítáte nebo ukládáte, a bez ohledu na hodnoty přiřazené k [DocumentProperties.name_of_application](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/name_of_application/).