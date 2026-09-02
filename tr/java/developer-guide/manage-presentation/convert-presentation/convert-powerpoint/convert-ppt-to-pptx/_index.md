---
title: Java'da PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notları için Java örneklerini içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for Java, bir PPT dosyasını Microsoft PowerPoint olmadan yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, tek bir dosyayı veya bir dosya dizinini nasıl dönüştüreceğinizi gösterir ve dönüşüm sonrası neyin doğrulanması gerektiğini açıklar.

## **PPT Dosyasını PPTX'e Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yöntemini [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/#Pptx) ile çağırın. `finally` bloğu sunumu serbest bırakır ve kaynaklarını serbest bırakır.

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

Dosya uzantısı tek başına çıktı formatını seçmez; bunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/#Pptx) argümanı yapar. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştür**

Aşağıdaki örnek, bir dizindeki her `.ppt` dosyasını dönüştürür. Her dosya bağımsız olarak işlenir, bu yüzden bir dönüştürme hatası bütün toplu işlemi durdurmaz.

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

Üretim iş yükleri için, tam istisnayı günlüğe kaydedin, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağına karar verin ve başarısız dosya adlarını bir yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik dönüştürmenin başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/java/password-protected-presentation/) bölümüne bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme normalde slaytları, masterları, düzenleri, metni, şekilleri, görüntüleri, tabloları ve grafikleri korur. Ancak, PPT ve PPTX her özelliği tam olarak aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX eşdeğeri olmayan bir eski özellik, normalleştirilebilir, atlanabilir veya farklı şekilde gösterilebilir.

Dönüştürülen dosyayı animasyonlar, geçişler, gömülü veya bağlantılı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir bulunan yazı tipleri veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro etkin bir format değildir, bu nedenle VBA'nın mevcut kalması gerekiyorsa uygun makro etkin iş akışını kullanın. Ayrıca, dönüştürülen sunumun açılacağı veya işleneceği ortamda gerekli yazı tiplerinin ve dış kaynakların bulunduğunu doğrulayın.

Önemli belgeler için, oluşturulan PPTX'i programlı olarak yeniden açın ve ana slayt sayısını ve içeriğini inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedef görüntüleyicide karşılaştırın. Başarılı bir [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-) çağrısını her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak kabul etmeyin.

## **PPTX Ne Zaman Kullanılır**

Sunum, mevcut PowerPoint sürümlerinde düzenlenecekse, Open XML paketleriyle çalışan sistemlerle değiş tokuş edilecekse veya eski ikili PPT'ye göre incelemesi ve kurtarılması daha kolay bir formatta saklanacaksa PPTX kullanın. Dönüştürülen sunum doğruluk kontrollerinizi geçtiğinde orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görüntüler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruduğunu varsaymak yerine [Convert Presentations to Multiple Formats](/java/convert-presentation/) bölümündeki format‑özeli yönergeleri kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için, [çevrimiçi PPT to PPTX dönüştürücü](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) adresini kullanabilirsiniz. Tekrarlanan dönüşümler, toplu işleme veya uygulama seviyesinde hata yönetimi için Java API'sını kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Java'da Sunumları Kaydet](/java/save-presentation/)
- [Desteklenen Dosya Formatları](/java/supported-file-formats/)
- [Java'da Sunumları Aç](/java/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for Java, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özellik için tam doğruluk garanti edilmez. Makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir yazı tipleri içerdiğinde oluşturulan dosyayı inceleyin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Eksik veya hatalı şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüşümden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyicilerde ve iş akışlarında doğrulayana kadar tutun. Bu, bir eski özellik farklı dönüştürülürse geri dönüş kopyası sağlar.