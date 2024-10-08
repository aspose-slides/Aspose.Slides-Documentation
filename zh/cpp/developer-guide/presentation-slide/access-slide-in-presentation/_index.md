---
title: 访问演示文稿中的幻灯片
type: docs
weight: 20
url: /zh/cpp/access-slide-in-presentation/
keywords: "访问 PowerPoint 演示文稿, 访问幻灯片, 编辑幻灯片属性, 更改幻灯片位置, 设置幻灯片编号, 索引, ID, 位置 C++, CPP, Aspose.Slides"
description: "通过索引、ID 或位置访问 PowerPoint 幻灯片。编辑幻灯片属性"
---

Aspose.Slides 允许您通过两种方式访问幻灯片：按索引和按 ID。

## **通过索引访问幻灯片**

演示文稿中的所有幻灯片按幻灯片位置从 0 开始按数字排列。第一张幻灯片通过索引 0 访问；第二张幻灯片通过索引 1 访问；依此类推。

表示演示文稿文件的 Presentation 类将所有幻灯片作为 [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) 集合（[ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) 对象的集合）公开。以下 C++ 代码演示如何通过索引访问幻灯片：

```c++
	// 文档目录的路径。
	const String templatePath = u"../templates/AddSlides.pptx";

	// 实例化 Presentation 类
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 通过索引获取幻灯片的引用
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **通过 ID 访问幻灯片**

演示文稿中的每张幻灯片都有一个唯一的 ID 与之关联。您可以使用 [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) 方法（由 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类公开）来定位该 ID。以下 C++ 代码演示如何提供一个有效的幻灯片 ID 并通过 [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) 方法访问该幻灯片：

```c++
	// 文档目录的路径。
	const String templatePath = u"../templates/AddSlides.pptx";

	// 实例化 Presentation 类
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 获取幻灯片 ID
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// 通过 ID 访问幻灯片
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **更改幻灯片位置**

Aspose.Slides 允许您更改幻灯片位置。例如，您可以指定第一张幻灯片应变为第二张幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 通过索引获取要更改其位置的幻灯片的引用
1. 通过 [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/) 属性设置幻灯片的新位置。
1. 保存修改后的演示文稿。

以下 C++ 代码演示了将位置 1 的幻灯片移动到位置 2 的操作：

```c++
	// 文档目录的路径。
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// 实例化 Presentation 类
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 获取将要更改位置的幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 设置幻灯片的新位置
	slide->set_SlideNumber(2);

	// 保存修改后的演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

第一张幻灯片变成了第二张；第二张幻灯片变成了第一张。当您更改幻灯片的位置时，其他幻灯片会自动调整。

## **设置幻灯片编号**

使用 [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) 属性（由 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类公开），您可以为演示文稿中的第一张幻灯片指定一个新编号。此操作会导致其他幻灯片编号被重新计算。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 获取幻灯片编号。
1. 设置幻灯片编号。
1. 保存修改后的演示文稿。

以下 C++ 代码演示了将第一张幻灯片编号设置为 10 的操作：

```c++
	// 文档目录的路径。
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	// 实例化 Presentation 类
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 获取幻灯片编号
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// 设置幻灯片编号
	pres->set_FirstSlideNumber(2);
	
	// 保存修改后的演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

如果您希望跳过第一张幻灯片，您可以从第二张幻灯片开始编号（并隐藏第一张幻灯片的编号）：

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// 设置第一张演示文稿幻灯片的编号
presentation->set_FirstSlideNumber(0);

// 显示所有幻灯片的编号
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// 隐藏第一张幻灯片的编号
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// 保存修改后的演示文稿
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```