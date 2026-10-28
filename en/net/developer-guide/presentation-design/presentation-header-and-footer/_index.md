---
title: Manage Presentation Headers and Footers in .NET
linktitle: Header and Footer
type: docs
weight: 140
url: /net/presentation-header-and-footer/
keywords:
- header
- header text
- footer
- footer text
- set header
- set footer
- handout
- notes
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to manage footer, date-time, slide-number, and header placeholders on slides, notes pages, and handouts with Aspose.Slides for .NET."
---

## **Overview**

PowerPoint uses different header and footer placeholders depending on the page type. Aspose.Slides for .NET lets you control the text and visibility of these placeholders through header/footer manager interfaces.

The available placeholders depend on the scope:

| Scope | Header | Footer | Date/time | Slide/page number |
|---|---|---|---|---|
| Regular slide | No | Yes | Yes | Yes |
| Notes master | Yes | Yes | Yes | Yes |
| Notes slide | Yes | Yes | Yes | Yes |
| Handout master | Yes | Yes | Yes | Yes |

A regular presentation slide does not have a header placeholder. Headers are available on notes pages and handouts. For regular slides, use footer, date/time, and slide-number placeholders instead.

The scope of a change depends on the manager you use. The [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/islideheaderfootermanager/) interface controls one regular slide. The [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/inotesslideheaderfootermanager/) interface controls one notes slide. Master and layout managers can also propagate settings to dependent slides, while the [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/imasterhandoutslideheaderfootermanager/) interface controls the handout master.

## **Update Header, Footer, and Date/Time Text Across a Presentation**

Use [Presentation.HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/headerfootermanager/), which implements [IPresentationHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ipresentationheaderfootermanager/), to apply consistent text across a presentation without updating each page or master individually.

