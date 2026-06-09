---
title: .NET'te Sunum Görüntüleyicisi Oluştur
linktitle: Sunum Görüntüleyici
type: docs
weight: 50
url: /tr/net/presentation-viewer/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides kullanarak .NET'te özel bir sunum görüntüleyici oluşturun. Microsoft PowerPoint olmadan PowerPoint ve OpenDocument dosyalarını kolayca görüntüleyin."
---
## **Giriş**

Aspose.Slides for .NET, slaytlarla sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, örneğin Microsoft PowerPoint’te sunumları açarak görüntülenebilir. Ancak, geliştiriciler bazen slaytları tercih ettikleri bir görüntüleyicide resim olarak görmek veya özel bir sunum görüntüleyicide kullanmak isteyebilir. Böyle durumlarda, Aspose.Slides tek tek slaytları resim olarak dışa aktarmanıza olanak tanır. Bu makale bunu nasıl yapacağınızı açıklar.

## **Bir Slayttan SVG Görüntüsü Oluşturma**

Aspose.Slides kullanarak bir sunum slaytından SVG görüntüsü oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksine göre slayta bir referans alın.
1. Bir dosya akışı açın.
1. Slaytı dosya akışına SVG görüntüsü olarak kaydedin.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Özel Şekil Kimliğiyle SVG Oluşturma**

Aspose.Slides, özel bir şekil `ID` si ile bir slayttan [SVG](https://docs.fileformat.com/page-description-language/svg/) oluşturmak için kullanılabilir. Bunu başarmak için, [ISvgShape](https://reference.aspose.com/slides/tr/net/aspose.slides.export/isvgshape) arayüzündeki Id özelliğini kullanın. `CustomSvgShapeFormattingController` sınıfı, şekil kimliğini ayarlamak için kullanılabilir.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Bir Slayt Küçük Resmi Oluşturma**

Aspose.Slides, slaytların küçük resimlerini oluşturmanıza yardımcı olur. Aspose.Slides kullanarak bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksine göre slayta bir referans alın.
1. Referans alınan slayttan istediğiniz ölçekte bir küçük resim oluşturun.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Kullanıcı Tanımlı Boyutlarla Slayt Küçük Resmi Oluşturma**

Kullanıcı tanımlı boyutlarla bir slayt küçük resmi oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksine göre slayta bir referans alın.
1. Referans alınan slayttan belirtilen boyutlarla bir küçük resim oluşturun.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Konuşmacı Notlarıyla Slayt Küçük Resmi Oluşturma**

Aspose.Slides kullanarak konuşmacı notları içeren bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. [RenderingOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/renderingoptions/) sınıfının bir örneğini oluşturun.
1. Konuşmacı notlarının konumunu ayarlamak için `RenderingOptions.SlidesLayoutOptions` özelliğini kullanın.
1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksine göre slayta bir referans alın.
1. Referans alınan slaytı, render seçeneklerini kullanarak bir küçük resim oluşturun.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Canlı Örnek**

[Aspose.Slides Viewer](https://products.aspose.app/slides/tr/viewer/) ücretsiz uygulamasını deneyerek Aspose.Slides API ile neler yapabileceğinizi görün:

[![Çevrimiçi PowerPoint Görüntüleyici](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/tr/viewer/)

## **SSS**

**ASP.NET web uygulamasına bir sunum görüntüleyici yerleştirebilir miyim?**

Evet. Aspose.Slides'ı sunucu tarafında kullanarak slaytları görüntü veya HTML olarak render edebilir ve tarayıcıda görüntüleyebilirsiniz. Gezinti ve yakınlaştırma özellikleri, etkileşimli bir deneyim için JavaScript ile uygulanabilir.

**Özel bir .NET görüntüleyicide slaytları göstermek için en iyi yöntem nedir?**

Önerilen yöntem, her slaytı bir görüntü (örn. PNG veya SVG) olarak render etmek veya Aspose.Slides kullanarak HTML'ye dönüştürmek, ardından çıktıyı bir resim kutusunda (masaüstü için) veya bir HTML konteynerinde (web için) göstermektir.

**Çok sayıda slaytı olan büyük sunumları nasıl yönetirim?**

Büyük sunumlar için, slaytların tembel yükleme (lazy-loading) veya isteğe bağlı render edilmesini düşünün. Bu, bir slaytın içeriğinin yalnızca kullanıcı ona gittiğinde oluşturulması anlamına gelir ve bellek ile yükleme süresini azaltır.