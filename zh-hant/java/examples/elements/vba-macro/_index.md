---
title: VBA 巨集
type: docs
weight: 150
url: /zh-hant/java/examples/elements/vba-macro/
keywords:
- 程式碼範例
- VBA
- 巨集
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 自動化簡報：建立、執行、匯入並保護 PPT、PPTX 及 ODP 中的 VBA 巨集，提供清晰的 Java 範例。"
---
本文示範如何使用 **Aspose.Slides for Java** 新增、存取與移除 VBA 巨集。

## **新增 VBA 巨集**

建立包含 VBA 專案與簡易巨集模組的簡報。

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

## **存取 VBA 巨集**

從 VBA 專案中取得第一個模組。

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

## **移除 VBA 巨集**

從 VBA 專案中刪除模組。

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