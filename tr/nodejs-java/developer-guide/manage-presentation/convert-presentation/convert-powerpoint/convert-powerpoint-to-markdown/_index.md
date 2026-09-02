---
title: PowerPoint Sunumlarını JavaScript'te Markdown'a Dönüştür
linktitle: PowerPoint'ten Markdown'a
type: docs
weight: 140
url: /tr/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten MD'ye
- sunumdan MD'ye
- slayttan MD'ye
- PPT'den MD'ye
- PPTX'ten MD'ye
- PowerPoint'i Markdown olarak kaydet
- sunumu Markdown olarak kaydet
- slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'i MD olarak kaydet
- PPT'yi MD'ye dışa aktar
- PPTX'i MD'ye dışa aktar
- Markdown görüntü dışa aktarımı
- CDN görüntü bağlantıları
- PowerPoint
- sunum
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "PPT ve PPTX sunumlarını JavaScript'te Markdown'a dönüştürün ve dışa aktarılan bitmap, metafile ve SVG görüntülerinin nerede kaydedileceğini ve nasıl referans verileceğini kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, PPT ve PPTX sunumlarını belgeleme, statik site, içerik taşıma ve sürüm kontrolü iş akışları için Markdown’a dönüştürebilir. Bir Markdown çeşidi seçebilir, slayt içeriğinin nasıl render edileceğini kontrol edebilir ve dışa aktarılan görüntülerin nerede saklanacağını ve oluşturulan Markdown’ın onlara nasıl başvurduğunu belirleyebilirsiniz.

Varsayılan olarak, Markdown dışa aktarımı sadece metin çıktısı kullanır. Görsel içeriği dışa aktarmak için, dışa aktarma tipini [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) metoduyla [MarkdownExportType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownexporttype/) enum'undan `Sequential` veya `Visual` değerine ayarlayın. `Sequential`, slayt öğelerini ayrı ayrı ve sırayla render ederken, `Visual` gruplandırılmış öğeleri birlikte tutarak görsel ilişkilerini korur. `TextOnly` değeri görüntü kaynakları üretmez, bu yüzden bu modda görüntü kaydetme geri çağrıları tetiklenmez.

## **Bir Sunumu Markdown’a Dönüştürme**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı ile yükleyin ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) metodunu [SaveFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveformat/) enum'undan `Md` değeriyle çağırın.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Bir Markdown Çeşidi Seçin**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) metodu, çıktıda kullanılan Markdown spesifikasyonunu kontrol eder. [Flavor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/flavor/) enum'ı CommonMark, GitHub Flavored Markdown ve diğer desteklenen çeşitleri içerir.

Aşağıdaki örnek bir sunumu CommonMark olarak dışa aktarır:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Varsayılan Yerel Kaydetme Davranışıyla Görüntüleri Dışa Aktarma**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) sınıfı, yerel olarak kaydedilen görüntüleri yapılandırmak için iki metod sağlar:

- [setBasePath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) Markdown belgesi ve kaynakları için temel dizini belirtir.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) görüntü alt klasörünü belirtir. Varsayılan değeri `Images`'tır.

Aşağıdaki örnek görsel içeriği render eder, görüntüleri `output/assets` klasörüne yazar ve Markdown belgesinde göreli görüntü referansları oluşturur:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Bu davranış, özel bir görüntü kaydetme işleyicisi `false` döndürdüğünde geri dönüş (fallback) olarak da hizmet verir.

## **Görüntü Kaydetmeyi ve Markdown Bağlantılarını Özelleştirme**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) metodunu, Markdown dışa aktarımı sırasında üretilen SVG olmayan bitmap ve metafile kaynakları için bir geri çağrı (callback) kaydetmek için kullanın. Bu metodun `MarkdownImageSavingHandler` geri çağrısı, [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) nesnesini, onun [ImageFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imageformat/) değerini ve üretilen Markdown bağlantısını tek elemanlı bir dize dizisi olarak alır. Görüntüyü sağlanan formatta kaydedin veya yükleyin ve `link[0]` öğesini Markdown çıktısında görünmesi gereken referansla değiştirin.

SVG formatında üretilen kaynaklar ayrı şekilde işlenir. [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) metodu ile bir geri çağrı kaydedin. Bu metodun `MarkdownSvgImageSavingHandler` geri çağrısı bir `ISvgImage` nesnesi ve tek elemanlı `link` dizisini alır. SVG'nin bir `ImageFormat` argümanı yoktur; bunun yerine `ISvgImage.getSvgData` metodundan XML verisini yazar veya yüklersiniz. Dışa aktarma modu ve görsel gruplamaya bağlı olarak, kaynak sunumdaki bir SVG rasterleştirilebilir veya diğer içeriklerle birleştirilebilir; ortaya çıkan SVG olmayan kaynak daha sonra görüntü kaydetme geri çağrısına geçirilir. Her dışa aktarılan görsel kaynağın özel işleme ihtiyacı olduğunda her iki geri çağrıyı da kaydedin.

Node.js'te, bu geri çağrı arayüzlerinin uygulamalarını `java.newProxy` ile oluşturun.

İşleyici dönüş değeri, görüntüyü kim işleyeceğini belirler:

