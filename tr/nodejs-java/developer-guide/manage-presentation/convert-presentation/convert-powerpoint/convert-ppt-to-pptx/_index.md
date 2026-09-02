---
title: Node.js'te PPT'yi PPTX'e Dönüştür
linktitle: PPT'den PPTX'e
type: docs
weight: 20
url: /tr/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile Node.js'te eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notları için JavaScript örnekleri içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for Node.js via Java, Microsoft PowerPoint olmadan bir PPT dosyasını yükleyip PPTX olarak kaydedebilir. Bu makale bir dosyayı ya da bir dizindeki dosyaları nasıl dönüştüreceğinizi gösterir ve dönüştürmeden sonra neyin doğrulanması gerektiğini açıklar.

## **PPT Dosyasını PPTX'e Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı ile yükleyin, ardından [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) metodunu [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) argümanıyle çağırın. `finally` bloğu sunumu serbest bırakır ve kaynaklarını serbest bırakır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Eski PPT sunumunu yükle.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Sunumu PPTX formatında kaydet.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dosya uzantısı tek başına çıktı formatını seçmez; bu işi [SaveFormat.Pptx](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) argümanı yapar. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştür**

Aşağıdaki örnek bir dizindeki tüm `.ppt` dosyalarını dönüştürür. Her dosya bağımsız olarak işlenir, bu yüzden bir dönüşüm hatası diğerlerinin işlenmesini durdurmaz.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Üretim ortamları için, tam hatayı günlüğe kaydedin, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağını belirleyin ve başarısız dosya adlarını yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerikler dönüşümün başarısız olmasına neden olabilir. Şifreli dosyaları yüklemek için [Password-Protected Presentations](/slides/tr/nodejs-java/password-protected-presentation/) bölümüne bakın.

## **Doğruluk ve Eski Özellikler**

Dönüşüm genellikle slaytları, ana şablonları, düzenleri, metni, şekilleri, görüntüleri, tabloları ve grafikleri korur. Ancak PPT ve PPTX, her özelliği tam olarak aynı şekilde temsil etmez. Kitaplık tarafından desteklenmeyen veya PPTX eşdeğeri olmayan bir eski özellik normalize edilebilir, atlanabilir veya farklı gösterilebilir.

Animasyonlar, geçişler, gömülü veya bağlı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir yazı tipleri veya VBA makroları içeren dönüştürülmüş dosyayı kontrol edin. Düz bir PPTX dosyası makro destekli bir format değildir; VBA'nın kullanılabilir olması gerektiğinde uygun makro‑destekli iş akışı kullanın. Ayrıca dönüştürülen sunumun açılacağı ya da render edileceği ortamda gerekli yazı tiplerinin ve dış kaynakların mevcut olduğunu doğrulayın.

Önemli belgeler için, oluşturulan PPTX'i programlı olarak yeniden açın ve ana slayt sayısını ve içeriğini inceleyin, ardından görünümünü ve slayt gösterisi davranışını hedeflenen görüntüleyicide karşılaştırın. Başarılı bir [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğu kanıtı olarak değerlendirmeyin.

## **Ne Zaman PPTX Kullanılmalı**

Sunumun güncel PowerPoint sürümlerinde düzenlenecek, Open XML paketleriyle çalışan sistemlerle değiştirilecek veya eski ikili PPT'den daha kolay incelenip geri kurtarılabilen bir formatta depolanacak olması durumunda PPTX kullanın. Dönüştürülen sunum doğruluk kontrollerinizi geçtiği sürece orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görüntüler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Convert Presentations to Multiple Formats](/slides/tr/nodejs-java/convert-presentation/) bölümündeki formata özgü yönergeleri kullanın.

## **Çevrimiçi Dönüştürücü**

Arada bir dosya veya hızlı bir karşılaştırma için [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) adresini kullanabilirsiniz. Tekrarlanabilir dönüşümler, toplu işleme veya uygulama seviyesinde hata yönetimi için Node.js via Java API'yi kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/slides/tr/nodejs-java/ppt-vs-pptx/)
- [Node.js'te Sunumları Kaydet](/slides/tr/nodejs-java/save-presentation/)
- [Desteklenen Dosya Formatları](/slides/tr/nodejs-java/supported-file-formats/)
- [Node.js'te Sunumları Aç](/slides/tr/nodejs-java/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for Node.js via Java, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT'den PPTX'e dönüşüm tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özellik için tam doğruluk garanti edilmez. Oluşturulan dosyayı makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir yazı tipleri içeriyorsa gözden geçirin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız mümkündür. Eksik veya hatalı şifre, yükleme işleminin başarısız olmasına neden olur.

**Dönüştürmeden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyicilerde ve iş akışlarında doğrulayana kadar saklayın. Bu, eski bir özelliğin farklı dönüştürülmesi durumunda geri dönüş kopyası sağlar.