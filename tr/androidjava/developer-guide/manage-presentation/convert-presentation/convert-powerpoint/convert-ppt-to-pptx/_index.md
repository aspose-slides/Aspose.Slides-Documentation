---
title: Android'de PPT'yi PPTX'e dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPT'den PPTX'e
- PPT'yi PPTX olarak kaydet
- PPT'yi PPTX'e dışa aktar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides ile Android'de eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata işleme ve doğruluk notaları için Java örneklerini içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for Android via Java, bir PPT dosyasını Microsoft PowerPoint olmadan yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, bir dosya ya da bir dizindeki dosyaların nasıl dönüştürüleceğini gösterir ve dönüşüm sonrası neyin doğrulanması gerektiğini açıklar.

## **Bir PPT Dosyasını PPTX'e Dönüştürme**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/#Pptx) ile çağırın. `finally` bloğu sunumu serbest bırakır ve kaynaklarını serbest bırakır.

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

Dosya uzantısı, çıktıyı kendiliğinden belirlemez; bunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/#Pptx) argümanı yapar. Orijinal PPT dosyasını korumanız gerekiyorsa, giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştürme**

Aşağıdaki örnek, bir dizindeki tüm `.ppt` dosyalarını dönüştürür. Her dosya bağımsız olarak işlenir, böylece bir dönüştürme hatası, kalan toplu işin durmasını engellemez.

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

Üretim ortamları için, tam istisnayı günlüğe kaydedin, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağına karar verin ve başarısız dosya adlarını yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik, dönüştürmenin başarısız olmasına neden olabilir. Şifreli dosyaların yüklenmesi için [Password-Protected Presentations](/androidjava/password-protected-presentation/) bölümüne bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme genellikle slaytları, ana slaytları, yerleşimleri, metni, şekilleri, görüntüleri, tabloları ve grafikleri korur. Ancak PPT ve PPTX, her özelliği tam olarak aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX eşdeğeri olmayan bir eski özellik, normalleştirilebilir, atlanabilir veya farklı gösterilebilir.

Dönüştürülen dosyayı, animasyonlar, geçişler, gömülü veya bağlantılı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir kullanılan yazı tipleri veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro etkin bir format değildir; bu nedenle VBA'nın kullanılabilir kalması gerektiğinde uygun makro etkin iş akışı kullanın. Ayrıca, dönüştürülen sunumun açılacağı veya renderlanacağı ortamda gerekli yazı tiplerinin ve dış kaynakların mevcut olduğundan emin olun.

Önemli belgeler için, oluşturulan PPTX'i programlı olarak yeniden açın ve ana slayt sayısını ve içeriğini inceleyin, ardından istenen görüntüleyicide görünümünü ve slayt gösterisi davranışını karşılaştırın. Başarılı bir [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak değerlendirilmeyin.

## **Ne Zaman PPTX Kullanmalı**

Sunum mevcut PowerPoint sürümlerinde düzenlenecekse, Open XML paketleriyle çalışan sistemlerle değiştirilecekse veya eski ikili PPT'ye göre daha kolay incelenip kurtarılabilen bir formatta saklanacaksa PPTX kullanın. Dönüştürülen sunum doğruluk kontrollerinizi geçene kadar orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, resimler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) bölümündeki formata özgü talimatları kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) kullanabilirsiniz. Tekrarlanabilir dönüşümler, toplu işleme veya uygulama düzeyinde hata yönetimi için Android via Java API'yi kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Android'de Sunumları Kaydet](/androidjava/save-presentation/)
- [Desteklenen Dosya Formatları](/androidjava/supported-file-formats/)
- [Android'de Sunumları Aç](/androidjava/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for Android via Java, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği eksiksiz olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özellik için tam doğruluk garanti edilmez. Makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir kullanılan yazı tipleri içerdiğinde oluşturulan dosyayı gözden geçirin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Eksik veya hatalı şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüştürmeden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyiciler ve iş akışlarında doğrulayana kadar tutun. Bu, eski bir özellik farklı dönüştüğünde geri dönüş kopyası sağlar.