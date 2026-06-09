---
title: Java'da Sunum Görüntüleyicisi Oluşturun
linktitle: Sunum Görüntüleyicisi
type: docs
weight: 50
url: /tr/java/presentation-viewer/
keywords:
- sunumu görüntüle
- sunum görüntüleyici
- sunum görüntüleyici oluştur
- PPT'yi görüntüle
- PPTX'i görüntüle
- ODP'yi görüntüle
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides kullanarak Java'da özel bir sunum görüntüleyicisi oluşturun. Microsoft PowerPoint olmadan PowerPoint ve OpenDocument dosyalarını kolayca görüntüleyin."
---
## **Giriş**

Aspose.Slides for Java, slayt içeren sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, örneğin Microsoft PowerPoint'te sunumları açarak görüntülenebilir. Ancak, bazen geliştiricilerin slaytları tercih ettikleri bir görüntü görüntüleyicide görüntülemeleri veya kendi sunum görüntüleyicilerini oluşturmaları gerekebilir. Böyle durumlarda, Aspose.Slides tek bir slaytı görüntü olarak dışa aktarmanıza olanak tanır. Bu makale bunun nasıl yapılacağını açıklar.

## **Bir Slayttan SVG Görüntüsü Oluşturma**

Aspose.Slides kullanarak bir sunum slaytından SVG görüntüsü oluşturmak için, aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayt referansını indeksine göre alın.
1. Bir dosya akışı açın.
1. Slaytı dosya akışına SVG görüntüsü olarak kaydedin.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Özel Şekil Kimliği ile SVG Oluşturma**

Aspose.Slides, özel bir şekil kimliğiyle bir slayttan [SVG](https://docs.fileformat.com/page-description-language/svg/) oluşturmak için kullanılabilir. Bunu yapmak için, [ISvgShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isvgshape/) arayüzündeki `setId` metodunu kullanın. `CustomSvgShapeFormattingController` şekil kimliğini ayarlamak için kullanılabilir.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Slayt Küçük Resmi Oluşturma**

Aspose.Slides, slaytların küçük resimlerini oluşturmanıza yardımcı olur. Aspose.Slides kullanarak bir slaytın küçük resmini oluşturmak için, lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayt referansını indeksine göre alın.
1. Referans alınan slaytın tanımlı ölçekle küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Kullanıcı Tanımlı Boyutlarla Slayt Küçük Resmi Oluşturma**

Kullanıcı tanımlı boyutlarla bir slayt küçük resmi görüntüsü oluşturmak için, lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayt referansını indeksine göre alın.
1. Referans alınan slaytın tanımlı boyutlarla küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Konuşmacı Notlarıyla Slayt Küçük Resmi Oluşturma**

Aspose.Slides kullanarak konuşmacı notlarıyla bir slaytın küçük resmini oluşturmak için, lütfen aşağıdaki adımları izleyin:

1. [RenderingOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/renderingoptions/) sınıfının bir örneğini oluşturun.
1. `RenderingOptions.setSlidesLayoutOptions` metodunu kullanarak konuşmacı notlarının konumunu ayarlayın.
1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayt referansını indeksine göre alın.
1. Referans alınan slaytın, render seçenekleriyle küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Canlı Örnek**

[**Aspose.Slides Viewer**](https://products.aspose.app/slides/tr/viewer/) ücretsiz uygulamasını deneyebilir ve Aspose.Slides API ile ne uygulayabileceğinizi görebilirsiniz:

![Çevrimiçi PowerPoint Görüntüleyici](online-PowerPoint-viewer.png)

## **SSS**

**Bir sunum görüntüleyiciyi bir web uygulamasına gömebilir miyim?**

Evet. Aspose.Slides'ı sunucu tarafında kullanarak slaytları görüntü ya da HTML olarak işleyebilir ve tarayıcıda görüntüleyebilirsiniz. Navigasyon ve yakınlaştırma özellikleri, etkileşimli bir deneyim için JavaScript ile uygulanabilir.

**Özel bir görüntüleyicide slaytları görüntülemenin en iyi yolu nedir?**

Önerilen yaklaşım, her bir slaytı bir görüntü (ör. PNG veya SVG) olarak işlemek ya da Aspose.Slides kullanarak HTML'ye dönüştürmek, ardından çıktıyı bir picture box içinde (masaüstü için) ya da bir HTML konteynerinde (web için) görüntülemektir.

**Birçok slaytı olan büyük sunumları nasıl yönetebilirim?**

Büyük sunumlar için, slaytların tembel yükleme (lazy-loading) veya isteğe bağlı işlenmesini düşünün. Bu, bir slaytın içeriğinin yalnızca kullanıcı ona geçtiğinde oluşturulması anlamına gelir ve bellek ile yükleme süresini azaltır.