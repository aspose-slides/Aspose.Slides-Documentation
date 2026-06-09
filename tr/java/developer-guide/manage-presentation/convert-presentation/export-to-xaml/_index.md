---
title: Java'da Sunumları XAML'ye Dışa Aktarma
linktitle: Sunumdan XAML'ye
type: docs
weight: 30
url: /tr/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da PowerPoint ve OpenDocument slaytlarını XAML'ye dönüştürün—düzeninizi bozmayan hızlı, Office'siz bir çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML'ye nasıl dışa aktaracağınızı açıklar. XAML'e kısa bir giriş içerir, bir sunumu varsayılan ayarlarla XAML olarak nasıl kaydedeceğinizi gösterir ve dışa aktarmayı [XamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/) üzerinden nasıl özelleştireceğinizi, gizli slaytların dışa aktarılması dahil, gösterir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarım davranışıyla ilgili birkaç yaygın soruyu yanıtlar.

## **XAML Hakkında**

XAML, uygulamalar için kullanıcı arayüzleri oluşturmanıza veya yazmanıza olanak tanıyan tanımsal bir programlama dilidir; özellikle WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin Forms kullananlar için.

XAML, XML tabanlı bir dil olduğu için, Microsoft'un GUI tanımlama varyantıdır. Çoğu zaman XAML dosyaları üzerinde çalışmak için bir tasarımcı kullanırsınız, ancak yine de GUI'nizi yazabilir ve düzenleyebilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML'ye Dışa Aktarma**

Bu Java kodu, bir sunumu varsayılan ayarlarla XAML'ye nasıl dışa aktaracağınızı gösterir:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **Özel Seçeneklerle Sunumları XAML'ye Dışa Aktarma**

Dışa aktarma sürecini kontrol eden ve Aspose.Slides'ın sunumunuzu XAML'ye nasıl dışa aktaracağını belirleyen seçenekleri [IXamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IXamlOptions) arayüzünden seçebilirsiniz.

Örneğin, Aspose.Slides'ın XAML'ye dışa aktarırken sunumunuzdaki gizli slaytları eklemesini istiyorsanız, [ExportHiddenSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) özelliğini true olarak ayarlayabilirsiniz. Bu örnek Java koduna bakın:

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

**Orijinal yazı tipi makinede mevcut değilse, öngörülebilir yazı tiplerini nasıl sağlayabilirim?**

[XamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/) içinde [varsayılan normal yazı tipini](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ayarlayın — orijinali eksik olduğunda yedek yazı tipi olarak kullanılır. Bu, beklenmedik ikameleri önlemeye yardımcı olur.

**Dışa aktarılan XAML yalnızca WPF için mi tasarlanmıştır, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

XAML, WPF, UWP ve Xamarin.Forms'da kullanılan genel bir UI işaretleme dilidir. Dışa aktarım, Microsoft XAML yığınlarıyla uyumluluğu hedefler; belirli yapıların kesin davranışı ve desteği hedef platforma bağlıdır. İşaretlemeyi ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engelleyebilirim?**

Varsayılan olarak, gizli slaytlar dahil edilmez. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/) içinde [setExportHiddenSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) ile kontrol edebilirsiniz — eğer dışa aktarmanıza gerek yoksa devre dışı bırakın.