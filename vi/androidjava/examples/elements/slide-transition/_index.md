---
title: Chuyển tiếp slide
type: docs
weight: 110
url: /vi/androidjava/examples/elements/slide-transition/
keywords:
- ví dụ mã
- chuyển tiếp slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Thành thạo chuyển tiếp slide trong Aspose.Slides cho Android: thêm, tùy chỉnh và sắp xếp các hiệu ứng và thời lượng với các ví dụ Java cho bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách áp dụng hiệu ứng chuyển tiếp slide và thời gian với **Aspose.Slides for Android via Java**.

## **Thêm chuyển tiếp slide**

Áp dụng hiệu ứng chuyển tiếp fade cho slide đầu tiên.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Áp dụng chuyển tiếp mờ.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập chuyển tiếp slide**

Đọc loại chuyển tiếp hiện đang được gán cho một slide.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Truy cập loại chuyển tiếp.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa chuyển tiếp slide**

Xóa mọi hiệu ứng chuyển tiếp bằng cách đặt loại thành `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Xóa chuyển tiếp bằng cách đặt none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Đặt thời lượng chuyển tiếp**

Xác định thời gian hiển thị slide trước khi tự động chuyển sang slide tiếp theo.

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