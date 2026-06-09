---
title: Sunumları Harici Bağlantılı Görsellerle HTML'ye Dışa Aktarma
type: docs
weight: 100
url: /tr/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint dışa aktar
- OpenDocument dışa aktar
- sunum dışa aktar
- slayt dışa aktar
- PPT dışa aktar
- PPTX dışa aktar
- ODP dışa aktar
- PowerPoint'tan HTML'ye
- OpenDocument'tan HTML'ye
- sunumdan HTML'ye
- slayttan HTML'ye
- PPT'den HTML'ye
- PPTX'ten HTML'ye
- ODP'den HTML'ye
- bağlantılı görüntü
- harici bağlantılı görüntü
- bağlantılı kaynak
- harici kaynak
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak Java üzerinden PHP'de PowerPoint ve OpenDocument sunumlarını HTML'ye dışa aktarın; görseller ve diğer kaynaklar harici bağlantılı dosyalar olarak kaydedilir."
---
## **Genel Bakış**

Varsayılan olarak, Aspose.Slides bir sunumu tek dosyalı HTML dosyasına aktarır. Görseller ve diğer kaynaklar doğrudan HTML içine, genellikle Base64 veri olarak yazılır. Tek bir taşınabilir dosya gerektiğinde bu kullanışlıdır, ancak her zaman bir web sitesi, bir CMS veya sunucu tarafı dönüştürme hattı için en iyi format değildir.

Harici bağlı kaynakları şu durumlarda kullanın:
- HTML belgesinin boyutunu azaltmak;
- görselleri, yazı tiplerini, sesleri veya videoları tarayıcıda veya CDN'de ayrı olarak önbelleğe almak;
- dışa aktarma sonrası oluşturulan kaynakları incelemek, değiştirmek, sıkıştırmak veya son işlem uygulamak;
- çıktı yapısını bir web uygulamasının beklediğine daha yakın tutmak.

