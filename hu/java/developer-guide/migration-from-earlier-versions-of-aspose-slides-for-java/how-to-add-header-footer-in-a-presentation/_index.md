---
title: Hogyan adjunk hozzá fejléceket és lábléceket a prezentációkhoz Java-ban
linktitle: Fejléc és lábléc hozzáadása
type: docs
weight: 20
url: /hu/java/how-to-add-header-footer-in-a-presentation/
keywords:
- migráció
- fejléc hozzáadása
- lábléc hozzáadása
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet fejléceket és lábléceket hozzáadni PowerPoint PPT, PPTX és ODP prezentációkhoz Java-ban, mind az örökölt, mind a modern Aspose.Slides API-k használatával."
---
{{% alert color="info" %}} 

Egy új [Aspose.Slides for Java API](https://docs.aspose.com/slides/hu/java/) jelent meg, és most ez a termék képes PowerPoint‑dokumentumok előállítására a semmiből, valamint meglévő dokumentumok szerkesztésére.

{{% /alert %}} 
## **Legacy kód támogatása**
Annak érdekében, hogy a korábbi, 13.x‑nél korábbi Aspose.Slides for Java verziókkal fejlesztett legacy kódot használhassa, néhány kisebb módosítást kell végezni a kódban, és az úgy fog működni, mint korábban. Az összes osztály, amely korábban az Aspose.Slides for Java-ban az Aspose.Slide és Aspose.Slides.Pptx névtérben volt, most egyetlen Aspose.Slides névtérbe van egyesítve. Tekintse meg az alábbi egyszerű kódrészletet, amely a fejléc és lábléc hozzáadását mutatja egy prezentációhoz a régi Aspose.Slides API‑val, és kövesse a lépéseket, amelyek leírják, hogyan lehet átmenni az új, egyesített API‑ra.
## **Legacy Aspose.Slides for Java megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **Új Aspose.Slides for Java 13.x megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}