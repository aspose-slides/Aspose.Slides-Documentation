---
title: Chuyển đổi Slide
type: docs
weight: 110
url: /vi/java/examples/elements/slide-transition/
keywords:
- ví dụ mã
- chuyển đổi slide
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Thành thạo các chuyển đổi slide trong Aspose.Slides cho Java: thêm, tùy chỉnh và sắp xếp các hiệu ứng và thời lượng với các ví dụ Java cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách áp dụng hiệu ứng chuyển slide và thời gian với **Aspose.Slides for Java**.

## **Add a Slide Transition**
Áp dụng hiệu ứng chuyển mờ cho slide đầu tiên.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Áp dụng hiệu ứng chuyển mờ.
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Slide Transition**
Đọc loại chuyển đổi hiện đang được gán cho một slide.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Truy cập loại chuyển đổi.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Slide Transition**
Xóa mọi hiệu ứng chuyển đổi bằng cách đặt loại thành `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Xóa chuyển đổi bằng cách đặt none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Transition Duration**
Xác định thời gian slide hiển thị trước khi tự động chuyển tiếp.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // tính bằng mili giây.
    } finally {
        presentation.dispose();
    }
}
```