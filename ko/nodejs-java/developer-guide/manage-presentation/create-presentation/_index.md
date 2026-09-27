---
title: "JavaScript에서 프레젠테이션 만들기"
linktitle: "프레젠테이션 만들기"
type: docs
weight: 10
url: /ko/nodejs-java/create-presentation/
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
- "오픈문서"
- "프레젠테이션"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides를 사용하여 프레젠테이션을 생성합니다—PPT, PPTX 및 ODP 파일을 만들고, OpenDocument 지원을 활용하며, 프로그래밍 방식으로 저장하여 안정적인 결과를 얻을 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides에서 프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트 상자를 추가한 다음 결과를 파일로 저장하는 방법을 보여줍니다.

시작하기 전에 npm에서 `aspose.slides.via.java` 패키지를 JDK, Python 및 필요한 C++ 빌드 도구와 함께 설치하십시오. [Installation](/slides/ko/nodejs-java/installation/)을 참조하십시오.

## **PowerPoint 프레젠테이션 만들기**

프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트 상자를 넣으려면 다음 단계를 따르세요:

1. 새로운 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다. 새 프레젠테이션에는 이미 빈 슬라이드가 하나 포함되어 있습니다.
2. [slide collection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getslides/)에서 인덱스 0으로 해당 슬라이드를 가져옵니다.
3. [addAutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/addautoshape/) 메서드로 사각형을 추가하고, [setText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/settext/) 로 텍스트를 설정합니다.
4. [save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/save/) 메서드로 프레젠테이션을 PPTX 파일로 저장합니다.
5. [dispose](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/dispose/) 메서드로 프레젠테이션을 해제하고, 프로세스를 종료합니다.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides는 Node.js가 계속 실행되도록 하는 Java 가상 머신에서 실행되므로, 프로세스를 명시적으로 종료합니다.
process.exit(0);
```

사각형의 왼쪽 상단 모서는 슬라이드 왼쪽 가장자리에서 50포인트, 위 가장자리에서 50포인트 떨어져 있으며, 사각형은 가로 400포인트, 세로 100포인트입니다. 코드를 프로젝트 폴더에 *hello.js* 로 저장하고 `node hello.js` 를 실행하십시오. 그러면 현재 폴더에 해당 사각형과 텍스트가 포함된 하나의 슬라이드를 가진 *hello.pptx* 가 저장됩니다.

Aspose.Slides는 `java` 패키지가 Node.js 프로세스 내부에서 시작하는 Java 가상 머신에서 실행됩니다. 이 가상 머신은 스크립트가 끝난 후 Node.js가 자동으로 종료되는 것을 방지하므로 예제는 `process.exit(0)` 로 끝납니다.

라이선스가 없으면 Aspose.Slides는 저장되는 모든 슬라이드에 평가용 워터마크를 추가합니다; 자세히 보려면 [Licensing](/slides/ko/nodejs-java/licensing/)를 참고하십시오.

## **FAQ**

### 새로운 프레젠테이션을 저장할 수 있는 형식은 무엇입니까?

프레젠테이션을 [PPTX, PPT, 및 ODP](/slides/ko/nodejs-java/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/), 및 [images](/slides/ko/nodejs-java/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

### 템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있습니까?

예. 템플릿을 로드하고 원하는 형식으로 저장합니다; POTX/POTM/PPTM 및 유사한 형식은 [지원됩니다](/slides/ko/nodejs-java/supported-file-formats/).

### 프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어합니까?

[slide size](/slides/ko/nodejs-java/slide-size/)를 설정하고(4:3 및 16:9와 같은 사전 설정 또는 사용자 지정 크기 포함) 콘텐츠가 어떻게 스케일링될지 선택합니다.

### 크기와 좌표는 어떤 단위로 측정됩니까?

포인트 단위이며, 1인치는 72 단위에 해당합니다.

### 메모리 사용량을 줄이기 위해 매우 큰 프레젠테이션(많은 미디어 파일 포함)을 어떻게 처리합니까?

[BLOB 관리 전략](/slides/ko/nodejs-java/manage-blob/)을 사용하고, 임시 파일을 활용하여 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호하십시오.

### 프레젠테이션을 병렬로 만들거나 저장할 수 있습니까?

여러 [multiple threads](/slides/ko/nodejs-java/multithreading/)에서 동일한 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하십시오.

### 평가 워터마크와 제한을 제거하려면 어떻게 해야 합니까?

프로세스당 한 번씩 [Apply a license](/slides/ko/nodejs-java/licensing/)를 적용하십시오. 라이선스 XML은 수정되지 않아야 하며, 다중 스레드가 관여할 경우 라이선스 설정을 동기화해야 합니다.

### 만든 PPTX에 디지털 서명을 할 수 있습니까?

예. 프레젠테이션에 대해 [Digital signatures](/slides/ko/nodejs-java/digital-signature-in-powerpoint/) (추가 및 검증)이 지원됩니다.

### 생성된 프레젠테이션에서 매크로(VBA)를 지원합니까?

예. [create/edit VBA projects](/slides/ko/nodejs-java/presentation-via-vba/)를 통해 VBA 프로젝트를 만들고 편집할 수 있으며, PPTM/PPSM과 같은 매크로 사용 파일을 저장할 수 있습니다.