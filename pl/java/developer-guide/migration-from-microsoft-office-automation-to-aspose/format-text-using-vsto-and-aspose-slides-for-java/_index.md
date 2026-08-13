---
title: Formatowanie tekstu przy użyciu VSTO i Aspose.Slides dla Java
linktitle: Formatowanie tekstu
type: docs
weight: 30
url: /pl/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- formatowanie tekstu
- migracja
- VSTO
- automatyzacja Office
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Migracja z automatyzacji Microsoft Office do Aspose.Slides dla Java i formatowanie tekstu w prezentacjach PowerPoint (PPT, PPTX) z precyzyjną kontrolą."
---
{{% alert color="info" %}} 

Czasami trzeba formatować tekst na slajdach programowo. Ten artykuł pokazuje, jak odczytać przykładową prezentację z tekstem na pierwszym slajdzie, używając [VSTO](/slides/pl/java/format-text-using-vsto-and-aspose-slides-for-java/) i [Aspose.Slides for Java](/slides/pl/java/format-text-using-vsto-and-aspose-slides-for-java/). Kod formatuje tekst w trzecim polu tekstowym na slajdzie, aby wyglądał jak tekst w ostatnim polu tekstowym.

{{% /alert %}} 
## **Formatowanie tekstu**
Obie metody VSTO i Aspose.Slides wykonują następujące kroki:

1. Otwórz źródłową prezentację. 
1. Uzyskaj dostęp do pierwszego slajdu. 
1. Uzyskaj dostęp do trzeciego pola tekstowego. 
1. Zmień formatowanie tekstu w trzecim polu tekstowym. 
1. Zapisz prezentację na dysku. 

Zrzuty ekranu poniżej pokazują przykładowy slajd przed i po wykonaniu kodu VSTO oraz Aspose.Slides for Java.

**Prezentacja wejściowa** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Przykład kodu VSTO**
Poniższy kod pokazuje, jak sformatować tekst na slajdzie przy użyciu VSTO.

**Tekst sformatowany przy użyciu VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Przykład Aspose.Slides for Java**
Aby sformatować tekst przy użyciu Aspose.Slides, najpierw dodaj czcionkę przed formatowaniem tekstu.

**Prezentacja wyjściowa utworzona przy użyciu Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}