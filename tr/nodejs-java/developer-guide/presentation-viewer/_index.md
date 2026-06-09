---
title: JavaScript ile Sunum Görüntüleyici Oluşturun
linktitle: Sunum Görüntüleyici
type: docs
weight: 50
url: /tr/nodejs-java/presentation-viewer/
keywords:
- sunumu görüntüle
- sunum görüntüleyici
- sunum görüntüleyici oluştur
- PPT görüntüle
- PPTX görüntüle
- ODP görüntüle
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile JavaScript'te özel bir sunum görüntüleyici oluşturun. Microsoft PowerPoint olmadan PowerPoint ve OpenDocument dosyalarını kolayca görüntüleyin."
---
## **Giriş**

Aspose.Slides for Node.js via Java, slayt içeren sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, örneğin Microsoft PowerPoint'te sunumları açarak görüntülenebilir. Ancak, bazen geliştiricilerin slaytları tercih ettikleri görüntü görüntüleyicide resim olarak görmeleri veya kendi sunum görüntüleyicilerini oluşturmaları gerekebilir. Böyle durumlarda, Aspose.Slides tek bir slaytı resim olarak dışa aktarmanıza olanak tanır. Bu makale bunu nasıl yapacağınızı açıklar.

## **Bir Slayttan SVG Resmi Oluşturma**

Bir sunum slaydından Aspose.Slides kullanarak SVG resmi oluşturmak için aşağıdaki adımları izleyin:

1. Aspose.Slides [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı indeksine göre referans alın.
1. Bir dosya akışı açın.
1. Slaytı bir SVG resmi olarak dosya akışına kaydedin.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Özel Şekil Kimliği ile SVG Oluşturma**

Aspose.Slides, özel bir şekil kimliği ile bir slayttan [SVG](https://docs.fileformat.com/page-description-language/svg/) oluşturmak için kullanılabilir. Bunu yapmak için [SvgShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgshape/) sınıfının `setId` metodunu kullanın. Şekil kimliğini ayarlamak için `CustomSvgShapeFormattingController` kullanılabilir.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **Bir Slayt Küçük Resmi Oluşturma**

Aspose.Slides, slaytların küçük resimlerini oluşturmanıza yardımcı olur. Aspose.Slides kullanarak bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. Aspose.Slides [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı indeksine göre referans alın.
1. Referans alınan slaydın tanımlı bir ölçekle küçük resmini alın.
1. Küçük resmi istediğiniz herhangi bir resim formatında kaydedin.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Kullanıcı Tanımlı Boyutlarla Slayt Küçük Resmi Oluşturma**

Kullanıcı tanımlı boyutlarla bir slayt küçük resmi oluşturmak için aşağıdaki adımları izleyin:

1. Aspose.Slides [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı indeksine göre referans alın.
1. Referans alınan slaydın tanımlı boyutlarla küçük resmini alın.
1. Küçük resmi istediğiniz herhangi bir resim formatında kaydedin.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Konuşmacı Notlarıyla Slayt Küçük Resmi Oluşturma**

Aspose.Slides kullanarak konuşmacı notlarıyla bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. Aspose.Slides [RenderingOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/renderingoptions/) sınıfının bir örneğini oluşturun.
1. `RenderingOptions.setSlidesLayoutOptions` metodunu kullanarak konuşmacı notlarının konumunu ayarlayın.
1. Aspose.Slides [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slaytı indeksine göre referans alın.
1. Referans alınan slaydın, rendering seçenekleriyle küçük resmini alın.
1. Küçük resmi istediğiniz herhangi bir resim formatında kaydedin.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Canlı Örnek**

Aspose.Slides API ile neler yapabileceğinizi görmek için ücretsiz [**Aspose.Slides Viewer**](https://products.aspose.app/slides/tr/viewer/) uygulamasını deneyebilirsiniz:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **SSS**

**Bir Node.js web uygulamasına sunum görüntüleyicisi gömebilir miyim?**

Evet. Sunucu tarafında Aspose.Slides kullanarak slaytları resim veya HTML olarak render edebilir ve tarayıcıda görüntüleyebilirsiniz. Navigasyon ve yakınlaştırma özellikleri, etkileşimli bir deneyim için JavaScript ile uygulanabilir.

**Özel bir görüntüleyicide slaytları göstermek için en iyi yöntem nedir?**

Önerilen yaklaşım, her slaytı bir resim (ör. PNG veya SVG) olarak render etmek veya Aspose.Slides kullanarak HTML'ye dönüştürmek, ardından çıktıyı bir picture box (masaüstü için) veya HTML konteyneri (web için) içinde göstermektir.

**Çok sayıda slaytı olan büyük sunumları nasıl yönetirim?**

Büyük sunumlar için slaytların tembel yüklenmesi veya isteğe bağlı olarak render edilmesi düşünülmelidir. Bu, kullanıcının bir slayta geçtiğinde içeriğin oluşturulması anlamına gelir ve bellek ve yükleme süresini azaltır.