---
title: Node.js에서 프레젠테이션 슬라이드의 도형 크기 조정
type: docs
weight: 130
url: /ko/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /ko/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- 도형 크기 조정
- 도형 크기 변경
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 Java로 사용하여 PowerPoint와 OpenDocument 슬라이드의 도형을 쉽게 크기 조정하고, 슬라이드 레이아웃 조정을 자동화하여 생산성을 높입니다."
---
## **개요**

프레젠테이션의 슬라이드 크기를 변경하면 새 치수에 맞게 도형을 크기 조정하고 위치를 재조정해야 할 수도 있습니다. 이 문서에서는 도형을 수동으로 스케일링하는 방법과 슬라이드, 마스터, 레이아웃의 테이블을 처리하는 방법을 보여줍니다.

## **도형 크기 조정**

각 도형의 상대적인 위치와 크기를 유지하려면 새 슬라이드 너비와 원래 너비의 비율만큼 가로 좌표와 너비를 곱합니다. 세로 좌표와 높이에는 해당 높이 비율을 적용합니다.

첫 번째 예제는 슬라이드에 테이블이 없는 프레젠테이션을 로드하고, 슬라이드 크기를 A4로 변경한 뒤 결과를 저장합니다. 이 예제는 이후 루프가 스케일링을 제어하도록 [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize)와 [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale)을 사용합니다. 비율은 단위가 없으며, 도형 위치와 크기는 포인트 단위로 측정됩니다. 너비와 높이 비율이 다르면 도형이 왜곡될 수 있으며, 도형의 크기를 변경해도 글꼴 크기는 스케일되지 않습니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // 독립적인 가로 및 세로 배율을 계산합니다.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
테이블은 별도로 처리해야 합니다. 전체 테이블의 너비와 높이를 할당하는 대신 열 너비와 행 높이를 스케일합니다. 셀 내용에 더 많은 공간이 필요하면 행 높이가 요청보다 크게 유지될 수 있습니다.
{{% /alert %}}

두 번째 예제는 테이블을 지원하고, 리사이즈된 프레젠테이션을 저장하기 전에 마스터 및 레이아웃의 도형과 개별 슬라이드의 도형을 처리합니다. 이 도우미는 각 [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)의 열 너비를 [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth)로, 최소 행 높이를 [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight)로 스케일링하여 처리합니다. 그런 다음 전체 차원을 별도로 스케일링하지 않고 테이블의 위치만 스케일링합니다.
```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // 테이블 크기는 열 너비와 행 높이로 제어됩니다.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // 독립적인 가로 및 세로 배율을 계산합니다.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // 마스터와 레이아웃, 개별 슬라이드에 정의된 도형을 크기 조정합니다.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**슬라이드 크기를 조정한 후 도형이 왜 왜곡되거나 잘리는가?**

슬라이드 크기를 조정하면서 도형을 스케일링하지 않으면 도형은 원래 위치와 크기를 유지하고 슬라이드 밖으로 넘어갈 수 있습니다. 너비와 높이를 다른 비율로 스케일링하면 도형이 왜곡될 수도 있습니다.

**제공된 코드는 모든 도형 유형에 적용됩니까?**

첫 번째 예제는 도형 경계를 직접 변경하며 테이블이 없는 슬라이드를 대상으로 합니다. 두 번째 예제는 테이블을 별도로 처리합니다. 이러한 예제는 글꼴 크기를 스케일링하지 않고 테이블 내용이 행 높이를 제한할 수 있으므로, 특히 텍스트와 테이블을 중심으로 결과 레이아웃을 확인하십시오.

**슬라이드 크기를 조정할 때 테이블은 어떻게 리사이즈합니까?**

두 번째 예제와 같이 너비 비율에 따라 열 너비를, 높이 비율에 따라 최소 행 높이를 스케일링한 뒤 테이블의 위치만 스케일링합니다.

**마스터 슬라이드와 레이아웃 슬라이드에도 이 리사이즈가 적용됩니까?**

예. 두 번째 예제는 [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters)와 각 마스터의 [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides)를 순회하며 도형에 동일한 리사이즈 로직을 적용합니다.

**리사이즈와 함께 슬라이드 방향(세로/가로)을 변경할 수 있나요?**

예. 슬라이드 크기를 변경한 후, 목표 치수를 읽기 전에 [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation)을 호출하면 스케일 팩터가 최종 방향을 반영합니다.

**설정할 수 있는 슬라이드 크기에 제한이 있나요?**

[SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize)을 사용하여 사용자 정의 슬라이드 크기를 지정할 수 있습니다. 지원되는 치수는 프레젠테이션 형식과 파일을 여는 응용 프로그램에 따라 달라집니다.

**고정된 종횡비를 가진 도형이 왜곡되는 것을 어떻게 방지할 수 있나요?**

너비와 높이에 동일한 스케일 팩터를 사용하십시오. 원래 레이아웃을 새 슬라이드 치수에 맞추려면 너비와 높이 비율 중 작은 값을 두 차원과 위치에 모두 적용합니다. 이렇게 하면 비율을 유지하지만 한쪽 가장자리에 사용되지 않은 공간이 남을 수 있습니다.