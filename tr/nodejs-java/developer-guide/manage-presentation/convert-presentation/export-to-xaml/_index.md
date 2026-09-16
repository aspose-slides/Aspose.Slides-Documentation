---
title: JavaScript'te Sunumları XAML'e Dışa Aktarma
linktitle: Sunumu XAML'e
type: docs
weight: 30
url: /tr/nodejs-java/export-to-xaml/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunumu dışa aktar
- PowerPoint dönüştür
- OpenDocument dönüştür
- sunumu dönüştür
- PowerPoint'tan XAML'e
- OpenDocument'tan XAML'e
- sunumdan XAML'e
- PPT'den XAML'e
- PPTX'den XAML'e
- ODP'den XAML'e
- PPT'yi XAML olarak kaydet
- PPTX'i XAML olarak kaydet
- ODP'yi XAML olarak kaydet
- PPT'yi XAML'e dışa aktar
- PPTX'i XAML'e dışa aktar
- ODP'yi XAML'e dışa aktar
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides kullanarak JavaScript'te PowerPoint ve OpenDocument slaytlarını XAML'e dönüştürün—düzeni bozmayan hızlı, Office gerektirmeyen bir çözüm."
---
## **Genel Bakış**

Bu makale, PowerPoint sunumlarını Aspose.Slides kullanarak XAML’e nasıl dışa aktaracağınızı açıklar. Kısa bir XAML tanıtımı içerir, varsayılan ayarlarla bir sunumun XAML’e nasıl kaydedileceğini gösterir ve gizli slaytların dışa aktarılması dahil olmak üzere [XamlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/) üzerinden dışa aktarımı nasıl özelleştirebileceğinizi gösterir. Ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarım davranışıyla ilgili bazı yaygın soruları yanıtlar.

## **XAML Hakkında**

XAML, WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin.Forms gibi çerçevelerde kullanıcı arabirimlerini tanımlamak için kullanılan XML tabanlı bir işaretleme dilidir.

XAML dosyalarıyla görsel bir tasarımcıda çalışabilir veya işaretlemeyi doğrudan yazıp düzenleyebilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML’e Dışa Aktarma**

Aşağıdaki JavaScript örneği, bir sunumu varsayılan ayarlarla XAML’e nasıl dışa aktarılacağını gösterir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Varsayılan olarak, dışa aktarılan slaytlar işlemin geçerli çalışma dizininin bir `input` alt klasörüne kaydedilir. Klasör otomatik olarak oluşturulur ve gerekli tüm görüntüler de oraya kaydedilir.

Çıktı klasörü adı, uzantısı olmadan kaynak dosya adından alınır. Aspose.Slides for Node.js via Java 26.8’de `input.pptx` dışa aktarmak, `input/input/Slide_1.xaml` gibi iç içe bir yol üretir. Çıktıyı işlerken oluşturulan tam yolları koruyun. Varsayılan çıktı, geçerli çalışma dizinine göredir; mutlaka giriş dosyasının yanında olmayabilir.

## **Özel Seçeneklerle Sunumları XAML’e Dışa Aktarma**

Aspose.Slides’in bir sunumu XAML’e nasıl dışa aktaracağını kontrol etmek için [IXamlOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloptions/) arayüzünü kullanın.

Çıktıyı özel bir konuma kaydetmek için [IXamlOutputSaver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloutputsaver/) uygulayın ve örnekleyiminizi [XamlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/) ‑in [setOutputSaver](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) yöntemine iletin.

Gizli slaytları XAML çıktısına dahil etmek için aşağıdaki JavaScript örneğinde gösterildiği gibi `true` ile [setExportHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) çağırın:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Oluşturulan Tüm XAML Artefaktlarını Yakalama**

Bir XAML dışa aktarımı, dışa aktarılan her slayt için bir XAML belgesi ve ayrı görüntü ve yardımcı kaynaklar üretebilir. Bu artefaktları almak için varsayılan dosya‑sistemi kaydedicisi yerine bir özel [IXamlOutputSaver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloutputsaver/) atayın. XAML seçeneklerini kabul eden [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) aşırı yüklemesiyle dışa aktarmayı başlatın.

