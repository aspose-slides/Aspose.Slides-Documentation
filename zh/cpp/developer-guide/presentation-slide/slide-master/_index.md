---
title: 管理 C++ 中的演示文稿幻灯片母版
linktitle: 幻灯片母版
type: docs
weight: 80
url: /zh/cpp/slide-master/
keywords:
- 幻灯片母版
- 母版幻灯片
- PPT 母版幻灯片
- 多个母版幻灯片
- 比较母版幻灯片
- 背景
- 占位符
- 克隆母版幻灯片
- 复制母版幻灯片
- 重复的母版幻灯片
- 未使用的母版幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中管理幻灯片母版：使用简洁的 C++ 示例创建、编辑并应用布局、主题和占位符到 PPT、PPTX 和 ODP。"
---

## **PowerPoint 中的幻灯片母版是什么**

A **Slide Master** 是一种幻灯片模板，用于定义演示文稿中幻灯片的布局、样式、主题、字体、背景以及其他属性。如果希望为公司制作一套具有相同样式和模板的演示文稿（或一系列演示文稿），可以使用幻灯片母版。

幻灯片母版的优势在于可以一次性设置并更改所有演示文稿幻灯片的外观。Aspose.Slides 支持 PowerPoint 的幻灯片母版机制。

VBA 也允许操作幻灯片母版并执行 PowerPoint 支持的相同操作：更改背景、添加形状、定制布局等。Aspose.Slides 提供灵活的机制，帮助您使用幻灯片母版并完成基本任务。

以下是基本的幻灯片母版操作：

- 创建或获取幻灯片母版。
- 将幻灯片母版应用于演示文稿中的幻灯片。
- 更改幻灯片母版的背景。 
- 向幻灯片母版添加图片、占位符、Smart Art 等。

以下是更高级的幻灯片母版操作：

- 比较幻灯片母版。
- 合并幻灯片母版。
- 应用多个幻灯片母版。
- 将包含幻灯片母版的幻灯片复制到另一个演示文稿。
- 查找演示文稿中重复的幻灯片母版。
- 将幻灯片母版设为演示文稿的默认视图。

{{% alert color="primary" %}} 

