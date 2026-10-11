---
title: Java Kullanarak Handout Modunda PowerPoint Sunumlarını Dönüştürme
linktitle: Handout Modu
type: docs
weight: 150
url: /tr/java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- el kitabı modu
- el kitabı
- PPT
- PPTX
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java'da sunumları el kitabına dönüştürün. Sayfa başına slayt sayısını ayarlayın, notları koruyun, Aspose.Slides ile PDF ya da görsellere dışa aktarın, örnek Java kodu ile. Ücretsiz deneyin."
---
## **Giriş**

Aspose.Slides, sunumları Handout modunu destekleyen çıktı biçimlerine dönüştürmenizi sağlar. Bu modda, bir sayfada birden fazla slayt düzenlenir; bu, konferanslar, seminerler ve benzeri etkinlikler için sunum materyallerini yazdırmakta faydalıdır.

Handout modu, `setSlidesLayoutOptions` yöntemi ile yapılandırılır; bu yöntem [IPdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ihtmloptions/) ve [ITiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiffoptions/) içinde mevcuttur. Handout düzenini tanımlamak için [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handoutlayoutingoptions/) nesnesini kullanın.

Dışa aktarma öncesinde Handout sayfa boyutları ve yönelimini ayarlamak için [Not Sayfası Boyutu](/slides/tr/java/notes-size/) sayfasına bakın.

## **Handout Modu Dışa Aktarma**

Handout modunda bir sunumu dışa aktarmak için hedef dışa aktarım seçeneklerinde `setSlidesLayoutOptions` metodunu ayarlayın ve sayfa başına slayt sayısı ile ilgili görüntü parametrelerini tanımlayan bir [HandoutLayoutingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handoutlayoutingoptions/) örneği atayın.

Aşağıda, bir sunumu Handout modunda PDF’ye dönüştüren bir kod örneği bulunmaktadır.

```java
import com.aspose.slides.*;

// Sunumu yükle.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Dışa aktarım seçeneklerini ayarla.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // Tek sayfada yatay olarak 4 slayt
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

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` metodunun yalnızca PDF, HTML, TIFF gibi belirli çıktı biçimleri ve görüntü olarak render edildiğinde kullanılabilir olduğunu unutmayın.
{{% /alert %}} 

## **SSS**

**Handout modunda sayfa başına en fazla kaç slayt küçük resmi bulunabilir?**

Aspose.Slides, [ön ayarlar](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handouttype/) aracılığıyla yatay veya dikey sıralama ile sayfa başına en fazla 9 küçük resim desteği sunar: 1, 2, 3, 4 (yatay/dikey), 6 (yatay/dikey) ve 9 (yatay/dikey).

**5 veya 8 slayt gibi özel bir ızgara tanımlayabilir miyim?**

Hayır. Küçük resimlerin sayısı ve sıralaması tamamen [HandoutType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/handouttype/) sınıfı tarafından kontrol edilir; rastgele düzenler desteklenmez.

**Handout çıktısına gizli slaytları ekleyebilir miyim?**

Evet. Gizli slaytları, hedef format için dışa aktarım ayarlarında `setShowHiddenSlides` metodunu etkinleştirerek dahil edebilirsiniz; örneğin [PdfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/htmloptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/tiffoptions/) gibi.