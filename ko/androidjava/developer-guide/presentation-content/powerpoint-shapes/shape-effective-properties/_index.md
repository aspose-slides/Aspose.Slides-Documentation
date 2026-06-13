---
title: Android에서 프레젠테이션의 쉐이프 유효 속성 가져오기
linktitle: 유효 속성
type: docs
weight: 50
url: /ko/androidjava/shape-effective-properties/
keywords:
- 쉐이프 속성
- 카메라 속성
- 라이트 릭
- 베벨 쉐이프
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 서식
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 Java를 통해 사용하여 정확한 PowerPoint 렌더링을 위해 쉐이프 유효 속성을 계산하고 적용하는 방법을 알아보세요."
---
## **개요**

이 항목에서는 **로컬** 속성과 **유효** 속성의 차이를 설명합니다. 로컬 값은 특정 서식 수준에서 직접 설정된 값이며, 예를 들어:

1. 슬라이드의 구간 속성.
1. 레이아웃 또는 마스터 슬라이드에 있는 프로토타입 쉐이프 텍스트 스타일(구간의 텍스트 프레임 쉐이프에 해당하는 경우).
1. 프레젠테이션의 전역 텍스트 설정.

로컬 값은 어느 수준에서든 정의하거나 생략할 수 있습니다. Aspose.Slides가 최종 “렌더링된” 서식을 필요로 할 때는 상속 체인을 해결하여 **유효** 값을 반환합니다. 로컬 서식 개체에서 `getEffective()` 메서드를 호출하면 이를 얻을 수 있습니다.

다음 예제는 유효 값을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 쉐이프가 텍스트 프레임과 최소 하나의 구간을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/)이라고 가정합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
유효 서식 데이터는 상속이 적용된 후 현재 계산된 서식을 나타냅니다. 현재 구현에서는 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportionformateffectivedata/)와 같은 일부 유효 데이터 객체가 내부적으로 캐시될 수 있습니다. 부모 또는 상속된 서식을 변경한 후 `getEffective()`를 다시 호출하면 캐시된 데이터가 새로 고쳐지며, 이전에 얻은 객체는 더 이상 이전 상태를 나타내지 않을 수 있습니다. 나중에 재사용하기 위해 유효 값을 보존해야 한다면 글꼴 높이, 채우기 색, 글꼴 스타일 또는 정렬과 같은 필요한 속성을 자체 데이터 객체에 복사하십시오.
{{% /alert %}}

## **카메라의 유효 속성 가져오기**

Aspose.Slides를 사용하면 카메라의 유효 속성을 가져올 수 있습니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icameraeffectivedata/) 인터페이스는 유효 카메라 속성을 포함하는 불변 객체를 나타냅니다. [ICameraEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icameraeffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/)의 유효 값을 제공합니다.

다음 코드 샘플은 카메라의 유효 속성을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 쉐이프에 3D 서식이 적용되어 있다고 가정합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **라이트 릭의 유효 속성 가져오기**

Aspose.Slides를 사용하면 라이트 릭의 유효 속성을 가져올 수 있습니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilightrigeffectivedata/) 인터페이스는 유효 라이트 릭 속성을 포함하는 불변 객체를 나타냅니다. [ILightRigEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilightrigeffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/)의 유효 값을 제공합니다.

다음 코드 샘플은 라이트 릭의 유효 속성을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 쉐이프에 3D 서식이 적용되어 있다고 가정합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **쉐이프 베벨의 유효 속성 가져오기**

Aspose.Slides를 사용하면 쉐이프 베벨의 유효 속성을 가져올 수 있습니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapebeveleffectivedata/) 인터페이스는 쉐이프에 대한 유효 면돌출(face‑relief) 속성을 포함하는 불변 객체를 나타냅니다. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapebeveleffectivedata/) 인스턴스는 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformateffectivedata/)를 통해 노출되며, 이는 [IThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/)의 유효 값을 제공합니다.

다음 코드 샘플은 쉐이프 상단 베벨의 유효 속성을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 쉐이프에 3D 서식이 적용되어 있다고 가정합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **텍스트 프레임의 유효 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 프레임의 유효 속성을 가져올 수 있습니다. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformateffectivedata/) 인터페이스는 유효 텍스트 프레임 서식 속성을 포함합니다.

다음 코드 샘플은 텍스트 프레임의 유효 서식 속성을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 쉐이프가 텍스트 프레임을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/)이라고 가정합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **텍스트 스타일의 유효 속성 가져오기**

Aspose.Slides를 사용하면 텍스트 스타일의 유효 속성을 가져올 수 있습니다. [ITextStyleEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextstyleeffectivedata/) 인터페이스는 유효 텍스트 스타일 속성을 포함합니다.

