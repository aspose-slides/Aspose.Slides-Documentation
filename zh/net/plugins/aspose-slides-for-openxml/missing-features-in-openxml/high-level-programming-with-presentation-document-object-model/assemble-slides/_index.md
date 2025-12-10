---
title: 汇编幻灯片
type: docs
weight: 10
url: /zh/net/assemble-slides/
---

## **向演示文稿添加幻灯片**
在讨论向演示文稿文件添加幻灯片之前，让我们先了解一些关于幻灯片的事实。每个 PowerPoint 演示文稿文件都包含母版/布局幻灯片以及其他普通幻灯片。这意味着演示文稿文件至少包含一张或多张幻灯片。需要注意的是，不包含幻灯片的演示文稿文件不受 Aspose.Slides for .NET 支持。每张幻灯片都有唯一的 Id，所有普通幻灯片按照从零开始的索引顺序排列。

Aspose.Slides for .NET 允许开发者向演示文稿中添加空白幻灯片。要在演示文稿中添加空白幻灯片，请按以下步骤操作：

- 创建 **Presentation** 类的实例
- 通过设置对 Presentation 对象公开的 Slides（内容幻灯片对象集合）属性的引用，实例化 **SlideCollection** 类
- 调用 **SlideCollection** 对象公开的 **AddEmptySlide** 方法，在内容幻灯片集合的末尾添加空白幻灯片
- 对新添加的空白幻灯片进行相应操作
- 最后，使用 **Presentation** 对象写入演示文稿文件

``` csharp

 PresentationEx pres = new PresentationEx();

//Instantiate SlideCollection class

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Add an empty slide to the Slides collection

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Write("EmptySlide.pptx");

``` 
## **访问演示文稿的幻灯片**
Aspose.Slides for .NET 提供了 Presentation 类，可用于查找并访问演示文稿中任意所需的幻灯片。

**使用 Slides 集合**

**Presentation** 类表示一个演示文稿文件，并将其中的所有幻灯片公开为 **SlideCollection**（即 **Slide** 对象的集合）。可以通过幻灯片索引从此 **Slides** 集合中访问这些幻灯片。

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its slide index

SlideEx slide = pres.Slides[0];

``` 
## **删除幻灯片**
我们知道，**Aspose.Slides for .NET** 中的 Presentation 类表示一个演示文稿文件。Presentation 类封装了一个 **SlideCollection**，该集合充当演示文稿中所有幻灯片的仓库。开发者可以通过两种方式从此 Slides 集合中删除幻灯片：

- 使用幻灯片引用
- 使用幻灯片索引

**使用幻灯片引用**

要使用引用删除幻灯片，请按以下步骤操作：

- 创建 Presentation 类的实例
- 通过 Id 或 Index 获取幻灯片的引用
- 从演示文稿中删除该引用的幻灯片
- 写入修改后的演示文稿文件

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its index in the slides collection

SlideEx slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Write("modified.pptx");

``` 
## **更改幻灯片位置**
更改演示文稿中幻灯片的位置非常简单。只需按以下步骤操作：

- 创建 Presentation 类的实例
- 通过 Index 获取幻灯片的引用
- 更改该引用幻灯片的 SlideNumber
- 写入修改后的演示文稿文件

下面的示例演示了如何将演示文稿中位于零索引位置 1 的幻灯片移动到索引 1（位置 2）。

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

//Instantiate SlideCollection class

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Add an empty slide to the Slides collection

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its slide index

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its index in the slides collection

ISlide slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instantiate Presentation class to load the source presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Get the slide whose position is to be changed

    ISlide sld = pres.Slides[0];

    //Set the new position for the slide

    sld.SlideNumber = 2;

    //Write the presentation to disk

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)