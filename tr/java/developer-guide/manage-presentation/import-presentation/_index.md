---
title: Java’da PDF veya HTML’den Sunumları İçe Aktarma
linktitle: Sunumu İçe Aktar
type: docs
weight: 60
url: /tr/java/import-presentation/
keywords:
- sunum içe aktar
- slayt içe aktar
- PDF içe aktar
- HTML içe aktar
- PDF’den sunuma
- PDF’den PPT’ye
- PDF’den PPTX’e
- PDF’den ODP’ye
- HTML’den sunuma
- HTML’den PPT’ye
- HTML’den PPTX’e
- HTML’den ODP’ye
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java’da PDF ve HTML belgelerini PowerPoint ve OpenDocument sunumlarına sorunsuz ve yüksek performanslı slayt işleme için zahmetsizce içe aktarın."
---
## **Giriş**

Aspose.Slides kullanarak, sunumları diğer formatlardaki dosyalardan içe aktarabilirsiniz. Aspose.Slides, PDF ve HTML belgelerinden sunumları içe aktarmanızı sağlayan [SlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/) sınıfını sunar.

## **PDF'ten PowerPoint'e İçe Aktarma**

Bu durumda, bir PDF'yi PowerPoint sunumuna dönüştürürsünüz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/) sınıfının bir örneğini oluşturun. 
2. [addFromPdf()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metodunu çağırıp PDF dosyasını geçirin. 
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu Java kodu PDF'ten PowerPoint'e dönüşümü gösterir:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="İpucu" color="primary" %}} 
Bu süreçte anlatılan işlemin canlı bir uygulamasını görmek için **Aspose ücretsiz** [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasına göz atmak isteyebilirsiniz. 
{{% /alert %}} 

## **HTML'den PowerPoint'e İçe Aktarma**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürürsünüz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/) sınıfının bir örneğini oluşturun. 
2. [addFromHtml()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metodunu çağırıp HTML dosyasını geçirin. 
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu Java kodu HTML'den PowerPoint'e dönüşümü gösterir: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **SSS**

**PDF içe aktarılırken tablolar korunur mu ve algılamaları iyileştirilebilir mi?**

Tablolar içe aktarma sırasında tespit edilebilir; [PdfImportOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfimportoptions/) içinde tablo tanımasını etkinleştiren bir [setDetectTables](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) metodu bulunur. Etkinlik, PDF'nin yapısına bağlıdır.

{{% alert title="Not" color="warning" %}} 
Ayrıca Aspose.Slides'ı HTML'yi diğer popüler dosya formatlarına dönüştürmek için de kullanabilirsiniz: 

* [HTML'den görsele](https://products.aspose.com/slides/tr/java/conversion/html-to-image/)
* [HTML'den JPG'ye](https://products.aspose.com/slides/tr/java/conversion/html-to-jpg/)
* [HTML'den XML'e](https://products.aspose.com/slides/tr/java/conversion/html-to-xml/)
* [HTML'den TIFF'e](https://products.aspose.com/slides/tr/java/conversion/html-to-tiff/)

{{% /alert %}}