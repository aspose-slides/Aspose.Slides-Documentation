---
title: Formátování textu pomocí VSTO a Aspose.Slides pro Java
linktitle: Formátování textu
type: docs
weight: 30
url: /cs/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- formátování textu
- migrace
- VSTO
- automatizace Office
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Migrujte z automatizace Microsoft Office na Aspose.Slides pro Java a formátujte text v prezentacích PowerPoint (PPT, PPTX) s přesnou kontrolou."
---
{{% alert color="info" %}} 
Někdy potřebujete programově formátovat text na snímcích. Tento článek ukazuje, jak načíst ukázkovou prezentaci s textem na prvním snímku pomocí [VSTO](/slides/cs/java/format-text-using-vsto-and-aspose-slides-for-java/) a [Aspose.Slides for Java](/slides/cs/java/format-text-using-vsto-and-aspose-slides-for-java/). Kód formátuje text ve třetím textovém poli na snímku tak, aby vypadal jako text v posledním textovém poli.
{{% /alert %}} 
## **Formátování textu**
Obě metody VSTO a Aspose.Slides provádějí následující kroky:

1. Otevřete zdrojovou prezentaci.
1. Získejte první snímek.
1. Získejte třetí textové pole.
1. Změňte formátování textu ve třetím textovém poli.
1. Uložte prezentaci na disk.

Níže uvedené snímky ukazují ukázkový snímek před a po spuštění kódu VSTO a Aspose.Slides pro Java.

**Vstupní prezentace** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Příklad kódu VSTO**
Níže uvedený kód ukazuje, jak pomocí VSTO přeformátovat text na snímku.

**Text přeformátovaný pomocí VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Příklad Aspose.Slides pro Java**
Pro formátování textu pomocí Aspose.Slides přidejte font před formátováním textu.

**Výstupní prezentace vytvořená pomocí Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}