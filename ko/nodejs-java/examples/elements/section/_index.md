---
title: 섹션
type: docs
weight: 90
url: /ko/nodejs-java/examples/elements/section/
keywords:
- 코드 예제
- 섹션
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java에서 슬라이드 섹션을 관리합니다: PPT, PPTX 및 ODP용 JavaScript 예제를 통해 슬라이드를 생성, 이름 변경, 순서 재배치 및 그룹화합니다."
---
프레젠테이션 섹션을 관리하는 예제—섹션을 추가, 접근, 제거 및 이름 변경을 **Aspose.Slides for Node.js via Java**를 사용해 프로그래밍 방식으로 수행합니다.

## **Add a Section**
특정 슬라이드에서 시작하는 섹션을 생성합니다.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 섹션의 시작을 나타내는 슬라이드를 지정합니다.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Section**
프레젠테이션에서 섹션 정보를 읽어옵니다.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 인덱스로 섹션에 접근합니다.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Section**
이전에 추가한 섹션을 삭제합니다.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 섹션을 제거합니다.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Rename a Section**
기존 섹션의 이름을 변경합니다.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```