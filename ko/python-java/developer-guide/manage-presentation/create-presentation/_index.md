---
title: Python via Java에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/python-java/create-presentation/
keywords:
- 프레젠테이션 만들기
- 새로운 프레젠테이션
- PPT 만들기
- 새로운 PPT
- PPTX 만들기
- 새로운 PPTX
- ODP 만들기
- 새로운 ODP
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python via Java에서 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며 OpenDocument 지원을 활용하고, 신뢰할 수 있는 결과를 위해 프로그래밍 방식으로 저장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via Java를 사용하여 프레젠테이션을 만들고, 첫 번째 슬라이드에 텍스트가 포함된 도형을 추가한 후 결과를 PPTX 파일로 저장하는 방법을 보여줍니다. FAQ에서는 출력 형식, 템플릿, 슬라이드 크기, 메모리 사용량, 스레딩, 라이선스, 디지털 서명 및 VBA 지원 등에 대해 다룹니다.

시작하기 전에 Python, JDK, JPype 및 Aspose.Slides for Python via Java를 설치하십시오. Windows, Linux 및 macOS에 대한 단계는 [설치](/slides/ko/python-java/installation/)을(를) 참조하십시오.

## **프레젠테이션 만들기**

Aspose.Slides for Python via Java에서 처음부터 PowerPoint 파일을 만드는 과정은 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스를 인스턴스화하는 것만큼 간단합니다. 생성자는 자동으로 하나의 슬라이드가 포함된 빈 덱을 제공하므로 도형, 텍스트, 차트 또는 애플리케이션에서 필요한 기타 콘텐츠를 바로 추가할 수 있습니다. 해당 슬라이드를 수정하거나 새 슬라이드를 추가하면 결과를 PPTX, 기존 PPT 또는 OpenDocument 형식으로 저장할 수 있습니다. 아래의 짧은 코드 예제는 첫 번째 슬라이드에 간단한 도형을 추가하는 작업 흐름을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스 0을 사용하여 첫 번째 슬라이드를 가져옵니다.
1. [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)을 [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) 유형으로 추가하고, [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape)를 사용합니다.
1. [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText)를 사용하여 도형의 텍스트를 설정합니다.
1. [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)와 [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx)를 사용하여 프레젠테이션을 저장합니다.

다음 예제는 Java Virtual Machine (JVM)이 아직 실행 중이 아닌 경우 시작하고, 첫 번째 슬라이드에 텍스트가 포함된 클라우드 도형을 추가한 뒤 프레젠테이션을 저장합니다. 파일명을 *create_presentation.py* 로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 하나의 빈 슬라이드가 있는 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 클라우드 도형을 추가하고 텍스트를 설정합니다.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

패키지를 설치한 환경에서 스크립트를 실행합니다:

```sh
python create_presentation.py
```

클라우드의 왼쪽 위 모서리는 슬라이드의 왼쪽 및 위 가장자리에서 각각 20포인트 떨어져 있으며, 클라우드의 너비는 200포인트, 높이는 80포인트입니다. 스크립트는 현재 작업 디렉터리에 *new_presentation.pptx* 를 저장하며, 클라우드와 텍스트가 포함된 하나의 슬라이드가 있습니다. JVM은 Python 프로세스가 종료될 때까지 실행됩니다; 자세한 내용은 [제한 사항 및 API 차이점](/slides/ko/python-java/limitations-and-api-differences/#import-the-library)를 참조하십시오. 라이선스가 없으면 Aspose.Slides는 저장하는 모든 슬라이드에 평가용 워터마크 텍스트 상자를 추가합니다; 자세한 내용은 [라이선스](/slides/ko/python-java/licensing/)을(를) 참조하십시오.

결과:

![새 프레젠테이션](new_presentation.png)

## **자주 묻는 질문**

**새 프레젠테이션을 어떤 형식으로 저장할 수 있나요?**

새 프레젠테이션은 [PPTX, PPT 및 ODP](/slides/ko/python-java/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/python-java/convert-powerpoint-to-xps/), [HTML](/slides/ko/python-java/convert-powerpoint-to-html/), [SVG](/slides/ko/python-java/render-a-slide-as-an-svg-image/), 및 [images](/slides/ko/python-java/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

**템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?**

예. 템플릿을 로드하고 원하는 형식으로 저장합니다; POTX/POTM/PPTM 및 유사한 형식은 [지원됩니다](/slides/ko/python-java/supported-file-formats/).

**프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?**

[슬라이드 크기](/slides/ko/python-java/slide-size/)를 설정하고(4:3 및 16:9와 같은 프리셋 또는 사용자 지정 크기 포함) 콘텐츠가 어떻게 스케일링될지 선택합니다.

**크기와 좌표는 어떤 단위로 측정되나요?**

포인트 단위이며, 1인치는 72포인트에 해당합니다.

**메모리 사용량을 줄이기 위해 많은 미디어 파일이 포함된 대용량 프레젠테이션을 어떻게 처리하나요?**

[BLOB 관리 전략](/slides/ko/python-java/manage-blob/)을 사용하고, 임시 파일을 활용하여 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

**프레젠테이션을 병렬로 만들거나 저장할 수 있나요?**

같은 [Presentation] 인스턴스를 [다중 스레드](/slides/ko/python-java/multithreading/)에서 동시에 작업할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하십시오.

**평가용 워터마크와 제한을 제거하려면 어떻게 해야 하나요?**

[라이선스를 적용](/slides/ko/python-java/licensing/)하여 프로세스당 한 번만 적용합니다. 라이선스 XML은 변경되지 않아야 하며, 여러 스레드가 관련된 경우 라이선스 설정을 동기화해야 합니다.

**생성한 PPTX에 디지털 서명을 할 수 있나요?**

예. 프레젠테이션에 대해 [디지털 서명](/slides/ko/python-java/digital-signature-in-powerpoint/)이 지원됩니다.

**생성된 프레젠테이션에서 매크로(VBA)를 지원하나요?**

예. [VBA 프로젝트 만들기/편집](/slides/ko/python-java/presentation-via-vba/)을 통해 매크로가 포함된 PPTM/PPSM 파일을 저장할 수 있습니다.