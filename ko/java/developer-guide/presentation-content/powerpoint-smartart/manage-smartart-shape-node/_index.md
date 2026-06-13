---
title: "Java를 사용하여 프레젠테이션에서 SmartArt 도형 노드 관리"
linktitle: "SmartArt 도형 노드"
type: docs
weight: 30
url: /ko/java/manage-smartart-shape-node/
keywords:
- "SmartArt 노드"
- "자식 노드"
- "노드 추가"
- "노드 위치"
- "노드 접근"
- "노드 제거"
- "사용자 지정 위치"
- "어시스턴트 노드"
- "채우기 형식"
- "노드 렌더링"
- "PowerPoint"
- "프레젠테이션"
- "Java"
- "Aspose.Slides"
description: "Java용 Aspose.Slides로 PPT 및 PPTX에서 SmartArt 도형 노드를 관리합니다. 프레젠테이션을 효율화하기 위한 명확한 코드 샘플과 팁을 제공합니다."
---
## **개요**

PowerPoint 프레젠테이션의 SmartArt 그래픽은 텍스트를 포함하고 다이어그램 구조를 정의하는 노드로 구성됩니다. Aspose.Slides를 사용하면 이러한 SmartArt 노드를 프로그래밍 방식으로 작업할 수 있습니다: 새로운 노드와 자식 노드 추가, 특정 위치에 자식 노드 삽입, 기존 노드 접근, 텍스트, 레벨 및 위치 읽기.

이 문서에서는 SmartArt 도형 노드를 관리하는 방법을 설명합니다. 노드 제거, 인덱스 또는 위치를 통한 자식 노드 작업, 어시스턴트 노드를 일반 노드로 변경, SmartArt 노드 도형의 위치, 크기 및 회전 조정, 노드 채우기 형식 설정, SmartArt 자식 노드의 썸네일 이미지 생성 방법을 보여줍니다.

## **SmartArt 노드 추가**
Aspose.Slides for Java는 SmartArt 도형을 가장 쉽게 관리할 수 있는 API를 제공합니다. 아래 샘플 코드는 SmartArt 도형 내부에 노드와 자식 노드를 추가하는 방법을 보여줍니다.