Node.js’te, Aspose.Slides tarafından kullanılan `java` paketinden `java.newProxy` ile Java arayüzünü uygulayın. Proxy, dışa aktarım tamamlanana kadar ulaşılabilir kalmalıdır.

### **Geri Çağrı Yaşam Döngüsünü Anlama**

Dışa aktarım, her oluşturulan artefakt için [IXamlOutputSaver.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) metodunu ayrı ayrı çağırır:

- `path` artefaktı tanımlar ve göreli dizinler içerebilir. XAML, kaynakları göreli yollarla referanslayabileceği için bu bilgiyi tutun.
- `data` artefaktın baytlarını içerir. Görüntüler ve diğer ikili kaynaklar metin olarak çözümlenmemelidir.
- Kaydedici, veriyi geri dönmeden önce saklamaktan veya kalıcı hale getirmekten sorumludur. Örneklerde her Java byte dizisi bir uygulama‑sahibi Node.js tamponuna kopyalanır.
- Sunum kaydetme işlemi döndüğünde ve her geri çağrı başarılı bir şekilde tamamlandığında dışa aktarma başarılı kabul edilir. Depolama hatalarını yutmayın ve gözlemlenmeyen arka plan yazmalarını başlatmayın. Kalıcılık sonradan gerçekleşirse, bütün adım da başarılı olduğunda genel başarı rapor edilmelidir.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) özel kaydediciye de uygulanır. Varsayılan ayar `false` olduğundan gizli‑slayt XAML belgeleri dışarı çıkarılmaz. `true` geçirilirse bu belgeler ve ihracatları için gereken tüm kaynaklar dahil edilir. Kaynak sayısı sunuma bağlıdır; slayt başına tek bir geri çağrı ya da sabit bir sıra varsaymayın.

### **Belleğe Dışa Aktar ve Artefaktları İncele**

Bu tam örnek `input.pptx` dosyasını yükler, her artefaktı isim‑tampon eşlemesine toplar ve adını, türünü ve bayt sayısını yazdırır. Sağlanan adlar tam olarak korunur. Yinelenen adlar koleksiyonu geçersiz olarak işaretlenir ve sessizce üzerine yazılmaz. Örnek, sonuçları kullanmadan önce bunu kontrol eder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Yalnızca XAML'i çöz ve yalnızca metinsel inceleme gerektiğinde.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Uzantı kontrolleri inceleme için faydalıdır; tanıdık olmayan kaynak türleri de dahil olmak üzere tüm artefaktları koruyun. Baytları depolarken ya da iletirken değiştirmeyin. Yalnızca XAML metin işleme gerektiren durumlarda UTF‑8 kod çözücüsü kullanın.

### **Toplanan Artefaktları ZIP Arşivine Paketleme**

Bu bağımsız örnek dışa aktarımı toplar, adlarını doğrular ve Java köprüsüyle bir ZIP arşivine yazar. ZIP, diske kaydedilmeden önce bellekte birleştirilir. Eşzamanlı dışa aktarma işleri için benzersiz bir arşiv adı kullanılır. ZIP girdileri ileri eğik çizgi (`/`) kullanır ve göreli dizinleri korur. Normalleştirme sonrası çakışan ya da güvensiz adlar, arşiv yazılmadan önce tamamen reddedilir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XtraOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Kapatma, arşiv kalıcı hâle getirilmeden önce ZIP dizinini sonlandırır.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Örnek, bir yerel arşiv yazmak için [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) kullanır; dışa aktarıcı kendisi gevşek XAML veya görüntü dosyaları yazmaz. Uzaktan depolama için, arşiv‑yazma aşamasını toplanan byte dizilerinin yüklemeleriyle değiştirin. Bir dışa aktarım‑iş kimliği ve tam göreli artefakt adı bir blob anahtarı olarak kullanılabilir veya iş kimliği, göreli ad ve ikili veri bir veritabanı satırında saklanabilir. Tüm yüklemeler tamamlanıp işlem onaylandığında işi yayınlayın. Kalıcılık başarısız olursa kısmi çıktıyı temizleyin.

