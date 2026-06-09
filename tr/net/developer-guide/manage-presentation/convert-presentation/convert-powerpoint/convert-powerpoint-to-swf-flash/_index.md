---
title: .NET'te PowerPoint Sunumlarını SWF Flash'e Dönüştür
linktitle: PowerPoint'ten SWF'ye
type: docs
weight: 80
url: /tr/net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten SWF'ye
- sunumdan SWF'ye
- slayttan SWF'ye
- PPT'den SWF'ye
- PPTX'den SWF'ye
- PowerPoint'ten Flash'a
- sunumdan Flash'a
- slayttan Flash'a
- PPT'den Flash'a
- PPTX'den Flash'a
- PPT'yi SWF olarak kaydet
- PPTX'i SWF olarak kaydet
- PPT'yi SWF'ye aktar
- PPTX'i SWF'ye aktar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) dosyalarını .NET'te Aspose.Slides ile SWF Flash'e dönüştürün. Adım adım C# kod örnekleri, hızlı ve kaliteli çıktı, PowerPoint otomasyonu yok."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını SWF'ye nasıl dönüştüreceğinizi açıklar. Sunumu bir SWF dosyası olarak [Presentation.Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) yöntemiyle nasıl kaydedeceğinizi ve [SwfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/swfoptions/) ile dışa aktarmayı nasıl yapılandıracağınızı, görüntüleyici ayarları ile notlar veya yorum düzeni dahil olmak üzere gösterir.

## **Sunumları Flash'a Dönüştür**

Sunum sınıfı tarafından sunulan [Save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/methods/save/index) metodu, tüm sunumu bir SWF belgesine dönüştürmek için kullanılabilir. Ayrıca, oluşturulan SWF'ye yorumları eklemek için [SWFOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/swfoptions) sınıfını ve [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/inotescommentslayoutingoptions) arayüzünü kullanabilirsiniz. Aşağıdaki örnek, SWFOptions sınıfı tarafından sağlanan seçenekleri kullanarak bir sunumu SWF belgesine nasıl dönüştüreceğinizi gösterir.

```c#
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Sunumu ve not sayfalarını kaydediyor
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **SSS**

**SWF'ye gizli slaytları ekleyebilir miyim?**

Evet. [SwfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/swfoptions/) içinde [ShowHiddenSlides](https://reference.aspose.com/slides/tr/net/aspose.slides.export/swfoptions/showhiddenslides/) seçeneğini etkinleştirin. Varsayılan olarak, gizli slaytlar dışa aktarılmaz.

**Sıkıştırmayı ve son SWF boyutunu nasıl kontrol edebilirim?**

[Compressed](https://reference.aspose.com/slides/tr/net/aspose.slides.export/swfoptions/compressed/) bayrağını (varsayılan olarak etkindir) kullanın ve dosya boyutu ile görüntü kalitesini dengelemek için [JpegQuality](https://reference.aspose.com/slides/tr/net/aspose.slides.export/swfoptions/jpegquality/) ayarını değiştirin.

**'ViewerIncluded' ne için kullanılır ve ne zaman devre dışı bırakılmalı?**

[ViewerIncluded](https://reference.aspose.com/slides/tr/net/aspose.slides.export/swfoptions/viewerincluded/) gömülü bir oynatıcı UI'si (navigasyon kontrolleri, paneller, arama) ekler. Kendi oynatıcınızı kullanmayı planlıyorsanız veya UI olmadan sade bir SWF çerçevesine ihtiyacınız varsa bunu devre dışı bırakın.

**Dışa aktarma makinesinde kaynak font eksikse ne olur?**

Aspose.Slides, istenmeyen bir yedekleme olmaması için [SwfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/) içinde [DefaultRegularFont](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/defaultregularfont/) ile belirttiğiniz fontu değiştirecektir.