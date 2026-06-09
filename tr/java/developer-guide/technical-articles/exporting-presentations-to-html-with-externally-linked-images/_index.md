---
title: Sunumları Harici Bağlantılı Görsellerle HTML'ye Dışa Aktarma
type: docs
weight: 100
url: /tr/java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint'i dışa aktar
- OpenDocument'i dışa aktar
- sunumu dışa aktar
- slaytı dışa aktar
- PPT'yi dışa aktar
- PPTX'i dışa aktar
- ODP'yi dışa aktar
- PowerPoint'ten HTML'ye
- OpenDocument'ten HTML'ye
- sunumdan HTML'ye
- slayttan HTML'ye
- PPT'den HTML'ye
- PPTX'den HTML'ye
- ODP'den HTML'ye
- bağlantılı görsel
- harici bağlantılı görsel
- bağlantılı kaynak
- harici kaynak
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Java'da Aspose.Slides kullanarak HTML'ye dışa aktar, görseller ve diğer kaynaklar harici bağlantılı dosyalar olarak kaydedilir."
---
## **Genel Bakış**

Varsayılan olarak, Aspose.Slides bir sunumu tek bir HTML dosyasına dışa aktarır. Görseller ve diğer kaynaklar genellikle Base64 veri olarak doğrudan HTML'ye yazılır. Tek bir taşınabilir dosyaya ihtiyacınız olduğunda bu kullanışlıdır, ancak her zaman bir web sitesi, bir CMS veya sunucu tarafı dönüşüm hattı için en iyi format değildir.

Harici olarak bağlantılı kaynakları şu durumlarda kullanın:
- HTML belgesinin boyutunu azaltmak;
- görüntüleri, yazı tiplerini, sesleri veya videoları tarayıcıda veya CDN'de ayrı ayrı önbelleğe almak;
- dışa aktarmadan sonra oluşturulan kaynakları incelemek, değiştirmek, sıkıştırmak veya sonradan işlemek;
- çıktının yapısını bir web uygulamasının beklediğine daha yakın tutmak.

Genel HTML dönüştürme iş akışı için [Convert PowerPoint Presentations to HTML](/slides/tr/java/convert-powerpoint-to-html/) sayfasına bakın. Bu makale dışa aktarmanın kaynak bağlama kısmına odaklanmaktadır.

## **Bağlantılı Kaynak Dışa Aktarmanın Çalışma Şekli**

[ILinkEmbedController](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) uygulamanıza, kaynak bazında, dışa aktarıcının veriyi HTML'e gömüp gömmeyeceğine ya da harici olarak kaydedip bir bağlantı yazacağına karar vermeyi sağlar.

Arayüzün üç yöntemi vardır:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) bir kaynağın bağlantı mı yoksa gömülü mü olacağını belirler.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) oluşturulan HTML'ye ya da başka bir bağlanan kaynağa yazılacak URL'yi döndürür.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) bağlanan kaynak verisini diske ya da başka bir depolama hedefine yazar.

Dosya sistemi yolu ve tarayıcı URL'si ayrı konulardır. Örneğin, aşağıdaki örnek kaynak dosyalarını diskte `html-output/assets` konumuna yazar, HTML ise `assets/resource-1.svg` gibi göreli URL'ler içerir. Bir tarayıcı bu URL'leri bağlantıyı içeren dosyaya göre göreli olarak çözer. Bu nedenle, `presentation.html` dosyasından bir SVG dosyasına bağlantı `assets/resource-1.svg` kullanır, o SVG dosyasından aynı `assets` klasöründeki bir resme bağlantı ise `resource-4.jpg` kullanır.

## **Bağlantılı Kaynaklarla HTML Dışa Aktarma**

