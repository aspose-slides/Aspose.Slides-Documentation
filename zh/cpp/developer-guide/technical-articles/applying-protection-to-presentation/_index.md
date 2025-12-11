---
title: 使用形状锁防止演示文稿编辑
linktitle: 防止演示文稿编辑
type: docs
weight: 10
url: /zh/cpp/applying-protection-to-presentation/
keywords:
- 防止编辑
- 防止被编辑
- 锁定形状
- 锁定位置
- 锁定选择
- 锁定大小
- 锁定分组
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何在 PPT、PPTX 和 ODP 文件中锁定或解锁形状，保护演示文稿的安全，同时允许受控编辑并加快交付速度。"
---

## **背景**

Aspose.Slides 的常见用法是作为自动化工作流的一部分创建、更新和保存 Microsoft PowerPoint (PPTX) 演示文稿。以这种方式使用 Aspose.Slides 的应用程序的用户可以访问生成的演示文稿，因此保护它们不被编辑是一个常见的关注点。确保自动生成的演示文稿保留其原始的格式和内容非常重要。

本文说明了演示文稿和幻灯片的结构以及 Aspose.Slides for C++ 如何对演示文稿应用保护并在以后移除它。它为开发人员提供了一种控制其应用程序生成的演示文稿使用方式的方法。

## **幻灯片的组成**

演示文稿的幻灯片由自动形状、表格、OLE 对象、组合形状、图片框、视频框、连接线以及其他用于构建演示文稿的元素组成。在 Aspose.Slides for C++ 中，幻灯片上的每个元素都由实现了[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)接口或继承自实现该接口的类的对象表示。

PPTX 的结构比较复杂，因此不同于 PPT（可以对所有类型的形状使用通用锁），不同的形状类型需要不同的锁。[IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) 接口是 PPTX 的通用锁定类。Aspose.Slides for C++ 在 PPTX 中支持以下锁类型：

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) 用于锁定自动形状。  
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) 用于锁定连接线形状。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) 用于锁定图形对象。  
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) 用于锁定组合形状。  
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) 用于锁定图片框。   

对 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 对象中所有形状对象执行的任何操作都会应用于整个演示文稿。

## **应用和移除保护**

应用保护可确保演示文稿无法被编辑。这是一种保护演示文稿内容的有效技术。

### **对 PPTX 形状应用保护**

Aspose.Slides for C++ 提供了用于操作幻灯片上形状的[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 接口。

如前所述，每个形状类都有一个对应的形状锁类用于保护。本文重点介绍 NoSelect、NoMove 和 NoResize 锁。这些锁确保形状无法被选中（通过鼠标点击或其他选取方式），也无法被移动或调整大小。

以下代码示例对演示文稿中的所有形状类型应用保护。
```cpp
// 实例化表示 PPTX 文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// 遍历演示文稿中的所有幻灯片。
for (auto&& slide : presentation->get_Slides())	{

	// 遍历幻灯片中的所有形状。
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// 将形状强制转换为自动形状并获取其形状锁。
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// 将形状强制转换为组合形状并获取其形状锁。
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// 将形状强制转换为连接线形状并获取其形状锁。
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// 将形状强制转换为图片框并获取其形状锁。
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// 保存演示文稿文件。
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **移除保护**

要解锁形状，只需将已应用的锁的值设为 `false`。以下代码示例演示了如何在已锁定的演示文稿中解锁形状。
```cpp
// 实例化表示 PPTX 文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// 遍历演示文稿中的所有幻灯片。
for (auto&& slide : presentation->get_Slides())	{

	// 遍历幻灯片中的所有形状。
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// 将形状强制转换为自动形状并获取其形状锁。
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// 将形状强制转换为组合形状并获取其形状锁。
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// 将形状强制转换为连接线形状并获取其形状锁。
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// 将形状强制转换为图片框并获取其形状锁。
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// 保存演示文稿文件。
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **结论**

Aspose.Slides 提供了多种保护演示文稿中形状的选项。您可以锁定单个形状，也可以遍历演示文稿中的所有形状并逐一锁定，以有效保护整个文件。通过将锁的值设为 `false` 可移除保护。

## **常见问题**

**我可以在同一演示文稿中同时使用形状锁和密码保护吗？**

可以。锁定限制文件内部对象的编辑，而[密码保护](/slides/zh/cpp/password-protected-presentation/) 控制打开和/或保存更改的访问权限。这两种机制相互补充并协同工作。

**我可以仅限制特定幻灯片的编辑而不影响其他幻灯片吗？**

可以。对选定幻灯片上的形状应用锁定，其他幻灯片仍保持可编辑。

**形状锁是否适用于组合对象和连接线？**

是的。针对组合、连接线、图形对象以及其他形状类型提供了专用的锁定类型。