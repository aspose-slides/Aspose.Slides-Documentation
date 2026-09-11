---
title: Python via Java를 사용한 프레젠테이션 차트 내보내기
linktitle: 차트 내보내기
type: docs
weight: 90
url: /ko/python-java/export-chart/
keywords:
- 차트
- 차트를 이미지로
- 차트 이미지
- 차트 이미지 추출
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 프레젠테이션 차트를 내보내는 방법을 배우세요. PPT 및 PPTX 형식을 지원하며, 보고서를 모든 워크플로에 원활하게 연동할 수 있습니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션에서 차트를 이미지로 내보낼 수 있습니다. 이 문서에서는 차트에서 이미지를 가져와 저장하는 방법을 보여줍니다. 이는 PowerPoint 프레젠테이션 외부에서 차트 시각 자료를 재사용해야 할 때 유용합니다.

기본 이미지 내보내기 워크플로우 외에도, 이 문서에서는 차트 내용을 SVG로 저장하기, 렌더링 옵션을 통해 출력 크기 제어하기, 레이블 및 범례 모양을 유지하기 위해 글꼴을 로드하기, 그리고 렌더링 중 테마, 스타일, 채우기 및 효과와 같은 원본 프레젠테이션 형식을 유지하는 등 일반적인 내보내기 관련 질문을 다룹니다.

## **차트 이미지 가져오기**
Aspose.Slides for Python via Java는 특정 차트의 이미지를 추출하는 것을 지원합니다. 다음 예제에서는 이를 수행하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**차트를 래스터 이미지가 아닌 벡터(SVG)로 내보낼 수 있나요?**  
예. 차트는 도형이며, 그 내용을 [shape-to-SVG saving method](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#writeAsSvgToBytes) 를 사용하여 SVG로 저장할 수 있습니다.

**내보낸 차트의 정확한 픽셀 크기를 어떻게 설정할 수 있나요?**  
크기 또는 스케일을 지정할 수 있는 이미지 렌더링 오버로드를 사용하십시오 — 라이브러리는 지정된 차원/스케일로 객체를 렌더링하는 것을 지원합니다.

**내보낸 후 레이블 및 범례의 글꼴이 잘못 표시되면 어떻게 해야 하나요?**  
[필요한 글꼴 로드](/slides/ko/python-java/custom-font/)를 [FontsLoader](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontsloader/)를 사용하면 차트 렌더링이 메트릭과 텍스트 모양을 보존합니다.

**내보내기가 PowerPoint 테마, 스타일 및 효과를 유지합니까?**  
예. Aspose.Slides 렌더러는 프레젠테이션의 서식(테마, 스타일, 채우기, 효과)을 따르므로 차트 모양이 유지됩니다.

**차트 이미지 외에 사용 가능한 렌더링/내보내기 기능은 어디에서 확인할 수 있나요?**  
출력 대상([PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/ko/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/ko/python-java/convert-powerpoint-to-xps/), [HTML](/slides/ko/python-java/convert-powerpoint-to-html/), 등)을 위해 [API](https://reference.aspose.com/slides/ko/python-java/aspose.slides/)/[문서](/slides/ko/python-java/convert-powerpoint/)를 확인하고 관련 렌더링 옵션을 살펴보세요.