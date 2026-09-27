---
title: Python에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/python-net/create-presentation/
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
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용해 Python에서 PowerPoint 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며 OpenDocument 지원을 활용하고, 신뢰할 수 있는 결과를 위해 프로그래밍 방식으로 저장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via .NET를 사용해 프레젠테이션을 만들고, 첫 번째 슬라이드에 텍스트가 포함된 도형을 추가한 다음 결과를 PPTX 파일로 저장하는 방법을 보여줍니다. 동일한 API를 사용하면 프레젠테이션을 PPT 및 ODP 형식으로도 저장할 수 있어 Microsoft Office 없이도 하나의 코드 베이스에서 PowerPoint와 OpenDocument 형식을 모두 대상으로 할 수 있습니다. 끝부분의 간단한 FAQ에서는 형식, 템플릿, 슬라이드 크기, 단위, 메모리 사용량, 스레딩, 라이선스, 디지털 서명 및 VBA 지원에 관한 일반적인 질문을 다룹니다.

시작하기 전에 PyPI에서 `pip install aspose.slides` 명령으로 패키지를 설치하십시오. Linux 및 macOS에 필요한 라이브러리와 Debian 및 Ubuntu의 시스템 Python에 필요한 가상 환경에 대해서는 [Installation](/slides/ko/python-net/installation/)을 참조하십시오.

## **프레젠테이션 만들기**

프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트가 포함된 도형을 넣으려면 다음 단계를 따르세요:

1. 새 [프레젠테이션](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다. 새 프레젠테이션에는 이미 빈 슬라이드가 하나 포함됩니다.
2. 인덱스 0을 사용해 [슬라이드](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slides/ko/) 컬렉션에서 해당 슬라이드를 가져옵니다.
3. 슬라이드의 [shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/shapes/) 컬렉션에서 [add_auto_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_auto_shape/) 메서드를 사용해 구름 모양의 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가하고, 해당 [text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/text/)를 설정합니다.
4. [save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 메서드를 사용해 프레젠테이션을 PPTX 파일로 저장합니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    # 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # CLOUD 유형의 자동 도형을 추가합니다.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

구름의 좌상단 모서는 슬라이드 왼쪽 가장자리에서 20포인트, 위쪽 가장자리에서 20포인트 떨어져 있으며, 구름의 너비는 200포인트, 높이는 80포인트입니다. `with` 문은 블록이 끝날 때 프레젠테이션의 리소스를 해제합니다. 스크립트는 현재 폴더에 *new_presentation.pptx* 파일을 저장하며, 구름과 텍스트가 포함된 슬라이드가 하나 있습니다. 라이선스가 없으면 Aspose.Slides는 저장되는 모든 슬라이드에 평가 워터마크를 추가합니다; 자세한 내용은 [Licensing](/slides/ko/python-net/licensing/)를 참조하십시오.

결과:

![새 프레젠테이션](new_presentation.png)

## **FAQ**

### 새 프레젠테이션을 어떤 형식으로 저장할 수 있나요?

다음 링크에서 [PPTX, PPT 및 ODP](/slides/ko/python-net/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ko/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ko/python-net/convert-powerpoint-to-html/), [SVG](/slides/ko/python-net/render-a-slide-as-an-svg-image/), 그리고 [images](/slides/ko/python-net/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

### 템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?

예. 템플릿을 로드한 후 원하는 형식으로 저장하면 됩니다; POTX/POTM/PPTM 및 유사한 형식은 [지원됩니다](/slides/ko/python-net/supported-file-formats/).

### 프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?

[슬라이드 크기](/slides/ko/python-net/slide-size/)를 설정하고(4:3 및 16:9와 같은 프리셋이나 사용자 지정 치수 포함) 콘텐츠가 어떻게 확대/축소될지 선택합니다.

### 크기와 좌표는 어떤 단위로 측정되나요?

포인트 단위이며, 1인치는 72포인트에 해당합니다.

### 많은 미디어 파일이 포함된 매우 큰 프레젠테이션의 메모리 사용량을 줄이려면 어떻게 처리하나요?

[BLOB 관리 전략](/slides/ko/python-net/manage-blob/)을 사용하고, 임시 파일을 활용해 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

### 프레젠테이션을 병렬로 만들거나 저장할 수 있나요?

동일한 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/python-net/multithreading/)에서 동시에 사용할 수 없습니다. 각 스레드 또는 프로세스마다 별도의 독립 인스턴스를 실행하십시오.

### 평가 워터마크와 제한을 어떻게 제거하나요?

프로세스당 한 번 [라이선스 적용](/slides/ko/python-net/licensing/)을 수행하십시오. 라이선스 XML은 수정되지 않아야 하며, 여러 스레드가 관여하는 경우 라이선스 설정을 동기화해야 합니다.

### 생성한 PPTX에 디지털 서명을 할 수 있나요?

예. 프레젠테이션에서는 [Digital signatures](/slides/ko/python-net/digital-signature-in-powerpoint/) (추가 및 검증) 기능을 지원합니다.

### 생성된 프레젠테이션에서 매크로(VBA)를 지원하나요?

예. [create/edit VBA projects](/slides/ko/python-net/presentation-via-vba/)를 통해 VBA 프로젝트를 만들거나 편집할 수 있으며, PPTM/PPSM과 같은 매크로 사용 파일로 저장할 수 있습니다.