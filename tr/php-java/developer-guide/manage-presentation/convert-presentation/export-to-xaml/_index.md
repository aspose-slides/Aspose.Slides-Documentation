---
title: PHP'de Sunumları XAML'e Dışa Aktarma
linktitle: Sunumu XAML'e
type: docs
weight: 30
url: /tr/php-java/export-to-xaml/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunumu dışa aktar
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- PowerPoint'ten XAML'e
- OpenDocument'ten XAML'e
- sunumu XAML'e
- PPT'den XAML'e
- PPTX'ten XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument slaytlarını XAML'e dönüştürün — düzeninizi bozmayan hızlı, Office'siz çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML olarak dışa aktarmayı açıklar. XAML’e kısa bir giriş içerir, varsayılan ayarlarla bir sunumu XAML’e kaydetmeyi gösterir ve [XamlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/) aracılığıyla dışa aktarmayı özelleştirmenizi, gizli slaytların dışa aktarılmasını da gösterir. Makale ayrıca yedek fontlar, XAML yığını uyumluluğu ve gizli slayt dışa aktarma davranışıyla ilgili birkaç yaygın soruya yanıt verir.

## **XAML Hakkında**

XAML, özellikle WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin Forms kullanan uygulamalar için kullanıcı arabirimleri oluşturmanıza veya yazmanıza olanak tanıyan betimsel bir programlama dilidir.

XML tabanlı bir dil olan XAML, Microsoft’un GUI tanımlama varyantıdır. Çoğu zaman XAML dosyalarıyla çalışmak için bir tasarımcı kullanırsınız, ancak GUI’nizi hâlâ yazarak ve düzenleyerek oluşturabilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML’e Dışa Aktarma**

Bu PHP kodu, bir sunumu varsayılan ayarlarla XAML’e dışa aktarmayı gösterir:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Özel Seçeneklerle Sunumları XAML’e Dışa Aktarma**

[XamlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/) sınıfından dışa aktarma sürecini kontrol eden ve Aspose.Slides’ın sunumunuzu XAML’e nasıl dışa aktaracağını belirleyen seçenekleri seçebilirsiniz.

Örneğin, Aspose.Slides’ın XAML dışa aktarırken sunumunuzdaki gizli slaytları eklemesini istiyorsanız, `true` değerini kullanarak [setExportHiddenSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/setexporthiddenslides/) yöntemini çağırabilirsiniz. Aşağıdaki örnek PHP koduna bakın:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Orijinal font makinede bulunmuyorsa öngörülebilir fontları nasıl sağlayabilirim?**

[XamlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/) içinde bir [varsayılan normal font](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) ayarlayın — orijinal font eksik olduğunda yedek font olarak kullanılır. Bu, beklenmedik değişiklikleri önlemeye yardımcı olur.

**Dışa aktarılan XAML sadece WPF için mi tasarlandı, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

XAML, WPF, UWP ve Xamarin.Forms’da kullanılan genel bir UI işaretleme dilidir. Dışa aktarım, Microsoft XAML yığınlarıyla uyumluluğu hedefler; kesin davranış ve belirli yapıların desteği hedef platforma bağlıdır. İşaretlemenizi ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak bunların dışa aktarılmasını nasıl engelleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/) içinde [setExportHiddenSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xamloptions/setexporthiddenslides/) ile kontrol edebilirsiniz — ihtiyacınız yoksa devre dışı bırakın.