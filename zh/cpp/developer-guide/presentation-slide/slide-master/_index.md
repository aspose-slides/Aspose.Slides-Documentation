---
title: 幻灯片母版
type: docs
weight: 80
url: /cpp/slide-master/
keywords: "添加幻灯片母版, PPT母版幻灯片, 幻灯片母版PowerPoint, 图片到幻灯片母版, 占位符, 多个幻灯片母版, 比较幻灯片母版, C++, CPP, Aspose.Slides for C++"
description: "在C++中添加或编辑PowerPoint演示文稿中的幻灯片母版"
---

## **什么是PowerPoint中的幻灯片母版**

**幻灯片母版**是定义演示文稿中幻灯片布局、样式、主题、字体、背景和其他属性的幻灯片模板。如果您想为您的公司创建一个（或一系列）具有相同样式和模板的演示文稿，可以使用幻灯片母版。

幻灯片母版很有用，因为它允许您一次设置和更改所有演示文稿幻灯片的外观。Aspose.Slides支持PowerPoint中的幻灯片母版机制。

VBA也允许您操作幻灯片母版并执行PowerPoint中支持的相同操作：更改背景、添加形状、自定义布局等等。Aspose.Slides提供灵活的机制，允许您使用幻灯片母版并执行基本任务。

这些是基本的幻灯片母版操作：

- 创建或幻灯片母版。
- 将幻灯片母版应用于演示文稿幻灯片。
- 更改幻灯片母版背景。
- 向幻灯片母版添加图像、占位符、智能艺术等。

这些是涉及幻灯片母版的更高级操作：

- 比较幻灯片母版。
- 合并幻灯片母版。
- 应用多个幻灯片母版。
- 将带幻灯片母版的幻灯片复制到另一个演示文稿。
- 查找演示文稿中的重复幻灯片母版。
- 将幻灯片母版设置为演示文稿的默认视图。

{{% alert color="primary" %}} 

