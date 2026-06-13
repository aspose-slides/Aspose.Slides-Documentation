---
title: Android에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java에서 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며, OpenDocument 지원을 활용하고, 프로그래밍 방식으로 저장하여 신뢰할 수 있는 결과를 얻습니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션을 만들고, 슬라이드에 간단한 내용을 추가한 다음 결과를 파일로 저장하는 방법을 보여줍니다. 또한 새 프레젠테이션을 만들고 저장하는 방법, 지원되는 형식의 기존 프레젠테이션을 열어 다른 형식으로 저장하는 방법도 설명합니다.

## **PowerPoint 프레젠테이션 만들기**
프레젠테이션의 선택된 슬라이드에 간단한 일반 선을 추가하려면 아래 단계에 따라 주세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
1. Shapes 객체에서 제공하는 addAutoShape 메서드를 사용하여 Line 유형의 AutoShape를 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 기록합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 선을 추가했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);

    // 라인 유형의 자동 도형을 추가합니다
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**새 프레젠테이션을 어떤 형식으로 저장할 수 있나요?**

다음 형식으로 저장할 수 있습니다: [PPTX, PPT 및 ODP](/slides/ko/androidjava/save-presentation/), 그리고 [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/ko/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/ko/androidjava/convert-powerpoint-to-html/), [SVG](/slides/ko/androidjava/convert-powerpoint-to-png/), 및 [이미지](/slides/ko/androidjava/convert-powerpoint-to-png/) 등.

**템플릿(POTX/POTM)으로 시작하여 일반 PPTX로 저장할 수 있나요?**

예. 템플릿을 로드한 후 원하는 형식으로 저장합니다; POTX/POTM/PPTM 및 유사한 형식은 [지원됩니다](/slides/ko/androidjava/supported-file-formats/).

**프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?**

[슬라이드 크기](/slides/ko/androidjava/slide-size/)를 설정하고(4:3, 16:9와 같은 프리셋 또는 사용자 지정 크기 포함) 콘텐츠가 어떻게 확장될지 선택합니다.

**크기와 좌표는 어떤 단위로 측정되나요?**

포인트 단위이며, 1인치는 72포인트에 해당합니다.

**대용량 프레젠테이션(미디어 파일이 많은)을 메모리 사용량을 줄이면서 어떻게 처리합니까?**

[BLOB 관리 전략](/slides/ko/androidjava/manage-blob/)을 사용하고, 임시 파일을 활용해 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

**프레젠테이션을 병렬로 만들거나 저장할 수 있나요?**

동일한 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스를 [다중 스레드](/slides/ko/androidjava/multithreading/)에서 사용할 수 없습니다. 스레드 또는 프로세스당 별도 독립 인스턴스를 실행하십시오.

**시험판 워터마크와 제한을 제거하려면 어떻게 해야 하나요?**

프로세스당 한 번 [라이선스를 적용](/slides/ko/androidjava/licensing/)하십시오. 라이선스 XML은 수정되지 않아야 하며, 다중 스레드가 관여하는 경우 라이선스 설정을 동기화해야 합니다.

**생성한 PPTX에 디지털 서명을 할 수 있나요?**

예. 프레젠테이션에 대해 [디지털 서명](/slides/ko/androidjava/digital-signature-in-powerpoint/) (추가 및 검증)이 지원됩니다.

**생성된 프레젠테이션에서 매크로(VBA)가 지원되나요?**

예. [VBA 프로젝트 만들기/편집](/slides/ko/androidjava/presentation-via-vba/)이 가능하며 PPTM/PPSM과 같은 매크로 사용 파일로 저장할 수 있습니다.