다음 코드 샘플은 텍스트 스타일의 유효 속성을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 쉐이프가 텍스트 프레임을 가진 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/)이라고 가정합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **유효 글꼴 높이 값 가져오기**

Aspose.Slides를 사용하면 유효 글꼴 높이를 가져올 수 있습니다. 다음 코드는 구간의 유효 글꼴 높이가 프레젠테이션 구조의 서로 다른 수준에서 로컬 글꼴 높이 값을 설정한 후 어떻게 변하는지를 보여 줍니다.

```java
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

## **테이블의 유효 채우기 서식 가져오기**

Aspose.Slides를 사용하면 테이블의 다양한 부분에 대한 유효 채우기 서식을 가져올 수 있습니다. [IFillFormatEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifillformateffectivedata/) 인터페이스는 유효 채우기 서식 속성을 포함합니다. 셀 서식은 행 서식보다 우선순위가 높고, 행 서식은 열 서식보다, 열 서식은 전체 테이블 서식보다 우선순위가 높습니다.

그 결과, [ICellFormatEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icellformateffectivedata/) 속성이 테이블 셀을 그리는 데 사용됩니다. 다음 코드 샘플은 테이블의 다양한 부분에 대한 유효 채우기 서식을 가져오는 방법을 보여 줍니다. 첫 번째 슬라이드의 첫 번째 쉐이프가 [ITable](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itable/)이라고 가정합니다.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective()`는 스냅샷을 반환합니까?**

항상 그렇지는 않습니다. 유효 데이터는 상속이 적용된 후 계산된 서식을 나타내지만, 일부 유효 데이터 객체는 내부적으로 캐시될 수 있습니다. 이후 `getEffective()` 호출은 서식을 다시 계산하고 캐시된 데이터를 새로 고칠 수 있으므로, 이전에 얻은 객체를 영구적인 스냅샷으로 취급하면 안 됩니다.

**언제 유효 속성을 다시 읽어야 하나요?**

로컬 서식, 상위 스타일, 레이아웃 서식, 마스터 서식 또는 프레젠테이션 수준 기본값을 변경한 후 `getEffective()`를 다시 호출하십시오. 다음 호출은 서식 계층을 다시 평가하고 현재 유효 결과를 반환합니다.

**레이아웃/마스터 슬라이드를 변경하거나 제거하면 이미 가져온 유효 속성에 영향이 있나요?**

예, 하지만 변경 내용은 다음 `getEffective()` 호출 시 반영됩니다. 상위 서식 원본이 변경되거나 제거되면 이전에 얻은 유효 데이터는 오래될 수 있습니다. `getEffective()`를 다시 호출하면 Aspose.Slides가 서식 트리를 재평가하고 결과 글꼴, 색상, 크기 등 값이 변경될 수 있습니다.

**유효 데이터 객체를 통해 값을 수정할 수 있나요?**

아니요. 유효 데이터 객체는 계산된 값을 노출할 뿐입니다. 로컬 서식 객체에서 변경을 수행한 후 다시 유효 값을 얻으십시오.

**쉐이프 수준에도, 레이아웃/마스터에도, 전역 설정에도 속성이 설정되지 않은 경우 어떻게 됩니까?**

유효 값은 기본 메커니즘에 의해 결정되며, 여기에는 PowerPoint 및 Aspose.Slides 기본값이 포함됩니다. 해결된 값이 현재 유효 데이터의 일부가 됩니다.

**유효 글꼴 값으로 어느 수준에서 크기나 글꼴이 제공되었는지 알 수 있나요?**

직접적으로는 알 수 없습니다. 유효 데이터는 최종 값을 반환합니다. 원본을 찾으려면 구간, 단락, 텍스트 프레임 및 레이아웃, 마스터, 프레젠테이션 수준의 텍스트 스타일에서 로컬 값을 확인하여 최초로 명시적으로 정의된 위치를 찾아야 합니다.

**왜 유효 값이 로컬 값과 때때로 동일하게 보이나요?**

로컬 값이 최종 값이 되었기 때문입니다(더 높은 수준의 상속이 필요하지 않았음). 이런 경우 유효 값은 로컬 값과 일치합니다.

**언제 유효 속성을 사용하고, 언제 로컬 속성만 사용해야 하나요?**

모든 상속이 적용된 후 “렌더링된” 결과가 필요할 때는 유효 데이터를 사용하십시오(예: 색상, 들여쓰기, 크기 정렬). 이후 서식 변경과 무관하게 해당 값을 보존하려면 필요한 속성을 자체 객체에 복사하십시오. 특정 수준에서 서식을 변경하려면 로컬 속성을 수정하고, 필요에 따라 유효 데이터를 다시 읽어 결과를 확인하십시오.