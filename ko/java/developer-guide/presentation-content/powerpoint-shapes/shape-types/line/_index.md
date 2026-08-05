---
title: Java에서 프레젠테이션에 선 모양 추가
linktitle: 선
type: docs
weight: 50
url: /ko/java/line/
keywords:
- 선
- 선 만들기
- 선 추가
- 일반 선
- 선 구성
- 선 사용자 정의
- 대시 스타일
- 화살표 머리
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 선 서식을 조작하는 방법을 학습하십시오. 속성, 메서드 및 예제를 확인하세요."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 슬라이드에 선 모양을 추가할 수 있습니다. 이 문서에서는 간단한 선을 만드는 방법과 선을 화살표처럼 보이도록 사용자 정의하는 방법을 보여줍니다.

선 모양을 슬라이드에 추가하고 시각적 모양을 조정하며 업데이트된 프레젠테이션을 저장하는 방법을 배웁니다. 예제에서는 스타일, 너비, 대시 패턴, 화살표 머리 옵션 및 채우기 색상과 같은 실용적인 선 서식 설정에 중점을 둡니다.

## **일반 선 만들기**

프레젠테이션의 선택된 슬라이드에 간단한 일반 선을 추가하려면 아래 단계를 따르세요:

- [Presentation] 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- [IShapeCollection] 객체에서 노출된 [addAutoShape] 메서드를 사용하여 Line 유형의 AutoShape을 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 선을 추가했습니다.

```java
// PPTX 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 선 유형의 AutoShape을 추가합니다
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX를 디스크에 저장합니다
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **화살표 모양 선 만들기**

Aspose.Slides for Java는 개발자가 선의 일부 속성을 구성하여 더 매력적으로 보이게 할 수 있도록 합니다. 선을 화살표처럼 보이게 하기 위해 몇 가지 속성을 구성해 보겠습니다. 이를 위해 아래 단계를 따르세요:

- [Presentation] 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- [IShapeCollection] 객체에서 노출된 [addAutoShape] 메서드를 사용하여 Line 유형의 AutoShape을 추가합니다.
- [Line Style]을 Aspose.Slides for Java에서 제공하는 스타일 중 하나로 설정합니다.
- 선의 Width를 설정합니다.
- [Dash Style]을 Aspose.Slides for Java에서 제공하는 스타일 중 하나로 설정합니다.
- 선 시작점의 [Arrow Head Style] 및 [Length]를 설정합니다.
- 선 끝점의 [Arrow Head Style] 및 [Length]를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
// PPTX 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 선 유형의 AutoShape을 추가합니다
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 선에 일부 서식을 적용합니다
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // PPTX를 디스크에 저장합니다
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**일반 선을 커넥터로 변환하여 도형에 '스냅'하도록 할 수 있나요?**

아니요. 일반 선([AutoShape]의 [Line] 유형)은 자동으로 커넥터가 되지 않습니다. 도형에 스냅하도록 하려면 전용 [Connector] 유형과 연결을 위한 [corresponding APIs](/slides/ko/java/connector/)를 사용하십시오.

**테마에서 선 속성을 상속받아 최종 값을 파악하기 어려운 경우 어떻게 해야 하나요?**

[Read the effective properties](/slides/ko/java/shape-effective-properties/)를 [ILineFormatEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilinefillformateffectivedata/) 인터페이스를 통해 확인하십시오—이 인터페이스들은 이미 상속 및 테마 스타일을 반영합니다.

**선의 편집(이동, 크기 조정) 잠금이 가능한가요?**

예. Shapes는 [lock objects](https://reference.aspose.com/slides/ko/java/com.aspose.slides/autoshape/#getAutoShapeLock--)를 제공하여 [disallow editing operations](/slides/ko/java/applying-protection-to-presentation/)을 수행할 수 있습니다.