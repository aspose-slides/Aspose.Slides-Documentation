---
title: Java에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/java/create-presentation/
keywords:
- 프레젠테이션 만들기
- 새 프레젠테이션
- PPT 만들기
- 새 PPT
- PPTX 만들기
- 새 PPTX
- ODP 만들기
- 새 ODP
- 파워포인트
- 오픈문서
- 프레젠테이션
- 자바
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며, 오픈문서 지원을 활용하고 프로그래밍 방식으로 저장하여 신뢰할 수 있는 결과를 얻으세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션을 만드는 방법, 슬라이드에 간단한 내용을 추가하고 결과를 파일로 저장하는 방법을 보여줍니다. 또한 새 프레젠테이션을 만들고 저장하는 방법, 지원되는 형식의 기존 프레젠테이션을 열어 다른 형식으로 저장하는 방법도 설명합니다. 추가로 형식, 템플릿, 슬라이드 크기, 단위, 메모리 사용량, 스레딩, 라이선스, 디지털 서명 및 VBA 지원과 관련된 일반적인 질문을 다루는 짧은 FAQ가 포함되어 있습니다.

## **프레젠테이션 만들기**

Aspose.Slides for Java에서 처음부터 PowerPoint 파일을 만드는 것은 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스를 인스턴스화하는 것만큼 직접적입니다. 생성자는 자동으로 단일 슬라이드가 포함된 빈 프레젠테이션을 제공하므로 도형, 텍스트, 차트 또는 애플리케이션이 필요로 하는 기타 내용을 즉시 추가할 수 있는 캔버스를 제공합니다. 해당 슬라이드를 수정하거나 새 슬라이드를 추가한 후에는 결과를 PPTX, 레거시 PPT 또는 OpenDocument 형식으로 저장할 수 있습니다. 아래 짧은 코드 샘플은 첫 번째 슬라이드에 간단한 도형을 추가하는 작업 흐름을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스로 슬라이드에 대한 참조를 가져옵니다.  
3. `Shapes` 컬렉션이 제공하는 `addAutoShape` 메서드를 사용하여 `Cloud` 유형의 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/) 객체를 추가합니다.  
4. 자동 도형에 텍스트를 추가합니다.  
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션 첫 슬라이드에 구름 모양을 추가합니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Cloud 유형의 자동 도형을 추가합니다.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![새 프레젠테이션](new_presentation.png)

## **FAQ**

**새 프레젠테이션을 저장할 수 있는 형식은 무엇입니까?**

[PPTX, PPT, and ODP](/slides/ko/java/save-presentation/)에 저장할 수 있으며, [PDF](/slides/ko/java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/java/convert-powerpoint-to-xps/), [HTML](/slides/ko/java/convert-powerpoint-to-html/), [SVG](/slides/ko/java/convert-powerpoint-to-png/), 및 [images](/slides/ko/java/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

**템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있습니까?**

예. 템플릿을 로드하고 원하는 형식으로 저장하면 됩니다; POTX/POTM/PPTM 및 유사 형식은 [지원됩니다](/slides/ko/java/supported-file-formats/).

**프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어합니까?**

[슬라이드 크기](/slides/ko/java/slide-size/)를 설정하고(4:3, 16:9 같은 사전 설정이나 사용자 지정 치수) 내용이 어떻게 스케일링될지 선택합니다.

**크기와 좌표는 어떤 단위로 측정됩니까?**

포인트 단위이며, 1인치는 72포인트에 해당합니다.

**매우 큰 프레젠테이션(미디어 파일 다수)을 처리하여 메모리 사용량을 줄이려면 어떻게 해야 합니까?**

[BLOB 관리 전략](/slides/ko/java/manage-blob/)을 사용하고, 임시 파일을 활용하여 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

**프레젠테이션을 병렬로 만들거나 저장할 수 있습니까?**

동일한 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/java/multithreading/)에서 동시에 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하십시오.

**평가 워터마크와 제한을 제거하려면 어떻게 해야 합니까?**

프로세스당 한 번 [라이선스를 적용](/slides/ko/java/licensing/)합니다. 라이선스 XML은 수정되지 않아야 하며, 여러 스레드가 관여하는 경우 라이선스 설정을 동기화해야 합니다.

**생성한 PPTX에 디지털 서명을 할 수 있습니까?**

예. 프레젠테이션에 대한 [디지털 서명](/slides/ko/java/digital-signature-in-powerpoint/)(추가 및 검증)이 지원됩니다.

**생성된 프레젠테이션에서 매크로(VBA)를 지원합니까?**

예. [VBA 프로젝트를 만들고/편집](/slides/ko/java/presentation-via-vba/)할 수 있으며 PPTM/PPSM과 같은 매크로 사용 파일로 저장할 수 있습니다.