---
title: Android에서 프레젠테이션 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/androidjava/manage-placeholder/
keywords:
- 플레이스홀더
- 텍스트 플레이스홀더
- 이미지 플레이스홀더
- 차트 플레이스홀더
- 콘텐츠 플레이스홀더
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 Java로 사용하여 텍스트, 그림, 차트 및 콘텐츠 플레이스홀더를 검사하고 편집하는 방법과 플레이스홀더 상속을 이해하는 방법을 배웁니다."
---
## **개요**

플레이스홀더는 프레젠테이션 템플릿에서 특정 종류의 콘텐츠를 위한 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 일반 용도 콘텐츠 플레이스홀더가 있습니다. 일반 도형과 달리 플레이스홀더는 레이아웃 슬라이드 또는 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 [IShape.getPlaceholder](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/) 메서드를 통해 플레이스홀더 정보를 노출합니다. 이 메서드는 일반 도형에 대해서는 `null`을 반환하고, [IPlaceholder](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholder/) 개체를 반환합니다. 플레이스홀더가 어떤 콘텐츠를 담도록 의도되었는지 확인하려면 [IPlaceholder.getType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholder/)를 사용하십시오.

플레이스홀더 유형을 알게 된 후에도 도형 인터페이스는 여전히 중요합니다:

- 빈 텍스트, 그림, 차트 또는 콘텐츠 플레이스홀더는 일반적으로 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 로 표현됩니다.
- 내용이 채워진 그림 플레이스홀더는 [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/) 로 표현될 수 있습니다.
- 내용이 채워진 차트 플레이스홀더는 [IChart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichart/) 로 표현될 수 있습니다.
- 콘텐츠 플레이스홀더는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 플레이스홀더가 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 라고 가정하지 말고 [IPlaceholder.getType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholder/)과 런타임 도형 인터페이스를 모두 확인하십시오.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholder/) 은 플레이스홀더의 역할을 설명하지만 도형의 런타임 유형을 보장하지 않습니다. 텍스트, 그림, 차트, 표 또는 미디어와 관련된 멤버에 접근하기 전에 항상 유형 검사를 수행하십시오.
{{% /alert %}}

## **플레이스홀더 상속 이해**

플레이스홀더는 계층 구조를 형성합니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고 경우에 따라 마스터 수준의 플레이스홀더를 포함합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드가 사용하는 배치를 정의하며 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 플레이스홀더를 포함하고 레이아웃으로부터 상속받을 수 있습니다.

[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/) 를 호출하여 이 계층 구조에서 한 단계 위로 이동합니다. 일반 슬라이드의 플레이스홀더는 보통 레이아웃 플레이스홀더를 반환하고, 레이아웃 플레이스홀더는 마스터 플레이스홀더를 반환할 수 있습니다. 도형에 기본 플레이스홀더가 없으면 이 메서드는 `null`을 반환합니다.

다음 예제는 첫 번째 슬라이드의 플레이스홀더를 나열하고 해당 기본 플레이스홀더를 보고합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

일반 슬라이드에서 플레이스홀더를 편집하면 해당 슬라이드에 대한 로컬 오버라이드가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 해당 설정을 상속받는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 플레이스홀더가 없으며, 동일한 좌표에 위치한다고 해서 상속을 시작하지도 않습니다.

## **플레이스홀더의 텍스트 변경**

