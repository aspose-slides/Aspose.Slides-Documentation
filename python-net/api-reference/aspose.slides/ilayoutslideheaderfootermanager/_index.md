---
title: ILayoutSlideHeaderFooterManager Class
type: docs
weight: 1710
url: /slides/python-net/api-reference/aspose.slides/ilayoutslideheaderfootermanager/
---

Represents manager which holds behavior of the layout slide footer, date-time, page number placeholders and all child placeholders.<br/>            Child placeholders mean placeholders are contained on depending slides.<br/>            Depending slides use and depend on layout slide.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.ILayoutSlideHeaderFooterManager

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ILayoutSlideHeaderFooterManager type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_ibase_slide_header_footer_manager|Returns IBaseSlideHeaderFooterManager interface.|
|is_footer_visible|Gets value indicating that a footer placeholder is present.<br/>            Read bool.|
|is_slide_number_visible|Gets value indicating that a page number placeholder is present.<br/>            Readbool.|
|is_date_time_visible|Gets value indicating that a date-time placeholder is present.<br/>            Readbool.|
|as_ibase_header_footer_manager|Returns IBaseHeaderFooterManager interface.|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|set_footer_and_child_footers_visibility(is_visible)|Changes layout slide footer placeholder and all child footer placeholders visibility.<br/>            Child placeholders mean placeholders are contained on depending slides.<br/>            Depending slides use and depend on master slide.|
|set_slide_number_and_child_slide_numbers_visibility(is_visible)|Changes layout slide page number placeholder and all child page number placeholders visibility.<br/>            Child placeholders mean placeholders are contained on depending slides.<br/>            Depending slides use and depend on layout slide.|
|set_date_time_and_child_date_times_visibility(is_visible)|Changes layout slide date-time placeholder and all child date-time placeholders visibility.<br/>            Child placeholders mean placeholders are contained on depending slides.<br/>            Depending slides use and depend on layout slide.|
|set_footer_and_child_footers_text(text)|Sets text to layout slide footer placeholder and all child footer placeholders.<br/>            Child placeholders mean placeholders are contained on depending slides.<br/>            Depending slides use and depend on layout slide.|
|set_date_time_and_child_date_times_text(text)|Sets text to layout slide date-time placeholder and all child date-time placeholders.<br/>            Child placeholders mean placeholders are contained on depending slides.<br/>            Depending slides use and depend on layout slide.|
|set_footer_visibility(is_visible)|Changes slide footer placeholder visibility.|
|set_slide_number_visibility(is_visible)|Changes slide page number placeholder visibility.|
|set_date_time_visibility(is_visible)|Changes slide date-time placeholder visibility.|
|set_footer_text(text)|Sets text to slide footer placeholder.|
|set_date_time_text(text)|Sets text to slide date-time placeholder.|
