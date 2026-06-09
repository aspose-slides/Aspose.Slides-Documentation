---
title: Java kullanarak Handout Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: Handout Modu
type: docs
weight: 150
url: /tr/java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- handout modu
- el kitabı
- PPT
- PPTX
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java'da sunumları el kitaplarına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF veya görüntülere dışa aktarın, örnek Java kodu ile. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları Handout modunu destekleyen çıktı formatlarına dönüştürmenizi sağlar. Bu modda, bir sayfada birden fazla slayt düzenlenir; bu da konferanslar, seminerler ve benzeri etkinlikler için sunum materyallerinin yazdırılmasında faydalıdır.

Handout modu, `setSlidesLayoutOptions` yöntemiyle yapılandırılır; bu yöntem [IPdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihtmloptions/) ve [ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) içinde mevcuttur. Handout düzenini tanımlamak için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

## **Handout Modu Dışa Aktarma**

Handout modunda bir sunumu dışa aktarmak için, hedef dışa aktarma seçenekleri için `setSlidesLayoutOptions` yöntemini ayarlayın ve sayfa başına slayt sayısını ve ilgili görüntüleme parametrelerini tanımlayan bir [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handoutlayoutingoptions/) örneği atayın.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```java
// Bir sunum yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Dışa aktarma seçeneklerini ayarla.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // Yatay olarak bir sayfada 4 slayt
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // slayt numaralarını yazdır
    slidesLayoutOptions.setPrintFrameSlide(true);                     // slaytların etrafına bir çerçeve yazdır
    slidesLayoutOptions.setPrintComments(false);                      // yorum yok

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Seçilen düzenle sunumu PDF olarak dışa aktar.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` yönteminin yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntüler olarak işlenirken kullanılabilir olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda sayfa başına maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, sayfa başına yatay veya dikey sıralama ile en fazla 9 küçük resim destekleyen [presets](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handouttype/) sunar: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sıralaması, sadece [HandoutType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handouttype/) sınıfı tarafından kesin olarak kontrol edilir; rastgele düzenler desteklenmez.

**Handout çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında `setShowHiddenSlides` yöntemini kullanarak gizli slaytları etkinleştirebilirsiniz; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/).