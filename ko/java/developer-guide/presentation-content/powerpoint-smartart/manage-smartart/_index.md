---
title: Java를 사용하여 PowerPoint 프레젠테이션에서 SmartArt 관리
linktitle: SmartArt 관리
type: docs
weight: 10
url: /ko/java/manage-smartart/
keywords:
- 스마트아트
- SmartArt 텍스트
- 레이아웃 유형
- 숨김 속성
- 조직도
- 그림 조직도
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 명확한 코드 예제로 PowerPoint SmartArt를 만들고 편집하는 방법을 배우고, 슬라이드 디자인 및 자동화를 가속화하세요."
---
## **개요**

SmartArt는 노드, 노드 도형 및 레이아웃으로 구성된 PowerPoint 다이어그램입니다. Aspose.Slides for Java를 사용하면 SmartArt를 생성하고, 노드에서 텍스트를 읽으며, 레이아웃을 변경하고, 숨겨진 노드를 검사하고, 조직도 레이아웃을 구성하며, 그림 조직도를 만들 수 있습니다.

## **SmartArt 개체에서 텍스트 가져오기**

SmartArt 노드에는 하나 이상의 도형이 포함될 수 있습니다. 표시되는 텍스트를 읽으려면 [ISmartArt.getAllNodes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ismartart/#getAllNodes--)를 반복한 다음, [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ismartartshape/#getTextFrame--)이 반환하는 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)을 읽으십시오.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt 개체의 레이아웃 유형 변경**

SmartArt 레이아웃은 노드가 배치되고 연결되는 방식을 제어합니다. 다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` 값을 사용하여 SmartArt 개체를 생성하고, 이를 `BasicProcess` 값으로 변경한 뒤 프레젠테이션을 저장합니다.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SmartArt 노드가 숨겨졌는지 확인**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ismartartnode/#isHidden--)은(는) SmartArt 데이터 모델에서 노드가 숨겨져 있는지 여부를 나타냅니다. 선택한 레이아웃이 해당 노드를 보이는 다이어그램 요소로 표시하지 않더라도 숨겨진 노드는 구조에 존재할 수 있습니다.

다음 예제는 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` 값을 사용하는 SmartArt 개체에 노드를 추가하고 해당 노드의 숨김 상태를 확인합니다.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **조직도 레이아웃 가져오기 또는 설정하기**

조직도 레이아웃을 사용하는 SmartArt 다이어그램의 경우, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) 및 [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)은(는) 자식 노드가 부모 노드 아래에 어떻게 배치되는지를 정의합니다. 예를 들어, 선택한 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/OrganizationChartLayoutType)에 따라 자식 노드를 왼쪽, 오른쪽 또는 양쪽에서 매달리도록 설정할 수 있습니다.

다음 예제는 조직도를 생성하고 첫 번째 노드의 레이아웃을 [OrganizationChartLayoutType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` 값으로 설정합니다.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그림 조직도 만들기**

그림 조직도는 이미지 자리 표시자를 포함하는 계층 다이어그램을 위해 설계된 SmartArt 레이아웃입니다. 슬라이드에 SmartArt 개체를 추가할 때 [SmartArtLayoutType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` 값을 사용하십시오.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**SmartArt가 RTL 언어에 대해 미러링 또는 역방향을 지원합니까?**

예. 선택한 SmartArt 레이아웃이 역방향을 지원하는 경우, [ISmartArt.setReversed](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ismartart/#setReversed-boolean-) 메서드는 다이어그램 방향을 왼쪽에서 오른쪽에서 오른쪽에서 왼쪽(또는 그 반대로) 전환합니다.

**포맷을 유지하면서 같은 슬라이드 또는 다른 프레젠테이션에 SmartArt를 복사하려면 어떻게 해야 하나요?**

SmartArt가 포함된 슬라이드를 [ShapeCollection.addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)을 사용하여 [SmartArt 도형을 복제](/slides/ko/java/shape-manipulations/)하거나, 전체 슬라이드를 [복제](/slides/ko/java/clone-slides/)할 수 있습니다. 두 방법 모두 크기, 위치 및 서식을 유지합니다.

**미리보기 또는 웹 내보내기를 위해 SmartArt를 래스터 이미지로 렌더링하려면 어떻게 해야 하나요?**

[슬라이드](/slides/ko/java/convert-powerpoint-to-png/) 또는 전체 프레젠테이션을 PNG 또는 JPEG로 렌더링합니다. SmartArt는 슬라이드의 일부로 렌더링됩니다.

**슬라이드에 여러 SmartArt 개체가 있을 경우 특정 SmartArt 개체를 어떻게 찾을 수 있나요?**

SmartArt 도형에 고유한 [Shape.getAlternativeText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getAlternativeText--) 또는 [Shape.getName](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getName--) 값을 설정하고, [BaseSlide.getShapes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/baseslide/#getShapes--)에서 해당 값을 검색한 다음, 일치하는 도형이 [ISmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ismartart/)인지 확인합니다.