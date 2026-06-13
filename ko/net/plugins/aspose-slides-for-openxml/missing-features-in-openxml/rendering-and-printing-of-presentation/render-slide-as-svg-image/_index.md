---
title: 슬라이드를 SVG 이미지로 렌더링
type: docs
weight: 50
url: /ko/net/render-slide-as-svg-image/
---
SVG—Scalable Vector Graphics의 약어—는 2차원 이미지를 렌더링하는 데 사용되는 표준 그래픽 유형 또는 포맷입니다. SVG는 이미지의 동작이나 모양을 정의하는 세부 정보를 포함한 XML 형식의 벡터로 이미지를 저장합니다. 

SVG는 확장성, 상호작용성, 성능, 접근성, 프로그래밍 가능성 등과 같은 높은 기준을 충족하는 몇 안 되는 이미지 포맷 중 하나입니다. 이러한 이유로 웹 개발에서 널리 사용됩니다. 

다음과 같은 상황에서 SVG 파일을 사용할 수 있습니다:

- 프레젠테이션을 매우 큰 형식으로 인쇄하려는 경우. SVG 이미지는 어떤 해상도나 수준으로든 확대할 수 있습니다. 품질을 손상시키지 않고 필요에 따라 SVG 이미지를 여러 번 크기 조정할 수 있습니다.
- 슬라이드의 차트와 그래프를 다양한 매체나 플랫폼에서 사용하려는 경우. 대부분의 뷰어가 SVG 파일을 해석할 수 있습니다. 
- 가능한 가장 작은 이미지 크기가 필요한 경우. SVG 파일은 일반적으로 다른 포맷의 고해상도 이미지보다 작으며, 특히 비트맵 기반 포맷(JPEG 또는 PNG)보다 작습니다.

Aspose.Slides for .NET를 사용하면 프레젠테이션의 슬라이드를 **SVG** 이미지로 내보낼 수 있습니다. SVG 이미지를 생성하려면 다음과 같이 하세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- 프레젠테이션의 모든 슬라이드를 순회합니다.
- 각 슬라이드를 FileStream을 사용하여 개별 SVG 파일에 기록합니다.

{{% alert color="primary" %}} 
무료 웹 애플리케이션을 사용해 보실 수 있습니다. 이 애플리케이션에서는 Aspose.Slides for .NET의 PPT를 SVG로 변환하는 기능을 구현했습니다. [무료 웹 애플리케이션](https://products.aspose.app/slides/ko/conversion/ppt-to-svg)
{{% /alert %}} 

다음 C# 샘플 코드는 Aspose.Slides를 사용하여 PPT를 SVG로 변환하는 방법을 보여줍니다:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```