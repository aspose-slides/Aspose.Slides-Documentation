---
title: Omezení výstupních metadat
type: docs
weight: 320
url: /cs/java/api-limitations/
keywords:
- Omezení API
- formát exportu
- aplikace
- producent
- vlastnosti dokumentu
- metadata
- generátor
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Aspose.Slides for Java zapisuje pevná metadata aplikace, autora a producenta do uložených souborů PPTX, PDF a ODP, bez ohledu na nastavený název aplikace."
---
## **Přehled**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides pro Java, některá technická metadata jsou zapisována do souboru. Tento článek vysvětluje omezení související s metadaty `Application`, `Creator`, `Producer` a generator v souborech PPTX, PDF a ODP.

## **Aplikace a Producent**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides pro Java, některá technická metadata jsou zapisována do souboru. Dvě pole často vyvolávají otázky:

**Application** identifikuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides pro Java je tato hodnota pevná a zobrazuje název knihovny místo názvu vaší aplikace, i když použijete [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifikuje vykreslovací engine, který během exportu vygeneroval finální soubor. Při exportu do **PDF** metadata používají pole **Creator** a **Producer**. S Aspose.Slides pro Java jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

**Co je omezeno**

Tyto pole nelze přepsat pomocí API pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako "Aspose.Slides for Java". Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako "Aspose.Slides for Java" následované verzí knihovny. Pro **ODP** je pole generator zapsáno jako "Aspose.Slides for Java" následované verzí knihovny. Toto chování je záměrné a platí bez ohledu na to, jak soubor načtete nebo uložíte, a bez ohledu na hodnoty přiřazené pomocí [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Toto omezení se nevztahuje na **PPT** soubory: v souboru PPT je název aplikace, který nastavíte pomocí [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-), uložen.