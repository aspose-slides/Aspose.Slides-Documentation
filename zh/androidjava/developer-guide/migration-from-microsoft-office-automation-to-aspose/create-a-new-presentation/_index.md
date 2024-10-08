---
title: 创建新演示文稿
type: docs
weight: 10
url: /zh/androidjava/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO 是为了让开发者构建能在 Microsoft Office 中运行的应用程序而开发的。VSTO 基于 COM，但它封装在 .NET 对象中，因此可以在 .NET 应用程序中使用。VSTO 需要 .NET 框架的支持以及 Microsoft Office CLR 基于运行时。虽然它可以用于制作 Microsoft Office 插件，但几乎不可能用作服务器端组件。它也存在严重的部署问题。

Aspose.Slides for Android via Java 是一个可以用来操作 Microsoft PowerPoint 演示文稿的组件，类似于 VSTO，但它有几个优点：

- Aspose.Slides 只包含托管代码，不需要安装 Microsoft Office 运行时。
- 它可以作为客户端组件或服务器端组件使用。
- 部署很简单，因为 Aspose.Slides 包含在一个 jar 文件中。

{{% /alert %}} 
## **创建演示文稿**
以下是两个代码示例，说明如何使用 VSTO 和 Aspose.Slides for Android via Java 实现相同的目标。第一个示例是 [VSTO](/slides/zh/androidjava/create-a-new-presentation/)；[第二个示例](/slides/zh/androidjava/create-a-new-presentation/) 使用 Aspose.Slides。
### **VSTO 示例**
**VSTO 输出** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Aspose.Slides for Android via Java 示例**
**Aspose.Slides 的输出** 

![todo:image_alt_text](create-a-new-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}