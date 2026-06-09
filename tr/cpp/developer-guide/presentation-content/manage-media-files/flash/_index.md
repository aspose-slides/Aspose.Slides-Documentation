---
title: C++'ta Sunumlardan Flash Nesnelerini Çıkarma
linktitle: Flash
type: docs
weight: 10
url: /tr/cpp/flash/
keywords:
- flash çıkarma
- flash nesnesi
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta PowerPoint ve OpenDocument slaytlarından Flash nesnelerini nasıl çıkaracağınızı, tam kod örnekleri ve en iyi uygulamaları öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlardan Flash nesnelerini nasıl çıkarılacağını açıklar. Bir slaytın denetimler koleksiyonunda adıyla bir Flash denetimini bulmayı ve gömülü SWF nesne verileriyle çalışmayı gösterir.

## **Sunumlardan Flash Nesnelerini Çıkarma**
Aspose.Slides for C++ bir sunumdan flash nesnelerini çıkarmak için bir özellik sağlar. Flash denetimine adla erişebilir ve sunumdan çıkarabilir, ayrıca SWF nesne verilerini depolayabilirsiniz.

``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```

## **SSS**

**Flash içeriği çıkarılırken hangi sunum biçimleri desteklenir?**

[Aspose.Slides supports](/slides/tr/cpp/supported-file-formats/) ana PowerPoint formatları olan PPT ve PPTX'i destekler, çünkü bu kapsayıcıları yükleyebilir ve denetimlerine, Flash ile ilgili ActiveX öğeleri dahil, erişebilir.

**Flash içeren bir sunumu HTML5'e dönüştürüp Flash etkileşimini koruyabilir miyim?**

Hayır. Aspose.Slides SWF içeriğini çalıştırmaz veya etkileşimini dönüştürmez. [HTML](/slides/tr/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/tr/cpp/export-to-html5/) dışa aktarma desteklenirken, Flash modern tarayıcılarda destek sonu nedeniyle çalışmayacaktır. Önerilen yol, dışa aktarmadan önce Flash'ı video veya HTML5 animasyonları gibi alternatiflerle değiştirmektir.

**Güvenlik açısından, Aspose.Slides bir sunumu okurken SWF dosyalarını çalıştırır mı?**

Hayır. Aspose.Slides Flash'ı dosyada gömülü ikili veri olarak kabul eder ve işleme sırasında SWF içeriğini çalıştırmaz.

**Flash ile birlikte OLE aracılığıyla gömülmüş diğer dosyalar içeren sunumları nasıl ele almalıyım?**

Aspose.Slides [gömülü OLE nesnelerini çıkarmayı](/slides/tr/cpp/manage-ole/) destekler, böylece tüm ilgili gömülü içerikleri tek bir adımda işleyebilir, Flash denetimlerini ve diğer OLE ile gömülü belgeleri birlikte ele alabilirsiniz.