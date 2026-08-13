---
title: PowerPoint Sunumlarını .NET'te XPS'ye Dönüştürme
linktitle: PowerPoint'ten XPS'ye
type: docs
weight: 70
url: /tr/net/convert-powerpoint-to-xps/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te PowerPoint PPT/PPTX'yi yüksek kaliteli, platform bağımsız XPS'ye dönüştürün. Adım adım kılavuz ve örnek C# kodu alın."
---
## **Genel Bakış**

Aspose.Slides, bir PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'ye dönüştürmenizi sağlar. Bu makale, XPS formatının ne zaman faydalı olabileceğini açıklar ve Aspose.Slides kullanarak varsayılan ayarlarla veya özel [XpsOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions/) ayarlarıyla dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**

Microsoft, [XPS](https://docs.fileformat.com/page-description-language/xps/)’yi [PDF](https://docs.fileformat.com/pdf/)’ye bir alternatif olarak geliştirdi. PDF’ye çok benzeyen bir dosya üreterek içeriği yazdırmanıza olanak tanır. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemleri ve yazıcılarda aynı kalır.

## **Microsoft XPS Formatını Ne Zaman Kullanmalısınız**

{{% alert color="info" %}} 

Aspose.Slides'in PPT veya PPTX sunumunu XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerini azaltmak istiyorsanız, Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Böylece belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olacaktır.  

Microsoft, Windows'ta (Windows 10'da bile) XPS için güçlü desteği sürdürdüğü için dosyaları bu formata kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, XPS belirli işlemler için en iyi seçeneğiniz olabilir.  

- **Windows 8** OXPS (Open XPS) formatını XPS dosyaları için kullanır. OXPS, orijinal XPS formatının standartlaştırılmış bir versiyonudur. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek sağlar.  
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS'ye yazdırma özelliği mevcut.  
  - **PDF**: PDF okuyucu mevcut ancak PDF'ye yazdırma özelliği yok.  

- **Windows 7 ve Windows Vista** orijinal XPS formatını kullanır. Bu işletim sistemleri de PDF'lere göre XPS dosyalarına daha iyi destek sağlar.  
  - **XPS**: Yerleşik XPS görüntüleyici ve XPS'ye yazdırma özelliği mevcut.  
  - **PDF**: PDF okuyucu yok. PDF'ye yazdırma özelliği yok.  

|<p>**Giriş PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, sonunda Windows 10'da PDF'ye Yazdır özelliği aracılığıyla PDF'de yazdırma işlemleri desteğini uygulamaya koydu. Daha önce, kullanıcıların belgeleri XPS formatı üzerinden yazdırması bekleniyordu.  

## **Aspose.Slides ile XPS Dönüştürme**

.NET için [**Aspose.Slides**](https://products.aspose.com/slides/tr/net/) içinde, tüm sunumu bir XPS belgesine dönüştürmek için [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı tarafından sunulan [**Save**](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/methods/save/index) metodunu kullanabilirsiniz.  

Bir sunumu XPS'ye dönüştürürken, sunumu aşağıdaki ayarlardan biriyle kaydetmeniz gerekir:  

- Varsayılan ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions) olmadan)  
- Özel ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions) ile)  

### **Varsayılan Ayarlarla Sunumları XPS'ye Dönüştürme**

Bu C# örnek kod, bir sunumu standart ayarlarla XPS belgesine nasıl dönüştüreceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturma
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Sunumu XPS belgesine kaydetme
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Özel Ayarlarla Sunumları XPS'ye Dönüştürme**

Bu örnek kod, bir sunumu C#'ta özel ayarlarla XPS belgesine nasıl dönüştüreceğinizi gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturma
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // TiffOptions sınıfını oluşturma
    XpsOptions options = new XpsOptions();

    // MetaFiles'i PNG olarak kaydet
    options.SaveMetafilesAsPng = true;

    // Sunumu XPS belgesine kaydet
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **SSS**

### XPS'yi bir dosya yerine akışa kaydedebilir miyim?

Evet—Aspose.Slides, XPS'yi doğrudan bir akışa dışa aktarmanıza olanak tanır; bu, web API'leri, sunucu tarafı iş akışları veya XPS'yi dosya sistemine dokunmadan göndermek istediğiniz herhangi bir senaryo için idealdir.  

### Gizli slaytlar XPS'ye aktarılıyor mu ve onları dışlamam mümkün mü?

Varsayılan olarak, yalnızca normal (görünür) slaytlar işlenir. XPS'ye kaydetmeden önce [dışa aktarım ayarları](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions/) aracılığıyla gizli slaytları [dahil edebilir veya dışlayabilirsiniz](https://reference.aspose.com/slides/tr/net/aspose.slides.export/xpsoptions/showhiddenslides/), böylece çıktı tam olarak istediğiniz sayfaları içerir.