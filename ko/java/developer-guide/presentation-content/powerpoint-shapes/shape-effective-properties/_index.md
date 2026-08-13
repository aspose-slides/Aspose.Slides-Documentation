---
title: Java에서 프레젠테이션의 도형 Effective 속성 가져오기
linktitle: Effective 속성
type: docs
weight: 50
url: /ko/java/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 라이트 릭
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 형식
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java가 정확한 PowerPoint 렌더링을 위해 효과적인 도형 속성을 계산하고 적용하는 방법을 알아보세요."
---
## **개요**

이 항목은 **local** 및 **effective** 속성 간의 차이를 설명합니다. Local 값은 특정 서식 수준에서 직접 설정된 값으로, 예를 들어:

1. 슬라이드의 구획 속성.
1. 레이아웃 또는 마스터 슬라이드의 프로토타입 도형 텍스트 스타일(구획의 텍스트 프레임 도형에 하나가 있을 때).
1. 프레젠테이션의 전역 텍스트 설정.

Local 값은 어느 수준에서도 정의하거나 생략할 수 있습니다. Aspose.Slides가 최종 "as rendered" 서식이 필요할 때는 상속 체인을 해결하여 **effective** 값을 반환합니다. 로컬 형식 객체에서 `getEffective` 메서드를 호출하면 이를 얻을 수 있습니다.

다음 예제는 effective 값을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임과 최소 하나의 구획을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape)이라고 가정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Effective formatting data는 상속이 적용된 후 현재 계산된 서식을 나타냅니다. 현재 구현에서는 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPortionFormatEffectiveData)와 같은 일부 effective 데이터 객체가 내부에 캐시될 수 있습니다. 부모 또는 상속된 서식을 변경한 후 `getEffective`를 다시 호출하면 캐시된 데이터를 새로 고칠 수 있으며, 이전에 얻은 객체는 더 이상 이전 상태를 나타내지 않을 수 있습니다. 이후에 재사용하기 위해 effective 값을 보존해야 하는 경우, 글꼴 높이, 채우기 색, 글꼴 스타일 또는 정렬과 같은 필요한 속성을 자체 데이터 객체에 복사하십시오.
{{% /alert %}}

## **카메라의 Effective 속성 가져오기**

Aspose.Slides를 사용하면 카메라의 effective 속성을 가져올 수 있습니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ICameraEffectiveData) 인터페이스는 effective 카메라 속성을 포함하는 불변 객체를 나타냅니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ICameraEffectiveData) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IThreeDFormatEffectiveData)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IThreeDFormat)에 대한 effective 값을 제공합니다.

다음 코드 샘플은 카메라에 대한 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Light Rig의 Effective 속성 가져오기**

Aspose.Slides를 사용하면 라이트 릭(Light Rig)의 effective 속성을 가져올 수 있습니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ILightRigEffectiveData) 인터페이스는 effective 라이트 릭 속성을 포함하는 불변 객체를 나타냅니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ILightRigEffectiveData) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IThreeDFormatEffectiveData)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IThreeDFormat)에 대한 effective 값을 제공합니다.

다음 코드 샘플은 라이트 릭에 대한 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **베벨 도형의 Effective 속성 가져오기**

Aspose.Slides를 사용하면 도형 베벨의 effective 속성을 가져올 수 있습니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeBevelEffectiveData) 인터페이스는 도형의 effective 면-릴리프 속성을 포함하는 불변 객체를 나타냅니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IShapeBevelEffectiveData) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IThreeDFormatEffectiveData)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IThreeDFormat)에 대한 effective 값을 제공합니다.

다음 코드 샘플은 도형의 상단 베벨에 대한 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형에 3D 서식이 적용되어 있다고 가정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **텍스트 프레임의 Effective 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 프레임의 effective 속성을 가져올 수 있습니다. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITextFrameFormatEffectiveData) 인터페이스에는 effective 텍스트 프레임 서식 속성이 포함됩니다.

다음 코드 샘플은 텍스트 프레임의 effective 서식 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape)이라고 가정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **텍스트 스타일의 Effective 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 스타일의 effective 속성을 가져올 수 있습니다. [ITextStyleEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITextStyleEffectiveData) 인터페이스에는 effective 텍스트 스타일 속성이 포함됩니다.

다음 코드 샘플은 텍스트 스타일의 effective 속성을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 텍스트 프레임을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IAutoShape)이라고 가정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Effective 글꼴 높이 값 가져오기**

