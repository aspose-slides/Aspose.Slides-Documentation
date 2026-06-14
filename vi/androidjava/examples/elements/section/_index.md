---
title: "Phần"
type: docs
weight: 90
url: /vi/androidjava/examples/elements/section/
keywords:
- "ví dụ mã"
- "phần"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Quản lý các phần slide trong Aspose.Slides cho Android: tạo, đổi tên, sắp xếp lại và nhóm các slide với các ví dụ Java cho PPT, PPTX và ODP."
---
Các ví dụ về quản lý các phần của bản trình chiếu—thêm, truy cập, xóa và đổi tên chúng một cách lập trình bằng **Aspose.Slides for Android via Java**.

## **Thêm một phần**

Tạo một phần bắt đầu tại một slide cụ thể.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Chỉ định slide đánh dấu sự bắt đầu của phần.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập một phần**

Đọc thông tin phần từ một bản trình chiếu.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Truy cập một phần theo chỉ mục.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một phần**

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

## **Đổi tên một phần**

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