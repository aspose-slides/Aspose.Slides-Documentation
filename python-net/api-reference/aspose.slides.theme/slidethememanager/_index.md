---
title: SlideThemeManager Class
type: docs
weight: 440
url: /python-net/api-reference/aspose.slides.theme/slidethememanager/
---

Provides access to slide theme overriden.

**Namespace:** [aspose.slides.theme](/slides/python-net/api-reference/aspose.slides.theme/)

**Full Class Name:** aspose.slides.theme.SlideThemeManager

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The SlideThemeManager type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|override_theme|Returns the overriding theme object.<br/>            Read/write [IOverrideTheme](/python-net/api-reference/aspose.slides.theme/ioverridetheme/).|
|is_override_theme_enabled|Determines whether OverrideTheme overrides inherited effective theme or not.<br/>            To enable OverrideTheme for overriding use OverrideTheme.Init*() methods.<br/>            To disable OverrideTheme from overriding use OverrideTheme.Clear() method.<br/>            Read-only bool.|
|as_itheme_manager|Allows to get base IThemeManager interface.<br/>            Read-only [IThemeManager](/python-net/api-reference/aspose.slides.theme/ithememanager/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|create_theme_effective()|Returns the theme object.|
|apply_color_scheme(scheme)|Applies extra color scheme to a slide.|