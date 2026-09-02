---
title: JavaScript Kullanarak Sunumlardaki Görüntü Yönetimini Optimize Etme
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/nodejs-java/image/
keywords:
- görüntü ekle
- resim ekle
- bit eşlem ekle
- görüntüyü değiştir
- resmi değiştir
- web’den
- arkaplan
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint ve OpenDocument'te görüntü yönetimini kolaylaştırın, performansı optimize edin ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller sunumları daha ilgi çekici ve görsel olarak cazip kılar. Microsoft PowerPoint'te, dosyalardan, internetten veya diğer kaynaklardan slaytlara resimler ekleyebilirsiniz. Benzer şekilde, Aspose.Slides de sunum slaytlarına birkaç yolla resim eklemenizi sağlar.

{{% alert  title="İpucu" color="primary" %}} 

Aspose, görüntülerden hızlı bir şekilde sunum oluşturmanızı sağlayan ücretsiz dönüştürücüler—[JPEG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG'den PowerPoint'e](https://products.aspose.app/slides/tr/import/png-to-ppt)—sunmaktadır. 

{{% /alert %}} 

{{% alert title="Bilgi" color="info" %}}

Bir resmi resim çerçevesi olarak eklemek isterseniz—özellikle yeniden boyutlandırma, efekt uygulama veya diğer standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Resim Çerçevesi](/slides/tr/nodejs-java/picture-frame/) bölümüne bakın. 

{{% /alert %}} 

{{% alert title="Not" color="warning" %}}

