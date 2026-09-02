---
title: JavaScript에서 프레젠테이션 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/nodejs-java/manage-placeholder/
keywords:
- 플레이스홀더
- 텍스트 플레이스홀더
- 이미지 플레이스홀더
- 차트 플레이스홀더
- 콘텐츠 플레이스홀더
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 Java에서 텍스트, 그림, 차트 및 콘텐츠 플레이스홀더를 검사하고 편집하는 방법과 플레이스홀더 상속 구조를 이해하는 방법을 배웁니다."
---
## **개요**

플레이스홀더는 프레젠테이션 템플릿에서 특정 종류의 콘텐츠 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 일반 용도 콘텐츠 플레이스홀더가 있습니다. 일반 도형과 달리 플레이스홀더는 레이아웃 슬라이드 또는 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속할 수 있습니다.

Aspose.Slides는 플레이스홀더 정보를 [Shape.getPlaceholder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getPlaceholder) 메서드를 통해 노출합니다. 이 메서드는 일반 도형에 대해 `null`을 반환하거나 [Placeholder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholder/) 객체를 반환합니다. 플레이스홀더가 어떤 콘텐츠를 포함하도록 설계되었는지 확인하려면 [Placeholder.getType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholder/#getType) 를 사용하십시오.

플레이스홀더 유형을 알게 된 후에도 도형 클래스는 여전히 중요합니다:

- 빈 텍스트, 그림, 차트 또는 콘텐츠 플레이스홀더는 일반적으로 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)으로 표현됩니다.
- 채워진 그림 플레이스홀더는 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)으로 표현될 수 있습니다.
- 채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/)으로 표현될 수 있습니다.
- 콘텐츠 플레이스홀더는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 플레이스홀더가 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)이라고 가정하지 말고 [Placeholder.getType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholder/#getType)과 런타임 도형 클래스를 모두 확인하십시오.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType]은 플레이스홀더의 역할을 설명하지만, 도형의 런타임 유형을 보장하지는 않습니다. 텍스트, 그림, 차트, 표 또는 미디어 전용 멤버에 접근하기 전에 항상 유형 검사를 수행하십시오.
{{% /alert %}}

## **플레이스홀더 상속 이해**

플레이스홀더는 계층 구조를 형성합니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고 경우에 따라 마스터 수준의 플레이스홀더를 정의합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드에서 사용되는 배치를 정의하며 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 플레이스홀더를 포함하고 레이아웃으로부터 상속받을 수 있습니다.

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 을 호출하면 이 계층 구조에서 한 단계 위로 이동합니다. 슬라이드 플레이스홀더는 일반적으로 자신의 레이아웃 플레이스홀더를 반환하고, 레이아웃 플레이스홀더는 마스터 플레이스홀더를 반환할 수 있습니다. 도형에 기본 플레이스홀더가 없을 경우 메서드는 `null`을 반환합니다.

다음 예제는 첫 번째 슬라이드의 플레이스홀더를 열거하고 해당 기본 플레이스홀더를 보고합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

일반 슬라이드에서 플레이스홀더를 편집하면 해당 슬라이드에 대한 로컬 재정의가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 여전히 해당 설정을 상속하는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 플레이스홀더가 없으며 동일한 좌표에 위치한다고 해서 상속을 시작하지 않습니다.

## **플레이스홀더의 텍스트 변경**

제목, 중앙제목, 부제목, 본문 및 텍스트 플레이스홀더는 일반적으로 텍스트를 지원합니다. 해당 도형의 [getTextFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/#getTextFrame) 메서드를 사용하기 전에 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/)인지 확인하십시오.

다음 예제는 첫 번째 슬라이드의 첫 번째 제목 플레이스홀더를 업데이트하고 결과를 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 패턴은 그림, 차트, 표 또는 미디어 플레이스홀더를 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 객체로 취급하는 것을 방지합니다. 또한 불안정한 도형 인덱스에 의존하지 않고 목적에 따라 플레이스홀더를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 *Click to add title* 과 같이 빈 플레이스홀더에 표시되는 디자인 시점 안내문입니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려고 시도하기보다 레이아웃 플레이스홀더에 사용자 정의 프롬프트 텍스트를 설정하십시오. 레이아웃은 [Slide.getLayoutSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#getLayoutSlide) 로 접근하고, [BaseSlide.getShapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseslide/#getShapes) 가 반환하는 컬렉션을 순회하십시오.

다음 예제는 첫 번째 슬라이드가 사용하는 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 애플리케이션에서 빈 플레이스홀더에 표시되는 것이 목적이며, 사용자가 실제 콘텐츠를 입력하거나 프로그램이 내용을 제공하면 더 이상 표시되지 않습니다. 프롬프트를 변경해도 레이아웃을 사용하는 슬라이드의 기존 텍스트가 교체되지는 않습니다.

## **그림 플레이스홀더 업데이트**

다음 두 경우를 처리해야 합니다:

- 그림 플레이스홀더가 이미 채워져 있고 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/) 로 표현되는 경우, [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#getPicture) 및 [Picture.setImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picture/#setImage) 을 사용해 이미지를 교체하십시오.
- 아직 빈 플레이스홀더인 경우, [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) 로 플레이스홀더 좌표에 그림 프레임을 추가하고 빈 플레이스홀더를 제거하십시오.

다음 예제는 두 경우를 모두 지원하고 프레젠테이션을 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

빈 플레이스홀더에 대해 생성된 교체물은 새 플레이스홀더가 아니라 로컬 그림 프레임이며, 이는 [Shape.getPlaceholder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getPlaceholder) 이 설정자를 제공하지 않기 때문입니다. 예약된 위치는 유지하지만 더 이상 플레이스홀더 전용 동작을 상속하지 않습니다. 플레이스홀더 관계를 유지해야 하는 경우 먼저 PowerPoint에서 플레이스홀더를 준비하고 채운 뒤, Aspose.Slides 로 결과 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/) 을 업데이트하십시오.

이미지 투명도, 자르기 및 기타 그림 전용 효과에 대해서는 [Manage Picture Frames](/slides/ko/nodejs-java/picture-frame/) 를 참조하십시오. 이러한 작업은 그림 프레임 또는 그림 채우기와 관련이 있으며 플레이스홀더 메타데이터와는 관계가 없습니다.

## **차트 및 콘텐츠 플레이스홀더 작업**

채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/) 로 표현될 수 있습니다. 이 예제는 플레이스홀더 유형과 런타임 클래스를 모두 사용해 차트를 찾고, 제목을 변경한 뒤 파일을 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

일반 콘텐츠 플레이스홀더는 보통 [PlaceholderType.Object](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholdertype/#Object) 를 가집니다. PowerPoint에서는 차트, 표, 다이어그램, 그림, 미디어 등 여러 콘텐츠 유형을 시작할 수 있는 런처 역할을 합니다. 콘텐츠가 채워진 후에는 실제 도형 클래스를 검사해 어떤 내용이 포함되어 있는지 확인하십시오. 특수 레이아웃은 또한 [PlaceholderType.Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholdertype/#Media) 또는 [PlaceholderType.Diagram](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholdertype/#Diagram) 을 노출할 수 있습니다.

Aspose.Slides는 [Placeholder.getType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/placeholder/#getType) 을 변경한다고 해서 빈 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 플레이스홀더를 [Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/) 로 변환하지 않습니다; 객체를 통해 유형을 변경할 수 없습니다. 빈 차트나 콘텐츠 영역을 프로그래밍 방식으로 채우려면 해당 위치에 필요한 객체를 추가하고 빈 플레이스홀더를 제거하십시오. 다음 예제는 차트에 대해 이를 수행합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

추가된 차트는 일반 로컬 차트이며, 플레이스홀더 영역을 차지하지만 레이아웃 플레이스홀더로부터 상속받지는 않습니다. 범주, 시리즈 또는 워크북 데이터를 교체해야 할 경우 전용 [chart management articles](/slides/ko/nodejs-java/powerpoint-charts/) 를 활용하십시오.

## **완전한 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 엔드‑투‑엔드 예제는 템플릿을 연 뒤 첫 번째 슬라이드에서 제목 또는 그림 플레이스홀더를 찾아 플레이스홀더와 도형 유형을 확인하고 해당 콘텐츠를 업데이트한 뒤 결과를 저장합니다. 예제는 도형 인덱스를 가정하거나 모든 플레이스홀더를 동일한 클래스로 처리하는 것을 의도적으로 피합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**베이스 플레이스홀더가 무엇인가요?**

베이스 플레이스홀더는 레이아웃 또는 마스터에 존재하는 해당 도형으로, 다른 플레이스홀더가 이를 상속받습니다. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 를 사용해 가져올 수 있습니다. 일반 로컬 도형은 플레이스홀더 계층의 일부가 아니므로 `null`을 반환합니다.

**레이아웃 플레이스홀더를 편집해서 모든 슬라이드 제목을 변경할 수 있나요?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 실제 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 제목 텍스트를 교체하려면 슬라이드를 순회하며 각 제목 플레이스홀더를 업데이트해야 합니다.

**날짜, 슬라이드 번호, 머리글 및 바닥글 플레이스홀더는 어떻게 관리하나요?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 팸플릿 범위에서 머리글 및 바닥글 관리자를 사용하십시오. 자세한 예제는 [Manage Presentation Header and Footer](/slides/ko/nodejs-java/presentation-header-and-footer/) 를 참조하십시오.