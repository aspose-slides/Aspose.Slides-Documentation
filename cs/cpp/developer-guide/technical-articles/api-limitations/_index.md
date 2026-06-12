---
title: Omezení API
type: docs
weight: 320
url: /cs/cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "Poznejte omezení Aspose.Slides pro C++: exporty nastavují pevná metadata Application/Producer v souborech PPT, PPTX, ODP a PDF—pomáhají vám naplánovat integrace bez neočekávaných překvapení."
---
## **Přehled**

Když jsou prezentace vytvářeny nebo exportovány pomocí Aspose.Slides, do výstupního souboru jsou zapsána určitá technická metadata. Tento článek vysvětluje omezení související s poli metadat `Application`, `Creator` a `Producer` v souborech PPTX a PDF.

## **Aplikace a Producent**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides pro C++, jsou do souboru zapsána některá technická metadata. Dvě pole často vyvolávají otázky:

**Application** identifikuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides pro C++ je tato hodnota pevná a zobrazuje dodavatele knihovny místo názvu vaší aplikace, i když použijete [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cs/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** identifikuje vykreslovací engine, který během exportu vygeneroval finální soubor. V exportech do **PDF** metadata používají pole **Creator** a **Producer**. V Aspose.Slides pro C++ jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

**Co je omezeno**

Nelze přepsat tato pole pomocí API pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako "Aspose.Slides for C++". Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako "Aspose.Slides for C++ x.x.x". Toto chování je záměrné a platí bez ohledu na to, jak soubor načítáte nebo ukládáte, a bez ohledu na hodnoty přiřazené pomocí [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cs/cpp/aspose.slides/documentproperties/set_nameofapplication/).