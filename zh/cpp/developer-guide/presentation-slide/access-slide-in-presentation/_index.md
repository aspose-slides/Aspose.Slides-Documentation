---
title: 在 C++ 中访问演示文稿幻灯片
linktitle: 访问幻灯片
type: docs
weight: 20
url: /zh/cpp/access-slide-in-presentation/
keywords:
- 访问幻灯片
- 幻灯片索引
- 幻灯片 ID
- 幻灯片位置
- 更改位置
- 幻灯片属性
- 幻灯片编号
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 访问和管理 PowerPoint 与 OpenDocument 演示文稿中的幻灯片。通过代码示例提升生产力。"
---

Aspose.Slides 允许您以两种方式访问幻灯片：按索引和按 ID。

## **按索引访问幻灯片**

演示文稿中的所有幻灯片都按幻灯片位置的数字顺序排列，从 0 开始。第一张幻灯片可通过索引 0 访问；第二张幻灯片可通过索引 1 访问；依此类推。

Presentation 类表示演示文稿文件，提供所有幻灯片作为 [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) 集合（[ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) 对象的集合）。下面的 C++ 代码演示了如何通过索引访问幻灯片：
```c++
	// 文档目录的路径。
	const String templatePath = u"../templates/AddSlides.pptx";

	// 实例化 Presentation 类
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 通过索引获取幻灯片的引用
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```


## **按 ID 访问幻灯片**

演示文稿中的每张幻灯片都有唯一的 ID 与之关联。您可以使用 [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) 方法（由 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类公开）来定位该 ID。下面的 C++ 代码演示了如何提供有效的幻灯片 ID 并通过 [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) 方法访问该幻灯片：
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

Aspose.Slides 允许您更改幻灯片的位置。例如，您可以指定将第一张幻灯片变为第二张幻灯片。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取要更改位置的幻灯片引用。  
1. 通过 [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/) 属性为幻灯片设置新位置。  
1. 保存修改后的演示文稿。  

下面的 C++ 代码演示了将位置 1 的幻灯片移动到位置 2 的操作：
```c++
	// 文档目录的路径。
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// 实例化 Presentation 类
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 获取将要更改位置的幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 为幻灯片设置新的位置
	slide->set_SlideNumber(2);

	// 保存修改后的演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```



第一张幻灯片变成了第二张，第二张幻灯片变成了第一张。更改幻灯片位置时，其他幻灯片会自动调整。

## **设置幻灯片编号**

使用 [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) 属性（由 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类公开），您可以为演示文稿中的第一张幻灯片指定新的编号。此操作会重新计算其他幻灯片的编号。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
1. 获取幻灯片编号。  
1. 设置幻灯片编号。  
1. 保存修改后的演示文稿。  

下面的 C++ 代码演示了将第一张幻灯片的编号设置为 10 的操作：
```c++
	// 文档目录的路径。
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//实例化 Presentation 类
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 获取幻灯片编号
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// 设置幻灯片编号
	pres->set_FirstSlideNumber(2);
	
	// 保存修改后的演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


如果您想跳过第一张幻灯片，可以从第二张幻灯片开始编号（并隐藏第一张幻灯片的编号），方式如下：
```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// 设置首张演示文稿幻灯片的编号
presentation->set_FirstSlideNumber(0);

// 显示所有幻灯片的幻灯片编号
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// 隐藏首张幻灯片的幻灯片编号
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// 保存修改后的演示文稿
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **常见问题**

**用户看到的幻灯片编号是否与集合的零基索引匹配？**

幻灯片上显示的编号可以从任意值开始（例如 10），并不一定要与索引匹配；两者的关系由演示文稿的 [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) 设置控制。

**隐藏的幻灯片会影响索引吗？**

会。隐藏的幻灯片仍然保留在集合中，并计入索引；“隐藏”指的是显示状态，而不是在集合中的位置。

**当添加或删除其他幻灯片时，幻灯片的索引会改变吗？**

会。索引始终反映当前的幻灯片顺序，并在插入、删除和移动操作后重新计算。