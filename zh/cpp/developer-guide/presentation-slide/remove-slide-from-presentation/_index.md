---
title: 从演示文稿中删除幻灯片
type: docs
weight: 30
url: /zh/cpp/remove-slide-from-presentation/
keywords: "删除幻灯片, 删除幻灯片, PowerPoint, 演示文稿, C++, Aspose.Slides"
description: "通过引用或索引在 C++ 中从 PowerPoint 中删除幻灯片"

---

如果某个幻灯片（或其内容）变得多余，您可以将其删除。Aspose.Slides 提供了 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类，该类封装了 [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)，这是演示文稿中所有幻灯片的仓库。通过已知的 [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) 对象的指针（引用或索引），您可以指定要删除的幻灯片。

## **通过引用删除幻灯片**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 通过其 ID 或索引获取要删除的幻灯片的引用。
1. 从演示文稿中删除引用的幻灯片。
1. 保存修改后的演示文稿。

以下 C++ 代码显示了如何通过引用删除幻灯片：

```c++
	// 文档目录的路径
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// 实例化表示演示文稿文件的 Presentation 对象
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 通过在幻灯片集合中的索引访问幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 通过引用删除幻灯片
	pres->get_Slides()->Remove(slide);

	// 保存修改后的演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **通过索引删除幻灯片**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 通过幻灯片的索引位置从演示文稿中删除幻灯片。
1. 保存修改后的演示文稿。

以下 C++ 代码显示了如何通过索引删除幻灯片：

```c++
	// 文档目录的路径
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// 实例化表示演示文稿文件的 Presentation 对象
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 通过幻灯片索引删除幻灯片
	pres->get_Slides()->RemoveAt(0);

	// 保存修改后的演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **删除未使用的布局幻灯片**

Aspose.Slides 提供了 [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法（来自 [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类），允许您删除不需要和未使用的布局幻灯片。以下 C++ 代码显示了如何从 PowerPoint 演示文稿中删除一个布局幻灯片：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **删除未使用的母版幻灯片**

Aspose.Slides 提供了 [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法（来自 [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类），允许您删除不需要和未使用的母版幻灯片。以下 C++ 代码显示了如何从 PowerPoint 演示文稿中删除一个母版幻灯片：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```