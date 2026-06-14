---
title: Macro VBA
type: docs
weight: 150
url: /vi/java/examples/elements/vba-macro/
keywords:
- ví dụ mã
- VBA
- macro
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tự động hoá các bản trình chiếu với Aspose.Slides for Java: tạo, chạy, nhập và bảo vệ các macro VBA trong PPT, PPTX và ODP bằng các ví dụ Java rõ ràng."
---
Bài viết này trình bày cách thêm, truy cập và xoá macro VBA bằng **Aspose.Slides for Java**.

## **Thêm macro VBA**

Tạo một bản trình chiếu có dự án VBA và một mô-đun macro đơn giản.

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập macro VBA**

Lấy mô-đun đầu tiên từ dự án VBA.

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Xoá macro VBA**

Xoá một mô-đun khỏi dự án VBA.

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```