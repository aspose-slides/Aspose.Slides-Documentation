---
title: .NET'te Notlarla PowerPoint Sunumlarını PDF'ye Dönüştürün
linktitle: Notlarla PowerPoint'ten PDF'ye
type: docs
weight: 50
url: /tr/net/convert-powerpoint-to-pdf-with-notes/
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
- notlarla PDF
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PPT ve PPTX formatlarını notlarla PDF'ye dönüştürün. Profesyonel sunumlar için düzenleri ve konuşmacı notlarını koruyun."
---
## **Genel Bakış**

Bu makalede, Aspose.Slides kullanarak PowerPoint sunumlarını konuşmacı notlarıyla PDF formatına nasıl dönüştüreceğinizi öğreneceksiniz. Bu rehber, gerekli adımları kapsar ve görevi verimli bir şekilde gerçekleştirmenize yardımcı olacak kod örnekleri sunar. Makalenin sonunda, şunları yapabileceksiniz:

- Konuşmacı notlarını koruyarak PowerPoint slaytlarını PDF belgelerine dönüştürme sürecini uygulamak.
- Çıktı PDF'sini, konuşmacı notlarının dahil edilmesini ve gereksinimlerinize göre biçimlendirilmesini sağlamak üzere özelleştirmek.

## **Konuşmacı Notlarıyla PowerPoint'i PDF'ye Dönüştür**

`Save` yöntemi, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfında, bir PPT veya PPTX sunumunu konuşmacı notlarıyla PDF'ye dönüştürmek için kullanılabilir. Aspose.Slides ile sadece sunumu yüklersiniz, konuşmacı notlarını dahil etmek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanarak düzen seçeneklerini yapılandırırsınız ve ardından dosyayı PDF olarak kaydedersiniz. Aşağıdaki kod parçacığı, örnek bir sunumu Not Slayt görünümünde PDF'ye nasıl dönüştüreceğinizi gösterir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Konuşmacı notlarını işlemek için PDF seçeneklerini yapılandır.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Konuşmacı notlarını slaytın altında oluştur.
        }
    };

    // Sunumu konuşmacı notlarıyla PDF olarak kaydet.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/tr/conversion)'ı kontrol etmek isteyebilirsiniz. 
{{% /alert %}}