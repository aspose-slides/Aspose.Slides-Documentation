---
title: C++'ta Sunum Görüntüleyicisi Oluştur
linktitle: Sunum Görüntüleyicisi
type: docs
weight: 50
url: /tr/cpp/presentation-viewer/
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
- C++
- Aspose.Slides
description: "Aspose.Slides kullanarak C++'ta özel bir sunum görüntüleyicisi oluşturun. Microsoft PowerPoint olmadan PowerPoint ve OpenDocument dosyalarını kolayca görüntüleyin."
---
## **Giriş**

Aspose.Slides for C++ sunum dosyalarını slaytlarla oluşturmak için kullanılır. Bu slaytlar, örneğin Microsoft PowerPoint'te sunumları açarak görüntülenebilir. Ancak bazen geliştiriciler slaytları tercih ettikleri bir resim görüntüleyicide görüntülemek veya kendi sunum görüntüleyicilerini oluşturmak isteyebilirler. Böyle durumlarda Aspose.Slides, tek bir slaytı resim olarak dışa aktarmanıza olanak tanır. Bu makale bunu nasıl yapacağınızı açıklar.

## **Bir Slayttan SVG Görüntüsü Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slaytı indeksine göre referans alın.  
1. Bir dosya akışı açın.  
1. Slaytı bir SVG görüntüsü olarak dosya akışına kaydedin.  

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Özel Şekil Kimliğiyle SVG Oluşturma**

Aspose.Slides, bir slayttan özel bir şekil kimliğiyle bir [SVG](https://docs.fileformat.com/page-description-language/svg/) oluşturmak için kullanılabilir. Bunu yapmak için [ISvgShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/isvgshape/) üzerindeki `set_Id` metodunu kullanın. Şekil kimliğini ayarlamak için `CustomSvgShapeFormattingController` kullanılabilir.  

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Bir Slayt Küçük Resmi Oluşturma**

Aspose.Slides, slaytların küçük resim görüntülerini oluşturmanıza yardımcı olur. Aspose.Slides kullanarak bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slaytı indeksine göre referans alın.  
1. Referans alınan slaytın tanımlı ölçekle küçük resim görüntüsünü alın.  
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.  

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Kullanıcı Tanımlı Boyutlarla Slayt Küçük Resmi Oluşturma**

Kullanıcı tanımlı boyutlarla bir slayt küçük resmi oluşturmak için aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slaytı indeksine göre referans alın.  
1. Referans alınan slaytın tanımlı boyutlarla küçük resim görüntüsünü alın.  
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.  

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Konuşmacı Notlarıyla Slayt Küçük Resmi Oluşturma**

Aspose.Slides kullanarak konuşmacı notlarıyla bir slaytın küçük resmini oluşturmak için aşağıdaki adımları izleyin:

1. [RenderingOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/renderingoptions/) sınıfının bir örneğini oluşturun.  
1. Konuşmacı notlarının konumunu ayarlamak için `RenderingOptions.set_SlidesLayoutOptions` metodunu kullanın.  
1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slaytı indeksine göre referans alın.  
1. Referans alınan slaytın küçük resim görüntüsünü render seçenekleriyle alın.  
1. Küçük resim görüntüsünü istediğiniz herhangi bir görüntü formatında kaydedin.  

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Canlı Örnek**

Aspose.Slides API ile neler yapabileceğinizi görmek için ücretsiz olarak [**Aspose.Slides Viewer**](https://products.aspose.app/slides/tr/viewer/) uygulamasını deneyebilirsiniz:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **SSS**

**Bir sunum görüntüleyiciyi bir web uygulamasına gömebilir miyim?**

Evet. Sunum slaytlarını görüntüler olarak veya HTML olarak sunucu tarafında Aspose.Slides ile işleyebilir ve tarayıcıda görüntüleyebilirsiniz. Gezinme ve yakınlaştırma özellikleri, etkileşimli bir deneyim için JavaScript ile uygulanabilir.

**Özel bir görüntüleyicide slaytları göstermek için en iyi yöntem nedir?**

Önerilen yaklaşım, her slaytı bir görüntü (ör. PNG veya SVG) olarak render etmek veya Aspose.Slides kullanarak HTML'ye dönüştürmek, ardından çıktıyı bir resim kutusunda (masaüstü için) veya HTML konteynerinde (web için) göstermektir.

**Birçok slaytı olan büyük sunumları nasıl yönetebilirim?**

Büyük sunumlar için, slaytların tembel yükleme (lazy-loading) veya isteğe bağlı render edilmesini düşünün. Bu, slayt içeriğinin yalnızca kullanıcı ona geçtiğinde oluşturulması anlamına gelir ve bellek ile yükleme süresini azaltır.