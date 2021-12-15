---
title: DocumentProperties Class
type: docs
weight: 440
url: /slides/python-net/api-reference/aspose.slides/documentproperties/
---

Represents properties of a presentation.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.DocumentProperties

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The DocumentProperties type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|DocumentProperties()|Initializes new instance of class [DocumentProperties](/python-net/api-reference/aspose.slides/documentproperties/).|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|app_version|Returns the app version.<br/>            Read-only string.|
|name_of_application|Returns or sets the name of the application.<br/>            Read/write string.|
|company|Returns or sets the company property.<br/>            Read/write string.|
|manager|Returns or sets the manager property.<br/>            Read/write string.|
|presentation_format|Returns or sets the intended format of a presentation.<br/>            Read/write string.|
|shared_doc|Determines whether the presentation is shared between multiple people.<br/>            Read/write bool.|
|application_template|Returns or sets the template of a application.<br/>            Read/write string.|
|total_editing_time|Total editing time of a presentation.<br/>            Read/write datatime.|
|title|Returns or sets the title of a presentation.<br/>            Read/write string.|
|subject|Returns or sets the subject of a presentation.<br/>            Read/write string.|
|author|Returns or sets the author of a presentation.<br/>            Read/write string.|
|keywords|Returns or sets the keywords of a presentation.<br/>            Read/write string.|
|comments|Returns or sets the comments of a presentation.<br/>            Read/write string.|
|category|Returns or sets the category of a presentation.<br/>            Read/write string.|
|created_time|Returns the date when a presentation was created.<br/>            Read/write datetime.|
|last_saved_time|Returns the date when a presentation was modified last time.<br/>            Read-only in case of Presentation.DocumentProperties (because it will be updated internally while IPresentation object saving process). <br/>            Can be changed via DocumentProperties instance returning by method [None](/python-net/api-reference/aspose.slides/ipresentationinfo/)<br/>            Please see the example in|
|last_printed|Returns the date when a presentation was printed last time.<br/>            Read/write datetime.|
|last_saved_by|Returns or sets the name of a last person who modified a presentation.<br/>            Read/write string.|
|revision_number|Returns or sets the presentation revision number.<br/>            Read/write|
|content_status|Returns or sets the content status of a presentation.<br/>            Read/write string.|
|content_type|Returns or sets the content type of a presentation.<br/>            Read/write string.|
|hyperlink_base|Returns or sets the HyperlinkBase document property.<br/>            Read/write string.|
|count_of_custom_properties|Returns the number of custom properties actually contained in a collection.<br/>            Read-only|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_custom_property_value(name, value)|  |
|get_custom_property_value(name, value)|  |
|get_custom_property_value(name, value)|  |
|get_custom_property_value(name, value)|  |
|get_custom_property_value(name, value)|  |
|get_custom_property_value(name, value)|  |
|set_custom_property_value(name, value)|Sets a named boolean custom property.|
|set_custom_property_value(name, value)|Sets a named integer custom property.|
|set_custom_property_value(name, value)|Sets a named DateTime custom property.|
|set_custom_property_value(name, value)|Sets a named boolean custom property.|
|set_custom_property_value(name, value)|Sets a named float custom property.|
|set_custom_property_value(name, value)|Sets a named double custom property.|
|get_custom_property_name(index)|Return a custom property name at the specified index.|
|remove_custom_property(name)|Remove a custom property associated with a specified name.|
|contains_custom_property(name)|Check presents of a custom property with a specified name.|
|clear_custom_properties()|Removes all custom properties.|
|clear_built_in_properties()|Clears and sets default values for all builtIn properties.|
|clone()|Clones current object|
|clone_t()|Clones current object|
