---
title: 演示文稿锁定
type: docs
weight: 110
url: /zh/net/presentation-locking/
---

## **演示文稿锁定**
**Aspose.Slides** 的一个常见用途是在自动化工作流程中创建、更新和保存 Microsoft PowerPoint 2007（PPTX）演示文稿。以这种方式使用 Aspose.Slides 的应用程序用户可以访问输出的演示文稿。保护它们不被编辑是一项常见的关注点。确保自动生成的演示文稿保留其原始格式和内容非常重要。

这解释了演示文稿和幻灯片是如何构建的，以及 Aspose.Slides for .NET 如何对演示文稿应用保护，然后再将其移除。此功能是 Aspose.Slides 独有的，在撰写本文时，Microsoft PowerPoint 中尚不可用。它为开发人员提供了一种控制其应用程序创建的演示文稿如何使用的方法。
## **幻灯片的组成**
PPTX 幻灯片由多个组件组成，如自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接器和用于构建演示文稿的各种其他元素。

在 Aspose.Slides for .NET 中，幻灯片上的每个元素都转换为一个 Shape 对象。换句话说，幻灯片上的每个元素要么是 Shape 对象，要么是从 Shape 对象派生的对象。

PPTX 的结构复杂，因此与 PPT 不同，PPT 可以对所有类型的形状使用通用锁定，PPTX 对于不同的形状类型有不同类型的锁定。BaseShapeLock 类是通用的 PPTX 锁定类。Aspose.Slides for .NET 支持以下类型的 PPTX 锁定。

- AutoShapeLock 锁定自动形状。
- ConnectorLock 锁定连接器形状。
- GraphicalObjectLock 锁定图形对象。
- GroupshapeLock 锁定组合形状。
- PictureFrameLock 锁定图片框。

在 Presentation 对象中对所有 Shape 对象执行的任何操作都适用于整个演示文稿。
## **应用和移除保护**
应用保护可确保演示文稿无法编辑。这是一种保护演示文稿内容的有效技术。

**对 PPTX 形状应用保护**

Aspose.Slides for .NET 提供 Shape 类来处理幻灯片上的形状。

如前所述，每个形状类都有一个相关的形状锁定类以进行保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁定。这些锁定确保形状不能被选择（通过鼠标单击或其他选择方法），并且不能移动或调整大小。

以下代码示例将保护应用于演示文稿中的所有形状类型。

``` csharp

 //实例化代表 PPTX 文件的 Presentation 类

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//实例化代表 PPTX 文件的 Presentation 类


//用于访问演示文稿中幻灯片的 ISlide对象

SlideEx slide = pTemplate.Slides[0];

//用于临时存放形状的 IShape 对象

ShapeEx shape;

//遍历演示文稿中的所有幻灯片

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//遍历幻灯片中的所有形状

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//如果形状是自动形状

		if (shape is AutoShapeEx)

		{

			//类型转换为自动形状并获取自动形状锁定

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//应用形状锁定

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//如果形状是组合形状

		else if (shape is GroupShapeEx)

		{

			//类型转换为组合形状并获取组合形状锁定

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//应用形状锁定

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//如果形状是连接器

		else if (shape is ConnectorEx)

		{

			//类型转换为连接器形状并获取连接器形状锁定

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//应用形状锁定

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//如果形状是图片框

		else if (shape is PictureFrameEx)

		{

			//类型转换为图片框形状并获取图片框形状锁定

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//应用形状锁定

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//保存演示文稿文件

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**移除保护**

使用 Aspose.Slides for .NET 应用的保护只能通过 Aspose.Slides for .NET 移除。要解锁某个形状，请将已应用锁定的值设为 false。以下代码示例演示了如何在已锁定的演示文稿中解锁形状。

``` csharp

 //打开所需的演示文稿

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//用于访问演示文稿中幻灯片的 ISlide 对象

SlideEx slide = pTemplate.Slides[0];

//用于临时存放形状的 IShape 对象

ShapeEx shape;

//遍历演示文稿中的所有幻灯片

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//遍历幻灯片中的所有形状

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//如果形状是自动形状

		if (shape is AutoShapeEx)

		{

			//类型转换为自动形状并获取自动形状锁定

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//应用形状锁定

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//如果形状是组合形状

		else if (shape is GroupShapeEx)

		{

			//类型转换为组合形状并获取组合形状锁定

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//应用形状锁定

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//如果形状是连接器形状

		else if (shape is ConnectorEx)

		{

			//类型转换为连接器形状并获取连接器形状锁定

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//应用形状锁定

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//如果形状是图片框

		else if (shape is PictureFrameEx)

		{

			//类型转换为图片框形状并获取图片框形状锁定

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//应用形状锁定

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//保存演示文稿文件

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)