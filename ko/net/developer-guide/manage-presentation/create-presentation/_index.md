---
title: .NET에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/net/create-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 .NET에서 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며, OpenDocument 지원을 활용하고, 프로그램으로 저장하여 신뢰할 수 있는 결과를 얻으세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션을 생성하고, 첫 번째 슬라이드에 텍스트 상자를 추가하고, 결과를 파일로 저장하는 방법을 보여줍니다. 또한 빈 프레젠테이션을 생성 및 저장하는 방법과 지원되는 형식의 기존 프레젠테이션을 열어 다른 형식으로 저장하는 방법도 설명합니다. 끝에 있는 짧은 FAQ에서는 형식, 템플릿, 슬라이드 크기, 단위, 메모리 사용량, 스레딩, 라이선스, 디지털 서명 및 VBA 지원에 관한 일반적인 질문을 다룹니다.

시작하기 전에 NuGet에서 Aspose.Slides를 프로젝트에 추가하십시오. Windows, Linux 및 macOS에서 사용할 패키지에 대해서는 [Installation](/slides/ko/net/installation/)을 참조하십시오.

## **PowerPoint 프레젠테이션 만들기**

프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트 상자를 넣으려면 다음 단계에 따라 진행하십시오:

1. 새로운 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다. 새 프레젠테이션에는 이미 빈 슬라이드가 하나 포함되어 있습니다.
2. [Slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slides/ko/) 컬렉션에서 인덱스 0으로 해당 슬라이드를 가져옵니다.
3. [AddAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addautoshape/) 메서드로 사각형을 추가하고 해당 [text](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/text/)를 설정합니다.
4. [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드로 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

사각형의 왼쪽 상단 모서는 슬라이드의 왼쪽 가장자리에서 50포인트, 위쪽 가장자리에서 50포인트 떨어져 있으며, 사각형의 너비는 400포인트, 높이는 100포인트입니다. 저장된 파일에는 해당 사각형과 텍스트가 포함된 슬라이드가 하나 들어 있습니다. 라이선스가 없을 경우 Aspose.Slides는 저장되는 모든 슬라이드에 평가용 워터마크를 추가합니다; 자세한 내용은 [Licensing](/slides/ko/net/licensing/)을 참조하십시오.

## **프레젠테이션 만들기 및 저장하기**

<a name="csharp-create-save-presentation"></a>

빈 프레젠테이션을 만들고 저장하려면, [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 [SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/) 열거형의任意 형식으로 저장합니다. 결과는 빈 슬라이드 하나를 포함한 프레젠테이션이 됩니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **프레젠테이션 열기 및 저장하기**

<a name="csharp-open-save-presentation"></a>

프레젠테이션을 한 형식에서 다른 형식으로 변환하려면, 파일 경로를 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/presentation/) 생성자에 전달하여 열고, 원하는 형식으로 저장합니다. Aspose.Slides는 파일 자체에서 입력 형식(PPT, PPTX 또는 ODP 등)을 감지합니다.

아래 예제는 작업 디렉터리에 *Sample.odp* 라는 OpenDocument 프레젠테이션이 존재한다고 가정하고 이를 PPTX로 저장합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### 새 프레젠테이션을 저장할 수 있는 형식은 무엇인가요?

새 프레젠테이션은 [PPTX, PPT, ODP](/slides/ko/net/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/net/convert-powerpoint-to-pdf/), [XPS](/slides/ko/net/convert-powerpoint-to-xps/), [HTML](/slides/ko/net/convert-powerpoint-to-html/), [SVG](/slides/ko/net/render-a-slide-as-an-svg-image/), 그리고 [images](/slides/ko/net/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

### 템플릿(POTX/POTM)에서 시작해 일반 PPTX로 저장할 수 있나요?

예. 템플릿을 로드한 뒤 원하는 형식으로 저장하면 됩니다; POTX/POTM/PPTM 등과 유사한 형식은 [지원됩니다](/slides/ko/net/supported-file-formats/) .

### 프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?

프레젠테이션을 만들 때 [slide size](/slides/ko/net/slide-size/)를 설정하고(4:3, 16:9 등 미리 설정된 옵션 또는 사용자 지정 크기), 콘텐츠가 어떻게 스케일링될지 선택합니다.

### 크기와 좌표는 어떤 단위로 측정되나요?

포인트 단위이며, 1인치는 72 포인트에 해당합니다.

### 메모리 사용량을 줄이기 위해 매우 큰 프레젠테이션(미디어 파일 다수 포함)을 어떻게 처리하나요?

[BLOB 관리 전략](/slides/ko/net/manage-blob/)을 사용하고, 임시 파일을 활용해 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

### 프레젠테이션을 병렬로 만들거나 저장할 수 있나요?

동일한 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/net/multithreading/)에서 동시에 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하십시오.

### 평가용 워터마크와 제한을 제거하려면 어떻게 하나요?

프로세스당 한 번 [라이선스를 적용](/slides/ko/net/licensing/)하십시오. 라이선스 XML은 수정되지 않아야 하며, 여러 스레드가 있는 경우 라이선스 설정을 동기화해야 합니다.

### 만든 PPTX에 디지털 서명을 할 수 있나요?

예. 프레젠테이션에 대해 [디지털 서명](/slides/ko/net/digital-signature-in-powerpoint/)을 추가하고 확인할 수 있습니다.

### 만든 프레젠테이션에서 매크로(VBA)가 지원되나요?

예. [VBA 프로젝트를 생성/편집](/slides/ko/net/presentation-via-vba/)하고 PPTM/PPSM과 같은 매크로 사용 파일을 저장할 수 있습니다.