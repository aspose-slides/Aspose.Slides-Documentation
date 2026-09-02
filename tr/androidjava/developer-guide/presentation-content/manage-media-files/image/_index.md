---
title: Android'de Sunumlarda Görüntü Yönetimini Optimize Edin
linktitle: Görselleri Yönetin
type: docs
weight: 10
url: /tr/androidjava/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görsel değiştir
- resim değiştir
- web'den
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- harici SVG kaynakları
- SVG çözücü
- bağlı SVG görüntüleri
- SVG yazı tipleri
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument içinde görüntü yönetimini basitleştirin, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha çekici ve görsel olarak etkileyici hâle getirir. Microsoft PowerPoint’te, dosyalardan, internetten veya diğer kaynaklardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides, sunum slaytlarına çeşitli yollarla resim eklemenizi sağlar.

{{% alert  title="Tip" color="primary" %}} 
Aspose, görüntülerden hızlıca sunumlar oluşturmanızı sağlayan ücretsiz dönüştürücüler sunar—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt).
{{% /alert %}} 

{{% alert title="Bilgi" color="info" %}}
Bir resmi resim çerçevesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırma, efekt uygulama veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](/slides/tr/androidjava/picture-frame/) bölümüne bakın.
{{% /alert %}} 

{{% alert title="Not" color="warning" %}}
Görselleri bir biçimden diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: [image to JPG](https://products.aspose.com/slides/tr/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/tr/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/tr/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/tr/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/tr/androidjava/conversion/png-to-svg/), ve [SVG to PNG](https://products.aspose.com/slides/tr/androidjava/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler biçimler dahil olmak üzere çeşitli görüntü formatlarını destekler. 

## **Yerel Olarak Depolanan Görselleri Slaytlara Ekleyin**

Bilgisayarınızda depolanan bir veya daha fazla görseli sunum slaytına ekleyebilirsiniz. Aşağıdaki Java örnek kodu, bir görselin slayta nasıl ekleneceğini gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Web’den Görselleri Slaytlara Ekleyin**

Slayta eklemek istediğiniz görsel bilgisayarınızda depolanmamışsa, doğrudan web’den ekleyebilirsiniz. 

Aşağıdaki Java örnek kodu, web’den bir görselin slayta nasıl ekleneceğini gösterir:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Görselleri Slayt Üstatlarına Ekleyin**

Bir slayt üstadı, onu kullanan slaytların tema ve düzeni gibi bilgileri depolar ve kontrol eder. Bir görseli slayt üstadına eklediğinizde, o görsel üstadı temel alan tüm slaytlarda görünür. 

Aşağıdaki Java örnek kodu, bir görselin slayt üstadına nasıl ekleneceğini gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Görselleri Slayt Arka Planı Olarak Ekleyin**

Bir veya birden fazla slayt için arka plan olarak bir resim kullanabilirsiniz. Ayrıntılar için *[Setting Images as Backgrounds for Slides](/slides/tr/androidjava/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın.

## **SVG’yi Sunumlara Ekleyin**

SVG içeriği, [SvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgimage/) sınıfı kullanılarak bir sunuma eklenebilir. Ortaya çıkan [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) nesnesi daha sonra sunumun görüntü koleksiyonuna eklenebilir ve bir resim çerçevesi oluşturmak için kullanılabilir.

Aşağıdaki Java örneği, bağımsız bir SVG dizesini içe aktarır. Bu SVG tarafından kullanılan tüm görüntüler, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülüdür.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Harici Kaynaklı SVG İçeriğini İçe Aktarın**

Tasarım araçları, diyagram editörleri, ikon sistemleri ve web işlem hatlarından dışa aktarılan SVG dosyaları, SVG belgesi dışındaki kaynaklara referanslar içerebilir. Örneğin, bir SVG `images/photo.png` gibi bir resim bağlantısı, bir CSS `url(...)` değeri veya bir yazı tipi URL’si içerebilir.

Bu tür SVG içeriğini içe aktarmak için bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iexternalresourceresolver/) uygulaması oluşturun ve uygun bir [SvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgimage/) kurucusuna temel URI ile birlikte iletin. Temel URI, SVG belgesinin konumunu belirler ve göreli bağlantıların çözülmesinde kullanılır.

[ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) arayüzü, içe aktarılan SVG hakkında bilgiye erişim sağlar:

- `getSvgContent()` SVG işaretlemesini bir dize olarak döndürür.
- `getSvgData()` SVG içeriğini bir bayt dizisi olarak döndürür.
- `getBaseUri()` göreli bağlantılar için kullanılan temel URI’yi döndürür.
- `getExternalResourceResolver()` SVG görüntüsüne atanmış çözücüyü döndürür.

### **Harici Kaynak Çözücüsü Uygulayın**

Çözücünün iki yöntemi vardır:

- `resolveUri` temel URI ile göreli kaynak bağlantısını birleştirir ve mutlak bir URI döndürür. Bağlantı çözülemezse veya izin verilmiyorsa `null` döndürün.
- `getEntity` mutlak bir kaynak URI’si için okunabilir bir akış döndürür. Kaynak eksik, engellenmiş veya erişilemezse `null` döndürün. Uygun olduğunda bir yedek akış da döndürülebilir.

Aşağıdaki çözücü, yalnızca izin verilen yerel bir dizinden bağlanan kaynakları yükler. Ağ kaynakları ve izin verilen dizinin dışındaki yollar engellenir. Çözülmemiş resim bağlantıları için isteğe bağlı bir yedek resim döndürülür.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Bu çözücü kasıtlı olarak yalnızca yerel dosyalara izin verir.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Yedek yalnızca resim kaynakları için kullanılmalıdır. Eksik bir yazı tipi
            // veya stil sayfası için bir resim akışı döndürmek geçerli olmaz.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **SVG İçe Aktarımında Bağlı Kaynakları Çözümleyin**

`assets/diagram.svg` dosyasının aşağıdaki gibi bir göreli referans içerdiğini varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki Java örneği, SVG dosyası URI’sini temel URI olarak geçirir ve özel bir çözücü sağlar. Çözücü, göreli resim bağlantısını mutlak bir URI’ye dönüştürür ve Aspose.Slides SVG’i işlerken bağlı kaynağı içeren bir akış döndürür.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Base URI, SVG belgesinin konumunu temsil eder.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage, kaynak içeriği, ikili veri, base URI ve çözücüyü ortaya çıkarır.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` sınıfı ayrıca, SVG verisini bir bayt dizisi veya bir giriş akışı olarak kabul eden, dış kaynak çözücüsü ve temel URI ile birlikte ek yüklemeler (overloads) sunar.

{{% alert title="Önemli" color="warning" %}}
Kaynak çözücüsü, Aspose.Slides SVG’i işler ve render ederken harici kaynakları kullanılabilir hâle getirir. Orijinal SVG işaretlemesini değiştirmez veya çözülmüş kaynakları otomatik olarak içine gömme işlemini gerçekleştirmez.

Bir `ISvgImage` sunumun görüntü koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de raster bir yedek resim içerebilir. Bağlı bir kaynak, oluşturulan yedek resimde yer alabilirken `images/photo.png` gibi bir göreli bağlantı saklanan SVG içinde değişmeden kalır. Yerel SVG temsili render eden bir uygulama, orijinal harici kaynak kullanılamaz olduğunda bağlı içeriği dışarıda bırakabilir.
{{% /alert %}}

### **Taşınabilir Bir SVG Resmi Oluşturun**

Harici dosyalara bağımlı olmayan bir SVG resmi oluşturmak için, `SvgImage` oluşturulmadan önce SVG’yi bağımsız hâle getirin. Örneğin, bağlı resim URL’lerini, görüntü verisini içeren `data:` URI’leriyle değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Gerekli tüm kaynaklar SVG içeriğine gömüldükten sonra `SvgImage` oluşturun, sunumun görüntü koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir resim çerçevesine yerleştirin.

### **Eksik veya Engellenmiş Kaynakları Ele Alın**

`resolveUri` yönteminde, kaynak URI geçersiz, yasaklanmış veya çözülemez ise `null` döndürün. `getEntity` yönteminde, kaynak okunamıyorsa `null` döndürün. Aspose.Slides mümkün olduğunca bu kaynağı olmadan SVG’i işlemeye devam eder.

Eksik bir kaynak için yedek bir akış döndürülebilir, ancak içeriğin talep edilen kaynak türüyle uyumlu olması gerekir. Örneğin, yalnızca eksik bir resim için bir resim akışı döndürün; bir yazı tipi veya stil sayfası için döndürmeyin.

{{% alert title="Güvenlik" color="warning" %}}
Güvenilmeyen SVG dosyalarından rastgele dosya yolları veya sınırsız ağ URL’leri çözülmemelidir. İzin verilen şemalar, dizinler ve hostlar kısıtlanmalıdır. Ağ kaynakları için bağlantı zaman aşımı, yanıt boyutu sınırları ve içerik doğrulaması da uygulanmalıdır.
{{% /alert %}}

## **SVG’yi Şekil Setine Dönüştürün**

Aspose.Slides, bir SVG’yi PowerPoint’teki karşılık gelen işlevselliğe benzer şekilde bir dizi şekle dönüştürebilir:

![PowerPoint Açılır Menü](img_01_01.png)

Bu işlevsellik, `IShapeCollection` arayüzünün `addGroupShape` metodunun bir [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISvgImage) nesnesini ilk parametre olarak almasını sağlayan bir aşırı yüklemesi (overload) aracılığıyla sunulur.

Aşağıdaki Java örnek kodu, bu yöntemi kullanarak bir SVG dosyasını şekil setine nasıl dönüştüreceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Kaynak SVG dosya adı.
String svgFileName = "sample.svg";

// Çıktı sunum dosya adı.
String outPptxPath = "presentation.pptx";

// Yeni bir sunum oluştur.
IPresentation presentation = new Presentation();
try {
    // SVG dosya içeriğini okuyun.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Bir SvgImage nesnesi oluştur.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Slayt boyutunu alın.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG görüntüsünü bir şekil grubuna dönüştür ve slayt boyutuna ölçekle.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Sunumu PPTX formatında kaydedin.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Görselleri EMF Olarak Slaytlara Ekleyin**

Aspose.Slides for Android via Java, Aspose.Cells ile Excel çalışma sayfalarından EMF resimleri oluşturmanıza ve bunları sunum slaytlarına eklemenize olanak tanır.

Aşağıdaki Java örnek kodu bu işlemi göstermektedir:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Çalışma kitabını bir akışa kaydet.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Dosyayı olduğu gibi ekle böylece resim vektörel EMF kalır, rasterize olmaz.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Görselleri Görüntü Koleksiyonunda Değiştirin**

Aspose.Slides, slayt şekilleri tarafından kullanılan görseller de dahil olmak üzere bir sunumun görüntü koleksiyonunda depolanan görselleri değiştirmenize izin verir. Bu bölüm, koleksiyondaki görselleri güncellemenin çeşitli yollarını tanımlar. Bir görseli ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut bir başka görsel kullanarak değiştirebilirsiniz.

Aşağıdaki adımları izleyin:

1. Görselleri içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. Yeni bir görseli dosyadan bir bayt dizisine yükleyin.
3. Hedef görseli, bayt dizisini kullanarak yeni görselle değiştirin.
4. İkinci yöntemde, görseli bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesine yükleyin ve hedef görseli bu nesneyle değiştirin.
5. Üçüncü yöntemde, hedef görseli sunumun görüntü koleksiyonunda zaten var olan bir görselle değiştirin.
6. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
Presentation presentation = new Presentation("sample.pptx");
try {
    // İlk yol.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // İkinci yol.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Üçüncü yol.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Sunumu bir dosyaya kaydet.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Bilgi" color="info" %}}
Aspose’un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü ile metni kolayca canlandırabilir ve metinden GIF’ler oluşturabilirsiniz.
{{% /alert %}}

## **SSS**

**Ekleme işleminden sonra orijinal görüntü çözünürlüğü korunur mu?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm, slayttaki [picture](/slides/tr/androidjava/picture-frame/) ölçeklendirmesi ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu aynı anda değiştirmek için en iyi yol nedir?**

Logoyu ana slayta veya bir düzene yerleştirin ve sunumun görüntü koleksiyonunda değiştirin—değişiklikler bu kaynağı kullanan tüm öğelere yansır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. SVG bir şekil grubuna dönüştürülebilir; ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi birden çok slaytın arka planı olarak aynı anda nasıl ayarlarım?**

Resmi, ana slaytta veya ilgili düzende arka plan olarak atayın—o ana/slayt düzenini kullanan tüm slaytlar arka planı miras alır.

**Bir sunum, çok sayıda resim nedeniyle çok büyük hale gelmesini nasıl önlerim?**

Tek bir görüntü kaynağını tekrar kullanın, makul çözünürlükler seçin, kaydederken sıkıştırma uygulayın ve gerektiğinde grafiklerinizi ana slayta yerleştirerek tekrar etmeyi azaltın.