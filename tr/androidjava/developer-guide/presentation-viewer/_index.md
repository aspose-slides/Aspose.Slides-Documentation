---
title: Android'de Sunum Görüntüleyicisi Oluştur
linktitle: Sunum Görüntüleyicisi
type: docs
weight: 50
url: /tr/androidjava/presentation-viewer/
keywords:
- sunumu görüntüle
- sunum görüntüleyicisi
- sunum görüntüleyicisi oluştur
- PPT görüntüle
- PPTX görüntüle
- ODP görüntüle
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak Java'da özel bir sunum görüntüleyicisi oluşturun. Microsoft PowerPoint olmadan PowerPoint ve OpenDocument dosyalarını kolayca görüntüleyin."
---
## **Giriş**

Aspose.Slides for Android via Java, slayt içeren sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, örneğin Microsoft PowerPoint’te sunumları açarak görüntülenebilir. Ancak, bazen geliştiricilerin slaytları tercih ettikleri görüntü görüntüleyicisinde resim olarak görüntülemeleri veya kendi sunum görüntüleyicilerini oluşturmaları gerekebilir. Bu gibi durumlarda, Aspose.Slides tek bir slaytı resim olarak dışa aktarmanıza olanak tanır. Bu makale bunu nasıl yapacağınızı açıklar.

## **Bir Slayttan SVG Görüntüsü Oluşturma**

Aspose.Slides kullanarak bir sunum slaytından SVG görüntüsü oluşturmak için, lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
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

## **Özel Şekil Kimliğiyle SVG Oluşturma**

Aspose.Slides, özel bir şekil kimliğiyle bir slayttan [SVG](https://docs.fileformat.com/page-description-language/svg/) oluşturmak için kullanılabilir. Bunu yapmak için, [ISvgShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isvgshape/) içindeki `setId` yöntemini kullanın. Şekil kimliğini ayarlamak için `CustomSvgShapeFormattingController` kullanılabilir.

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Bir Slayt Küçük Resmi Oluşturma**

Aspose.Slides, slaytların küçük resimlerini oluşturmanıza yardımcı olur. Aspose.Slides kullanarak bir slaytın küçük resmini oluşturmak için, lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
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

Kullanıcı tanımlı boyutlarla bir slayt küçük resmi oluşturmak için, lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayt referansını indeksine göre alın.
1. Referans alınan slaytın tanımlı boyutlarla küçük resim görüntüsünü alın.
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Konuşmacı Notlarıyla Slayt Küçük Resmi Oluşturma**

Aspose.Slides kullanarak konuşmacı notlarıyla bir slaytın küçük resmini oluşturmak için, lütfen aşağıdaki adımları izleyin:

1. [RenderingOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/renderingoptions/) sınıfının bir örneğini oluşturun.
1. Konuşmacı notlarının konumunu ayarlamak için `RenderingOptions.setSlidesLayoutOptions` yöntemini kullanın.
1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayt referansını indeksine göre alın.
1. Referans alınan slaytı, rendering seçenekleriyle küçük resim görüntüsü olarak alın.
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

Aspose.Slides API ile neler uygulayabileceğinizi görmek için ücretsiz [**Aspose.Slides Viewer**](https://products.aspose.app/slides/tr/viewer/) uygulamasını deneyebilirsiniz:

![Çevrimiçi PowerPoint Görüntüleyici](online-PowerPoint-viewer.png)

## **SSS**

**Bir web uygulamasına sunum görüntüleyicisi gömebilir miyim?**

Evet. Sunumları sunucu tarafında görüntüleri veya HTML olarak işlemek ve tarayıcıda göstermek için Aspose.Slides’i kullanabilirsiniz. Gezinti ve yakınlaştırma özellikleri, etkileşimli bir deneyim için JavaScript ile uygulanabilir.

**Özel bir görüntüleyicide slaytları göstermek için en iyi yol nedir?**

Önerilen yöntem, her slaytı bir görüntü (ör. PNG veya SVG) olarak işlemek veya Aspose.Slides kullanarak HTML’ye dönüştürmek, ardından çıktıyı bir resim kutusu (masaüstü için) veya HTML konteyneri (web için) içinde görüntülemektir.

**Çok sayıda slaytı olan büyük sunumları nasıl yönetirim?**

Büyük sunumlar için, slaytların tembel yükleme (lazy-loading) veya ihtiyaç duyulduğunda işlenmesini düşünün. Bu, bir slaytın içeriğinin yalnızca kullanıcı ona geçtiğinde üretilmesi anlamına gelir ve bellek ve yükleme süresini azaltır.