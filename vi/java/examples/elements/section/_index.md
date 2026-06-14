---
title: Section
type: docs
weight: 90
url: /vi/java/examples/elements/section/
keywords:
- ví dụ mã
- phần
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý các phần slide trong Aspose.Slides for Java: tạo, đổi tên, sắp xếp lại và nhóm các slide với các ví dụ Java cho PPT, PPTX và ODP."
---
Ví dụ về việc quản lý các phần của bản trình chiếu — thêm, truy cập, xóa và đổi tên chúng một cách lập trình bằng **Aspose.Slides for Java**.

## **Thêm một Phần**

Tạo một phần bắt đầu tại một slide cụ thể.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Xác định slide đánh dấu bắt đầu của phần.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập một Phần**

Đọc thông tin phần từ một bản trình chiếu.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Truy cập một phần theo chỉ số.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một Phần**

Xóa một phần đã được thêm trước đó.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Xóa phần đầu tiên.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Đổi tên một Phần**

Thay đổi tên của một phần hiện có.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```