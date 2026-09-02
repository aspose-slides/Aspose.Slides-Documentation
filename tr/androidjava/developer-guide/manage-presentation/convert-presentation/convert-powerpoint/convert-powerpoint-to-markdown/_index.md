---
title: "Android'de PowerPoint Sunumlarını Markdown'a Dönüştür"
linktitle: "PowerPoint'ten Markdown'a"
type: docs
weight: 140
url: /tr/androidjava/convert-powerpoint-to-markdown/
keywords:
- "PowerPoint dönüştür"
- "sunumu dönüştür"
- "slaytı dönüştür"
- "PPT dönüştür"
- "PPTX dönüştür"
- "PowerPoint'ten MD"
- "sunumu MD'ye"
- "slaytı MD'ye"
- "PPT'den MD"
- "PPTX'ten MD"
- "PowerPoint'i Markdown olarak kaydet"
- "sunumu Markdown olarak kaydet"
- "slaytı Markdown olarak kaydet"
- "PPT'yi MD olarak kaydet"
- "PPTX'i MD olarak kaydet"
- "PPT'yi MD'ye dışa aktar"
- "PPTX'i MD'ye dışa aktar"
- "Markdown görüntü dışa aktarımı"
- "CDN görüntü bağlantıları"
- "PowerPoint"
- "sunum"
- "Markdown"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Android'de Java aracılığıyla PPT ve PPTX sunumlarını Markdown'a dönüştürün ve dışa aktarılan bitmap, metafile ve SVG görüntülerinin nerede kaydedileceğini ve nasıl referans verileceğini kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, belge oluşturma, statik site, içerik taşıma ve sürüm kontrolü iş akışları için PPT ve PPTX sunumlarını Markdown'a dönüştürebilir. Bir Markdown çeşidini seçebilir, slayt içeriğinin nasıl işlendiğini kontrol edebilir ve dışa aktarılan görsellerin nerede saklanacağını ve oluşturulan Markdown'un bunlara nasıl referans vereceğini belirleyebilirsiniz.

Varsayılan olarak, Markdown dışa aktarma sadece metin çıktısı üretir. Görsel içeriği dışa aktarmak için, dışa aktarma türünü [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) yöntemiyle [MarkdownExportType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownexporttype/) enumarasyonundaki `Sequential` veya `Visual` değerine ayarlayın. `Sequential` slayt öğelerini ayrı ayrı ve sırayla işler, `Visual` ise görsel ilişkilerini korumak için gruplanmış öğeleri birlikte tutar. `TextOnly` değeri görüntü kaynaklarını üretmez, bu yüzden bu modda görüntü kaydetme geri çağırmaları yürütülmez.

## **Bir Sunumu Markdown'a Dönüştürme**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) yöntemini [SaveFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveformat/) enumarasyonundaki `Md` değeriyle çağırın.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Bir Markdown Çeşidi Seçme**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) yöntemi, çıktıda kullanılan Markdown spesifikasyonunu kontrol eder. [Flavor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/flavor/) enumarasyonu CommonMark, GitHub Flavored Markdown ve diğer desteklenen varyantları içerir.

Aşağıdaki örnek bir sunumu CommonMark olarak dışa aktarır:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Varsayılan Yerel Kaydetme Davranışıyla Görselleri Dışa Aktarma**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) sınıfı, yerel olarak kaydedilen görselleri yapılandırmak için iki yöntem sağlar:

- [setBasePath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) Markdown belgesi ve kaynakları için temel dizini belirtir.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) görsel alt dizinini belirtir. Varsayılan değeri `Images`'tır.

Aşağıdaki örnek görsel içeriği işler, görselleri `output/assets` klasörüne yazar ve Markdown belgesinde göreli görsel referansları oluşturur:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Bu davranış, özel bir görüntü kaydetme işleyicisi `false` döndürdüğünde yedek olarak da hizmet verir.

## **Görsel Kaydetme ve Markdown Bağlantılarını Özelleştirme**

