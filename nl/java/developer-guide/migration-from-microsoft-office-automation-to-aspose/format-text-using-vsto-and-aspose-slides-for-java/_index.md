---
title: Tekst opmaken met VSTO en Aspose.Slides voor Java
linktitle: Tekst opmaken
type: docs
weight: 30
url: /nl/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- tekst opmaken
- migratie
- VSTO
- Office-automatisering
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Migreer van Microsoft Office-automatisering naar Aspose.Slides voor Java en formatteer tekst in PowerPoint‑presentaties (PPT, PPTX) met nauwkeurige controle."
---
{{% alert color="info" %}} 
Soms moet je de tekst op dia's programmatisch opmaken. Dit artikel laat zien hoe je een voorbeeldpresentatie met wat tekst op de eerste dia kunt lezen met behulp van zowel [VSTO](/slides/nl/java/format-text-using-vsto-and-aspose-slides-for-java/) en [Aspose.Slides for Java](/slides/nl/java/format-text-using-vsto-and-aspose-slides-for-java/). De code formatteert de tekst in het derde tekstvak op de dia zodat deze eruitziet als de tekst in het laatste tekstvak.
{{% /alert %}} 
## **Tekst opmaken**
Zowel de VSTO- als de Aspose.Slides‑methoden doorlopen de volgende stappen:

1. Open de bronpresentatie.
1. Open de eerste dia.
1. Open het derde tekstvak.
1. Wijzig de opmaak van de tekst in het derde tekstvak.
1. Sla de presentatie op op schijf.

De schermafbeeldingen hieronder tonen de voorbeelddia vóór en na het uitvoeren van de VSTO- en Aspose.Slides‑for‑Java‑code.

**De invoerpresentatie** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO‑codevoorbeeld**
De onderstaande code laat zien hoe je tekst op een dia opnieuw kunt opmaken met VSTO.

**De tekst opnieuw opgemaakt met VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}

### **Aspose.Slides for Java‑voorbeeld**
Om tekst op te maken met Aspose.Slides, voeg je eerst het lettertype toe voordat je de tekst opmaakt.

**De uitvoerpresentatie gemaakt met Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}