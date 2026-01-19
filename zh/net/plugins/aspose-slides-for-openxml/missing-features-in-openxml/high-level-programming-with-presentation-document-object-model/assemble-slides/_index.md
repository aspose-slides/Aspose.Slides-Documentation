---
title: 组装幻灯片
type: docs
weight: 10
url: /zh/net/assemble-slides/
---

## **向演示文稿添加幻灯片**
在讨论向演示文稿文件添加幻灯片之前，先来了解一些关于幻灯片的事实。每个 PowerPoint 演示文稿文件都包含主母版/版式幻灯片以及其他普通幻灯片。这意味着演示文稿文件至少包含一个或多个幻灯片。需要注意的是，Aspose.Slides for .NET 不支持没有幻灯片的演示文稿文件。每个幻灯片都有唯一的 Id，所有普通幻灯片按照零基索引的顺序排列。

Aspose.Slides for .NET 允许开发者向演示文稿添加空白幻灯片。要在演示文稿中添加空白幻灯片，请按以下步骤操作：

- 创建 **Presentation** 类的实例
- 通过设置对 Presentation 对象公开的 Slides（内容 Slide 对象集合）属性的引用来实例化 **SlideCollection** 类
- 调用 **SlideCollection** 对象公开的 **AddEmptySlide** 方法，在内容幻灯片集合的末尾添加空白幻灯片
- 对新添加的空白幻灯片进行相应操作
- 最后，使用 **Presentation** 对象写入演示文稿文件

``` csharp

 PresentationEx pres = new PresentationEx();

//实例化 SlideCollection 类

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//向 Slides 集合添加空白幻灯片

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//将 PPTX 文件保存到磁盘

pres.Write("EmptySlide.pptx");

``` 
## **访问演示文稿的幻灯片**
Aspose.Slides for .NET 提供了 Presentation 类，可用于查找和访问演示文稿中任何所需的幻灯片。

**使用 Slides 集合**

**Presentation** 类表示一个演示文稿文件，并将其中的所有幻灯片公开为 **SlideCollection** 集合（即 **Slide** 对象的集合）。可以通过幻灯片索引从此 **Slides** 集合访问所有幻灯片。

``` csharp

 //实例化表示演示文稿文件的 Presentation 对象

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//使用幻灯片索引访问幻灯片

SlideEx slide = pres.Slides[0];

``` 
## **删除幻灯片**
我们知道 **Aspose.Slides for .NET** 中的 Presentation 类代表一个演示文稿文件。Presentation 类封装了一个 **SlideCollection**，该集合充当演示文稿中所有幻灯片的仓库。开发者可以通过两种方式从 Slides 集合中删除幻灯片：

- 使用幻灯片引用
- 使用幻灯片索引

**使用幻灯片引用**

要使用引用删除幻灯片，请按以下步骤操作：

- 创建 Presentation 类的实例
- 通过其 Id 或 Index 获取幻灯片的引用
- 从演示文稿中移除该引用的幻灯片
- 写入修改后的演示文稿文件

``` csharp

 //实例化表示演示文稿文件的 Presentation 对象

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//使用幻灯片集合中的索引访问幻灯片

SlideEx slide = pres.Slides[0];

//使用引用删除幻灯片

pres.Slides.Remove(slide);

//写入演示文稿文件

pres.Write("modified.pptx");

``` 
## **更改幻灯片位置**
更改演示文稿中幻灯片的位置非常简单。只需按以下步骤操作：

- 创建 Presentation 类的实例
- 通过其 Index 获取幻灯片的引用
- 更改该引用幻灯片的 SlideNumber
- 写入修改后的演示文稿文件

在下面的示例中，我们将演示文稿中位于零索引位置 1 的幻灯片位置更改为索引 1（位置 2）。

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//实例化 SlideCollection 类

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //向 Slides 集合添加空白幻灯片

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//将 PPTX 文件保存到磁盘

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//实例化表示演示文稿文件的 Presentation 对象

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//使用幻灯片索引访问幻灯片

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//实例化表示演示文稿文件的 Presentation 对象

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//使用幻灯片集合中的索引访问幻灯片

ISlide slide = pres.Slides[0];

//使用引用删除幻灯片

pres.Slides.Remove(slide);

//写入演示文稿文件

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//实例化 Presentation 类以加载源演示文稿文件

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //获取需要更改位置的幻灯片

    ISlide sld = pres.Slides[0];

    //设置幻灯片的新位置

    sld.SlideNumber = 2;

    //将演示文稿写入磁盘

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)