---
title: Sunumları Dış Bağlantılı Görsellerle HTML'ye Dışa Aktarma
type: docs
weight: 100
url: /tr/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- PPTX'den HTML'ye
- ODP'den HTML'ye
- bağlantılı görüntü
- dışarıdan bağlantılı görüntü
- bağlantılı kaynak
- dış kaynak
- Android
- Java
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Android'de Java aracılığıyla Aspose.Slides kullanarak HTML'ye dışa aktarın; görüntüler ve diğer kaynaklar dış bağlantılı dosyalar olarak kaydedilir."
---
## **Genel Bakış**

Varsayılan olarak, Aspose.Slides bir sunumu tek bir HTML dosyasına dışa aktarır. Görseller ve diğer kaynaklar doğrudan HTML içine, genellikle Base64 veri olarak yazılır. Tek bir taşınabilir dosyaya ihtiyacınız olduğunda bu kullanışlıdır, ancak bir web görünümü, bir CMS ya da daha sonra çıktıyı yayınlayan sunucu tarafı dönüşüm hattı için her zaman en iyi format değildir.

Harici bağlantılı kaynakları aşağıdaki durumlarda kullanın:

- HTML belgesinin boyutunu azaltmak;
- Görselleri, yazı tiplerini, sesleri veya videoları tarayıcıda ya da CDN'de ayrı olarak önbelleğe almak;
- Dışa aktarmadan sonra oluşturulan kaynakları incelemek, değiştirmek, sıkıştırmak ya da son işlem yapmak;
- Çıktı yapısını bir web uygulamasının beklentilerine daha yakın tutmak.

Genel HTML dönüştürme iş akışı için, [Convert PowerPoint Presentations to HTML](/slides/tr/androidjava/convert-powerpoint-to-html/) bölümüne bakın. Bu makale, dışa aktarmanın kaynak bağlama kısmına odaklanmaktadır.

## **Bağlantılı Kaynak Dışa Aktarımının Nasıl Çalıştığı**

[ILinkEmbedController](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinkembedcontroller/) uygulamanıza, kaynak bazında, dışa aktarımcının veriyi HTML'e gömüp gömmeyeceğine ya da harici olarak kaydedip bir bağlantı yazacağına karar vermesini sağlar.

Arayüzün üç yöntemi vardır:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinkembedcontroller/) bir kaynağın bağlantılı mı yoksa gömülü mü olacağını belirler.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinkembedcontroller/) oluşturulan HTML'e ya da başka bir bağlantılı kaynağa yazılacak URL'yi döndürür.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinkembedcontroller/) bağlantılı kaynak verisini diske ya da başka bir depolama hedefine yazar.

Dosya sistemi yolu ve tarayıcı URL'si ayrı konulardır. Örneğin, aşağıdaki örnek kaynak dosyalarını uygulamanın dosya depolamasında `html-output/assets` konumuna yazar, HTML ise `assets/resource-1.svg` gibi görece URL'ler içerir. Bir tarayıcı bu URL'leri bağlantıyı içeren dosyaya göre çözümleyecek şekilde işler. Dolayısıyla, `presentation.html` dosyasından bir SVG dosyasına bağlantı `assets/resource-1.svg` şeklinde olurken, aynı `assets` klasöründe saklanan bir görsele SVG dosyasından yapılan bağlantı `resource-4.jpg` olur.

## **Bağlantılı Kaynaklarla HTML Dışa Aktarma**

Aşağıdaki Android Java örneği bir çıktı dizini oluşturur, HTML dosyasını oraya kaydeder ve bağlantılı kaynakları `assets` alt dizininde depolar. `applicationFilesDirectory` olarak `context.getFilesDir()` gibi uygulamaya ait bir dizin iletin. Kod, `java.nio.file` API'lerini kullanmaz; bu sayede Android `minSdk` 19 ile uyumludur.

Denetleyici, Aspose.Slides bir güvenli dosya uzantısı sağladığında ya da çıkarabildiğinde yaygın görüntü, yazı tipi, ses, video ve CSS kaynaklarını bağlar. Tanınmayan kaynaklar gömülü kalır.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
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

Tam dosyalar, sunum içeriğine ve dışa aktarma seçeneklerine bağlıdır. Örneğin, raster görüntüler genellikle JPEG veya PNG olarak dışa aktarılır. Aspose.Slides, kaynak sunumda kullanılandan daha küçük veya daha uygun bir dosya ürettiğinde farklı bir görüntü codec'i seçebilir. Transparanlığı olan görüntüler PNG olarak dışa aktarılır.

