---
title: Java Kullanarak Sunumlarda Görüntü Yönetimini Optimize Edin
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/java/image/
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
- SVG fontları
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument'te görüntü yönetimini kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha etkileyici ve görsel açıdan çekici hâle getirir. Microsoft PowerPoint’te, dosyalardan, internetten veya diğer kaynaklardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides, sunum slaytlarına görüntü eklemenize çeşitli yollar sunar.

{{% alert  title="Tip" color="primary" %}} 

Aspose, görüntülerden hızlı bir şekilde sunum oluşturmanıza olanak tanıyan ücretsiz dönüştürücüler—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Bir resmi fotoğraf çerçevesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırmayı, efekt eklemeyi veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Resim Çerçevesi](/slides/tr/java/picture-frame/) sayfasına bakın. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Görüntüleri bir formattan diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: [görüntüyü JPG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/), [JPG'yi görüntüye dönüştür](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/), [JPG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/), [PNG'yi JPG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/), [PNG'yi SVG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/), ve [SVG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF ve diğer popüler formatlardaki görüntüleri destekler. 

## **Yerel Olarak Depolanan Görüntüleri Slaytlara Ekleyin**

Bilgisayarınızda depolanan bir veya daha fazla görüntüyü bir sunum slaytına ekleyebilirsiniz. Aşağıdaki Java örnek kodu, bir görüntünün slayta nasıl ekleneceğini gösterir:

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

## **Web'den Görüntüleri Slaytlara Ekleyin**

Eklenecek görüntü bilgisayarınızda depolanmamışsa, doğrudan web üzerinden ekleyebilirsiniz. 

Aşağıdaki Java örnek kodu, web'den bir görüntünün slayta nasıl ekleneceğini gösterir:

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

## **Görselleri Slayt Master'ına Ekleyin**

Bir slayt master'ı, onu kullanan slaytların teması ve düzeni gibi bilgileri depolar ve kontrol eder. Bir görüntüyü slayt master'ına eklediğinizde, bu görüntü o master'a dayanan her slaytta görünür. 

Aşağıdaki Java örnek kodu, bir slayt master'ına nasıl görüntü ekleneceğini gösterir:

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

Bir veya daha fazla slayt için arka plan olarak bir resim kullanabilirsiniz. Ayrıntılar için *[Slaytlar için Arka Plan Olarak Görüntü Ayarlama](/slides/tr/java/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın.

## **Sunumlara SVG Ekleyin**

SVG içeriği, [SvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgimage/) sınıfı kullanılarak bir sunuma eklenebilir. Oluşan [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) nesnesi daha sonra sunumun görüntü koleksiyonuna eklenebilir ve bir fotoğraf çerçevesi oluşturmak için kullanılabilir.

Aşağıdaki Java örneği, kendi içinde bütünleşik bir SVG dizesini içe aktarır. Bu SVG tarafından kullanılan tüm görüntüler, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülüdür.

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

## **Harici Kaynaklarla SVG İçeriği İçe Aktarın**

Tasarım araçları, diyagram editörleri, simge sistemleri ve web boru hatlarından dışa aktarılan SVG dosyaları, SVG belgesi dışında depolanan kaynaklara referans verebilir. Örneğin, bir SVG şu şekilde bir görüntü bağlantısı içerebilir: `images/photo.png`, bir CSS `url(...)` değeri veya bir font URL'si.

Böyle bir SVG içeriğini içe aktarmak için bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iexternalresourceresolver/) uygulaması oluşturun ve temel URI ile birlikte uygun bir [SvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgimage/) yapıcısına geçirin. Temel URI, SVG belgesinin konumunu belirler ve relatif bağlantıların çözümlenmesinde kullanılır.

[ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) arayüzü, içe aktarılan SVG hakkında bilgiye erişim sağlar:

- `getSvgContent()` SVG işaretlemesini bir dize olarak döndürür.
- `getSvgData()` SVG içeriğini bir bayt dizisi olarak döndürür.
- `getBaseUri()` relatif bağlantılar için kullanılan temel URI'yi döndürür.
- `getExternalResourceResolver()` SVG görüntüsüne atanmış çözücüyü döndürür.

### **Harici Kaynak Çözücüsü Uygulayın**

Çözücünün iki yöntemi vardır:

- `resolveUri` temel URI ile relatif kaynak bağlantısını birleştirir ve mutlak bir URI döndürür. Bağlantı çözülemezse veya izin verilmiyorsa `null` döndürülür.
- `getEntity` mutlak bir kaynak URI için okunabilir bir akış döndürür. Kaynak eksik, engellenmiş veya erişilemezse `null` döndürülür. Uygun olduğunda bir yedek akış da döndürülebilir.

Aşağıdaki çözücü, yalnızca izin verilen yerel bir dizinden bağlantılı kaynakları yükler. Ağ kaynakları ve izin verilen dizin dışındaki yollar engellenir. Çözülmemiş görüntü bağlantıları için isteğe bağlı bir yedek görüntü döndürülür.

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

            // Yalnızca görüntü kaynakları için bir yedek kullanın. Bir görüntü akışı döndürmek
            // eksik bir font veya stil sayfası için geçerli olmaz.
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

### **SVG İçe Aktarımı Sırasında Bağlantılı Kaynakları Çözün**

`assets/diagram.svg` dosyasının şu şekilde bir relatif referans içerdiğini varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki Java örneği, SVG dosya URI'sını temel URI olarak aktarır ve özel bir çözücü sağlar. Çözücü, relatif görüntü bağlantısını mutlak bir URI'ye dönüştürür ve Aspose.Slides SVG'yi işlerken bağlantılı kaynağı içeren bir akış döndürür.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Temel URI, SVG belgesinin konumunu temsil eder.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage, kaynak içeriği, ikili veri, temel URI ve çözücüyü ortaya çıkarır.
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

`SvgImage` sınıfı ayrıca SVG verilerini bir bayt dizisi veya bir giriş akışı olarak kabul eden, harici kaynak çözücüsü ve temel URI ile birlikte kullanılan aşırı yüklemeler de sunar.

{{% alert title="Important" color="warning" %}}

Kaynak çözücü, Aspose.Slides SVG'yi işler ve render ederken harici kaynakların kullanılabilir olmasını sağlar. Orijinal SVG işaretlemesini değiştirmez ve çözülen kaynakları otomatik olarak içine gömme işlemini yapmaz.

Bir `ISvgImage` sunumun görüntü koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de bir raster yedek görüntü içerebilir. Bağlantılı bir kaynak, oluşturulan yedek görüntüde görünebilir; `images/photo.png` gibi bir relatif bağlantı ise depolanan SVG'de değişmeden kalır. Yerel SVG temsiliyle render yapan bir uygulama, dış kaynak mevcut değilse bağlantılı içeriği atlayabilir.

{{% /alert %}}

### **Taşınabilir Bir SVG Resmi Oluşturun**

Harici dosyalara bağımlı olmayan bir SVG resmi oluşturmak için, `SvgImage` oluşturmadan önce SVG'yi kendi içinde bütünleşik hâle getirin. Örneğin, bağlanmış görüntü URL'lerini görüntü verisini içeren `data:` URI'leriyle değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Gerekli tüm kaynaklar SVG içeriğine gömüldükten sonra `SvgImage` oluşturun, sunumun görüntü koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir fotoğraf çerçevesine yerleştirin.

### **Eksik veya Engellenen Kaynakları Ele Alın**

Bir kaynak URI'si geçersiz, yasak veya çözülemez olduğunda `resolveUri` metodundan `null` döndürün. Kaynak okunamazsa `getEntity` metodundan `null` döndürün. Aspose.Slides mümkün olduğunca bu kaynağı olmadan SVG'yi işlemeye devam eder.

Eksik bir kaynak için bir yedek akış döndürülebilir, ancak içeriği istenen kaynak türüyle uyumlu olmalıdır. Örneğin, yalnızca eksik bir görüntü için bir görüntü akışı döndürün; bir font ya da stil sayfası için döndürmeyin.

{{% alert title="Security" color="warning" %}}

Güvenilmeyen SVG dosyalarından keyfi dosya yollarını veya kısıtlamasız ağ URL'lerini çözümlemeyin. İzin verilen şemaları, dizinleri ve hostları sınırlayın. Ağ kaynakları için bağlantı zaman aşımı, yanıt boyutu sınırlamaları ve içerik doğrulaması uygulayın.

{{% /alert %}}

## **SVG'yi Şekil Setine Dönüştürün**

Aspose.Slides, SVG'yi PowerPoint'teki karşılık gelen işlevselliğe benzer şekilde bir şekil setine dönüştürebilir:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, bir [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISvgImage) nesnesini ilk parametre olarak alan [addGroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metodunun bir aşırı yüklemesi tarafından sağlanır.

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
    // SVG dosya içeriğini oku.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Bir SvgImage nesnesi oluştur.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Slayt boyutunu al.
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

## **Görselleri EMF Olarak Slaytlara Ekleyin**

Aspose.Slides for Java, Aspose.Cells ile Excel çalışma sayfalarından EMF görüntüleri oluşturmanıza ve bunları sunum slaytlarına eklemenize olanak tanır.

Aşağıdaki Java örnek kodu, bunu nasıl yapacağınızı gösterir:

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

        // Dosyayı olduğu gibi ekleyin, böylece resim rasterleştirilmeden vektör EMF olarak kalır.
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

## **Görüntü Koleksiyonundaki Görselleri Değiştirin**

Aspose.Slides, bir sunumun görüntü koleksiyonunda depolanan görselleri, slayt şekilleri tarafından kullanılan görseller de dahil olmak üzere değiştirme imkanı verir. Bu bölüm, koleksiyondaki görselleri güncellemenin çeşitli yollarını açıklamaktadır. Bir görseli ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut olan başka bir görsel kullanarak değiştirebilirsiniz.

Aşağıdaki adımları izleyin:

1. Görseller içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin.
2. Yeni bir görseli bir dosyadan bayt dizisine yükleyin.
3. Hedef görseli yeni görsel ile bayt dizisi üzerinden değiştirin.
4. İkinci yöntemde, görseli bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) nesnesine yükleyin ve hedef görseli bu nesneyle değiştirin.
5. Üçüncü yöntemde, hedef görseli sunumun görüntü koleksiyonunda zaten mevcut olan bir görsel ile değiştirin.
6. Değiştirilen sunumu bir PPTX dosyası olarak yazın.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Sunum dosyasını temsil eden Presentation sınıfını örnekle.
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

    // Sunumu bir dosyaya kaydet.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose'un ücretsiz [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü ile metni kolayca canlandırabilir ve metinden GIF'ler oluşturabilirsiniz. 

{{% /alert %}}

## **SSS**

**Ekleme işleminden sonra orijinal görüntü çözünürlüğü korunur mu?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm, slayttaki [picture](/slides/tr/java/picture-frame/) ölçeklendirmesine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Onlarca slaytta aynı logoyu bir kerede değiştirmek için en iyi yöntem nedir?**

Logoyu master slayta ya da bir yerleşime yerleştirip, sunumun görüntü koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. SVG'yi bir şekil grubuna dönüştürebilir, ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Birden fazla slayt için aynı resmi arka plan olarak nasıl ayarlayabilirim?**

[Resmi arka plan olarak ata](/slides/tr/java/presentation-background/) master slaytta ya da ilgili yerleşimde—bu master/yerleşimi kullanan tüm slaytlar arka planı devralır.

**Çok sayıda resim nedeniyle sunumun aşırı büyük olmasını nasıl önleyebilirim?**

Tek bir görüntü kaynağını tekrar kullanın, makul çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve tekrarlanan grafik öğelerini mümkün olduğunca master'da tutun.