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
description: "Aspose.Slides ile Node.js'te eski PPT dosyalarını PPTX'e dönüştürün. Tek dosya ve toplu dönüşüm, hata yönetimi ve doğruluk notları için JavaScript örneklerini içerir."
---
## **Genel Bakış**

PPT, eski ikili PowerPoint formatıdır, PPTX ise daha yeni Open XML formatıdır. Aspose.Slides for Node.js via Java, Microsoft PowerPoint olmadan bir PPT dosyasını yükleyebilir ve PPTX olarak kaydedebilir. Bu makale, tek bir dosya veya bir dizindeki dosyalar nasıl dönüştürülür ve dönüşüm sonrası neyin doğrulanması gerektiğini açıklar.

## **PPT Dosyasını PPTX'e Dönüştür**

Kaynak dosyayı Presentation sınıfı ile yükleyin, ardından SaveFormat.Pptx ile Presentation.save yöntemini çağırın. `finally` bloğu sunumu serbest bırakır ve kaynaklarını serbest bırakır.

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

Dosya uzantısı tek başına çıktı formatını seçmez; SaveFormat.Pptx argümanı seçer. Orijinal PPT dosyasını korumanız gerekiyorsa giriş ve çıkış yollarını farklı tutun.

## **Birden Çok PPT Dosyasını Dönüştür**

Aşağıdaki örnek, bir dizindeki tüm `.ppt` dosyalarını dönüştürür. Her dosya bağımsız olarak işlenir, bu nedenle tek bir dönüşüm hatası toplu işlemin geri kalanını durdurmaz.

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

Üretim ortamlarında, tam hatayı günlüğe kaydedin, mevcut bir çıktı dosyasının üzerine yazılıp yazılamayacağına karar verin ve başarısız dosya adlarını yeniden deneme veya inceleme kuyruğuna yazın. Bozuk dosyalar, gerekli şifre olmadan açılan şifre korumalı dosyalar, erişilemeyen yollar ve desteklenmeyen içerik dönüşümün başarısız olmasına neden olabilir. Şifre korumalı sunumları yüklemek için [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) sayfasına bakın.

## **Doğruluk ve Eski Özellikler**

Dönüştürme genellikle slaytları, masterları, yerleşimleri, metni, şekilleri, görüntüleri, tabloları ve grafikleri korur. Ancak PPT ve PPTX her özelliği aynı şekilde temsil etmez. Kütüphane tarafından desteklenmeyen veya PPTX karşılığı olmayan bir eski özellik normalleştirilebilir, çıkarılabilir veya farklı görüntülenebilir.

Dönüştürülen dosyayı animasyonlar, geçişler, gömülü veya bağlantılı OLE nesneleri, ActiveX denetimleri, gömülü medya, nadir kullanılan fontlar veya VBA makroları içerdiğinde kontrol edin. Düz bir PPTX dosyası makro destekli bir format değildir; VBA'nın erişilebilir olması gerekiyorsa uygun bir makro-destekli iş akışı kullanın. Ayrıca, dönüştürülen sunumun açılacağı veya render edileceği ortamda gerekli fontların ve harici kaynakların mevcut olduğunu doğrulayın.

Önemli belgeler için, oluşturulan PPTX'i programlı olarak yeniden açın ve ana slayt sayısını ve içeriği inceleyin, ardından hedef görüntüleyicide görünümünü ve slayt gösterisi davranışını karşılaştırın. Başarılı bir Presentation.save çağrısını, her eski özelliğin tam bir PPTX temsiline sahip olduğunun kanıtı olarak değerlendirmeyin.

## **PPTX Ne Zaman Kullanılmalı**

Sunum, mevcut PowerPoint sürümlerinde düzenlenecek, Open XML paketleriyle çalışan sistemlerle değiştirilecek veya eski ikili PPT'ye göre daha kolay incelenebilir ve kurtarılabilir bir formatta saklanacaksa PPTX kullanın. Dönüştürülen sunum doğruluk kontrollerinizi geçene kadar orijinal PPT'yi arşiv veya geri dönüş kopyası olarak tutun.

PDF, HTML, görüntüler, XPS veya başka bir çıktı türüne ihtiyacınız varsa, tüm hedeflerin düzenlenebilir PowerPoint özelliklerini koruyacağını varsaymak yerine [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) bölümündeki format-özelliği kılavuzunu kullanın.

## **Çevrimiçi Dönüştürücü**

Ara sıra bir dosya veya hızlı bir karşılaştırma için çevrimiçi [online PPT to PPTX converter](https://products.aspose.app/slides/tr/conversion/ppt-to-pptx) kullanabilirsiniz. Tekrarlanabilir dönüşümler, toplu işleme veya uygulama düzeyinde hata yönetimi için Node.js via Java API'sini kullanın.

## **İlgili Makaleler**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Node.js'te Sunumları Kaydet](/nodejs-java/save-presentation/)
- [Desteklenen Dosya Biçimleri](/nodejs-java/supported-file-formats/)
- [Node.js'te Sunumları Aç](/nodejs-java/open-presentation/)

## **SSS**

**Microsoft PowerPoint yüklü olmadan PPT'yi PPTX'e dönüştürebilir miyim?**

Evet. Aspose.Slides for Node.js via Java, Microsoft PowerPoint gerektirmeden sunum dosyalarını yükler ve kaydeder.

**PPT‑to‑PPTX dönüşümü tüm içeriği tam olarak korur mu?**

Ortak sunum içeriğini korur, ancak her eski veya desteklenmeyen özellik için tam doğruluk garanti edilemez. Makrolar, OLE veya ActiveX nesneleri, medya, özel animasyonlar veya nadir kullanılan fontlar içerdiğinde oluşturulan dosyayı gözden geçirin.

**Şifre korumalı bir PPT dosyasını dönüştürebilir miyim?**

Evet, dosyayı yüklerken doğru şifreyi sağlarsanız. Şifre eksik veya hatalı olduğunda yükleme işlemi başarısız olur.

**Dönüşümden sonra PPT dosyasını silmeli miyim?**

Orijinali, PPTX'i sizin için önemli olan görüntüleyicilerde ve iş akışlarında doğrulayana kadar tutun. Bu, bir eski özelliğin farklı dönüştürülmesi durumunda geri dönüş kopyası sağlar.