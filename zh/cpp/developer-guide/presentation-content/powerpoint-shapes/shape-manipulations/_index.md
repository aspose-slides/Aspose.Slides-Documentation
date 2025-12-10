---
title: 在 C++ 中管理演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/cpp/shape-manipulations/
keywords:
- PowerPoint 形状
- 演示文稿形状
- 幻灯片上的形状
- 查找形状
- 克隆形状
- 删除形状
- 隐藏形状
- 更改形状顺序
- 获取 Interop 形状 ID
- 形状替代文本
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中创建、编辑和优化形状，并交付高性能的 PowerPoint 演示文稿。"
---

## **在幻灯片上查找形状**
本章节将介绍一种简便技术，帮助开发者在不使用内部 Id 的情况下更容易在幻灯片上找到特定形状。需要了解的是，PowerPoint 演示文稿文件除了内部唯一 Id 外，没有其他方式标识幻灯片上的形状。开发者使用内部唯一 Id 查找形状往往比较困难。所有添加到幻灯片的形状都有 Alt Text（替代文本）。我们建议开发者使用替代文本来查找特定形状。您可以使用 MS PowerPoint 为计划以后更改的对象定义替代文本。

在为任意所需形状设置替代文本后，您即可使用 Aspose.Slides for C++ 打开该演示文稿，并遍历幻灯片中添加的所有形状。在每次遍历时检查形状的 AlternativeText，匹配的 AlternativeText 所对应的形状即为您需要的形状。为了更直观地演示此技术，我们创建了一个方法[FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f)，它可以在幻灯片中查找特定形状并返回该形状。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **克隆形状**
使用 Aspose.Slides for C++ 将形状克隆到幻灯片的步骤：

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 访问源幻灯片的形状集合。  
1. 向演示文稿添加一个新幻灯片。  
1. 将源幻灯片形状集合中的形状克隆到新幻灯片。  
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加了一个组合形状。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **删除形状**
Aspose.Slides for C++ 允许开发者删除任意形状。要从幻灯片中删除形状，请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。  
1. 访问第一张幻灯片。  
1. 查找具有特定 AlternativeText 的形状。  
1. 删除该形状。  
1. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **隐藏形状**
Aspose.Slides for C++ 允许开发者隐藏任意形状。要隐藏幻灯片中的形状，请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。  
1. 访问第一张幻灯片。  
1. 查找具有特定 AlternativeText 的形状。  
1. 隐藏该形状。  
1. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **更改形状顺序**
Aspose.Slides for C++ 允许开发者重新排序形状。重新排序决定形状是位于前面还是后面。要对幻灯片中的形状进行重新排序，请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。  
1. 访问第一张幻灯片。  
1. 添加一个形状。  
1. 在形状的文本框中添加一些文本。  
1. 再添加一个具有相同坐标的形状。  
1. 重新排序这些形状。  
1. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **获取 Interop Shape ID**
Aspose.Slides for C++ 允许开发者获取幻灯片范围内唯一的形状标识符（与 UniqueId 属性不同，后者在演示文稿范围内唯一）。在 IShape 接口和 Shape 类中分别添加了 OfficeInteropShapeId 属性。OfficeInteropShapeId 属性返回的值对应 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id。以下示例演示了相关代码。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **设置 AlternativeText 属性**
Aspose.Slides for C++ 允许开发者为任意形状设置 AlternateText。要设置形状的 AlternateText，请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。  
1. 访问第一张幻灯片。  
1. 向幻灯片添加任意形状。  
1. 对新添加的形状进行相应操作。  
1. 遍历形状集合以找到目标形状。  
1. 设置 AlternativeText。  
1. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **访问形状的布局格式**
Aspose.Slides for C++ 允许开发者访问形状的布局格式。本文演示如何访问形状的**FillFormat**和**LineFormat**属性。

以下示例展示了相应的代码。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **将形状渲染为 SVG**
现在 Aspose.Slides for C++ 支持将形状渲染为 SVG。Shape 类和 IShape 接口中已添加 WriteAsSvg 方法（及其重载），该方法可将形状内容保存为 SVG 文件。下面的代码片段展示了如何将幻灯片中的形状导出为 SVG 文件。
``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```


## **形状对齐**
Aspose.Slides 允许将形状相对于幻灯片边距或相互之间对齐。为此，新增了重载的[SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) 方法。[ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) 枚举定义了可能的对齐选项。

**示例 1**

下面的源代码将索引为 1、2 和 4 的形状对齐到幻灯片的顶部边缘。  
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```


**示例 2**

下面的示例展示如何将整个形状集合相对于集合中最底部的形状进行对齐。  
``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```


## **翻转属性**

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) 类通过 `flipH` 与 `flipV` 属性提供对形状水平和垂直镜像的控制。这两个属性的类型为[NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/)，可以取 `True`（翻转）、`False`（不翻转）或 `NotDefined`（使用默认行为）。这些值可通过形状的[Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) 访问。

要修改翻转设置，可使用形状当前的位置、尺寸以及所需的 `flipH`、`flipV` 值和旋转角度构造一个新的[ShapeFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapeframe/) 实例。将该实例分配给形状的[Frame](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_frame/) 并保存演示文稿，即可应用镜像转换并写入输出文件。

假设我们有一个 sample.pptx 文件，其第一张幻灯片包含一个默认翻转设置的单个形状，如下所示。

![要翻转的形状](shape_to_be_flipped.png)

下面的代码示例获取该形状当前的翻转属性，并同时对其进行水平和垂直翻转。
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// 检索形状的水平翻转属性。
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// 检索形状的垂直翻转属性。
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // 水平翻转。
auto flipV = NullableBool::True; // 水平翻转。
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


结果：

![已翻转的形状](flipped_shape.png)

## **常见问题**

**我可以像桌面编辑器那样在幻灯片上对形状进行合并（并集/交集/相减）吗？**

目前没有内置的布尔运算 API。您可以通过自行构造所需轮廓来近似实现，例如使用 [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) 计算结果几何并创建具有该轮廓的新形状，同时可选择删除原始形状。

**如何控制堆叠顺序（z‑order），使某个形状始终位于“顶部”？**

在幻灯片的[shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) 集合中更改插入/移动顺序即可。为获得可预期的结果，请在完成所有其他幻灯片修改后最终确定 z‑order。

**我可以“锁定”形状，以防止用户在 PowerPoint 中编辑它吗？**

可以。设置[形状级别的保护标志](/slides/zh/cpp/applying-protection-to-presentation/)（例如锁定选择、移动、调整大小、文本编辑）。如有需要，也可以在母版或布局上镜像这些限制。需注意这属于 UI 层面的保护，而非安全特性；若需更强的保护，可结合文件级限制，如[只读建议或密码](/slides/zh/cpp/password-protected-presentation/)。