---
title: Hogyan hozzunk létre Hello World prezentációkat Java-ban
linktitle: Hello World prezentáció
type: docs
weight: 10
url: /hu/java/how-to-create-hello-world-presentation-document/
keywords:
- migráció
- hello world
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Készítsen Hello World PowerPoint PPT, PPTX és ODP prezentációt Java-ban az Aspose.Slides használatával, mind az örökölt, mind a modern API-kat egy egyszerű útmutatóban."
---
{{% alert color="info" %}} 
Megjelent egy új [Aspose.Slides for Java API](/slides/hu/java/), és most ez a termék támogatja a PowerPoint-dokumentumok nulláról történő létrehozását és a meglévők szerkesztését.
{{% /alert %}} 
## **Régi kód támogatása**
A 13.x verzió előtti Aspose.Slides for Java-val fejlesztett régi kód használatához néhány kisebb módosítást kell végrehajtani a kódban, ezután a kód ugyanúgy fog működni, mint korábban. Az összes régi Aspose.Slides for Java alatt az Aspose.Slide és az Aspose.Slides.Pptx névtérben található osztály most egyetlen Aspose.Slides névtérbe van egyesítve. Kérjük, tekintse meg az alábbi egyszerű kódrészletet, amely egy Hello World prezentációs dokumentumot hoz létre a régi Aspose.Slides API-val, és kövesse a lépéseket, amelyek leírják, hogyan migráljon az új egyesített API-ra.
## **Régi Aspose.Slides for Java megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Creation-HelloWorldPresentation-HelloWorldPresentation.java" >}}
## **Új Aspose.Slides for Java 14.x.x megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Creation-CreateAPresentation-CreateAPresentation.java" >}}