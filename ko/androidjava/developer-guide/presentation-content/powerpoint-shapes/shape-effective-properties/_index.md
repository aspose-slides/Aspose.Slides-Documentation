---
title: Android에서 프레젠테이션의 도형 유효 속성 가져오기
linktitle: 유효 속성
type: docs
weight: 50
url: /ko/androidjava/shape-effective-properties/
keywords:
- 도형 속성
- 카메라 속성
- 조명 장치
- 베벨 도형
- 텍스트 프레임
- 텍스트 스타일
- 글꼴 높이
- 채우기 형식
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션에서 도형 서식의 로컬, 상속 및 유효 값을 구분하는 방법을 배웁니다."
---
## **로컬, 상속 및 유효 속성 이해**

PowerPoint 서식은 여러 위치에서 올 수 있습니다. 객체에 직접 저장된 값은 **로컬 값**입니다. 해당 값이 설정되지 않은 경우 PowerPoint는 단락 기본값, 텍스트 스타일, 레이아웃 또는 마스터 슬라이드, 테마, 프레젠테이션 수준 기본값과 같은 상위 서식 소스를 확인합니다. 이러한 값은 **상속 값**이라고 합니다. 전체 계층 구조가 해결된 후 남는 값이 **유효 값**이며, 객체를 렌더링하는 데 사용되는 값입니다.

예를 들어, 텍스트 구간이 자체 글꼴 높이를 정의하지 않을 수 있습니다. 해당 구간의 로컬 [getFontHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) 값은 `Float.NaN`으로, 이는 “여기서 설정되지 않음”을 의미합니다. 구간은 단락, 프레젠테이션의 기본 텍스트 스타일 또는 다른 적용 가능한 소스로부터 높이를 상속받을 수 있습니다. 구간 형식에서 [getEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportionformat/#getEffective--) 을 호출하면 최종 해결된 높이가 반환됩니다.

두 종류의 서식 데이터를 다른 목적에 사용하십시오:

- 값이 정의된 위치를 제어해야 할 때는 [IPortionFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportionformat/) 와 같은 로컬 형식 객체를 읽거나 변경합니다.
- 최종 렌더링 결과가 필요할 때는 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportionformateffectivedata/) 와 같은 유효 데이터 객체를 읽습니다. 유효 데이터는 읽기 전용입니다.

## **로컬, 상속 및 유효 값 비교**

다음 전체 예제는 도형을 생성하고 프레젠테이션, 단락 및 구간 수준에서 글꼴 높이를 적용합니다. 각 단계에서는 해당 수준에서 정의된 값과 동일한 텍스트 구간에 대한 결과 유효 값을 출력합니다. 또한 형식 변경 후 유효 데이터를 다시 읽어야 하는 이유를 보여줍니다.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // 두 개의 다른 수준에서 상속된 값을 정의합니다.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // 구간에 대한 로컬 값이 두 상속 값을 모두 덮어씁니다.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // 상속된 값을 변경해도 기존 로컬 값을 덮어쓰지 않습니다.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // 로컬 값을 지웁니다. 이제 구간은 다시 단락에서 상속합니다.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // 단락 값을 지웁니다. 이제 프레젠테이션 기본값이 결과를 제공합니다.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // 앞선 변경 후 유효 데이터를 읽습니다.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

이 예제에서 우선 순위는 구간 로컬 서식 → 단락 서식 → 프레젠테이션 기본값입니다. 다른 객체는 서로 다른 상속 체인을 가질 수 있지만 원리는 동일합니다: 보다 구체적인 명시적 값이 승리하며, [getEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportionformat/#getEffective--) 은 최종 결과를 반환합니다.

## **유효 텍스트 속성 가져오기**

텍스트 서식은 여러 객체에 걸쳐 분산됩니다:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#getEffective--) 은 여백, 고정, 자동 맞춤, 세로 텍스트 방향과 같은 텍스트 프레임 속성을 해결합니다.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextstyle/#getEffective--) 은 각 텍스트 스타일 레벨에 대한 단락 서식을 해결합니다.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) 은 정렬, 들여쓰기, 글머리표와 같은 단락 속성을 해결합니다.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iportionformat/#getEffective--) 은 글꼴 높이, 서체, 색상, 굵게, 기울임과 같은 문자 속성을 해결합니다.

다음 예제에서는 `text-formatting.pptx` 에 최소 하나의 슬라이드와 비어 있지 않은 텍스트 프레임을 가진 [AutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/autoshape/) 이 포함되어 있어야 합니다. AutoShape 은 도형 컬렉션의 어느 위치에 있어도 되며, 코드는 적합한 객체를 찾아 사용 전에 검증합니다.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **유효 3D 속성 가져오기**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getEffective--) 은 모든 해결된 3D 설정을 묶는 하나의 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformateffectivedata/) 객체를 반환합니다. 해당 객체의 [getCamera](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), [getBevelBottom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) 메서드는 각각 해당 유효 데이터를 노출합니다. 이러한 관련 설정을 함께 읽으면 도형의 최종 3D 모습을 이해하기가 더 쉬워집니다.

