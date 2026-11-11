---
title: Sunum Slaytlarını JavaScript'te SVG Görüntüleri Olarak Oluşturma
linktitle: Slaytı SVG'ye
type: docs
weight: 50
url: /tr/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'den SVG'ye
- SVG dışa aktarma seçenekleri
- etkileşimli SVG
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint slaytlarını JavaScript'te SVG görüntüleri olarak dışa aktarın ve yazı tiplerini, metni, görüntüleri, kimlikleri ve olayları Aspose.Slides ile kontrol edin."
---
## **Genel Bakış**

SVG, web yayıncılığı, slayt görüntüleyicileri, erişilebilirlik iş akışları ve otomatik post‑işleme için iyi çalışan ölçeklenebilir bir XML tabanlı görüntü formatıdır. Aspose.Slides for Node.js via Java, her slaytı ayrı bir SVG dosyasına dışa aktarır ve metin, yazı tipleri, resimler ve SVG öğelerinin nasıl yazılacağını kontrol etmenizi sağlar.

Dışa aktarılan SVG’nin sıkıştırılmış, tarayıcılar arasında öngörülebilir veya etkileşimli kullanım için hazır olması gerektiğinde [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) kullanın.

## **Bir Slaytı SVG Olarak Dışa Aktarma**

Bir [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) oluşturun, bir slaytı seçin ve [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) ile bir akıma yazın. Aşağıdaki örnek, bir sunumdaki her slaytı ayrı bir SVG dosyası olarak dışa aktarır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Dosya adı, döngü indeksi yerine [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) kullanır. Bir slayt görüntüleyicisinin veya web sayfasının yalnızca o şekle ihtiyaç duyduğu durumlarda, [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) ile tek bir şekli de dışa aktarabilirsiniz.

## **SVG Çıktısını Yapılandırma**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) SVG oluşturmayı kontrol eder. Metin çerçeveleri için, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) metin çerçevesini oluşturma alanına dahil eder ve [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) çerçeve dönüşünün uygulanıp uygulanmayacağını belirler. Metnin ligatür olmadan render edilmesi gerektiğinde [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) değerini `true` olarak ayarlayın.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Ok Uçlarında Çizgi Uç Kesmesini Kontrol Etme**

SVG 1.1, bir çizginin ok ucunun altındaki durma noktasını belirlemek için bir işaretçi iç girinti ayarına sahip değildir. Varsayılan olarak, Aspose.Slides dışa aktarılan çizgiyi, çizgi kalemi işaretçiden dışarı çıkmayacak şekilde kısaltır. Çizgiyi orijinal uç noktasına kadar çizebilmek için [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) değerini `true` olarak çağırın. Bu ayar sadece SVG çıktısını etkiler. Çizgi slayttaki konumunu ve uzunluğunu korur.

Örnek, 2 ve 10 puan genişliğindeki çizgilere üçgen ve elmas ok uçları çizer. Aynı slaytı yalnızca kırpma seçeneğini değiştirerek iki kez dışa aktarır.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

Kıyaslama, 10 puanlık çizgideki üçgen ok ucunu gösterir. Kırpma etkin olduğunda, ucu keskindir. Kırpma devre dışı bırakıldığında, kalem işaretçinin eğimli kenarlarından dışarı çıkar ve düz bir uç bırakır.

![Kırpma etkin olduğunda keskin uçlu, kırpma devre dışı olduğunda düz uçlu büyütülmüş 10 puanlık üçgen](line-end-cropping.png)

Örnekteki diğer çizgilerde, dışarı çıkan kalem 2 puanlık üçgende daha az görülür. Dolu elmas, her iki genişlikte de kalemin ucunu kapatır.

## **Metin ve Yazı Tiplerini Kontrol Etme**

Slaytları SVG olarak dışa aktarırken, metnin metin olarak kalıp kalmayacağını veya vektör grafiklerine dönüştürüleceğini ve dış yazı tiplerinin nasıl dahil edileceğini veya referans gösterileceğini kontrol edebilirsiniz. Aşağıdaki seçenekler, dışa aktarılan SVG'de görsel tutarlılık, metin seçilebilirliği ve yazı tipi bağımlılıklarını dengelemenize yardımcı olur.

