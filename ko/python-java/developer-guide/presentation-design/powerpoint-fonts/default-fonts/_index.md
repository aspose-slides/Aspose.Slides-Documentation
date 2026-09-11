---
title: Python via Java에서 기본 프레젠테이션 글꼴 지정
linktitle: 기본 글꼴
type: docs
weight: 30
url: /ko/python-java/default-font/
keywords:
- 기본 글꼴
- 일반 글꼴
- 표준 글꼴
- 아시아 글꼴
- PDF 내보내기
- XPS 내보내기
- 이미지 내보내기
- 파워포인트
- 오픈문서
- 프레젠테이션
- 파이썬
- 자바
- Aspose.Slides
description: "Python via Java용 Aspose.Slides에서 기본 글꼴을 설정하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP)를 PDF, XPS 및 이미지로 올바르게 변환하도록 합니다."
---
## **개요**

Aspose.Slides는 프레젠테이션이 렌더링될 때 사용되는 기본 글꼴을 지정할 수 있게 합니다. 이는 슬라이드 썸네일을 생성하거나 프레젠테이션을 PDF 및 XPS와 같은 형식으로 내보낼 때 유용합니다. 기본 글꼴은 프레젠테이션을 로드하기 전에 [LoadOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/)을 통해 구성됩니다.

[setDefaultRegularFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) 메서드는 일반 텍스트에 대한 기본 글꼴을 정의하고, [setDefaultAsianFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) 은 아시아 언어 텍스트에 대한 기본 글꼴을 정의합니다. 이러한 옵션을 설정한 후 프레젠테이션을 로드하고 지정된 글꼴을 사용하여 렌더링할 수 있습니다.

## **프레젠테이션 렌더링을 위한 기본 글꼴 사용**

Aspose.Slides를 사용하면 PDF, XPS 또는 썸네일로 프레젠테이션을 렌더링할 때 기본 글꼴을 설정할 수 있습니다. 이 섹션에서는 Python via Java용 Aspose.Slides를 사용하여 일반 텍스트와 아시아 텍스트에 대한 기본 글꼴을 정의하는 방법을 보여줍니다:

1. [LoadOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/)의 인스턴스를 생성합니다.
2. 원하는 글꼴을 지정하려면 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setDefaultRegularFont)을 사용합니다. 다음 예제는 Wingdings을 사용합니다.
3. 원하는 글꼴을 지정하려면 [setDefaultAsianFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setDefaultAsianFont)을 사용합니다. 다음 예제 또한 Wingdings을 사용합니다.
4. 로드 옵션을 사용하여 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)으로 프레젠테이션을 로드합니다.
5. 슬라이드 썸네일, PDF 및 XPS를 생성하여 결과를 확인합니다.

다음 예제는 이러한 단계들을 구현합니다:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# 로드 옵션을 사용하여 기본 일반 및 아시아 글꼴을 정의합니다.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# 프레젠테이션을 로드합니다.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # 슬라이드 썸네일을 생성합니다.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # 이미지를 디스크에 저장합니다.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # PDF를 생성합니다.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # XPS 문서를 생성합니다.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **자주 묻는 질문**

**기본 일반 및 아시아 글꼴이 정확히 무엇에 영향을 줍니까—내보내기만, 아니면 썸네일, PDF, XPS, HTML, SVG에도 영향을 줍니까?**

기본 글꼴은 모든 지원되는 출력에 대한 렌더링 파이프라인에 참여합니다. 여기에는 슬라이드 썸네일, [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/python-java/convert-powerpoint-to-xps/), [raster images](/slides/ko/python-java/convert-powerpoint-to-png/), [HTML](/slides/ko/python-java/convert-powerpoint-to-html/), 및 [SVG](/slides/ko/python-java/render-a-slide-as-an-svg-image/)가 포함되며, Aspose.Slides는 이러한 대상들 간에 동일한 레이아웃 및 글리프 해석 로직을 사용합니다.

**렌더링 없이 단순히 PPTX를 읽고 저장하는 경우에도 기본 글꼴이 적용되나요?**

아니요. 기본 글꼴은 텍스트의 측정 및 그리기가 필요할 때만 영향을 미칩니다. 프레젠테이션을 그대로 열고 저장하는 경우 저장된 글꼴 실행이나 파일 구조가 변경되지 않습니다. 기본 글꼴은 텍스트를 렌더링하거나 재배치하는 작업 중에 적용됩니다.

**내가 직접 만든 글꼴 폴더를 추가하거나 메모리에서 글꼴을 제공하면 기본 글꼴 선택에 반영되나요?**

예. [Custom font sources](/slides/ko/python-java/custom-font/)는 엔진이 사용할 수 있는 글꼴 패밀리와 글리프 카탈로그를 확장합니다. 기본 글꼴 및 모든 [fallback rules](/slides/ko/python-java/fallback-font/)은 먼저 이러한 소스를 참조하여 서버 및 컨테이너에서 보다 신뢰할 수 있는 커버리지를 제공합니다.

**기본 글꼴이 텍스트 메트릭(커닝, 전진)과 라인 브레이크 및 래핑에 영향을 미치나요?**

예. 글꼴을 변경하면 글리프 메트릭이 바뀌어 렌더링 중 라인 브레이크, 래핑 및 페이지 매김이 달라질 수 있습니다. 레이아웃 안정성을 위해 [embed the original fonts](/slides/ko/python-java/embedded-font/)을 사용하거나 메트릭이 호환되는 기본 및 대체 패밀리를 선택하십시오.

**프레젠테이션에 사용된 모든 글꼴이 임베드된 경우 기본 글꼴을 설정할 의미가 있나요?**

대부분의 경우 필요하지 않습니다. [embedded fonts](/slides/ko/python-java/embedded-font/)이 이미 일관된 표시를 보장하기 때문입니다. 그러나 임베드되지 않은 문자나 임베드된 텍스트와 비임베드된 텍스트가 혼합된 파일에 대해 기본 글꼴은 안전망 역할을 할 수 있습니다.