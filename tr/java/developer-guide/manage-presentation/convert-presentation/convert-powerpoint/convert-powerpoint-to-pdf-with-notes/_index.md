---
title: "Java'da Notlu PowerPoint Sunumlarını PDF'ye Dönüştürme"
linktitle: "Notlu PowerPoint'ten PDF'ye"
type: docs
weight: 50
url: /tr/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- "PowerPoint dönüştür"
- "sunum dönüştür"
- "slayt dönüştür"
- "PPT dönüştür"
- "PPTX dönüştür"
- "PowerPoint'ten PDF'ye"
- "sunumu PDF'ye"
- "slaytı PDF'ye"
- "PPT'den PDF'ye"
- "PPTX'ten PDF'ye"
- "sunumu PDF olarak kaydet"
- "PPT'yi PDF olarak kaydet"
- "PPTX'i PDF olarak kaydet"
- "PPT'yi PDF'ye dışa aktar"
- "PPTX'i PDF'ye dışa aktar"
- "konuşmacı notları"
- "notlu PDF"
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PPT ve PPTX formatlarını notlu PDF'ye dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makalenin sonunda şunları yapabilecek duruma geleceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulayın.  
- Çıktı PDF'yi, konuşmacı notlarının dahil edildiğinden ve gereksinimlerinize göre biçimlendirildiğinden emin olmak için özelleştirin.

## **Konuşmacı Notlarıyla PowerPoint'ten PDF'ye Dönüştürme**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfında PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile yalnızca sunumu yüklersiniz, konuşmacı notlarını eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırırsınız ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Notlar Slayt görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

```java
Presentation presentation = new Presentation("sample.pptx");

// Konuşmacı notlarını işlemek için PDF seçeneklerini yapılandır.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Konuşmacı notlarını slaytın altında işleyin.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Sunumu konuşmacı notlarıyla PDF'ye kaydet.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) aracını incelemek isteyebilirsiniz. 
{{% /alert %}}