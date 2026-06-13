---
title: Java에서 프레젠테이션에 사각형 추가
linktitle: 사각형
type: docs
weight: 80
url: /ko/java/rectangle/
keywords:
- 사각형 추가
- 사각형 만들기
- 사각형 도형
- 단순 사각형
- 서식이 적용된 사각형
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 사각형을 추가함으로써 PowerPoint 프레젠테이션을 강화하고, 프로그래밍 방식으로 도형을 쉽게 디자인하고 수정할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 사각형 도형을 추가하는 방법을 보여줍니다. 간단한 사각형 만들기, 서식이 적용된 사각형 만들기, 그리고 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 방법을 다룹니다.

또한 단색 채우기 색상, 선 색상 및 선 두께와 같은 기본 사각형 서식을 적용하는 방법을 확인할 수 있습니다. 추가로 문서의 FAQ에서는 둥근 모서리, 그림 채우기, 시각 효과, 하이퍼링크, 도형 잠금, 내보내기 옵션 및 실효 속성 등 관련 사각형 작업을 안내합니다.

## **슬라이드에 사각형 추가**
프레젠테이션의 선택한 슬라이드에 간단한 사각형을 추가하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 슬라이드의 인덱스를 사용하여 해당 슬라이드에 대한 참조를 가져옵니다.
- [IShapeCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection) 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 메서드를 사용하여 사각형 유형의 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape)를 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 간단한 사각형을 추가했습니다.

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // Ellipse 유형의 AutoShape를 추가합니다
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // PPTX 파일을 디스크에 씁니다
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **서식이 적용된 사각형을 슬라이드에 추가**
슬라이드에 서식이 적용된 사각형을 추가하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 슬라이드의 인덱스를 사용하여 해당 슬라이드에 대한 참조를 가져옵니다.
- [IShapeCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection) 객체가 제공하는 [addAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 메서드를 사용하여 사각형 유형의 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape)를 추가합니다.
- 사각형의 [Fill Type](https://reference.aspose.com/slides/ko/java/com.aspose.slides/FillType)을 Solid(단색)으로 설정합니다.
- [IFillFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IFillFormat) 객체와 연결된 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShape) 객체에서 제공하는 [SolidFillColor.setColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) 메서드를 사용하여 사각형의 색상을 설정합니다.
- 사각형 테두리의 색상을 설정합니다.
- 사각형 테두리의 두께를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계는 아래 예제에 구현되어 있습니다.

```java
// PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.getSlides().get_Item(0);

    // 타원 유형의 AutoShape를 추가합니다
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 타원 도형에 일부 서식을 적용합니다
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 타원의 선에 일부 서식을 적용합니다
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX 파일을 디스크에 씁니다
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**어떻게 하면 모서리가 둥근 사각형을 추가할 수 있나요?**  
라운드 코너 [shape type](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shapetype/)을 사용하고 도형 속성에서 모서리 반경을 조정합니다. 기하학적 조정을 통해 각 모서리마다 라운딩을 적용할 수도 있습니다.

**이미지(텍스처)로 사각형을 채우려면 어떻게 해야 하나요?**  
[fill type](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)을 picture로 선택하고 이미지 소스를 제공한 뒤 [stretching/tiling modes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/picturefillmode/)을 구성합니다.

**사각형에 그림자와 광선을 적용할 수 있나요?**  
예. [외부/내부 그림자, 광선, 부드러운 가장자리](/slides/ko/java/shape-effect/)를 사용할 수 있으며 매개변수를 조정할 수 있습니다.

**사각형을 하이퍼링크가 있는 버튼으로 만들 수 있나요?**  
예. [하이퍼링크 지정](/slides/ko/java/manage-hyperlinks/)을 통해 도형 클릭 시 슬라이드, 파일, 웹 주소 또는 이메일로 이동하도록 할 수 있습니다.

**사각형이 이동하거나 변경되지 않도록 보호할 수 있나요?**  
[도형 잠금](/slides/ko/java/applying-protection-to-presentation/)을 사용하면 이동, 크기 조정, 선택 또는 텍스트 편집을 금지하여 레이아웃을 유지할 수 있습니다.

**사각형을 래스터 이미지나 SVG로 변환할 수 있나요?**  
예. [shape] 객체의 [render] 메서드(https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getImage-int-float-float-)를 사용해 지정된 크기/스케일로 이미지를 렌더링하거나, [SVG로 내보내기](/slides/ko/java/shape-effective-properties/)를 통해 벡터 형식으로 저장할 수 있습니다.

**테마와 상속을 고려한 사각형의 실제(실효) 속성을 빠르게 확인하려면 어떻게 해야 하나요?**  
[도형의 실효 속성](/slides/ko/java/shape-effective-properties/)을 사용하면 API가 테마 스타일, 레이아웃 및 로컬 설정을 반영한 계산된 값을 반환하여 서식 분석을 단순화합니다.