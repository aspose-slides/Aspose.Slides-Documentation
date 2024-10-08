---
title: 创建新演示文稿
type: docs
weight: 10
url: /php-java/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO的开发目的是让开发人员构建可以在Microsoft Office内部运行的应用程序。VSTO基于COM，但它被封装在一个.NET对象中，以便能够在.NET应用程序中使用。VSTO需要.NET框架的支持以及Microsoft Office CLR基于的运行时。尽管可以使用它来制作Microsoft Office插件，但几乎不可能将其用作服务器端组件。它还有严重的部署问题。

Aspose.Slides for PHP via Java是一个可以用来操作Microsoft PowerPoint演示文稿的组件，就像VSTO一样，但它有几个优点：

- Aspose.Slides仅包含托管代码，不需要安装Microsoft Office运行时。
- 它可以作为客户端组件或服务器端组件使用。
- 部署很简单，因为Aspose.Slides包含在一个单独的jar文件中。

{{% /alert %}} 
## **创建演示文稿**
以下是两个代码示例，说明如何使用VSTO和Aspose.Slides for PHP via Java来实现相同的目标。第一个示例是[VSTO](/slides/php-java/create-a-new-presentation/)；[第二个示例](/slides/php-java/create-a-new-presentation/)使用Aspose.Slides。
### **VSTO示例**
**VSTO输出** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Aspose.Slides for PHP via Java示例**
**Aspose.Slides的输出** 

![todo:image_alt_text](create-a-new-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}