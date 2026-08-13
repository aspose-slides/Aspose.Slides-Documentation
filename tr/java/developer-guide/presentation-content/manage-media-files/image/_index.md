---
title: Java Kullanarak Sunumlarda Görsel Yönetimini Optimize Et
linktitle: Görselleri Yönet
type: docs
weight: 10
url: /tr/java/image/
keywords:
- görsel ekle
- resim ekle
- bitmap ekle
- görseli değiştir
- resmi değiştir
- web'den
- arkaplan
- PNG ekle
- JPG ekle
- SVG ekle
- dış SVG kaynakları
- SVG çözücü
- bağlantılı SVG görüntüleri
- SVG yazı tipleri
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument'te görsel yönetimini kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller, sunumları daha etkileyici ve görsel olarak çekici hâle getirir. Microsoft PowerPoint’te, dosyalardan, internetteki kaynaklardan veya diğer yollarla slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides, sunum slaytlarına çeşitli yollarla görsel eklemenize imkan tanır.

{{% alert  title="Tip" color="info" %}} 
Aspose, görüntülerden hızlı bir şekilde sunumlar oluşturmanıza olanak tanıyan ücretsiz dönüştürücüler—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Bir resmi resim çerçevesi olarak eklemek istiyorsanız—özellikle yeniden boyutlandırmayı, efekt eklemeyi veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Resim Çerçevesi](/slides/tr/java/picture-frame/) sayfasına bakın. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Resimleri bir biçimden diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: [görüntüyü JPG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/image-to-jpg/), [JPG'yi görüntüye dönüştür](https://products.aspose.com/slides/tr/java/conversion/jpg-to-image/), [JPG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/jpg-to-png/), [PNG'yi JPG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/png-to-jpg/), [PNG'yi SVG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/png-to-svg/), ve [SVG'yi PNG'ye dönüştür](https://products.aspose.com/slides/tr/java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF gibi popüler biçimlerdeki görselleri destekler. 

## **Yerel Olarak Saklanan Görselleri Slaytlara Ekle**

Bilgisayarınızda depolanan bir veya daha fazla görseli bir sunum slaytına ekleyebilirsiniz. Aşağıdaki Java örnek kodu, bir görseli slayta eklemenin nasıl yapılacağını gösterir:

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

## **Web'den Görselleri Slaytlara Ekle**

Ekleyeceğiniz görsel bilgisayarınızda yoksa, doğrudan web üzerinden ekleyebilirsiniz. 

Aşağıdaki Java örnek kodu, web üzerindeki bir görseli slayta eklemenin nasıl yapılacağını gösterir:

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

## **Slayt Ana Şablonlarına Görselleri Ekle**

Bir slayt ana şablonu, onu kullanan slaytların tema ve düzen gibi bilgilerini depolar ve kontrol eder. Bir görseli slayt ana şablonuna eklediğinizde, o görsel ilgili ana şablona bağlı tüm slaytlarda görünür. 

Aşağıdaki Java örnek kodu, bir slayt ana şablonuna görsel eklemenin nasıl yapılacağını gösterir:

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

## **Görselleri Slayt Arka Planı Olarak Ekle**

Bir görseli bir veya birden fazla slaytın arka planı olarak kullanabilirsiniz. Ayrıntılar için *[Slaytlar için Görselleri Arka Plan Olarak Ayarlama](/slides/tr/java/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın. 

## **Sunumlara SVG Ekle**

SVG içeriği, [SvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgimage/) sınıfı kullanılarak bir sunuma eklenebilir. Oluşturulan [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) nesnesi daha sonra sunumun görsel koleksiyonuna eklenir ve bir resim çerçevesi oluşturmak için kullanılabilir. 

Aşağıdaki Java örneği, bağımsız bir SVG dizesi içe aktarır. Bu SVG’de kullanılan tüm görseller, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülüdür.

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

## **Dış Kaynaklı SVG İçeriğini İçe Aktar**

Tasarım araçları, diyagram editörleri, ikon sistemleri ve web işlem hatlarından dışa aktarılan SVG dosyaları, SVG belgesi dışındaki kaynaklara referans içerebilir. Örneğin, bir SVG `images/photo.png` gibi bir görsel bağlantısı, bir CSS `url(...)` değeri veya bir yazı tipi URL’i içerebilir. 

Böyle bir SVG içeriğini içe aktarmak için bir [IExternalResourceResolver](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iexternalresourceresolver/) uygulaması oluşturup, temel URI ile birlikte uygun bir [SvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/svgimage/) yapıcıya iletmelisiniz. Temel URI, SVG belgesinin konumunu tanımlar ve göreceli bağlantıların çözülmesinde kullanılır. 

[ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgimage/) arabirimi, içe aktarılan SVG hakkında bilgi sağlar:

- `getSvgContent()` SVG işaretlemesini bir dize olarak döndürür. 
- `getSvgData()` SVG içeriğini bir bayt dizisi olarak döndürür. 
- `getBaseUri()` göreceli bağlantılar için kullanılan temel URI’yi döndürür. 
- `getExternalResourceResolver()` SVG görüntüsüne atanmış çözümleyiciyi döndürür. 

### **Harici Kaynak Çözümleyicisi Uygula**

Çözümleyicide iki yöntem bulunur:

- `resolveUri` temel URI ile göreceli kaynak bağlantısını birleştirir ve mutlak bir URI döndürür. Bağlantı çözülemezse veya izin verilmiyorsa `null` döndürülür. 
- `getEntity` mutlak bir kaynak URI’si için okunabilir bir akış döndürür. Kaynak eksik, engellenmiş veya kullanılamıyorsa `null` döndürülür. Gerekirse bir yedek akış da döndürülebilir. 

Aşağıdaki çözümleyici, yalnızca izin verilen yerel bir dizinden bağlantılı kaynakları yükler. Ağ kaynakları ve izin verilen dizin dışındaki yollar engellenir. Çözülmeyen görsel bağlantıları için isteğe bağlı bir yedek görsel döndürülür.

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

            // Bu çözümleyici yalnızca yerel dosyalara izin verecek şekilde kasıtlı olarak tasarlanmıştır.
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

            // Yalnızca görsel kaynakları için yedek kullanın. Bir görsel akışı döndürmek
            // eksik bir yazı tipi veya stil sayfası için geçerli olmaz.
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

### **SVG İçe Aktarımı Sırasında Bağlantılı Kaynakları Çöz**

`assets/diagram.svg` dosyasının aşağıdaki gibi bir göreceli referans içerdiğini varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki Java örneği, SVG dosyasının URI’sini temel URI olarak geçirir ve özel bir çözümleyici sağlar. Çözümleyici, göreceli görsel bağlantısını mutlak bir URI’ye dönüştürür ve Aspose.Slides SVG’yi işlerken bağlanmış kaynağı içeren bir akış döndürür.

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

// ISvgImage exposes the source content, binary data, base URI, and resolver.
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

`SvgImage` sınıfı ayrıca, SVG verilerini bir bayt dizisi veya bir giriş akışı olarak kabul edip, dış kaynak çözümleyicisi ve temel URI ile birlikte kullanabileceğiniz aşırı yüklemeler sunar.

{{% alert title="Important" color="warning" %}}
Kaynak çözümleyici, Aspose.Slides SVG’yi işlerken dış kaynakları kullanılabilir hâle getirir. Orijinal SVG işaretlemesini değiştirmez veya çözülen kaynakları otomatik olarak içine gömme işlemi yapmaz. 

Bir `ISvgImage` sunum görsel koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de bir raster yedek görsel içerebilir. Bağlantılı bir kaynak, oluşturulan yedek görselde yer alabilir; ancak `images/photo.png` gibi bir göreceli bağlantı, depolanan SVG’de aynı şekilde kalır. Yerel SVG temsili render eden bir uygulama, dış kaynak mevcut olmadığında bağlı içeriği atlayabilir.
{{% /alert %}}

### **Taşınabilir Bir SVG Resmi Oluştur**

Harici dosyalara bağımlı olmayan bir SVG resmi oluşturmak için `SvgImage` oluşturulmadan önce SVG’yi bağımsız hâle getirin. Örneğin, bağlanmış görsel URL’lerini, görsel verisini içeren `data:` URI’leriyle değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Gerekli tüm kaynaklar SVG içeriğine gömüldükten sonra `SvgImage` oluşturun, sunum görsel koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir resim çerçevesine yerleştirin.

### **Eksik veya Engellenen Kaynakları Ele Al**

`resolveUri` yöntemi, geçersiz, yasaklanmış veya çözülemez bir kaynak URI’siyle karşılaştığında `null` döndürmelidir. `getEntity` yöntemi, kaynağa erişilemediğinde `null` döndürmelidir. Aspose.Slides mümkün olduğunca kaynağı olmadan SVG’yi işlemeye devam eder. 

Eksik bir kaynak için bir yedek akış döndürülebilir, ancak içeriği talep edilen kaynak türüyle uyumlu olmalıdır. Örneğin, yalnızca eksik bir görsel için görsel akışı döndürün; bir yazı tipi veya stil sayfası için bunu yapmayın.

{{% alert title="Security" color="warning" %}}
Güvenilmeyen SVG dosyalarından rastgele dosya yolları veya sınırsız ağ URL’leri çözülmemelidir. İzin verilen şema, dizin ve ana bilgisayarları sınırlayın. Ağ kaynakları için bağlantı zaman aşımı, yanıt boyutu sınırları ve içerik doğrulaması uygulayın.
{{% /alert %}}

## **SVG'yi Şekil Setine Dönüştür**

Aspose.Slides, bir SVG’yi şekil setine dönüştürebilir; bu, PowerPoint’teki eşdeğer işlevselliğe benzer:

![PowerPoint Açılır Menü](img_01_01.png)

Bu işlevsellik, bir [ISvgImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISvgImage) nesnesini ilk bağımsız değişken olarak alan [addGroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metodunun bir aşırı yüklemesi ile sağlanır. 

Aşağıdaki Java örnek kodu, bir SVG dosyasını şekil setine dönüştürmek için bu yöntemin nasıl kullanılacağını gösterir:

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

    // SVG görüntüsünü şekil grubuna dönüştür ve slayt boyutuna ölçekle.
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

## **Görselleri EMF Olarak Slaytlara Ekle**

Aspose.Slides for Java, Aspose.Cells ile Excel çalışma sayfalarından EMF görselleri oluşturmanıza ve bu görselleri sunum slaytlarına eklemenize olanak tanır. 

Aşağıdaki Java örnek kodu, bunun nasıl yapılacağını gösterir:

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

        // Dosyayı olduğu gibi ekle, böylece resim rasterleştirilmek yerine vektör EMF olarak kalır.
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

## **Görsel Koleksiyonundaki Görselleri Değiştir**

Aspose.Slides, bir sunumun görsel koleksiyonunda depolanan görselleri, slayt şekilleri tarafından kullanılan görseller de dahil olmak üzere, değiştirmenizi sağlar. Bu bölüm, koleksiyondaki görselleri güncellemenin çeşitli yollarını anlatır. Bir görseli ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) örneği veya koleksiyonda zaten bulunan başka bir görsel ile değiştirebilirsiniz. 

Aşağıdaki adımları izleyin:

1. Görselleri içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfı ile yükleyin. 
1. Yeni bir görseli dosyadan bir bayt dizisine yükleyin. 
1. Hedef görseli yeni görselle bayt dizisini kullanarak değiştirin. 
1. İkinci yöntemde, görseli bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) nesnesine yükleyin ve hedef görseli bu nesneyle değiştirin. 
1. Üçüncü yöntemde, hedef görseli sunumun görsel koleksiyonunda zaten mevcut olan bir görselle değiştirin. 
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin. 

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
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
Aspose’un ücretsiz [Metni GIF’e Dönüştür](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü sayesinde metni kolayca canlandırabilir ve GIF’ler oluşturabilirsiniz. 
{{% /alert %}}

## **SSS**

**Ekleme sonrasında orijinal görsel çözünürlüğü korunur mu?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm [resim](/slides/tr/java/picture-frame/) slaytta nasıl ölçeklendirildiğine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır. 

**Onlarca slayttaki aynı logoyu bir kerede değiştirmek için en iyi yol nedir?**

Logoyu ana slayta veya bir yerleşime yerleştirip, sunumun görsel koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır. 

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG’yi şekil grubuna dönüştürebilir, ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir. 

**Bir görseli birden fazla slaytın arka planı olarak aynı anda nasıl ayarlarım?**

Görseli ana slaytta veya ilgili yerleşimde arka plan olarak atayın—bu ana/slayt düzenini kullanan tüm slaytlar arka planı miras alır. 

**Sunum çok sayıda görsel nedeniyle aşırı büyük olmaktan nasıl korunur?**

Tek bir görsel kaynağını yeniden kullanın, makul çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve tekrarlanan grafikleri gerektiğinde ana slayta taşıyın.