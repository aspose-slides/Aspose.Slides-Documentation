---
title: Táblázatok létrehozása VSTO-val és az Aspose.Slides for Java segítségével
linktitle: Táblázatok létrehozása
type: docs
weight: 50
url: /hu/java/creating-a-table-on-powerpoint-slide/
keywords:
- táblázat létrehozása
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for Java-ra, és hozzon létre táblázatokat a PowerPoint (PPT, PPTX) diáknál Java-ban rugalmas formázással."
---
{{% alert color="info" %}} 
A táblázatokat széles körben használják adatok megjelenítésére prezentációs diákon. Ez a cikk bemutatja, hogyan lehet programozottan létrehozni egy 15 x 15 méretű táblázatot 10-es betűmérettel, először a [VSTO 2008](/slides/hu/java/creating-a-table-on-powerpoint-slide/) használatával, majd az [Aspose.Slides for Java](/slides/hu/java/creating-a-table-on-powerpoint-slide/) segítségével.
{{% /alert %}} 
## **Táblázatok létrehozása**
### **VSTO 2008 Példa**
A következő lépések VSTO használatával egy Microsoft PowerPoint diára adnak hozzá egy táblázatot:
1. Hozzon létre egy prezentációt.
1. Adjon hozzá egy üres diát a prezentációhoz.
1. Adjon hozzá egy 15 x 15 méretű táblázatot a diára.
1. Adjon szöveget a táblázat minden cellájához 10-es betűmérettel.
1. Mentse a prezentációt a lemezre.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateTableUsingVSTO-CreateTableUsingVSTO.cs" >}}
### **Aspose.Slides for Java Példa**
A következő lépések az Aspose.Slides használatával egy Microsoft PowerPoint diára adnak hozzá egy táblázatot:
1. Hozzon létre egy prezentációt.
1. Adjon hozzá egy 15 x 15 méretű táblázatot az első diára.
1. Adjon szöveget a táblázat minden cellájához 10-es betűmérettel.
1. Írja a prezentációt a lemezre.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-CreateTable-CreateTable.java" >}}