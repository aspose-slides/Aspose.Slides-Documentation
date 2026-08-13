---
title: VSTO ve Aspose.Slides for Java Kullanarak Metni Biçimlendirme
linktitle: Metni Biçimlendirme
type: docs
weight: 30
url: /tr/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- metni biçimlendirme
- göç
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for Java'a geçiş yapın ve PowerPoint (PPT, PPTX) sunumlarında metni hassas kontrol ile biçimlendirin."
---
{{% alert color="info" %}} 

Bazen slaytlardaki metni programlı bir şekilde biçimlendirmeniz gerekir. Bu makale, ilk slaytta bazı metinler bulunan örnek bir sunumu ya [VSTO](/slides/tr/java/format-text-using-vsto-and-aspose-slides-for-java/) ya da [Aspose.Slides for Java](/slides/tr/java/format-text-using-vsto-and-aspose-slides-for-java/) kullanarak nasıl okuyacağınızı gösterir. Kod, slayttaki üçüncü metin kutusundaki metni son metin kutusundaki gibi biçimlendirir.

{{% /alert %}} 
## **Metni Biçimlendirme**
VSTO ve Aspose.Slides yöntemleri aşağıdaki adımları izler:

1. Kaynak sunumu aç.
1. İlk slayta eriş.
1. Üçüncü metin kutusuna eriş.
1. Üçüncü metin kutusundaki metnin biçimini değiştir.
1. Sunumu diske kaydet.

Aşağıdaki ekran görüntüleri, VSTO ve Aspose.Slides for Java kodunun çalıştırılmasından önce ve sonra örnek slaytı gösterir.

**Girdi sunumu** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO Kod Örneği**
Aşağıdaki kod, VSTO kullanarak bir slayttaki metni nasıl yeniden biçimlendireceğinizi gösterir.

**VSTO ile yeniden biçimlendirilmiş metin** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java Örneği**
Aspose.Slides ile metni biçimlendirmek için, metni biçimlendirmeden önce fontu ekleyin.

**Aspose.Slides ile oluşturulan çıktı sunumu** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}