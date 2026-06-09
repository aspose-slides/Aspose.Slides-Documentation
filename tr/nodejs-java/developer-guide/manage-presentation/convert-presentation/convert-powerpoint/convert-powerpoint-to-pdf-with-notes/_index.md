---
title: JavaScript'te Notlarla PowerPoint Sunumlarını PDF'ye Dönüştür
linktitle: Notlarla PowerPoint'ten PDF
type: docs
weight: 50
url: /tr/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PDF'ye
- sunumdan PDF'ye
- slayttan PDF'ye
- PPT'den PDF'ye
- PPTX'ten PDF'ye
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'ye aktar
- PPTX'i PDF'ye aktar
- konuşmacı notları
- notlu PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak JavaScript'te PPT ve PPTX formatlarını notlu PDF'ye dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla birlikte PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makale sonunda şunları başarabileceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulamak.
- Çıktı PDF'sini, konuşmacı notlarının dahil edildiğinden ve ihtiyaçlarınıza göre biçimlendirildiğinden emin olmak için özelleştirmek.

## **Notlarla PowerPoint'i PDF'ye Dönüştür**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfında, bir PPT veya PPTX sunumunu konuşmacı notlarıyla birlikte PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yükleyin, konuşmacı notlarını eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırın ve ardından dosyayı PDF olarak kaydedin. Aşağıdaki kod parçacığı, örnek bir sunumu Notlar Slayt görünümünde PDF'ye dönüştürmeyi göstermektedir.

```js
let presentation = new asposeSlides.Presentation("sample.pptx");

// Konuşmacı notlarını renderlamak için PDF seçeneklerini yapılandır.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Konuşmacı notlarını slaytın altında göster.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Sunumu konuşmacı notlarıyla birlikte PDF olarak kaydet.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="primary" %}} 
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) adresine göz atabilirsiniz. 
{{% /alert %}}