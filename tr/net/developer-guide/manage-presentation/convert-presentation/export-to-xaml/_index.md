---
title: XAML'e Sunumları .NET'te Dışa Aktarma
linktitle: Sunumu XAML'e
type: docs
weight: 30
url: /tr/net/export-to-xaml/
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
- PPTX'ten XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te PowerPoint ve OpenDocument slaytlarını XAML'e dönüştürün—düzeninizi koruyan hızlı, Office'siz çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML’e dışa aktarmayı açıklar. XAML’e kısa bir giriş içerir, bir sunumu varsayılan ayarlarla XAML’e nasıl kaydedeceğinizi gösterir ve gizli slaytları dışa aktarmayı da içeren XamlOptions aracılığıyla dışa aktarmayı nasıl özelleştireceğinizi gösterir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarma davranışıyla ilgili birkaç yaygın soruya yanıt verir.

## **XAML Hakkında**

XAML, uygulamalar için kullanıcı arayüzleri oluşturmanıza veya yazmanıza olanak tanıyan tanımlayıcı bir programlama dilidir; özellikle WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin Forms kullananlar için.  
XML tabanlı bir dil olan XAML, Microsoft’un GUI tanımlama çeşididir. Çoğu zaman XAML dosyaları üzerinde çalışmak için bir tasarımcı kullanırsınız, ancak yine de GUI’nizi yazabilir ve düzenleyebilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML’e Dışa Aktarma**

Bu C# kodu, bir sunumu varsayılan ayarlarla XAML’e nasıl dışa aktaracağınızı gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **Özel Seçeneklerle Sunumları XAML’e Dışa Aktarma**

Dışa aktarma sürecini kontrol eden ve Aspose.Slides’ın sunumunuzu XAML’e nasıl dışa aktaracağını belirleyen IXamlOptions arabiriminden seçenekler seçebilirsiniz.  

Örneğin, Aspose.Slides'ın sunumunuzdan gizli slaytları XAML’e dışa aktarırken eklemesini istiyorsanız, ExportHiddenSlides özelliğini true olarak ayarlayabilirsiniz. Bu örnek C# koduna bakın:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **SSS**

**Orijinal yazı tipi makinede mevcut değilse öngörülebilir yazı tiplerini nasıl sağlayabilirim?**

XamlOptions içinde DefaultRegularFont özelliğini ayarlayın—orijinal yazı tipi eksik olduğunda yedek yazı tipi olarak kullanılır. Bu, beklenmeyen değiştirmeleri önlemeye yardımcı olur.  

**Dışa aktarılan XAML sadece WPF için mi tasarlanmıştır, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

XAML, WPF, UWP ve Xamarin.Forms'ta kullanılan genel bir UI işaretleme dilidir. Dışa aktarma, Microsoft XAML yığınlarıyla uyumluluğu hedefler; belirli yapılar için kesin davranış ve destek hedef platforma bağlıdır. İşaretlemeyi ortamınızda test edin.  

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl önleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı XamlOptions içindeki ExportHiddenSlides özelliğiyle kontrol edebilirsiniz—eğer dışa aktarmanıza gerek yoksa devre dışı bırakın.