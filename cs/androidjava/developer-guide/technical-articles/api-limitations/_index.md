---
title: Omezení API
type: docs
weight: 320
url: /cs/androidjava/api-limitations/
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
- Android
- Java
- Aspose.Slides
description: "Zjistěte omezení Aspose.Slides pro Android: exporty nastavují pevná metadata Application/Producer v PPT, PPTX, ODP a PDF—což vám pomůže naplánovat integrace bez překvapení."
---
## **Přehled**

Když jsou prezentace vytvořeny nebo exportovány pomocí Aspose.Slides, do výstupního souboru se zapíšou určité technické metadata. Tento článek vysvětluje omezení související s poli metadat `Application`, `Creator` a `Producer` v souborech PPTX a PDF.

## **Application a Producer**

Když vytváříte nebo exportujete prezentace pomocí Aspose.Slides for Android via Java, do souboru se zapíše určité technické metadata. Dvě pole často vyvolávají otázky:

**Application** určuje program, který vytvořil nebo naposledy uložil **PPTX** prezentaci. V Aspose.Slides for Android via Java je tato hodnota pevná a zobrazuje dodavatele knihovny místo názvu vaší aplikace, i když použijete [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** určuje renderovací engine, který vygeneroval finální soubor během exportu. V **PDF** exportech metadata používají pole **Creator** a **Producer**. S Aspose.Slides for Android via Java jsou obě tato pole pevná a odrážejí knihovnu a její verzi.

## **Co je omezeno**

Nemůžete přepsat tato pole prostřednictvím API pro výše uvedené formáty. Pro **PPTX** je vlastnost Application zapsána jako "Aspose.Slides for Android via Java". Pro **PDF** jsou vlastnosti Creator a Producer zapsány jako "Aspose.Slides for Android via Java x.x.x." Toto chování je záměrné a platí bez ohledu na to, jak soubor načtete nebo uložíte, a bez ohledu na hodnoty přiřazené pomocí [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).