이 예제에서는 `shape-3d.pptx` 에 첫 번째 슬라이드에 최소 하나의 도형이 포함되어 있어야 합니다. 기본값 이외의 값을 출력하려면 해당 도형에 3D 카메라, 조명 또는 베벨 설정을 적용하십시오.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **유효 표 서식 가져오기**

표 서식은 표 스타일과 전체 표, 열, 행 또는 개별 셀에 적용된 서식에서 올 수 있습니다. 명시적으로 정의된 채우기 간 충돌이 발생하면 우선 순위는 셀 → 행 → 열 → 전체 표입니다. 셀의 유효 서식은 해당 셀을 그릴 때 사용되는 최종 서식입니다.

이 예제에서는 `table-formatting.pptx` 에 첫 번째 슬라이드에 최소 하나의 표가 포함되어 있어야 합니다. 표에는 최소 하나의 행과 하나의 열이 있어야 합니다. 코드는 `getShapes().get_Item(0)` 이 표라고 가정하는 대신 [ITable](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itable/) 을 검색합니다.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

색상 자체가 필요하고 채우기 유형만이 아니라면 먼저 유효 [getFillType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--) 를 확인한 다음 해당 유형에 적용되는 메서드를 읽으십시오—예를 들어, 고정 색 채우기의 경우 [getSolidFillColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) 를 사용합니다.

## **변경 후 유효 데이터 다시 읽기**

유효 데이터는 해결 당시의 서식 계층 구조를 설명합니다. 계층에 참여할 수 있는 항목을 변경한 후에는 `getEffective` 를 다시 호출하십시오. 포함 항목:

- 객체의 로컬 서식
- 단락 또는 텍스트 프레임 기본값
- 표 스타일, 표, 열, 행 또는 셀 서식
- 레이아웃 또는 마스터 슬라이드 서식
- 테마 데이터 또는 프레젠테이션 수준 기본값
- 슬라이드에 할당된 레이아웃 또는 마스터

유효 데이터 객체를 영구 스냅샷으로 보관하지 마십시오. Aspose.Slides 가 내부적으로 일부 유효 데이터를 캐시할 수 있으며, 이후 `getEffective` 호출은 해당 데이터를 새로 고칩니다. 변경 전후 값을 비교해야 한다면, 글꼴 높이, 색상, 정렬, 베벨 너비와 같은 스칼라 값을 변경 전 자체 변수에 복사하십시오.

값을 변경하려면 해당 로컬 형식 객체를 업데이트한 뒤 `getEffective` 를 호출해 결과를 확인합니다. 유효 데이터 객체 자체는 읽기 전용입니다.

## **FAQ**

**어떻게 하면 어느 수준이 유효 값을 제공했는지 알 수 있나요?**

유효 데이터에는 최종 값만 포함되고 그 출처는 포함되지 않습니다. 가장 구체적인 수준부터 외부로 확장하면서 해당 로컬 객체들을 검사하십시오. 텍스트의 경우 구간, 단락, 텍스트 프레임, 레이아웃, 마스터, 테마 및 프레젠테이션 기본값을 포함할 수 있습니다. `Float.NaN` 이나 `null` 과 같은 정의되지 않은 값은 검색이 다른 수준으로 계속 진행되고 있음을 나타냅니다.

**어떤 수준에서도 속성을 정의하지 않으면 어떻게 되나요?**

Aspose.Slides 는 적절한 PowerPoint 또는 라이브러리 기본값을 해결합니다. 해당 해결된 값은 로컬 객체가 명시적으로 정의하지 않았더라도 유효 데이터에 표시됩니다.

**왜 유효 값이 때때로 로컬 값과 동일합니까?**

로컬 값이 상속 계산에서 우승했기 때문입니다. 이는 해당 속성이 객체에 명시적으로 설정되어 있고 더 구체적인 규칙이 이를 재정의하지 않을 때 기대되는 동작입니다.

**언제 로컬 데이터를 사용하고 유효 데이터를 사용하지 않아야 하나요?**

특정 서식 수준을 검사하거나 편집하려면 로컬 데이터를 사용하십시오. 상속, 테마 규칙 및 적용 가능한 스타일이 모두 해결된 후 최종 모습을 필요로 할 때는 유효 데이터를 사용하십시오. [전체 비교 예제](#compare-local-inherited-and-effective-values) 가 동일한 워크플로에서 두 가지를 모두 보여줍니다.