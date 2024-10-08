---
title: 幻灯片布局
type: docs
weight: 60
url: /cpp/slide-layout/
keyword: "设置幻灯片大小，设置幻灯片选项，指定幻灯片大小，页脚可见性，子页脚，内容缩放，页面大小，C++，CPP，Aspose.Slides"
description: "在C++中设置PowerPoint幻灯片的大小和选项"
---

幻灯片布局包含了所有出现在幻灯片上的内容的占位符框和格式信息。布局决定了可用内容占位符及其位置。

幻灯片布局使您能够快速创建和设计演示文稿（无论是简单还是复杂）。以下是PowerPoint演示文稿中使用的一些最流行的幻灯片布局：

* **标题幻灯片布局**。此布局由两个文本占位符组成。一个占位符用于标题，另一个用于副标题。
* **标题和内容布局**。此布局在顶部包含一个相对较小的占位符用于标题，大的占位符用于核心内容（图表、段落、项目符号列表、编号列表、图像等）。
* **空白布局**。此布局没有占位符，因此允许您从头开始创建元素。

由于幻灯片母版是存储幻灯片布局信息的最高层级幻灯片，您可以使用母版幻灯片访问幻灯片布局并对其进行更改。可以按类型或名称访问布局幻灯片。同样，每个幻灯片都有一个唯一的ID，可以用来访问它。

或者，您可以直接对演示文稿中的特定幻灯片布局进行更改。

