---
title: PowerPoint Sunumlarını C++ ile SWF Flash'e Dönüştür
linktitle: PowerPoint'tan SWF'ye
type: docs
weight: 80
url: /tr/cpp/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan SWF'ye
- sunumdan SWF'ye
- slayttan SWF'ye
- PPT'den SWF'ye
- PPTX'ten SWF'ye
- PowerPoint'tan Flash'e
- sunumdan Flash'e
- slayttan Flash'e
- PPT'den Flash'e
- PPTX'ten Flash'e
- PPT'yi SWF olarak kaydet
- PPTX'i SWF olarak kaydet
- PPT'yi SWF'ye dışa aktar
- PPTX'i SWF'ye dışa aktar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++ kullanarak PowerPoint (PPT/PPTX) dosyalarını SWF Flash'e dönüştürün. Adım adım kod örnekleri, hızlı ve kaliteli çıktı, PowerPoint otomasyonu yok."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını SWF'ye nasıl dönüştüreceğinizi açıklar. Bir sunumu [Presentation::Save](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/save/) yöntemiyle SWF dosyası olarak nasıl kaydedeceğinizi ve izleyici ayarları ile notlar veya yorumlar düzenini içerecek şekilde dışa aktarımı [SwfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/swfoptions/) ile nasıl yapılandıracağınızı gösterir.

## **Sunumları Flash'e Dönüştürme**

[Save](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) yöntemi, [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı tarafından sunularak tüm sunumu bir SWF belgesine dönüştürmek için kullanılabilir. Ayrıca, oluşturulan SWF'ye [SWFOptions](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.swf_options) sınıfını ve [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanarak yorumları ekleyebilirsiniz. Aşağıdaki örnek, SWFOptions sınıfı tarafından sağlanan seçenekleri kullanarak bir sunumu SWF belgesine nasıl dönüştüreceğinizi gösterir.

``` cpp
// Belgeler dizinine giden yol.
    // Sunum dosyasını temsil eden bir Presentation nesnesi oluştur.
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Sunumu ve not sayfalarını kaydetme
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **SSS**

**SWF içinde gizli slaytları dahil edebilir miyim?**

Evet. [set_ShowHiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) yöntemini [SwfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/swfoptions/) içinde kullanın. Varsayılan olarak gizli slaytlar dışa aktarılmaz.

**Sıkıştırmayı ve son SWF boyutunu nasıl kontrol edebilirim?**

[set_Compressed](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/swfoptions/set_compressed/) yöntemini kullanın ve dosya boyutu ile görüntü kalitesini dengelemek için [JPEG quality](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/swfoptions/set_jpegquality/) ayarını düzenleyin.

**'set_ViewerIncluded' ne işe yarar ve ne zaman kullanılmalıdır?**

[set_ViewerIncluded](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) gömülü bir oynatıcı arayüzü (navigasyon kontrolleri, paneller, arama) ekler. Kendi oynatıcınızı kullanmayı planlıyorsanız veya UI olmadan sade bir SWF çerçevesine ihtiyacınız varsa bunu devre dışı bırakın.

**Dışa aktarma makinesinde kaynak bir yazı tipi eksikse ne olur?**

Aspose.Slides, [SwfOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/swfoptions/) içinde [set_DefaultRegularFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) ile belirttiğiniz yazı tipini kullanarak istenmeyen bir yedekleme oluşmasını önleyecektir.