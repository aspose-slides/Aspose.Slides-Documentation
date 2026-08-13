---
title: Java'da PDF veya HTML'den Sunum İçe Aktarma
linktitle: Sunumu İçe Aktar
type: docs
weight: 60
url: /tr/java/import-presentation/
keywords:
- sunumu içe aktar
- slaytı içe aktar
- PDF'yi içe aktar
- HTML'yi içe aktar
- PDF'den sunuma
- PDF'den PPT'ye
- PDF'den PPTX'e
- PDF'den ODP'ye
- HTML'den sunuma
- HTML'den PPT'ye
- HTML'den PPTX'e
- HTML'den ODP'ye
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da PDF ve HTML belgelerini PowerPoint ve OpenDocument sunumlarına sorunsuz ve yüksek performansli slayt isleme için zahmetsizce içe aktarın."
---
## **Giriş**

Aspose.Slides kullanarak, diğer formatlardaki dosyalardan sunumları içe aktarabilirsiniz. Aspose.Slides, PDF ve HTML belgelerinden sunumları içe aktarmanızı sağlayan [SlideCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/) sınıfını sunar.

## **PDF'den PowerPoint'e Aktarım**

Bu durumda, bir PDF'yi PowerPoint sunumuna dönüştürürsünüz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/) sınıfının bir örneğini oluşturun. 
2. [addFromPdf()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metodunu çağırın ve PDF dosyasını geçirin. 
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu Java kodu, PDF'den PowerPoint'e işlemini gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="İpucu" color="info" %}} 

**Aspose ücretsiz** [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasını inceleyebilirsiniz; çünkü burada açıklanan sürecin canlı bir uygulamasıdır. 

{{% /alert %}} 

## **HTML'den PowerPoint'e Aktarım**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürürsünüz.

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/) sınıfının bir örneğini oluşturun. 
2. [addFromHtml()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metodunu çağırın ve HTML belgesi içeren bir akış geçirin. 
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu Java kodu, HTML'den PowerPoint'e işlemini gösterir: 

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

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

### PDF içe aktarılırken tablolar korunur mu ve algılamaları iyileştirilebilir mi?

İçe aktarım sırasında tablolar algılanabilir; [PdfImportOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfimportoptions/) sınıfı, tablo tanımını etkinleştiren bir [setDetectTables](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) metoduna sahiptir. Etkinlik, PDF'nin yapısına bağlıdır.

{{% alert title="Not" color="warning" %}} 

Aspose.Slides ile HTML'yi diğer popüler dosya formatlarına da dönüştürebilirsiniz: 

* [HTML'den görüntüye](https://products.aspose.com/slides/tr/java/conversion/html-to-image/)
* [HTML'den JPG'ye](https://products.aspose.com/slides/tr/java/conversion/html-to-jpg/)
* [HTML'den XML'e](https://products.aspose.com/slides/tr/java/conversion/html-to-xml/)
* [HTML'den TIFF'e](https://products.aspose.com/slides/tr/java/conversion/html-to-tiff/)

{{% /alert %}}