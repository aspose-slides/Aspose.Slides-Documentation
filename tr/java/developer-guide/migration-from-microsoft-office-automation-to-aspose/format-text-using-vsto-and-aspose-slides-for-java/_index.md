---
title: VSTO ve Aspose.Slides for Java Kullanarak Metin Biçimlendirme
linktitle: Metin Biçimlendirme
type: docs
weight: 30
url: /tr/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- metin biçimlendirme
- göç
- VSTO
- Office otomasyonu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Microsoft Office otomasyonundan Aspose.Slides for Java'a geçiş yapın ve PowerPoint (PPT, PPTX) sunumlarındaki metni hassas kontrol ile biçimlendirin."
---
{{% alert color="primary" %}} 

Bazen slaytlardaki metni programlı olarak biçimlendirmeniz gerekir. Bu makale, ilk slaytta bazı metinler bulunan örnek bir sunumu ya [VSTO](/slides/tr/java/format-text-using-vsto-and-aspose-slides-for-java/) ya da [Aspose.Slides for Java](/slides/tr/java/format-text-using-vsto-and-aspose-slides-for-java/) kullanarak nasıl okuyacağınızı gösterir. Kod, slayttaki üçüncü metin kutusundaki metni, son metin kutusundaki metin gibi görünmesi için biçimlendirir.

{{% /alert %}} 
## **Metin Biçimlendirme**
Hem VSTO hem de Aspose.Slides yöntemleri aşağıdaki adımları izler:

1. Kaynak sunumu açın.
1. İlk slayta erişin.
1. Üçüncü metin kutusuna erişin.
1. Üçüncü metin kutusundaki metnin biçimini değiştirin.
1. Sunumu diske kaydedin.

Aşağıdaki ekran görüntüleri, VSTO ve Aspose.Slides for Java kodunun çalıştırılmasından önce ve sonra örnek slayı gösterir.

**Girdi sunumu** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO Kod Örneği**
Aşağıdaki kod, VSTO kullanarak bir slayttaki metni yeniden biçimlendirmenin yolunu gösterir.

**VSTO ile yeniden biçimlendirilmiş metin** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java Örneği**
Aspose.Slides ile metni biçimlendirmek için, metni biçimlendirmeden önce yazı tipini ekleyin.

**Aspose.Slides ile oluşturulan çıktı sunumu** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}