| Method | Affected objects |
|---|---|
| [SetAllHeadersText](https://reference.aspose.com/slides/net/aspose.slides/presentationheaderfootermanager/setallheaderstext/) | Existing notes pages, notes master, and handout master |
| [SetAllFootersText](https://reference.aspose.com/slides/net/aspose.slides/presentationheaderfootermanager/setallfooterstext/) | Regular slides, layouts, slide masters, existing notes pages, notes master, and handout master |
| [SetAllDateTimesText](https://reference.aspose.com/slides/net/aspose.slides/presentationheaderfootermanager/setalldatetimestext/) | Regular slides, layouts, slide masters, existing notes pages, notes master, and handout master |

Headers apply only to notes pages and handouts; regular slides do not support header placeholders. Handout settings are updated through the handout master.

Setting text does not make a placeholder visible. First use [SetAllHeadersVisibility](https://reference.aspose.com/slides/net/aspose.slides/presentationheaderfootermanager/setallheadersvisibility/), [SetAllFootersVisibility](https://reference.aspose.com/slides/net/aspose.slides/presentationheaderfootermanager/setallfootersvisibility/), and [SetAllDateTimesVisibility](https://reference.aspose.com/slides/net/aspose.slides/presentationheaderfootermanager/setalldatetimesvisibility/) to enable the corresponding placeholders, then set their text. These visibility methods have the same scope as the corresponding text methods.

The following example assumes that a presentation contains regular slides, notes pages, a notes master, and a handout master. It applies corporate text and a fixed date label, then saves the result.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var manager = presentation.HeaderFooterManager;

manager.SetAllHeadersVisibility(true);
manager.SetAllFootersVisibility(true);
manager.SetAllDateTimesVisibility(true);

manager.SetAllHeadersText("Contoso");
manager.SetAllFootersText("Internal use only");
manager.SetAllDateTimesText("October 2026");

presentation.Save("updated.pptx", SaveFormat.Pptx);
```

The text methods skip missing placeholders. Enabling visibility first creates the required placeholders on existing pages and masters. Neither the text methods nor the visibility methods create missing notes pages, notes masters, or handout masters. The date/time text is a fixed label, not an automatically updating date/time field.

For narrower changes, see the examples for [regular slides](#set-footer-datetime-and-slide-numbers-on-regular-slides), the [notes master](#set-headers-and-footers-on-the-notes-master), an [individual notes page](#set-headers-and-footers-on-an-individual-notes-slide), and the [handout master](#set-headers-and-footers-on-the-handout-master). See [Presentation Notes](/slides/net/presentation-notes/) for creating and managing notes pages.

## **Set Footer, Date/Time, and Slide Numbers on Regular Slides**

For regular slides, the basic workflow is to access each slide's header/footer manager, set the footer and date/time text, enable the required placeholders, and save the presentation. Slide numbers are generated by the presentation, so you only need to control their visibility.

Use [`SetFooterText`](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) and [`SetDateTimeText`](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) to set text, and use [`SetFooterVisibility`](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), and [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) to show the corresponding placeholders.

The following end-to-end example applies the same footer, date/time text, and slide-number visibility to all regular slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

If you need to update only one slide, access that slide directly through the [`Slides`](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection instead of iterating through the entire collection.

## **Set Headers and Footers on the Notes Master**

The notes master defines common formatting and placeholder behavior for notes pages. Use the [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslideheaderfootermanager/) interface when you want to change only the notes master itself.

The following example sets header, footer, and date/time text on the notes master and makes all supported placeholders visible on that master:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

The [`MasterNotesSlide`](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslidemanager/masternotesslide/) property returns `null` when the presentation does not contain a notes master.

## **Apply Notes Master Settings to Child Notes Slides**

A notes master can apply header and footer settings to itself and to all dependent notes slides. Use the dedicated propagation methods on [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslideheaderfootermanager/) when the same settings should be applied across the notes hierarchy.

For example, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) and [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) update the notes master header and all child headers. Equivalent methods are available for footers, date/time, and slide numbers.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

The propagation methods used above are [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), and [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Set Headers and Footers on an Individual Notes Slide**

A notes slide belongs to a specific regular slide. Use its [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/inotesslideheaderfootermanager/) interface when you want to customize only that notes page.

The [`AddNotesSlide`](https://reference.aspose.com/slides/net/aspose.slides/inotesslidemanager/addnotesslide/) method returns the notes slide for the current slide and creates one if it does not already exist. The following example configures the notes page associated with the first presentation slide:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

If you first propagate settings from the notes master and then change an individual notes slide, the later per-slide settings let you customize that notes page independently.

## **Set Headers and Footers on the Handout Master**

Handout pages use the handout master for their header, footer, date/time, and page-number placeholders. Unlike notes pages, handout settings are managed through the handout master rather than through individual handout slides.

Use the [`MasterHandoutSlide`](https://reference.aspose.com/slides/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) property to access the handout master. If it is not present, call [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) to create the default handout master.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Understand Scope and Inheritance**

Choose the header/footer manager that matches the scope you want to change:

- [IPresentationHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ipresentationheaderfootermanager/) updates supported placeholders throughout the presentation, as shown in the [presentation-wide example](#update-header-footer-and-datetime-text-across-a-presentation).
- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/islideheaderfootermanager/) changes footer, date/time, and slide-number settings for one regular slide.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslideheaderfootermanager/) controls a layout slide and can propagate supported settings to dependent slides.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/imasterslideheaderfootermanager/) controls a regular slide master and can propagate supported settings to dependent slides.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslideheaderfootermanager/) controls the notes master and can propagate settings to all dependent notes slides.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/inotesslideheaderfootermanager/) changes one notes slide and supports a header placeholder in addition to footer, date/time, and slide number.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/net/aspose.slides/imasterhandoutslideheaderfootermanager/) changes the handout master and supports all four placeholder types.

Use propagation from a master or layout when the same setting should apply throughout its hierarchy. Use an individual slide or notes-slide manager when you need a local setting for one page.

## **FAQ**

**Can I add a header to a regular slide?**

No. PowerPoint does not define a header placeholder for regular slides. On regular slides, use the footer, date/time, and slide-number placeholders. Header placeholders are available on notes pages and handouts.

**What if a footer, date/time, or slide-number placeholder is not visible?**

Use the corresponding header/footer manager to check its visibility and enable it when needed. For example, [`IsFooterVisible`](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) reports whether a footer placeholder is present, and [`SetFooterVisibility`](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) changes its visibility.

**How do I start slide numbering from a value other than 1?**

Set the presentation's [`FirstSlideNumber`](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) property. The slide-number placeholders then use the updated numbering sequence.

**What happens to headers and footers when exporting to PDF, images, or HTML?**

Visible header and footer elements are rendered with the rest of the presentation content in the output format. Their appearance depends on the page type being exported and the corresponding placeholder visibility settings.
