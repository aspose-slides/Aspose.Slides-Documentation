---
title: Java’da PowerPoint Sunumlarını XPS’ye Dönüştürme
linktitle: PowerPoint’tan XPS’ye
type: docs
weight: 70
url: /tr/java/convert-powerpoint-to-xps/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint’tan XPS’ye
- sunumdan XPS’ye
- slayttan XPS’ye
- PPT’den XPS’ye
- PPTX’den XPS’ye
- PPT'yi XPS olarak kaydet
- PPTX'i XPS olarak kaydet
- PPT'yi XPS’ye dışa aktar
- PPTX'i XPS’ye dışa aktar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java’da PowerPoint PPT/PPTX'yi yüksek kaliteli, platform bağımsız XPS'ye dönüştürün. Adım adım kılavuz ve örnek kod alın."
---
## **Genel Bakış**

Aspose.Slides, PPT veya PPTX dosyasını XPS formatında kaydederek PowerPoint sunumlarını XPS'ye dönüştürmenizi sağlar. Bu makale, XPS formatının ne zaman faydalı olabileceğini açıklar ve Aspose.Slides ile varsayılan ayarları veya özel [XpsOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions/) ayarlarını kullanarak dönüşümün nasıl yapılacağını gösterir.

## **XPS Hakkında**

Microsoft, [XPS](https://docs.fileformat.com/page-description-language/xps/) ‘i, [PDF](https://docs.fileformat.com/pdf/) ‘e bir alternatif olarak geliştirdi. İçeriği bir PDF’ye çok benzeyen bir dosya olarak çıktı almanıza olanak tanır. XPS formatı XML tabanlıdır. Bir XPS dosyasının düzeni veya yapısı tüm işletim sistemlerinde ve yazıcılarda aynı kalır. 

## **Microsoft XPS Formatını Ne Zaman Kullanmalısınız**

{{% alert color="info" %}} 
Aspose.Slides’in PPT veya PPTX sunumunu XPS formatına nasıl dönüştürdüğünü görmek için [bu ücretsiz çevrimiçi dönüştürücü uygulamasına](https://products.aspose.app/slides/tr/conversion) göz atabilirsiniz. 
{{% /alert %}} 

Depolama maliyetlerini azaltmak isterseniz Microsoft PowerPoint sunumunuzu XPS formatına dönüştürebilirsiniz. Böylece belgelerinizi kaydetmek, paylaşmak ve yazdırmak daha kolay olur. 

Microsoft, Windows (Windows 10 dahil) içinde XPS’e güçlü destek eklemeye devam ediyor; bu nedenle dosyalarınızı bu formata kaydetmeyi düşünebilirsiniz. Windows 8.1, Windows 8, Windows 7 ve Windows Vista ile çalışıyorsanız, belirli işlemler için XPS aslında en iyi seçenek olabilir. 

- **Windows 8** XPS dosyaları için OXPS (Open XPS) formatını kullanır. OXPS, orijinal XPS formatının standartlaştırılmış bir sürümüdür. Windows 8, PDF dosyalarına göre XPS dosyalarına daha iyi destek sağlar. 
  - **XPS:** Yerleşik XPS görüntüleyici/okuyucu ve XPS’ye yazdırma özelliği bulunur. 
  - **PDF:** PDF okuyucu bulunur ancak PDF’ye yazdırma özelliği yoktur. 

- **Windows 7 ve Windows Vista** orijinal XPS formatını kullanır. Bu işletim sistemleri de PDF’lere göre XPS dosyalarına daha iyi destek sunar. 
  - **XPS:** Yerleşik XPS görüntüleyici ve XPS’ye yazdırma özelliği bulunur. 
  - **PDF:** PDF okuyucu yoktur. PDF’ye yazdırma özelliği yoktur. 

|<p>**Girdi PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Çıktı XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft, Windows 10’da Print to PDF özelliğiyle PDF’ye yazdırma desteği ekledi. Daha önce kullanıcıların belgeleri XPS formatı üzerinden yazdırması bekleniyordu. 

## **XPS Dönüştürme Aspose.Slides ile**

Java için [**Aspose.Slides**](https://products.aspose.com/slides/tr/java/) içinde, tüm sunumu bir XPS belgesine dönüştürmek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfı tarafından sunulan [**Save**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemini kullanabilirsiniz. 

Bir sunumu XPS’ye dönüştürürken aşağıdaki ayarlardan birini kullanarak sunumu kaydetmelisiniz:

- Varsayılan ayarlar ( [**XPSOptions**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions) olmadan)
- Özel ayarlar ( [**XPSOptions**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions) ile)

### **Sunumları Varsayılan Ayarlarla XPS'ye Dönüştürme**

Bu Java örnek kodu, standart ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Sunumu XPS belgesine kaydediyor
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Sunumları Özel Ayarlarla XPS'ye Dönüştürme**

Bu örnek kod, Java’da özel ayarları kullanarak bir sunumu XPS belgesine nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // XpsOptions sınıfını oluşturur
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

### Bir dosya yerine XPS'yi bir akışa kaydedebilir miyim?

Evet—Aspose.Slides, XPS'yi doğrudan bir akışa dışa aktarmanıza izin verir; bu, web API’leri, sunucu tarafı işlem hatları veya dosya sistemine dokunmadan XPS gönderilmesi gereken herhangi bir senaryo için idealdir.

### Gizli slaytlar XPS'ye aktarılıyor mu ve onları hariç tutabilir miyim?

Varsayılan olarak yalnızca normal (görünür) slaytlar işlenir. [gizli slaytları dahil etme veya hariç tutma](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) için [dışa aktarma ayarları](https://reference.aspose.com/slides/tr/java/com.aspose.slides/xpsoptions/) üzerinden XPS’ye kaydetmeden önce gerekli ayarlamaları yapabilirsiniz, böylece çıktı tam olarak istediğiniz sayfaları içerir.