---
title: ActiveX
type: docs
weight: 200
url: /vi/androidjava/examples/elements/activex/
keywords:
- ví dụ mã
- ActiveX
- PowerPoint
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Xem các ví dụ ActiveX của Aspose.Slides cho Android: chèn, cấu hình và điều khiển các đối tượng ActiveX trong các bản trình chiếu PPT và PPTX bằng mã Java rõ ràng."
---
Bài viết này trình bày cách thêm, truy cập, xóa và cấu hình các điều khiển ActiveX trong một bản thuyết trình bằng cách sử dụng **Aspose.Slides for Android via Java**.

## **Thêm một điều khiển ActiveX**

Chèn một điều khiển ActiveX mới và tùy chọn thiết lập các thuộc tính của nó.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Thêm một điều khiển ActiveX mới.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Tùy chọn thiết lập một số thuộc tính.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập một điều khiển ActiveX**

Đọc thông tin từ điều khiển ActiveX đầu tiên trên slide.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Truy cập điều khiển ActiveX đầu tiên.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một điều khiển ActiveX**

Xóa một điều khiển ActiveX hiện có khỏi slide.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // Xóa điều khiển ActiveX đầu tiên.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Đặt thuộc tính ActiveX**

Thêm một điều khiển và cấu hình một số thuộc tính ActiveX.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Thêm một điều khiển Windows Media Player và cấu hình các thuộc tính.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```