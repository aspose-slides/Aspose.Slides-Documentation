---
title: Sunumları Dış Bağlantılı Görsellerle HTML'ye Aktarın
type: docs
weight: 100
url: /tr/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunum dışa aktar
- slayt dışa aktar
- PPT dışa aktar
- PPTX dışa aktar
- ODP dışa aktar
- PowerPoint'ten HTML'ye
- OpenDocument'ten HTML'ye
- sunumdan HTML'ye
- slayttan HTML'ye
- PPT'den HTML'ye
- PPTX'ten HTML'ye
- ODP'den HTML'ye
- bağlantılı görsel
- dış bağlantılı görsel
- bağlantılı kaynak
- dış kaynak
- JavaScript
- Node.js
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını, görüntüleri ve diğer kaynakları harici bağlantılı dosyalar olarak kaydedilen JavaScript kullanarak, Aspose.Slides for Node.js aracılığıyla Java üzerinden HTML'ye dışa aktarın."
---
## **Genel Bakış**

Varsayılan olarak, Aspose.Slides bir sunumu tek bir HTML dosyasına aktarır. Görseller ve diğer kaynaklar doğrudan HTML içine, genellikle Base64 veri olarak yazılır. Bu, tek bir taşınabilir dosyaya ihtiyacınız olduğunda kullanışlıdır, ancak bir web sitesi, bir CMS veya sunucu tarafı dönüştürme hattı için her zaman en iyi format değildir.

- HTML belgesinin boyutunu azaltmak;
- görselleri, yazı tiplerini, sesleri veya videoları bir tarayıcıda veya CDN'de ayrı ayrı önbelleğe almak;
- dışa aktarmadan sonra oluşturulan kaynakları denetlemek, değiştirmek, sıkıştırmak veya sonradan işlemek;
- çıktının yapısını web uygulamasının beklediğine daha yakın tutmak.

Genel HTML dönüştürme iş akışı için bkz. [Convert PowerPoint Presentations to HTML](/slides/tr/nodejs-java/convert-powerpoint-to-html/). Bu makale, dışa aktarmanın kaynak bağlama kısmına odaklanmaktadır.

## **Bağlantılı Kaynak Dışa Aktarma Nasıl Çalışır**

Java proxy'si olan [ILinkEmbedController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) uygulamanıza, kaynak bazında, dışa aktarıcının veriyi HTML içinde gömüp gömmeyeceğine ya da harici olarak kaydedip bir bağlantı yazıp yazmayacağına karar verme imkanı verir.

Denetleyicinin üç yöntemi vardır:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) bir kaynağın bağlantı mı yoksa gömülü mü olması gerektiğine karar verir.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) oluşturulan HTML'ye ya da başka bir bağlantılı kaynağa yazılacak URL'yi döndürür.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) bağlantılı kaynak verilerini diske ya da başka bir depolama hedefine yazar.

Dosya sistemi yolu ve tarayıcı URL'i ayrı konulardır. Örneğin, aşağıdaki örnek kaynak dosyalarını diskte `html-output/assets` konumuna yazar, ancak HTML `assets/resource-1.svg` gibi göreli URL'ler içerir. Bir tarayıcı bu URL'leri, bağlantıyı içeren dosyaya göreli olarak çözer. Bu nedenle, `presentation.html` dosyasından bir SVG dosyasına bağlantı `assets/resource-1.svg` şeklinde olurken, aynı `assets` klasöründe kaydedilmiş bir görsele SVG dosyasından yapılan bağlantı `resource-4.jpg` olur.

## **Bağlantılı Kaynaklarla HTML Dışa Aktarma**

Aşağıdaki JavaScript örneği bir çıktı dizini oluşturur, HTML dosyasını burada kaydeder ve bağlantılı kaynakları bir `assets` alt dizinine depolar. Denetleyici, Aspose.Slides güvenli bir dosya uzantısı sağladığında veya çıkarabildiğinde yaygın resim, yazı tipi, ses, video ve CSS kaynaklarını bağlar. Tanınmayan kaynaklar gömülü kalır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Dışa aktarmadan sonra, çıktı klasörü şu yapıya sahiptir:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Belirli dosyalar, sunum içeriğine ve dışa aktarma seçeneklerine bağlıdır. Örneğin, raster görüntüler genellikle JPEG veya PNG olarak dışa aktarılır. Aspose.Slides, kaynak sunumda kullanılandan daha küçük veya daha uygun bir dosya ürettiğinde farklı bir görüntü kodeği seçebilir. Şeffaflık içeren görseller PNG olarak dışa aktarılır.

