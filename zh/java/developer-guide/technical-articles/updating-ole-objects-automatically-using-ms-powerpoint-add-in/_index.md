---
title: 使用 MS PowerPoint 插件自动更新 OLE 对象
type: docs
weight: 10
url: /zh/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **关于自动更新 OLE 对象**
Aspose.Slides 客户最常问的一个问题是如何创建或更改可编辑的图表或其他 OLE 对象，并在打开演示文稿时自动更新它们。不幸的是，PowerPoint 不支持任何自动宏，而这些宏在 Excel 和 Word 中可用。仅有的可用宏是 Auto_Open 和 Auto_Close。然而，这些宏只会从插件中自动运行。这个简短的技术提示展示了如何实现这一点。

首先，有几个免费插件可以为 PowerPoint 添加 Auto_Open 宏功能，例如 [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) 和 [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)。

安装此类插件后，只需将 Auto_Open() 宏（在“事件生成器”中为 OnPresentationOpen()）添加到您的模板演示文稿中，如下所示：

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}

{{% alert color="primary" %}} 

使用 Aspose.Slides 对 OLE 对象所做的任何更改将在 PowerPoint 打开演示文稿时自动更新。如果您的演示文稿中有许多 OLE 对象而不想全部更新，只需为需要处理的形状添加自定义标签，并在宏中检查它。

{{% /alert %}}