---
title: Omezení výstupních metadat
type: docs
weight: 320
url: /cs/net/api-limitations/
keywords:
- Omezení API
- exportní formát
- aplikace
- producent
- vlastnosti dokumentu
- metadata
- generátor
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET zapisuje pevná metadata aplikace, tvůrce a producent do uložených souborů PPTX, PDF a ODP, bez ohledu na nastavený název aplikace."
---
## **Přehled**

Když jsou prezentace vytvářeny nebo exportovány pomocí Aspose.Slides, do výstupního souboru jsou zapsána určitá technická metadata. Tento článek vysvětluje omezení související s poli metadat `Application`, `Creator`, `Producer` a generator v souborech PPTX, PDF a ODP.

## **Application a Producer**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides for .NET, do souboru jsou zapsána některá technická metadata. Dvě pole často vyvolávají otázky:

**Application** identifikuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides for .NET je tato hodnota pevná a zobrazuje název knihovny místo názvu vaší aplikace, i když nastavíte [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/cs/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifikuje vykreslovací engine, který vygeneroval finální soubor během exportu. V **PDF** exportech metadata používají pole **Creator** a **Producer**. S Aspose.Slides for .NET jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

**Co je omezeno**

Nemůžete přepsat tato pole pomocí API pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako „Aspose.Slides for .NET“. Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako „Aspose.Slides for .NET“ následované verzí knihovny. Pro **ODP** je pole generator zapsáno jako „Aspose.Slides for .NET“ následované verzí knihovny. Toto chování je záměrné a platí bez ohledu na to, jak soubor načtete nebo uložíte, a bez ohledu na hodnoty přiřazené [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/cs/net/aspose.slides/documentproperties/nameofapplication/).

Toto omezení se nevztahuje na soubory **PPT**: v souboru PPT je název aplikace, který jste nastavili v [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/cs/net/aspose.slides/documentproperties/nameofapplication/), uložen.