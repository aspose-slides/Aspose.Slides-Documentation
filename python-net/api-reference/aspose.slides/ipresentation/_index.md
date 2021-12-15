---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 2220
url: /python-net/api-reference/aspose.slides/ipresentation/
---

Presentation document

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IPresentation

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IPresentation type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|current_date_time|Returns or sets date and time which will substitute content of datetime fields.<br/>            Time of this Presentation object creation by default.<br/>            Read/write datetime.|
|header_footer_manager|Returns HeaderFooter manager of the presentation.<br/>            Read-only [IPresentationHeaderFooterManager](/python-net/api-reference/aspose.slides/ipresentationheaderfootermanager/).|
|protection_manager|Gets manager of the permissions for this presentation. <br/>            Read-only [IProtectionManager](/python-net/api-reference/aspose.slides/iprotectionmanager/).|
|slides|Returns a list of all slides that are defined in the presentation.<br/>            Read-only [ISlideCollection](/python-net/api-reference/aspose.slides/islidecollection/).|
|sections|Returns a list of all slides sections that are defined in the presentation.<br/>            Read-only [ISectionCollection](/python-net/api-reference/aspose.slides/isectioncollection/).|
|slide_size|Returns slide size object.<br/>            Read-only [ISlideSize](/python-net/api-reference/aspose.slides/islidesize/).|
|notes_size|Returns notes slide size object.<br/>            Read-only [INotesSize](/python-net/api-reference/aspose.slides/inotessize/).|
|layout_slides|Returns a list of all layout slides that are defined in the presentation.<br/>            Read-only [IGlobalLayoutSlideCollection](/python-net/api-reference/aspose.slides/igloballayoutslidecollection/).|
|masters|Returns a list of all master slides that are defined in the presentation.<br/>            Read-only [IMasterSlideCollection](/python-net/api-reference/aspose.slides/imasterslidecollection/).|
|master_notes_slide_manager|Returns notes master manager.<br/>            Read-only [IMasterNotesSlideManager](/python-net/api-reference/aspose.slides/imasternotesslidemanager/).|
|master_handout_slide_manager|Returns handout master manager.<br/>            Read-only [IMasterHandoutSlideManager](/python-net/api-reference/aspose.slides/imasterhandoutslidemanager/).|
|fonts_manager|Returns fonts manager.<br/>            Read-only [IFontsManager](/python-net/api-reference/aspose.slides/ifontsmanager/).|
|default_text_style|Returns default text style for shapes.<br/>            Read-only [ITextStyle](/python-net/api-reference/aspose.slides/itextstyle/).|
|comment_authors|Returns the collection of comments autors.<br/>            Read-only [ICommentAuthorCollection](/python-net/api-reference/aspose.slides/icommentauthorcollection/).|
|document_properties|Returns DocumentProperties object which contains standard and custom document properties.<br/>            Read-only [IDocumentProperties](/python-net/api-reference/aspose.slides/idocumentproperties/).|
|images|Returns the collection of all images in the presentation.<br/>            Read-only [IImageCollection](/python-net/api-reference/aspose.slides/iimagecollection/).|
|audios|Returns the collection of all embedded audio files in the presentation.<br/>            Read-only [IAudioCollection](/python-net/api-reference/aspose.slides/iaudiocollection/).|
|videos|Returns the collection of all embedded video files in the presentation.<br/>            Read-only [IVideoCollection](/python-net/api-reference/aspose.slides/ivideocollection/).|
|custom_data|Returns the presentation's custom data.<br/>            Read-only [ICustomData](/python-net/api-reference/aspose.slides/icustomdata/).|
|vba_project|Gets VBA project with presentation macros.<br/>            Read/write [IVbaProject](/python-net/api-reference/aspose.slides.vba/ivbaproject/).|
|source_format|Returns information about from which format presentation was loaded.<br/>            Read-only [source_format](/python-net/api-reference/aspose.slides/ipresentation/).|
|master_theme|Returns master theme of the presentation.<br/>            Read-only [IMasterTheme](/python-net/api-reference/aspose.slides.theme/imastertheme/).|
|hyperlink_queries|Provides easy access to all hyperlinks contained in all presentation slides (not in master, layout, notes slides).<br/>            Read-only [IHyperlinkQueries](/python-net/api-reference/aspose.slides/ihyperlinkqueries/).|
|view_properties|Gets presentation wide view properties.<br/>            Read-only [IViewProperties](/python-net/api-reference/aspose.slides/iviewproperties/).|
|first_slide_number|Represents the first slide number in the presentation.<br/>            Read/write|
|all_custom_xml_parts|Returns all custom data parts in the presentaion.<br/>            Read-only [ICustomXmlPart](/python-net/api-reference/aspose.slides/icustomxmlpart/)[].|
|digital_signatures|Returns the collection of signatures used to sign the presentation.<br/>            Read-only [IDigitalSignatureCollection](/python-net/api-reference/aspose.slides/idigitalsignaturecollection/).|
|as_idisposable|Returns IDisposable interface.<br/>            Read-only disposable.|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|save(fname, format)|Saves all slides of a presentation to a file with the specified format.|
|save(stream, format)|Saves all slides of a presentation to a stream in the specified format.|
|save(fname, format, options)|Saves all slides of a presentation to a file with the specified format and with additional options.|
|save(stream, format, options)|Saves all slides of a presentation to a stream in the specified format and with additional options.|
|save(fname, slides, format)|Saves specified slides of a presentation to a file with the specified format.|
|save(fname, slides, format, options)|Saves specified slides of a presentation to a file with the specified format.|
|save(stream, slides, format)|Saves specified slides of a presentation to a stream in the specified format.|
|save(stream, slides, format, options)|Saves specified slides of a presentation to a stream in the specified format.|
|save(options)|Saves all slides of a presentation to a set of files representing XAML markup.|
|get_thumbnails(notes_comments_layouting)|Returns a Thumbnail Bitmap objects for all slides of a presentation.|
|get_thumbnails(notes_comments_layouting, slides)|Returns a Thumbnail Bitmap objects for specified slides of a presentation.|
|get_thumbnails(notes_comments_layouting, scale_x, scale_y)|Returns a Thumbnail Bitmap objects for all slides of a presentation with custom scaling.|
|get_thumbnails(notes_comments_layouting, slides, scale_x, scale_y)|Returns a Thumbnail Bitmap objects for specified slides of a presentation with custom scaling.|
|get_thumbnails(notes_comments_layouting, image_size)|Returns a Thumbnail Bitmap objects for all slides of a presentation with specified size.|
|get_thumbnails(notes_comments_layouting, slides, image_size)|Returns a Thumbnail Bitmap objects for specified slides of a presentation with specified size.|
|get_thumbnails(options)|Returns a Thumbnail Bitmap objects for all slides of a presentation.|
|get_thumbnails(options, slides)|Returns a Thumbnail Bitmap objects for specified slides of a presentation.|
|get_thumbnails(options, scale_x, scale_y)|Returns a Thumbnail Bitmap objects for all slides of a presentation with custom scaling.|
|get_thumbnails(options, slides, scale_x, scale_y)|Returns a Thumbnail Bitmap objects for specified slides of a presentation with custom scaling.|
|get_thumbnails(options, image_size)|Returns a Thumbnail Bitmap objects for all slides of a presentation with specified size.|
|get_thumbnails(options, slides, image_size)|Returns a Thumbnail Bitmap objects for specified slides of a presentation with specified size.|
|print()|Prints the whole presentation to the default printer.|
|print(printer_settings)|Prints the presentation according to the specified printer settings,<br/>            using the standard (no User Interface) print controller.|
|print(printer_name)|Print the whole presentation to the specified printer,<br/>            using the standard (no User Interface) print controller.|
|print(printer_settings, pres_name)|Prints the document according to the specified printer settings, using<br/>            the standard (no User Interface) print controller and a presentation name.|
|get_slide_by_id(id)|Returns a Slide, MasterSlide or LayoutSlide by Id.|
|join_portions_with_same_formatting()|Joins runs with same formatting in all paragraphs in all acceptable shapes in all slides.|
