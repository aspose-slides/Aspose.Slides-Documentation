---
title: JavaScript'te Sunum Mürekkep Nesnelerini Yönetme
linktitle: Mürekkebi Yönet
type: docs
weight: 95
url: /tr/nodejs-java/manage-ink/
keywords:
- mürekkep
- mürekkep nesnesi
- mürekkep izi
- mürekkebi yönet
- mürekkep çiz
- çizim
- mürekkep dışa aktarımı
- mürekkep işleme
- mürekkebi gizle
- InkOptions
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint mürekkep nesnelerini yönetin, izleri ve fırça özelliklerini düzenleyin ve PDF, HTML, SVG, TIFF ve görüntü dışa aktarımları sırasında mürekkep görünümünü Aspose.Slides for Node.js ile Java aracılığıyla kontrol edin."
---
## **Giriş**

PowerPoint, serbest biçimli darbeler çizebilmenizi sağlayan bir mürekkep özelliği sunar. Mürekkep, diğer nesneleri vurgulamak, bağlantıları ve süreçleri göstermek ve bir slayttaki belirli öğelere dikkat çekmek için kullanılabilir.

Aspose.Slides, mürekkep nesneleriyle çalışmak için gereken tipleri sağlar. Örneğin, [Ink](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ink/) sınıfı bir slayttaki mürekkep nesnesini temsil eder.

## **Normal Nesneler ile Mürekkep Nesneleri Arasındaki Farklar**

