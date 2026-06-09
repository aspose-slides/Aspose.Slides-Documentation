---
title: Sunumları JavaScript'te XAML'ye Dışa Aktarma
linktitle: Sunumu XAML'ye
type: docs
weight: 30
url: /tr/nodejs-java/export-to-xaml/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunumu dışa aktar
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- PowerPoint'ten XAML'ye
- OpenDocument'ten XAML'ye
- sunumdan XAML'ye
- PPT'den XAML'ye
- PPTX'den XAML'ye
- ODP'den XAML'ye
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'ye dışa aktar
- PPTX'i XAML'ye dışa aktar
- ODP'yi XAML'ye dışa aktar
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js kullanarak JavaScript'te PowerPoint ve OpenDocument slaytlarını XAML'ye dönüştürün—düzeninizi koruyan hızlı, Office gerektirmeyen çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML'ye nasıl dışa aktaracağınızı açıklar. XAML'e kısa bir giriş içerir, bir sunumu varsayılan ayarlarla XAML'ye nasıl kaydedeceğinizi gösterir ve dışa aktarmayı [XamlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/) aracılığıyla özelleştirmeyi, gizli slaytların dışa aktarılmasını da içerir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarım davranışıyla ilgili birkaç yaygın soruya yanıt verir.

## **XAML Hakkında**

XAML, özellikle WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin Forms kullanan uygulamalar için kullanıcı sınıfları oluşturmanıza veya yazmanıza olanak tanıyan betimleyici bir programlama dilidir.

XML tabanlı bir dil olan XAML, Microsoft'un GUI tanımlama varyantıdır. Çoğu zaman XAML dosyaları üzerinde çalışmak için bir tasarımcı kullanırsınız, ancak yine de GUI'nizi yazabilir ve düzenleyebilirsiniz. 

## **Sunumları XAML'ye Varsayılan Seçeneklerle Dışa Aktarma**

Bu JavaScript kodu, bir sunumu varsayılan ayarlarla XAML'ye nasıl dışa aktaracağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sunumları XAML'ye Özel Seçeneklerle Dışa Aktarma**

[XamlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/XamlOptions) sınıfından dışa aktarma işlemini kontrol eden ve Aspose.Slides'ın sunumunuzu XAML'ye nasıl dışa aktaracağını belirleyen seçenekleri seçebilirsiniz.

Örneğin, Aspose.Slides'ın sunumunuzdaki gizli slaytları XAML'ye dışa aktarırken eklemesini istiyorsanız, [setExportHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) metodunu true olarak ayarlayabilirsiniz. Bu örnek JavaScript koduna bakın:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Orijinal yazı tipi makinede mevcut değilse, öngörülebilir yazı tiplerini nasıl sağlayabilirim?**

[XamlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/) içinde [setDefaultRegularFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) kullanın — orijinal yazı tipi eksik olduğunda yedek yazı tipi olarak kullanılır. Bu, beklenmedik yerine koymaları önlemeye yardımcı olur.

**Dışa aktarılan XAML sadece WPF için mi tasarlanmıştır, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

XAML, WPF, UWP ve Xamarin.Forms'ta kullanılan genel bir UI işaretleme dilidir. Dışa aktarma, Microsoft XAML yığınlarıyla uyumluluğu hedefler; belirli yapıların kesin davranışı ve desteği hedef platforma bağlıdır. İşaretlemi ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engelleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/) içinde [setExportHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) ile kontrol edebilirsiniz — eğer dışa aktarmak istemiyorsanız devre dışı bırakın.