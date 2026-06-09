---
title: "PDF veya HTML'den PHP'de Sunumları İçe Aktar"
linktitle: "Sunumu İçe Aktar"
type: docs
weight: 60
url: /tr/php-java/import-presentation/
keywords:
- "sunum içe aktar"
- "slayt içe aktar"
- "PDF içe aktar"
- "HTML içe aktar"
- "PDF'den sunuma"
- "PDF'den PPT'ye"
- "PDF'den PPTX'e"
- "PDF'den ODP'ye"
- "HTML'den sunuma"
- "HTML'den PPT'ye"
- "HTML'den PPTX'e"
- "HTML'den ODP'ye"
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "PDF ve HTML belgelerini PHP'de Aspose.Slides ile PowerPoint ve OpenDocument sunumlarına sorunsuz, yüksek performanslı slayt işleme için içe aktarın."
---
## **Giriş**

Kullanarak [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/tr/php-java/), dosyaları diğer formatlardan içe aktarabilirsiniz. Aspose.Slides, PDF'lerden, HTML belgelerinden vb. sunumları içe aktarmanıza olanak tanıyan [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) sınıfını sağlar.

## **PDF'ten PowerPoint İçe Aktarma**

Bu durumda, bir PDF'yi PowerPoint sunumuna dönüştürebilirsiniz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Presentation sınıfının bir örneğini oluşturun.  
2. [addFromPdf()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metodunu çağırın ve PDF dosyasını geçirin.  
3. [save()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanarak dosyayı PowerPoint formatında kaydedin.

Bu PHP kodu, PDF'ten PowerPoint'e dönüşüm işlemini göstermektedir:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert  title="Tip" color="primary" %}} 
Burada açıklanan sürecin canlı bir uygulaması olduğu için **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasına göz atmak isteyebilirsiniz. 
{{% /alert %}} 

## **HTML'den PowerPoint İçe Aktarma**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürebilirsiniz.

1. Presentation sınıfının bir örneğini oluşturun.  
2. [addFromHtml()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metodunu çağırın ve PDF dosyasını geçirin.  
3. [save()](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanarak dosyayı PowerPoint formatında kaydedin.

Bu PHP kodu, HTML'den PowerPoint'e dönüşüm işlemini göstermektedir:

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **SSS**

**PDF içe aktarırken tablolar korunur mu ve tespitleri geliştirilebilir mi?**

Tablolar içe aktarma sırasında tespit edilebilir; [PdfImportOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfimportoptions/) içinde tablo tanımasını etkinleştiren bir [setDetectTables](https://reference.aspose.com/slides/tr/php-java/aspose.slides/pdfimportoptions/#setDetectTables) metodu bulunur. Etkinlik, PDF'nin yapısına bağlıdır.

{{% alert title="Not" color="warning" %}} 
HTML'i diğer popüler dosya formatlarına dönüştürmek için Aspose.Slides'ı da kullanabilirsiniz: 

* [HTML'den görsele](https://products.aspose.com/slides/tr/php-java/conversion/html-to-image/)  
* [HTML'den JPG'ye](https://products.aspose.com/slides/tr/php-java/conversion/html-to-jpg/)  
* [HTML'den XML'e](https://products.aspose.com/slides/tr/php-java/conversion/html-to-xml/)  
* [HTML'den TIFF'e](https://products.aspose.com/slides/tr/php-java/conversion/html-to-tiff/)  

{{% /alert %}}