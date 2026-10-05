---
title: Convert Presentations to HTML5 in C++
linktitle: Presentation to HTML5
type: docs
weight: 40
url: /cpp/export-to-html5/
keywords:
- PowerPoint to HTML5
- OpenDocument to HTML5
- presentation to HTML5
- slide to HTML5
- PPT to HTML5
- PPTX to HTML5
- ODP to HTML5
- save PPT as HTML5
- save PPTX as HTML5
- save ODP as HTML5
- export PPT to HTML5
- export PPTX to HTML5
- export ODP to HTML5
- C++
- Aspose.Slides
description: "Export PowerPoint & OpenDocument presentations to responsive HTML5 with Aspose.Slides for C++. Preserve formatting, animations, and interactivity."
---

## **Overview**

This article explains how to convert PowerPoint presentations to HTML5 using Aspose.Slides for C++. It covers basic export, control of shape animations and slide transitions, and comment layout. It also compares HTML5 output with the SVG-based output of standard HTML export.

## **Export PowerPoint to HTML5**

The following example loads a presentation from the working directory and saves it in HTML5 format. It uses the default export settings; the next example shows how to control animation playback explicitly. Replace the input path with the path to your presentation.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Besides the HTML document, the export writes supporting CSS and JavaScript files for slide styling, animations, effects, and navigation. Keep these files with the HTML document when moving or publishing the output. The generated page also loads jQuery and Anime.js from public CDNs; without them, slide navigation and animations do not run.

{{% /alert %}}

To export without playing shape animations or slide transitions, pass `false` to [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) and [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) in [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). These settings are independent, so you can enable one while disabling the other. The example exports the presentation with both types of animation disabled in the generated page.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Export PowerPoint to HTML**

The standard HTML export uses a different rendering approach: slide content is represented by SVG inside an HTML page. The following example converts a presentation to an HTML document using this rendering approach.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

The simplified markup below illustrates the structure of the generated page. The SVG element contains the rendered slide content; the placeholder text represents that content and is not literal export output.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}

The SVG-based export does not expose PowerPoint shapes as individual HTML elements. Use HTML5 export when you need the shape-animation and slide-transition options demonstrated in this article.

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

HTML5 export produces a page for viewing and navigating the presentation slides in a browser. This example passes `true` to both [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) and [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) so that the exported slide view can play effects from the source presentation.

Use a presentation that already contains shape animations and slide transitions to see the effect of these settings. Enabling them does not add new effects to slides that have none. After export, open the generated HTML5 document in a browser with its supporting files available.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Convert a Presentation to an HTML5 Document with Comments**

You can include existing slide comments in HTML5 output so that readers can see feedback alongside the slide content. The example in this section expects the source presentation to contain comments, as illustrated below. It exports those comments; it does not create new ones.

![Two comments on the presentation slide](two_comments_pptx.png)

Pass a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) object to the [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) method of [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Call [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) with `CommentsPositions::Right` from the [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) enumeration to place the comments to the right of each slide.

The following example exports the presentation to HTML5 with this comment layout. A presentation without comments will have no comment text to display.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

The image below shows the exported HTML5 document with the comments displayed beside the slide.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Exclude JavaScript Hyperlinks During Export**

Suppose `hyperlinks.pptx` contains linked text with a `javascript:alert('Hello')` target and an ordinary `https://example.com/` link. To exclude the JavaScript hyperlink during export, call [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) with `true`. The default is `false`, so these links are not filtered unless you enable the option.

The following example loads the presentation from the working directory and exports it using [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

The exported file omits the JavaScript hyperlink while retaining its text and the ordinary HTTPS link. The source presentation is unchanged.

This option filters JavaScript hyperlinks; it does not remove all scripts or other active content, nor does it guarantee CSP compliance. For example, HTML5 output still includes scripts for slide navigation and animations.

## **FAQ**

**Can I control whether object animations and slide transitions will play in HTML5?**

Yes, HTML5 export provides separate options to enable or disable [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) and [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Are comments supported, and where can they be placed relative to the slide?**

Yes, existing comments can be included in HTML5 output and positioned (for example, to the right of the slide) through [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) for notes and comments.

**Can I skip links that invoke JavaScript for security or CSP reasons?**

Yes, the [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) method allows you to skip hyperlinks with JavaScript calls during saving. The default is `false`. See [Exclude JavaScript Hyperlinks During Export](/slides/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) for an HTML5 export example and the scope of the filter. This setting does not remove the JavaScript used by the HTML5 viewer for navigation and animations.