* 为了让您能够处理幻灯片布局（包括母版幻灯片中的布局），Aspose.Slides提供了像[get_LayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/)和[get_Masters()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/)的属性，这些属性属于[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类。
* 为了执行相关任务，Aspose.Slides提供了[MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/masterlayoutslidecollection/)、[SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/)、[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/baseslideheaderfootermanager/)以及许多其他类型。

{{% alert title="信息" color="info" %}}

有关特别使用母版幻灯片的更多信息，请参见[幻灯片母版](https://docs.aspose.com/slides/cpp/slide-master/)文章。

{{% /alert %}}

## **将幻灯片布局添加到演示文稿**

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例。
1. 访问[MasterSlide集合](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/)。
1. 浏览现有的布局幻灯片以确认所需的布局幻灯片已存在于布局幻灯片集合中。否则，添加您想要的布局幻灯片。
1. 基于新的布局幻灯片添加一个空幻灯片。
1. 保存演示文稿。

以下C++代码展示了如何将幻灯片布局添加到PowerPoint演示文稿：

```c++
	// 文档目录的路径。
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/AddLayoutSlides.pptx";

	// 实例化一个代表演示文稿文件的Presentation类
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 遍历布局幻灯片类型
	SharedPtr<IMasterLayoutSlideCollection> layoutSlides = pres->get_Masters()->idx_get(0)->get_LayoutSlides();

	SharedPtr<ILayoutSlide> layoutSlide;
	if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
	}
	else if (layoutSlides->GetByType(SlideLayoutType::Title) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
	}

	if (layoutSlide == NULL)
	{
		// 演示文稿不包含某些布局类型的情况。
		// 演示文稿文件仅包含空白和自定义布局类型。
		// 但具有自定义类型的布局幻灯片具有不同的幻灯片名称，
		// 例如：“标题”、“标题和内容”等。可以使用这些
		// 名称进行布局幻灯片选择。
		// 您还可以使用一组占位符形状类型。例如，
		// 标题幻灯片应仅具有标题占位符类型，等等。

		for (int i = 0; i<layoutSlides->get_Count(); i++)
		{
			SharedPtr<ILayoutSlide> titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

			if (titleAndObjectLayoutSlide->get_Name().Equals(u"标题和对象"))
			{
				layoutSlide = titleAndObjectLayoutSlide;
				break;
			}
		}

		if (layoutSlide == NULL)
		{
			for (int i = 0; i < layoutSlides->get_Count(); i++)
			{
				SharedPtr<ILayoutSlide> titleLayoutSlide = layoutSlides->idx_get(i);

				if (titleLayoutSlide->get_Name().Equals(u"标题"))
				{
					layoutSlide = titleLayoutSlide;
					break;
				}
			}

			if (layoutSlide == NULL)
			{
				layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
				if (layoutSlide == NULL)
				{
					layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"标题和对象");
				}
			}
		}
	}

	// 添加带有新增布局幻灯片的空幻灯片  
	pres->get_Slides()->InsertEmptySlide(0, layoutSlide);

	// 将演示文稿保存到磁盘
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **删除未使用的布局幻灯片**

Aspose.Slides提供了来自[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)类的[RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)方法，以允许您删除不需要和未使用的布局幻灯片。以下C++代码展示了如何从PowerPoint演示文稿中删除布局幻灯片：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);

```

## **为幻灯片布局设置大小和类型**

为了让您能够为特定布局幻灯片设置大小和类型，Aspose.Slides提供了[get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/)和[get_Size()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_size/)属性（来自[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类）。以下C++代码演示了此操作：

```c++
	// 文档目录的路径。
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/CloneToAnotherPresentationWithSetSizeAndType.pptx";
	// 实例化一个代表演示文稿文件的Presentation对象
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	SharedPtr<Presentation> destPres = MakeObject<Presentation>();

	// 从集合中按ID访问幻灯片
	SharedPtr<ISlideCollection> slideCollection = destPres->get_Slides();
	
	// 设置生成的演示文稿的幻灯片大小与源相同
	destPres->get_SlideSize()->SetSize(pres->get_SlideSize()->get_Type(), Aspose::Slides::SlideSizeScaleType::DoNotScale);

	slideCollection->InsertClone(1, pres->get_Slides()->idx_get(0));

	// 将演示文稿保存到磁盘
	destPres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **在幻灯片内设置页脚可见性**

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例。
1. 通过索引获取幻灯片的引用。
1. 将幻灯片页脚占位符设置为可见。
1. 将日期时间占位符设置为可见。
1. 保存演示文稿。

以下C++代码展示了如何设置幻灯片页脚的可见性（并执行相关任务）：

```c++
 // 文档目录的路径。
const String outPath = u"../out/HeaderFooterManager_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// 实例化一个SlideCollection类
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

//	SharedPtr<IBaseSlideHeaderFooterManager> headerFooterManager = presentation->get_Slides()->idx_get(0)->get_HeaderFooterManager();
SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
if (!headerFooterManager->get_IsFooterVisible()) // 属性IsFooterVisible用于指示幻灯片页脚占位符缺失
{
	headerFooterManager->SetFooterVisibility(true); // 方法SetFooterVisibility用于将幻灯片页脚占位符设置为可见
}
if (!headerFooterManager->get_IsSlideNumberVisible()) // 属性IsSlideNumberVisible用于指示幻灯片页码占位符缺失
{
	headerFooterManager->SetSlideNumberVisibility(true); // 方法SetSlideNumberVisibility用于将幻灯片页码占位符设置为可见
}
if (!headerFooterManager->get_IsDateTimeVisible()) // 属性IsDateTimeVisible用于指示幻灯片日期时间占位符缺失
{
	headerFooterManager->SetDateTimeVisibility(true); // 方法SetFooterVisibility用于将幻灯片日期时间占位符设置为可见
}
headerFooterManager->SetFooterText(u"页脚文本"); // 方法SetFooterText用于设置幻灯片页脚占位符的文本
headerFooterManager->SetDateTimeText(u"日期和时间文本"); // 方法SetDateTimeText用于设置幻灯片日期时间占位符的文本。

// 将演示文稿保存到磁盘
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **在幻灯片内设置子页脚可见性**

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例。
1. 通过索引获取母版幻灯片的引用。
1. 将母版幻灯片和所有子页脚占位符设置为可见。
1. 为母版幻灯片和所有子页脚占位符设置文本。
1. 为母版幻灯片和所有子日期时间占位符设置文本。
1. 保存演示文稿。

以下C++代码演示了此操作：

```c++
// 文档目录的路径。
const String outPath = u"../out/SetChildFooter_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// 实例化一个SlideCollection类
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true); // 方法SetFooterAndChildFootersVisibility用于将母版幻灯片和所有子页脚占位符设置为可见
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true); // 方法SetSlideNumberAndChildSlideNumbersVisibility用于将母版幻灯片和所有子页码占位符设置为可见
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true); // 方法SetDateTimeAndChildDateTimesVisibility用于将母版幻灯片和所有子日期时间占位符设置为可见

headerFooterManager->SetFooterAndChildFootersText(u"页脚文本"); // 方法SetFooterAndChildFootersText用于设置母版幻灯片和所有子页脚占位符的文本
headerFooterManager->SetDateTimeAndChildDateTimesText(u"日期和时间文本"); // 方法SetDateTimeAndChildDateTimesText用于设置母版幻灯片和所有子日期时间占位符的文本

presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **根据内容缩放设置幻灯片大小**

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例，并加载包含要设置大小的幻灯片的演示文稿。
1. 创建另一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例以生成新的演示文稿。
1. 通过索引从第一个演示文稿中获取幻灯片的引用。
1. 将幻灯片页脚占位符设置为可见。
1. 将日期时间占位符设置为可见。
1. 保存演示文稿。

以下C++代码演示了此操作：

```c++
// 文档目录的路径。
const String templatePath = u"../templates/AccessSlides.pptx";
const String outPath = u"../out/SetSlideSizeScale_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);
SharedPtr<Presentation> auxPresentation = MakeObject<Presentation>();

// 实例化一个SlideCollection类
SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

// 设置生成的演示文稿的幻灯片大小与源相同
auxPresentation->get_SlideSize()->SetSize(540, 720, SlideSizeScaleType::EnsureFit); // 方法SetSize用于设置幻灯片大小，缩放内容以确保适合
auxPresentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize); // 方法SetSize用于设置幻灯片大小，最大化内容大小

auxPresentation->get_Slides()->InsertClone(0, slide);
auxPresentation->get_Slides()->RemoveAt(0);

// 保存演示文稿
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **在生成PDF时设置页面大小**

某些演示文稿（如海报）通常会转换为PDF文档。如果您希望将PowerPoint转换为PDF，以获取最佳打印和可访问性选项，则希望将幻灯片设置为适合PDF文档的尺寸（例如A4）。

Aspose.Slides提供了[SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/)类，以允许您指定幻灯片的首选设置。以下C++代码展示了如何使用[get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/)属性（来自`SlideSize`类）为演示文稿中的幻灯片设置特定纸张大小：

```c++
// 文档目录的路径。
	const String outPath = u"../out/SetPDFPageSize_out.pptx";

	// 实例化一个代表演示文稿文件的Presentation对象 
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 设置SlideSize.Type属性
	pres->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);

	// 设置PDF选项的不同属性
	Aspose::Slides::Export::PdfOptions opts = Aspose::Slides::Export::PdfOptions();
	opts.set_SufficientResolution (600);

	// 保存演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pdf, &opts);
```