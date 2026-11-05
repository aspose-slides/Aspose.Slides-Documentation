---
title: Java'da Notlarla PowerPoint Sunumlarını PDF'e Dönüştür
linktitle: Notlarla PowerPoint PDF'e
type: docs
weight: 50
url: /tr/java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PPT ve PPTX formatlarını notlarla PDF'e dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu rehber, gerekli adımları kapsar ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makalenin sonunda aşağıdakileri yapabileceksiniz:

- PowerPoint slaytlarını konuşmacı notlarını koruyarak PDF belgelerine dönüştürme sürecini uygulayın.
- Çıktı PDF'yi, konuşmacı notlarının dahil edilmesini ve gereksinimlerinize göre biçimlendirilmesini sağlamak için özelleştirin.

Dışa aktarmadan önce not sayfası boyutlarını ve yönünü ayarlamak için [Not Sayfası Boyutu](/slides/tr/java/notes-size/) bölümüne bakın.

## **Notlarla PowerPoint'i PDF'e Dönüştür**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfında PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'e dönüştürmek için kullanılabilir. Aspose.Slides ile yalnızca sunumu yükler, konuşmacı notlarını dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırır ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Not Slayt görünümünde PDF'e nasıl dönüştüreceğinizi gösterir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Konuşmacı notlarını oluşturmak için PDF seçeneklerini yapılandır.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Konuşmacı notlarını slaytın altında oluştur.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Aspose [Çevrimiçi PowerPoint'ten PDF'ye Dönüştürücü](https://products.aspose.app/slides/tr/conversion) aracına göz atmak isteyebilirsiniz.
{{% /alert %}}