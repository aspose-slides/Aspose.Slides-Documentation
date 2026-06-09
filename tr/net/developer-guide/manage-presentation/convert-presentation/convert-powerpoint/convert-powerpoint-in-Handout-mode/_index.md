---
title: ".NET'te Handout Modunda PowerPoint Sunumlarını Dönüştür"
linktitle: "Handout Modu"
type: docs
weight: 150
url: /tr/net/convert-powerpoint-in-handout-mode/
keywords:
- "PowerPoint dönüştür"
- "sunum dönüştür"
- "handout modu"
- "handout"
- "PowerPoint"
- "sunum"
- "PPT"
- "PPTX"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET'te sunumları el ilanına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF veya resim olarak dışa aktarın, örnek C# koduyla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları Handout modunu destekleyen çıktı formatlarına dönüştürmenizi sağlar. Bu modda, bir sayfada birden fazla slayt düzenlenir; bu, konferanslar, seminerler ve benzeri etkinlikler için sunum materyallerini yazdırmakta faydalıdır.

Handout modu, `SlidesLayoutOptions` özelliği aracılığıyla yapılandırılır; bu özellik [IPdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ihtmloptions/) ve [ITiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/itiffoptions/) içinde mevcuttur. Handout düzenini tanımlamak için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/handoutlayoutingoptions/) nesnesini kullanın.

## **Handout Modu Dışa Aktarma**

Handout modunda bir sunumu dışa aktarmak için, hedef dışa aktarma seçeneklerinde `SlidesLayoutOptions` özelliğini ayarlayın ve sayfa başına slayt sayısını ve ilgili görüntüleme parametrelerini tanımlayan bir [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/handoutlayoutingoptions/) örneği atayın.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```c#
// Bir sunumu yükle.
using var presentation = new Presentation("sample.pptx");

// Dışa aktarma seçeneklerini ayarla.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // Bir sayfada yatay olarak 4 slayt
        PrintSlideNumbers = true,                   // slayt numaralarını yazdır
        PrintFrameSlide = true,                     // slaytların etrafına bir çerçeve yazdır
        PrintComments = false                       // yorum yok
    }
};

// Seçilen düzenle sunumu PDF olarak dışa aktar.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
`SlidesLayoutOptions` özelliğinin yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntü olarak render edildiğinde mevcut olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda sayfa başına maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, yatay veya dikey sıralama ile sayfa başına en fazla 9 küçük resim sağlayan [presets](https://reference.aspose.com/slides/tr/net/aspose.slides.export/handouttype/) destekler: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) ve 9 (horizontal/vertical).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sıralaması yalnızca [HandoutType](https://reference.aspose.com/slides/tr/net/aspose.slides.export/handouttype/) enum'ı tarafından kontrol edilir; rastgele düzenler desteklenmez.

**Handout çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında `ShowHiddenSlides` seçeneğini etkinleştirin; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/tiffoptions/).