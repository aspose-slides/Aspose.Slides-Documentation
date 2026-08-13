---
title: Diagramok létrehozása prezentációkban Java használatával
linktitle: Diagram létrehozása
type: docs
weight: 30
url: /hu/java/how-to-create-charts-in-a-presentation/
keywords:
- migráció
- diagram létrehozása
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre diagramokat PowerPoint PPT, PPTX és ODP prezentációkban Java-val az Aspose.Slides használatával, mind az örökölt, mind a modern diagram API-kat alkalmazva."
---
{{% alert color="info" %}} 
Megjelent egy új [Aspose.Slides for Java API](https://docs.aspose.com/slides/hu/java/), és most ez az egyetlen termék támogatja a PowerPoint dokumentumok létrehozását a semmiből és a meglévők szerkesztését.
{{% /alert %}} 
## **Régi kód támogatása**
Hogy használni tudja a régi kódbázist, amelyet a Aspose.Slides for Java 14.x.x előtti verziókkal fejlesztettek, kis módosításokat kell végeznie a kódban, és az úgy fog működni, mint korábban. Az összes osztály, amelyek a régi Aspose.Slides for Java-ban a com.aspose.slides és a com.aspose.slides.pptx névterekben voltak, most egyetlen com.aspose.slides névtérbe vannak egyesítve. Tekintse meg az alábbi egyszerű kódrészletet, amely bemutatja, hogyan hozhat létre egy normál diagramot a semmiből a prezentációban a legacy Aspose.Slides API-val, és kövesse a lépéseket az új egyesített API-ra való átállás leírásához.
## **Legacy Aspose.Slides for Java megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChartEx-CreateChartEx.java" >}}
## **Új Aspose.Slides for Java 14.x.x megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateAChart-CreateAChart.java" >}}

Tekintse meg az alábbi egyszerű kódrészletet, amely bemutatja, hogyan hozhat létre egy szórt diagramot a semmiből a prezentációban a legacy Aspose.Slides API-val, és hogyan valósítható meg ez az új egyesített API-val.
## **Legacy Aspose.Slides for Java megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ExistingChart-ExistingChart.java" >}}
## **Új Aspose.Slides for Java 14.x.x megközelítés**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateScatterChart-CreateScatterChart.java" >}}