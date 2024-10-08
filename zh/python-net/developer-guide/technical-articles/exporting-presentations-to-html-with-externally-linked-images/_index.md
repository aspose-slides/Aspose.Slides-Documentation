---
title: 将演示文稿导出为带有外部链接图像的HTML
type: docs
weight: 100
url: /python-net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

本文描述了一种高级技术，允许控制哪些资源嵌入到生成的HTML文件中，哪些资源则保存为外部并从HTML文件中引用。

{{% /alert %}} 
## **背景**
默认的HTML导出行为是将任何资源嵌入到HTML文件中。这种方法会生成一个易于查看和分发的单一HTML文件。所有必要的资源都以base64编码嵌入其中。但是，这种方法有两个缺点：

- 输出文件的大小显著增加，因为使用了base64编码。*很难替换文件中包含的图像。

在本文中，我们将看到如何使用**Aspose.Slides for Python via .NET**更改默认行为，以外部链接的方式而非将图像嵌入HTML文件。我们将使用**ILinkEmbedController**接口，该接口包含三个方法来控制资源的嵌入和保存过程。我们可以在准备导出时将此接口传递给HtmlOptions类的构造函数。

以下是实现**ILinkEmbedController**接口的**LinkController**类的完整代码。如前所述，LinkController必须实现ILinkEmbedController接口。该接口指定了三个方法：

- **public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)** 当导出器遇到资源并需要决定如何存储时，会调用该方法。最重要的参数是‘id’——整个导出操作的资源唯一标识符和‘contentType’——包含资源的MIME类型。如果我们决定链接资源，则应从此方法返回LinkEmbedDecision.Link。否则，应返回LinkEmbedDecision.Embed以嵌入该资源。
- **public string GetUrl(int id, int referrer)** 
  用于以结果文件中使用的形式获取资源的URL，例如对于 `<img src="%method_result_here%">` 标签。资源由‘id’标识。
- **public void SaveExternal(int id, byte[] entityData)** 
  序列中的最后一个方法，在需要将资源外部存储时调用。我们有资源标识符和资源内容，作为字节数组。如何处理提供的资源数据取决于我们。

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

在编写完**LinkController**类后，我们将使用它与**HTMLOptions**类结合，使用以下代码将演示文稿导出为带有外部链接图像的HTML。

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

我们将**SlideImageFormat.Svg**分配给**SlideImageFormat**属性，这意味着生成的HTML文件将包含SVG数据以绘制演示文稿内容。

至于内容类型，这取决于演示文稿中包含的实际图像数据。如果演示文稿中有栅格位图，则类代码必须准备好处理‘image/jpeg’和‘image/png’两种内容类型。导出栅格位图图像的实际内容类型可能与演示文稿中存储的图像的内容类型不匹配。Aspose.Slides的内部算法会执行大小优化，并使用产生较小数据大小的JPG或PNG编解码器。包含alpha通道（透明度）的图像始终编码为PNG。