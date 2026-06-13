---
title: Java에서 그룹 프레젠테이션 도형
linktitle: 도형 그룹
type: docs
weight: 40
url: /ko/java/group/
keywords:
- 그룹 도형
- 도형 그룹
- 그룹 추가
- 대체 텍스트
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 도형을 그룹화하고 그룹 해제하는 방법을 배우세요—빠르고 단계별 가이드와 무료 Java 코드를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 그룹 도형을 사용하는 방법을 설명합니다. 슬라이드에 그룹 도형을 추가하고, 그 안에 도형을 배치하고, 업데이트된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 그룹 내부에 저장된 도형에 접근하여 `AlternativeText` 값을 읽는 방법을 시연합니다. 추가로 중첩 그룹, z‑order 및 잠금 옵션과 같은 관련 그룹 도형 기능도 간략히 다룹니다.

## **그룹 도형 추가**
Aspose.Slides는 슬라이드에서 그룹 도형을 작업할 수 있도록 지원합니다. 이 기능은 개발자가 보다 풍부한 프레젠테이션을 만들 수 있게 도와줍니다. Aspose.Slides for Java는 그룹 도형을 추가하거나 접근하는 것을 지원합니다. 추가된 그룹 도형에 도형을 넣어 채우거나 그룹 도형의 속성을 어떤 것이든 접근할 수 있습니다. Aspose.Slides for Java를 사용하여 슬라이드에 그룹 도형을 추가하려면 다음을 수행합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스를 인스턴스화합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
1. 슬라이드에 그룹 도형을 추가합니다.
1. 추가된 그룹 도형에 도형을 넣습니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 도형을 추가합니다.

```java
// Presentation 클래스 인스턴스화
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드 가져오기
    ISlide sld = pres.getSlides().get_Item(0);

    // 슬라이드의 도형 컬렉션에 접근
    IShapeCollection slideShapes = sld.getShapes();

    // 슬라이드에 그룹 도형 추가
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // 추가된 그룹 도형 내부에 도형 추가
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // 그룹 도형 프레임 추가
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // PPTX 파일을 디스크에 저장
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **AltText 속성 접근**
이 항목에서는 그룹 도형을 추가하고 슬라이드의 그룹 도형에 대한 AltText 속성에 접근하는 간단한 단계와 코드 예제를 제공합니다. Aspose.Slides for Java를 사용하여 슬라이드의 그룹 도형에 대한 AltText에 접근하려면 다음을 수행합니다.

1. PPTX 파일을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스를 인스턴스화합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
1. 슬라이드의 도형 컬렉션에 접근합니다.
1. 그룹 도형에 접근합니다.
1. [AlternativeText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShape#getAlternativeText--) 속성에 접근합니다.

아래 예제는 그룹 도형의 대체 텍스트에 접근합니다.

```java
// PPTX 파일을 나타내는 Presentation 클래스 인스턴스화
Presentation pres = new Presentation("AltText.pptx");
try {
    // 첫 번째 슬라이드 가져오기
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // 슬라이드의 도형 컬렉션에 접근
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // 그룹 도형에 접근합니다.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // AltText 속성에 접근
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**중첩 그룹화(그룹 내부에 그룹)가 지원되나요?**

예. [GroupShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/groupshape/)에는 계층 구조 지원을 직접 나타내는 [getParentGroup](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getParentGroup--) 메서드가 있어, 그룹이 다른 그룹의 하위가 될 수 있습니다.

**슬라이드의 다른 개체에 대한 그룹의 z‑order를 어떻게 제어하나요?**

[GroupShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/groupshape/)의 [getZOrderPosition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getZOrderPosition--) 메서드를 사용하여 디스플레이 스택에서의 위치를 확인합니다.

**이동/편집/그룹 해제를 방지할 수 있나요?**

예. 그룹의 잠금 섹션은 [GroupShapeLock](https://reference.aspose.com/slides/ko/java/com.aspose.slides/groupshape/#getGroupShapeLock--)을 통해 노출되며, 객체에 대한 작업을 제한할 수 있습니다.