---
title: PowerPoint Sunumlarını Notlarla PDF'e Dönüştürme (PHP)
linktitle: PowerPoint'ten Notlarla PDF'e
type: docs
weight: 50
url: /tr/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint PDF'e
- sunumu PDF'e
- slaytı PDF'e
- PPT PDF'e
- PPTX PDF'e
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'e dışa aktar
- PPTX'i PDF'e dışa aktar
- konuşmacı notları
- notlu PDF
- PHP
- Aspose.Slides
description: "PPT ve PPTX formatlarını Java aracılığıyla PHP için Aspose.Slides kullanarak notlarla PDF'e dönüştürür. Profesyonel sunumlar için sayfa düzenlerini ve konuşmacı notlarını korur."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla birlikte PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu kılavuz gerekli adımları açıklayacak ve görevi verimli bir şekilde tamamlamanıza yardımcı olacak kod örnekleri sunacak. Makalenin sonunda şunları yapabilecek duruma geleceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme işlemini uygulamak.
- Çıktı PDF'yi, konuşmacı notlarının dahil edilmesini ve istediğiniz biçimde düzenlenmesini sağlayacak şekilde özelleştirmek.

Not sayfasının boyutlarını ve yönünü dışa aktarmadan önce ayarlamak için [Notes Page Size](/slides/tr/php-java/notes-size/) bölümüne bakın.

## **Notlarla PowerPoint'i PDF'e Dönüştür**

[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfındaki `save` yöntemi, bir PPT veya PPTX sunumunu konuşmacı notlarıyla birlikte PDF'e dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yükleyip, konuşmacı notlarını içerecek şekilde [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırır ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, bir örnek sunumu Not Slaytı görünümünde PDF'e nasıl dönüştüreceğinizi gösterir.

```php
$presentation = new Presentation("sample.pptx");

// Konuşmacı notlarını oluşturmak için PDF seçeneklerini yapılandır.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Konuşmacı notlarını slaytın altında oluştur.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Sunumu konuşmacı notlarıyla PDF olarak kaydet.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Not" %}}
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) adresini incelemek isteyebilirsiniz.
{{% /alert %}}