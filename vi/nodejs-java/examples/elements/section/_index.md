---
title: Phần
type: docs
weight: 90
url: /vi/nodejs-java/examples/elements/section/
keywords:
- ví dụ mã
- phần
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các phần slide trong Aspose.Slides for Node.js qua Java: tạo, đổi tên, sắp xếp lại và nhóm các slide với các ví dụ JavaScript cho PPT, PPTX và ODP."
---
Các ví dụ về quản lý các phần trong bài thuyết trình—thêm, truy cập, xóa và đổi tên chúng một cách lập trình bằng **Aspose.Slides for Node.js via Java**.

## **Thêm một Phần**

Tạo một phần bắt đầu tại một slide cụ thể.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Chỉ định slide đánh dấu đầu của phần.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập một Phần**

Đọc thông tin phần từ một bài thuyết trình.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Truy cập một phần theo chỉ mục.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một Phần**

Xóa một phần đã được thêm trước đó.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Xóa phần đầu tiên.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Đổi tên một Phần**

Thay đổi tên của một phần hiện có.

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