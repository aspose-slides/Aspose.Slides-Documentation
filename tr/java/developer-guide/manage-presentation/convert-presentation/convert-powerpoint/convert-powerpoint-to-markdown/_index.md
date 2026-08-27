---
title: Java'da PowerPoint Sunumlarını Markdown'a Dönüştür
linktitle: PowerPoint'den Markdown'a
type: docs
weight: 140
url: /tr/java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint dönüştür
- Sunumu dönüştür
- Slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan MD'ye
- Sunumdan MD'ye
- Slayttan MD'ye
- PPT'den MD'ye
- PPTX'den MD'ye
- PowerPoint'i Markdown olarak kaydet
- Sunumu Markdown olarak kaydet
- Slaytı Markdown olarak kaydet
- PPT'yi MD olarak kaydet
- PPTX'i MD olarak kaydet
- PPT'yi MD'ye aktar
- PPTX'i MD'ye aktar
- Markdown görüntü dışa aktarma
- CDN görüntü bağlantıları
- PowerPoint
- sunum
- Markdown
- Java
- Aspose.Slides
description: "Java'da PPT ve PPTX sunumlarını Markdown'a dönüştürün ve dışa aktarılan bitmap, metafile ve SVG görüntülerinin nerede kaydedildiğini ve referans verildiğini kontrol edin."
---
## **Genel Bakış**

Aspose.Slides for Java, PPT ve PPTX sunumlarını belgeleme, sabit site, içerik taşıma ve sürüm kontrolü iş akışları için Markdown'a dönüştürebilir. Bir Markdown çeşidini seçebilir, slayt içeriğinin nasıl renderlanacağını kontrol edebilir ve dışa aktarılan görüntülerin nerede depolanacağını ve oluşturulan Markdown'un bunlara nasıl referans verdiğini belirleyebilirsiniz.

Varsayılan olarak, Markdown dışa aktarma yalnızca metin çıktısı üretir. Görsel içeriği dışa aktarmak için, dışa aktarma türünü [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) yöntemiyle [MarkdownExportType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownexporttype/) enum'undan `Sequential` veya `Visual` değerine ayarlayın. `Sequential`, slayt öğelerini ayrı ayrı ve sırayla renderlarken, `Visual` grup içindeki öğeleri bir arada tutarak görsel ilişkilerini korur. `TextOnly` değeri görüntü kaynaklarını üretmez, bu yüzden bu modda görüntü kaydetme geri çağrıları çalıştırılmaz.

## **Bir Sunumu Markdown'a Dönüştür**

Kaynak dosyayı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin ve ardından [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) yöntemini [SaveFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveformat/) enum'undan `Md` değeriyle çağırın.

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

## **Bir Markdown Çeşidi Seçin**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) yöntemi, çıktıda kullanılan Markdown spesifikasyonunu kontrol eder. [Flavor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/flavor/) enum'ı CommonMark, GitHub Flavored Markdown ve diğer desteklenen varyantları içerir.

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

## **Görüntüleri Varsayılan Yerel Kaydetme Davranışıyla Dışa Aktarın**

[MarkdownSaveOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) sınıfı, yerel olarak kaydedilen görüntüleri yapılandırmak için iki yöntem sağlar:

- [setBasePath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) Markdown belgesi ve kaynakları için temel dizini belirler.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) görüntü alt dizinini belirler. Varsayılan değeri `Images`'dır.

Aşağıdaki örnek görsel içeriği renderlar, görüntüleri `output/assets` dizinine yazar ve Markdown belgesinde göreli görüntü referansları oluşturur:

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

Bu davranış, özel bir görüntü kaydetme işleyicisi `false` döndürdüğünde geri dönüş (fallback) olarak da hizmet eder.

## **Görüntü Kaydetmeyi ve Markdown Bağlantılarını Özelleştirin**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) yöntemini, Markdown dışa aktarımı sırasında üretilen SVG olmayan bitmap ve metafile kaynakları için bir geri çağrı kaydetmek üzere kullanın. `MarkdownImageSavingHandler` geri çağrısı, [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) nesnesini, onun [ImageFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imageformat/) değerini ve oluşturulan Markdown bağlantısını tek elemanlı `String[]` parametresi olarak alır. Görüntüyü verilen formatta kaydedin veya yükleyin ve `link[0]` öğesini Markdown çıktısında görünmesi gereken referansla değiştirin.

SVG formatında üretilen kaynaklar ayrı şekilde işlenir. [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) yöntemiyle bir geri çağrı kaydedin. `MarkdownSvgImageSavingHandler` geri çağrısı bir [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) nesnesi ve tek elemanlı `String[] link` parametresini alır. SVG'nin bir `ImageFormat` argümanı yoktur; bunun yerine XML verisini [ISvgImage.getSvgData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) yönteminden yazar veya yüklersiniz. Dışa aktarma modu ve görsel gruplanmasına bağlı olarak, kaynak sunumdaki bir SVG rasterleştirilebilir veya diğer içerikle birleştirilebilir; ortaya çıkan SVG olmayan kaynak daha sonra görüntü kaydetme geri çağrısına iletilir. Her dışa aktarılan görsel kaynağın özelleştirilmiş işlem gerektirdiği durumlarda her iki geri çağırıyı da kaydedin.

İşleyicinin dönüş değeri, görüntüyü kimin işleyeceğini belirler:

