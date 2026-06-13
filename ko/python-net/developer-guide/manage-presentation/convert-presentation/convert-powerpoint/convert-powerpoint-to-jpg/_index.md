---
title: Python에서 PPT, PPTX 및 ODP를 JPG로 변환
linktitle: 슬라이드를 JPG 이미지로 변환
type: docs
weight: 60
url: /ko/python-net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint를 JPG로 변환
- 프레젠테이션을 JPG로 변환
- 슬라이드를 JPG로 변환
- PPT를 JPG로 변환
- PPTX를 JPG로 변환
- ODP를 JPG로 변환
- PowerPoint에서 JPG
- 프레젠테이션에서 JPG
- 슬라이드에서 JPG
- PPT에서 JPG
- PPTX에서 JPG
- ODP에서 JPG
- PowerPoint를 JPEG로 변환
- 프레젠테이션을 JPEG로 변환
- 슬라이드를 JPEG로 변환
- PPT를 JPEG로 변환
- PPTX를 JPEG로 변환
- ODP를 JPEG로 변환
- PowerPoint에서 JPEG
- 프레젠테이션에서 JPEG
- 슬라이드에서 JPEG
- PPT에서 JPEG
- PPTX에서 JPEG
- ODP에서 JPEG
- Python
- Aspose.Slides
description: "Python 몇 줄의 코드만으로 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드를 고품질 JPEG 이미지로 변환하는 방법을 배웁니다. 웹 사용, 공유 및 보관을 위해 프레젠테이션을 최적화하세요. 지금 전체 가이드를 읽어보세요!"
---
## **소개**

PowerPoint 및 OpenDocument 프레젠테이션을 JPG 이미지로 변환하면 슬라이드 공유, 성능 최적화 및 웹사이트나 애플리케이션에 콘텐츠를 삽입하는 데 도움이 됩니다. Aspose.Slides for Python을 사용하면 PPTX, PPT 및 ODP 파일을 고품질 JPEG 이미지로 변환할 수 있습니다. 이 가이드는 변환 방법을 설명합니다.

이러한 기능을 통해 자체 프레젠테이션 뷰어를 구현하고 각 슬라이드에 대한 썸네일을 만들 수 있습니다. 프레젠테이션 슬라이드를 복사로부터 보호하거나 읽기 전용 모드로 프레젠테이션을 시연하려는 경우에 유용할 수 있습니다. Aspose.Slides를 사용하면 전체 프레젠테이션이나 특정 슬라이드를 이미지 형식으로 변환할 수 있습니다.

## **프레젠테이션 슬라이드를 JPG 이미지로 변환**

