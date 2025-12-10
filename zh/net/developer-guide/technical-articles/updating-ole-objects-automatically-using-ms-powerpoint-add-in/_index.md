---
title: 使用 PowerPoint 加载项自动更新 OLE 对象
type: docs
weight: 10
url: /zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE 对象
- 更新 OLE
- 自动
- 加载项
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用加载项和 Aspose.Slides for .NET 在 PowerPoint 中自动更新 OLE 图表和对象，提供实用代码和优化技巧。"
---

## **自动更新 OLE 对象**

Aspose.Slides for .NET 客户最常问的问题之一是如何创建或修改可编辑的图表（或其他 OLE 对象），以便在打开演示文稿时自动更新。不幸的是，PowerPoint 并不像 Excel 和 Word 那样支持自动宏。唯一可用的宏是 `Auto_Open` 和 `Auto_Close`，且这些宏只能通过加载项自动运行。本简短技术提示展示了如何实现此功能。

首先，有多款免费插件可以为 PowerPoint 添加 Auto_Open 宏功能，例如[AutoEvents Add-in](http://skp.mvps.org/autoevents.htm)和[Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)。

安装这些插件之一后，只需将 `Auto_Open()` 宏（如果使用 Event Generator，则为 `OnPresentationOpen()`）添加到模板演示文稿中，如下所示：
```cs
public void Auto_Open()
{
    // 循环遍历演示文稿中的每个幻灯片。
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // 循环遍历当前幻灯片上的所有形状。
        foreach (var oShape in oSlide.Shapes)
        {
            // 检查形状是否为 OLE 对象。
            if (oShape.Type == msoEmbeddedOLEObject)
            {
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
}
```


使用 Aspose.Slides for .NET 对 OLE 对象所作的任何更改，在 PowerPoint 打开演示文稿时都会自动更新。如果你有大量 OLE 对象且不想全部更新，只需为需要处理的形状添加自定义标签，并在宏中检查该标签即可。