Genel HTML dönüşüm iş akışı için [PowerPoint Sunumlarını HTML'ye Dönüştür](/slides/tr/php-java/convert-powerpoint-to-html/) sayfasına bakın. Bu makale dışa aktarmanın kaynak bağlama bölümüne odaklanır.

## **Bağlantılı Kaynak Dışa Aktarma Nasıl Çalışır**

[HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/) Aspose.Slides bir sunumu HTML'ye aktarırken özel bir link/gömme denetleyicisi kullanabilir. PHP üzerinden Java'da bu senaryo genellikle küçük bir Java yardımcı sınıfı ile uygulanır. Yardımcıyı derleyin, PHP Java Bridge sınıf yoluna ekleyin ve PHP'den `new Java(...)` ile örnekleyin.

Yardımcı sınıf, her kaynak için dışa aktarıcının veriyi HTML içine gömüp gömmeyeceğine ya da dışarı kaydedip bir bağlantı yazacağına karar verir. Üç geri arama metoduna ihtiyaç duyar:
- `ExternalResourceController.getObjectStoringLocation` bir kaynağın link mi yoksa gömülü mü olacağını belirler.
- `ExternalResourceController.getUrl` oluşturulan HTML'ye ya da başka bir bağlı kaynağa yazılacak URL'yi döndürür.
- `ExternalResourceController.saveExternal` bağlı kaynak verisini diske ya da başka bir depolama hedefine yazar.

Dosya sistemi yolu ve tarayıcı URL'si ayrı konulardır. Örneğin, aşağıdaki örnek kaynak dosyalarını diskte `html-output/assets` klasörüne yazar, ancak HTML `assets/resource-1.svg` gibi göreli URL'ler içerir. Bir tarayıcı bu URL'leri bağlantıyı içeren dosyaya göreli olarak çözer. Bu nedenle `presentation.html` dosyasından bir SVG dosyasına bağlantı `assets/resource-1.svg` kullanırken, aynı `assets` klasöründeki bir görsele başvuran SVG dosyası `resource-4.jpg` olarak referans verir.

## **Java Yardımcı Sınıfını Oluşturma**

`com.example.slides.ExternalResourceController` gibi bir Java sınıfı oluşturun, sınıf yolunda Aspose.Slides for Java ile derleyin ve derlenmiş sınıfı veya JAR dosyasını PHP Java Bridge'e erişilebilir hâle getirin.

Aşağıdaki yardımcı, Aspose.Slides güvenli bir dosya uzantısı sağladığında veya çıkarabildiğinde yaygın görüntü, yazı tipi, ses, video ve CSS kaynaklarını bağlar. Tanınmayan kaynaklar gömülü kalır.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **HTML'yi Bağlantılı Kaynaklarla Dışa Aktar**

Aşağıdaki PHP kodu bir çıktı dizini oluşturur, HTML dosyasını oraya kaydeder ve bağlı kaynakları bir `assets` alt klasöründe saklar. Dışa aktarma için [HtmlOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideimageformat/) ve [SaveFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveformat/) birleştirilir.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Dışa aktarmadan sonra çıktı klasörü şu yapıya sahiptir:

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

Tam dosyalar sunum içeriğine ve dışa aktarma seçeneklerine bağlıdır. Örneğin, raster görüntüler genellikle JPEG veya PNG olarak dışa aktarılır. Aspose.Slides, daha küçük veya daha uygun bir dosya sağladığında kaynak sunumdaki uzantıdan farklı bir görüntü codec'i seçebilir. Şeffaflık içeren görseller PNG olarak dışa aktarılır.

## **Dağıtım için URL'lerin Seçilmesi**

Örnek göreli bir URL öneki kullanır: `assets/`. `presentation.html` `html-output/presentation.html` konumundan açılırsa tarayıcı `html-output/assets/resource-1.svg` dosyasını yükler.

Bir bağlantılı kaynak başka bir bağlantılı kaynağa başvurduğunda örnek, `ExternalResourceController.getUrl` içindeki `referrer` parametresini kullanır ve yalnızca dosya adını döndürür. Örneğin, `resource-1.svg` ve `resource-4.jpg` aynı `assets` klasöründeyse SVG dosyası `resource-4.jpg`'a, `assets/resource-4.jpg`'a değil, başvurmalıdır.

Dosyalar başka bir konuma dağıtıldığında farklı bir URL öneki kullanın:
- `assets/` dizini HTML dosyasının yanındaysa kullanın.
- `../assets/` dizini HTML dosyasının bir üst seviyedeyse kullanın.
- Dosyalar bir CDN ya da statik dosya sunucusuna yüklenecekse `https://cdn.example.com/presentations/job-123/assets/` önekini kullanın.

`ExternalResourceController.getUrl` tarafından döndürülen URL, `ExternalResourceController.saveExternal` tarafından yazılan dosyanın nihai dağıtım konumuyla eşleşmelidir. Sunucu uygulamalarında, başka bir dışa aktarmanın dosyalarını üzerine yazmamak için her dönüşüm görevi için benzersiz bir çıktı dizini veya nesne depolama öneki kullanın.

## **Gömme Ne Zaman Tercih Edilir**

Gömülü Base64 HTML, çıktı tek bir dosya olması gerektiğinde hâlâ kullanışlıdır; örneğin e‑posta eki, çevrim dışı ön izleme veya destekleyici bir varlık klasörü olmadan taşınacak bir belge. Bağlantılı kaynaklar, HTML bir web uygulaması tarafından sunulacaksa, bir CMS içinde depolanacaksa, bir yapı işlem hattı tarafından optimize edilecekse veya tarayıcılar HTML'den bağımsız olarak önbelleğe alacaksa daha uygun bir çözümdür.

## **SSS**

**Sadece görselleri dışa aktarıp diğer kaynakları gömülü tutabilir miyim?**

Evet. `ExternalResourceController.getObjectStoringLocation` içinde, ayrı dosyalar olarak kaydetmek istediğiniz içerik türleri için yalnızca [LinkEmbedDecision](https://reference.aspose.com/slides/tr/php-java/aspose.slides/linkembeddecision/) `Link` değerini, diğer tümleri için `Embed` değerini döndürün.

**Dışa aktarılan görüntü uzantısı kaynak sunumdan neden farklı?**

Aspose.Slides, HTML dışa aktarımı sırasında boyutu veya tarayıcı uyumluluğunu iyileştirmek için raster görüntüleri yeniden kodlayabilir. Örneğin, kaynak dosyadaki bir görüntü, render sonucuna bağlı olarak JPEG veya PNG olarak yazılabilir.

**HTML dosyasını taşıdıktan sonra göreli URL'ler çalışır mı?**

Göreli URL'ler yalnızca aynı göreli klasör yapısı korunduğunda çalışır. HTML `assets/resource-1.png` dosyasına atıfta bulunuyorsa, `assets` klasörü HTML dosyasının yaninda kalmalıdır; aksi takdirde farklı bir URL öneki üretmeniz gerekir.

**Sunucu uygulamaları aynı çıktı klasörünü yeniden kullanmalı mı?**

Hayır. Her dönüşüm görevi için benzersiz bir çıktı dizini veya depolama öneki kullanın. Bu, dosya adı çakışmalarını önler ve bir dışa aktarmanın, başka bir dışa aktarmanın oluşturduğu kaynakları üzerine yazmasını engeller.