- `true` döndürün; işleyici görüntüyü kaydettikten, yükledikten, dönüştürdükten veya başka bir şekilde işledikten ve `link[0]` öğesine geçerli bir değer atadıktan sonra. Aspose.Slides bu değeri Markdown belgesine yazar ve varsayılan yerel kaydetmeyi yapmaz.
- `false` döndürün; Aspose.Slides'in resmi yerel olarak kaydetmesine ve bağlantısını [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) ve [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) ile ayarlanan değerlere göre oluşturmasına izin verir.

{{% alert color="warning" title="Important" %}}
`true` döndüren bir işleyici, görüntünün sorumluluğunu alır. Geçerli ve boş olmayan bir bağlantı atamadan `true` dönerse, dışa aktarım `InvalidOperationException` ile başarısız olur.
{{% /alert %}}

### **Görüntüleri bir CDN Kaynak Dizini'ne Kaydedin ve Harici URL'ler Kullanın**

Aşağıdaki örnek `cdn-origin/presentations/quarterly-report` dizinini bağlanmış veya eşzamanlanmış bir CDN kaynak dizini olarak ele alır. Her işleyici oluşturulan dosya adını alır, görüntüyü bu özel dizine kaydeder ve oluşturulan yerel referansı bir genel CDN URL'siyle değiştirir. Örnek kendisi ağ üzerinden bir yükleme yapmaz: URL, dizin CDN kaynağı olarak bağlandığında veya dosyaları CDN'e yayınlandığında geçerli olur. Nesne depolama için, dosya sistemi yazımını depolama SDK'sının yükleme işlemiyle değiştirin ve sadece yükleme başarılı olduğunda `link[0]` atayın.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Bitmap işleyicisi, 128 × 128 pikselden küçük görüntüler için kasıtlı olarak `false` döndürür, bu yüzden Aspose.Slides bu görüntüleri varsayılan davranışı kullanarak `output/fallback-images` klasörüne kaydeder. Daha büyük bitmap ve metafile kaynakları ile SVG kaynakları özel kod tarafından işlenir. Örneğin, `fallback-images/image1.png` gibi bir yerel referans `https://cdn.example.com/presentations/quarterly-report/image1.png` olur. İşleyiciler, dosyaları yazarken sadece işletim sistemi yollarını kullanır; Markdown'a yazılan bağlantılar ise ileri eğik çizgi ve URL kodlamalı dosya adları kullanır. Göreli bağlantılar oluştururken aynı kuralı uygulayın: `/` kullanın, platforma özgü dizin ayırıcısını değil.

## **SSS**

**Bir işleyici hem raster görüntüleri hem de SVG görüntülerini işleyebilir mi?**

Hayır. Üretilen bitmap ve metafile kaynakları için [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) yöntemini, SVG olarak üretilen kaynaklar için ise [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) yöntemini kullanın. İlk yöntem bir [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) nesnesi ve bir [ImageFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imageformat/) değeri sağlar; ikincisi `ISvgImage` nesnesi sağlar ve SVG verisi `ISvgImage.getSvgData` ile okunabilir. Dışa aktarım sırasında rasterleştirilen bir kaynak SVG, görüntü kaydetme geri çağrısı tarafından işlenir.

**Bir görüntü kaydetme işleyicisi `false` döndürdüğünde ne olur?**

Aspose.Slides varsayılan yerel kaydetme davranışını kullanır. Görüntünün konumu ve oluşturulan referans, [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) ve [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/markdownsaveoptions/) ile ayarlanan değerler tarafından kontrol edilir.

**Bir işleyici, görüntüyü yerel olarak kaydetmeden bir URL sağlayabilir mi?**

Evet. İşleyici görüntüyü nesne depolamaya yükleyebilir veya başka bir servise iletebilir, ortaya çıkan URL'yi `link[0]` öğesine atayabilir ve `true` dönebilir. İşleyicinin işlemi kendisi tamamlaması gerekir; `true` döndürmek varsayılan yerel kaydetmeyi engeller.

**Markdown dışa aktarımı bir işleyiciden `InvalidOperationException` hatası neden atar?**

Bu istisna, işleyicinin `true` döndürdüğü ancak geçerli bir bağlantı sağlamadığı durumlarda oluşur. `true` döndürmeden önce Markdown'a yazılması gereken göreli yolu veya harici URL'yi atayın.

**Görüntü bağlantıları hangi yol ayırıcıyı kullanmalı?**

Markdown bağlantılarında ve URL'lerde ileri eğik çizgi `/` kullanın. `path.join` yalnızca dosya sistemi yolları için kullanılmalı, ardından Markdown referansı ayrı olarak oluşturulup normalleştirilmelidir.

**Markdown dışa aktarımı sırasında köprüler korunur mu?**

Evet. Metin [hyperlinks](/slides/tr/nodejs-java/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [transitions](/slides/tr/nodejs-java/slide-transition/) ve [animations](/slides/tr/nodejs-java/powerpoint-animation/) dönüştürülmez.

**Sunumlar paralel olarak Markdown’a dönüştürülebilir mi?**

Farklı sunum dosyalarını paralel olarak işleyebilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneğini iş parçacıkları arasında paylaşmayın. [multithreading guidelines](/slides/tr/nodejs-java/multithreading/) yönergelerini izleyin ve her dosya için ayrı bir örnek kullanın.