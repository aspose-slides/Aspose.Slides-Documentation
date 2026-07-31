---
title: Android'de El Kitapçığı Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: El Kitapçığı Modu
type: docs
weight: 150
url: /tr/androidjava/convert-powerpoint-in-handout-mode/
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
description: "Sunumları Java'da el kitapçığına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides for Android ile PDF veya resim olarak dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları çeşitli biçimlere dönüştürme yeteneği sağlar; bunlar arasında Handout modunda yazdırmak için el kitapçıkları oluşturmak da bulunur. Bu mod, bir sayfada birden çok slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için yararlıdır. Bu modu, arayüzlerde `setSlidesLayoutOptions` metodunu ayarlayarak etkinleştirebilirsiniz: [IPdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihtmloptions/), ve [ITiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiffoptions/) arayüzlerinde.

## **El Kitapçığı Modu Dışa Aktarımı**

Handout modunu yapılandırmak için, bir sayfaya kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```java
// Bir sunum yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Dışa aktarma seçeneklerini ayarla.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // Sayfada yatay olarak 4 slayt
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // slayt numaralarını yazdır
	slidesLayoutOptions.setPrintFrameSlide(true);                     // slaytların etrafına çerçeve ekle
	slidesLayoutOptions.setPrintComments(false);                      // yorum ekleme

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Sunumu seçilen düzenle PDF olarak dışa aktar.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` metodunun yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve resim olarak render edilirken kullanılabilir olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda sayfa başına maksimum slayt küçük resmi sayısı nedir?**

Aspose.Slides, sayfa başına en fazla 9 küçük resim destekleyen [presets](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handouttype/) sağlar; yatay veya dikey sıralama seçenekleri: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) ve 9 (horizontal/vertical).

**Sayfa başına 5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sıralaması yalnızca [HandoutType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handouttype/) sınıfı tarafından kontrol edilir; rastgele düzenler desteklenmez.

**El kitapçığı çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında `setShowHiddenSlides` metodunu kullanarak gizli slaytları etkinleştirebilirsiniz; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/).