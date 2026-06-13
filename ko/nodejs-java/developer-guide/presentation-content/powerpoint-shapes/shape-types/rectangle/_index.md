---
title: JavaScript로 프레젠테이션에 사각형 추가
linktitle: 사각형
type: docs
weight: 80
url: /ko/nodejs-java/rectangle/
keywords:
- 사각형 추가
- 사각형 만들기
- 사각형 도형
- 간단한 사각형
- 서식이 적용된 사각형
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용해 사각형을 추가하여 PowerPoint 프레젠테이션을 강화하고, 프로그래밍 방식으로 도형을 쉽게 디자인하고 수정할 수 있습니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 사각형 모양을 추가하는 방법을 보여줍니다. 간단한 사각형 만들기, 서식이 적용된 사각형 만들기, 그리고 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 내용을 다룹니다.

또한 단색 채우기 색상, 선 색상 및 선 두께와 같은 기본 사각형 서식을 적용하는 방법을 확인할 수 있습니다. 추가로, 문서의 FAQ에서는 둥근 모서리, 이미지 채우기, 시각 효과, 하이퍼링크, 도형 잠금, 내보내기 옵션 및 유효 속성 등과 관련된 사각형 작업을 안내합니다.

## **슬라이드에 사각형 추가**

이전 항목들처럼 이번에도 도형 추가에 대한 내용이며, 이번에 다룰 도형은 사각형입니다. 이 항목에서는 개발자가 Aspose.Slides를 사용하여 슬라이드에 간단하거나 서식이 적용된 사각형을 추가하는 방법을 설명합니다.

슬라이드에 간단한 사각형을 추가하려면 아래 단계에 따라 진행하십시오.

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 객체에서 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 메서드를 사용하여 사각형 유형의 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape)를 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 간단한 사각형을 추가했습니다.

```javascript
// PPTX를 나타내는 Presentation 클래스 인스턴스화
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드 가져오기
    var sld = pres.getSlides().get_Item(0);
    // 타원형 AutoShape 추가
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // PPTX 파일을 디스크에 저장
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **슬라이드에 서식이 적용된 사각형 추가**

슬라이드에 서식이 적용된 사각형을 추가하려면 아래 단계에 따라 진행하십시오.

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- [ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection) 객체에서 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 메서드를 사용하여 사각형 유형의 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape)를 추가합니다.
- 사각형의 [Fill Type](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FillType)을 Solid로 설정합니다.
- [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape) 객체와 연결된 [FillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FillFormat) 객체가 제공하는 [SolidFillColor.setColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) 메서드를 사용하여 사각형의 색상을 설정합니다.
- 사각형의 선 색상을 설정합니다.
- 사각형의 선 두께를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계는 아래 예제에 구현되어 있습니다.

```javascript
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    var sld = pres.getSlides().get_Item(0);
    // 타원형 AutoShape을 추가합니다
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // 타원 도형에 일부 서식을 적용합니다
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // 타원 선에 일부 서식을 적용합니다
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // PPTX 파일을 디스크에 저장합니다
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**둥근 모서리가 있는 사각형을 어떻게 추가하나요?**

둥근 모서리 [shape type](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapetype/)을 사용하고 도형 속성에서 코너 반경을 조정합니다; 기하학적 조정을 통해 코너별로 라운딩을 적용할 수도 있습니다.

**이미지(텍스처)로 사각형을 채우려면 어떻게 하나요?**

그림 [fill type](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/filltype/)을 선택하고 이미지 소스를 제공한 뒤 [stretching/tiling modes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillmode/)를 구성합니다.

**사각형에 그림자와 광채를 적용할 수 있나요?**

예. [Outer/inner shadow, glow, and soft edges](/slides/ko/nodejs-java/shape-effect/)를 사용할 수 있으며 매개변수를 조정할 수 있습니다.

**사각형을 하이퍼링크가 있는 버튼으로 만들 수 있나요?**

예. 도형 클릭에 [Assign a hyperlink](/slides/ko/nodejs-java/manage-hyperlinks/)을 지정하면 슬라이드, 파일, 웹 주소 또는 이메일로 이동할 수 있습니다.

**사각형이 이동하거나 변경되는 것을 어떻게 보호할 수 있나요?**

도형 잠금을 사용하십시오: 이동, 크기 조정, 선택 또는 텍스트 편집을 금지하여 레이아웃을 유지할 수 있습니다.

**사각형을 래스터 이미지 또는 SVG로 변환할 수 있나요?**

예. 지정된 크기/비율로 이미지를 만들기 위해 [render the shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getImage)할 수 있으며, 벡터 용도로 [export it as SVG](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/writeassvg/)도 가능합니다.

**테마와 상속을 고려한 사각형의 실제(효과적인) 속성을 빠르게 가져오려면 어떻게 해야 하나요?**

[Use the shape’s effective properties](/slides/ko/nodejs-java/shape-effective-properties/): API는 테마 스타일, 레이아웃 및 로컬 설정을 반영한 계산값을 반환하므로 서식 분석이 간소화됩니다.