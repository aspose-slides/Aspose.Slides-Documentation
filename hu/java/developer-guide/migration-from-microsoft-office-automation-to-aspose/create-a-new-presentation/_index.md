---
title: VSTO és Aspose.Slides for Java használata új prezentációk létrehozásához
linktitle: Új prezentáció létrehozása
type: docs
weight: 10
url: /hu/java/create-a-new-presentation/
keywords:
- prezentáció létrehozása
- új prezentáció
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Migráljon a Microsoft Office automatizálásról az Aspose.Slides for Java-ra, és hozzon létre új PowerPoint (PPT, PPTX) prezentációkat Java-ban tiszta, megbízható kóddal."
---
{{% alert color="info" %}} 

A VSTO-t úgy fejlesztették ki, hogy a fejlesztők olyan alkalmazásokat készíthessenek, amelyek a Microsoft Office-ban futtathatók. A VSTO COM-alapú, de egy .NET objektumba van beágyazva, így .NET alkalmazásokban is használható. A VSTO-hoz .NET keretrendszer támogatásra, valamint a Microsoft Office CLR-alapú futtatókörnyezetre van szükség. Bár használható Microsoft Office kiegészítők készítésére, szinte lehetetlen szerveroldali komponensként alkalmazni. Emellett komoly telepítési problémákkal is küzd.

Az Aspose.Slides for Java egy olyan komponens, amely a Microsoft PowerPoint prezentációk manipulálására használható, akárcsak a VSTO, de több előnnyel is rendelkezik:

- Az Aspose.Slides csak kezelt kódot tartalmaz, és nem igényel Microsoft Office futtatókörnyezet telepítését.
- Használható kliensoldali vagy szerveroldali komponensként.
- A telepítés egyszerű, mivel az Aspose.Slides egyetlen JAR fájlban található.

{{% /alert %}} 
## **Prezentáció létrehozása**
Alább két kódrészlet látható, amely bemutatja, hogyan lehet a VSTO-t és az Aspose.Slides for Java-t ugyanarra a célra felhasználni. Az első példát [VSTO](/slides/hu/java/create-a-new-presentation/); a [a második példát](/slides/hu/java/create-a-new-presentation/) az Aspose.Slides használja.
### **VSTO példa**
**A VSTO kimenet** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Aspose.Slides for Java példa**
**Az Aspose.Slides kimenete** 

![todo:image_alt_text](create-a-new-presentation_2.png)



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}