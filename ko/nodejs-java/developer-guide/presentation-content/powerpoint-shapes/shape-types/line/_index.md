---
title: JavaScript에서 프레젠테이션에 선 모양 추가
linktitle: 선
type: docs
weight: 50
url: /ko/nodejs-java/line/
keywords:
- 선
- 선 만들기
- 선 추가
- 일반 선
- 선 구성
- 선 사용자 지정
- 대시 스타일
- 화살표 머리
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 프레젠테이션에서 선 서식을 조작하는 방법을 배웁니다. 속성, 메서드 및 예제를 확인하세요."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 슬라이드에 선 모양을 추가할 수 있습니다. 이 문서에서는 간단한 선을 만드는 방법과 선을 화살표처럼 보이도록 사용자 정의하는 방법을 보여줍니다.

선 모양을 슬라이드에 추가하고 시각적 모양을 조정하며 업데이트된 프레젠테이션을 저장하는 방법을 배우게 됩니다. 예제에서는 스타일, 너비, 대시 패턴, 화살촉 옵션 및 채우기 색상과 같은 실용적인 선 형식 설정에 중점을 둡니다.

## **일반 선 만들기**

프레젠테이션의 선택된 슬라이드에 간단한 일반 선을 추가하려면 아래 단계를 따라 주세요:

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 슬라이드의 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 메서드를 사용하여 Line 유형의 AutoShape를 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 선을 추가했습니다.

```javascript
// PPTX 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // line 유형의 AutoShape를 추가합니다
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // PPTX를 디스크에 저장합니다
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **화살표 모양 선 만들기**

Node.js용 Java 버전의 Aspose.Slides는 개발자가 선의 일부 속성을 구성하여 더욱 매력적으로 보이게 할 수 있습니다. 선을 화살표처럼 보이게 몇 가지 속성을 구성해 보겠습니다. 아래 단계를 따라 주세요:

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 슬라이드의 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 메서드를 사용하여 Line 유형의 AutoShape를 추가합니다.
- [Line Style](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/LineStyle)을 Aspose.Slides for Node.js via Java에서 제공하는 스타일 중 하나로 설정합니다.
- 선의 너비를 설정합니다.
- 선의 [Dash Style](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/LineDashStyle)을 Aspose.Slides for Node.js via Java에서 제공하는 스타일 중 하나로 설정합니다.
- 선 시작점의 [Arrow Head Style](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/LineArrowheadStyle)와 [Length](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/LineArrowheadLength)를 설정합니다.
- 선 끝점의 [Arrow Head Style](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/LineArrowheadStyle)와 [Length](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/LineArrowheadLength)를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```javascript
// PPTX 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // line 유형의 AutoShape를 추가합니다
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // 선에 일부 서식을 적용합니다
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // PPTX를 디스크에 저장합니다
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**일반 선을 커넥터로 변환하여 도형에 "스냅"되게 할 수 있나요?**

아니요. 일반 선([Line](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapetype/) 유형의 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/))은 자동으로 커넥터가 되지 않습니다. 도형에 스냅되게 하려면 전용 [Connector](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/connector/) 유형과 연결을 위한 [corresponding APIs](/slides/ko/nodejs-java/connector/)를 사용하십시오.

**테마에서 상속된 선 속성이라 최종 값을 파악하기 어려운 경우 어떻게 해야 하나요?**

`ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` 클래스를 통해 [효과적인 속성 읽기](/slides/ko/nodejs-java/shape-effective-properties/)를 수행하십시오—이 클래스들은 이미 상속 및 테마 스타일을 반영합니다.

**선을 편집(이동, 크기 조정)으로부터 잠글 수 있나요?**

예. 도형은 편집 작업을 허용하지 않도록 하는 [lock objects](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/getautoshapelock/)를 제공합니다.