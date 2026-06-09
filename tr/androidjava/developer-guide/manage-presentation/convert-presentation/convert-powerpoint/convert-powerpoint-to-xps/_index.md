---
title: Android'de PowerPoint Sunumlarını XPS'e Dönüştürme
linktitle: PowerPoint'ten XPS'e
type: docs
weight: 70
url: /tr/androidjava/convert-powerpoint-to-xps/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten XPS'e
- sunumu XPS'e
- slaytı XPS'e
- PPT'yi XPS'e
- PPTX'i XPS'e
- PPT'yi XPS olarak kaydet
- PPTX'i XPS olarak kaydet
- PPT'yi XPS'e dışa aktar
- PPTX'i XPS'e dışa aktar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak Java'da PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, platform bağımsız XPS'e dönüştürün. Adım adım kılavuz ve örnek kodu alın."
---
## **Genel Bakış**

Aspose.Slides, bir PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'e dönüştürmenizi sağlar. Bu makale, XPS formatının ne zaman faydalı olabileceğini açıklar ve Aspose.Slides ile varsayılan ayarları veya özel [XpsOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions/) ayarlarını kullanarak dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**
Microsoft, [PDF](https://docs.fileformat.com/pdf/) alternatif bir format olarak [XPS](https://docs.fileformat.com/page-description-language/xps/) geliştirdi. XPS, PDF'ye çok benzer bir dosya üreterek içeriği yazdırmanıza olanak tanır. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemleri ve yazıcılarda aynı kalır. 

## **Microsoft XPS Formatını Ne Zaman Kullanmalısınız**

{{% alert color="primary" %}} 

Aspose.Slides'in PPT veya PPTX sunumlarını XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerini azaltmak istiyorsanız, Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Böylece belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olur. 

Microsoft, Windows'ta (Windows 10'da bile) XPS için güçlü destek sağlamaya devam ediyor, bu yüzden dosyaları bu formatta kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, XPS belirli işlemler için en iyi seçenek olabilir. 

- **Windows 8** XPS dosyaları için OXPS (Open XPS) formatını kullanır. OXPS, orijinal XPS formatının standartlandırılmış bir sürümüdür. Windows 8, XPS dosyalarına PDF dosyalarına göre daha iyi destek sağlar. 
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS'e yazdırma özelliği mevcut. 
  - **PDF**: PDF okuyucu mevcut ama PDF'ye yazdırma özelliği yok. 

- **Windows 7 ve Windows Vista** orijinal XPS formatını kullanır. Bu işletim sistemleri de PDF'lere göre XPS dosyalarına daha iyi destek sağlar. 
  - **XPS**: Yerleşik XPS görüntüleyici ve XPS'e yazdırma özelliği mevcut. 
  - **PDF**: PDF okuyucu yok. PDF'ye yazdırma özelliği yok. 

|<p>**Girdi PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, sonunda Windows 10'da PDF'ye yazdırma işlevi olan Print to PDF özelliğiyle PDF yazdırma desteği ekledi. Daha önce, kullanıcıların belgeleri XPS formatı üzerinden yazdırmaları bekleniyordu. 

## **Aspose.Slides ile XPS Dönüşümü**

Java için [**Aspose.Slides**](https://products.aspose.com/slides/tr/androidjava/) içinde, tüm sunumu bir XPS belgesine dönüştürmek için [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı tarafından sunulan [**Save**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemini kullanabilirsiniz.

Bir sunumu XPS'ye dönüştürürken, sunumu aşağıdaki ayarlardan biriyle kaydetmeniz gerekir:

- Varsayılan ayarlar ( [**XPSOptions**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions) olmadan )
- Özel ayarlar ( [**XPSOptions**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions) ile )

### **Varsayılan Ayarları Kullanarak Sunumları XPS'e Dönüştürme**

Bu Java örnek kodu, standart ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Sunumu XPS belgesine kaydediyor
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Özel Ayarları Kullanarak Sunumları XPS'e Dönüştürme**
Bu örnek kod, Java'da özel ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekleyin
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions sınıfını örnekleyin
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

**XPS'yi bir dosya yerine akışa kaydedebilir miyim?**

Evet—Aspose.Slides, XPS'yi doğrudan bir akışa dışa aktarmanıza izin verir; bu, web API'leri, sunucu tarafı işlem hatları veya XPS'yi dosya sistemine dokunmadan göndermek istediğiniz herhangi bir senaryo için idealdir.

**Gizli slaytlar XPS'ye taşınıyor mu ve bunları hariç tutabilir miyim?**

Varsayılan olarak, yalnızca normal (görünür) slaytlar oluşturulur. XPS'ye kaydetmeden önce [dışa aktarma ayarları](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions/) aracılığıyla gizli slaytları [dahil edebilir veya hariç tutabilirsiniz](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-), böylece çıktı tam olarak istediğiniz sayfaları içerir.