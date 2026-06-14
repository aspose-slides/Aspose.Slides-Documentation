---
title: VBA 巨集
type: docs
weight: 150
url: /zh-hant/androidjava/examples/elements/vba-macro/
keywords:
- 程式碼範例
- VBA
- 巨集
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 自動化簡報：透過清晰的 Java 範例建立、執行、匯入並保護 PPT、PPTX 與 ODP 中的 VBA 巨集。"
---
本文示範如何使用 **Aspose.Slides for Android via Java** 新增、存取與移除 VBA 巨集。

## **新增 VBA 巨集**

建立含有 VBA 專案與簡單巨集模組的簡報。

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