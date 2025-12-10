---
title: Manage Presentation Notes in C++
linktitle: Presentation Notes
type: docs
weight: 110
url: /cpp/presentation-notes/
keywords:
- notes
- notes slide
- add notes
- remove notes
- notes style
- master notes
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Customize presentation notes with Aspose.Slides for C++. Seamlessly work with PowerPoint and OpenDocument notes to boost your productivity."
---


## **Add and Remove Slide Notes**
Aspose.Slides now supports removing notes slides from presentation. In this topic, we will introduce this new feature of removing Notes also adding notes style slides from any presentation. Aspose.Slides for C++ provides the feature of removing notes of any slide as well as add style to existing notes. Developers can remove notes in following ways:

- Removing Notes of a Specific Slide of a presentation.
- Removing Notes of All Slides of a Presentation.

## **Remove Notes from a Specific Slide**
Notes of some specific slide could be removed as shown in example below:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Remove Notes from All Slides**
Notes of all the slides of a presentation could be removed as shown in example below:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Add a Notes Style**
NotesStyle property has been added to IMasterNotesSlide interface and MasterNotesSlide class respectively. This property specifies the style of a notes text.  The implementation is demonstrated in the example below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

Notes are accessed through the slide’s notes manager: the slide has a [NotesSlideManager](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/) and a [method](https://reference.aspose.com/slides/cpp/aspose.slides/notesslidemanager/get_notesslide/) that returns the notes object, or `null` if there are no notes.

**Are there differences in notes support across the PowerPoint versions the library works with?**

The library targets a broad range of Microsoft PowerPoint formats (97–newer) and ODP; notes are supported within these formats without depending on an installed copy of PowerPoint.
