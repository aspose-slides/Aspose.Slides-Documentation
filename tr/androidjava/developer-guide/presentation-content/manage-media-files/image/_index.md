---
title: Android'de Sunumlarda Görüntü Yönetimini Optimize Etme
linktitle: Görüntüleri Yönet
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
- bağlantılı SVG görüntüleri
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
description: "PowerPoint ve OpenDocument'te görüntü yönetimini, Android için Java aracılığıyla Aspose.Slides ile kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Resimler sunumları daha etkileyici ve görsel olarak çekici kılar. Microsoft PowerPoint'te, dosyalardan, internetten veya diğer kaynaklardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides birçok şekilde sunum slaytlarına resim eklemenizi sağlar.

{{% alert  title="İpucu" color="info" %}} 

Aspose, görüntülerden hızlı bir şekilde sunum oluşturmanıza olanak tanıyan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 

{{% /alert %}} 

{{% alert title="Bilgi" color="info" %}}

Bir resmi resim çerçevesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırmayı, efekt uygulamayı veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](/slides/tr/androidjava/picture-frame/) bölümüne bakın. 

{{% /alert %}} 

{{% alert title="Not" color="warning" %}}

Bir resmi bir formattan başka bir formata dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: [image to JPG](https://products.aspose.com/slides/tr/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/tr/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/tr/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/tr/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/tr/androidjava/conversion/png-to-svg/), ve [SVG to PNG](https://products.aspose.com/slides/tr/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler formatlardaki görüntüleri destekler. 

## **Yerel Olarak Depolanan Resimleri Slaytlara Ekleyin**

Bilgisayarınızda depolanan bir veya daha fazla resmi bir sunum slaytına ekleyebilirsiniz. Aşağıdaki Java örnek kodu bir resmin slayta nasıl ekleneceğini gösterir:

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

## **Web'den Slaytlara Resim Ekleme**

Slayta eklemek istediğiniz resim bilgisayarınızda depolanmamışsa, doğrudan web üzerinden ekleyebilirsiniz. 

Aşağıdaki Java örnek kodu web üzerindeki bir resmin slayta nasıl ekleneceğini gösterir:

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

## **Resimleri Ana Slayta Ekleyin**

Bir slayt ustası, teması ve düzeni gibi bilgileri depolar ve bu ustayı kullanan slaytları kontrol eder. Bir resmi bir slayt ustasına eklediğinizde, resim o ustaya dayalı tüm slaytlarda görünür. 

Aşağıdaki Java örnek kodu bir slayt ustasına nasıl resim ekleneceğini gösterir:

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

## **Resimleri Slayt Arka Planı Olarak Ekleyin**

Bir veya birden fazla slaytın arka planı olarak bir resim kullanabilirsiniz. Ayrıntılar için *[Setting Images as Backgrounds for Slides](/slides/tr/androidjava/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın.

## **Sunumlara SVG Ekleme**

SVG içeriği, [SvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgimage/) sınıfı kullanılarak bir sunuma eklenebilir. Ortaya çıkan [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) nesnesi daha sonra sunumun resim koleksiyonuna eklenebilir ve bir resim çerçevesi oluşturmak için kullanılabilir.

Aşağıdaki Java örneği bağımsız bir SVG dizesi içe aktarır. Bu SVG tarafından kullanılan tüm görüntüler, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülüdür.

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

## **Harici Kaynaklarla SVG İçeriği İçe Aktarma**

Tasarım araçları, diyagram editörleri, ikon sistemleri ve web işlem hatlarından dışa aktarılan SVG dosyaları, SVG belgesi dışında depolanan kaynaklara referans verebilir. Örneğin bir SVG `images/photo.png` gibi bir resim bağlantısı, bir CSS `url(...)` değeri veya bir yazı tipi URL'si içerebilir. 

Böyle bir SVG içeriğini içe aktarmak için bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iexternalresourceresolver/) uygulaması oluşturun ve uygun bir [SvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgimage/) yapıcısına, temel URI ile birlikte geçirin. Temel URI, SVG belgesinin konumunu belirler ve göreli bağlantıların çözülmesinde kullanılır. 

[ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgimage/) arabirimi, içe aktarılan SVG hakkında aşağıdaki bilgileri sağlar:

- `getSvgContent()` SVG işaretlemesini bir dize olarak döndürür. 
- `getSvgData()` SVG içeriğini bayt dizisi olarak döndürür. 
- `getBaseUri()` göreli bağlantılar için kullanılan temel URI'yi döndürür. 
- `getExternalResourceResolver()` SVG görüntüsüne atanan çözücüyü döndürür. 

### **Harici Kaynak Çözücüsü Uygulama**

Çözücünün iki yöntemi vardır:

- `resolveUri` temel URI ile göreli kaynak bağlantısını birleştirir ve mutlak bir URI döndürür. Bağlantı çözülemezse veya izin verilmiyorsa `null` döndürün. 
- `getEntity` mutlak bir kaynak URI'si için okunabilir bir akış döndürür. Kaynak eksik, engelli veya kullanılamıyorsa `null` döndürün. Uygun olduğunda bir yedek akış da döndürülebilir. 

Aşağıdaki çözücü yalnızca izin verilen yerel dizinden bağlantılı kaynakları yükler. Ağ kaynakları ve izin verilen dizin dışındaki yollar engellenir. Çözülmemiş resim bağlantıları için isteğe bağlı bir yedek resim döndürülür.

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

            // Bu çözücü, yalnızca yerel dosyalara izin vermek üzere kasıtlı olarak tasarlanmıştır.
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

            // Yedek yalnızca görüntü kaynakları için kullanılmalıdır. Görüntü akışı döndürmek
            // eksik bir yazı tipi veya stil sayfası için geçerli olmayacaktır.
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

### **SVG İçe Aktarımında Bağlantılı Kaynakları Çözümleme**

`assets/diagram.svg` dosyasının aşağıdaki gibi bir göreli referans içerdiğini varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki Java örneği SVG dosyası URI'sını temel URI olarak geçirir ve özel bir çözücü sağlar. Çözücü, göreli resim bağlantısını mutlak bir URI'ye dönüştürür ve Aspose.Slides SVG'yi işlerken bağlantılı kaynağı içeren bir akış döndürür.

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

// ISvgImage, kaynak içeriği, ikili veri, base URI ve çözücüyü sunar.
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

`SvgImage` sınıfı ayrıca SVG verisini bayt dizisi veya giriş akışı olarak kabul eden, harici kaynak çözücüsü ve temel URI alan aşırı yüklemeler sunar.

{{% alert title="Önemli" color="warning" %}}

Kaynak çözücü, Aspose.Slides SVG'yi işler ve oluştururken harici kaynakların kullanılmasını sağlar. Orijinal SVG işaretlemesini değiştirmez veya çözülen kaynakları otomatik olarak içine gömme işlemini yapmaz. 

Bir `ISvgImage` sunumun resim koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de bir raster yedek resim içerebilir. Bağlantılı bir kaynak, oluşturulan yedek resimde görünebilirken, `images/photo.png` gibi bir göreli bağlantı depolanan SVG içinde değişmeden kalır. Yerel SVG temsiliyi işleyen bir uygulama, dış kaynak mevcut değilse bağlantılı içeriği atlayabilir. 

{{% /alert %}}

### **Taşınabilir SVG Resmi Oluşturma**

Harici dosyalara bağlı olmayan bir SVG resmi oluşturmak için, `SvgImage` oluşturmadan önce SVG'yi kendi içinde bağımsız hâle getirin. Örneğin, bağlantılı resim URL'lerini resim verisini içeren `data:` URI'leriyle değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Gerekli tüm kaynaklar SVG içeriğine gömüldükten sonra `SvgImage` oluşturun, sunumun resim koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir resim çerçevesine yerleştirin.

### **Eksik veya Engellenmiş Kaynakları İşleme**

`resolveUri` metodundan, kaynak URI geçersiz, yasak veya çözülemezse `null` döndürün. `getEntity` metodundan da kaynak okunamıyorsa `null` döndürün. Aspose.Slides, mümkün olduğunda bu kaynak olmadan SVG'yi işlemeye devam eder. 

Bir eksik kaynak için yedek bir akış döndürülebilir, ancak içeriği istenen kaynak türüyle uyumlu olmalıdır. Örneğin, yalnızca eksik bir resim için bir resim akışı döndürün; bir yazı tipi veya stil sayfası için değil. 

{{% alert title="Güvenlik" color="warning" %}}

Güvenilmeyen SVG dosyalarından rastgele dosya yolları veya kısıtlamasız ağ URL'leri çözülmemelidir. İzin verilen şemaları, dizinleri ve ana makineleri sınırlayın. Ağ kaynakları için bağlantı zaman aşımı, yanıt boyutu sınırları ve içerik doğrulaması uygulayın. 

{{% /alert %}}

## **SVG'yi Şekil Setine Dönüştürme**

Aspose.Slides, bir SVG'yi PowerPoint'teki karşılık gelen işlevselliğe benzer şekilde bir şekil setine dönüştürebilir:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, bir [ISvgImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISvgImage) nesnesini ilk parametre olarak alan [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) arabiriminin [addGroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metodunun bir aşırı yüklemesi tarafından sağlanır. 

Aşağıdaki Java örnek kodu bu metodu kullanarak bir SVG dosyasını şekil setine nasıl dönüştüreceğinizi gösterir:

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

    // Sunumu PPTX formatında kaydet.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Resimleri EMF Olarak Slaytlara Ekleyin**

Aspose.Slides for Android via Java, Aspose.Cells ile Excel çalışma sayfalarından EMF resimleri oluşturmanıza ve bunları sunum slaytlarına eklemenize olanak tanır.

Aşağıdaki Java örnek kodu bunu nasıl yapacağınızı gösterir:

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

        // Dosyayı olduğu gibi ekleyin, böylece resim rasterleştirilmek yerine vektörel EMF olarak kalır.
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

## **Resim Koleksiyonundaki Görüntüleri Değiştirme**

Aspose.Slides, bir sunumun resim koleksiyonunda depolanan görüntüleri, slayt şekilleri tarafından kullanılan görüntüler dahil, değiştirmenizi sağlar. Bu bölüm, koleksiyondaki görüntüleri güncellemenin birkaç yolunu açıklar. Bir görüntüyü ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) örneği veya koleksiyonda zaten var olan başka bir görüntü kullanarak değiştirebilirsiniz. 

Aşağıdaki adımları izleyin:

1. Görüntü içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfını kullanarak yükleyin. 
1. Yeni bir resmi dosyadan bayt dizisine yükleyin. 
1. Hedef resmi, yeni resimle bayt dizisini kullanarak değiştirin. 
1. İkinci yöntemde, resmi bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesine yükleyin ve hedef resmi bu nesneyle değiştirin. 
1. Üçüncü yöntemde, hedef resmi sunumun resim koleksiyonunda zaten var olan bir resimle değiştirin. 
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin. 

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("sample.pptx");
try {
    // İlk yöntem.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // İkinci yöntem.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Üçüncü yöntem.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Sunumu bir dosyaya kaydedin.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Bilgi" color="info" %}}

Aspose'un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü ile metni kolayca canlandırabilir ve metinden GIF'ler oluşturabilirsiniz. 

{{% /alert %}}

## **SSS**

**Ekleme sonrasında orijinal resim çözünürlüğü bozulur mu?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm resmin slayt üzerindeki [picture](/slides/tr/androidjava/picture-frame/) ölçeklendirilme şekline ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır. 

**Yüzlerce slaytta aynı logoyu aynı anda değiştirmek için en iyi yol nedir?**

Logoyu ana slayta veya bir düzene yerleştirin ve sunumun resim koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır. 

**Eklenen SVG, düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. SVG'yi bir şekil grubuna dönüştürebilir, ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir. 

**Bir resmi birden fazla slaytın arka planı olarak aynı anda nasıl ayarlayabilirim?**

Resmi ana slayta veya ilgili düzene arka plan olarak atayın; o ana/slayt düzenini kullanan tüm slaytlar arka planı miras alır. 

**Bir sunum, çok sayıda resim nedeniyle çok büyük olmasını nasıl önleyebilirim?**

Tek bir resim kaynağını tekrar tekrar kullanın, makul çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve gerektiğinde grafikleri ana slayta taşıyarak tekrarı azaltın.