---
title: Java Kullanarak El İlanı Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: El İlanı Modu
type: docs
weight: 150
url: /tr/java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştürme
- sunum dönüştürme
- el ilanı modu
- el ilanı
- PPT
- PPTX
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java'da sunumları el ilanına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF ya da görüntülere dışa aktarın, örnek Java kodu eşliğinde. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, El İlanı modunu destekleyen çıktı formatlarına sunumları dönüştürmenizi sağlar. Bu modda, bir sayfada birden fazla slayt düzenlenir; bu, konferans, seminer ve benzeri etkinlikler için sunum materyallerini yazdırmakta faydalıdır.

El İlanı modu, `setSlidesLayoutOptions` yöntemiyle yapılandırılır; bu yöntem [IPdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihtmloptions/) ve [ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) içinde bulunur. El ilanı yerleşimini tanımlamak için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

## **El İlanı Modu Dışa Aktarma**

Bir sunumu El İlanı modunda dışa aktarmak için, hedef dışa aktarma seçenekleri için `setSlidesLayoutOptions` yöntemini ayarlayın ve sayfa başına slayt sayısını ve ilgili gösterim parametrelerini tanımlayan bir [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handoutlayoutingoptions/) örneği atayın.

Aşağıda, bir sunumu El İlanı modunda PDF'ye dönüştürmeyi gösteren bir kod örneği bulunmaktadır.

```java
// Bir sunumu yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Dışa aktarma seçeneklerini ayarla.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // Bir sayfada yatay olarak 4 slayt
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // slayt numaralarını yazdır
    slidesLayoutOptions.setPrintFrameSlide(true);                     // slaytların etrafına bir çerçeve yazdır
    slidesLayoutOptions.setPrintComments(false);                      // yorum yok

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Seçilen yerleşimle sunumu PDF'ye dışa aktar.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` yönteminin yalnızca PDF, HTML, TIFF gibi belirli çıktı formatları ve görüntüler olarak render edildiğinde kullanılabilir olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**El İlanı modunda sayfa başına maksimum kaç slayt küçük resmi bulunabilir?**

Aspose.Slides, sayfa başına yatay veya dikey sıralama ile en fazla 9 küçük resme kadar olan [presets](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handouttype/) destekler: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sıralaması, sadece [HandoutType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handouttype/) sınıfı tarafından sıkı bir şekilde kontrol edilir; rastgele düzenler desteklenmez.

**El İlanı çıktısına gizli slaytları dahil edebilir miyim?**

Evet. Hedef format için dışa aktarma ayarlarında, örneğin [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) gibi, gizli slaytları `setShowHiddenSlides` yöntemiyle etkinleştirin.