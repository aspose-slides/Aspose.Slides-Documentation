---
title: Android에서 프레젠테이션에 타원 추가
linktitle: 타원
type: docs
weight: 30
url: /ko/androidjava/ellipse/
keywords:
- 타원
- 도형
- 타원 추가
- 타원 만들기
- 타원 그리기
- 서식이 지정된 타원
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 PPT 및 PPTX 프레젠테이션에 타원 도형을 생성, 서식 지정 및 조작하는 방법을 배우세요—Java 코드 예제가 포함됩니다."
---
## **Overview**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 타원 도형을 추가하는 방법을 보여줍니다. 간단한 타원 만들기, 서식이 지정된 타원 만들기, 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 내용을 다룹니다. 또한 타원의 위치와 크기 작업, 스택 순서 제어, 애니메이션 효과 적용과 같은 관련 질문도 다룹니다.

## **Create an Ellipse**
프레젠테이션의 선택된 슬라이드에 간단한 타원을 추가하려면 아래 단계를 따르세요:

- Presentation 클래스를 인스턴스화합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- IShapeCollection 객체가 제공하는 addAutoShape 메서드를 사용하여 Ellipse 유형의 AutoShape를 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 첫 번째 슬라이드에 타원을 추가했습니다

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 타원 유형의 AutoShape를 추가합니다
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // PPTX 파일을 디스크에 저장합니다
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create a Formatted Ellipse**
슬라이드에 서식이 지정된 타원을 추가하려면 아래 단계를 따르세요:

- Presentation 클래스를 인스턴스화합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- IShapeCollection 객체가 제공하는 addAutoShape 메서드를 사용하여 Ellipse 유형의 AutoShape를 추가합니다.
- 타원의 Fill Type을 Solid(단색)으로 설정합니다.
- IShape 객체와 연결된 FillFormat 객체가 제공하는 SolidFillColor.Color 속성을 사용하여 타원의 색을 설정합니다.
- 타원 윤곽선의 색을 설정합니다.
- 타원 윤곽선의 너비를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 서식이 지정된 타원을 추가했습니다.

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 타원 유형의 AutoShape를 추가합니다
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 타원 도형에 서식을 적용합니다
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // 타원 윤곽선에 서식을 적용합니다
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX 파일을 디스크에 저장합니다
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**How do I set the exact position and size of an ellipse with respect to the slide's units?**

좌표와 크기는 일반적으로 **포인트** 단위로 지정합니다. 예측 가능한 결과를 얻으려면 슬라이드 크기를 기준으로 계산하고, 필요한 밀리미터나 인치를 포인트로 변환한 후 값을 할당하십시오.

**How can I place an ellipse above or below other objects (control stacking order)?**

객체를 앞쪽으로 가져오거나 뒤로 보내어 그리기 순서를 조정합니다. 이렇게 하면 타원이 다른 객체 위에 겹치거나 그 아래에 있는 객체를 드러낼 수 있습니다.

**How do I animate the appearance or emphasis of an ellipse?**

[Apply](/slides/ko/androidjava/shape-animation/) 입장, 강조 또는 퇴장 효과를 도형에 적용하고, 트리거와 타이밍을 구성하여 애니메이션이 언제 어떻게 재생되는지 조정합니다.