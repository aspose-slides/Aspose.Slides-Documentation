---
title: PowerPoint Sunumlarını .NET'te XPS'e Dönüştürme
linktitle: PowerPoint'ten XPS'e
type: docs
weight: 70
url: /tr/net/convert-powerpoint-to-xps/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten XPS'e
- sunumdan XPS'e
- slayttan XPS'e
- PPT'den XPS'e
- PPTX'ten XPS'e
- PPT'yi XPS olarak kaydet
- PPTX'i XPS olarak kaydet
- PPT'yi XPS'e dışa aktar
- PPTX'i XPS'e dışa aktar
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, platform bağımsız XPS'e dönüştürün. Adım adım rehber ve örnek C# kodunu alın."
---
## **Genel Bakış**

Aspose.Slides, PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'e dönüştürmenizi sağlar. Bu makale, XPS formatının ne zaman faydalı olabileceğini açıklar ve Aspose.Slides ile varsayılan ayarları veya özel [XpsOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions/) ayarlarını kullanarak dönüşümün nasıl yapılacağını gösterir.

## **XPS hakkında**

Microsoft, [XPS](https://docs.fileformat.com/page-description-language/xps/) adresini [PDF](https://docs.fileformat.com/pdf/) alternatif olarak geliştirdi. PDF'ye çok benzer bir dosya üreterek içeriği yazdırmanıza olanak tanır. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemleri ve yazıcılarda aynı kalır. 

## **Microsoft XPS Formatını Ne Zaman Kullanmalısınız**

{{% alert color="primary" %}} 

Aspose.Slides'in PPT veya PPTX sunumunu XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerini azaltmak istiyorsanız, Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Bu sayede belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olacaktır. 

Microsoft, Windows'ta (Windows 10'da bile) XPS için güçlü desteği uygulamaya devam ediyor, bu yüzden dosyaları bu formata kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, XPS belirli işlemler için en iyi seçenek olabilir. 

- **Windows 8** OXPS (Open XPS) formatını XPS dosyaları için kullanır. OXPS, orijinal XPS formatının standardize edilmiş sürümüdür. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek sağlar. 
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS'ye yazdırma özelliği mevcut. 
  - **PDF:** PDF okuyucu mevcut ancak PDF'ye yazdırma özelliği yok. 

- **Windows 7 ve Windows Vista** özgün XPS formatını kullanır. Bu işletim sistemleri de PDF'ye göre XPS dosyalarına daha iyi destek sağlar. 
  - **XPS:** Yerleşik XPS görüntüleyici ve XPS'ye yazdırma özelliği mevcut. 
  - **PDF:** PDF okuyucu yok. PDF'ye yazdırma özelliği yok. 

|<p>**Girdi PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, Windows 10'da PDF'ye yazdırma özelliği aracılığıyla PDF'de baskı işlemleri desteğini sonunda uyguladı. Daha önce kullanıcıların belgeleri XPS formatı üzerinden yazdırması bekleniyordu. 

## **Aspose.Slides ile XPS Dönüştürme**

.NET için [**Aspose.Slides**](https://products.aspose.com/slides/tr/net/) içinde, tüm sunumu bir XPS belgesine dönüştürmek için [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı tarafından sunulan [**Save**](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/methods/save/index) yöntemini kullanabilirsiniz. 

Bir sunumu XPS'ye dönüştürürken, sunumu aşağıdaki ayarlardan biriyle kaydetmeniz gerekir:

- Varsayılan ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions) olmadan)
- Özel ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions) ile)

### **Varsayılan Ayarları Kullanarak Sunumları XPS'e Dönüştürme**

Bu C# örnek kodu, standart ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```c#
// Bir sunum dosyasını temsil eden Presentation nesnesini oluştur
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Sunumu XPS belgesine kaydetme
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Özel Ayarları Kullanarak Sunumları XPS'e Dönüştürme**

Bu örnek kod, C#'ta özel ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```c#
// Bir sunum dosyasını temsil eden Presentation nesnesini oluştur
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // TiffOptions sınıfını oluştur
    XpsOptions options = new XpsOptions();

    // MetaFiles'i PNG olarak kaydet
    options.SaveMetafilesAsPng = true;

    // Sunumu XPS belgesine kaydet
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **SSS**

**XPS'yi bir dosya yerine akışa kaydedebilir miyim?**

Evet—Aspose.Slides, XPS'yi doğrudan bir akışa dışa aktarmanıza izin verir; bu, web API'leri, sunucu tarafı işlem hatları veya XPS'yi dosya sistemine dokunmadan göndermek istediğiniz herhangi bir senaryo için idealdir.

**Gizli slaytlar XPS'ye aktarılıyor mu ve onları dışarıda bırakabilir miyim?**

Varsayılan olarak, yalnızca normal (görünür) slaytlar işlenir. XPS'ye kaydetmeden önce [dışa aktarma ayarları](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions/) aracılığıyla [gizli slaytları dahil edebilir veya hariç tutabilirsiniz](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions/showhiddenslides/), böylece çıktı tam olarak istediğiniz sayfaları içerir.