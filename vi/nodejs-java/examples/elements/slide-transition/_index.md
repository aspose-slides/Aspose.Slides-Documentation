---
title: Chuyển tiếp slide
type: docs
weight: 110
url: /vi/nodejs-java/examples/elements/slide-transition/
keywords:
- ví dụ mã
- chuyển tiếp slide
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Thành thạo các chuyển tiếp slide trong Aspose.Slides cho Node.js: thêm, tùy chỉnh và sắp xếp các hiệu ứng và thời lượng với các ví dụ cho bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách áp dụng hiệu ứng chuyển tiếp slide và thời gian với **Aspose.Slides for Node.js via Java**.

## **Thêm chuyển tiếp slide**

Áp dụng hiệu ứng chuyển tiếp mờ cho slide đầu tiên.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Áp dụng chuyển tiếp mờ.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập chuyển tiếp slide**

Đọc loại chuyển tiếp hiện đang được gán cho một slide.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Truy cập loại chuyển tiếp.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa chuyển tiếp slide**

Xóa bất kỳ hiệu ứng chuyển tiếp nào bằng cách đặt loại thành `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Xóa chuyển tiếp bằng cách đặt None.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Đặt thời lượng chuyển tiếp**

Xác định thời gian slide được hiển thị trước khi tự động chuyển sang slide tiếp theo.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // tính bằng mili giây.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```