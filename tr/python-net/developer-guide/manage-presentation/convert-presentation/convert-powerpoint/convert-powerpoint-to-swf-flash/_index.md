---
title: PowerPoint Sunumlarını Python’da SWF Flash’e Dönüştür
linktitle: PowerPoint'tan SWF Flash'e
type: docs
weight: 80
url: /tr/python-net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PowerPoint'tan SWF'ye
- sunumu SWF'ye
- slaytı SWF'ye
- PPT'den SWF'ye
- PPTX'ten SWF'ye
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da PowerPoint (PPT/PPTX) dosyalarını SWF Flash'e dönüştürün. Adım adım kod örnekleri, hızlı kalite çıktısı, PowerPoint otomasyonu gerekmez."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını SWF’ye nasıl dönüştüreceğinizi açıklar. Sunumu bir SWF dosyası olarak [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) yöntemiyle nasıl kaydedeceğinizi ve dışa aktarmayı [SwfOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/swfoptions/) ile nasıl yapılandıracağınızı, görüntüleyici ayarları ile notlar veya yorumlar düzenini de kapsayacak şekilde gösterir.

## **Sunumları Flash’a Dönüştür**

[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı tarafından sunulan [save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) yöntemi, tüm sunumu bir SWF belgesine dönüştürmek için kullanılabilir. Ayrıca, oluşturulan SWF’ye yorumları eklemek için [SWFOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/swfoptions/) sınıfı ve [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/notescommentslayoutingoptions/) sınıfını kullanabilirsiniz. Aşağıdaki örnek, SWFOptions sınıfı tarafından sağlanan seçenekleri kullanarak bir sunumun SWF belgesine nasıl dönüştürüleceğini gösterir.

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden bir Presentation nesnesi oluştur
presentation = slides.Presentation("pres.pptx")

swfOptions = slides.export.SwfOptions()
swfOptions.viewer_included = False
swfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Sunumu ve not sayfalarını kaydediyor
presentation.save("SaveAsSwf_out.swf", slides.export.SaveFormat.SWF, swfOptions)
swfOptions.viewer_included = True
presentation.save("SaveNotes_out.swf", slides.export.SaveFormat.SWF, swfOptions)
```

## **SSS**

**Gizli slaytları SWF içinde dahil edebilir miyim?**

Evet. [SwfOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/swfoptions/) içinde bulunan [show_hidden_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/swfoptions/show_hidden_slides/) seçeneğini etkinleştirin. Varsayılan olarak gizli slaytlar dışa aktarılmaz.

**Sıkıştırmayı ve son SWF boyutunu nasıl kontrol edebilirim?**

Varsayılan olarak etkin olan [compressed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/swfoptions/compressed/) bayrağını kullanın ve dosya boyutu ile görüntü kalitesini dengelemek için [jpeg_quality](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/swfoptions/jpeg_quality/) ayarını değiştirin.

**'viewer_included' ne işe yarar ve ne zaman devre dışı bırakmalıyım?**

[viewer_included](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/swfoptions/viewer_included/) gömülü bir oynatıcı arayüzü (navigasyon kontrolleri, paneller, arama) ekler. Kendi oynatıcınızı kullanmayı planlıyorsanız veya UI olmadan sade bir SWF çerçevesine ihtiyacınız varsa devre dışı bırakın.

**Kaynak font dışa aktarma makinesinde eksikse ne olur?**

Aspose.Slides, dışa aktarım sırasında istenmeyen bir yedekleme oluşmasını önlemek için [SwfOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/swfoptions/) içindeki [default_regular_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/swfoptions/default_regular_font/) ile belirttiğiniz fontu kullanarak fontu değiştirecektir.