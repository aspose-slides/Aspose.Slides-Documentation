---
title: "Modern API로 이미지 처리 강화"
linktitle: "Modern API"
type: docs
weight: 280
url: /ko/cpp/modern-api/
keywords:
- System.Drawing
- Modern API
- 그리기
- 슬라이드 썸네일
- 슬라이드에서 이미지로
- 도형 썸네일
- 도형에서 이미지로
- 프레젠테이션 썸네일
- 프레젠테이션을 이미지로
- 이미지 추가
- 그림 추가
- C++
- Aspose.Slides
description: "구식 이미지 API를 C++ Modern API로 교체하여 슬라이드 이미지 처리를 현대화하고 PowerPoint 및 OpenDocument 자동화를 원활하게 구현합니다."
---
## **소개**

현재 Aspose.Slides for C++ 라이브러리는 public API에서 System::Drawing의 다음 클래스에 종속됩니다:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/ko/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/ko/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/ko/cpp/system.drawing/bitmap/)

버전 24.4부터 이 public API는 더 이상 사용되지 않음(deprecated)으로 선언되었습니다.

System::Drawing에 대한 종속성을 public API에서 제거하기 위해 "Modern API"를 추가했습니다. [System::Drawing::Image](https://reference.aspose.com/slides/ko/cpp/system.drawing/image/) 및 [System::Drawing::Bitmap](https://reference.aspose.com/slides/ko/cpp/system.drawing/bitmap/)와 관련된 메서드는 더 이상 사용되지 않음으로 선언되었으며 Modern API의 해당 메서드로 교체해야 합니다. [System::Drawing::Graphics](https://reference.aspose.com/slides/ko/cpp/system.drawing/graphics/)와 관련된 메서드는 더 이상 사용되지 않음으로 선언되었고 직접적인 Modern API 대체 메서드는 없습니다.

현재 버전에서는 System::Drawing 타입에 의존하는 public API를 레거시/더 이상 사용되지 않음으로 취급하십시오. 새 코드와 기존 이미지 처리 워크플로우를 마이그레이션할 때는 Modern API를 사용하십시오.

## **Modern API**

public API에 다음 클래스와 열거형이 추가되었습니다:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) - 래스터 또는 벡터 이미지를 나타냅니다.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imageformat/) - 이미지의 파일 형식을 나타냅니다.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/ko/cpp/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 인터페이스를 인스턴스화하고 작업하기 위한 메서드입니다.

단일 슬라이드 또는 도형을 렌더링하려면 `GetImage`를 사용하십시오. 여러 프레젠테이션 슬라이드를 렌더링하려면 `GetImages`를 사용하십시오. 이미지를 로드하려면 [Images](https://reference.aspose.com/slides/ko/cpp/aspose.slides/images/) 메서드를 사용하고, 프레젠테이션에 추가하려면 `AddImage`와 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)를, 기존 프레젠테이션 이미지를 업데이트하려면 `ReplaceImage`와 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)를 사용하십시오.

새 API 사용의 전형적인 시나리오는 다음과 같습니다:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// 디스크에 있는 파일에서 일회용 IImage 인스턴스를 생성합니다.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// IImage 인스턴스를 프레젠테이션의 이미지 컬렉션에 추가하여 PowerPoint 이미지를 만듭니다.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// 슬라이드 #1에 그림 도형을 추가합니다.
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// 슬라이드 #1을 나타내는 IImage 인스턴스를 가져옵니다.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// 이미지를 디스크에 저장합니다.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **구식 코드를 Modern API로 교체**

전환을 용이하게 하기 위해 새로운 [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/) 인터페이스는 [System::Drawing::Image](https://reference.aspose.com/slides/ko/cpp/system.drawing/image/) 및 [System::Drawing::Bitmap](https://reference.aspose.com/slides/ko/cpp/system.drawing/bitmap/) 클래스의 별도 시그니처를 그대로 반복합니다. 일반적으로 System::Drawing을 사용하는 기존 메서드 호출을 새로운 메서드로 교체하면 됩니다.

### **슬라이드 썸네일 가져오기**

레거시/더 이상 사용되지 않음 API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **도형 썸네일 가져오기**

레거시/더 이상 사용되지 않음 API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **프레젠테이션 썸네일 가져오기**

레거시/더 이상 사용되지 않음 API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **프레젠테이션에 그림 추가**

레거시/더 이상 사용되지 않음 API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **더 이상 사용되지 않는 메서드/속성 및 Modern API 대체**

### **Presentation 클래스**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide 클래스**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Shape 클래스**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection 클래스**
|Method Signature|Replacement Method Signature|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage 클래스**
|Method Signature|Replacement Method Signature|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat 클래스**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData 클래스**
|Method Signature|Replacement Method Signature|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **System::Drawing::Graphics에 대한 API 지원**

[System::Drawing::Graphics](https://reference.aspose.com/slides/ko/cpp/system.drawing/graphics/)와 관련된 메서드는 더 이상 사용되지 않음으로 선언되었으며 직접적인 Modern API 대체 메서드는 없습니다.

Modern API 이미지 렌더링 메서드를 사용하고 [System::Drawing::Graphics](https://reference.aspose.com/slides/ko/cpp/system.drawing/graphics/)에 렌더링하는 API 대신 사용하십시오:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/ko/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**[System::Drawing::Graphics](https://reference.aspose.com/slides/ko/cpp/system.drawing/graphics/)가 삭제된 이유는 무엇입니까?**

[System::Drawing::Graphics](https://reference.aspose.com/slides/ko/cpp/system.drawing/graphics/)에 대한 지원은 public API에서 더 이상 사용되지 않음으로 지정되어 렌더링 및 이미지 작업을 통합하고, 플랫폼별 종속성을 제거하며, [IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)를 통한 크로스 플랫폼 접근 방식으로 전환하기 위함입니다. [System::Drawing::Graphics](https://reference.aspose.com/slides/ko/cpp/system.drawing/graphics/) 대신 `GetImage` 또는 `GetImages`를 사용하십시오.

**[IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)가 [System::Drawing::Image](https://reference.aspose.com/slides/ko/cpp/system.drawing/image/) 및 [System::Drawing::Bitmap](https://reference.aspose.com/slides/ko/cpp/system.drawing/bitmap/)에 비해 실용적인 이점은 무엇입니까?**

[IImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iimage/)은 래스터 및 벡터 이미지를 모두 다루도록 통합하고, [ImageFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imageformat/)을 통해 다양한 형식으로 저장을 간소화하며, `System::Drawing`에 대한 의존성을 줄이고, 환경 간 코드 이식성을 높입니다.

**Modern API가 썸네일 생성 성능에 영향을 미칩니까?**

`GetThumbnail`을 `GetImage`로 전환해도 시나리오가 악화되지 않습니다. 새로운 메서드는 옵션 및 크기로 이미지를 생성하는 동일한 기능을 제공하며, 렌더링 옵션 지원을 유지합니다. 구체적인 이득 또는 감소는 시나리오에 따라 다르지만 기능적으로 대체 메서드는 동등합니다.