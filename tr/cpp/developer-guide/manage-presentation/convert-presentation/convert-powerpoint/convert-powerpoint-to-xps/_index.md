---
title: C++'ta PowerPoint Sunumlarını XPS'ye Dönüştürme
linktitle: PowerPoint'ten XPS'ye
type: docs
weight: 70
url: /tr/cpp/convert-powerpoint-to-xps
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten XPS'ye
- sunumu XPS'ye
- slaytı XPS'ye
- PPT'yi XPS'ye
- PPTX'i XPS'ye
- PPT'yi XPS olarak kaydet
- PPTX'i XPS olarak kaydet
- PPT'yi XPS'ye dışa aktar
- PPTX'i XPS'ye dışa aktar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta PowerPoint PPT/PPTX dosyalarını yüksek kalite, platform bağımsız XPS'ye dönüştürün. Adım adım kılavuz ve örnek kod alın."
---
## **Genel Bakış**

Aspose.Slides, bir PPT veya PPTX dosyasını XPS biçiminde kaydederek PowerPoint sunumlarını XPS’ye dönüştürmenizi sağlar. Bu makale, XPS biçiminin ne zaman faydalı olabileceğini açıklar ve Aspose.Slides kullanarak varsayılan ayarlar veya özelleştirilmiş [XpsOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/xpsoptions/) ayarları ile dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**
Microsoft, [XPS](https://docs.fileformat.com/page-description-language/xps/)’yi [PDF](https://docs.fileformat.com/pdf/)’ye alternatif olarak geliştirdi. PDF’e çok benzer bir dosya üreterek içeriği yazdırmanıza olanak tanır. XPS biçimi XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemlerinde ve yazıcılarda aynı kalır. 

## **Microsoft XPS Biçimini Ne Zaman Kullanmalısınız**

{{% alert color="info" %}} 

Aspose.Slides’ın PPT veya PPTX sunumunu XPS biçimine nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasını](https://products.aspose.app/slides/tr/conversion) inceleyebilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerini azaltmak istiyorsanız Microsoft PowerPoint sunumunuzu XPS biçimine dönüştürebilirsiniz. Böylece belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olur. 

Microsoft, Windows’ta (Windows 10’da dahi) XPS’e güçlü destek sağlamaya devam ediyor; bu yüzden dosyalarınızı bu biçimde kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, belirli işlemler için XPS aslında en iyi seçeneğiniz olabilir. 

- **Windows 8** XPS dosyaları için OXPS (Open XPS) biçimini kullanır. OXPS, orijinal XPS biçiminin standartlaştırılmış bir sürümüdür. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek sunar. 
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS’ye yazdırma özelliği mevcut. 
  - **PDF:** PDF okuyucu mevcut ancak PDF’ye yazdırma özelliği yok. 

- **Windows 7 ve Windows Vista** orijinal XPS biçimini kullanır. Bu işletim sistemleri de PDF dosyalarına göre XPS dosyalarına daha iyi destek verir. 
  - **XPS:** Yerleşik XPS görüntüleyici ve XPS’ye yazdırma özelliği mevcut. 
  - **PDF:** PDF okuyucu yok. PDF’ye yazdırma özelliği yok. 

|<p>**Giriş PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, Windows 10’da “Print to PDF” özelliği sayesinde PDF’ye yazdırma desteğini sonunda uygulamaya koydu. Daha önce kullanıcıların belgelerini XPS biçimi üzerinden yazdırması bekleniyordu. 

## **Aspose.Slides ile XPS Dönüştürme**

[C++ için **Aspose.Slides**](https://products.aspose.com/slides/tr/cpp/) içinde, [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı tarafından sunulan [**Save**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metodunu kullanarak tüm sunumu bir XPS belgesine dönüştürebilirsiniz. 

Bir sunumu XPS’ye dönüştürürken aşağıdaki ayarlardan birini kullanarak kaydetmeniz gerekir:

- Varsayılan ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.xps_options) olmadan)
- Özelleştirilmiş ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.xps_options) ile)

### **Varsayılan Ayarları Kullanarak Sunumları XPS’ye Dönüştürme**

Aşağıdaki C++ örnek kodu, standart ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantiate a Presentation object that represents a presentation file
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Saving the presentation to XPS document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Özelleştirilmiş Ayarları Kullanarak Sunumları XPS’ye Dönüştürme**

Bu örnek kod, C++ içinde özelleştirilmiş ayarlarla bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Bir sunum dosyasını temsil eden bir Presentation nesnesi oluştur
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptions sınıfını örnekle
auto options = System::MakeObject<XpsOptions>();

// MetaDosyalarını PNG olarak kaydet
options->set_SaveMetafilesAsPng(true);

// Sunumu XPS belgesi olarak kaydet
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **SSS**

### XPS’yi bir dosya yerine akışa kaydedebilir miyim?

Evet—Aspose.Slides, doğrudan bir akışa dışa aktarmanıza olanak tanır; bu, web API’leri, sunucu tarafı işlem hatları veya XPS’yi dosya sistemine dokunmadan göndermek istediğiniz herhangi bir senaryo için idealdir.

### Gizli slaytlar XPS’ye aktarılır mı ve bunları hariç tutabilir miyim?

Varsayılan olarak yalnızca normal (görünür) slaytlar işlenir. [export settings](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/xpsoptions/) kullanarak [gizli slaytları ekleyebilir veya hariç tutabilirsiniz](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/), böylece kaydedilen XPS çıktısı tam olarak istediğiniz sayfaları içerir.