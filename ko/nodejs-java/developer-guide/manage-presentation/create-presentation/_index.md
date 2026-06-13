---
title: JavaScript에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/nodejs-java/create-presentation/
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
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며, OpenDocument 지원을 활용하고, 프로그래밍 방식으로 저장하여 신뢰할 수 있는 결과를 얻으세요."
---
## **개요**

이 문서는 Aspose.Slides에서 프레젠테이션을 만들고, 슬라이드에 간단한 내용을 추가한 뒤, 결과를 파일로 저장하는 방법을 보여줍니다.

## **PowerPoint 프레젠테이션 만들기**

프레젠테이션의 선택된 슬라이드에 간단한 직선을 추가하려면, 아래 단계를 따르세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. Shapes 개체가 제공하는 addAutoShape 메서드를 사용하여 Line 유형의 AutoShape을 추가합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 선을 추가했습니다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var slide = pres.getSlides().get_Item(0);
    // 라인 유형의 자동 도형을 추가합니다
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **자주 묻는 질문**

**새 프레젠테이션을 저장할 수 있는 형식은 무엇인가요?**

다음 형식으로 저장할 수 있습니다: [PPTX, PPT 및 ODP](/slides/ko/nodejs-java/save-presentation/), 그리고 [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/ko/nodejs-java/convert-powerpoint-to-png/), 및 [이미지](/slides/ko/nodejs-java/convert-powerpoint-to-png/) 등.

**템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?**

예. 템플릿을 로드하고 원하는 형식으로 저장합니다; POTX/POTM/PPTM 및 유사 형식은 [지원됩니다](/slides/ko/nodejs-java/supported-file-formats/).

**프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?**

[슬라이드 크기](/slides/ko/nodejs-java/slide-size/)를 설정합니다(4:3 및 16:9와 같은 프리셋 또는 사용자 지정 크기 포함) 그리고 콘텐츠가 어떻게 스케일될지 선택합니다.

**크기와 좌표는 어떤 단위로 측정되나요?**

포인트 단위입니다: 1인치는 72 단위에 해당합니다.

**많은 미디어 파일이 포함된 대용량 프레젠테이션을 메모리 사용량을 줄이면서 어떻게 처리하나요?**

[BLOB 관리 전략](/slides/ko/nodejs-java/manage-blob/)을 사용하고, 임시 파일을 활용하여 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

**프레젠테이션을 병렬로 생성/저장할 수 있나요?**

동일한 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/nodejs-java/multithreading/)에서 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하십시오.

**체험판 워터마크와 제한을 제거하려면 어떻게 해야 하나요?**

프로세스당 한 번 [라이선스를 적용](/slides/ko/nodejs-java/licensing/)하십시오. 라이선스 XML은 수정되지 않아야 하며, 여러 스레드가 관여하는 경우 라이선스 설정을 동기화해야 합니다.

**생성한 PPTX에 디지털 서명을 할 수 있나요?**

예. 프레젠테이션에 대해 [디지털 서명](/slides/ko/nodejs-java/digital-signature-in-powerpoint/) (추가 및 검증)이 지원됩니다.

**생성된 프레젠테이션에서 매크로(VBA)가 지원되나요?**

예. [VBA 프로젝트 생성/편집](/slides/ko/nodejs-java/presentation-via-vba/)이 가능하며 PPTM/PPSM과 같은 매크로 사용 파일을 저장할 수 있습니다.