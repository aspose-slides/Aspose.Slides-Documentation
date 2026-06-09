---
title: Android'de El Kitapçığı Modunda PowerPoint Sunumlarını Dönüştür
linktitle: El Kitapçığı Modu
type: docs
weight: 150
url: /tr/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- el kitapçığı modu
- el kitapçığı
- PPT
- PPTX
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Sunumları Java'da el kitapçıklarına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Android için Aspose.Slides ile PDF veya görüntülere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli formatlara dönüştürme yeteneği sağlar; buna Handout modunda baskı için el kitapçıkları oluşturma da dahildir. Bu mod, bir sayfada birden çok slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için faydalıdır. Bu modu, `setSlidesLayoutOptions` metodunu [IPdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihtmloptions/) ve [ITiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiffoptions/) arabirimlerinde ayarlayarak etkinleştirebilirsiniz.

## **El Kitapçığı Modu Dışa Aktarma**

Handout modunu yapılandırmak için, tek bir sayfada kaç slayt yer alacağını ve diğer görüntü parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF’ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```java
// Bir sunum yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Dışa aktarma seçeneklerini ayarla.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // Yatay olarak bir sayfada 4 slayt
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // slayt numaralarını yazdır
	slidesLayoutOptions.setPrintFrameSlide(true);                     // slaytların etrafına çerçeve yazdır
	slidesLayoutOptions.setPrintComments(false);                      // yorum yok

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Sunumu seçilen düzenle PDF olarak dışa aktar.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` metodunun yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntülere dönüştürürken kullanılabildiğini unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda sayfa başına maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, sayfa başına yatay veya dikey sıralama ile en fazla 9 küçük resim destekleyen [presets](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handouttype/) sunar: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**Sayfa başına 5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sıralaması tamamen [HandoutType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handouttype/) sınıfı tarafından kontrol edilir; keyfi düzenler desteklenmez.

**Handout çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında `setShowHiddenSlides` metodunu kullanarak gizli slaytları etkinleştirebilirsiniz; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/).