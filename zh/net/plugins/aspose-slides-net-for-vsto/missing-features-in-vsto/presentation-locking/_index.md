---
title: 演示文稿锁定
type: docs
weight: 110
url: /zh/net/presentation-locking/
---

## **演示文稿锁定**
**Aspose.Slides** 的常见用途是作为自动化工作流的一部分创建、更新和保存 Microsoft PowerPoint 2007（PPTX）演示文稿。以这种方式使用 Aspose.Slides 的应用程序用户可以访问输出的演示文稿。保护它们不被编辑是一个常见的关注点。确保自动生成的演示文稿保持原始的格式和内容非常重要。

本文解释了演示文稿和幻灯片的构建方式以及 Aspose.Slides for .NET 如何对演示文稿应用保护并随后移除保护。此功能是 Aspose.Slides 独有的，在撰写本文时，Microsoft PowerPoint 尚不支持。它为开发人员提供了一种控制其应用程序创建的演示文稿使用方式的方法。

## **幻灯片的组成**
一个 PPTX 幻灯片由多种组件组成，例如自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及用于构建演示文稿的其他各种元素。

在 Aspose.Slides for .NET 中，幻灯片上的每个元素都会转换为 Shape 对象。换句话说，幻灯片上的每个元素要么是 Shape 对象，要么是从 Shape 对象派生的对象。

PPTX 的结构比较复杂，因此不同于 PPT 可以对所有形状使用通用锁，PPTX 对不同类型的形状提供了不同的锁。BaseShapeLock 类是通用的 PPTX 锁定类。Aspose.Slides for .NET 在 PPTX 中支持以下类型的锁。

- AutoShapeLock 锁定自动形状。
- ConnectorLock 锁定连接形状。
- GraphicalObjectLock 锁定图形对象。
- GroupshapeLock 锁定组合形状。
- PictureFrameLock 锁定图片框。

对 Presentation 对象中所有 Shape 对象执行的任何操作都会应用于整个演示文稿。

## **应用和移除保护**
应用保护可确保演示文稿无法被编辑。这是一种保护演示文稿内容的有效技术。

**对 PPTX 形状应用保护**

Aspose.Slides for .NET 提供了 Shape 类来处理幻灯片上的形状。

如前所述，每个形状类都有对应的形状锁类用于保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状不能被选中（通过鼠标点击或其他选择方式），并且不能被移动或调整大小。

下面的代码示例对演示文稿中的所有形状类型应用保护。

``` csharp

 //Instatiate Presentation class that represents a PPTX file

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instatiate Presentation class that represents a PPTX file


//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in the presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//if shape is a connector

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to picture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Saving the presentation file

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**移除保护**

使用 Aspose.Slides for .NET 应用的保护只能通过 Aspose.Slides for .NET 移除。要解锁形状，只需将已应用锁的值设为 false。下面的代码示例展示了如何在已锁定的演示文稿中解锁形状。

``` csharp

 //Open the desired presentation

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//if shape is Connector shape

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to pitcture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Saving the presentation file

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)