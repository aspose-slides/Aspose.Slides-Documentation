---
title: Formatera text med VSTO och Aspose.Slides för Java
linktitle: Formatera text
type: docs
weight: 30
url: /sv/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- formatera text
- migration
- VSTO
- Office-automatisering
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Migrera från Microsoft Office-automatisering till Aspose.Slides for Java och formatera text i PowerPoint (PPT, PPTX) presentationer med exakt kontroll."
---
{{% alert color="info" %}} 

Ibland behöver du formatera text på bilder programmatiskt. Denna artikel visar hur du läser en exempelpresentation med lite text på den första bilden med antingen [VSTO](/slides/sv/java/format-text-using-vsto-and-aspose-slides-for-java/) och [Aspose.Slides for Java](/slides/sv/java/format-text-using-vsto-and-aspose-slides-for-java/). Koden formaterar texten i den tredje textrutan på bilden så att den ser ut som texten i den sista textrutan.

{{% /alert %}} 
## **Formatera text**
Både VSTO- och Aspose.Slides-metoderna utför följande steg:

1. Öppna källpresentationen.
1. Få åtkomst till den första bilden.
1. Få åtkomst till den tredje textrutan.
1. Ändra formateringen av texten i den tredje textrutan.
1. Spara presentationen till disk.

Skärmbilderna nedan visar exempelbilden före och efter körning av VSTO- och Aspose.Slides for Java-koden.

**Inmatningspresentationen** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO-kodexempel**
Koden nedan visar hur man omformaterar text på en bild med VSTO.

**Texten omformaterad med VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java-exempel**
För att formatera text med Aspose.Slides, lägg till teckensnittet innan du formaterar texten.

**Utdata-presentationen skapad med Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}