## **Dağıtım İçin URL'lerin Seçimi**

Örnek, göreli bir URL öneki kullanır: `assets/`. `presentation.html` `html-output/presentation.html` konumundan açılırsa, tarayıcı `html-output/assets/resource-1.svg` dosyasını yükler.

Bir bağlantılı kaynak başka bir bağlantılı kaynağa referans verdiğinde, örnek [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) içinde `referrer` parametresini kullanır ve yalnızca dosya adını döndürür. Örneğin, `resource-1.svg` ve `resource-4.jpg` aynı `assets` klasöründeyse, SVG dosyası `assets/resource-4.jpg` yerine `resource-4.jpg` adresine başvurmalıdır.

Dosyalar başka bir yerde dağıtıldığında farklı bir URL öneki kullanın:

- Varlık dizini HTML dosyasının yanında olduğunda `assets/` kullanın.
- Varlık dizini HTML dosyasının bir seviye üstünde olduğunda `../assets/` kullanın.
- Dosyalar bir CDN ya da statik dosya sunucusuna yüklendiğinde `https://cdn.example.com/presentations/job-123/assets/` kullanın.

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) tarafından döndürülen URL, [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) tarafından yazılan dosyanın nihai dağıtım konumuyla eşleşmelidir. Sunucu uygulamalarında, başka bir dışa aktarmadan dosyaların üzerine yazılmasını önlemek için her dönüşüm işi için benzersiz bir çıktı dizini veya nesne depolama öneki kullanın.

## **Ne Zaman Gömülmüş Formu Tercih Etmeli**

Gömülü Base64 HTML, çıktı tek bir dosya olması gerektiğinde hâlâ kullanışlıdır; örneğin e-posta eki, çevrim dışı önizleme veya destekleyici varlık klasörü olmadan taşınacak bir belge. Bağlantılı kaynaklar, HTML bir web uygulaması tarafından sunulacak, bir CMS'de depolanacak, bir yapı hattı tarafından optimize edilecek veya tarayıcılar tarafından HTML'den bağımsız olarak önbelleğe alınacaksa daha uygun bir seçenektir.

## **SSS**

**Sadece görselleri harici hale getirip diğer kaynakları gömülü tutabilir miyim?**

Evet. [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) içinde, ayrı dosyalar olarak kaydetmek istediğiniz içerik türleri için yalnızca `LinkEmbedDecision.Link` döndürün ve diğer tümleri için `LinkEmbedDecision.Embed` döndürün.

**Neden dışa aktarılan görüntü uzantısı kaynak sunumdan farklı?**

Aspose.Slides, HTML dışa aktarımı sırasında boyutu iyileştirmek veya tarayıcı uyumluluğunu artırmak için raster görüntüleri yeniden kodlayabilir. Örneğin, kaynak dosyadaki bir görüntü, render sonucuna bağlı olarak JPEG veya PNG olarak yazılabilir.

**HTML dosyasını taşıdıktan sonra göreli URL'ler çalışır mı?**

Göreli URL'ler yalnızca aynı göreli klasör yapısı korunursa çalışır. HTML `assets/resource-1.png` adresine referans veriyorsa, `assets` klasörü HTML dosyasının yaninda kalmalıdır; aksi takdirde farklı bir URL öneki oluşturmanız gerekir.

**Sunucu uygulamaları aynı çıktı klasörünü yeniden kullanmalı mı?**

Hayır. Her dönüşüm işi için benzersiz bir çıktı dizini veya depolama öneki kullanın. Bu, dosya adı çakışmalarını önler ve bir dışa aktarmanın başka bir dışa aktarmanın oluşturduğu kaynakların üzerine yazılmasını engeller.