---
title: PowerPoint Sunumlarını C++ ile XPS'e Dönüştür
linktitle: PowerPoint'ten XPS'e
type: docs
weight: 70
url: /tr/cpp/convert-powerpoint-to-xps
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten XPS'e
- sunumu XPS'e
- slaytı XPS'e
- PPT'yi XPS'e
- PPTX'i XPS'e
- PPT'yi XPS olarak kaydet
- PPTX'i XPS olarak kaydet
- PPT'yi XPS'ye aktar
- PPTX'i XPS'ye aktar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++ ile PowerPoint PPT/PPTX'i yüksek kaliteli, platform bağımsız XPS'e dönüştürün. Adım adım kılavuz ve örnek kod alın."
---
## **Genel Bakış**

Aspose.Slides, PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'e dönüştürmenizi sağlar. Bu makale, XPS formatının ne zaman faydalı olabileceğini açıklar ve Aspose.Slides ile varsayılan ayarları veya özel [XpsOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/xpsoptions/) ayarlarını kullanarak dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**

Microsoft, [XPS](https://docs.fileformat.com/page-description-language/xps/)’ı [PDF](https://docs.fileformat.com/pdf/)’a bir alternatif olarak geliştirdi. İçeriği PDF'ye çok benzer bir dosya oluşturarak yazdırmanıza olanak tanır. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemleri ve yazıcılarda aynı kalır. 

## **Microsoft XPS Formatını Ne Zaman Kullanmalısınız**

{{% alert color="primary" %}} 

Aspose.Slides'in PPT veya PPTX sunumunu XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerinizi azaltmak istiyorsanız, Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Bu sayede belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olacaktır. 

Microsoft, Windows’ta (Windows 10 dahil) XPS için güçlü destek sağlamaya devam ediyor, bu nedenle dosyaları bu formatta kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, XPS bazı işlemler için en iyi seçeneğiniz olabilir. 

- **Windows 8** XPS dosyaları için OXPS (Open XPS) formatını kullanır. OXPS, orijinal XPS formatının standartlaştırılmış bir sürümüdür. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek sağlar. 
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS’ye yazdırma özelliği mevcuttur. 
  - **PDF:** PDF okuyucu mevcut ancak PDF’ye yazdırma özelliği yok. 

- **Windows 7 ve Windows Vista** orijinal XPS formatını kullanır. Bu işletim sistemleri de PDF'ye göre XPS dosyalarına daha iyi destek sağlar. 
  - **XPS:** Yerleşik XPS görüntüleyici ve XPS’ye yazdırma özelliği mevcuttur. 
  - **PDF:** PDF okuyucu yok. PDF’ye yazdırma özelliği yok. 

|<p>**Giriş PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, Windows 10’da PDF’ye yazdırma özelliği aracılığıyla PDF için yazdırma işlemlerine destek ekledi. Önceden, kullanıcıların belgeleri XPS formatı üzerinden yazdırması bekleniyordu. 

## **Aspose.Slides ile XPS Dönüştürme**

C++ için [**Aspose.Slides**](https://products.aspose.com/slides/tr/cpp/) içinde, [**Save**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) metodunu, [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfı tarafından sunulan, tüm sunumu bir XPS belgesine dönüştürmek için kullanabilirsiniz. 

Bir sunumu XPS'ye dönüştürürken, sunumu aşağıdaki ayarlardan biriyle kaydetmeniz gerekir:

- Varsayılan ayarlar (without [**XPSOptions**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.xps_options))
- Özel ayarlar (with [**XPSOptions**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.export.xps_options))

### **Varsayılan Ayarları Kullanarak Sunumları XPS'e Dönüştürme**

C++ örnek kodu, bir sunumu standart ayarları kullanarak XPS belgesine nasıl dönüştüreceğinizi gösterir:

``` cpp
// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturur
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Sunumu XPS belgesine kaydediyor
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Özel Ayarları Kullanarak Sunumları XPS'e Dönüştürme**
C++'ta özel ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösteren örnek kod:

``` cpp
// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturur
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// TiffOptions sınıfını oluşturur
auto options = System::MakeObject<XpsOptions>();

// MetaDosyaları PNG olarak kaydet
options->set_SaveMetafilesAsPng(true);

// Sunumu XPS belgesine kaydet
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **SSS**

**XPS'yi bir dosya yerine akışa kaydedebilir miyim?**

Evet—Aspose.Slides, XPS'yi doğrudan bir akışa dışa aktarmanıza olanak tanır; bu, web API'leri, sunucu tarafı işlem hatları veya XPS'yi dosya sistemine dokunmadan göndermek istediğiniz herhangi bir senaryo için idealdir.

**Gizli slaytlar XPS'ye aktarılır mı ve bunları dışarı bırakabilir miyim?**

Varsayılan olarak yalnızca normal (görünür) slaytlar işlenir. XPS'ye kaydetmeden önce [dışa aktarma ayarları](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/xpsoptions/) aracılığıyla gizli slaytları [dahil edebilir veya hariç tutabilirsiniz](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/), böylece çıktı tam olarak istediğiniz sayfaları içerir.