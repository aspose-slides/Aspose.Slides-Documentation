---
title: Flash
type: docs
weight: 10
url: /zh/androidjava/flash/
description: 使用 Java 从 PowerPoint 演示文稿中提取 Flash 对象
---

## **从演示文稿中提取 Flash 对象**

Aspose.Slides for Android via Java 提供了一种从演示文稿中提取 Flash 对象的功能。您可以通过名称访问 Flash 控件并将其从演示文稿中提取出来，包括存储 SWF 对象数据。

```java
// 实例化表示 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```