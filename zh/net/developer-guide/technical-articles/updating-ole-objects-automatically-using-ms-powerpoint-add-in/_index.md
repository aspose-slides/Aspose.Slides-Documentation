---
title: 使用 MS PowerPoint 加载项自动更新 OLE 对象
type: docs
weight: 10
url: /zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **关于自动更新 OLE 对象**
Aspose.Slides for .NET 客户最常问的问题之一是如何创建或更改可编辑图表或其他 OLE 对象，并在打开演示文稿时自动更新它们。遗憾的是，PowerPoint 不支持 Excel 和 Word 中可用的任何自动宏。唯一可用的是 Auto_Open 和 Auto_Close 宏。然而，这些宏只能从加载项中自动运行。这个简短的技术提示展示了如何实现这一点。

首先，有几个免费的加载项可以为 PowerPoint 添加 Auto_Open 宏功能，例如 [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) 和 [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)。

安装此类加载项后，只需将 Auto_Open() 宏（在 "Event Generator" 的情况下为 OnPresentationOpen()）添加到您的模板演示文稿中，如下所示：

```c#
public void Auto_Open()
{
    Shape oShape;
    Slide oSlide;
    object oGraph;

    // 循环遍历演示文稿中的每一张幻灯片。
    foreach (var oSlide in ActivePresentation.Slides)
    {

        // 循环遍历当前幻灯片上的所有形状。
        foreach (var oShape in oSlide.Shapes)
        {

            // 检查形状是否为 OLE 对象。
            if (oShape.Type == msoEmbeddedOLEObject)
            {

                // 找到 OLE 对象；获取对象引用，然后更新。
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // 现在，退出 OLE 服务器程序。这将释放
                // 内存，并防止任何问题。同时，将 oObject 设置为
                // Nothing 以释放对象。
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

{{% alert color="primary" %}} 

对 Aspose.Slides for .NET 中 OLE 对象所做的任何更改，将在 PowerPoint 打开演示文稿时自动更新。如果您在演示文稿中有许多 OLE 对象，不希望全部更新，只需为需要处理的形状添加一个自定义标签并在宏中检查它。

{{% /alert %}}