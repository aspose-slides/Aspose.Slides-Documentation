---
title: Java’da PowerPoint Sunumlarını XPS’e Dönüştürme
linktitle: PowerPoint'ten XPS'e
type: docs
weight: 70
url: /tr/java/convert-powerpoint-to-xps/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan XPS'e
- sunumu XPS'e
- slaytı XPS'e
- PPT'den XPS'e
- PPTX'ten XPS'e
- PPT'yi XPS olarak kaydet
- PPTX'i XPS olarak kaydet
- PPT'yi XPS'e dışa aktar
- PPTX'i XPS'e dışa aktar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java’da PowerPoint PPT/PPTX dosyalarını yüksek kaliteli, platform bağımsız XPS’e dönüştürün. Adım adım kılavuz ve örnek kod alın."
---
## **Genel Bakış**

Aspose.Slides, bir PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'e dönüştürmenizi sağlar. Bu makale, XPS formatının ne zaman faydalı olabileceğini açıklar ve Aspose.Slides kullanarak varsayılan ayarlarla ya da özel [XpsOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions/) ayarlarıyla dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**
Microsoft, [PDF](https://docs.fileformat.com/pdf/) alternatifi olarak [XPS](https://docs.fileformat.com/page-description-language/xps/) geliştirdi. PDF’ye çok benzeyen bir dosya üreterek içeriği yazdırmanıza olanak tanır. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemleri ve yazıcılarda aynı kalır. 

## **Microsoft XPS Formatını Ne Zaman Kullanmalısınız**

{{% alert color="primary" %}} 

Aspose.Slides’ın PPT veya PPTX sunumunu XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 

{{% /alert %}} 

Depolama maliyetlerini azaltmak isterseniz, Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Böylece belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olur. 

Microsoft, Windows (Windows 10 dahil) üzerinde XPS desteğini güçlü bir şekilde sürdürmeye devam ediyor, bu yüzden dosyalarınızı bu formata kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, belirli işlemler için XPS aslında en iyi seçenek olabilir. 

- **Windows 8**, XPS dosyaları için OXPS (Open XPS) formatını kullanır. OXPS, orijinal XPS formatının standartlaştırılmış bir sürümüdür. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek sunar. 
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS’ye yazdırma özelliği mevcuttur. 
  - **PDF:** PDF okuyucu bulunur ancak PDF’ye yazdırma özelliği yoktur. 

- **Windows 7 ve Windows Vista**, orijinal XPS formatını kullanır. Bu işletim sistemleri de PDF’lere göre XPS dosyalarına daha iyi destek sağlar. 
  - **XPS:** Yerleşik XPS görüntüleyici ve XPS’ye yazdırma özelliği mevcuttur. 
  - **PDF:** PDF okuyucu yoktur. PDF’ye yazdırma özelliği yoktur. 

|<p>**Giriş PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft, Windows 10’da “Print to PDF” özelliği aracılığıyla PDF için yazdırma işlemlerine destek ekledi. Önceden, kullanıcıların belgeleri XPS formatı üzerinden yazdırması bekleniyordu. 

## **Aspose.Slides ile XPS Dönüştürme**

Java için [**Aspose.Slides**](https://products.aspose.com/slides/tr/java/) içinde, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfı tarafından sunulan [**Save**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) metodunu kullanarak tüm sunumu bir XPS belgesine dönüştürebilirsiniz. 

Sunumu XPS’e dönüştürürken aşağıdaki ayarlardan birini kullanarak sunumu kaydetmeniz gerekir:

- Varsayılan ayarlar ( [**XPSOptions**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions) olmadan )
- Özel ayarlar ( [**XPSOptions**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions) ile )

### **Varsayılan Ayarları Kullanarak Sunumları XPS’e Dönüştürme**

Java’da standart ayarları kullanarak bir sunumu XPS belgesine dönüştürmenin örnek kodu:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturun
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Sunumu XPS belgesine kaydediyor
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Özel Ayarları Kullanarak Sunumları XPS’e Dönüştürme**
Java’da özel ayarları kullanarak bir sunumu XPS belgesine dönüştürmenin örnek kodu:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini oluşturun
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // TiffOptions sınıfını oluşturun
    XpsOptions options = new XpsOptions();

    // MetaDosyaları PNG olarak kaydet
    options.setSaveMetafilesAsPng(true);

    // Sunumu XPS belgesine kaydedin
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**XPS’i bir dosya yerine akışa (stream) kaydedebilir miyim?**

Evet—Aspose.Slides, XPS’i doğrudan bir akışa dışa aktarmanıza olanak tanır; bu, web API’leri, sunucu tarafı işlem hatları veya dosya sistemine dokunmadan XPS gönderilmek istenen tüm senaryolar için idealdir.

**Gizli slaytlar XPS’e aktarılır mı ve onları hariç tutabilir miyim?**

Varsayılan olarak yalnızca normal (görünür) slaytlar işlenir. [**XPSOptions**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions/) üzerinden [gizli slaytları ekleme veya hariç tutma](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) ayarlarını yaparak kaydetmeden önce istediğiniz sayfaların tam olarak çıktı içinde yer almasını sağlayabilirsiniz.