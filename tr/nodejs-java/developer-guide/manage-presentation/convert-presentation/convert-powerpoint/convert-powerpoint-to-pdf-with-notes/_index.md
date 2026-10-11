---
title: PowerPoint Sunumlarını Notlarla PDF'ye JavaScript'te Dönüştür
linktitle: PowerPoint'i Notlarla PDF'ye
type: docs
weight: 50
url: /tr/nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
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

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu kılavuz gerekli adımları kapsar ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makalenin sonunda şu yeteneklere sahip olacaksınız:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulamak.
- Çıktı PDF'yi özelleştirerek konuşmacı notlarının dahil edilmesini ve gereksinimlerinize göre biçimlendirilmesini sağlamak.

Dışa aktarmadan önce not sayfası boyutlarını ve yönünü ayarlamak için [Not Sayfası Boyutu](/slides/tr/nodejs-java/notes-size/) bölümüne bakın.

## **PowerPoint'i Notlarla PDF'ye Dönüştür**

`save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfında bir PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yükler, konuşmacı notlarını eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırır ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Not Slayt görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Konuşmacı notlarını işlemek için PDF seçeneklerini yapılandır.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Konuşmacı notlarını slaytın altına getir.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Konuşmacı notlarıyla sunumu PDF olarak kaydet.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}

Aspose [Çevrimiçi PowerPoint'ten PDF'ye Dönüştürücü](https://products.aspose.app/slides/tr/conversion) adresine göz atmak isteyebilirsiniz.

{{% /alert %}}