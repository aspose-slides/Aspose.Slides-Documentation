---
title: PowerPoint Sunumlarını PHP'de XPS'ye Dönüştürme
linktitle: PowerPoint'ten XPS'ye
type: docs
weight: 70
url: /tr/php-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten XPS'ye
- sunum XPS'ye
- slayt XPS'ye
- PPT XPS'ye
- PPTX XPS'ye
- PPT'yi XPS olarak kaydet
- PPTX'i XPS olarak kaydet
- PPT'yi XPS'ye dışa aktar
- PPTX'i XPS'ye dışa aktar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, platform bağımsız XPS'ye dönüştürün. Adım adım kılavuz ve örnek kod alın."
---
## **Genel Bakış**

Aspose.Slides, bir PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'ye dönüştürmenizi sağlar. Bu makale, XPS formatının ne zaman faydalı olabileceğini açıklar ve Aspose.Slides ile varsayılan ayarlar veya özel [XpsOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xpsoptions/) ayarları kullanarak dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**
Microsoft, [XPS](https://docs.fileformat.com/page-description-language/xps/) i [PDF](https://docs.fileformat.com/pdf/) alternatif olarak geliştirdi. Bir PDF'ye çok benzer bir dosya üreterek içeriği yazdırmanızı sağlar. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemlerinde ve yazıcılarda aynı kalır. 

## **Microsoft XPS Formatını Ne Zaman Kullanmalısınız**

{{% alert color="primary" %}} 

Aspose.Slides'in PPT veya PPTX sunumlarını XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerini düşürmek istiyorsanız, Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Bu sayede belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olacaktır. 

Microsoft, Windows'ta (Windows 10’da bile) XPS desteğini güçlü bir şekilde uygulamaya devam ediyor; bu yüzden dosyaları bu formata kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, XPS belirli işlemler için en iyi seçeneğiniz olabilir. 

- **Windows 8**, XPS dosyaları için OXPS (Open XPS) formatını kullanır. OXPS, orijinal XPS formatının standartlaştırılmış bir sürümüdür. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek sunar. 
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS’ye yazdırma özelliği bulunur. 
  - **PDF:** PDF okuyucu bulunur ancak PDF’ye yazdırma özelliği yoktur. 

- **Windows 7 ve Windows Vista**, orijinal XPS formatını kullanır. Bu işletim sistemleri de PDF'ye göre XPS dosyalarına daha iyi destek sağlar. 
  - **XPS:** Yerleşik XPS görüntüleyici ve XPS’ye yazdırma özelliği bulunur. 
  - **PDF:** PDF okuyucu yoktur. PDF’ye yazdırma özelliği yoktur. 

|<p>**Girdi PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, Windows 10’da PDF'ye yazdırma özelliği (Print to PDF) aracılığıyla PDF desteğini sonunda ekledi. Daha önce kullanıcıların belgeleri XPS formatı üzerinden yazdırması bekleniyordu. 

## **Aspose.Slides ile XPS Dönüştürme**

Java için [**Aspose.Slides**](https://products.aspose.com/slides/tr/php-java/) içinde, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfı tarafından sunulan [**Save**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metodunu kullanarak tüm sunumu bir XPS belgesine dönüştürebilirsiniz.

Bir sunumu XPS’ye dönüştürürken, sunumu aşağıdaki ayarlardan biriyle kaydetmelisiniz:

- Varsayılan ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xpsoptions/) olmadan)
- Özel ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xpsoptions/) ile)

### **Varsayılan Ayarları Kullanarak Sunumları XPS’ye Dönüştürme**

Bu örnek kod, standart ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```php
  # Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Sunumu XPS belgesine kaydetme
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Özel Ayarları Kullanarak Sunumları XPS’ye Dönüştürme**
Bu örnek kod, özel ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```php
  # Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # TiffOptions sınıfını oluşturun
    $options = new XpsOptions();
    # MetaFiles'ı PNG olarak kaydet
    $options->setSaveMetafilesAsPng(true);
    # Sunumu XPS belgesine kaydet
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**XPS’i bir dosya yerine akışa (stream) kaydedebilir miyim?**

Evet—Aspose.Slides, doğrudan bir akışa (stream) dışa aktarım yapmanıza olanak tanır; bu, web API'leri, sunucu‑tarafı işlem hatları veya XPS’i dosya sistemine dokunmadan göndermek istediğiniz herhangi bir senaryo için idealdir.

**Gizli slaytlar XPS’e aktarılıyor mu ve onları hariç tutabilir miyim?**

Varsayılan olarak yalnızca normal (görünür) slaytlar işlenir. [gizli slaytları dahil etme veya hariç tutma](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) için [dışa aktarma ayarlarını](https://reference.aspose.com/slides/tr/php-java/aspose.slides/xpsoptions/) XPS’e kaydetmeden önce kullanabilirsiniz; bu sayede çıktıda tam olarak istediğiniz sayfalar bulunur.