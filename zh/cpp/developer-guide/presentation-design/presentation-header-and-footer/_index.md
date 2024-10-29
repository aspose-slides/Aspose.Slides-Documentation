---
title: 演示文稿的页眉和页脚
type: docs
weight: 140
url: /zh/cpp/presentation-header-and-footer/
keywords: "PowerPoint中的页眉和页脚"
description: "使用Aspose.Slides在PowerPoint中处理页眉和页脚。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/zh/cpp/) 提供支持，以处理实际上在幻灯片母版级别维护的幻灯片的页眉和页脚文本。

{{% /alert %}} 

[Aspose.Slides for C++](/slides/zh/cpp/) 提供在演示文稿幻灯片中管理页眉和页脚的功能。这实际上是在演示文稿母版级别管理的。
## **管理页眉和页脚文本**
某些特定幻灯片的说明可以如下面示例中所示进行更新：

``` cpp
// 设置页眉/页脚文本的函数
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"嗨，新页眉");
            }
        }
    }
}
```

``` cpp
// 加载演示文稿
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// 设置页脚
pres->get_HeaderFooterManager()->SetAllFootersText(u"我的页脚文本");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// 访问并更新页眉
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// 保存演示文稿
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **管理讲义和备注幻灯片中的页眉和页脚**
Aspose.Slides for C++ 支持讲义和备注幻灯片中的页眉和页脚。请遵循以下步骤：

- 加载一个包含视频的[演示文稿](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)。
- 更改备注母版和所有备注幻灯片的页眉和页脚设置。
- 设置母版备注幻灯片和所有子页脚占位符为可见。
- 设置母版备注幻灯片和所有子日期时间占位符为可见。
- 仅更改第一个备注幻灯片的页眉和页脚设置。
- 设置备注幻灯片的页眉占位符为可见。
- 设置备注幻灯片页眉占位符的文本。
- 设置备注幻灯片日期时间占位符的文本。
- 写入修改后的演示文稿文件。

下面的示例中提供的代码片段。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// 更改备注母版和所有备注幻灯片的页眉和页脚设置
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// 使母版备注幻灯片和所有子页脚占位符可见
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// 使母版备注幻灯片和所有子页眉占位符可见
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// 使母版备注幻灯片和所有子幻灯片编号占位符可见
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// 使母版备注幻灯片和所有子日期时间占位符可见
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// 设置母版备注幻灯片和所有子页眉占位符的文本
	headerFooterManager->SetHeaderAndChildHeadersText(u"页眉文本");
	// 设置母版备注幻灯片和所有子页脚占位符的文本
	headerFooterManager->SetFooterAndChildFootersText(u"页脚文本");
	// 设置母版备注幻灯片和所有子日期时间占位符的文本
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"日期和时间文本");
}

// 仅更改第一个备注幻灯片的页眉和页脚设置
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// 使该备注幻灯片的页眉占位符可见
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// 使该备注幻灯片的页脚占位符可见
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// 使该备注幻灯片的幻灯片编号占位符可见
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// 使该备注幻灯片的日期时间占位符可见
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// 设置备注幻灯片页眉占位符的文本
	headerFooterManager->SetHeaderText(u"新页眉文本");
	// 设置备注幻灯片页脚占位符的文本
	headerFooterManager->SetFooterText(u"新页脚文本");
	// 设置备注幻灯片日期时间占位符的文本
	headerFooterManager->SetDateTimeText(u"新日期和时间文本");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```