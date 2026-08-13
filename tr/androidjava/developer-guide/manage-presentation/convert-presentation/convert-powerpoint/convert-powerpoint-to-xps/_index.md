---
title: Android'de PowerPoint Sunumlarını XPS'ye Dönüştürme
linktitle: PowerPoint'ten XPS'ye
type: docs
weight: 70
url: /tr/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak Java'da PowerPoint PPT/PPTX dosyalarını yüksek kalite, platform bağımsız XPS'ye dönüştürün. Adım adım kılavuz ve örnek kodu alın."
---
## **Genel Bakış**

Aspose.Slides, bir PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'ye dönüştürmenizi sağlar. Bu makale, XPS formatının ne zaman yararlı olabileceğini açıklar ve Aspose.Slides ile varsayılan ayarları veya özel [XpsOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions/) ayarlarını kullanarak dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**

Microsoft, [PDF](https://docs.fileformat.com/pdf/) alternatifi olarak [XPS](https://docs.fileformat.com/page-description-language/xps/) geliştirdi. PDF'ye çok benzer bir dosya üreterek içeriği yazdırmanıza olanak tanır. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemleri ve yazıcılarda aynı kalır. 

## **Microsoft XPS Formatını Ne Zaman Kullanmalısınız**

{{% alert color="info" %}} 

Aspose.Slides'in PPT veya PPTX sunumunu XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerini azaltmak istiyorsanız, Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Böylece belgeleri kaydetmek, paylaşmak ve yazdırmak daha kolay olur. 

Microsoft, Windows'ta (Windows 10’da bile) XPS için güçlü destek sağlamaya devam ediyor; bu nedenle dosyalarınızı bu formatta kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, belirli işlemler için XPS aslında en iyi seçeneğiniz olabilir. 

- **Windows 8** OXPS (Open XPS) formatını kullanır. OXPS, orijinal XPS formatının standartlaştırılmış sürümüdür. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek sunar. 
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS'ye yazdırma özelliği bulunur. 
  - **PDF:** PDF okuyucu bulunur ancak PDF'ye yazdırma özelliği yoktur. 

- **Windows 7 ve Windows Vista** orijinal XPS formatını kullanır. Bu işletim sistemleri de PDF'ye göre XPS dosyalarına daha iyi destek sağlar. 
  - **XPS:** Yerleşik XPS görüntüleyici ve XPS'ye yazdırma özelliği bulunur. 
  - **PDF:** PDF okuyucu yoktur. PDF'ye yazdırma özelliği yoktur. 

|<p>**Girdi PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, Windows 10’da Print to PDF özelliği sayesinde PDF’de yazdırma işlemleri için desteği sonunda sağladı. Daha önce kullanıcılar, belgeleri XPS formatı üzerinden yazdırmak zorundaydı. 

## **Aspose.Slides ile XPS Dönüştürme**

Java için [**Aspose.Slides**](https://products.aspose.com/slides/tr/androidjava/) içinde, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı tarafından sunulan [**Save**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metodunu kullanarak tüm sunumu bir XPS belgesine dönüştürebilirsiniz.

Bir sunumu XPS'ye dönüştürürken aşağıdaki ayarlardan birini kullanarak kaydetmeniz gerekir:

- Varsayılan ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions) olmadan)
- Özel ayarlar ([**XPSOptions**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions) ile)

### **Varsayılan Ayarları Kullanarak Sunumları XPS'ye Dönüştürme**

Java'da bu örnek kod, standart ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Sunumu XPS belgesine kaydediyor
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Özel Ayarları Kullanarak Sunumları XPS'ye Dönüştürme**

Bu örnek kod, Java'da özel ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturun
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // XpsOptions sınıfını oluşturun
    XpsOptions options = new XpsOptions();

    // MetaDosyaları PNG olarak kaydet
    options.setSaveMetafilesAsPng(true);

    // Sunumu XPS belgesine kaydet
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

### XPS'i bir dosya yerine akışa kaydedebilir miyim?

Evet—Aspose.Slides, XPS'i doğrudan bir akışa dışa aktarmanıza olanak tanır; bu, web API'leri, sunucu tarafı işlem hatları veya XPS'i dosya sistemine dokunmadan göndermek istediğiniz herhangi bir senaryo için idealdir.

### Gizli slaytlar XPS'ye taşınıyor mu ve onları dışarı bırakabilir miyim?

Varsayılan olarak yalnızca normal (görünür) slaytlar işlenir. XPS'ye kaydetmeden önce [gizli slaytları dahil etme veya hariç tutma](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) seçeneğini [dışa aktarma ayarları](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions/) üzerinden belirleyerek çıktıdaki sayfaların tam olarak istediğiniz gibi olmasını sağlayabilirsiniz.