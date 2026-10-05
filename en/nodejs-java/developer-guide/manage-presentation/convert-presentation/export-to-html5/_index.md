---
title: Convert Presentations to HTML5 in JavaScript
linktitle: Presentation to HTML5
type: docs
weight: 40
url: /nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Export PowerPoint & OpenDocument presentations to responsive HTML5 with Aspose.Slides for Node.js. Preserve formatting, animations, and interactivity."
---

## **Overview**

This article explains how to convert PowerPoint presentations to HTML5 using Aspose.Slides for Node.js via Java. It covers basic export, control of shape animations and slide transitions, and comment layout. It also compares HTML5 output with the SVG-based output of standard HTML export.

## **Export PowerPoint to HTML5**

The following example loads a presentation from the working directory and saves it in HTML5 format. It uses the default export settings; the next example shows how to control animation playback explicitly. Replace the input path with the path to your presentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Besides the HTML document, the export writes supporting CSS and JavaScript files for slide styling, animations, effects, and navigation. Keep these files with the HTML document when moving or publishing the output. The generated page also loads jQuery and Anime.js from public CDNs; without them, slide navigation and animations do not run.

{{% /alert %}}

To export without playing shape animations or slide transitions, pass `false` to [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) and [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) in [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). These settings are independent, so you can enable one while disabling the other. The example exports the presentation with both types of animation disabled in the generated page.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Export PowerPoint to HTML**

The standard HTML export uses a different rendering approach: slide content is represented by SVG inside an HTML page. The following example converts a presentation to an HTML document using this rendering approach.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
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

HTML5 export produces a page for viewing and navigating the presentation slides in a browser. This example enables both [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) and [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) so that the exported slide view can play effects from the source presentation.

Use a presentation that already contains shape animations and slide transitions to see the effect of these settings. Enabling them does not add new effects to slides that have none. After export, open the generated HTML5 document in a browser with its supporting files available.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Convert a Presentation to an HTML5 Document with Comments**

You can include existing slide comments in HTML5 output so that readers can see feedback alongside the slide content. The example in this section expects the source presentation to contain comments, as illustrated below. It exports those comments; it does not create new ones.

![Two comments on the presentation slide](two_comments_pptx.png)

Pass a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) object to the [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) method of [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Use [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) to select `Right` from the [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) enumeration to place the comments to the right of each slide.

The following example exports the presentation to HTML5 with this comment layout. A presentation without comments will have no comment text to display.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

The image below shows the exported HTML5 document with the comments displayed beside the slide.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Exclude JavaScript Hyperlinks During Export**

Suppose `hyperlinks.pptx` contains linked text with a `javascript:alert('Hello')` target and an ordinary `https://example.com/` link. To exclude the JavaScript hyperlink during export, pass `true` to [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). The default is `false`, so these links are not filtered unless you enable the option.

The following example loads the presentation from the working directory and exports it using [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

The exported file omits the JavaScript hyperlink while retaining its text and the ordinary HTTPS link. The source presentation is unchanged.

This option filters JavaScript hyperlinks; it does not remove all scripts or other active content, nor does it guarantee CSP compliance. For example, HTML5 output still includes scripts for slide navigation and animations.

## **FAQ**

**Can I control whether object animations and slide transitions will play in HTML5?**

Yes, HTML5 export provides separate options to enable or disable [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) and [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Are comments supported, and where can they be placed relative to the slide?**

Yes, existing comments can be included in HTML5 output and positioned (for example, to the right of the slide) through [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) for notes and comments.

**Can I skip links that invoke JavaScript for security or CSP reasons?**

Yes, the [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) setting allows you to skip hyperlinks with JavaScript calls during saving. The default is `false`. See [Exclude JavaScript Hyperlinks During Export](/slides/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) for an HTML5 export example and the scope of the filter. This setting does not remove the JavaScript used by the HTML5 viewer for navigation and animations.
