---
title: Sunumları JavaScript'te XAML'e Dışa Aktar
linktitle: Sunumdan XAML'e
type: docs
weight: 30
url: /tr/nodejs-java/export-to-xaml/
keywords:
  - PowerPoint'i dışa aktar
  - OpenDocument'i dışa aktar
  - sunumu dışa aktar
  - PowerPoint'i dönüştür
  - OpenDocument'i dönüştür
  - sunumu dönüştür
  - PowerPoint'ten XAML'e
  - OpenDocument'ten XAML'e
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
description: "Aspose.Slides kullanarak JavaScript'te PowerPoint ve OpenDocument slaytlarını XAML'e dönüştürün—düzeninizi koruyan hızlı, Office gerektirmeyen bir çözüm."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını XAML'e nasıl dışa aktaracağınızı açıklar. XAML'e kısa bir giriş içerir, bir sunumu varsayılan ayarlarla XAML olarak nasıl kaydedeceğinizi gösterir ve dışa aktarmayı [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) aracılığıyla, gizli slaytların dışa aktarılması dahil, nasıl özelleştirebileceğinizi gösterir. Makale ayrıca yedek yazı tipleri, XAML yığını uyumluluğu ve gizli slayt dışa aktarım davranışıyla ilgili birkaç yaygın soruya da yanıt verir.

## **XAML Hakkında**

XAML, WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) ve Xamarin.Forms gibi çerçevelerde kullanıcı arabirimlerini tanımlamak için kullanılan XML tabanlı bir işaretleme dilidir.

XAML dosyalarıyla görsel bir tasarımcıda çalışabilir veya işaretlemeyi doğrudan yazıp düzenleyebilirsiniz.

## **Varsayılan Seçeneklerle Sunumları XAML'e Dışa Aktarma**

Aşağıdaki JavaScript örneği, bir sunumu varsayılan ayarlarla XAML'e nasıl dışa aktaracağınızı gösterir:

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

Varsayılan olarak, dışa aktarılan slaytlar, işlemin geçerli çalışma dizininin bir `input` alt klasöründe kaydedilir. Klasör otomatik olarak oluşturulur ve gerekli görüntüler de oraya kaydedilir.

Çıktı klasörü adı, kaynak dosya adından uzantısı olmadan alınır. Aspose.Slides for Node.js via Java 26.8'de `input.pptx` dışa aktarmak, `input/input/Slide_1.xaml` gibi iç içe bir yol üretir. Çıktıyı işlerken oluşturulan tam yolları koruyun. Varsayılan çıktı, geçerli çalışma dizinine göredir, mutlaka giriş dosyasının yanına değil.

## **Özel Seçeneklerle Sunumları XAML'e Dışa Aktarma**

Aspose.Slides'in bir sunumu XAML'e nasıl dışa aktardığını kontrol etmek için [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) arayüzünü kullanın.

Çıktıyı özel bir konuma kaydetmek için [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/)`ı uygulayın ve uygulamanızın bir örneğini [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/)`ın [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) metoduna geçirin.

Gizli slaytları XAML çıktısına dahil etmek için, aşağıdaki JavaScript örneğinde gösterildiği gibi `true` ile [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) metodunu çağırın:

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

## **Oluşturulan Tüm XAML Ürünlerini Yakalama**

