---
title: JavaScript ile Sunum Slaytlarını Görsellere Dönüştür
linktitle: Slayttan Görsele
type: docs
weight: 35
url: /tr/nodejs-java/convert-slide/
keywords:
- slaytı dönüştür
- slaytı dışa aktar
- slayttan görüntüye
- slaytı görüntü olarak kaydet
- slayttan EMF'ye
- slayttan PNG'ye
- slayttan JPEG'e
- slayttan bitmap'e
- slayttan TIFF'e
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile JavaScript'te PPT, PPTX ve ODP sunumlarından PNG, JPEG, GIF, TIFF, EMF ve diğer görüntü formatlarına slaytları dönüştürün."
---
## **Introduction**

Aspose.Slides for Node.js via Java, PowerPoint ve OpenDocument sunumlarından ayrı slaytları PNG, JPEG, GIF, TIFF ve diğer görüntü formatları olarak işleyebilir.

Bir slaytı görüntüye dönüştürmek için aşağıdaki adımları izleyin:

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfı ile yükleyin.  
2. Görüntülenmesini istediğiniz slaytı seçin.  
3. Gerekirse, renderlemeyi [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/) veya [TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfı ile yapılandırın.  
4. [Slide.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) metodunu çağırın. Bu metod bir [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) nesnesi döndürür.  
5. [IImage.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/#save) metodunu çağırın ve çıkış formatını bir [ImageFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imageformat/) değeriyle belirtin.

## **Convert a Slide to a PNG Image**

En basit dönüşüm, varsayılan renderleme ayarlarını kullanır. Oluşan [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) nesnesi bellekte işlenebilir ya da bir dosyaya kaydedilebilir.

Aşağıdaki JavaScript örneği, ilk slaytı renderler ve PNG görüntüsü olarak kaydeder:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convert Slides to Images with Custom Sizes**

Tam piksel boyutlarıyla bir slaytı renderlemek için `java.awt.Dimension` değerini kabul eden [Slide.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) aşırı yüklemesini kullanın.

Aşağıdaki örnek, 1820 × 1040 boyutlarında bir JPEG görüntüsü oluşturur:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Convert Slides with Notes and Comments to Images**

Varsayılan olarak slayt görselleri notları veya yorumları içermez. Notların ve yorumların nerede görüneceğini kontrol etmek için [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) metoduna bir [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) nesnesi gönderin.

Aşağıdaki örnek, kesilmiş notları slaytın altına ve yorumları sağ tarafına yerleştirir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Uyarı" color="warning" %}}

Slayt‑görüntü dönüşümü için, [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metoduna [BottomFull](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notespositions/) gönderilmemelidir. Notlar, sabit görüntü boyutunun alabileceğinden daha fazla metin içerebilir. Bunun yerine [BottomTruncated](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/notespositions/) kullanın.

{{% /alert %}}

## **Convert Slides to Images Using TIFF Options**

[TiffOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/) sınıfı, oluşturulan TIFF görüntüsünün boyutunu, çözünürlüğünü ve diğer özelliklerini kontrol etmenizi sağlar.

Aşağıdaki örnek, ilk slaytı 2160 × 2880 boyutlarında, 300 DPI çözünürlükte bir TIFF görüntüsü olarak renderler:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Uyarı" color="warning" %}}

TIFF desteği, JDK 9’dan önceki Java sürümlerinde garanti edilmez.

{{% /alert %}}

## **Convert All Slides to Images**

Tüm sunumu bir dizi görüntüye dönüştürmek için slayt koleksiyonunda döngü yapın. Gizli slaytlar, özellikle atlamazsanız dahil edilir.

Aşağıdaki örnek, her slaytı yatay ve dikey ölçek faktörleri 2 olan bir JPEG görüntüsü olarak renderler:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Create Enhanced Metafile Output**

Enhanced Metafile (EMF), vektör tabanlı grafiklerin Microsoft Office veya Windows metafile desteği olan diğer Windows uygulamalarıyla değiş tokuş edilmesi gerektiğinde kullanışlıdır. Piksel tabanlı bir görüntünün aksine, EMF, aynı keskinlik kaybı olmadan ölçeklenebilen vektör çizim işlemlerini koruyabilir. Ancak EMF, esas olarak Windows metafile desteği olan uygulamalar için bir uyumluluk formatıdır, evrensel bir değiş‑takas formatı değildir. Ayrıca, bitmap görüntüler ve bazı efektler gibi karmaşık slayt içerikleri, vektör metafile konteyneri içinde rasterleştirilmiş öğeler olarak saklanabilir.

### **Export a Slide to EMF**

[Slide.writeAsEmf](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#writeAsEmf) metodu, bir slaytı EMF formatında hedef akıma yazar. Aşağıdaki örnek bir sunumu yükler, ilk slaytı seçer ve bir EMF dosya akışına yazar:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

[Slide.writeAsEmf](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#writeAsEmf) metoduna geçirilen akımın sahibi arayan taraftır ve örnekte gösterildiği gibi kapanmasından sorumludur.

### **Convert an SVG Image to EMF and Add It to a Presentation**

SVG içeriğini EMF’ye dönüştürmek için [SvgImage.writeAsEmf](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/#writeAsEmf) kullanın. Ortaya çıkan baytlar, [ImageCollection.addImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagecollection/#addImage) aracılığıyla sunuma eklenebilir ve [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) ile bir slayta yerleştirilebilir.

Aşağıdaki örnek, SVG işaretlemesinden bir [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) oluşturur, bunu bellek içinde bir EMF’ye dönüştürür, metafile’i ilk slayta ekler ve sunumu kaydeder:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/#writeAsEmf), hedef akımın sahipliğini almaz. `java.io.ByteArrayOutputStream` tüm oluşturulan veriyi bellekte tutar; bu nedenle `toByteArray` çağrılmadan önce konum sıfırlamaya gerek yoktur. Döndürülen bayt dizisi, akım kapatıldıktan sonra da geçerliliğini korur.

EMF üretimi, seçilen Aspose.Slides for Node.js via Java ve JDK yapılandırması tarafından desteklenen işletim sistemlerinde kullanılabilir, ancak yazı tipleri veya grafik bağımlılıkları bulunmadığında platformlar arasında renderleme farklılık gösterebilir. Kaynak içeriğin kullandığı yazı tiplerini kurun veya uygun ikameler yapılandırın, Aspose.Slides for Node.js via Java için [platform gereksinimlerini](/slides/tr/nodejs-java/system-requirements/) izleyin ve hedef EMF tüketen uygulamada sonucu doğrulayın. Linux ve macOS uygulamaları genellikle Windows metafile’larını görüntüleme ve düzenlemede sınırlı veya tutarsız destek sunar.

## **Color Emoji Rendering**

{{% alert title="Bilgi" color="info" %}}
Sunum slaytlarını görüntülere dönüştürürken renkli emoji’lerin doğru renderlenmesi için, sunumda kullanılan emoji yazı tiplerinin dönüştürmeyi yapan sistemde kurulu ve erişilebilir olması gerekir. Örneğin, sunum **Segoe UI Emoji** yazı tipini kullanıyorsa ve bu yazı tipi eksikse, emoji’ler çıktı görüntülerinde tek renkli (monokrom) görünebilir.
{{% /alert %}}

## **FAQ**

**Aspose.Slides, animasyonlu slaytların renderlenmesini destekliyor mu?**

Hayır. [Slide.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) metodu, slaytin statik bir görüntüsünü oluşturur ve animasyonları dışa aktmaz.

**Gizli slaytlar görüntü olarak dışa aktarılabilir mi?**

Evet. Gizli slaytlar, normal slaytlar gibi renderlenebilir. Yukarıdaki örnekte gösterildiği gibi işleme döngüsüne dahil edin.

**Slayt görüntülerinde gölgeler ve diğer efektler korunur mu?**

Evet. Aspose.Slides, gölgeler, şeffaflık ve diğer desteklenen grafik efektlerini slayt görüntülerinde renderler.