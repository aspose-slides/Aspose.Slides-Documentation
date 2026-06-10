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
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for Java-ra, és formázza a szöveget a PowerPoint (PPT, PPTX) prezentációkban pontos vezérléssel."
---
{{% alert color="primary" %}} 

Néha szükséges programozott módon formázni a szöveget a diákon. Ez a cikk bemutatja, hogyan olvassunk be egy mintaprezentációt, amelynek első diáján van szöveg, a [VSTO](/slides/hu/java/format-text-using-vsto-and-aspose-slides-for-java/) és az [Aspose.Slides for Java](/slides/hu/java/format-text-using-vsto-and-aspose-slides-for-java/) segítségével. A kód a dián lévő harmadik szövegdoboz szövegét úgy formázza, hogy az az utolsó szövegdoboz szövegéhez hasonló legyen.

{{% /alert %}} 
## **Szöveg formázása**
A VSTO és az Aspose.Slides módszerek a következő lépéseket követik:

1. Nyissa meg a forrásprezentációt.
1. Nyissa meg az első diát.
1. Nyissa meg a harmadik szövegdobozt.
1. Módosítsa a harmadik szövegdoboz szövegének formázását.
1. Mentse a prezentációt a lemezre.

Az alábbi képernyőképek a mintadiát mutatják a VSTO és az Aspose.Slides for Java kód végrehajtása előtti és utáni állapotban.

**A bemeneti prezentáció** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO kódpélda**
Az alábbi kód bemutatja, hogyan formázható újra a szöveg egy dián a VSTO használatával.

**A VSTO-val újraformázott szöveg** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java példa**
A szöveg formázásához az Aspose.Slides használatával először adja meg a betűtípust, mielőtt formázná a szöveget.

**Az Aspose.Slides által létrehozott kimeneti prezentáció** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}