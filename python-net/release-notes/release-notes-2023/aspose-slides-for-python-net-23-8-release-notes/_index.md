---
title: Aspose.Slides for Python 23.8 Release Notes
type: docs
weight: 40
url: /python-net/aspose-slides-for-python-net-23-8-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for [Aspose.Slides for Python via .NET 23.8](https://pypi.org/project/Aspose.Slides/23.8/)

{{% /alert %}} 

|**Key**|**Summary**|**Category**|**Related Documentation**|
| :- | :- | :- | :- |
|SLIDESPYNET-115|[Use Aspose.Slides for Net 23.8 features](/slides/net/aspose-slides-for-net-23-8-release-notes/)|Enhancement| |


## Public API Changes ##

## Markdown export - Flavor, MarkdownExportType, NewLineType and MarkdownSaveOptions moved to Aspose.Slides.Export namespace ##

The classes and enums related to markdown export have been moved from namespace 'aspose.slides.dom.export.markdown' to 'aspose.slides.export'.

The following classes and enums have been moved:
- MarkdownSaveOptions
- NewLineType
- MarkdownExportType
- Flavor

## show_media_controls property has been added for SlideShowSettings ##

The show_media_controls property was added for the SlideShowSettings class, which Represents the slide show settings for the presentation.

Example:

```py
from aspose.slides import Presentation

with Presentation() as pres: 
    pres.slide_show_settings.show_media_controls = True
