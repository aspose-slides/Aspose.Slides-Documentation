---
title: JavaScript'te PowerPoint Sunumlarını XPS'e Dönüştürme
linktitle: PowerPoint'ten XPS'e
type: docs
weight: 70
url: /tr/nodejs-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten XPS'e
- sunumu XPS'e
- slaytı XPS'e
- PPT XPS'e
- PPTX XPS'e
- PPT'yi XPS olarak kaydet
- PPTX'i XPS olarak kaydet
- PPT'yi XPS'e dışa aktar
- PPTX'i XPS'e dışa aktar
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te Aspose.Slides for Node.js kullanarak PowerPoint PPT/PPTX'i yüksek kaliteli, platform bağımsız XPS'e dönüştürün. Adım adım kılavuz ve örnek kod alın."
---
## **Genel Bakış**

Aspose.Slides, bir PPT veya PPTX dosyasını XPS biçiminde kaydederek PowerPoint sunumlarını XPS’e dönüştürmenizi sağlar. Bu makale, XPS biçiminin ne zaman faydalı olabileceğini açıklar ve Aspose.Slides ile varsayılan ayarları veya özel [XpsOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xpsoptions/) ayarlarını kullanarak dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**

Microsoft, [PDF](https://docs.fileformat.com/pdf/) alternatif bir format olarak [XPS](https://docs.fileformat.com/page-description-language/xps/) geliştirdi. PDF’e çok benzeyen bir dosya oluşturarak içeriği yazdırmanıza olanak tanır. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemleri ve yazıcılarda aynı kalır. 

## **Microsoft XPS Formatı Ne Zaman Kullanılır**

{{% alert color="primary" %}} 

Aspose.Slides’ın PPT veya PPTX sunumlarını XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerini azaltmak istiyorsanız, Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Böylece belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olur. 

Microsoft, Windows’ta (Windows 10’da bile) XPS için güçlü destek sağlamaya devam ediyor; bu nedenle dosyalarınızı bu formata kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, belirli işlemler için XPS aslında en iyi seçenek olabilir. 

- **Windows 8**, XPS dosyaları için OXPS (Open XPS) formatını kullanır. OXPS, orijinal XPS formatının standartlaştırılmış bir sürümüdür. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek verir. 
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS’ye yazdırma özelliği mevcut. 
  - **PDF**: PDF okuyucu mevcut ancak PDF’ye yazdırma özelliği yok. 

- **Windows 7 ve Windows Vista**, orijinal XPS formatını kullanır. Bu işletim sistemleri de PDF’lere göre XPS dosyalarına daha iyi destek sunar. 
  - **XPS**: Yerleşik XPS görüntüleyici ve XPS’ye yazdırma özelliği mevcut. 
  - **PDF**: PDF okuyucu yok. PDF’ye yazdırma özelliği yok. 

|<p>**Giriş PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, Windows 10’da Print to PDF özelliğiyle PDF yazdırma işlemleri için destek ekledi. Daha önce kullanıcıların belgeleri XPS formatı üzerinden yazdırması bekleniyordu. 

## **Aspose.Slides ile XPS Dönüştürme**

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/tr/nodejs-java/) içinde, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfı tarafından sunulan [**save**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) metodunu kullanarak tüm sunumu bir XPS belgesine dönüştürebilirsiniz.

Sunumu XPS’e dönüştürürken aşağıdaki ayarlarla kaydetmeniz gerekir:

- Varsayılan ayarlar ( [**XPSOptions**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xpsoptions) olmadan )
- Özel ayarlar ( [**XPSOptions**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xpsoptions) ile )

### **Varsayılan Ayarları Kullanarak Sunumları XPS’e Dönüştürme**

Bu JavaScript örnek kodu, standart ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```javascript
// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturun
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Sunumu XPS belgesine kaydediyor
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Özel Ayarları Kullanarak Sunumları XPS’e Dönüştürme**

Bu örnek kod, JavaScript içinde özel ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```javascript
// Bir sunum dosyasını temsil eden Presentation nesnesi oluşturun
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions sınıfını örnekleyin
    var options = new aspose.slides.XpsOptions();
    // MetaDosyaları PNG olarak kaydet
    options.setSaveMetafilesAsPng(true);
    // Sunumu XPS belgesine kaydet
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**XPS’i bir dosya yerine akıta (stream) kaydedebilir miyim?**

Evet—Aspose.Slides, doğrudan bir akıta (stream) dışa aktarmaya izin verir; bu, web API’leri, sunucu tarafı boru hatları veya XPS’i dosya sistemine dokunmadan göndermek istediğiniz herhangi bir senaryo için idealdir.

**Gizli slaytlar XPS’e aktarılır mı, onları hariç tutabilir miyim?**

Varsayılan olarak yalnızca normal (görünür) slaytlar işlenir. [**XPSOptions**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xpsoptions/) üzerinden [gizli slaytları dahil etme veya hariç tutma](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) ayarını yaparak XPS’e kaydetmeden önce istediğiniz sayfaların çıktıda yer almasını sağlayabilirsiniz.