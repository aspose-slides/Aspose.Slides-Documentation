---
title: PowerPoint Sunumlarını Notlarla PDF'e Dönüştürme (PHP)
linktitle: Notlu PowerPoint PDF'e
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
- PPTX'yi PDF olarak kaydet
- PPT'yi PDF'e dışa aktar
- PPTX'yi PDF'e dışa aktar
- konuşmacı notları
- notlu PDF
- PHP
- Aspose.Slides
description: "Java üzerinden PHP için Aspose.Slides kullanarak PPT ve PPTX formatlarını notlu PDF'e dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu rehber gerekli adımları kapsar ve görevi verimli bir şekilde tamamlamanıza yardımcı olacak kod örnekleri sunar. Makalenin sonunda şunları yapabilecek duruma geleceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulamak.
- Çıktı PDF'sini, konuşmacı notlarının dahil edilmesini ve gereksinimlerinize göre biçimlendirilmesini sağlamak için özelleştirmek.

## **Notlu PowerPoint'i PDF'e Dönüştürme**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfında PPT veya PPTX sunumunu konuşmacı notları içeren bir PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yüklersiniz, konuşmacı notlarını dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırırsınız ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Notlu Slayt görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

```php
$presentation = new Presentation("sample.pptx");

// Konuşmacı notlarını render etmek için PDF seçeneklerini yapılandır.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // Konuşmacı notlarını slaytın altında render et.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// Sunumu konuşmacı notlarıyla PDF olarak kaydet.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="primary" %}} 
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) aracını incelemek isteyebilirsiniz. 
{{% /alert %}}