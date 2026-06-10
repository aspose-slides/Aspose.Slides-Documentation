---
title: "Hogyan adjon hozzá fejléceket és lábléceket a prezentációkhoz Java-ban"
linktitle: "Fejléc és lábléc hozzáadása"
type: docs
weight: 20
url: /hu/java/how-to-add-header-footer-in-a-presentation/
keywords:
- migráció
- fejléc hozzáadása
- lábléc hozzáadása
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá fejléceket és lábléceket PowerPoint PPT, PPTX és ODP prezentációkhoz Java-ban, a régi és modern Aspose.Slides API-k használatával."
---
{{% alert color="primary" %}} 

Egy új [Aspose.Slides for Java API](https://docs.aspose.com/slides/hu/java/) jelent meg, és most ez a termék képes PowerPoint dokumentumokat generálni a semmiből, valamint a meglévőket szerkeszteni.

{{% /alert %}} 
## **Legacy kód támogatása**
Ahhoz, hogy a Aspose.Slides for Java 13.x előtti verzióihoz készült legacy kódot használhassa, kisebb módosításokat kell elvégeznie a kódban, és a kód úgy fog működni, mint korábban. Az összes osztály, amely a régi Aspose.Slides for Java-ban az Aspose.Slide és az Aspose.Slides.Pptx névtérben szerepelt, most egyetlen Aspose.Slides névtérbe van összevonva. Tekintse meg az alábbi egyszerű kódrészletet, amely bemutatja a fejléc és lábléc hozzáadását a prezentációhoz a legacy Aspose.Slides API-ban, és kövesse a lépéseket az új összevont API-ra való migráláshoz.
## **Legacy Aspose.Slides for Java megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **Új Aspose.Slides for Java 13.x megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}