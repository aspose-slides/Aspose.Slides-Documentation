---
title: 마스터 슬라이드
type: docs
weight: 30
url: /ko/nodejs-java/examples/elements/master-slide/
keywords:
- 코드 예제
- 마스터 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js 마스터 슬라이드 예제를 살펴보고, PPT, PPTX 및 ODP에서 마스터, 플레이스홀더 및 테마를 만들고, 편집하고, 스타일링하는 방법을 명확한 코드와 함께 확인하세요."
---
Master slides form the top level of the slide inheritance hierarchy in PowerPoint. A **master slide** defines common design elements such as backgrounds, logos, and text formatting. **Layout slides** inherit from master slides, and **normal slides** inherit from layout slides.

마스터 슬라이드는 PowerPoint에서 슬라이드 상속 계층 구조의 최상위 레벨을 형성합니다. **마스터 슬라이드**는 배경, 로고 및 텍스트 서식과 같은 공통 디자인 요소를 정의합니다. **레이아웃 슬라이드**는 마스터 슬라이드에서 상속되고, **일반 슬라이드**는 레이아웃 슬라이드에서 상속됩니다.

This article demonstrates how to create, modify, and manage master slides using Aspose.Slides for Node.js via Java.

이 문서에서는 Aspose.Slides for Node.js via Java를 사용하여 마스터 슬라이드를 만들고, 수정하고, 관리하는 방법을 보여줍니다.

## **마스터 슬라이드 추가**

This example shows how to create a new master slide by cloning the default one. It then adds a company name banner to all slides through layout inheritance.

이 예제에서는 기본 마스터 슬라이드를 복제하여 새 마스터 슬라이드를 만드는 방법을 보여줍니다. 그런 다음 레이아웃 상속을 통해 모든 슬라이드에 회사 이름 배너를 추가합니다.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // 기본 마스터 슬라이드를 복제합니다.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // 마스터 슬라이드 상단에 회사 이름 배너를 추가합니다.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // 새 마스터 슬라이드를 레이아웃 슬라이드에 할당합니다.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // 레이아웃 슬라이드를 프레젠테이션의 첫 번째 슬라이드에 할당합니다.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Master slides provide a way to apply consistent branding or shared design elements across all slides. Any changes made to the master will automatically reflect on dependent layout and normal slides.

> 💡 **Note 1:** 마스터 슬라이드는 모든 슬라이드에 일관된 브랜딩 또는 공유 디자인 요소를 적용하는 방법을 제공합니다. 마스터에 대한 변경 사항은 종속 레이아웃 및 일반 슬라이드에 자동으로 반영됩니다.

> 💡 **Note 2:** Any shapes or formatting added to a master slide are inherited by layout slides and, in turn, all normal slides using those layouts.
> The image below illustrates how a text box added on a master slide is automatically rendered on the final slide.

> 💡 **Note 2:** 마스터 슬라이드에 추가된 모든 도형이나 서식은 레이아웃 슬라이드에 상속되고, 그 레이아웃을 사용하는 모든 일반 슬라이드에도 상속됩니다. 아래 이미지에서는 마스터 슬라이드에 추가된 텍스트 상자가 최종 슬라이드에 자동으로 렌더링되는 방식을 보여줍니다.

![마스터 상속 예시](master-slide-banner.png)

## **마스터 슬라이드 액세스**

You can access master slides using the presentation master collection. Here’s how to retrieve and work with them:

프레젠테이션 마스터 컬렉션을 사용하여 마스터 슬라이드에 접근할 수 있습니다. 다음은 마스터 슬라이드를 가져오고 작업하는 방법입니다:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // 배경 유형을 변경합니다.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **마스터 슬라이드 제거**

Master slides can be removed either by index or by reference.

마스터 슬라이드는 인덱스 또는 참조를 사용하여 제거할 수 있습니다.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // 인덱스로 마스터 슬라이드를 제거합니다.
        presentation.getMasters().removeAt(0);

        // 참조로 마스터 슬라이드를 제거합니다.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **사용되지 않는 마스터 슬라이드 제거**

Some presentations contain master slides that are not in use. Removing these slides can help reduce file size.

일부 프레젠테이션에는 사용되지 않는 마스터 슬라이드가 포함되어 있습니다. 이러한 슬라이드를 제거하면 파일 크기를 줄이는 데 도움이 됩니다.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // 사용되지 않는 모든 마스터 슬라이드를 제거합니다 (보존으로 표시된 슬라이드도 포함).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```