Aşağıdaki Java örneği bir çıktı dizini oluşturur, HTML dosyasını oraya kaydeder ve bağlantılı kaynakları bir `assets` alt dizininde saklar. Kontrolcü, Aspose.Slides güvenli bir dosya uzantısı sağladığında veya çıkarabildiğinde ortak görüntü, yazı tipi, ses, video ve CSS kaynaklarını bağlar. Tanınmayan kaynaklar gömülü kalır.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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
}
```

Dışa aktarmadan sonra, çıktı klasörü aşağıdaki yapıya sahiptir:

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

Tam dosyalar sunum içeriğine ve dışa aktarma seçeneklerine bağlıdır. Örneğin, raster görüntüler genellikle JPEG veya PNG olarak dışa aktarılır. Aspose.Slides, kaynak sunumda kullanılandan daha küçük veya daha uygun bir dosya ürettiğinde farklı bir görüntü codec'i seçebilir. Şeffaflığı olan görüntüler PNG olarak dışa aktarılır.

## **Dağıtım İçin URL'lerin Seçimi**

Örnek göreli bir URL ön eki kullanır: `assets/`. `presentation.html` `html-output/presentation.html` konumundan açılırsa, tarayıcı `html-output/assets/resource-1.svg` yükler.

Bir bağlantılı kaynak başka bir bağlantılı kaynağa başvurduğunda, örnek [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) içinde `referrer` parametresini kullanır ve yalnızca dosya adını döndürür. Örneğin, `resource-1.svg` ve `resource-4.jpg` aynı `assets` klasöründeyse, SVG dosyası `assets/resource-4.jpg` yerine `resource-4.jpg` adresine başvurmalıdır.

Dosyalar başka bir yerde dağıtıldığında farklı bir URL ön eki kullanın:
- HTML dosyasının yanındaki varlık (asset) dizini için `assets/` kullanın.
- Varlık dizini HTML dosyasının bir seviye üstünde ise `../assets/` kullanın.
- Dosyalar bir CDN'ye veya statik dosya sunucusuna yüklendiğinde `https://cdn.example.com/presentations/job-123/assets/` kullanın.

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) tarafından döndürülen URL, [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) tarafından yazılan dosyanın nihai dağıtım konumuyla eşleşmelidir. Sunucu uygulamalarında, her dönüşüm işi için benzersiz bir çıktı dizini veya nesne depolama ön eki kullanarak başka bir dışa aktarmanın dosyalarını üzerine yazmayı önleyin.

## **Ne Zaman Gömmeli**

Gömülü Base64 HTML, çıktı tek bir dosya olmalıysa hâlâ kullanışlıdır; örneğin bir e-posta eki, çevrim dışı ön izleme veya destekleyici varlık klasörü olmadan taşınacak bir belge. Bağlantılı kaynaklar, HTML bir web uygulaması tarafından hizmet verilecekse, bir CMS'de depolanacaksa, bir yapı hattı tarafından optimize edilecekse veya tarayıcılar tarafından HTML'den bağımsız olarak önbelleğe alınacaksa daha uygundur.

## **SSS**

**Sadece görüntüleri harici birleştirebilir ve diğer kaynakları gömülü tutabilir miyim?**

Evet. [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinkembedcontroller/) içinde yalnızca ayrı dosyalar olarak kaydetmek istediğiniz içerik türleri için `LinkEmbedDecision.Link`, diğer tümleri için `LinkEmbedDecision.Embed` döndürün.

**Neden dışa aktarılan görüntü uzantısı kaynak sunumdan farklıdır?**

Aspose.Slides, HTML dışa aktarımı sırasında raster görüntüleri yeniden kodlayarak boyutu küçültebilir veya tarayıcı uyumluluğunu artırabilir. Örneğin, kaynak dosyadaki bir görüntü, işlenen sonuca bağlı olarak JPEG veya PNG olarak yazılabilir.

**HTML dosyasını taşıdıktan sonra göreli URL'ler çalışır mı?**

Göreli URL'ler yalnızca aynı göreli klasör yapısı korunduğunda çalışır. HTML `assets/resource-1.png` referans veriyorsa, `assets` klasörü HTML dosyasının yaninda kalmalıdır; farklı bir URL ön eki oluşturmazsanız.

**Sunucu uygulamaları aynı çıktı klasörünü yeniden kullanmalı mı?**

Hayır. Her dönüşüm işi için benzersiz bir çıktı dizini veya depolama ön eki kullanın. Bu, dosya adı çakışmalarını önler ve bir dışa aktarmanın diğerinin ürettiği kaynakların üzerine yazmasını engeller.