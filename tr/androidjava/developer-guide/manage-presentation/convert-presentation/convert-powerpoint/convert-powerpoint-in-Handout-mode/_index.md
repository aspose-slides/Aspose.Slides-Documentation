---
title: PowerPoint Sunumlarını Android’de El İlanı Modunda Dönüştürün
linktitle: El İlanı Modu
type: docs
weight: 150
url: /tr/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- el ilanı modu
- el ilanı
- PPT
- PPTX
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Sunumları Java’da el ilanına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides for Android ile PDF veya görüntülere dışa aktarın, örnek kodla. Ücretsiz deneyin."
---
## **Introduction**

Aspose.Slides, sunumları çeşitli biçimlere dönüştürme imkanı sağlar; bunlar arasında Handout modunda yazdırma için el ilanları oluşturma da vardır. Bu mod, bir sayfada birden çok slaytın nasıl görüneceğini yapılandırmanıza olanak tanır ve konferanslar, seminerler ve diğer etkinlikler için kullanışlıdır. `setSlidesLayoutOptions` yöntemini, [IPdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ihtmloptions/) ve [ITiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiffoptions/) arabirimlerinde ayarlayarak bu modu etkinleştirebilirsiniz.

Dışa aktarmadan önce el ilanı sayfa boyutlarını ve yönelimini ayarlamak için [Notes Page Size](/slides/tr/androidjava/notes-size/) bölümüne bakın.

## **Handout Mode Export**

Handout modunu yapılandırmak için, bir sayfada kaç slayt yerleştirileceğini ve diğer görüntüleme parametrelerini belirleyen [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

Aşağıda, bir sunumu Handout modunda PDF’ye dönüştüren bir kod örneği bulunuyor.

```java
import com.aspose.slides.*;

// Sunumu yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Dışa aktarma seçeneklerini ayarla.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // Bir sayfada 4 slayt yatay olarak
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // Slayt numaralarını yazdır
	slidesLayoutOptions.setPrintFrameSlide(true);                     // Slaytların etrafına çerçeve ekle
	slidesLayoutOptions.setPrintComments(false);                      // yorum yok

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Sunumu seçilen düzenle PDF olarak dışa aktar.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` yönteminin yalnızca PDF, HTML, TIFF gibi belirli çıktı biçimleri ve görüntü olarak işlenirken kullanılabilir olduğunu unutmayın.
{{% /alert %}} 

## **FAQ**

**Handout modunda bir sayfada en fazla kaç slayt küçük resmi bulunabilir?**

Aspose.Slides, yatay veya dikey sıralama ile sayfa başına 9 küçük resme kadar [presets](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handouttype/) destekler: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**Sayfa başına 5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resim sayısı ve sıralaması, [HandoutType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/handouttype/) sınıfı tarafından kesin olarak kontrol edilir; keyfi düzenler desteklenmez.

**Handout çıktısına gizli slaytları dahil edebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında (ör. [PdfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/tiffoptions/)) `setShowHiddenSlides` yöntemini etkinleştirerek gizli slaytları dahil edebilirsiniz.