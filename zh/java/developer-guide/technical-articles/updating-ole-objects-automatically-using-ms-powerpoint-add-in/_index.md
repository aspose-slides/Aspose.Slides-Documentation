---
title: 使用 PowerPoint 加载项自动更新 OLE 对象
type: docs
weight: 10
url: /zh/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE 对象
- 更新 OLE
- 自动
- 加载项
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用加载项和 Aspose.Slides for Java 在 PowerPoint 中自动更新 OLE 图表和对象，提供实用代码和优化技巧。"
---

## **自动更新 OLE 对象**

Aspose.Slides for Java 客户最常问的一个问题是如何创建或修改可编辑的图表（或其他 OLE 对象），使其在打开演示文稿时自动更新。不幸的是，PowerPoint 并不像 Excel 和 Word 那样支持自动宏。唯一可用的宏是 `Auto_Open` 和 `Auto_Close`，且只能从加载项中自动运行。本技术小贴士演示了实现方式。

首先，有几个免费加载项可以为 PowerPoint 添加 Auto_Open 宏功能，例如[AutoEvents Add-in](http://skp.mvps.org/autoevents.htm)和[Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)。

安装其中一个加载项后，只需像下面示例中那样在模板演示文稿中添加 `Auto_Open()` 宏（如果使用 Event Generator，则添加 `OnPresentationOpen()`）：
```java
// 循环遍历演示文稿中的每张幻灯片。
for (var oSlide : ActivePresentation.Slides) {
    // 循环遍历当前幻灯片上的所有形状。
    for (var oShape : oSlide.Shapes) {
        // 检查形状是否为 OLE 对象。
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // 找到 OLE 对象。获取其对象引用并进行更新。
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // 现在，退出 OLE 服务器程序。
            // 这将释放内存，并防止任何问题。
            // 同时，将 oObject 设为 Nothing 以释放对象。
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```


使用 Aspose.Slides for Java 对 OLE 对象所做的任何更改，在 PowerPoint 打开演示文稿时都会自动更新。如果 OLE 对象很多且不想全部更新，只需为需要处理的形状添加自定义标签，并在宏中检查该标签。