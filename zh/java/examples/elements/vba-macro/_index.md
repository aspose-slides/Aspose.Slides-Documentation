---
title: VBA 宏
type: docs
weight: 150
url: /zh/java/examples/elements/vba-macro/
keywords:
- 代码示例
- VBA
- 宏
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 自动化演示文稿：创建、运行、导入和保护 PPT、PPTX、ODP 中的 VBA 宏，提供清晰的 Java 示例。"
---
本文演示如何使用 **Aspose.Slides for Java** 添加、访问和删除 VBA 宏。

## **添加 VBA 宏**

创建一个包含 VBA 项目和简单宏模块的演示文稿。

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

## **访问 VBA 宏**

从 VBA 项目中检索第一个模块。

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

## **删除 VBA 宏**

从 VBA 项目中删除一个模块。

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