Markdown dışa aktarımı sırasında oluşturulan SVG olmayan bitmap ve metafile kaynakları için bir geri çağırma kaydetmek üzere [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) yöntemini kullanın. `MarkdownImageSavingHandler` geri çağrısı, [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesini, onun [ImageFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imageformat/) değerini ve oluşturulan Markdown bağlantısını tek elemanlı `String[]` parametresi olarak alır. Görseli verilen formatta kaydedin veya yükleyin ve `link[0]` değerini Markdown çıktısında görünmesi gereken referansla değiştirin.

SVG formatında oluşturulan kaynaklar ayrı olarak işlenir. [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) yöntemiyle bir geri çağırma kaydedin. `MarkdownSvgImageSavingHandler` geri çağrısı bir [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) nesnesi ve tek elemanlı `String[] link` parametresini alır. SVG'nin bir `ImageFormat` argümanı yoktur; bunun yerine XML verisini [ISvgImage.getSvgData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) yöntemiyle yazın veya yükleyin. Dışa aktarma modu ve görsel gruplamaya bağlı olarak, kaynak sunumdaki bir SVG rasterleştirilebilir veya diğer içeriklerle birleştirilebilir; ortaya çıkan SVG olmayan kaynak daha sonra görsel kaydetme geri çağrısına iletilir. Tüm dışa aktarılan görsel kaynaklar özel işleme ihtiyaç duyduğunda her iki geri çağırmayı da kaydedin.

Görseli kimin işleyeceği, işleyicinin dönüş değerine göre belirlenir:

- `true` döndürün; işleyici görseli kaydettikten, yükledikten, dönüştürdükten veya başka bir şekilde işledikten ve `link[0]`'a geçerli bir değer attıktan sonra. Aspose.Slides bu değeri Markdown belgesine yazar ve varsayılan yerel kaydetme işlemini yapmaz.
- `false` döndürün; Aspose.Slides'in görseli yerel olarak kaydetmesine ve bağlantısını [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) ve [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) ile ayarlanan değerlere göre oluşturmasına izin verin.

{{% alert color="warning" title="Important" %}}
`true` döndüren bir işleyici, görselin sorumluluğunu alır. Geçerli ve boş olmayan bir bağlantı atamadan `true` dönerse, dışa aktarma `InvalidOperationException` ile başarısız olur.
{{% /alert %}}

### **Görselleri CDN Kaynak Dizini'ne Kaydetme ve Harici URL'ler Kullanma**

Aşağıdaki örnek `cdn-origin/presentations/quarterly-report` dizinini bağlanmış veya senkronize edilmiş bir CDN kaynak dizini olarak ele alır. Her işleyici, oluşturulan dosya adını alır, görseli bu özel dizine kaydeder ve yerel referansı genel bir CDN URL'siyle değiştirir. Örnek kendisi ağ üzerinden bir yükleme yapmaz: URL, dizin CDN kaynağı olarak bağlandıktan veya dosyaları CDN'ye yayınlandıktan sonra geçerli olur. Nesne depolama için, dosya sistemi yazımını depolama SDK'sının yükleme operasyonuyla değiştirin ve `link[0]`'ı yalnızca yükleme başarılı olduğunda atayın.
```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Bitmap işleyicisi, 128 × 128 pikselden küçük görseller için kasıtlı olarak `false` döndürür; böylece Aspose.Slides bu görselleri varsayılan davranışı kullanarak `output/fallback-images` klasörüne kaydeder. Daha büyük bitmap ve metafile kaynakları ve SVG kaynakları özel kod tarafından işlenir. Örneğin, `fallback-images/image1.png` gibi oluşturulan yerel bir referans `https://cdn.example.com/presentations/quarterly-report/image1.png` haline gelir. İşleyiciler dosya yazarken yalnızca işletim sistemi yollarını kullanır; Markdown'a yazılan bağlantılar ise ileri eğik çizgi ve URL kodlu dosya adları içerir. Göreli bağlantılar oluştururken aynı kuralı uygulayın: platforma özgü dizin ayırıcı yerine `/` kullanın.

## **FAQ**

**Bir işleyici hem raster görselleri hem de SVG görselleri işleyebilir mi?**

Hayır. Oluşturulan bitmap ve metafile kaynakları için [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) , SVG olarak oluşturulan kaynaklar için ise [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) kullanın. İlk yöntem bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesi ve bir [ImageFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imageformat/) değeri sağlar; ikincisi ise SVG verisi [ISvgImage.getSvgData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) ile okunabilen bir [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) nesnesi sağlar. Dışa aktarma sırasında rasterleştirilen bir kaynak SVG, görüntü kaydetme geri çağırması tarafından işlenir.

**Bir image-saving işleyicisi `false` döndürdüğünde ne olur?**

Aspose.Slides varsayılan yerel kaydetme davranışını kullanır. Görselin konumu ve oluşturulan referans, [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) ve [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/markdownsaveoptions/) ile ayarlanan değerlerle kontrol edilir.

**Bir işleyici görüntüyü yerel olarak kaydetmeden bir URL sağlayabilir mi?**

Evet. İşleyici görseli nesne depolamaya yükleyebilir veya başka bir hizmete yönlendirebilir, oluşan URL'yi `link[0]`'a atayabilir ve `true` dönebilir. İşleyicinin işlemi kendisi tamamlaması gerekir; `true` döndürmek varsayılan yerel kaydetmeyi engeller.

**Markdown dışa aktarımı, bir işleyiciden `InvalidOperationException` hatası atmasına neden neden olur?**

Bu istisna, işleyicinin `true` döndürdüğü ancak geçerli bir bağlantı sağlamadığı zaman ortaya çıkar. `true` döndürmeden önce Markdown'a yazılması gereken göreli yolu veya dış URL'yi `link[0]`'a atayın.

**Görsel bağlantılar hangi yol ayırıcıyı kullanmalı?**

Markdown bağlantılarında ve URL'lerde ileri eğik çizgi (`/`) kullanın. Dosya sistemi yolları için yalnızca `Path.resolve` kullanın, ardından Markdown referansını ayrı olarak oluşturun veya normalleştirin.

**Markdown dışa aktarımı sırasında hiperlinkler korunur mu?**

Evet. Metin [bağlantılar](/slides/tr/androidjava/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [geçişleri](/slides/tr/androidjava/slide-transition/) ve [animasyonları](/slides/tr/androidjava/powerpoint-animation/) dönüştürülmez.

**Sunumlar paralel olarak Markdown'a dönüştürülebilir mi?**

Farklı sunum dosyalarını paralel olarak işleyebilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) örneğini iş parçacıkları arasında paylaşmayın. [Çoklu iş parçacığı yönergelerini](/slides/tr/androidjava/multithreading/) izleyin ve her dosya için ayrı bir örnek kullanın.