Bir XAML dışa aktarımı, dışa aktarılan her slayt için bir XAML belgesi ve ayrı görüntüler ile destek kaynakları üretebilir. Varsayılan dosya sistemi kaydedicisi yerine bu ürünleri almak için özel bir [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/)`ı [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver)ʼa atayın. Dışa aktarmayı, XAML‑specific [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) aşırı yüklemesiyle başlatın.

Node.js'te, Aspose.Slides tarafından kullanılan `java` paketindeki `java.newProxy` ile Java arayüzünü uygulayın. Proxy'i dışa aktarım tamamlanana kadar erişilebilir tutun.

### **Geri Çağrı Yaşam Döngüsünü Anlamak**

Dışa aktaran, oluşturulan her ürün için ayrı ayrı [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) metodunu çağırır:

- `path` ürünün kimliğini belirler ve göreli dizinler içerebilir. XAML'in kaynakları göreli yollarla referanslayabileceği için bu bilgiyi koruyun.
- `data` ürünün baytlarını içerir. Görüntüler ve diğer ikili kaynaklar metin olarak çözülemez.
- Kaydedici, döndürmeden önce veriyi tutmak ya da kalıcı hâle getirmekle sorumludur. Örnekler, her Java bayt dizisini uygulama sahipliğindeki bir Node.js tamponuna kopyalar.
- Dışa aktarmayı yalnızca sunum kaydetme işlemi döndüğünde ve her geri çağrı başarıyla tamamlandığında başarılı olarak kabul edin. Depolama hatalarını yutmayın veya gözlemlenmeyen arka plan yazımlarını başlatmayın. Kalıcılık daha sonra gerçekleşirse, genel başarıyı yalnızca bu adım da başarılı olduğunda bildirin.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ayrıca özel bir kaydediciye de uygulanır. Varsayılan ayar `false`, gizli slayt XAML belgelerini hariç tutar. `true` geçirilmesi, bunları ve ihracatları için gereken tüm kaynakları içerir. Kaynak sayısı sunuma bağlıdır; slayt başına bir geri çağrı ya da sabit bir çağrı sırası varsaymayın.

### **Belleğe Dışa Aktar ve Ürünleri İncele**

Bu tam örnek `input.pptx` dosyasını yükler, her ürünü isim‑tampon haritasında toplar ve adını, türünü ve bayt sayısını yazar. Sağlanan adları tam olarak korur. Yinelenen adlar, bir ürünün sessizce üzerine yazılması yerine koleksiyonu geçersiz olarak işaretler. Örnek, sonuçları kullanmadan önce bunu kontrol eder.

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

        // Yalnızca XAML'i çözümlendir ve sadece metinsel inceleme gerektiğinde.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Uzantı kontrolleri inceleme için faydalıdır; tanıdık olmayan kaynak tipleri dahil tüm ürünleri koruyun. Baytları depolarken veya iletirken değiştirmeyin. Yalnızca metin işleme gerektiren XAML için UTF‑8 kod çözümlemesi kullanın.

### **Toplanan Ürünleri ZIP Arşivine Paketle**

Bu bağımsız örnek dışa aktarmayı toplar, adlarını doğrular ve orijinal baytları Java köprüsü aracılığıyla bir ZIP arşivine yazar. ZIP, diske kaydedilmeden önce bellek içinde oluşturulur. Benzersiz bir arşiv adı, eşzamanlı dışa aktarma işleri arasında ayrım sağlar. ZIP girdileri ileri eğik çizgi kullanır ve göreli dizinleri korur. Normalleştirmeden sonra çakışan güvensiz adlar, paket yazılmadan önce tüm paketi reddeder.

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
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Kapatma, arşiv kalıcı hale getirilmeden önce ZIP dizinini sonlandırır.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Örnek, tek bir yerel arşiv yazmak için [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) kullanır; dışa aktaran kendisi gevşek XAML veya görüntü dosyaları yazmaz. Uzaktan depolama için, arşiv‑yazma aşamasını toplanan bayt dizilerinin yüklemeleriyle değiştirin. Bir dışa aktarma‑iş kimliğiyle birlikte tam göreli ürün adını blob anahtarı olarak kullanın veya iş kimliğini, göreli adı ve ikili veriyi bir veritabanı satırında saklayın. Tüm yüklemeler tamamlandığında veya veritabanı işlemi commit edildiğinde işi yayımlayın. Kalıcılık başarısız olursa kısmi çıktıyı temizleyin.

Büyük sunumlar için, özel bir kaydedici her ürünü doğrudan uygulama depolamasına kalıcı hâle getirerek tüm dışa aktarmanın ek bir kopyasını uygulama belleğinde tutmaktan kaçınabilir. Dışa aktaran perspektifinden her geri çağrıyı eşzamanlı tutun: hedef baytları kabul ettikten sonra döndürün ve hataların çağırıcıya ulaşmasına izin verin.

### **Kaynak Adlarını Koru ve Referansları Doğrula**

- Hedef gerektirdiğinde yol ayırıcılarını normalleştirin, ancak göreli dizinleri koruyun. Her oluşturulan adın benzersiz olduğu ve kaynak referanslarının geçerli kaldığı durumlar dışında yalnızca dosya adını (basename) kullanmayın.
- Hedefe özgü ad doğrulaması uygulayın. Gevşek dosyalar yazarken kök yolları ve geçiş segmentlerini reddedin, hedefi mutlak bir yola çözün ve hedefin amaçlanan dışa aktarma dizini altında kalmasını doğrulayın; dizin ayırıcıyı da içerme kontrolünde kullanın. Yazımları yönlendirebilecek sembolik bağlar içermeyen uygulama‑kontrollü bir dizin kullanın.
- Her dışa aktarma işi için ayrı bir kaydedici ve depolama ad alanı kullanın. Ayırıcı normalleştirmesinden sonra ve hedefin büyük‑küçük harf duyarlılığı kurallarına göre çakışmaları tespit edin.
- Yayımlamadan önce, her XAML belgesini XML olarak ayrıştırın ve görüntü `Source` ya da `ImageSource` öznitelikleri gibi dosya‑tabanlı kaynak referanslarını inceleyin. Her göreli URI'yi, içeren XAML ürününün dizinine göre çözün, ortaya çıkan depolama adını normalleştirin ve karşılık gelen harita anahtarının, ZIP girdisinin veya saklanan nesnenin var olduğunu doğrulayın. Dış URI'leri ve XAML işaretleme ifadelerini göreli dosya adlarından ayrı olarak ele alın.

Örneğin, `input/Slide_1.xaml` dosyası `images/image1.png` referans veriyorsa, depolanmış kaynak `input/images/image1.png` olarak mevcut olmalıdır. Yalnızca `image1.png` tutmak bu ilişkiyi bozar. Nesne depolamada, iş önekinin altında aynı düzeni koruyun ve bu kaynak URL'lerini XAML tüketicisinin erişebileceği şekilde yapın. Tamamlanmış ZIP'ı yeniden açarak giriş adlarını ve kaynak baytlarını doğrulayın ve hedef XAML ortamında temsilci slaytları yükleyerek görüntülerin doğru çözüldüğünü teyit edin.

## **SSS**

**Orijinal yazı tipi makinede bulunmuyorsa öngörülebilir yazı tiplerini nasıl sağlayabilirim?**

Orijinal eksik olduğunda dışa aktarım sırasında yedek yazı tipi olarak kullanılmak üzere [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) içinde [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) metodunu çağırın. Bu, oluşturulan XAML'in yedek yazı tipine referans verdiğini veya hedef makinede yazı tipinin mevcut olduğunu garanti etmez. XAML'in referans verdiği yazı tiplerinin görüntülendiği ortamda mevcut olduğundan emin olun.

**Dışa aktarılan XAML yalnızca WPF için mi amaçlanmıştır, yoksa diğer XAML yığınlarında da kullanılabilir mi?**

Aspose.Slides, herkese açık API'si aracılığıyla WPF XAML'i dışa aktarır. UWP ve Xamarin.Forms gibi diğer XAML yığınlarıyla uyumluluk garanti edilmez. Oluşturulan işaretlemeyi hedef ortamınızda test edin.

**Gizli slaytlar destekleniyor mu ve varsayılan olarak dışa aktarılmalarını nasıl engelleyebilirim?**

Varsayılan olarak gizli slaytlar dahil edilmez. Bu davranışı [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) içinde [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ile kontrol edebilirsiniz — eğer dışa aktarmanıza ihtiyaç duymuyorsanız devre dışı bırakın.