## **Dağıtım İçin URL'lerin Seçimi**

Örnek, göreli bir URL öneki kullanır: `assets/`. `presentation.html` `html-output/presentation.html` konumundan açılırsa, tarayıcı `html-output/assets/resource-1.svg` dosyasını yükler.

Bir bağlantılı kaynak başka bir bağlantılı kaynağa başvurduğunda, örnek [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinkembedcontroller/) içinde `referrer` parametresini kullanır ve sadece dosya adını döndürür. Örneğin, `resource-1.svg` ve `resource-4.jpg` aynı `assets` klasöründeyse, SVG dosyası `resource-4.jpg`'ye, `assets/resource-4.jpg` yerine, başvurmalıdır.

Dosyalar başka bir yerde dağıtıldığında farklı bir URL öneki kullanın:

- `assets/` kullanın, varlık dizini HTML dosyasının yanında olduğunda.
- `../assets/` kullanın, varlık dizini HTML dosyasının bir seviye üstünde olduğunda.
- `https://cdn.example.com/presentations/job-123/assets/` kullanın, dosyalar bir CDN ya da statik dosya sunucusuna yüklendiğinde.

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinkembedcontroller/) tarafından döndürülen URL, [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinkembedcontroller/) tarafından yazılan dosyanın nihai dağıtım konumuyla eşleşmelidir. Android uygulamalarında, yayın akışınıza göre uygulamaya özel depolama, bir önbellek dizini veya Depolama Erişim Çerçevesi üzerinden elde edilen bir dizin kullanın. Sunucu uygulamalarında, başka bir dışa aktarmanın dosyalarını üzerine yazmayı önlemek için her dönüşüm işi için benzersiz bir çıktı dizini veya nesne‑depolama öneki kullanın.

## **Ne Zaman Gömülmüş Kullanılmalı**

Gömülü Base64 HTML, çıktı tek bir dosya olmalıysa hâlâ yararlıdır; örneğin bir e‑posta eki, çevrim dışı ön izleme veya destekleyici varlık klasörü olmadan taşınacak bir belge. Bağlantılı kaynaklar, HTML bir web uygulaması tarafından sunulacak, bir CMS'de depolanacak, bir derleme hattı tarafından optimize edilecek veya tarayıcılar tarafından HTML'den bağımsız olarak önbelleğe alınacaksa daha uygun bir seçenektir.

## **SSS**

**Sadece görselleri harici hale getirip diğer kaynakları gömülü tutabilir miyim?**

Evet. [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinkembedcontroller/) içinde, ayrı dosyalar olarak kaydetmek istediğiniz içerik türleri için sadece `Link` döndürün ve diğer tüm içerikler için `Embed` döndürün.

**Neden dışa aktarılan görüntü uzantısı kaynak sunumdan farklı?**

Aspose.Slides, HTML dışa aktarımı sırasında boyutu azaltmak veya tarayıcı uyumluluğunu artırmak için raster görüntüleri yeniden kodlayabilir. Örneğin, kaynak dosyadaki bir görüntü, oluşturulan sonuca bağlı olarak JPEG veya PNG olarak yazılabilir.

**HTML dosyasını taşıdıktan sonra göreli URL'ler çalışır mı?**

Göreli URL'ler yalnızca aynı göreli klasör yapısı korunduğunda çalışır. HTML `assets/resource-1.png` adresine başvuruyorsa, `assets` klasörü HTML dosyasının yanında kalmalıdır; aksi takdirde farklı bir URL öneki oluşturmanız gerekir.

**Android'de kaynakları herkese açık harici depolamaya yazabilir miyim?**

Evet, uygulamanız hedef Android sürümü için geçerli bir hedef konuma ve izin modeline sahipse. Yalnızca uygulamanız tarafından kullanılan oluşturulan HTML için, uygulamaya özel dosyalar veya önbellek dizinleri genellikle daha basittir. Kullanıcıya görünür çıktı için, kullanıcı tarafından seçilen bir konum veya uygulamanıza uygun başka bir depolama yöntemi kullanın.

**Sunucu uygulamaları aynı çıktı klasörünü yeniden kullanmalı mı?**

Hayır. Her dönüşüm işi için benzersiz bir çıktı dizini veya depolama öneki kullanın. Bu, dosya adı çakışmalarını önler ve bir dışa aktarmanın başka bir dışa aktarmanın kaynaklarını üzerine yazmasını engeller.