1. SmartArt 도형이 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
1. 첫 번째 슬라이드 안의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt) 유형인지 확인하고, SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt)으로 형변환합니다.
1. SmartArt 도형의 [**NodeCollection**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt#getAllNodes--) 에서 [새 노드 추가](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)를 수행하고 TextFrame에 텍스트를 설정합니다.
1. 이제, 새로 추가된 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt) 노드에 [**Child Node**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNode#getChildNodes--)를 [Add](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) 하고 TextFrame에 텍스트를 설정합니다.
1. 프레젠테이션을 저장합니다.

```java
// 원하는 프레젠테이션을 로드합니다
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof SmartArt) 
        {
            // 도형을 SmartArt로 형변환합니다
            SmartArt smart = (SmartArt) shape;
    
            // 새 SmartArt 노드를 추가합니다
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // 텍스트를 추가합니다
            TemNode.getTextFrame().setText("Test");
    
            // 부모 노드에 새로운 자식 노드를 추가합니다. 컬렉션 끝에 추가됩니다
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // 텍스트를 추가합니다
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // 프레젠테이션을 저장합니다
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **특정 위치에 SmartArt 노드 추가**
다음 샘플 코드는 SmartArt 도형의 해당 노드에 속하는 자식 노드를 특정 위치에 추가하는 방법을 설명합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
1. 접근된 슬라이드에 [**StackedList**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtLayoutType#StackedList) 유형 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArt) 도형을 추가합니다.
1. 추가된 SmartArt 도형에서 첫 번째 노드에 접근합니다.
1. 선택된 [**Node**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtNode) 에 대해 위치 2에서 [**Child Node**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNode#getChildNodes--)를 추가하고 텍스트를 설정합니다.
1. 프레젠테이션을 저장합니다.

```java
// 프레젠테이션 인스턴스를 생성합니다
Presentation pres = new Presentation();
try {
    // 프레젠테이션 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);

    // Smart Art IShape 추가
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // 인덱스 0에 있는 SmartArt 노드에 접근합니다
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // 부모 노드에서 위치 2에 새 자식 노드 추가
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // 텍스트 추가
    chNode.getTextFrame().setText("Sample Text Added");

    // 프레젠테이션 저장
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt 노드 접근**
다음 샘플 코드는 SmartArt 도형 내부의 노드에 접근하는 방법을 보여줍니다. SmartArt의 LayoutType은 읽기 전용이며 SmartArt 도형을 추가할 때만 설정된다는 점에 유의하세요.

1. SmartArt 도형이 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
1. 첫 번째 슬라이드 안의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt) 유형인지 확인하고, SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt)으로 형변환합니다.
1. SmartArt 도형 내부의 모든 [**Nodes**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArt#getAllNodes--)를 순회합니다.
1. SmartArt 노드의 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```java
// Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : slide.getShapes()) 
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof ISmartArt) 
        {
            // 도형을 SmartArt로 형변환합니다
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt 내부의 모든 노드를 순회합니다
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 인덱스 i에 있는 SmartArt 노드에 접근합니다
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // SmartArt 노드 매개변수를 출력합니다
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt 자식 노드 접근**
다음 샘플 코드는 SmartArt 도형의 해당 노드에 속하는 자식 노드에 접근하는 방법을 보여줍니다.

1. SmartArt 도형이 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
1. 첫 번째 슬라이드 안의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt) 유형인지 확인하고, SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt)으로 형변환합니다.
1. SmartArt 도형 내부의 모든 [**Nodes**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArt#getAllNodes--)를 순회합니다.
1. 선택된 SmartArt 도형 [**Node**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtNode) 에 대해 해당 노드 내부의 모든 [**Child Nodes**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtNode#getChildNodes--)를 순회합니다.
1. [**Child Node**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNode#getChildNodes--)의 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```java
// Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : slide.getShapes()) 
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof ISmartArt) 
        {
            // 도형을 SmartArt로 형변환합니다
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt 내부의 모든 노드를 순회합니다
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // 인덱스 i에 있는 SmartArt 노드에 접근합니다
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // 인덱스 i에 있는 SmartArt 노드의 자식 노드를 순회합니다
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // SmartArt 노드의 자식 노드에 접근합니다
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // SmartArt 자식 노드 매개변수를 출력합니다
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **특정 위치에 SmartArt 자식 노드 접근**
이 예제에서는 SmartArt 도형의 해당 노드에 속하는 특정 위치에 있는 자식 노드에 접근하는 방법을 배웁니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 두 번째 슬라이드의 참조를 가져옵니다.
1. [**StackedList**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtLayoutType#StackedList) 유형 SmartArt 도형을 추가합니다.
1. 추가된 SmartArt 도형에 접근합니다.
1. 접근된 SmartArt 도형에서 인덱스 0에 해당하는 노드에 접근합니다.
1. 이제 **get_Item()** 메서드를 사용하여 해당 SmartArt 노드의 위치 1에 있는 [**Child Node**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNode#getChildNodes--)에 접근합니다.
1. [**Child Node**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNode#getChildNodes--)의 위치, 레벨 및 텍스트와 같은 정보를 접근하고 표시합니다.

```java
// 프레젠테이션을 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 첫 번째 슬라이드에 SmartArt 도형을 추가합니다
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // 인덱스 0에 있는 SmartArt 노드에 접근합니다
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // 부모 노드에서 위치 1에 있는 자식 노드에 접근합니다
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // SmartArt 자식 노드 매개변수를 출력합니다
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt 노드 제거**
이 예제에서는 SmartArt 도형 내부의 노드를 제거하는 방법을 배웁니다.

1. SmartArt 도형이 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
1. 첫 번째 슬라이드 안의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt) 유형인지 확인하고, SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt)으로 형변환합니다.
1. 해당 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt) 에 0개 이상의 노드가 있는지 확인합니다.
1. 삭제할 SmartArt 노드를 선택합니다.
1. 이제 [**RemoveNode**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) 메서드를 사용하여 선택한 노드를 제거합니다.
1. 프레젠테이션을 저장합니다.

```java
// 원하는 프레젠테이션을 로드합니다
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof ISmartArt) 
        {
            // 도형을 SmartArt로 형변환합니다
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 인덱스 0에 있는 SmartArt 노드에 접근합니다
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // 선택한 노드를 제거합니다
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // 프레젠테이션을 저장합니다
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **특정 위치에 SmartArt 노드 제거**
이 예제에서는 특정 위치에 있는 SmartArt 도형 내부의 노드를 제거하는 방법을 배웁니다.

1. SmartArt 도형이 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 첫 번째 슬라이드의 참조를 가져옵니다.
1. 첫 번째 슬라이드 안의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt) 유형인지 확인하고, SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt)으로 형변환합니다.
1. 인덱스 0에 해당하는 SmartArt 도형 노드를 선택합니다.
1. 이제 선택된 SmartArt 노드에 2개 이상의 자식 노드가 있는지 확인합니다.
1. [**RemoveNode**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) 메서드를 사용하여 **Position 1**에 있는 노드를 제거합니다.
1. 프레젠테이션을 저장합니다.

```java
// 원하는 프레젠테이션을 로드합니다
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof SmartArt) 
        {
            // 도형을 SmartArt로 형변환합니다
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // 인덱스 0에 있는 SmartArt 노드에 접근합니다
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // 위치 1에 있는 자식 노드를 제거합니다
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // 프레젠테이션을 저장합니다
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt 객체에서 자식 노드의 사용자 지정 위치 설정**
이제 Aspose.Slides for Java는 [SmartArtShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtShape) 의 [X](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShape#setX-float-) 및 [Y](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShape#setY-float-) 속성 설정을 지원합니다. 아래 코드 조각은 사용자 지정 SmartArtShape 위치, 크기 및 회전을 설정하는 방법을 보여줍니다. 또한 새 노드를 추가하면 모든 노드의 위치와 크기가 재계산된다는 점에 유의하세요. 사용자 지정 위치 설정을 통해 필요에 따라 노드를 배치할 수 있습니다.

```java
// Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // SmartArt 도형을 새 위치로 이동합니다
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // SmartArt 도형의 너비를 변경합니다
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // SmartArt 도형의 높이를 변경합니다
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // SmartArt 도형의 회전을 변경합니다
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **어시스턴트 노드 확인**
{{% alert color="primary" %}} 

이 문서에서는 Aspose.Slides for Java를 사용하여 프레젠테이션 슬라이드에 프로그래밍 방식으로 추가된 SmartArt 도형의 기능을 자세히 살펴봅니다.

{{% /alert %}} 

다음 섹션에서 조사에 사용할 기본 SmartArt 도형은 다음과 같습니다.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**그림: 슬라이드의 원본 SmartArt 도형**|

다음 샘플 코드는 SmartArt 노드 컬렉션에서 **Assistant Nodes**를 식별하고 변경하는 방법을 조사합니다.

1. SmartArt 도형이 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 두 번째 슬라이드의 참조를 가져옵니다.
1. 첫 번째 슬라이드 안의 모든 도형을 순회합니다.
1. 도형이 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt) 유형인지 확인하고, SmartArt인 경우 선택된 도형을 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt)으로 형변환합니다.
1. SmartArt 도형 내부의 모든 노드를 순회하며 [**Assistant Nodes**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtNode#isAssistant--)인지 확인합니다.
1. Assistant Node의 상태를 일반 노드로 변경합니다.
1. 프레젠테이션을 저장합니다.

```java
// 프레젠테이션 인스턴스를 생성합니다
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // 첫 번째 슬라이드 내부의 모든 도형을 순회합니다
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // 도형이 SmartArt 유형인지 확인합니다
        if (shape instanceof ISmartArt) 
        {
            // 도형을 SmartArt로 형변환합니다
            ISmartArt smart = (SmartArt) shape;
    
            // SmartArt 도형의 모든 노드를 순회합니다
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // 노드가 Assistant 노드인지 확인합니다
                if (node.isAssistant()) 
                {
                    // Assistant 노드를 false 로 설정하고 일반 노드로 변경합니다
                    node.isAssistant();
                }
            }
        }
    }
    
    // 프레젠테이션을 저장합니다
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**그림: 슬라이드 내 SmartArt 도형에서 변경된 Assistant Nodes**|

## **노드의 채우기 형식 설정**
Aspose.Slides for Java를 사용하면 사용자 지정 SmartArt 도형을 추가하고 채우기 형식을 설정할 수 있습니다. 이 문서에서는 SmartArt 도형을 만들고 접근하여 채우기 형식을 설정하는 방법을 설명합니다.

다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
1. [**LayoutType**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) 을 설정하여 [SmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArt) 도형을 추가합니다.
1. SmartArt 도형 노드에 대한 [**FillFormat**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShape#getFillFormat--) 을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
// 프레젠테이션을 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 슬라이드에 접근합니다
    ISlide slide = pres.getSlides().get_Item(0);
    
    // SmartArt 도형과 노드를 추가합니다
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // 노드 채우기 색상을 설정합니다
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // 프레젠테이션을 저장합니다
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt 자식 노드의 썸네일 생성**
개발자는 아래 단계에 따라 SmartArt 자식 노드의 썸네일을 생성할 수 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [SmartArt 추가](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) 합니다.
1. 인덱스를 사용하여 노드의 참조를 가져옵니다.
1. 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일을 저장합니다.

```java
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // SmartArt를 추가합니다
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // 인덱스를 사용하여 노드의 참조를 가져옵니다
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // 썸네일을 가져옵니다
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // 썸네일을 저장합니다
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**SmartArt 애니메이션이 지원되나요?**

예. SmartArt는 일반 도형으로 처리되므로 [표준 애니메이션](/slides/ko/java/shape-animation/) (입장, 퇴장, 강조, 움직임 경로)을 적용하고 타이밍을 조정할 수 있습니다. 필요에 따라 SmartArt 노드 내부의 도형에도 애니메이션을 적용할 수 있습니다.

**슬라이드에서 내부 ID를 모를 경우 특정 SmartArt를 어떻게 신뢰성 있게 찾을 수 있나요?**

[대체 텍스트](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getAlternativeText--) 로 설정하고 검색하세요. SmartArt에 고유한 AltText를 지정하면 내부 식별자에 의존하지 않고 프로그래밍 방식으로 찾을 수 있습니다.

**프레젠테이션을 PDF로 변환할 때 SmartArt 모양이 유지되나요?**

예. Aspose.Slides는 [PDF 내보내기](/slides/ko/java/convert-powerpoint-to-pdf/) 동안 SmartArt를 높은 시각적 충실도로 렌더링하여 레이아웃, 색상 및 효과를 보존합니다.

**전체 SmartArt의 이미지를 추출해 미리보기나 보고서에 사용할 수 있나요?**

예. SmartArt 도형을 [래스터 형식](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getImage-int-float-float-)이나 [SVG](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) 로 렌더링할 수 있어 썸네일, 보고서 또는 웹 용도로 적합합니다.