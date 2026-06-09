---
title: JavaScript Kullanarak Sunumlarda Görüntü Yönetimini Optimize Edin
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/nodejs-java/image/
keywords:
- görüntü ekle
- resim ekle
- bitmap ekle
- görüntüyü değiştir
- resmi değiştir
- web'den
- arkaplan
- PNG ekle
- JPG ekle
- SVG ekle
- EMF ekle
- WMF ekle
- TIFF ekle
- PowerPoint
- OpenDocument
- sunum
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Node.js için Aspose.Slides ile PowerPoint ve OpenDocument'te görüntü yönetimini kolaylaştırarak performansı artırın ve iş akışınızı otomatikleştirin."
---
## **Giriş**

Görseller sunumları daha ilgi çekici ve etkileyici hâle getirir. Microsoft PowerPoint'te bir dosyadan, internetten veya başka konumlardan slaytlara resim ekleyebilirsiniz. Benzer şekilde, Aspose.Slides sunumlarınızdaki slaytlara farklı prosedürler aracılığıyla resim eklemenizi sağlar. 

{{% alert  title="Tip" color="primary" %}} 

Aspose, insanlara görüntülerden hızlı bir şekilde sunum oluşturmayı sağlayan ücretsiz dönüştürücüler—[JPEG to PowerPoint](https://products.aspose.app/slides/tr/import/jpg-to-ppt) ve [PNG to PowerPoint](https://products.aspose.app/slides/tr/import/png-to-ppt)—sağlar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Bir resmi çerçeve nesnesi olarak eklemek istiyorsanız—özellikle boyutunu değiştirmek, efekt eklemek vb. için standart biçimlendirme seçeneklerini kullanmayı planlıyorsanız—[Picture Frame](https://docs.aspose.com/slides/tr/nodejs-java/picture-frame/) sayfasına bakın.

{{% /alert %}} 

Aspose.Slides, JPEG, PNG, GIF ve diğer popüler formatlardaki görüntülerle işlemleri destekler. 

## **Yerel Olarak Depolanan Görsellerin Slaytlara Eklenmesi**

Bilgisayarınızda bulunan bir veya birkaç görüntüyü bir sunumdaki slayta ekleyebilirsiniz. Bu JavaScript örnek kodu, bir görüntüyü slayta nasıl ekleyeceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Akıştan Görsellerin Slaytlara Eklenmesi**

Slayta eklemek istediğiniz görüntü bilgisayarınızda mevcut değilse, görüntüyü doğrudan web'den ekleyebilirsiniz. 

Bu örnek kod, JavaScript'te bir görüntüyü web'den slayta nasıl ekleyeceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // İlk slayta erişir
    var sld = pres.getSlides().get_Item(0);
    // Bir excel dosyasını akışa yükler
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Gömme için veri nesnesi oluşturur
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Bir Ole Object Frame şekli ekler
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // PPTX dosyasını diske yazar
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Görsellerin Slayt Üstlerine Eklenmesi**

Slayt üstü, altındaki tüm slaytların (tema, düzen vb.) bilgilerini saklayan ve kontrol eden en üst slayttır. Bu nedenle bir slayt üstüne bir görsel eklerseniz, o görsel o slayt üstünün altındaki tüm slaytlarda görünür. 

Bu JavaScript örnek kodu, bir görseli slayt üstüne nasıl ekleyeceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Görselleri Slayt Arka Planı Olarak Eklemek**

Belirli bir slayt veya birkaç slayt için bir resmi arka plan olarak kullanmaya karar verebilirsiniz. Bu durumda *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/tr/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* sayfasına bakmanız gerekir.

## **Sunumlara SVG Eklemek**
Sunuma herhangi bir görüntü eklemek veya yerleştirmek için, [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) sınıfına ait olan [addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) metodunu kullanabilirsiniz.

SVG görüntüsüne dayalı bir görüntü nesnesi oluşturmak için şu şekilde yapabilirsiniz:

1. SvgImage nesnesi oluşturun ve ImageShapeCollection'a ekleyin
2. ISvgImage'den PPImage nesnesi oluşturun
3. PPImage sınıfını kullanarak PictureFrame nesnesi oluşturun

Bu örnek kod, yukarıdaki adımları uygulayarak bir SVG görüntüsünü sunuma nasıl ekleyeceğinizi gösterir:
```javascript
// PPTX dosyasını temsil eden Presentation sınıfını örnekle
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SVG'yi Şekil Kümesine Dönüştürmek**
Aspose.Slides'ın SVG'yi şekil kümesine dönüştürmesi, SVG görüntüleriyle çalışmak için kullanılan PowerPoint işlevine benzer:

![PowerPoint Popup Menu](img_01_01.png)

Bu işlevsellik, [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) sınıfının [addGroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) metodunun aşırı yüklemelerinden biri tarafından sağlanır; bu metod ilk argüman olarak bir [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SvgImage) nesnesi alır.

Bu örnek kod, bir SVG dosyasını şekil kümesine dönüştürmek için açıklanan metodu nasıl kullanacağınızı gösterir:

```javascript
// Yeni bir sunum oluştur
var presentation = new aspose.slides.Presentation();
try {
    // SVG dosya içeriğini oku
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // SvgImage nesnesi oluştur
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Slayt boyutunu al
    var slideSize = presentation.getSlideSize().getSize();
    // SVG görüntüsünü slayt boyutuna ölçeklendirerek şekil grubuna dönüştür
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Sunumu PPTX formatında kaydet
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Görselleri Slaytlara EMF Olarak Eklemek**
Node.js için Java aracılığıyla Aspose.Slides, Excel sayfalarından EMF görüntüleri oluşturmanıza ve bu görüntüleri Aspose.Cells ile slaytlara EMF olarak eklemenize olanak tanır.  

Bu örnek kod, açıklanan görevi nasıl yerine getireceğinizi gösterir:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Çalışma kitabını akışa kaydet
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Görüntü Koleksiyonundaki Görselleri Değiştirme**

Aspose.Slides, bir sunumun görüntü koleksiyonunda (slayt şekilleri tarafından kullanılanlar dahil) depolanan görüntüleri değiştirmenizi sağlar. Bu bölüm, koleksiyondaki görüntüleri güncellemenin çeşitli yaklaşımlarını gösterir. API, ham bayt verisi, bir [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) örneği veya koleksiyonda zaten mevcut olan başka bir görüntü kullanarak bir görüntüyü değiştirmek için basit yöntemler sunar.

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfını kullanarak görüntüleri içeren sunum dosyasını yükleyin.
2. Yeni bir görüntüyü dosyadan bir bayt dizisine yükleyin.
3. Hedef görüntüyü bayt dizisini kullanarak yeni görüntüyle değiştirin.
4. İkinci yaklaşımda, görüntüyü bir [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) nesnesine yükleyin ve hedef görüntüyü bu nesneyle değiştirin.
5. Üçüncü yaklaşımda, hedef görüntüyü sunumun görüntü koleksiyonunda zaten mevcut olan bir görüntüyle değiştirin.
Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```js
// Sunum dosyasını temsil eden Presentation sınıfını örnekle.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // İlk yol.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // İkinci yol.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Üçüncü yol.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Sunumu bir dosyaya kaydet.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose FREE [Text to GIF](https://products.aspose.app/slides/tr/text-to-gif) dönüştürücüsünü kullanarak metinleri kolayca canlandırabilir, metinlerden GIF oluşturabilir vb. 

{{% /alert %}}

## **SSS**

**Ekleme işleminden sonra orijinal görüntü çözünürlüğü aynı kalır mı?**

Evet. Kaynak pikseller korunur, ancak nihai görünüm slayttaki [picture](/slides/tr/nodejs-java/picture-frame/) ölçeklendirme şekline ve kaydetme sırasında uygulanan sıkıştırmaya bağlıdır.

**Onlarca slaytta aynı logoyu aynı anda değiştirmek için en iyi yöntem nedir?**

Logoyu master slayta veya bir düzene yerleştirin ve sunumun görüntü koleksiyonunda değiştirin—güncellemeler o kaynağı kullanan tüm öğelere yayılır.

**Eklenen bir SVG, düzenlenebilir şekillere dönüştürülebilir mi?**

Evet. Bir SVG'yi şekil grubuna dönüştürebilir ve ardından bireysel parçalar standart şekil özellikleriyle düzenlenebilir hâle gelir.

**Bir resmi birden fazla slaytın arka planı olarak nasıl ayarlayabilirim?**

Görseli master slaytta veya ilgili düzende [arka plan olarak ata](/slides/tr/nodejs-java/presentation-background/)—bu master/düzeni kullanan tüm slaytlar arka planı miras alır.

**Birçok resim nedeniyle sunumun boyutu "şişmekten" nasıl korurum?**

Tek bir görüntü kaynağını tekrar kullanın, kopyalar yerine, uygun çözünürlükler seçin, kaydederken sıkıştırma uygulayın ve tekrarlanan grafikleri gerektiğinde master üzerinde tutun.