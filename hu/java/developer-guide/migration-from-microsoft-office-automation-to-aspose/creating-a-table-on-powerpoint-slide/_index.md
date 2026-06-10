---
title: Táblázatok létrehozása VSTO és Aspose.Slides for Java segítségével
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
description: "Migráljon a Microsoft Office automatizálásból az Aspose.Slides for Java-ra, és hozza létre a táblázatokat PowerPoint (PPT, PPTX) diákként Java-ban rugalmas formázással."
---
{{% alert color="primary" %}} 
A táblázatokat széles körben használják adatok megjelenítésére prezentációs diákon. Ez a cikk bemutatja, hogyan hozhatunk létre programozottan egy 15 x 15-ös táblázatot 10-es betűmérettel, először a [VSTO 2008](/slides/hu/java/creating-a-table-on-powerpoint-slide/) segítségével, majd az [Aspose.Slides for Java](/slides/hu/java/creating-a-table-on-powerpoint-slide/) használatával.
{{% /alert %}} 
## **Táblázatok létrehozása**
### **VSTO 2008 példa**
A következő lépések a Microsoft PowerPoint diára táblázatot adnak hozzá VSTO használatával:

1. Készítsen egy prezentációt.
1. Egy üres diát adunk hozzá a prezentációhoz.
1. Adjunk hozzá egy 15 x 15-ös táblázatot a diához.
1. Adjunk szöveget a táblázat minden cellájához 10-es betűmérettel.
1. Mentse a prezentációt a lemezre.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateTableUsingVSTO-CreateTableUsingVSTO.cs" >}}
### **Aspose.Slides for Java példa**
A következő lépések a Microsoft PowerPoint diára táblázatot adnak hozzá Aspose.Slides használatával:

1. Készítsen egy prezentációt.
1. Adjunk hozzá egy 15 x 15-ös táblázatot az első diára.
1. Adjunk szöveget a táblázat minden cellájához 10-es betűmérettel.
1. Írja ki a prezentációt a lemezre.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Table-CreateTable-CreateTable.java" >}}