您可能想查看 Aspose [**在线 PowerPoint 查看器**](https://products.aspose.app/slides/viewer)，因为它实现了本文中描述的部分核心流程。

{{% /alert %}} 

## **幻灯片母版是如何应用的**

在使用幻灯片母版之前，您可能需要了解它们在演示文稿中的使用方式以及如何应用到幻灯片上。

* 每个演示文稿默认至少包含一个幻灯片母版。 
* 一个演示文稿可以包含多个幻灯片母版。您可以添加多个幻灯片母版，并以不同方式为演示文稿的不同部分设置样式。 

在 **Aspose.Slides** 中，幻灯片母版由 [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) 类型表示。

Aspose.Slides 的 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 对象包含 [**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) 列表，它是 [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) 类型的实例，存放演示文稿中定义的所有母版幻灯片。

除了 CRUD 操作，[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) 接口还提供以下实用方法： [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) 和 [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311)。这些方法继承自基本的幻灯片克隆功能，但在处理幻灯片母版时，可用于实现更复杂的布局。

当向演示文稿添加新幻灯片时，会自动为其应用幻灯片母版。默认情况下选择前一张幻灯片的母版。

**Note**: 演示文稿幻灯片存放在 [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 列表中，默认情况下每个新幻灯片都会追加到集合末尾。如果演示文稿仅包含单个幻灯片母版，则该母版会被选中用于所有新幻灯片。这就是为什么您无需为每个新幻灯片单独指定母版的原因。

PowerPoint 与 Aspose.Slides 的原理相同。例如，在 PowerPoint 中，添加新幻灯片时，只需单击最后一张幻灯片下方的空白行，即可创建一张使用上一张幻灯片母版的新幻灯片：

![todo:image_alt_text](slide-master_1.jpg)

在 Aspose.Slides 中，您可以使用 [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) 方法在 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类下完成同样的操作。

## **幻灯片母版在 Slides 层级结构中的位置**

使用幻灯片布局结合幻灯片母版可实现最大灵活性。幻灯片布局允许您设置与幻灯片母版相同的所有样式（背景、字体、形状等）。然而，当在同一幻灯片母版上组合多个幻灯片布局时，会产生新的样式。将幻灯片布局应用于单个幻灯片后，您可以将其样式从母版的样式中切换。

幻灯片母版的层级高于所有设置项： 幻灯片母版 -> 幻灯片布局 -> 幻灯片：

![todo:image_alt_text](slide-master_2)

每个 [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) 对象都有一个 [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) 属性，返回幻灯片布局列表。每个 [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) 类型拥有一个 [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) 属性，指向应用于该幻灯片的幻灯片布局。幻灯片与幻灯片母版之间的交互通过幻灯片布局实现。

{{% alert color="info" title="Note" %}}

* 在 Aspose.Slides 中，所有幻灯片设置（幻灯片母版、幻灯片布局以及幻灯片本身）实际都是实现了 [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) 接口的幻灯片对象。  
* 因此，幻灯片母版和幻灯片布局可能实现相同的属性，您需要了解它们的值如何最终作用于 [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) 对象。幻灯片母版先应用于幻灯片，随后幻灯片布局再应用。例如，如果幻灯片母版和幻灯片布局都设置了背景，则最终幻灯片的背景将以幻灯片布局的背景为准。

{{% /alert %}}

## **幻灯片母版包含哪些内容**

要了解如何更改幻灯片母版，需先掌握其组成部分。以下是 [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) 的核心属性：

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - 获取/设置幻灯片背景。  
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - 获取/设置幻灯片正文的文本样式。  
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - 获取/设置幻灯片母版上的所有形状（占位符、图片框等）。  
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - 获取/设置 ActiveX 控件。  
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - 获取主题管理器。  
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - 获取页眉页脚管理器。

幻灯片母版的方法：

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - 获取所有依赖于该母版的幻灯片。  
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - 基于当前母版和新主题创建新的幻灯片母版，并将其应用于所有关联幻灯片。

## **获取幻灯片母版**

在 PowerPoint 中，可通过 “视图 → 幻灯片母版” 菜单访问幻灯片母版：

![todo:image_alt_text](slide-master_3.jpg)

使用 Aspose.Slides，可按如下方式访问幻灯片母版：
```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```


[IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) 接口代表幻灯片母版。[get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) 属性（对应 [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) 类型）包含演示文稿中定义的所有幻灯片母版列表。

## **向幻灯片母版添加图片**

向幻灯片母版添加图片后，该图片会出现在所有依赖该母版的幻灯片上。例如，您可以在幻灯片母版上放置公司标志和若干图片，然后切换回幻灯片编辑模式，您会看到每张幻灯片都显示该图片。

![todo:image_alt_text](slide-master_4.png)

使用 Aspose.Slides 添加图片：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 

有关向幻灯片添加图片的更多信息，请参阅 [Picture Frame](/slides/zh/cpp/picture-frame/#create-picture-frame) 文章。

{{% /alert %}}

## **向幻灯片母版添加占位符**

以下文本框是幻灯片母版上的标准占位符：

* Click to edit Master title style  
* Edit Master text styles  
* Second level  
* Third level  

它们同样会出现在基于该母版的幻灯片上。您可以在幻灯片母版上编辑这些占位符，修改会自动应用到相应的幻灯片。

在 PowerPoint 中，可通过 “幻灯片母版 → 插入占位符” 路径添加占位符：

![todo:image_alt_text](slide-master_5.png)

下面演示使用 Aspose.Slides 处理更复杂占位符的示例。假设一张幻灯片的占位符模板来源于幻灯片母版：

![todo:image_alt_text](slide-master_6.png)

我们希望以如下方式更改幻灯片母版上的标题和副标题格式：

![todo:image_alt_text](slide-master_7.png)

首先，从幻灯片母版对象获取标题占位符内容，然后使用 `PlaceHolder.FillFormat` 字段：
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


标题样式和格式将对所有基于该母版的幻灯片生效：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/cpp/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **更改幻灯片母版的背景**

更改母版幻灯片的背景颜色后，演示文稿中的所有普通幻灯片都会使用新颜色。下面的 C++ 代码演示了该操作：
```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 

- [Presentation Background](https://docs.aspose.com/slides/cpp/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/cpp/presentation-theme/)

{{% /alert %}}

## **将幻灯片母版克隆到另一个演示文稿**

要将幻灯片母版克隆到另一个演示文稿，只需在目标演示文稿上调用 [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) 方法，并传入要克隆的幻灯片母版。以下 C++ 代码展示了具体实现：
```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```


## **向演示文稿添加多个幻灯片母版**

Aspose.Slides 允许在任意演示文稿中添加多个幻灯片母版和幻灯片布局，从而以多种方式设置幻灯片的样式、布局和格式。

在 PowerPoint 中，可通过 “幻灯片母版” 菜单添加新的幻灯片母版和布局：

![todo:image_alt_text](slide-master_9.jpg)

使用 Aspose.Slides，可通过调用 [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) 方法添加新的幻灯片母版：
```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```


## **比较幻灯片母版**

母版幻灯片实现了 [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) 接口，其中包含 [**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f) 方法，可用于比较幻灯片。对于结构和静态内容相同的母版幻灯片，返回 `true`。

如果母版幻灯片的形状、样式、文本、动画等设置全部相同，则视为相等。比较过程不考虑唯一标识符（例如 SlideId）以及动态内容（例如日期占位符中的当前日期）。

## **将幻灯片母版设为演示文稿的默认视图**

Aspose.Slides 允许将幻灯片母版设置为演示文稿的默认视图。默认视图是打开演示文稿时首先看到的视图。

以下代码展示了在 C++ 中将幻灯片母版设为演示文稿默认视图的实现：
```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```


## **移除未使用的母版幻灯片**

Aspose.Slides 提供了 [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法（来自 [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类），帮助删除不需要的母版幻灯片。以下 C++ 代码演示了如何从 PowerPoint 演示文稿中移除母版幻灯片：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**PowerPoint 中的幻灯片母版是什么？**

幻灯片母版是一种幻灯片模板，用于定义演示文稿中幻灯片的布局、样式、主题、字体、背景以及其他属性。它可以一次性设置并更改所有演示文稿幻灯片的外观。

**幻灯片母版在演示文稿中是如何应用的？**

每个演示文稿默认至少包含一个幻灯片母版。当添加新幻灯片时，会自动为其应用幻灯片母版，通常继承前一张幻灯片的母版。演示文稿可以包含多个幻灯片母版，用于为不同部分设置独特样式。

**幻灯片母版可以自定义哪些元素？**

幻灯片母版由以下核心属性组成，可进行自定义：

- **Background**：设置幻灯片背景。  
- **BodyStyle**：定义幻灯片正文的文本样式。  
- **Shapes**：管理幻灯片母版上的所有形状，包括占位符和图片框。  
- **Controls**：处理 ActiveX 控件。  
- **ThemeManager**：访问主题管理器。  
- **HeaderFooterManager**：管理页眉页脚。

**如何向幻灯片母版添加图片？**

向幻灯片母版添加图片后，所有依赖该母版的幻灯片都会显示该图片。例如，将公司徽标放置在幻灯片母版上，即可在演示文稿的每张幻灯片中看到该徽标。

**幻灯片母版与幻灯片布局的关系是什么？**

幻灯片布局与幻灯片母版协同工作，提供灵活的幻灯片设计。幻灯片母版定义全局样式和主题，幻灯片布局则允许在内容安排上进行变化。层级关系如下：

- **幻灯片母版** → 定义全局样式。  
- **幻灯片布局** → 提供不同的内容排列方式。  
- **幻灯片** → 从其对应的幻灯片布局继承设计。

**一个演示文稿可以有多个幻灯片母版吗？**

可以，一个演示文稿可以包含多个幻灯片母版，这使您能够以不同方式对演示文稿的不同章节进行样式设置，提供更大的设计灵活性。

**如何使用 Aspose.Slides 访问和修改幻灯片母版？**

在 Aspose.Slides 中，幻灯片母版由 [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/) 接口表示。您可以通过 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 对象的 [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) 方法访问幻灯片母版。