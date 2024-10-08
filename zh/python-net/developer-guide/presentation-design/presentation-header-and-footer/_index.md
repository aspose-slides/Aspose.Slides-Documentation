---
title: 演示文稿页眉和页脚
type: docs
weight: 140
url: /python-net/presentation-header-and-footer/
keywords: "页眉, 页脚, 设置页眉, 设置页脚, 设置页眉和页脚, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "Python 中的 PowerPoint 页眉和页脚"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/python-net/) 提供对幻灯片页眉和页脚文本的支持，实际上这些文本是在幻灯片母版级别维护的。

{{% /alert %}} 

[Aspose.Slides for Python via .NET](/slides/python-net/) 提供在演示幻灯片中管理页眉和页脚的功能。这些实际上是在演示母版级别管理的。
## **管理页眉和页脚文本**
某些特定幻灯片的注释可以如下面的示例所示进行更新：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# 设置页眉/页脚文本的方法
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "你好，新页眉"

# 加载演示文稿
with slides.Presentation("combined_with_master.pptx") as pres:
    # 设置页脚
    pres.header_footer_manager.set_all_footers_text("我的页脚文本")
    pres.header_footer_manager.set_all_footers_visibility(True)

    # 访问并更新页眉
    masterNotesSlide = pres.master_notes_slide_manager.master_notes_slide
    if masterNotesSlide is not None:
        update_header_footer_text(masterNotesSlide)

    # 保存演示文稿
    pres.save("HeaderFooter-out.pptx", slides.export.SaveFormat.PPTX)
```




## **管理讲义和注释幻灯片中的页眉和页脚**
Aspose.Slides for Python via .NET 支持讲义和注释幻灯片中的页眉和页脚。请按照以下步骤进行操作：

- 加载包含视频的 [演示文稿](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)。
- 更改注释母版和所有注释幻灯片的页眉和页脚设置。
- 设置母注释幻灯片和所有子页脚占位符可见。
- 设置母注释幻灯片和所有子日期和时间占位符可见。
- 仅更改第一张注释幻灯片的页眉和页脚设置。
- 设置注释幻灯片页眉占位符可见。
- 为注释幻灯片页眉占位符设置文本。
- 为注释幻灯片日期时间占位符设置文本。
- 写入修改后的演示文稿文件。

下面示例中提供了代码片段。

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("combined_with_master.pptx") as presentation:
	masterNotesSlide = presentation.master_notes_slide_manager.master_notes_slide
	if masterNotesSlide != None:
		headerFooterManager = masterNotesSlide.header_footer_manager

		# 使母注释幻灯片和所有子页脚占位符可见
		headerFooterManager.set_header_and_child_headers_visibility(True) 
		headerFooterManager.set_footer_and_child_footers_visibility(True) 
		headerFooterManager.set_slide_number_and_child_slide_numbers_visibility(True) 
		headerFooterManager.set_date_time_and_child_date_times_visibility(True)

		# 为母注释幻灯片和所有子页眉占位符设置文本
		headerFooterManager.set_header_and_child_headers_text("页眉文本") 
		headerFooterManager.set_footer_and_child_footers_text("页脚文本") 
		headerFooterManager.set_date_time_and_child_date_times_text("日期和时间文本") 

	# 仅更改第一张注释幻灯片的页眉和页脚设置
	notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
	if notesSlide != None:
		headerFooterManager = notesSlide.header_footer_manager

		# 使注释幻灯片页眉占位符可见

		if not headerFooterManager.is_header_visible:
			headerFooterManager.set_header_visibility(True) 

		if not headerFooterManager.is_footer_visible:
			headerFooterManager.set_footer_visibility(True) 

		if not headerFooterManager.is_slide_number_visible:
			headerFooterManager.set_slide_number_visibility(True) 

		if not headerFooterManager.is_date_time_visible:
			headerFooterManager.set_date_time_visibility(True) 

		# 为注释幻灯片页眉占位符设置文本
		headerFooterManager.set_header_text("新页眉文本") 
		headerFooterManager.set_footer_text("新页脚文本") 
		headerFooterManager.set_date_time_text("新的日期和时间文本") 
	presentation.save("testresult.pptx",slides.export.SaveFormat.PPTX)
```