- İşleyici görüntüyü kaydettikten, yükledikten, dönüştürdükten veya başka bir şekilde işledikten ve `link[0]`'a geçerli bir değer atadıktan sonra `true` döndürün. Aspose.Slides bu değeri Markdown belgesine yazar ve varsayılan yerel kaydetme işlemini yapmaz.
- Aspose.Slides'in görüntüyü yerel olarak kaydetmesini ve bağlantıyı [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) ve [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) ile ayarlanan değerlere göre oluşturmasını sağlamak için `false` döndürün.

{{% alert color="warning" title="Önemli" %}}
`true` döndüren bir işleyici, görüntünün sorumluluğunu alır. Geçerli ve boş olmayan bir bağlantı atamadan `true` döndürürse, dışa aktarma `InvalidOperationException` hatasıyla başarısız olur.
{{% /alert %}}

### **Görüntüleri CDN Kaynak Dizinine Kaydedin ve Dış URL'ler Kullanın**

Aşağıdaki örnek `cdn-origin/presentations/quarterly-report` dizinini monte edilmiş veya senkronize bir CDN kaynak dizini olarak ele alır. Her işleyici oluşturulan dosya adını alır, görüntüyü bu özel dizine kaydeder ve oluşturulan yerel referansı genel bir CDN URL'siyle değiştirir. Örnek kendisi ağ üzerinden bir yükleme yapmaz: URL, dizin CDN kaynağı olarak monte edildikten veya dosyaları CDN'ye yayınlandıktan sonra geçerli olur. Nesne depolama için, dosya sistemi yazma işlemini depolama SDK'sının yükleme işlemiyle değiştirin ve yalnızca yükleme başarılı olduğunda `link[0]` atayın.

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

Bitmap işleyicisi, 128 × 128 pikselden küçük görüntüler için bilinçli olarak `false` döndürür, bu nedenle Aspose.Slides bu görüntüleri varsayılan davranışı kullanarak `output/fallback-images` dizinine kaydeder. Daha büyük bitmap ve metafile kaynakları, ayrıca SVG kaynakları, özel kod tarafından işlenir. Örneğin, `fallback-images/image1.png` gibi bir yerel referans `https://cdn.example.com/presentations/quarterly-report/image1.png` haline gelir. İşleyiciler dosya yazarken yalnızca işletim sistemi yollarını kullanır; Markdown'a yazılan bağlantılar ise ileri eğik çizgi ve URL kodlu dosya adları kullanır. Göreli bağlantılar oluştururken aynı kuralı uygulayın: platforma özgü dizin ayırıcı yerine `/` kullanın.

## **SSS**

**Bir işleyici hem raster hem de SVG görüntülerini işleyebilir mi?**

Hayır. Markdown dışa aktarımı sırasında üretilen bitmap ve metafile kaynakları için [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) kullanın ve SVG olarak üretilen kaynaklar için [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) kullanın. İlk yöntem bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) nesnesi ve bir [ImageFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imageformat/) değeri sağlar; ikincisi ise SVG verisi [ISvgImage.getSvgData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) ile okunabilen bir [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) nesnesi sağlar. Dışa aktarma sırasında rasterleştirilen bir kaynak SVG, görüntü kaydetme geri çağrısı tarafından işlenir.

**Bir görüntü kaydetme işleyicisi `false` döndürdüğünde ne olur?**

Aspose.Slides varsayılan yerel kaydetme davranışını kullanır. Görüntü konumu ve oluşturulan referans, [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) ve [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/tr/java/com.aspose.slides/markdownsaveoptions/) ile ayarlanan değerler tarafından kontrol edilir.

**Bir işleyici yerel olarak görüntüyü kaydetmeden bir URL sağlayabilir mi?**

Evet. İşleyici görüntüyü nesne depolamaya yükleyebilir veya başka bir hizmete gönderebilir, ortaya çıkan URL'yi `link[0]`'a atayabilir ve `true` döndürebilir. İşleyicinin işlemi kendisi tamamlamalıdır; `true` döndürmek varsayılan yerel kaydetmeyi engeller.

**Markdown dışa aktarımı bir işleyiciden neden `InvalidOperationException` hatası fırlatır?**

Bu istisna, işleyicinin `true` döndürdüğü ancak geçerli bir bağlantı sağlamadığı durumlarda ortaya çıkar. `true` döndürmeden önce Markdown'a yazılması gereken göreli yolu veya harici URL'yi `link[0]`'a atayın.

**Görüntü bağlantılarında hangi yol ayırıcı kullanılmalı?**

Markdown bağlantılarında ve URL'lerde ileri eğik çizgi (`/`) kullanın. `Path.resolve`'ı yalnızca dosya sistemi yolları için kullanın, ardından Markdown referansını ayrı olarak oluşturun veya normalleştirin.

**Markdown dışa aktarımı sırasında bağlantılar korunur mu?**

Evet. Metin [hyperlinks](/slides/tr/java/manage-hyperlinks/) standart Markdown bağlantıları olarak korunur. Slayt [transitions](/slides/tr/java/slide-transition/) ve [animations](/slides/tr/java/powerpoint-animation/) dönüştürülmez.

**Sunumlar paralel olarak Markdown'a dönüştürülebilir mi?**

Farklı sunum dosyalarını paralel olarak işleyebilirsiniz, ancak aynı [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneğini thread'ler arasında paylaşmayın. [multithreading guidelines](/slides/tr/java/multithreading/) izleyin ve her dosya için ayrı bir örnek kullanın.