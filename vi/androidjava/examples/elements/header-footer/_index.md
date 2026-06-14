---
title: Đầu trang và Chân trang
type: docs
weight: 220
url: /vi/androidjava/examples/elements/header-footer/
keywords:
- ví dụ mã
- đầu trang
- chân trang
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Kiểm soát đầu trang và chân trang của slide bằng Aspose.Slides cho Android: thêm ngày, số slide và văn bản tùy chỉnh trong PPT, PPTX và ODP với các ví dụ Java."
---
Bài viết này trình bày cách thêm chân trang và cập nhật các placeholder ngày và giờ bằng **Aspose.Slides for Android via Java**.

## **Thêm Chân Trang**

Thêm văn bản vào vùng chân trang của một slide và hiển thị nó.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **Cập Nhật Ngày và Giờ**

Sửa đổi placeholder ngày và giờ trên một slide.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```