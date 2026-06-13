---
title: Python으로 프레젠테이션 차트 내보내기
linktitle: 차트 내보내기
type: docs
weight: 90
url: /ko/python-net/export-chart/
keywords:
- 차트
- 차트를 이미지로 변환
- 차트 이미지
- 차트 이미지 추출
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 프레젠테이션 차트를 내보내는 방법을 배우고, PPT, PPTX 및 ODP 형식을 지원하며, 모든 워크플로우에서 보고서를 효율화합니다."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션의 차트를 이미지로 내보낼 수 있습니다. 이 문서에서는 차트에서 이미지를 가져와 저장하는 방법을 보여줍니다. 이는 PowerPoint 프레젠테이션 외부에서 차트 시각 자료를 재사용해야 할 때 유용합니다.

## **차트 이미지 가져오기**
Aspose.Slides for Python via .NET는 특정 차트의 이미지를 추출하는 기능을 제공합니다. 아래 샘플 예제가 제공됩니다.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **자주 묻는 질문**

**차트를 래스터 이미지가 아니라 벡터(SVG)로 내보낼 수 있나요?**

예. 차트는 도형이며, 내용은 [shape-to-SVG saving method](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/write_as_svg/)를 사용하여 SVG로 저장할 수 있습니다.

**내보낸 차트의 정확한 크기를 픽셀 단위로 설정하려면 어떻게 해야 하나요?**

이미지 렌더링 오버로드를 사용하여 크기나 스케일을 지정하십시오—라이브러리는 지정된 치수/스케일로 객체를 렌더링하는 것을 지원합니다.

**내보낸 후 레이블 및 범례의 글꼴이 잘못 표시되면 어떻게 해야 하나요?**

[필요한 글꼴 로드](/slides/ko/python-net/custom-font/)를 [FontsLoader](https://reference.aspose.com/slides/ko/python-net/aspose.slides/fontsloader/)를 통해 수행하면 차트 렌더링이 메트릭 및 텍스트 모양을 유지합니다.

**내보내기가 PowerPoint 테마, 스타일 및 효과를 반영합니까?**

예. Aspose.Slides의 렌더러는 프레젠테이션의 서식(테마, 스타일, 채우기, 효과)을 따르므로 차트 모양이 보존됩니다.

**차트 이미지 외에 사용 가능한 렌더링/내보내기 기능은 어디에서 찾을 수 있나요?**

출력 대상([PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/ko/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/ko/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ko/python-net/convert-powerpoint-to-html/) 등) 및 관련 렌더링 옵션에 대해서는 [API](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/)/[documentation](/slides/ko/python-net/convert-powerpoint/)의 내보내기 섹션을 확인하십시오.