Aspose.Slides를 사용하면 effective 글꼴 높이를 가져올 수 있습니다. 다음 코드는 구획의 effective 글꼴 높이가 다양한 프레젠테이션 구조 수준에서 로컬 글꼴 높이 값을 설정한 후 어떻게 변하는지를 보여줍니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **테이블의 Effective 채우기 형식 가져오기**

Aspose.Slides를 사용하면 다양한 테이블 부분에 대한 effective 채우기 서식을 가져올 수 있습니다. [IFillFormatEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IFillFormatEffectiveData) 인터페이스에는 effective 채우기 서식 속성이 포함됩니다. 셀 서식은 행 서식보다 우선 순위가 높으며, 행 서식은 열 서식보다, 열 서식은 전체 테이블 서식보다 우선합니다.

그 결과, [ICellFormatEffectiveData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ICellFormatEffectiveData) 속성이 테이블 셀을 그리는 데 사용됩니다. 다음 코드 샘플은 다양한 테이블 부분에 대한 effective 채우기 서식을 가져오는 방법을 보여줍니다. 첫 번째 슬라이드의 첫 번째 도형이 [ITable](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ITable)이라고 가정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

### `getEffective`는 스냅샷을 반환합니까?

항상 그런 것은 아닙니다. Effective 데이터는 상속이 적용된 후 계산된 서식을 나타내지만, 일부 effective 데이터 객체는 내부에 캐시될 수 있습니다. 이후에 `getEffective`를 호출하면 서식이 재계산되어 캐시된 데이터가 새로 고쳐질 수 있으며, 이전에 얻은 객체를 영구적인 스냅샷으로 취급해서는 안 됩니다.

### 언제 다시 effective 속성을 읽어야 합니까?

`getEffective`를 로컬 서식, 부모 스타일, 레이아웃 서식, 마스터 서식 또는 프레젠테이션 수준 기본값을 변경한 후 다시 호출하십시오. 다음 호출은 서식 계층을 다시 평가하여 현재의 effective 결과를 반환합니다.

### 레이아웃/마스터 슬라이드를 변경하거나 제거하면 이미 가져온 effective 속성에 영향을 줍니까?

예, 하지만 변경 사항은 다음 `getEffective` 호출 시 반영됩니다. 부모 서식 소스가 변경되거나 삭제되면 이전에 얻은 effective 데이터가 오래될 수 있습니다. `getEffective`를 다시 호출하면 Aspose.Slides가 서식 트리를 재평가하고 결과 폰트, 색상, 크기 또는 기타 값이 변경될 수 있습니다.

### effective 데이터 객체를 통해 값을 수정할 수 있습니까?

아니요. Effective 데이터 객체는 계산된 값만 노출합니다. 로컬 서식 객체에서 변경을 수행한 후 다시 effective 값을 가져오세요.

### 도형 수준, 레이아웃/마스터, 전역 설정 중 어느 곳에도 속성이 설정되지 않으면 어떻게 됩니까?

effective 값은 PowerPoint 및 Aspose.Slides 기본값을 포함하는 기본 메커니즘에 의해 결정됩니다. 해당 결정된 값은 현재 effective 데이터의 일부가 됩니다.

### effective 폰트 값으로 어느 수준이 크기나 글꼴을 제공했는지 알 수 있습니까?

직접적으로는 알 수 없습니다. Effective 데이터는 최종 값을 반환합니다. 원본을 찾으려면 구획, 단락, 텍스트 프레임 및 레이아웃, 마스터, 프레젠테이션 수준의 텍스트 스타일에서 로컬 값을 확인하여 첫 번째 명시적 정의가 어느 곳에 있는지 확인하세요.

### 왜 effective 값이 때때로 로컬 값과 동일하게 보입니까?

로컬 값이 최종 값이 되었기 때문입니다(상위 수준의 상속이 필요하지 않음). 이러한 경우 effective 값은 로컬 값과 일치합니다.

### 언제 effective 속성을 사용하고, 언제 로컬 속성만 사용해야 합니까?

모든 상속이 적용된 후 "as rendered" 결과가 필요할 때는 effective 데이터를 사용하십시오(예: 색상, 들여쓰기, 크기 정렬). 이후 서식 변경과 관계없이 해당 값을 보존해야 하면 필요한 속성을 자체 객체에 복사하십시오. 특정 수준에서 서식을 변경해야 하면 로컬 속성을 수정하고, 필요에 따라 effective 데이터를 다시 읽어 결과를 확인하십시오.