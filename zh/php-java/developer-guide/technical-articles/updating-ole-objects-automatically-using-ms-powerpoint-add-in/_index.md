---
title: 使用 MS PowerPoint 插件自动更新 OLE 对象
type: docs
weight: 10
url: /zh/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **关于自动更新 OLE 对象**
Aspose.Slides 的客户常常问的一个问题是如何创建或更改可编辑图表或其他 OLE 对象，并在打开演示文稿时自动更新它们。不幸的是，PowerPoint 不支持 Excel 和 Word 中可用的任何自动宏。唯一可用的是 Auto_Open 和 Auto_Close 宏。然而，这些宏只有在插件中才能自动运行。这个简短的技术小贴士展示了如何实现这一点。

首先，有几款免费的插件可以为 PowerPoint 添加 Auto_Open 宏功能，例如 [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) 和 [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html)。

安装此类插件后，只需将 Auto_Open() 宏（在“Event Generator”中为 OnPresentationOpen()）添加到您的模板演示文稿中，如下所示：

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}





{{% alert color="primary" %}} 

使用 Aspose.Slides 对 OLE 对象所做的任何更改将在 PowerPoint 打开演示文稿时自动更新。如果您在演示文稿中有多个 OLE 对象，并且不想更新它们所有，只需为您需要处理的形状添加一个自定义标签，并在宏中检查它。

{{% /alert %}}