PowerPoint slaydındaki nesneler genellikle şekil nesneleriyle temsil edilir. En basit biçimde, bir şekil nesnenin (çerçevesinin) alanını tanımlayan, konteyner boyutu, şekil ve arka plan gibi özelliklere sahip bir kapsayıcıdır. Daha fazla bilgi için [Shape Layout Format](https://docs.aspose.com/slides/tr/nodejs-java/shape-manipulations/#access-layout-formats-for-shape) bölümüne bakın.

Bununla birlikte, PowerPoint bir mürekkep nesnesini işlediğinde, nesne çerçevesinin (kapsayıcının) boyut dışındaki tüm özelliklerini yok sayar. Kapsayıcı alanının boyutu standart [Shape.getWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getWidth--) ve [Shape.getHeight](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getHeight--) yöntemleriyle belirlenir:

![ink_powerpoint1](ink_powerpoint1.png)

## **Mürekkep İzleri**

Mürekkep izi, bir kullanıcının dijital mürekkep ile yazarken kalemin izini kaydetmek için kullanılan temel bir öğedir. Bir iz, birbirine bağlanmış noktalar sırasını saklar.

Kodlamanın en basit biçimi, her örnek noktanın X ve Y koordinatlarını belirtir. Tüm bağlanmış noktalar çizildiğinde aşağıdaki gibi bir görüntü oluşur:

![ink_powerpoint2](ink_powerpoint2.png)

## **Çizim İçin Fırça Özellikleri**

Bir fırça, mürekkep izinin noktalarını birleştiren çizgileri çizmek için kullanılır. Fırçanın kendi rengi ve boyutu vardır; bu, [InkBrush.getColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkbrush/#getColor--) ve [InkBrush.getSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkbrush/#getSize--) yöntemleriyle temsil edilir.

### **Mürekkep Fırçası Rengini Ayarlama**

Bu JavaScript kodu, bir mürekkep fırçasının renginin nasıl ayarlanacağını gösterir:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Mürekkep Fırçası Boyutunu Ayarlama**

Bu JavaScript kodu, bir mürekkep fırçasının boyutunun nasıl ayarlanacağını gösterir:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Genellikle, bir fırçanın genişliği ve yüksekliği eşleşmez, bu yüzden PowerPoint fırça boyutunu göstermez (ilgili veri bölümü gri renkte olur). Fırça genişliği ve yüksekliği eşleştiğinde, PowerPoint boyutunu şu şekilde gösterir:

![ink_powerpoint3](ink_powerpoint3.png)

Açıklık kazandırmak için, mürekkep nesnesinin yüksekliğini artırıp önemli boyutları inceleyelim:

![ink_powerpoint4](ink_powerpoint4.png)

Kapsayıcı (çerçeve), fırçaların boyutunu dikkate almaz—her zaman çizgi kalınlığının sıfır olduğunu varsayar (önceki görüntüye bakın).

Bu nedenle, tüm mürekkep nesnesinin görünür alanını belirlemek için izlerin fırça boyutu dikkate alınmalıdır. Burada, hedef nesne (el yazısı metin izi) kapsayıcının (çerçevenin) boyutuna ölçeklendirilmiştir. Kapsayıcının boyutu değiştiğinde, fırça boyutu sabit kalır ve tersine de aynı durum geçerlidir.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint, metin nesneleri için benzer bir davranış kullanır:

![ink_powerpoint6](ink_powerpoint6.png)

## **Dışa Aktarma ve İşleme Sırasında Mürekkep Görünümünü Kontrol Etme**

Aspose.Slides, mürekkep nesnelerinin dışa aktarılmış veya işlenmiş çıktıda nasıl görüneceğini kontrol etmek için [InkOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/) sınıfını sağlar. Özelliklerini, mürekkebi tamamen gizlemek veya mürekkep fırça maske işlemlerinin nasıl yorumlandığını değiştirmek için kullanabilirsiniz.

Mürekkep seçenekleri, çeşitli çıktı türleri için dışa aktarım veya işleme seçenekleri aracılığıyla kullanılabilir:

| Çıktı | Mürekkep seçenekleri özelliği |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slayt görüntüsü | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Şu [InkOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/) yöntemleri aynı iki ayarı ortaya çıkarır:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/#getHideInk--) belirler, mürekkep nesnelerinin çıktıya dahil edilip edilmediğini. Varsayılan değeri `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) bir maske işleminin, mürekkep fırçası işlenirken opasite olarak yorumlanıp yorumlanmayacağını belirler. Varsayılan değeri `true`; `false` ile [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) çağırarak ROP işlemini kullanabilirsiniz.

### **PDF Çıktısında Mürekkep Nesnelerini Gizleme**

Varsayılan olarak, dışa aktarım sırasında mürekkep nesneleri görünür kalır. El yazısı notlar veya diğer mürekkep içerikleri olmadan temiz bir çıktı oluşturmak için [InkOptions.setHideInk](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) metodunu `true` ile çağırın.

Aşağıdaki JavaScript örneği, tüm mürekkep nesnelerini gizleyerek bir sunumu PDF olarak dışa aktarır:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Bir Slaytı Görüntü Olarak İşlerken Mürekkep Nesnelerini Gizleme**

Slaytları bitmap görüntüler olarak işlerken mürekkep nesnelerini gizlemek için [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) yapılandırın ve işleme seçeneklerini [Slide.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-) metoduna aktarın.

Aşağıdaki JavaScript örneği, ilk slaytı mürekkep nesnesi olmadan PNG görüntüsü olarak işler:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Mürekkep Maske İşlemeyi Kontrol Etme**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) ayarı, mürekkep fırçaları işlenirken maske işlemlerinin nasıl yorumlandığını kontrol eder. Varsayılan değer `true` olup opasiteyi kullanır. Bunun yerine ROP işlemini kullanmak için [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) metodunu `false` ile çağırın.

Aşağıdaki JavaScript örneği, bir slaytı SVG olarak dışa aktarır ve mürekkep maske işlemleri için ROP tabanlı işleme kullanır:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

Aynı ayar, bir sunumu dışa aktarırken veya bir slaytı TIFF olarak işlerken [TiffOptions.getInkOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) aracılığıyla uygulanabilir.

### **Mürekkebi Gizleyip Gizlemeyeceğinizi veya Koruyacağınızı Seçin**

İnceleme işaretleri olmadan dağıtım için anotasyonlu bir sunumun temiz bir sürümüne ihtiyacınız olduğunda, dışa aktarım sırasında [InkOptions.setHideInk](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) metodunu `true` ile çağırın.

İnk notları, el yazısı notlar, vurgulamalar veya dışa aktarılan sonuçta görünür kalması gereken çizimler gibi amaçlanan içeriğin bir parçası olduğunda, [InkOptions.getHideInk](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/#getHideInk--) değerini varsayılan `false` olarak bırakın. Bu, uygulamaların aynı sunumdan kaynak mürekkep nesnelerini değiştirmeden ayrı inceleme ve son çıktılar üretmesini sağlar.

## **SSS**

**Mevcut bir mürekkep darbesinin rengini veya boyutunu değiştirebilir miyim?**

Evet. İzleri [Ink.getTraces](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ink/#getTraces--) ile alın ve ardından onun [InkTrace.getBrush](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inktrace/#getBrush--) öğesini değiştirin. Fırçayı değiştirmek için [InkBrush.setColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) veya [InkBrush.setSize](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) metodlarını çağırın.

**Mürekkebi gizlemek kaynak sunumu değiştirir mi?**

Hayır. [InkOptions.setHideInk](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) çağrısı yalnızca işlenmiş veya dışa aktarılmış sonuca etki eder; kaynak sunumdaki mürekkep nesnelerini kaldırmaz veya değiştirmez.

**Hangi dışa aktarım formatları mürekkep seçeneklerini destekler?**

Yukarıda gösterilen ilgili dışa aktarım veya işleme seçenekleri aracılığıyla PDF, HTML, SVG, TIFF ve bitmap slayt görüntüleri için mürekkep seçeneklerini yapılandırabilirsiniz.

**İlave Okuma**

* Şekiller hakkında genel bilgi için [PowerPoint Shapes](https://docs.aspose.com/slides/tr/nodejs-java/powerpoint-shapes/) bölümüne bakın.
* Etkili değerler hakkında daha fazla bilgi için [Shape Effective Properties](https://docs.aspose.com/slides/tr/nodejs-java/shape-effective-properties/#get-effective-font-height-value) sayfasına bakın.
* PDF dışa aktarım detayları için [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/tr/nodejs-java/convert-powerpoint-to-pdf/) bölümüne bakın.
* HTML dışa aktarım detayları için [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/tr/nodejs-java/convert-powerpoint-to-html/) bölümüne bakın.
* SVG dışa aktarım detayları için [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/) bölümüne bakın.
* TIFF dışa aktarım detayları için [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/tr/nodejs-java/convert-powerpoint-to-tiff/) bölümüne bakın.
* Slayt‑görüntü işleme detayları için [Convert Presentation Slides to Images](https://docs.aspose.com/slides/tr/nodejs-java/convert-slide/) bölümüne bakın.