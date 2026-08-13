---
title: Szöveg formázása VSTO és Aspose.Slides for Java használatával
linktitle: Szöveg formázása
type: docs
weight: 30
url: /hu/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- szöveg formázása
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for Java-ra, és pontos vezérléssel formázza a szöveget PowerPoint (PPT, PPTX) prezentációkban."
---
{{% alert color="info" %}} 

Néha programozottan kell a diák szövegét formázni. Ez a cikk bemutatja, hogyan olvassunk be egy mintaprezentációt, amelynek első diáján szöveg van, a [VSTO](/slides/hu/java/format-text-using-vsto-and-aspose-slides-for-java/) vagy az [Aspose.Slides for Java](/slides/hu/java/format-text-using-vsto-and-aspose-slides-for-java/) használatával. A kód a dián található harmadik szövegdoboz szövegét úgy formázza, hogy az megegyezzen az utolsó szövegdoboz szövegével.

{{% /alert %}} 
## **Szöveg formázása**
A VSTO és az Aspose.Slides módszerek a következő lépéseket követik:

1. Nyissa meg a forrásprezentációt.
1. Hozza elérhetővé az első diát.
1. Hozza elérhetővé a harmadik szövegdobozt.
1. Módosítsa a szöveg formázását a harmadik szövegdobozban.
1. Mentse el a prezentációt a lemezen.

Az alábbi képernyőképek a mintadiát mutatják a VSTO és az Aspose.Slides for Java kód futtatása előtt és után.

**A bemeneti prezentáció** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO kódpélda**
Az alábbi kód bemutatja, hogyan formázhatjuk újra a szöveget egy dián a VSTO segítségével.

**A VSTO-val újraformázott szöveg** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java példa**
A szöveg Aspose.Slides-szel történő formázásához adja hozzá a betűtípust a szöveg formázása előtt.

**Az Aspose.Slides által létrehozott kimeneti prezentáció** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}