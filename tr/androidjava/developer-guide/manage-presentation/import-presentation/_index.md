---
title: Android'de PDF veya HTML'den Sunumları İçe Aktar
linktitle: Sunumu İçe Aktar
type: docs
weight: 60
url: /tr/androidjava/import-presentation/
keywords:
- sunum içe aktarma
- slayt içe aktarma
- PDF içe aktar
- HTML içe aktar
- PDF'den sunuma
- PDF'den PPT
- PDF'den PPTX
- PDF'den ODP
- HTML'den sunuma
- HTML'den PPT
- HTML'den PPTX
- HTML'den ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Java'da Aspose.Slides for Android ile PDF ve HTML belgelerini PowerPoint ve OpenDocument sunumlarına sorunsuz ve yüksek performanslı slayt işleme için içe aktarın."
---
## **Giriş**

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/tr/androidjava/) kullanarak, diğer formatlardaki dosyalardan sunumları içe aktarabilirsiniz. Aspose.Slides, PDF’lerden, HTML belgelerinden vb. sunumları içe aktarmanızı sağlayan [SlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/) sınıfını sunar.

## **PDF'den PowerPoint İçe Aktarma**

Bu durumda, bir PDF dosyasını PowerPoint sunumuna dönüştürebilirsiniz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) sınıfının bir örneğini oluşturun.  
2. [addFromPdf()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metodunu çağırın ve PDF dosyasını geçirin.  
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu Java kodu PDF'ten PowerPoint'e dönüşüm işlemini gösterir:

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

{{% alert  title="Tip" color="info" %}} 
Buradaki sürecin canlı bir uygulaması olduğundan, **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasına göz atmak isteyebilirsiniz. 
{{% /alert %}} 

## **HTML'den PowerPoint İçe Aktarma**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) sınıfının bir örneğini oluşturun.  
2. [addFromHtml()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metodunu çağırın ve HTML belgesini içeren bir akış geçirin.  
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu Java kodu HTML'den PowerPoint'e dönüşüm işlemini gösterir: 

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

### PDF içe aktarılırken tablolar korunur mu ve tespiti iyileştirilebilir mi?

Tablolar içe aktarım sırasında algılanabilir; [PdfImportOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfimportoptions/) içinde bulunan [setDetectTables](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) metodu tablo tanımasını etkinleştirir. Etkinlik, PDF’nin yapısına bağlıdır.