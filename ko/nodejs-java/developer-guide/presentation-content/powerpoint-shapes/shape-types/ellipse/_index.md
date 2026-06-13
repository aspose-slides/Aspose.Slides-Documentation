---
title: JavaScript에서 프레젠테이션에 타원 추가
linktitle: 타원
type: docs
weight: 30
url: /ko/nodejs-java/ellipse/
keywords:
- 타원
- 도형
- 타원 추가
- 타원 만들기
- 타원 그리기
- 서식이 지정된 타원
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js용 Aspose.Slides에서 타원 도형을 생성하고 서식 지정 및 조작하는 방법을 배우세요—JavaScript 코드 예제가 포함되어 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 타원 도형을 추가하는 방법을 보여줍니다. 간단한 타원 만들기, 서식이 지정된 타원 만들기, 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 내용을 다룹니다. 또한 타원의 위치와 크기 작업, 쌓임 순서 제어, 애니메이션 효과 적용과 같은 관련 질문도 다룹니다.

## **타원 만들기**
프레젠테이션의 선택된 슬라이드에 간단한 타원을 추가하려면 다음 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation)
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- ShapeCollection 객체에서 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 메서드를 사용하여 Ellipse 유형의 AutoShape을 추가합니다.[ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection)
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 첫 번째 슬라이드에 타원을 추가했습니다.

```javascript
// PPTX를 나타내는 Presentation 클래스 인스턴스화
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드 가져오기
    var sld = pres.getSlides().get_Item(0);
    // 타원 유형의 AutoShape 추가
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // PPTX 파일을 디스크에 저장
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **서식이 지정된 타원 만들기**
슬라이드에 더 잘 서식이 지정된 타원을 추가하려면 다음 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation)
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- ShapeCollection 객체에서 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 메서드를 사용하여 Ellipse 유형의 AutoShape을 추가합니다.[ShapeCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ShapeCollection)
- 타원의 채우기 유형을 Solid(단색)으로 설정합니다.
- FillFormat 객체에 연결된 Shape 객체에서 제공하는 SolidFillColor.Color 속성을 사용하여 타원의 색상을 설정합니다.[FillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FillFormat)[Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Shape)
- 타원의 선 색상을 설정합니다.
- 타원의 선 두께를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 서식이 지정된 타원을 추가했습니다.

```javascript
// PPTX를 나타내는 Presentation 클래스를 인스턴스화
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드 가져오기
    var sld = pres.getSlides().get_Item(0);
    // 타원 유형의 AutoShape 추가
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // 타원 도형에 일부 서식 적용
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // 타원 선에 일부 서식 적용
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // PPTX 파일을 디스크에 저장
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **FAQ**

**슬라이드 단위에 대해 타원의 정확한 위치와 크기를 어떻게 설정합니까?**

좌표와 크기는 일반적으로 **포인트(point)** 단위로 지정됩니다. 예측 가능한 결과를 위해 슬라이드 크기를 기준으로 계산하고, 필요한 밀리미터나 인치를 포인트로 변환한 후 값을 할당하십시오.

**다른 객체 위나 아래에 타원을 배치하려면(쌓임 순서 제어) 어떻게 해야 합니까?**

객체를 앞으로 가져오거나 뒤로 보내는 방식으로 그리기 순서를 조정합니다. 이를 통해 타원이 다른 객체와 겹치거나 뒤에 있는 객체를 드러낼 수 있습니다.

**타원의 나타남 또는 강조를 어떻게 애니메이션합니까?**

[Apply](/slides/ko/nodejs-java/shape-animation/) 링크를 사용하여 도형에 등장, 강조 또는 퇴장 효과를 적용하고, 트리거와 타이밍을 구성하여 애니메이션이 언제, 어떻게 재생될지 제어합니다.