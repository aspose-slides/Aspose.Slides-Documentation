---
title: Új prezentációk létrehozása VSTO és Aspose.Slides for Java használatával
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
description: "Migráljon a Microsoft Office automatizálásból az Aspose.Slides for Java-ra, és hozzon létre új PowerPoint (PPT, PPTX) prezentációkat Java-ban tiszta, megbízható kóddal."
---
{{% alert color="primary" %}} 

Az VSTO-t azért fejlesztették ki, hogy a fejlesztők olyan alkalmazásokat építhessenek, melyek a Microsoft Office-on belül futtathatók. Az VSTO COM-alapú, de egy .NET objektumba van becsomagolva, így .NET alkalmazásokban is használható. Az VSTO‑nek szüksége van a .NET keretrendszer támogatására, valamint a Microsoft Office CLR‑alapú futtatókörnyezetére. Bár használható Microsoft Office kiegészítők készítésére, szinte lehetetlen szerveroldali komponensként alkalmazni. Emellett súlyos telepítési problémákkal is rendelkezik.

Aspose.Slides for Java egy olyan komponens, amely a Microsoft PowerPoint prezentációk manipulálására használható, akárcsak az VSTO, de több előnnyel rendelkezik:

- Az Aspose.Slides csak kezelt kódot tartalmaz, és nem igényli a Microsoft Office futtatókörnyezet telepítését.
- Használható kliensoldali vagy szerveroldali komponensként.
- A telepítés egyszerű, mivel az Aspose.Slides egyetlen jar fájlban van.

{{% /alert %}} 
## **Prezentáció létrehozása**
Alább két kódrészlet látható, amely bemutatja, hogyan használhatók az VSTO és az Aspose.Slides for Java a ugyanarra a célra. Az első példa a [VSTO](/slides/hu/java/create-a-new-presentation/); a [második példa](/slides/hu/java/create-a-new-presentation/) az Aspose.Slides‑et használja.
### **VSTO példa**
**Az VSTO kimenete** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Aspose.Slides for Java példa**
**Az Aspose.Slides kimenete** 

![todo:image_alt_text](create-a-new-presentation_2.png)



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}