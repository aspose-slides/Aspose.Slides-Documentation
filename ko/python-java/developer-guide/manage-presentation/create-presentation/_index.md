---
title: Python via Java에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/python-java/create-presentation/
keywords:
- 프레젠테이션 만들기
- 새 프레젠테이션
- PPT 만들기
- 새 PPT
- PPTX 만들기
- 새 PPTX
- ODP 만들기
- 새 ODP
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python via Java로 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며, OpenDocument 지원을 활용하고, 프로그래밍 방식으로 저장하여 신뢰할 수 있는 결과를 얻으세요."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via Java를 사용해 프레젠테이션을 만들고, 첫 번째 슬라이드에 텍스트가 있는 도형을 추가한 뒤 PPTX 파일로 저장하는 방법을 보여줍니다. FAQ에서는 출력 형식, 템플릿, 슬라이드 크기, 메모리 사용량, 스레드 처리, 라이선스, 디지털 서명 및 VBA 지원에 대해 다룹니다.

## **프레젠테이션 만들기**

Aspose.Slides for Python via Java에서 처음부터 PowerPoint 파일을 만드는 것은 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화하는 것만큼 간단합니다. 생성자는 자동으로 빈 프레젠테이션과 단일 슬라이드를 제공하므로 도형, 텍스트, 차트 또는 애플리케이션이 필요로 하는 모든 콘텐츠를 바로 추가할 수 있습니다. 해당 슬라이드를 수정하거나 새 슬라이드를 추가한 후에는 결과를 PPTX, 이전 형식인 PPT 또는 OpenDocument 형식 등으로 저장할 수 있습니다. 아래의 짧은 코드 샘플은 첫 번째 슬라이드에 간단한 도형을 추가하는 워크플로를 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 첫 번째 슬라이드를 가져옵니다.
1. [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addAutoShape) 메서드를 사용해 [ShapeType.Cloud](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapetype/#Cloud) 유형의 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)을 추가합니다.
1. [TextFrame.setText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#setText) 메서드로 도형의 텍스트를 설정합니다.
1. [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드와 [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Pptx) 옵션을 사용해 프레젠테이션을 저장합니다.

다음 예제는 Aspose.Slides for Python via Java와 호환되는 Java 런타임이 필요합니다. JVM이 실행 중이 아니면 시작하고, 첫 번째 슬라이드에 구름 모양 도형을 추가한 뒤 프레젠테이션을 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 빈 슬라이드 하나가 있는 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 구름 모양을 추가하고 텍스트를 설정합니다.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![새 프레젠테이션](new_presentation.png)

## **FAQ**

**새 프레젠테이션을 저장할 수 있는 형식은 무엇입니까?**

[PPTX, PPT, ODP](/slides/ko/python-java/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/python-java/convert-powerpoint-to-xps/), [HTML](/slides/ko/python-java/convert-powerpoint-to-html/), [SVG](/slides/ko/python-java/render-slide-as-svg/), [이미지](/slides/ko/python-java/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

**템플릿(POTX/POTM)에서 시작해 일반 PPTX로 저장할 수 있나요?**

예. 템플릿을 로드한 뒤 원하는 형식으로 저장하면 됩니다. POTX/POTM/PPTM 등 유사 형식은 [지원됩니다](/slides/ko/python-java/supported-file-formats/).

**프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?**

[슬라이드 크기](/slides/ko/python-java/slide-size/)를 설정하고(4:3, 16:9 프리셋 또는 사용자 지정 치수) 콘텐츠가 어떻게 스케일링될지 선택합니다.

**크기와 좌표는 어떤 단위로 측정되나요?**

포인트 단위이며, 1인치는 72포인트에 해당합니다.

**매체 파일이 많은 매우 큰 프레젠테이션의 메모리 사용량을 줄이려면 어떻게 해야 하나요?**

[BLOB 관리 전략](/slides/ko/python-java/manage-blob/)을 사용하고, 임시 파일을 활용해 메모리 내 저장을 제한하며, 순수 인메모리 스트림보다 파일 기반 워크플로를 선호합니다.

**프레젠테이션을 병렬로 만들거나 저장할 수 있나요?**

동일한 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/python-java/multithreading/)에서 동시에 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 인스턴스를 실행하세요.

**체험판 워터마크와 제한을 제거하려면 어떻게 해야 하나요?**

프로세스당 한 번씩 [라이선스를 적용](/slides/ko/python-java/licensing/)하십시오. 라이선스 XML은 수정되지 않아야 하며, 여러 스레드가 사용할 경우 라이선스 설정을 동기화해야 합니다.

**생성한 PPTX에 디지털 서명을 할 수 있나요?**

예. 프레젠테이션에 대한 [디지털 서명](/slides/ko/python-java/digital-signature-in-powerpoint/)(추가 및 검증)이 지원됩니다.

**생성된 프레젠테이션에서 매크로(VBA)를 사용할 수 있나요?**

예. [VBA 프로젝트를 만들고/편집](/slides/ko/python-java/presentation-via-vba/)할 수 있으며, PPTM/PPSM 같은 매크로 포함 파일로 저장할 수 있습니다.