---
title: Android'de PDF veya HTML'den Sunumları İçe Aktarma
linktitle: Sunum İçe Aktarma
type: docs
weight: 60
url: /tr/androidjava/import-presentation/
keywords:
- sunum içe aktarma
- slayt içe aktarma
- PDF içe aktarma
- HTML içe aktarma
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
description: "Aspose.Slides for Android ile Java’da PDF ve HTML belgelerini PowerPoint ve OpenDocument sunumlarına sorunsuz ve yüksek performanslı slayt işleme için içe aktarın."
---
## **Giriş**

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/tr/androidjava/) kullanarak, diğer formatlardaki dosyalardan sunumları içe aktarabilirsiniz. Aspose.Slides, PDF'ler, HTML belgeleri vb. içe aktarmanıza olanak tanıyan [SlideCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/) sınıfını sağlar.

## **PDF'den PowerPoint içe aktar**

Bu durumda, bir PDF'yi PowerPoint sunumuna dönüştürürsünüz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) sınıfının bir örneğini oluşturun.
2. [addFromPdf()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metodunu çağırın ve PDF dosyasını geçirin.
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu Java kodu PDF'den PowerPoint işlemine örnek gösterir:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 

Burada açıklanan sürecin canlı bir uygulaması olduğu için **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasına göz atmak isteyebilirsiniz. 

{{% /alert %}} 

## **HTML'den PowerPoint içe aktar**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürürsünüz.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/) sınıfının bir örneğini oluşturun.
2. [addFromHtml()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metodunu çağırın ve PDF dosyasını geçirin.
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu Java kodu HTML'den PowerPoint işlemine örnek gösterir: 

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

**PDF içe aktarırken tablolar korunur mu ve tespiti geliştirilebilir mi?**

Tablolar içe aktarım sırasında algılanabilir; [PdfImportOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfimportoptions/) sınıfı, tablo tanımını etkinleştiren bir [setDetectTables](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) metodunu içerir. Etkililik, PDF'in yapısına bağlıdır.