제목, 중앙‑제목, 부제목, 본문 및 텍스트 플레이스홀더는 일반적으로 텍스트를 지원합니다. 해당 도형이 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 인지 확인한 뒤 [getTextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 메서드를 사용하십시오.

다음 예제는 첫 번째 슬라이드의 첫 번째 제목 플레이스홀더를 업데이트하고 결과를 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 패턴은 그림, 차트, 표 또는 미디어 플레이스홀더를 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 로 캐스팅하는 것을 방지합니다. 또한 형태 인덱스에 의존하지 않고 목적에 따라 플레이스홀더를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 빈 플레이스홀더에 표시되는 디자인‑타임 안내 문구이며, 예를 들어 *Click to add title* 와 같습니다. 프롬프트 텍스트는 일반 슬라이드의 도형 컬렉션을 통해 접근하려 하지 말고 레이아웃 플레이스홀더에 직접 설정하십시오. [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/) 로 레이아웃에 접근하고, [ILayoutSlide.getShapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibaseslide/) 로 반환되는 컬렉션을 순회하십시오.

다음 예제는 첫 번째 슬라이드가 사용하는 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 응용 프로그램에서 빈 플레이스홀더에만 표시됩니다. 사용자가 실제 콘텐츠를 제공하면 프롬프트는 더 이상 보이지 않으며, 레이아웃을 사용하는 슬라이드에 기존 텍스트를 대체하지도 않습니다.

## **그림 플레이스홀더 업데이트**

다음 두 경우를 처리해야 합니다:

- 그림 플레이스홀더가 이미 채워져 있고 [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/) 로 표현되는 경우, [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipicturefillformat/) 와 [ISlidesPicture.setImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidespicture/) 를 사용해 이미지를 교체하십시오.
- 아직 빈 플레이스홀더라면, [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/) 로 플레이스홀더 좌표에 그림 프레임을 추가하고 빈 플레이스홀더를 제거하십시오.

다음 예제는 두 경우를 모두 지원하고 프레젠테이션을 저장합니다:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

빈 플레이스홀더에 대해 생성된 교체물은 새로운 플레이스홀더가 아닌 로컬 그림 프레임이며, [IShape.getPlaceholder](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/) 가 설정자를 제공하지 않기 때문입니다. 예약된 위치는 유지되지만 플레이스홀더‑특정 동작은 더 이상 상속되지 않습니다. 플레이스홀더 관계를 유지해야 한다면 먼저 PowerPoint에서 플레이스홀더를 준비·채워 넣은 후 Aspose.Slides 로 결과 [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/) 를 업데이트하십시오.

이미지 투명도, 크롭 및 기타 그림‑특정 효과에 대해서는 [Manage Picture Frames](/slides/ko/androidjava/picture-frame/) 를 참조하십시오. 이러한 작업은 그림 프레임 또는 그림 채우기에 적용되며, 플레이스홀더 메타데이터와는 별개입니다.

## **차트 및 콘텐츠 플레이스홀더 작업**

채워진 차트 플레이스홀더는 [IChart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichart/) 로 표현될 수 있습니다. 다음 예제는 플레이스홀더 유형과 런타임 인터페이스를 모두 확인하여 차트를 찾고, 제목을 변경한 뒤 파일을 저장합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

일반 콘텐츠 플레이스홀더는 보통 [PlaceholderType.Object](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholdertype/) 를 가집니다. PowerPoint에서는 차트, 표, 다이어그램, 그림 및 미디어 등 여러 콘텐츠 유형의 시작점으로 작동합니다. 채워진 후에는 실제 도형 인터페이스를 검사하여 포함된 내용을 파악하십시오. 특수 레이아웃은 [PlaceholderType.Chart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Diagram](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholdertype/) 등을 노출할 수 있습니다.

Aspose.Slides는 [IPlaceholder.getType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/placeholder/) 을 변경한다고 해서 빈 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 플레이스홀더가 자동으로 [IChart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichart/) 로 변환되지 않으며, 인터페이스를 통해 유형을 변경할 수 없습니다. 빈 차트나 콘텐츠 영역을 프로그래밍 방식으로 채우려면 해당 플레이스홀더 좌표에 필요한 객체를 추가한 뒤 빈 플레이스홀더를 제거하십시오. 다음 예제는 차트에 대해 이를 수행합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

추가된 차트는 일반 로컬 차트이며, 플레이스홀더 영역을 차지하지만 레이아웃 플레이스홀더를 상속하지 않습니다. 카테고리, 시리즈 또는 워크북 데이터를 교체해야 할 경우 전용 [chart management articles](/slides/ko/androidjava/powerpoint-charts/) 를 참고하십시오.

## **전체 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 엔드‑투‑엔드 예제는 템플릿을 열고, 첫 번째 슬라이드에서 제목 또는 그림 플레이스홀더를 검색한 뒤, 플레이스홀더와 도형 유형을 확인하고 적절한 콘텐츠를 업데이트한 뒤 결과를 저장합니다. 이 예제는 도형 인덱스를 가정하거나 모든 플레이스홀더를 동일 인터페이스로 캐스팅하는 것을 의도적으로 피합니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**기본 플레이스홀더란 무엇인가요?**

기본 플레이스홀더는 다른 플레이스홀더가 상속받는 레이아웃 또는 마스터상의 해당 도형을 말합니다. 이를 가져오려면 [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/) 를 사용하십시오. 일반 로컬 도형은 플레이스홀더 계층에 포함되지 않으므로 `null`을 반환합니다.

**레이아웃 플레이스홀더를 편집하여 모든 슬라이드 제목을 변경할 수 있나요?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 실제 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 제목 텍스트를 교체하려면 슬라이드를 순회하면서 각 제목 플레이스홀더를 업데이트해야 합니다.

**날짜, 슬라이드 번호, 머리글, 바닥글 플레이스홀더는 어떻게 관리하나요?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 유인물 범위에서 머리글 및 바닥글 관리자를 사용하십시오. 전체 예제는 [Manage Presentation Header and Footer](/slides/ko/androidjava/presentation-header-and-footer/) 를 참조하십시오.