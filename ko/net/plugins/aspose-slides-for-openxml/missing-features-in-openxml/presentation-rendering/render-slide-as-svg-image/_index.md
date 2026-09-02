---
title: 슬라이드를 SVG 이미지로 렌더링
type: docs
weight: 50
url: /ko/net/render-slide-as-svg-image/
---
SVG—Scalable Vector Graphics의 약어—는 2차원 이미지를 렌더링하는 데 사용되는 표준 그래픽 유형 또는 형식입니다. SVG는 XML에 벡터 형태로 이미지를 저장하며, 해당 벡터의 동작이나 외관을 정의하는 세부 정보를 포함합니다.

SVG는 확장성, 상호 작용성, 성능, 접근성, 프로그래머빌리티 등 매우 높은 기준을 충족하는 몇 안 되는 이미지 형식 중 하나입니다. 이러한 이유로 웹 개발에서 널리 사용됩니다.

다음과 같은 상황에서 SVG 파일을 사용할 수 있습니다:

- 프레젠테이션을 매우 큰 형식으로 인쇄하려는 경우. SVG 이미지는 모든 해상도나 수준으로 확장할 수 있습니다. 품질 손실 없이 필요에 따라 여러 번 SVG 이미지를 크기 조정할 수 있습니다.
- 슬라이드의 차트와 그래프를 다양한 매체나 플랫폼에서 사용하려는 경우. 대부분의 뷰어가 SVG 파일을 해석할 수 있습니다.
- 가능한 가장 작은 이미지 크기를 사용해야 하는 경우. SVG 파일은 일반적으로 다른 형식의 고해상도 이미지보다 작으며, 특히 비트맵 기반 형식(JPEG 또는 PNG)보다 작습니다.

Aspose.Slides for .NET을 사용하면 프레젠테이션의 슬라이드를 **SVG** 이미지로 내보낼 수 있습니다. SVG 이미지를 생성하려면 다음과 같이 하십시오:

- Presentation 클래스의 인스턴스를 생성합니다.
- 프레젠테이션의 모든 슬라이드를 순회합니다.
- FileStream을 사용하여 각 슬라이드를 개별 SVG 파일로 저장합니다.

{{% alert color="info" %}} 
다음과 같이 Aspose.Slides for .NET의 PPT를 SVG로 변환하는 기능을 구현한 [무료 웹 애플리케이션](https://products.aspose.app/slides/ko/conversion/ppt-to-svg)을 사용해 보세요.
{{% /alert %}} 

다음은 C# 샘플 코드로, Aspose.Slides를 사용하여 PPT를 SVG로 변환하는 방법을 보여줍니다:

``` csharp
using Aspose.Slides;

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