Büyük sunumlar için, bir özel kaydedici her artefaktu doğrudan uygulama depolamasına kalıcı hâle getirebilir; böylece tüm dışa aktarımın bir kopyasını bellek içinde tutmaya gerek kalmaz. Dışa aktarıcının bakış açısından her geri çağrıyı senkron tutun: hedef baytları kabul edene kadar döndürmeyin ve hataların çağrıcaya ulaşmasına izin verin.

### **Kaynak Adlarını Koru ve Referansları Doğrula**

- Hedef gerektiriyorsa yol ayırıcılarını normalleştirin, ancak göreli dizinleri koruyun. Tüm üretilen adların benzersiz olduğu ve kaynak referanslarının geçerli kaldığı kesin değilse sadece temel adı kullanmayın.
- Hedefe‑özel ad doğrulaması uygulayın. Gevşek dosyalar yazılırken köklenmiş yolları ve travers (../) bölümlerini reddedin, hedefi mutlak bir yola dönüştürün ve belirtilen dışa aktarım dizini altında kaldığından emin olun; kontrol sırasında dizin ayırıcıyı da dahil edin. Sembolik bağlar içermeyen, yönlendirme yapabilecek dizinleri kullanmayın.
- Her dışa aktarım işi için ayrı bir kaydedici ve depolama ad alanı kullanın. Ayırıcı normalleştirmesinden ve hedefin büyük/küçük harf duyarlılığı kurallarından kaynaklı çakışmaları tespit edin.
- Yayınlamadan önce her XAML belgesini XML olarak ayrıştırın ve `Source` ya da `ImageSource` gibi dosya‑tabanlı kaynak referanslarını inceleyin. Her göreli URI’yı ilgili XAML artefaktının dizinine göre çözün, elde edilen depolama adını normalleştirin ve karşılık gelen harita anahtarı, ZIP girdisi ya da saklanmış nesnenin mevcut olduğunu doğrulayın. Harici URI’ları ve XAML işaretleme ifadelerini göreli dosya adlarından ayrı tutun.

Örneğin, `input/Slide_1.xaml` dosyası `images/image1.png` referans ediyorsa, depolanan kaynak `input/images/image1.png` olarak bulunmalıdır. Sadece `image1.png` saklamak ilişkiyi bozar. Nesne depolama kullanıyorsanız, aynı hiyerarşiyi iş kimliği altına koruyun ve bu kaynak URL’lerini XAML tüketicisi için erişilebilir hâle getirin. ZIP’ı tekrar açarak giriş adlarını ve kaynak baytlarını doğrulayın, ardından hedef XAML ortamında temsilî slaytları yükleyerek görüntülerin doğru çözümlendiğini kontrol edin.

## **SSS**

**Orijinal yazı tipi makinede bulunmuyorsa öngörülebilir bir yazı tipi nasıl sağlanır?**

[XamlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/) içindeki [setDefaultRegularFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) metodunu çağırın — dışa aktarım sırasında eksik olduğunda yedek yazı tipi olarak kullanılır. Bu, üretilen XAML’in yedek yazı tipine referans vereceği ya da hedef makinede yazı tipinin bulunacağı garantisini vermez. XAML’in referans verdiği yazı tiplerinin görüntüleneceği ortamda mevcut olduğundan emin olun.

**Dışa aktarılan XAML yalnızca WPF için mi amaçlanmıştır, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

Aspose.Slides, WPF XAML’ini halka açık API’siyle dışa aktarır. UWP ya da Xamarin.Forms gibi diğer XAML yığınlarıyla uyumluluk garanti edilmez. Üretilen işaretlemeyi hedef ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarımından nasıl engellenir?**

Varsayılan olarak gizli slaytlar dışa aktarılmaz. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/) içinde bulunan [setExportHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ile kontrol edebilirsiniz — ihtiyacınız yoksa devre dışı bırakın.