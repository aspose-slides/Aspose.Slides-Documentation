---
title: JavaScript를 사용하여 프레젠테이션의 SmartArt 그래픽 관리
linktitle: SmartArt 그래픽
type: docs
weight: 20
url: /ko/nodejs-java/manage-smartart-shape/
keywords:
- SmartArt 객체
- SmartArt 그래픽
- SmartArt 스타일
- SmartArt 색상
- SmartArt 생성
- SmartArt 추가
- SmartArt 편집
- SmartArt 변경
- SmartArt 액세스
- SmartArt 레이아웃 유형
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 JavaScript에서 PowerPoint SmartArt 생성, 편집 및 스타일링을 자동화하고, 간결한 코드 예제와 성능 중심 가이드를 제공합니다."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 프레젠테이션에서 SmartArt 그래픽을 만들고 관리할 수 있습니다. 이 문서에서는 슬라이드에 SmartArt 도형을 추가하고, 기존 SmartArt 도형에 액세스하며, 특정 레이아웃 유형으로 SmartArt를 찾아서 SmartArt 스타일 또는 색상 스타일을 변경하여 시각적 모습을 업데이트하는 방법을 설명합니다.

예제에서는 프레젠테이션 슬라이드의 도형 컬렉션을 통해 SmartArt 도형을 작업하고, 도형이 SmartArt인지 확인한 다음 해당 속성을 수정하거나 검사하는 방법을 보여줍니다.

## **SmartArt 도형 만들기**
Aspose.Slides for Node.js via Java는 SmartArt 도형을 만들기 위한 API를 제공합니다. 슬라이드에 SmartArt 도형을 만들려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
1. [LayoutType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SmartArtLayoutType)을 설정하여 [Add a SmartArt shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-)을 수행합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```javascript
// Presentation 클래스를 인스턴스화
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드 가져오기
    var slide = pres.getSlides().get_Item(0);
    // Smart Art 도형 추가
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // 프레젠테이션 저장
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**그림: 슬라이드에 추가된 SmartArt 도형**|

## **슬라이드에서 SmartArt 도형에 접근**
다음 코드는 프레젠테이션 슬라이드에 추가된 SmartArt 도형에 접근하는 방법을 보여줍니다. 샘플 코드에서는 슬라이드 내부의 모든 도형을 순회하면서 해당 도형이 [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SmartArt)인지 확인합니다. SmartArt 유형이면 이를 [**SmartArt**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SmartArt) 인스턴스로 형변환합니다.

```javascript
// 원하는 프레젠테이션을 로드합니다
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 도형이 SmartArt 유형인지 확인합니다
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 도형을 SmartArtEx로 형변환합니다
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **특정 레이아웃 유형을 가진 SmartArt 도형에 접근**
다음 샘플 코드는 특정 LayoutType을 가진 [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SmartArt) 도형에 접근하는 방법을 보여줍니다. LayoutType은 읽기 전용이며 SmartArt 도형을 추가할 때만 설정된다는 점에 유의하세요.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
1. 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SmartArt) 유형인지 확인하고, SmartArt인 경우 선택한 도형을 SmartArt로 형변환합니다.
1. 특정 LayoutType을 가진 SmartArt 도형을 확인하고, 이후 필요한 작업을 수행합니다.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // 도형이 SmartArt 유형인지 확인합니다
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 도형을 SmartArtEx로 형변환합니다
            var smart = shape;
            // SmartArt 레이아웃 확인 중
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SmartArt 도형 스타일 변경**
이 예제에서는任意의 SmartArt 도형에 대해 빠른 스타일을 변경하는 방법을 학습합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
1. 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SmartArt) 유형인지 확인하고, SmartArt인 경우 선택한 도형을 SmartArt로 형변환합니다.
1. 특정 스타일을 가진 SmartArt 도형을 찾습니다.
1. SmartArt 도형에 새 스타일을 설정합니다.
1. 프레젠테이션을 저장합니다.

```javascript
// Presentation 클래스를 인스턴스화
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 첫 번째 슬라이드 가져오기
    var slide = pres.getSlides().get_Item(0);
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // 도형이 SmartArt 유형인지 확인합니다
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 도형을 SmartArtEx로 형변환합니다
            var smart = shape;
            // SmartArt 스타일 확인 중
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // SmartArt 스타일 변경 중
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // 프레젠테이션 저장
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**그림: 스타일이 변경된 SmartArt 도형**|

## **SmartArt 도형 색상 스타일 변경**
이 예제에서는任意의 SmartArt 도형에 대해 색상 스타일을 변경하는 방법을 학습합니다. 아래 샘플 코드는 특정 색상 스타일을 가진 SmartArt 도형에 접근하고 해당 스타일을 변경합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 인스턴스화하고 SmartArt 도형이 포함된 프레젠테이션을 로드합니다.
1. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
1. 첫 번째 슬라이드 내부의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SmartArt) 유형인지 확인하고, SmartArt인 경우 선택한 도형을 SmartArt로 형변환합니다.
1. 특정 색상 스타일을 가진 SmartArt 도형을 찾습니다.
1. SmartArt 도형에 새 색상 스타일을 설정합니다.
1. 프레젠테이션을 저장합니다.

```javascript
// Presentation 클래스를 인스턴스화
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // 첫 번째 슬라이드 가져오기
    var slide = pres.getSlides().get_Item(0);
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // 도형이 SmartArt 유형인지 확인합니다
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // 도형을 SmartArtEx로 형변환합니다
            var smart = shape;
            // SmartArt 색상 유형 확인 중
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // SmartArt 색상 유형 변경 중
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // 프레젠테이션 저장
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**그림: 색상 스타일이 변경된 SmartArt 도형**|

## **FAQ**

**SmartArt를 단일 객체로 애니메이션 적용할 수 있나요?**

예. SmartArt는 도형이므로 다른 도형과 마찬가지로 애니메이션 API(입장, 종료, 강조, 움직임 경로)를 통해 [표준 애니메이션](/slides/ko/nodejs-java/powerpoint-animation/)을 적용할 수 있습니다.

**슬라이드에서 내부 ID를 모를 경우 특정 SmartArt를 어떻게 찾을 수 있나요?**

대체 텍스트(AltText)를 설정하고 해당 값을 기준으로 도형을 검색하세요. 이는 대상 도형을 찾는 권장 방법입니다.

**SmartArt를 다른 도형과 그룹화할 수 있나요?**

예. SmartArt를 사진, 표 등 다른 도형과 그룹화한 다음 [그룹을 조작](/slides/ko/nodejs-java/group/)할 수 있습니다.

**특정 SmartArt의 이미지를 얻으려면 어떻게 해야 하나요(예: 미리보기나 보고서용)?**

도형의 썸네일/이미지를 내보내세요. 라이브러리는 개별 도형을 raster 파일(PNG/JPG/TIFF)로 [렌더링](/slides/ko/nodejs-java/create-shape-thumbnails/)할 수 있습니다.

**전체 프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지되나요?**

예. 렌더링 엔진은 [PDF 내보내기](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)에서 높은 충실도를 목표로 하며 다양한 품질 및 호환성 옵션을 제공합니다.