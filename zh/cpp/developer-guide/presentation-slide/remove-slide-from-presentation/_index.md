---
title: 在 C++ 中从演示文稿中删除幻灯片
linktitle: 删除幻灯片
type: docs
weight: 30
url: /zh/cpp/remove-slide-from-presentation/
keywords:
- 删除幻灯片
- 删除幻灯片
- 删除未使用的幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，轻松从 PowerPoint 和 OpenDocument 演示文稿中删除幻灯片。获取清晰的代码示例，提升您的工作流。"
---

如果幻灯片（或其内容）变得多余，可以将其删除。Aspose.Slides 提供了 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类，封装了 [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)，它是演示文稿中所有幻灯片的仓库。使用已知的 [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) 对象的指针（引用或索引），可以指定要删除的幻灯片。

## **通过引用删除幻灯片**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
1. 通过 ID 或索引获取要删除的幻灯片的引用。  
1. 从演示文稿中删除该引用的幻灯片。  
1. 保存修改后的演示文稿。  

以下 C++ 代码演示了如何通过引用删除幻灯片：  
```c++
	// 文档目录的路径
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// 实例化一个表示演示文稿文件的 Presentation 对象
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 通过幻灯片集合中的索引访问幻灯片
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 通过引用删除幻灯片
	pres->get_Slides()->Remove(slide);

	// 保存修改后的演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **通过索引删除幻灯片**

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
1. 通过索引位置从演示文稿中删除幻灯片。  
1. 保存修改后的演示文稿。  

以下 C++ 代码演示了如何通过索引删除幻灯片：  
```c++
	// 文档目录的路径
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// 实例化一个表示演示文稿文件的 Presentation 对象
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 通过幻灯片索引删除幻灯片
	pres->get_Slides()->RemoveAt(0);

	// 保存修改后的演示文稿
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **删除未使用的布局幻灯片**

Aspose.Slides 提供了来自 [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类的 [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法，允许您删除不需要和未使用的布局幻灯片。以下 C++ 代码演示了如何从 PowerPoint 演示文稿中删除布局幻灯片：  
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **删除未使用的母版幻灯片**

Aspose.Slides 提供了来自 [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) 类的 [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法，允许您删除不需要和未使用的母版幻灯片。以下 C++ 代码演示了如何从 PowerPoint 演示文稿中删除母版幻灯片：  
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **常见问题**

**删除幻灯片后幻灯片索引会怎样？**  
删除后，[collection](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) 会重新索引：每个后续幻灯片左移一个位置，导致之前的索引号失效。如果需要稳定的引用，请使用每个幻灯片的持久 ID，而不是其索引。

**幻灯片的 ID 与索引不同吗？在删除相邻幻灯片时会变化吗？**  
是的。索引表示幻灯片的位置，在添加或删除幻灯片时会变化。幻灯片 ID 是持久标识符，在删除其他幻灯片时不会变化。

**删除幻灯片会如何影响幻灯片分段？**  
如果该幻灯片属于某个节，该节的幻灯片数会减少一个。节的结构保持不变；如果节变为空，您可以[删除或重新组织节](/slides/zh/cpp/slide-section/)。

**删除幻灯片时，附加的备注和评论会怎样？**  
[Notes](/slides/zh/cpp/presentation-notes/) 和 [comments](/slides/zh/cpp/presentation-comments/) 与该幻灯片绑定，删除幻灯片时一起被删除。其他幻灯片的内容不受影响。

**删除幻灯片与清理未使用的布局/母版有什么区别？**  
删除会从演示文稿中移除特定的普通幻灯片。清理未使用的布局/母版会删除没有任何引用的布局或母版幻灯片，从而减小文件大小且不更改剩余幻灯片的内容。这两种操作相辅相成：通常先删除，然后再清理。