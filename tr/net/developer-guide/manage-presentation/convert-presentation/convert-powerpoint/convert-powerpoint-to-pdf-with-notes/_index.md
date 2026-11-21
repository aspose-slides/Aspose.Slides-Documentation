---
title: PowerPoint Sunumlarını Notlarla PDF'e Dönüştür .NET'te
linktitle: Notlu PowerPoint PDF
type: docs
weight: 50
url: /tr/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten PDF'e
- sunumdan PDF'e
- slayttan PDF'e
- PPT'den PDF'e
- PPTX'den PDF'e
- sunumu PDF olarak kaydet
- PPT'yi PDF olarak kaydet
- PPTX'i PDF olarak kaydet
- PPT'yi PDF'e dışa aktar
- PPTX'i PDF'e dışa aktar
- konuşmacı notları
- notlu PDF
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PPT ve PPTX formatlarını notlarla PDF'e dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu rehber, gerekli adımları kapsar ve bu görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sağlar. Makalenin sonunda şunları yapabileceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulayın.
- Çıktı PDF'yi, konuşmacı notlarının dahil edildiğinden ve gereksinimlerinize göre biçimlendirildiğinden emin olmak üzere özelleştirin.

Dışa aktarmadan önce not sayfası boyutlarını ve yönünü ayarlamak için, [Not Sayfası Boyutu](/slides/tr/net/notes-size/) bölümüne bakın.

## **Konuşmacı Notlarıyla PowerPoint'i PDF'e Dönüştür**

`Save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfında PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'e dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yükleyip, konuşmacı notlarını dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırırsınız ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Not Slaytı görünümünde PDF'e nasıl dönüştüreceğinizi gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Konuşmacı notlarını renderlamak için PDF seçeneklerini yapılandırın.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Konuşmacı notlarını slaytın altında renderla.
        }
    };

    // Sunumu konuşmacı notlarıyla PDF olarak kaydedin.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Aspose [Çevrimiçi PowerPoint PDF Dönüştürücü](https://products.aspose.app/slides/tr/conversion) adresine göz atabilirsiniz. 
{{% /alert %}}