---
title: C++ ile Sunumları XAML'e Dışa Aktarma
linktitle: Sunumu XAML'e
type: docs
weight: 30
url: /tr/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++ içinde PowerPoint ve OpenDocument slaytlarını XAML'e dönüştürün—düzeninizi bozmayan hızlı, Office'siz bir çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML'e nasıl dışa aktarılacağını açıklar. XAML'e kısa bir giriş içerir, bir sunumun varsayılan ayarlarla XAML olarak nasıl kaydedileceğini gösterir ve [XamlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/) aracılığıyla dışa aktarmayı nasıl özelleştirebileceğinizi, gizli slaytların dışa aktarılması dahil, gösterir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarma davranışıyla ilgili birkaç yaygın soruya yanıt verir.

## **XAML Hakkında**

XAML, özellikle WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin formları kullanan uygulamalar için kullanıcı arayüzleri oluşturmanıza veya yazmanıza olanak tanıyan tanımlayıcı bir programlama dilidir.  

XML tabanlı bir dil olan XAML, Microsoft’un GUI tanımlama varyantıdır. Çoğu zaman bir tasarımcı kullanarak XAML dosyalarıyla çalışırsınız, ancak yine de GUI’nizi el ile yazıp düzenleyebilirsiniz.

## **Sunumları Varsayılan Seçeneklerle XAML'e Dışa Aktarma**

Bu C++ kodu, bir sunumu varsayılan ayarlarla XAML'e nasıl dışa aktaracağınızı gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **Sunumları Özel Seçeneklerle XAML'e Dışa Aktarma**

Dışa aktarma sürecini kontrol eden ve Aspose.Slides'ın sunumunuzu XAML'e nasıl dışa aktaracağını belirleyen seçenekleri [IXamlOptions](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.xaml.i_xaml_options) arayüzünden seçebilirsiniz. 

Örneğin, Aspose.Slides'ın sunumunuzdaki gizli slaytları XAML'e dışa aktarırken eklemesini istiyorsanız, [set_ExportHiddenSlides()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) yöntemine true değerini geçirebilirsiniz. Aşağıdaki örnek C++ koduna bakın: 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **SSS**

**Orijinal yazı tipi makinede mevcut değilse, öngörülebilir yazı tiplerini nasıl garanti edebilirim?**

Orijinal yazı tipi eksik olduğunda yedek yazı tipi olarak kullanılan [set_DefaultRegularFont](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) metodunu [XamlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/) içinde kullanın — bu, beklenmedik ikamelerden kaçınmanıza yardımcı olur.

**Dışa aktarılan XAML yalnızca WPF için mi amaçlanmıştır, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

XAML, WPF, UWP ve Xamarin.Forms içinde kullanılan genel bir UI işaretleme dilidir. Dışa aktarma, Microsoft XAML yığınlarıyla uyumluluğu hedefler; belirli yapılar için kesin davranış ve destek hedef platforma bağlıdır. İşaretlemenizi ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engelleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [set_ExportHiddenSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) yöntemiyle [XamlOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export.xaml/xamloptions/) içinde kontrol edebilirsiniz — ihtiyacınız yoksa devre dışı bırakın.