PPT, PPTX 또는 ODP 파일을 JPG로 변환하는 단계는 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. [Presentation.slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slides/ko/) 컬렉션에서 [Slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/) 유형의 슬라이드 객체를 가져옵니다.
3. [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#float-float) 메서드를 사용하여 슬라이드 이미지를 생성합니다.
4. 이미지 객체에서 [IImage.save(filename, format)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/save/#str-imageformat) 메서드를 호출합니다. 출력 파일 이름과 이미지 형식을 인수로 전달합니다.

{{% alert color="primary" %}}
**Note:** PPT, PPTX 또는 ODP를 JPG로 변환하는 방식은 Aspose.Slides Python API에서 다른 형식으로 변환하는 방식과 다릅니다. 다른 형식의 경우 일반적으로 [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) 메서드를 사용합니다. 그러나 JPG 변환에서는 [IImage.save(filename, format)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/save/#str-imageformat) 메서드를 사용해야 합니다.
{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # 이미지를 JPEG 형식으로 디스크에 저장합니다.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **맞춤형 크기로 슬라이드를 JPG로 변환**

결과 JPG 이미지의 크기를 변경하려면 [Slide.get_image(image_size)](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) 메서드에 이미지 크기를 전달하여 설정할 수 있습니다. 이를 통해 특정 너비와 높이 값을 가진 이미지를 생성할 수 있어 해상도와 종횡비에 대한 요구 사항을 충족합니다. 이러한 유연성은 웹 애플리케이션, 보고서 또는 문서용 이미지를 생성할 때 특히 유용하며, 정확한 이미지 크기가 필요합니다.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # 지정된 크기의 슬라이드 이미지를 생성합니다.
        with slide.get_image(image_size) as thumbnail:
            # 이미지를 JPEG 형식으로 디스크에 저장합니다.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **슬라이드를 이미지로 저장할 때 주석 렌더링**

Aspose.Slides for Python은 프레젠테이션 슬라이드를 JPG 이미지로 변환할 때 주석을 렌더링할 수 있는 기능을 제공합니다. 이 기능은 PowerPoint 프레젠테이션에 협업자가 추가한 주석, 피드백 또는 토론을 보존하는 데 특히 유용합니다. 이 옵션을 활성화하면 생성된 이미지에 주석이 표시되어 원본 프레젠테이션 파일을 열지 않고도 피드백을 검토하고 공유하기 쉬워집니다.

예를 들어, 주석이 포함된 슬라이드가 있는 프레젠테이션 파일 "sample.pptx"가 있다고 가정해 보겠습니다:

![주석이 있는 슬라이드](slide_with_comments.png)

다음 Python 코드는 주석을 보존하면서 슬라이드를 JPG 이미지로 변환합니다:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # 슬라이드 주석에 대한 옵션을 설정합니다.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # 첫 번째 슬라이드를 이미지로 변환합니다.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

결과:

![주석이 포함된 JPG 이미지](image_with_comments.png)

## **관련 항목**

PPT, PPTX 또는 ODP를 이미지로 변환하는 다른 옵션을 확인하십시오, 예:

- [PowerPoint를 GIF로 변환](/slides/ko/python-net/convert-powerpoint-to-animated-gif/)
- [PowerPoint를 PNG로 변환](/slides/ko/python-net/convert-powerpoint-to-png/)
- [PowerPoint를 TIFF로 변환](/slides/ko/python-net/convert-powerpoint-to-tiff/)
- [PowerPoint를 SVG로 변환](/slides/ko/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Aspose.Slides가 PowerPoint를 JPG 이미지로 변환하는 방법을 확인하려면, 다음 무료 온라인 변환기를 사용해 보세요: PowerPoint [PPTX를 JPG로](https://products.aspose.app/slides/ko/conversion/pptx-to-jpg) 및 [PPT를 JPG로](https://products.aspose.app/slides/ko/conversion/ppt-to-jpg). 
{{% /alert %}} 

![무료 온라인 PPTX to JPG 변환기](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}
Aspose는 [FREE Collage 웹 앱](https://products.aspose.app/slides/ko/collage)을 제공합니다. 이 온라인 서비스를 사용하면 [JPG를 JPG로](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG를 PNG로 이미지 병합, [photo grids](https://products.aspose.app/slides/ko/collage/photo-grid) 만들기 등을 할 수 있습니다. 

이 문서에 설명된 동일한 원칙을 사용하여 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 자세한 내용은 다음 페이지를 참조하십시오: 변환 [이미지를 JPG로](https://products.aspose.com/slides/ko/python-net/conversion/image-to-jpg/); 변환 [JPG를 이미지로](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-image/); 변환 [JPG를 PNG로](https://products.aspose.com/slides/ko/python-net/conversion/jpg-to-png/), 변환 [PNG를 JPG로](https://products.aspose.com/slides/ko/python-net/conversion/png-to-jpg/); 변환 [PNG를 SVG로](https://products.aspose.com/slides/ko/python-net/conversion/png-to-svg/), 변환 [SVG를 PNG로](https://products.aspose.com/slides/ko/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**이 방법은 배치 변환을 지원합니까?**

예, Aspose.Slides를 사용하면 여러 슬라이드를 한 번에 JPG로 배치 변환할 수 있습니다.

**변환이 SmartArt, 차트 및 기타 복잡한 개체를 지원합니까?**

예, Aspose.Slides는 SmartArt, 차트, 표, 도형 등 모든 콘텐츠를 렌더링합니다. 그러나 맞춤형 또는 누락된 글꼴을 사용하는 경우 PowerPoint에 비해 렌더링 정확도가 약간 다를 수 있습니다.

**처리할 수 있는 슬라이드 수에 제한이 있습니까?**

Aspose.Slides 자체는 처리할 수 있는 슬라이드 수에 엄격한 제한을 두지 않습니다. 그러나 대용량 프레젠테이션이나 고해상도 이미지를 다룰 때 메모리 부족 오류가 발생할 수 있습니다.