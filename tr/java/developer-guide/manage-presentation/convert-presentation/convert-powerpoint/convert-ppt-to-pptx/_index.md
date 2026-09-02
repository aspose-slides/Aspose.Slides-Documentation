---
title: Java'da PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/java/convert-ppt-to-pptx/
keywords:
  - PowerPoint dönüştür
  - sunum dönüştür
  - slayt dönüştür
  - PPT dönüştür
  - PPT'den PPTX'e
  - PPT'yi PPTX olarak kaydet
  - PPT'yi PPTX'e dışa aktar
  - PowerPoint
  - sunum
  - Java
  - Aspose.Slides
description: "Aspose.Slides ile Java'da eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notları için Java örnekleri içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for Java, bir PPT dosyasını Microsoft PowerPoint olmadan yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, bir dosya veya bir klasördeki dosyaları nasıl dönüştüreceğinizi gösterir ve dönüşüm sonrasında neyi doğrulamanız gerektiğini açıklar.

## **Bir PPT Dosyasını PPTX'e Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/#Pptx) argümanıyla çağırın. `finally` bloğu sunumu serbest bırakır ve kaynaklarını serbest bırakır.

```java
// Eski PPT sunumunu yükle.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Sunumu PPTX formatında kaydet.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dosya uzantısı, tek başına çıktı formatını seçmez; bu işlevi [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/#Pptx) argümanı yapar. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştür**

Aşağıdaki örnek, bir klasördeki her `.ppt` dosyasını dönüştürür. Her dosya bağımsız olarak işlenir, bu yüzden bir dönüştürme hatası diğerlerini durdurmaz.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Üretim ortamları için tam istisna kaydı tutun, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağına karar verin ve başarısız dosya adlarını tekrar deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik dönüşümün başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/slides/tr/java/password-protected-presentation/) bölümüne bakın.

## **Doğruluk ve Eski Özellikler**

Dönüşüm genellikle slaytları, ana şablonları, düzenleri, metni, şekilleri, görüntüleri, tabloları ve grafikleri korur. Ancak PPT ve PPTX, her özelliği aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX eşdeğeri olmayan bir eski özellik, normalleştirilebilir, çıkarılabilir veya farklı gösterilebilir.

Dönüştürülmüş dosyayı animasyonlar, geçişler, gömülü veya bağlantılı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir kullanılan yazı tipleri veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro‑destekli bir format değildir; VBA’nın mevcut kalması gerekiyorsa uygun makro‑destekli bir iş akışı kullanın. Ayrıca, gerekli yazı tiplerinin ve dış kaynakların, dönüştürülmüş sunumun açılacağı veya işleneceği ortamda bulunup bulunmadığını doğrulayın.

Önemli belgeler için, oluşturulan PPTX dosyasını programlı olarak yeniden açın ve temel slayt sayısını ve içeriği inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedeflenen görüntüleyicide karşılaştırın. Başarılı bir [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak değerlendirmeyin.

## **PPTX Ne Zaman Kullanılmalı**

Sunum, güncel PowerPoint sürümlerinde düzenlenecekse, Open XML paketleriyle çalışan sistemlerle değiş tokuş edilecekse veya eski ikili PPT’ye göre daha kolay incelenip kurtarılabilecek bir formatta saklanacaksa PPTX kullanın. Dönüştürülmüş sunum doğruluk kontrollerinizi geçtiğinde, orijinal PPT dosyasını arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görüntüler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Convert Presentations to Multiple Formats](/slides/tr/java/convert-presentation/) bölümündeki format‑özel yönergeleri kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) hizmetini kullanabilirsiniz. Tekrarlanabilir dönüşümler, toplu işleme veya uygulama düzeyinde hata yönetimi için Java API'sini kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/slides/tr/java/ppt-vs-pptx/)
- [Java'da Sunumları Kaydet](/slides/tr/java/save-presentation/)
- [Desteklenen Dosya Formatları](/slides/tr/java/supported-file-formats/)
- [Java'da Sunumları Aç](/slides/tr/java/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for Java, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özellik için tam doğruluk garanti edilmez. Makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir kullanılan yazı tipleri içerdiğinde oluşturulan dosyayı inceleyin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Eksik veya hatalı şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüşümden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyicilerde ve iş akışlarında doğrulayana kadar saklayın. Bu, bir eski özelliğin farklı dönüşmesi durumunda geri alma kopyası sağlar.