---
title: 形状操作
type: docs
weight: 40
url: /cpp/shape-manipulations/
---

## **在幻灯片中查找形状**
本主题将描述一种简单的技术，以帮助开发人员无需使用内部 Id 即可找到幻灯片上的特定形状。重要的是要知道，PowerPoint 演示文稿文件没有其他方法来识别幻灯片上的形状，除了内部唯一 Id。开发人员似乎很难使用其内部唯一 Id 找到形状。所有添加到幻灯片的形状都有一些替代文本。我们建议开发人员使用替代文本来查找特定形状。您可以使用 MS PowerPoint 为您计划在未来更改的对象定义替代文本。

在设置任何所需形状的替代文本后，您可以使用 Aspose.Slides for C++ 打开该演示文稿并遍历添加到幻灯片的所有形状。在每次迭代中，您可以检查形状的替代文本，具有匹配替代文本的形状将是您所需的形状。为了更好地演示这种技术，我们创建了一个方法，[FindShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f)，用于查找幻灯片中的特定形状，然后简简单单返回该形状。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}


## **克隆形状**
要使用 Aspose.Slides for C++ 将形状克隆到幻灯片：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 使用其索引获取幻灯片的引用。
1. 访问源幻灯片的形状集合。
1. 向演示文稿添加新幻灯片。
1. 从源幻灯片形状集合克隆形状到新幻灯片。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例将组形状添加到幻灯片中。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}


## **删除形状**
Aspose.Slides for C++ 允许开发人员删除任何形状。要从任何幻灯片中删除形状，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 访问第一张幻灯片。
1. 找到具有特定替代文本的形状。
1. 删除该形状。
1. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}


## **隐藏形状**
Aspose.Slides for C++ 允许开发人员隐藏任何形状。要隐藏任何幻灯片中的形状，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 访问第一张幻灯片。
1. 找到具有特定替代文本的形状。
1. 隐藏该形状。
1. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}



## **更改形状顺序**
Aspose.Slides for C++ 允许开发人员重新排列形状。重新排列形状指定哪个形状在前面或哪个形状在后面。要从任何幻灯片中重新排列形状，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 使用相同的坐标添加另一个形状。
1. 重新排列形状。
1. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}


## **获取互操作形状 ID**
Aspose.Slides for C++ 允许开发人员在幻灯片范围内获取唯一形状标识符，与允许在演示文稿范围内获取唯一标识符的 UniqueId 属性相反。 OfficeInteropShapeId 属性已分别添加到 IShape 接口和 Shape 类中。 OfficeInteropShapeId 属性返回的值对应于 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id 的值。下面给出了示例代码。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}


## **设置替代文本属性**
Aspose.Slides for C++ 允许开发人员设置任何形状的替代文本。要设置形状的替代文本，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 访问第一张幻灯片。
1. 向幻灯片添加任何形状。
1. 对新添加的形状进行一些操作。
1. 遍历形状以查找形状。
1. 设置替代文本。
1. 将文件保存到磁盘。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}


## **访问形状的布局格式**
Aspose.Slides for C++ 允许开发人员访问形状的布局格式。 本文演示了如何访问形状的 **FillFormat** 和 **LineFormat** 属性。

下面给出了示例代码。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **将形状渲染为 SVG**
现在 Aspose.Slides for C++ 支持将形状渲染为 SVG。 WriteAsSvg 方法（及其重载）已添加到 Shape 类和 IShape 接口中。 此方法允许将形状的内容保存为 SVG 文件。 下面的代码片段显示了如何将幻灯片的形状导出为 SVG 文件。

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **形状对齐**
Aspose.Slides 允许按幻灯片边距或相互之间对齐形状。为此，添加了重载的 [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) 方法。 [ShapesAlignmentType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) 枚举定义了可能的对齐选项。

**示例 1**

下面的源代码将索引 1、2 和 4 的形状沿幻灯片的上边界对齐。

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

下面的示例演示了如何将整个形状集合相对于集合中的最后一个形状进行对齐。

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```