Görüntüleri bir formattan diğerine dönüştürebilirsiniz. Aşağıdaki sayfalara bakın: görüntüyü [görüntüyü JPG'e](https://products.aspose.com/slides/tr/nodejs-java/conversion/image-to-jpg/), [JPG'yi görüntüye](https://products.aspose.com/slides/tr/nodejs-java/conversion/jpg-to-image/), [JPG'yi PNG'ye](https://products.aspose.com/slides/tr/nodejs-java/conversion/jpg-to-png/), [PNG'yi JPG'ye](https://products.aspose.com/slides/tr/nodejs-java/conversion/png-to-jpg/), [PNG'yi SVG'ye](https://products.aspose.com/slides/tr/nodejs-java/conversion/png-to-svg/), ve [SVG'yi PNG'ye](https://products.aspose.com/slides/tr/nodejs-java/conversion/svg-to-png/) dönüştürme sayfalarını inceleyin.

{{% /alert %}}

Aspose.Slides, JPEG, PNG, BMP, GIF gibi popüler formatlardaki görüntüleri destekler. 

## **Yerel Olarak Depolanan Görüntüleri Slaytlara Ekleme**

Bilgisayarınızda depolanan bir veya daha fazla görüntüyü bir sunum slaytına ekleyebilirsiniz. Aşağıdaki JavaScript örnek kodu bir görüntünün slayta nasıl ekleneceğini gösterir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Web'den Görüntüleri Slaytlara Ekleme**

Slayta eklemek istediğiniz görüntü bilgisayarınızda depolanmamışsa, doğrudan web üzerinden ekleyebilirsiniz. 

Aşağıdaki JavaScript örnek kodu bir görüntünün webten slayta nasıl ekleneceğini gösterir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Görüntüleri Slayt Master'ına Ekleme**

Bir slayt master'ı, onu kullanan slaytların teması ve düzeni gibi bilgileri saklar ve kontrol eder. Bir slayt master'ına bir görüntü eklediğinizde, görüntü o master'ı temel alan her slaytta görünür. 

Aşağıdaki JavaScript örnek kodu bir slayt master'ına bir görüntünün nasıl ekleneceğini gösterir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Görüntüleri Slayt Arka Planı Olarak Ekleme**

Bir veya daha fazla slaytın arka planı olarak bir resim kullanabilirsiniz. Ayrıntılar için *[Slaytlar İçin Görüntüleri Arka Plan Olarak Ayarlama](/slides/tr/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* bölümüne bakın.

## **Sunumlara SVG Ekleme**

SVG içeriği, bir sunuma [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) sınıfı kullanılarak eklenebilir. Oluşturulan SVG görüntü nesnesi daha sonra sunumun görüntü koleksiyonuna eklenebilir ve bir resim çerçevesi oluşturmak için kullanılabilir.

Aşağıdaki JavaScript örneği bağımsız bir SVG dizesi içe aktarır. Bu SVG tarafından kullanılan tüm görüntüler, stiller ve diğer kaynaklar doğrudan SVG içeriğine gömülür.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Harici Kaynaklarla SVG İçeriği İçe Aktarma**

SVG araçlarından, diyagram editörlerinden, ikon sistemlerinden ve web pipeline'larından dışa aktarılan SVG dosyaları, SVG belgesinin dışındaki kaynakları referans alabilir. Örneğin, bir SVG `images/photo.png` gibi bir resim bağlantısı, bir CSS `url(...)` değeri veya bir font URL'si içerebilir.

Bu tür SVG içeriğini içe aktarmak için bir harici kaynak çözücüsü sağlayın ve bunu bir temel URI ile birlikte uygun bir [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) yapıcıya geçirin. Temel URI, SVG belgesinin konumunu tanımlar ve göreceli bağlantıların çözülmesinde kullanılır.

`SvgImage` sınıfı, içe aktarılan SVG hakkında bilgiye erişim sağlar:

- `getSvgContent()` SVG işaretlemesini bir dize olarak döndürür.
- `getSvgData()` SVG içeriğini bir bayt dizisi olarak döndürür.
- `getBaseUri()` göreceli bağlantılar için kullanılan temel URI'yi döndürür.
- `getExternalResourceResolver()` SVG görüntüsüne atanmış çözücüyü döndürür.

### **Harici Kaynak Çözücüsü Uygulama**

Çözücünün iki yöntemi vardır:

- `resolveUri` temel URI ve göreceli kaynak bağlantısını birleştirir ve mutlak bir URI döndürür. Bağlantı çözülemez veya izin verilmiyorsa `null` döndürün.
- `getEntity` mutlak bir kaynak URI için okunabilir bir Java akışı döndürür. Kaynak eksik, engellenmiş veya erişilemezse `null` döndürün. Uygun olduğunda bir yedek akış da döndürülebilir.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Bu çözücü kasıtlı olarak yalnızca yerel dosyalara izin verir.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Yalnızca görüntü kaynakları için bir yedek kullanın. Bir görüntü akışı döndürmek
                // eksik bir yazı tipi veya stil sayfası için geçerli olmayacaktır.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **SVG İçe Aktarım Sırasında Bağlı Kaynakları Çözümleme**

`assets/diagram.svg` dosyasının aşağıdaki gibi bir göreceli referans içerdiğini varsayalım:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Aşağıdaki JavaScript örneği SVG dosya URI'sını temel URI olarak geçirir ve özel bir çözücü sağlar. Çözücü, göreceli resim bağlantısını mutlak bir URI'ye dönüştürür ve Aspose.Slides SVG'yi işlerken bağlı kaynağı içeren bir akış döndürür.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// Temel URI, SVG belgesinin konumunu temsil eder.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage, kaynak içeriği, ikili veri, temel URI ve çözücüyü ortaya çıkar.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` sınıfı ayrıca SVG verilerini bir bayt dizisi olarak kabul eden aşırı yüklemeler ve akış tabanlı fabrika yöntemleri sağlar; bu yöntemler bir harici kaynak çözücüsü ve temel URI ile birlikte kullanılabilir.

{{% alert title="Önemli" color="warning" %}}

Kaynak çözücüsü, Aspose.Slides SVG'yi işlerken ve render ederken harici kaynakların kullanılabilir olmasını sağlar. Orijinal SVG işaretlemesini değiştirmez veya çözülen kaynakları otomatik olarak içine gömme yapmaz.

Bir SVG görüntüsü sunumun görüntü koleksiyonuna eklendiğinde, PPTX dosyası hem orijinal SVG temsili hem de bir raster yedek görüntüsü içerebilir. Bağlı bir kaynak, oluşturulan yedek görüntüde görünebilirken, `images/photo.png` gibi bir göreceli bağlantı depolanmış SVG'de değişmeden kalır. Yerel SVG temsili render eden bir uygulama, orijinal harici kaynak mevcut olmadığında bağlı içeriği atlayabilir.

{{% /alert %}}

### **Taşınabilir SVG Resmi Oluşturma**

Harici dosyalara bağımlı olmayan bir SVG resmi oluşturmak için, `SvgImage` oluşturmadan önce SVG'yi kendine yeterli hâle getirin. Örneğin, bağlı resim URL'lerini resim verisini içeren `data:` URI'leriyle değiştirin:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Gerekli tüm kaynaklar SVG içeriğine gömüldükten sonra `SvgImage` oluşturun, sunumun görüntü koleksiyonuna ekleyin ve önceki örnekte gösterildiği gibi bir resim çerçevesine yerleştirin.

### **Eksik veya Engellenen Kaynakları İşleme**

Bir kaynak URI'si geçersiz, yasak veya çözülemezse `resolveUri`'den `null` döndürün. Kaynak okunamıyorsa `getEntity`'den `null` döndürün. Aspose.Slides mümkün olduğunda bu kaynağı olmadan SVG'yi işlemeye devam eder.

Eksik bir kaynak için bir yedek akış döndürülebilir, ancak içeriği istenen kaynak türüyle uyumlu olmalıdır. Örneğin, yalnızca eksik bir resim için bir resim akışı döndürün; font veya stil sayfası için değil.

{{% alert title="Güvenlik" color="warning" %}}

Güvenilmeyen SVG dosyalarından rastgele dosya yolları veya sınırsız ağ URL'leri çözümlemeyin. İzin verilen şemaları, dizinleri ve hostları kısıtlayın. Ağ kaynakları için ayrıca bağlantı zaman aşımı, yanıt boyutu limitleri ve içerik doğrulaması uygulayın.

{{% /alert %}}

## **SVG'yi Şekil Setine Dönüştürme**

Aspose.Slides, bir SVG'yi PowerPoint'teki karşılık gelen işlevselliğe benzer şekilde bir şekil setine dönüştürebilir:

![PowerPoint Açılır Menü](img_01_01.png)

Bu işlevsellik, bir SVG görüntü nesnesini ilk argüman olarak alan [addGroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) metodunun bir aşırı yüklemesi olan [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) sınıfı tarafından sağlanır.

Aşağıdaki JavaScript örnek kodu bu yöntemi kullanarak bir SVG dosyasını şekil setine dönüştürmeyi gösterir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Kaynak SVG dosya adı.
const svgFileName = "sample.svg";

// Çıktı sunum dosya adı.
const outPptxPath = "presentation.pptx";

// Yeni bir sunum oluştur.
const presentation = new aspose.slides.Presentation();
try {
    // SVG dosya içeriğini oku.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Bir SvgImage nesnesi oluştur.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Slayt boyutunu al.
    const slideSize = presentation.getSlideSize().getSize();

    // SVG görüntüsünü şekil grubuna dönüştür ve slayt boyutuna ölçekle.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Sunumu PPTX formatında kaydet.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Görüntüleri EMF Olarak Slaytlara Ekleme**

Aspose.Slides for Node.js via Java, Aspose.Cells ile Excel çalışma sayfalarından EMF görüntüleri oluşturmanıza ve bu görüntüleri sunum slaytlarına eklemenize olanak tanır.

Aşağıdaki JavaScript örnek kodu bunu nasıl yapacağınızı gösterir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Çalışma kitabını bir akışa kaydet.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Dosyayı olduğu gibi ekle ki resim rasterleştirilmek yerine vektörel EMF olarak kalsın.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Görüntü Koleksiyonundaki Görüntüleri Değiştirme**

Aspose.Slides, sunumun görüntü koleksiyonunda depolanan görüntüleri, slayt şekilleri tarafından kullanılan görüntüler dahil, değiştirmenize izin verir. Bu bölüm, koleksiyondaki görüntüleri güncellemenin birkaç yolunu açıklar. Bir görüntüyü ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut olan başka bir görüntü kullanarak değiştirebilirsiniz.

Aşağıdaki adımları izleyin:

1. Görüntüleri içeren sunum dosyasını [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfını kullanarak yükleyin.
1. Yeni bir görüntüyü dosyadan bir bayt dizisine yükleyin.
1. Hedef görüntüyü bayt dizisini kullanarak yeni görüntüyle değiştirin.
1. İkinci yöntemde, görüntüyü bir [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) nesnesine yükleyin ve hedef görüntüyü bu nesneyle değiştirin.
1. Üçüncü yöntemde, hedef görüntüyü sunumun görüntü koleksiyonunda zaten bulunan bir görüntüyle değiştirin.
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Sunum dosyasını temsil eden Presentation sınıfının örneğini oluştur.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // İlk yöntem.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // İkinci yöntem.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Üçüncü yöntem.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Sunumu bir dosyaya kaydet.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Bilgi" color="info" %}}

Aspose'un ücretsiz [Metni GIF'e Dönüştür](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsü ile metni kolayca hareketlendirebilir ve metinden GIF'ler oluşturabilirsiniz. 

{{% /alert %}}

## **SSS**

**Ekleme sonrası orijinal görüntü çözünürlüğü aynı kalır mı?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm, slayttaki [resim](/slides/tr/nodejs-java/picture-frame/) nasıl ölçeklendirildiğine ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Yüzlerce slaytta aynı logoyu aynı anda değiştirmek için en iyi yöntem nedir?**

Logoyu master slaytına veya bir düzene yerleştirin ve sunumun görüntü koleksiyonunda değiştirin—güncellemeler bu kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG'yi şekil grubuna dönüştürebilirsiniz; ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi birden fazla slaytın arka planı olarak aynı anda nasıl ayarlayabilirim?**

Resmi master slaytında veya ilgili düzende *[arkaplan olarak ata](/slides/tr/nodejs-java/presentation-background/)*; bu master/duzen'i kullanan tüm slaytlar arka planı miras alır.

**Bir sunumun çok sayıda resim nedeniyle çok büyük olmasını nasıl önleyebilirim?**

Tek bir görüntü kaynağını tekrar kullanın, makul çözünürlükler seçin, kaydetme sırasında sıkıştırma uygulayın ve gerektiğinde tekrarlanan grafikleri master'da tutun.