---
title: Android'de Sunumları XAML'e Dışa Aktarma
linktitle: Sunumu XAML'e
type: docs
weight: 30
url: /tr/androidjava/export-to-xaml/
keywords:
- PowerPoint'i dışa aktar
- OpenDocument'i dışa aktar
- sunumu dışa aktar
- PowerPoint'i dönüştür
- OpenDocument'i dönüştür
- sunumu dönüştür
- PowerPoint'ten XAML'e
- OpenDocument'ten XAML'e
- sunumdan XAML'e
- PPT'den XAML'e
- PPTX'den XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak Java'da PowerPoint ve OpenDocument slaytlarını XAML'e dönüştürün—düzeninizi bozmayan hızlı, Office'siz çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML'e nasıl dışa aktarılacağını açıklar. XAML'e kısa bir giriş, bir sunumun varsayılan ayarlarla XAML olarak nasıl kaydedileceği ve [XamlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/) aracılığıyla dışa aktarmanın nasıl özelleştirileceği, gizli slaytların dışa aktarılması dahil gösterilir. Makale ayrıca yedek fontlar, XAML yığını uyumluluğu ve gizli slayt dışa aktarma davranışıyla ilgili birkaç yaygın soruya yanıt verir.

## **XAML Hakkında**

XAML, uygulamalar için kullanıcı arayüzleri oluşturmanıza veya yazmanıza olanak tanıyan tanımlayıcı bir programlama dilidir; özellikle WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin formları kullananlar için.

XAML, XML tabanlı bir dil olan Microsoft'un GUI tanımlama varyantıdır. Çoğu zaman XAML dosyaları üzerinde çalışmak için bir tasarımcı kullanırsınız, ancak yine de GUI'nizi yazabilir ve düzenleyebilirsiniz.

## **Sunumları Varsayılan Seçeneklerle XAML'e Dışa Aktarma**

Bu Java kodu, bir sunumu varsayılan ayarlarla XAML'e nasıl dışa aktaracağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Sunumları Özelleştirilmiş Seçeneklerle XAML'e Dışa Aktarma**

Dışa aktarma sürecini kontrol eden ve Aspose.Slides'ın sunumunuzu XAML'e nasıl dışa aktaracağını belirleyen seçenekleri [IXamlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IXamlOptions) arayüzünden seçebilirsiniz.

Örneğin, Aspose.Slides'ın XAML'e dışa aktarırken sunumunuzdaki gizli slaytları eklemesini istiyorsanız, [ExportHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) özelliğini true olarak ayarlayabilirsiniz. Bu örnek Java koduna bakın:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **SSS**

**Orijinal font makinede bulunmuyorsa nasıl öngörülebilir fontlar sağlayabilirim?**

[XamlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/) içinde [varsayılan normal bir font](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ayarlayın — orijinal font eksik olduğunda yedek font olarak kullanılır. Bu, beklenmeyen ikameleri önlemeye yardımcı olur.

**Dışa aktarılan XAML sadece WPF için mi tasarlandı, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

XAML, WPF, UWP ve Xamarin.Forms'ta kullanılan genel bir UI işaretleme dilidir. Dışa aktarma, Microsoft XAML yığınlarıyla uyumluluğu hedefler; belirli yapılar için kesin davranış ve destek hedef platforma bağlıdır. İşaretlemenizi ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak bunların dışa aktarılmasını nasıl engelleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [setExportHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) aracılığıyla [XamlOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xamloptions/) içinde kontrol edebilirsiniz — eğer dışa aktarmanıza gerek yoksa devre dışı bırakın.