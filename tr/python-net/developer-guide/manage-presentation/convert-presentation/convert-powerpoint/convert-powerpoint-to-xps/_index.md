---
title: Python'da PowerPoint Sunumlarını XPS'ye Dönüştürme
linktitle: PowerPoint'ten XPS'ye
type: docs
weight: 70
url: /tr/python-net/convert-powerpoint-to-xps/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- PowerPoint'ten XPS'ye
- sunumdan XPS'ye
- PPT'den XPS'ye
- PPTX'ten XPS'ye
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides kullanarak Python'da PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, platform bağımsız XPS'ye dönüştürün. Adım adım kılavuz ve örnek kod alın."
---
## **Genel Bakış**

Aspose.Slides, bir PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'ye dönüştürmenizi sağlar. Bu makale, XPS formatının ne zaman kullanışlı olabileceğini açıklar ve Aspose.Slides kullanarak varsayılan ayarlarla veya özel [XpsOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/xpsoptions/) ayarlarıyla dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**
Microsoft, [PDF](https://docs.fileformat.com/pdf/)e alternatif olarak [XPS](https://docs.fileformat.com/page-description-language/xps/) geliştirdi. PDF'e çok benzer bir dosya üreterek içeriği yazdırmanıza olanak tanır. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemleri ve yazıcılarda aynı kalır.

## Microsoft XPS Formatını Ne Zaman Kullanmalı

{{% alert color="primary" %}} 

Aspose.Slides'in PPT veya PPTX sunumunu XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerini azaltmak istiyorsanız, Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Böylece belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olacaktır.

Microsoft, Windows'ta (Windows 10'da bile) XPS için güçlü desteği sürdürdüğünden, dosyalarınızı bu formata kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, XPS belirli işlemler için en iyi seçenek olabilir.

- **Windows 8**, XPS dosyaları için OXPS (Open XPS) formatını kullanır. OXPS, orijinal XPS formatının standartlaştırılmış bir sürümüdür. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek sağlar.
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS'ye yazdırma özelliği mevcuttur.
  - **PDF**: PDF okuyucu mevcut ancak PDF'ye yazdırma özelliği yoktur.

- **Windows 7 ve Windows Vista**, orijinal XPS formatını kullanır. Bu işletim sistemleri de PDF'lere göre XPS dosyalarına daha iyi destek sağlar.
  - **XPS**: Yerleşik XPS görüntüleyici ve XPS'ye yazdırma özelliği mevcuttur.
  - **PDF**: PDF okuyucu yok. PDF'ye yazdırma özelliği yok.

|<p>**Girdi PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, Windows 10'da Print to PDF özelliğiyle PDF yazdırma işlemleri için destek ekledi. Daha önce kullanıcıların belgeleri XPS formatı üzerinden yazdırması bekleniyordu.

## Aspose.Slides ile XPS Dönüştürme

.NET için [**Aspose.Slides**](https://products.aspose.com/slides/tr/python-net/) içinde, [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfı tarafından sunulan [**Save**](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) metodunu kullanarak tüm sunumu bir XPS belgesine dönüştürebilirsiniz.

Sunumu XPS'ye dönüştürürken aşağıdaki ayarlardan birini kullanarak sunumu kaydetmeniz gerekir:

- Varsayılan ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/xpsoptions/) olmadan)
- Özel ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/xpsoptions/) ile)

### **Varsayılan Ayarlarla Sunumları XPS'ye Dönüştürme**

Python'da standart ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösteren örnek kod:

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
pres = slides.Presentation("Convert_XPS.pptx")

# Sunumu XPS belgesine kaydediyor
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```

### **Özel Ayarlarla Sunumları XPS'ye Dönüştürme**
Python'da özel ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösteren örnek kod:

```py
import aspose.slides as slides

# Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
pres = slides.Presentation("Convert_XPS_Options.pptx")

# TiffOptions sınıfını oluşturur
options = slides.export.XpsOptions()

# MetaFiles dosyalarını PNG olarak kaydeder
options.save_metafiles_as_png = True

# Sunumu XPS belgesine kaydeder
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **SSS**

**XPS'i bir dosya yerine bir akışa kaydedebilir miyim?**

Evet—Aspose.Slides, XPS'i doğrudan bir akışa dışa aktarmanıza izin verir; bu, web API'leri, sunucu tarafı işlem hatları veya dosya sistemine dokunmadan XPS göndermek istediğiniz herhangi bir senaryo için idealdir.

**Gizli slaytlar XPS'e aktarılıyor mu, ve bunları hariç tutabilir miyim?**

Varsayılan olarak yalnızca normal (görünür) slaytlar işlenir. [XPSOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/xpsoptions/) içinde [gizli slaytları göster/kapalı tut](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) seçeneğiyle gizli slaytları dahil edip etmeyi ayarlayarak, XPS'e kaydetmeden önce [dışa aktarma ayarları](https://reference.aspose.com/slides/tr/python-net/aspose.slides.export/xpsoptions/) üzerinden istediğiniz sayfaların çıktıya dahil edildiğinden emin olabilirsiniz.