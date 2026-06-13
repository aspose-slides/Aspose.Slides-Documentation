---
title: "Python에서 프레젠테이션 만들기"
linktitle: "프레젠테이션 만들기"
type: docs
weight: 10
url: /ko/python-net/create-presentation/
keywords:
- "프레젠테이션 만들기"
- "새 프레젠테이션"
- "PPT 만들기"
- "새 PPT"
- "PPTX 만들기"
- "새 PPTX"
- "ODP 만들기"
- "새 ODP"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides를 사용하여 Python에서 PowerPoint 프레젠테이션을 생성합니다—PPT, PPTX 및 ODP 파일을 생성하고 OpenDocument 지원을 활용하며 프로그래밍 방식으로 저장하여 안정적인 결과를 얻을 수 있습니다."
---
## **개요**

Aspose.Slides for Python을 사용하면 코드를 통해 완전히 새로운 프레젠테이션 파일을 만들 수 있습니다. 이 문서에서는 핵심 흐름—[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 객체 생성, 첫 번째 슬라이드 가져오기, 간단한 도형 삽입, 결과 저장—을 보여 주어 Microsoft Office 없이 프레젠테이션을 생성하는 데 필요한 설정이 얼마나 적은지 확인할 수 있습니다. 동일한 API가 PPT, PPTX 및 ODP 파일을 모두 작성하므로 하나의 코드 베이스에서 기존 PowerPoint 형식과 OpenDocument 형식 모두를 대상으로 할 수 있습니다. Aspose.Slides는 데스크톱, 웹 또는 서버 환경에 적합하며, 초기 슬라이드 덱이 준비된 후 텍스트, 이미지 또는 차트와 같은 풍부한 콘텐츠를 추가하기 위한 효율적인 시작점을 Python 애플리케이션에 제공합니다.

## **프레젠테이션 만들기**

Aspose.Slides for Python에서 처음부터 PowerPoint 파일을 만드는 것은 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화하는 것만큼 간단합니다. 생성자는 자동으로 하나의 슬라이드가 포함된 빈 덱을 제공하므로 도형, 텍스트, 차트 또는 애플리케이션이 필요로 하는 기타 콘텐츠를 바로 그릴 수 있는 캔버스를 제공합니다. 해당 슬라이드를 수정하거나 새 슬라이드를 추가한 후에는 결과를 PPTX, 레거시 PPT 또는 OpenDocument 형식으로 저장할 수 있습니다. 아래의 짧은 코드 샘플은 첫 번째 슬라이드에 간단한 도형을 추가하는 흐름을 보여 줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. `shapes` 컬렉션이 제공하는 `add_auto_shape` 메서드를 사용하여 `CLOUD` 유형의 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 객체를 추가합니다.
1. 자동 도형에 텍스트를 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 구름 모양을 추가합니다.

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

결과:

![The new presentation](new_presentation.png)

## **FAQ**

**새 프레젠테이션을 어떤 형식으로 저장할 수 있나요?**

[PPTX, PPT, 및 ODP](/slides/ko/python-net/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/ko/python-net/convert-powerpoint-to-xps/), [HTML](/slides/ko/python-net/convert-powerpoint-to-html/), [SVG](/slides/ko/python-net/convert-powerpoint-to-png/), 그리고 [이미지](/slides/ko/python-net/convert-powerpoint-to-png/) 등으로도 내보낼 수 있습니다.

**템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?**

예. 템플릿을 로드한 뒤 원하는 형식으로 저장하면 됩니다; POTX/POTM/PPTM 및 유사 형식은 [지원됩니다](/slides/ko/python-net/supported-file-formats/).

**프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?**

[슬라이드 크기](/slides/ko/python-net/slide-size/)를 설정합니다(4:3, 16:9와 같은 사전 설정 또는 사용자 지정 치수 포함) 그리고 콘텐츠가 어떻게 스케일될지 선택합니다.

**크기와 좌표는 어떤 단위로 측정되나요?**

포인트 단위이며, 1인치는 72 포인트에 해당합니다.

**매우 큰 프레젠테이션(미디어 파일 다수)을 어떻게 메모리 사용량을 줄여 처리하나요?**

[BLOB 관리 전략](/slides/ko/python-net/manage-blob/)을 사용하고, 임시 파일을 활용해 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

**프레젠테이션을 병렬로 생성/저장할 수 있나요?**

[Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/python-net/multithreading/)에서 동시에 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하십시오.

**평가판 워터마크와 제한을 제거하려면 어떻게 하나요?**

프로세스당 한 번씩 [라이선스를 적용](/slides/ko/python-net/licensing/)합니다. 라이선스 XML은 수정되지 않아야 하며, 여러 스레드가 관련된 경우 라이선스 설정을 동기화해야 합니다.

**생성한 PPTX에 디지털 서명을 할 수 있나요?**

예. [디지털 서명](/slides/ko/python-net/digital-signature-in-powerpoint/) (추가 및 검증) 기능이 프레젠테이션에 대해 지원됩니다.

**생성된 프레젠테이션에서 매크로(VBA)를 지원하나요?**

예. [VBA 프로젝트 생성/편집](/slides/ko/python-net/presentation-via-vba/)이 가능하며 PPTM/PPSM과 같은 매크로 사용 파일도 저장할 수 있습니다.