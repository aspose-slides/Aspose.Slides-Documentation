---
title: PowerPoint Sunumlarını Notlarla .NET'te PDF'ye Dönüştür
linktitle: PowerPoint'ten PDF'ye Notlarla
type: docs
weight: 50
url: /tr/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten PDF'ye
- sunumu PDF'ye
- slaytı PDF'ye
- PPT'den PDF'ye
- PPTX'den PDF'ye
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'ye aktar
- PPTX'i PDF'ye aktar
- konuşmacı notları
- notlu PDF
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PPT ve PPTX formatlarını notlarla PDF'ye dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu rehber gerekli adımları kapsayacak ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sağlayacaktır. Makalenin sonunda, şunları yapabilecek durumda olacaksınız:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulayın.
- Çıktı PDF'yi, konuşmacı notlarının dahil edildiğinden ve gereksinimlerinize göre biçimlendirildiğinden emin olmak için özelleştirin.

## **Notlarla PowerPoint'i PDF'ye Dönüştür**

`Save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfında, PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile, sunumu sadece yükler, konuşmacı notlarını eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırırsınız ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Notlu Slayt görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Konuşmacı notlarını işlemek için PDF seçeneklerini yapılandır.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Slaytın altına konuşmacı notlarını ekle.
        }
    };

    // Sunumu konuşmacı notlarıyla PDF olarak kaydet.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion) aracını incelemek isteyebilirsiniz. 
{{% /alert %}}