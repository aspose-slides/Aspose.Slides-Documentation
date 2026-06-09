---
title: Python ile XAML'ye Sunumları Dışa Aktarma
linktitle: XAML'ye Dışa Aktar
type: docs
weight: 30
url: /tr/python-net/export-to-xaml/
keywords:
- PowerPoint'i dışa aktar
- OpenDocument'i dışa aktar
- sunumu dışa aktar
- PowerPoint'i dönüştür
- OpenDocument'i dönüştür
- sunumu dönüştür
- PowerPoint'ten XAML'ye
- OpenDocument'ten XAML'ye
- sunumdan XAML'ye
- PPT'den XAML'ye
- PPTX'den XAML'ye
- ODP'den XAML'ye
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da PowerPoint ve OpenDocument slaytlarını XAML'ye dönüştürün—hızlı, Office gerektirmeyen ve düzeninizi bozmayan bir çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML'ye nasıl dışa aktaracağınızı açıklar. XAML'ye kısa bir giriş içerir, sunumu varsayılan ayarlarla XAML'ye nasıl kaydedeceğinizi gösterir ve [XamlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/) aracılığıyla dışa aktarmayı nasıl özelleştirebileceğinizi, gizli slaytların dışa aktarılması dahil, gösterir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarma davranışıyla ilgili birkaç yaygın soruya yanıt verir.

## **XAML Hakkında**

XAML, özellikle WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin formları kullanan uygulamalar için kullanıcı arayüzleri oluşturmanıza veya yazmanıza olanak tanıyan tanımlayıcı bir programlama dilidir.  

XML tabanlı bir dil olan XAML, Microsoft'un GUI'yi tanımlamak için kullandığı bir varyanttır. Çoğu zaman XAML dosyaları üzerinde çalışmak için bir tasarımcı kullanırsınız, ancak yine de GUI'nizi yazabilir ve düzenleyebilirsiniz. 

## **Sunumları Varsayılan Seçeneklerle XAML'ye Dışa Aktarma**

Bu Python kodu, bir sunumu varsayılan ayarlarla XAML'ye nasıl dışa aktaracağınızı gösterir:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Sunumları Özel Seçeneklerle XAML'ye Dışa Aktarma**

Dışa aktarma sürecini kontrol eden ve Aspose.Slides'ın sunumunuzu XAML'ye nasıl dışa aktaracağını belirleyen seçenekleri [XamlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/) sınıfından seçebilirsiniz. 

Örneğin, Aspose.Slides'ın sunumunuzdan gizli slaytları XAML'ye dışa aktarırken eklemesini istiyorsanız, [export_hidden_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) özelliğini `True` olarak ayarlayabilirsiniz. Bu örnek Python koduna bakın: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **SSS**

**Orijinal yazı tipi makinede bulunmadığında tahmin edilebilir yazı tiplerini nasıl sağlayabilirim?**

[XamlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/) içinde [default_regular_font](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) özelliğini ayarlayın — orijinal eksik olduğunda yedek yazı tipi olarak kullanılır. Bu, beklenmeyen ikameleri önlemeye yardımcı olur.

**Dışa aktarılmış XAML yalnızca WPF için mi tasarlanmıştır, yoksa başka XAML yığınlarında da kullanılabilir mi?**

XAML, WPF, UWP ve Xamarin.Forms'ta kullanılan genel bir UI işaretleme dilidir. Dışa aktarma, Microsoft XAML yığınlarıyla uyumluluğu hedefler; belirli yapıların kesin davranışı ve desteği hedef platforma bağlıdır. İşaretlemeyi ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl önleyebilirim?**

Varsayılan olarak, gizli slaytlar dahil edilmez. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/) içindeki [export_hidden_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) özelliğiyle kontrol edebilirsiniz — onları dışa aktarmanıza gerek yoksa devre dışı bırakın.