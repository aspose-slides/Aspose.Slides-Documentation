---
title: Tiêu đề và Chân trang
type: docs
weight: 220
url: /vi/java/examples/elements/header-footer/
keywords:
- ví dụ mã
- tiêu đề
- chân trang
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Kiểm soát tiêu đề và chân trang của slide bằng Aspose.Slides cho Java: thêm ngày, số slide và văn bản tùy chỉnh trong PPT, PPTX và ODP với các ví dụ Java."
---
Bài viết này trình bày cách thêm footer và cập nhật các placeholder ngày giờ bằng **Aspose.Slides for Java**.

## **Thêm Footer**
Thêm văn bản vào khu vực footer của một slide và làm cho nó hiển thị.

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

## **Cập nhật Ngày và Giờ**
Chỉnh sửa placeholder ngày và giờ trên một slide.

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