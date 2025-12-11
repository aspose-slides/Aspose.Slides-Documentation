---
title: 在 C++ 中管理演示文稿页眉和页脚
linktitle: 页眉和页脚
type: docs
weight: 140
url: /zh/cpp/presentation-header-and-footer/
keywords:
- 页眉
- 页眉文本
- 页脚
- 页脚文本
- 设置页眉
- 设置页脚
- 讲义
- 备注
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 为 PowerPoint 和 OpenDocument 演示文稿添加并自定义页眉和页脚，以获得专业外观。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/zh/cpp/) 提供对幻灯片页眉和页脚文本的支持，这些文本实际上在幻灯片母版级别维护。

{{% /alert %}} 

[Aspose.Slides for C++](/slides/zh/cpp/) 提供在演示文稿幻灯片中管理页眉和页脚的功能。这些实际上在演示文稿母版级别进行管理。
## **管理页眉和页脚文本**
可以按下面示例更新特定幻灯片的备注：
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
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// 加载演示文稿
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// 设置页脚
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
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


## **在讲义和备注幻灯片上管理页眉和页脚**
Aspose.Slides for C++ 支持在讲义和备注幻灯片中的页眉和页脚。请遵循以下步骤：

- 加载包含视频的[演示文稿](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)。
- 更改备注母版和所有备注幻灯片的页眉和页脚设置。
- 设置主备注幻灯片以及所有子页脚占位符可见。
- 设置主备注幻灯片以及所有子日期和时间占位符可见。
- 仅更改第一张备注幻灯片的页眉和页脚设置。
- 设置备注幻灯片的页眉占位符可见。
- 为备注幻灯片的页眉占位符设置文本。
- 为备注幻灯片的日期时间占位符设置文本。
- 保存修改后的演示文稿文件。

下面示例中提供了代码片段。
``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// 更改备注母版以及所有备注幻灯片的页眉和页脚设置
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    // 使主备注幻灯片及所有子页脚占位符可见
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
    // 使主备注幻灯片及所有子页眉占位符可见
    headerFooterManager->SetFooterAndChildFootersVisibility(true);
    // 使主备注幻灯片及所有子幻灯片编号占位符可见
    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
    // 使主备注幻灯片及所有子日期和时间占位符可见
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    // 为主备注幻灯片及所有子页眉占位符设置文本
    headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
    // 为主备注幻灯片及所有子页脚占位符设置文本
    headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
    // 为主备注幻灯片及所有子日期和时间占位符设置文本
    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// 仅更改第一张备注幻灯片的页眉和页脚设置
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
    auto headerFooterManager = notesSlide->get_HeaderFooterManager();
    if (!headerFooterManager->get_IsHeaderVisible())
    {
        // 使此备注幻灯片的页眉占位符可见
        headerFooterManager->SetHeaderVisibility(true);
    }

    if (!headerFooterManager->get_IsFooterVisible())
    {
        // 使此备注幻灯片的页脚占位符可见
        headerFooterManager->SetFooterVisibility(true);
    }

    if (!headerFooterManager->get_IsSlideNumberVisible())
    {
        // 使此备注幻灯片的幻灯片编号占位符可见
        headerFooterManager->SetSlideNumberVisibility(true);
    }
    
    if (!headerFooterManager->get_IsDateTimeVisible())
    {
        // 使此备注幻灯片的日期时间占位符可见
        headerFooterManager->SetDateTimeVisibility(true);
    }
    
    // 为备注幻灯片的页眉占位符设置文本
    headerFooterManager->SetHeaderText(u"New header text");
    // 为备注幻灯片的页脚占位符设置文本
    headerFooterManager->SetFooterText(u"New footer text");
    // 为备注幻片的日期时间占位符设置文本
    headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```


## **常见问题**

**我可以在普通幻灯片上添加“页眉”吗？**

在 PowerPoint 中，“页眉”仅在备注和讲义中存在；在普通幻灯片上，支持的元素是页脚、日期/时间和幻灯片编号。在 Aspose.Slides 中也遵循相同的限制：页眉仅用于备注/讲义，幻灯片上则是页脚/日期时间/幻灯片编号。

**如果布局不包含页脚区域——我可以“打开”其可见性吗？**

可以。通过页眉/页脚管理器检查可见性，并在需要时启用它。这些 API 指标和方法专为占位符缺失或隐藏的情况设计。

**如何让幻灯片编号从除 1 之外的值开始？**

设置演示文稿的[first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/)；之后所有编号会重新计算。例如，可以从 0 或 10 开始，并在标题幻灯片上隐藏编号。

**导出为 PDF/图像/HTML 时页眉/页脚会怎样？**

它们会作为演示文稿的普通文本元素进行渲染。即，如果这些元素在幻灯片/备注页面上可见，它们也会出现在输出格式中，与其他内容一起。