您可能想查看Aspose [**在线PowerPoint查看器**](https://products.aspose.app/slides/viewer)，因为它是这里描述的一些核心过程的实时实现。

{{% /alert %}} 

## **如何应用幻灯片母版**

在您使用幻灯片母版之前，您可能想了解它们如何在演示文稿中使用和应用于幻灯片。

* 每个演示文稿默认至少有一个幻灯片母版。
* 一个演示文稿可以包含多个幻灯片母版。您可以添加多个幻灯片母版，并以不同的方式对演示文稿的不同部分进行样式设置。

在**Aspose.Slides**中，幻灯片母版由[**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide)类型表示。

Aspose.Slides的[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)对象包含[**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29)列表，类型为[**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)，其中包含演示文稿中定义的所有母版幻灯片的列表。

除了CRUD操作之外，[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)接口还包含这些有用的方法：[**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1)和[**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311)方法。这些方法是从基本幻灯片克隆功能继承的。但在处理幻灯片母版时，这些方法允许您实现复杂的设置。

当新的幻灯片添加到演示文稿时，幻灯片母版会自动应用于它。默认情况下，前一张幻灯片的幻灯片母版被选中。

**注意**：演示文稿幻灯片存储在[get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)列表中，每个新幻灯片默认添加到集合的末尾。如果演示文稿只包含一个幻灯片母版，该幻灯片母版将选用于所有新幻灯片。这就是为什么您不必为每个新幻灯片定义幻灯片母版的原因。

这个原则在PowerPoint和Aspose.Slides中是相同的。例如，在PowerPoint中，当您添加一个新演示文稿时，您可以只按最后一张幻灯片下方的底线，然后将创建一张新幻灯片（使用上一演示文稿的幻灯片母版）：

![todo:image_alt_text](slide-master_1.jpg)

在Aspose.Slides中，您可以使用[AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48)方法在[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类下执行等效任务。

## **幻灯片母版在幻灯片层次结构中**

使用幻灯片母版的幻灯片布局可以实现最大灵活性。幻灯片布局允许您设置与幻灯片母版相同的所有样式（背景、字体、形状等）。然而，当多个幻灯片布局与幻灯片母版组合在一起时，创建了一个新样式。当您将幻灯片布局应用于单个幻灯片时，您可以将其样式更改为幻灯片母版应用的样式。

幻灯片母版优先于所有设置项：幻灯片母版 -> 幻灯片布局 -> 幻灯片：

![todo:image_alt_text](slide-master_2)

每个[IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide)对象都有一个[get_LayoutSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37)属性，包含幻灯片布局列表。类型为[Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide)的对象有一个[**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8)属性，链接到应用于幻灯片的幻灯片布局。幻灯片与幻灯片母版之间的交互是通过幻灯片布局进行的。

{{% alert color="info" title="注意" %}}

* 在Aspose.Slides中，所有幻灯片设置（幻灯片母版、幻灯片布局和幻灯片本身）实际上都是实现了[**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide)接口的幻灯片对象。
* 因此，幻灯片母版和幻灯片布局可能实现相同的属性，您需要知道它们的值将如何应用于[Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide)对象。幻灯片母版首先应用于幻灯片，然后是幻灯片布局。例如，如果幻灯片母版和幻灯片布局都有背景值，则幻灯片最终将具有来自幻灯片布局的背景。

{{% /alert %}}

## **幻灯片母版的组成**

要理解幻灯片母版如何变化，您需要知道它的组成部分。这些是[MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/)的核心属性。

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - 获取/设置幻灯片背景。
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - 获取/设置幻灯片主体的文本样式。
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - 获取/设置幻灯片母版的所有形状（占位符、图片框等）。
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - 获取/设置ActiveX控件。
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - 获取主题管理器。
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - 获取页眉和页脚管理器。

幻灯片母版方法：

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - 获取所有依赖于幻灯片母版的幻灯片。
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - 允许您根据当前幻灯片母版和新主题创建新的幻灯片母版。新的幻灯片母版将应用于所有依赖的幻灯片。

## **获取幻灯片母版**

在PowerPoint中，可以通过视图 -> 幻灯片母版菜单访问幻灯片母版：

![todo:image_alt_text](slide-master_3.jpg)

使用Aspose.Slides，您可以这样访问幻灯片母版：

```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```

[IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide)接口表示幻灯片母版。与[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)类型相关的[get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29)属性包含演示文稿中定义的所有幻灯片母版的列表。

## **向幻灯片母版添加图像**

当您向幻灯片母版添加图像时，该图像将出现在所有依赖于该幻灯片母版的幻灯片上。

例如，您可以在幻灯片母版上放置公司的标志和一些图像，然后切换回幻灯片编辑模式。您应该会在每张幻灯片上看到该图像。

![todo:image_alt_text](slide-master_4.png)

您可以通过Aspose.Slides向幻灯片母版添加图像：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" title="另请参见" %}} 

有关向幻灯片添加图像的更多信息，请参见[图片框](/slides/cpp/picture-frame/#create-picture-frame)文章。
{{% /alert %}}

## **向幻灯片母版添加占位符**

这些文本字段是幻灯片母版上的标准占位符：

* 点击以编辑母版标题样式

* 编辑母版文本样式

* 第二级

* 第三级 

它们同样出现在基于幻灯片母版的幻灯片上。您可以编辑幻灯片母版上的这些占位符，并且更改会自动应用于幻灯片。

在PowerPoint中，您可以通过幻灯片母版 -> 插入占位符路径添加占位符：

![todo:image_alt_text](slide-master_5.png)

让我们通过Aspose.Slides检查一个更复杂的占位符示例。考虑一个从幻灯片母版模板生成占位符的幻灯片：

![todo:image_alt_text](slide-master_6.png)

我们希望以这种方式更改幻灯片母版上的标题和副标题格式：

![todo:image_alt_text](slide-master_7.png)

首先，我们从幻灯片母版对象获取标题占位符的内容，然后使用`PlaceHolder.FillFormat`字段：

```c++
System::SharedPtr<IAutoShape> FindPlaceholder(System::SharedPtr<IMasterSlide> master, PlaceholderType type)
{
    for (auto& shape : master->get_Shapes())
    {
        System::SharedPtr<IAutoShape> autoShape = System::AsCast<Aspose::Slides::IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            if (autoShape->get_Placeholder()->get_Type() == type)
            {
                return autoShape;
            }
        }
    }
    return nullptr;
}

void Main()
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
    System::SharedPtr<IAutoShape> placeHolder = FindPlaceholder(master, Aspose::Slides::PlaceholderType::Title);
    auto fillFormat = placeHolder->get_FillFormat();
    fillFormat->set_FillType(Aspose::Slides::FillType::Gradient);
    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(Aspose::Slides::GradientShape::Linear);
    gradientFormat->get_GradientStops()->Add(0.0f, System::Drawing::Color::FromArgb(255, 0, 0));
    gradientFormat->get_GradientStops()->Add(255.0f, System::Drawing::Color::FromArgb(128, 0, 128));
    
    pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
}
```

标题样式和格式将在所有基于幻灯片母版的幻灯片上更改：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="另请参见" %}} 

* [在占位符中设置提示文本](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [文本格式化](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **更改幻灯片母版上的背景**

当您更改母版幻灯片的背景颜色时，演示文稿中的所有常规幻灯片将获得新颜色。以下C++代码演示了该操作：

```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="primary" title="另请参见" %}} 

- [演示文稿背景](https://docs.aspose.com/slides/cpp/presentation-background/)

- [演示文稿主题](https://docs.aspose.com/slides/cpp/presentation-theme/)

  {{% /alert %}}

## **将幻灯片母版克隆到另一个演示文稿**

要将幻灯片母版克隆到另一个演示文稿，调用目标演示文稿中的[**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48)方法，同时传入幻灯片母版。以下C++代码展示了如何将幻灯片母版克隆到另一个演示文稿：

```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```

## **向演示文稿添加多个幻灯片母版**

Aspose.Slides允许您向任何给定的演示文稿添加多个幻灯片母版和幻灯片布局。这允许您以多种方式设置演示文稿幻灯片的样式、布局和格式选项。

在PowerPoint中，您可以通过这样的方式添加新的幻灯片母版和布局（来自“幻灯片母版菜单”）：

![todo:image_alt_text](slide-master_9.jpg)

使用Aspose.Slides，您可以通过调用[AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48)方法来添加新的幻灯片母版：

```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```

## **比较幻灯片母版**

幻灯片母版实现了包含[**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f)方法的[IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide)接口，该方法可以用于比较幻灯片。它为在结构和静态内容上相同的幻灯片母版返回`true`。

如果两个幻灯片母版的形状、样式、文本、动画和其他设置等相等，则它们是相等的。比较不考虑唯一标识符值（例如SlideId）和动态内容（例如日期占位符中的当前日期值）。

## **将幻灯片母版设置为演示文稿的默认视图**

Aspose.Slides允许您将幻灯片母版设置为演示文稿的默认视图。默认视图是在您打开演示文稿时首先看到的内容。

以下代码展示了如何在C++中将幻灯片母版设置为演示文稿的默认视图：

```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```

## **删除未使用的母版幻灯片**

Aspose.Slides提供了[RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/)方法（来自[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)类），允许您删除不必要和未使用的母版幻灯片。以下C++代码展示了如何从PowerPoint演示文稿中删除母版幻灯片：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```