### **Tüm Metni Vektörleştir**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) değerini `true` olarak ayarlayın; böylece tüm slayt metni vektör grafik olarak yazılır. Bu, yazı tipi bağımlılıklarını ortadan kaldırır ve görsel sonucu tarayıcılar arasında daha tutarlı hale getirir, ancak metin artık SVG metni olarak seçilemez veya aranamaz.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Dış Yazı Tiplerinin Nasıl İşleneceğini Seçin**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) dışarıdan yüklenen yazı tipleri için bir [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) değeri kullanır. Ayrı yazı tipi dosyalarına referans vermek için `AddLinksToFontFiles`, yazı tipi verisini SVG'ye dahil etmek için `Embed`, veya dış yazı tiplerini kullanan metni yalnızca grafik olarak render etmek için `Vectorize` seçin. Yazı tiplerini gömmeden önce lisanslamayı doğrulayın.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Yerleşik Görüntü Boyutunu Azaltma**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) kullanarak yerleşik resimlerin çözünürlüğünü düşürün, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) ile kırpılmış kaynak alanlarını atlayın ve [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) ile JPEG kodlama kalitesini kontrol edin. Bu ayarlar, dosya boyutunu azaltırken görüntü kalitesi veya tutulan görüntü verisi pahasına bir azalma sağlar.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Metafile Rasterizasyon Çözünürlüğünü Kontrol Etme**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) SVG dışa aktarımı sırasında metafile'ları rasterleştirirken alt çözünürlük sınırını belirler. EMF veya WMF görüntüsü rasterleştirildiğinde detay ve dosya boyutunu dengelemek için kullanın. Bu, SVG için küresel bir DPI tanımlamaz ve slayttaki her nesnenin raster görüntü olmasını zorlamaz.

[metafile-rasterization.pptx](metafile-rasterization.pptx) dosyasını indirin; bu dosya yakın aralıklı diyagonal çizgileri olan bir EMF görüntüsü içerir. Aşağıdaki örnek, [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) ile ilk slaytını üç rasterleştirme çözünürlüğünde dışa aktarır. Diğer tüm dışa aktarım ayarları aynı kalır, böylece sonuçlar karşılaştırılabilir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

| Metafile rasterizasyon DPI | Gömülü PNG boyutları | SVG dosya boyutu (bayt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Aşağıdaki karşılaştırma, gömülü rasterin aynı alanını aynı büyütülmüş görüntü boyutunda gösterir. Diyagonal çizgiler 72 DPI'de belirgin pikselleşme ve daha yüksek çözünürlüklerde daha yumuşak kenarlar gösterirken, SVG dosyası büyür. Değeri artırmak, her detayı iyileştirmek veya her dışa aktarılan görüntüyü değiştirmek zorunda değildir.

![72, 150 ve 300 DPI'de büyütülmüş diyagonal çizgi detayı](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) görüntü çözünürlüğü azaltmayı kontrol eder ve metafile rasterizasyon çözünürlüğündeki değişikliğin etkisini gizleyebilir. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) JPEG kodlama kalitesini kontrol eder, metafile rasterizasyon çözünürlüğünü değil.

## **Şekillere ve Metne Kararlı Kimlikler Ata**

Her SVG şekli için [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) ayarlamak amacıyla bir biçimlendirme denetleyicisini [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) aracılığıyla geçirin. Metin aralıklarını (tspan) da işleyen bir denetleyici, metin `tspan` öğeleri üzerinde [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) değerlerini ayarlayabilir.

Aşağıdaki denetleyici, şeklin yaşam süresi boyunca sabit olan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) ve metin aralıkları için tekrarlanabilir bir sayaç kullanır. Bu, üretilen kimliklerin değişmemiş bir sunumu sonradan işlemek için uygun olmasını sağlar.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **SVG Olay İşleyicileri Ekleme**

Bir biçimlendirme denetleyicisinde, dışa aktarılan bir şekle JavaScript olay işleyicisi eklemek için [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) metodunu bir [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) değeriyle çağırın. Denetleyiciyi [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) ile atayın ve sonucu barındıran sayfada veya SVG belgesinde JavaScript işlevini tanımlayın.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

Barındırıcı sayfa, işleyici tarafından referans verilen JavaScript fonksiyonunu tanımlayabilir. Kimliklerin ve olay işleyicilerin atanması, slayt görüntüleyicileri, erişilebilirlik iyileştirmeleri ve diğer etkileşimli SVG iş akışlarını mümkün kılar.

## **SSS**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) yerine [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) ne zaman kullanılmalı?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) tüm metnin yazı tiplerinden bağımsız olması gerektiğinde kullanın. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) yalnızca dış yazı tiplerini kullanan metnin grafiklere dönüştürülmesi gerektiğinde kullanın.

**Bir SVG'yi küçültmenin en iyi yolu nedir?**

İlk olarak yerleşik resimleri sıkıştırın, kırpılmış görüntü alanlarını silin ve hedef ortam bunları sunabiliyorsa bağlantılı yazı tipi dosyalarını seçin. Sonucu test edin; çünkü düşük görüntü çözünürlüğü, düşük JPEG kalitesi ve vektörleştirilmiş metin farklı kalite ve boyut dengeleri sunar.

**Dışa aktarılan SVG öğelerini dışa aktardıktan sonra değiştirebilir miyim?**

Evet. Bir biçimlendirme denetleyicisi aracılığıyla kimlikler atayın, ardından eşleşen SVG öğelerini son işleme aracınızda veya tarayıcı betiğinizde seçin.