---
title: Java ile Notlu PowerPoint Sunumlarını PDF'e Dönüştürme
linktitle: Notlu PowerPoint'ten PDF'e
type: docs
weight: 50
url: /tr/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PDF'e
- sunumu PDF'e
- slaytı PDF'e
- PPT'den PDF'e
- PPTX'ten PDF'e
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'e aktar
- PPTX'i PDF'e aktar
- konuşmacı notları
- notlu PDF
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PPT ve PPTX formatlarını notlu PDF'e dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sağlar. Makalenin sonunda şunları yapabilecek:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulamak.
- Çıktı PDF'yi özelleştirerek konuşmacı notlarının dahil edilmesini ve gereksinimlerinize göre biçimlendirilmesini sağlamak.

## **Konuşmacı Notlarıyla PowerPoint'i PDF'e Dönüştürme**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfında, bir PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'e dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yükleyin, konuşmacı notlarını dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırın ve ardından dosyayı PDF olarak kaydedin. Aşağıdaki kod parçacığı, örnek bir sunumu Not Slayt görünümünde PDF'e nasıl dönüştüreceğinizi gösterir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Konuşmacı notlarını render etmek için PDF seçeneklerini yapılandırın.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Slaytın altında konuşmacı notlarını render et.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Sunumu konuşmacı notlarıyla PDF'e kaydet.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 

Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) adresine göz atmak isteyebilirsiniz. 

{{% /alert %}}