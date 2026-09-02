---
title: Retrieve and Update Presentation Information in C++
linktitle: Presentation Information
type: docs
weight: 30
url: /cpp/examine-presentation/
keywords:
- presentation format
- presentation properties
- document properties
- get properties
- read properties
- change properties
- modify properties
- update properties
- examine PPTX
- examine PPT
- examine ODP
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Explore slides, structure and metadata in PowerPoint and OpenDocument presentations using C++ for faster insights and smarter content audits."
---

## **Overview**

This article shows how to inspect presentation information in Aspose.Slides. It explains how to determine a presentation’s current format without loading the full file, read its document properties, and update those properties when needed.

The examples are based on the [PresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/) and [DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/) APIs and demonstrate typical operations for working with presentation metadata.

## **Check a Presentation Format**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this C++ code:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Get Presentation Properties**

This C++ code shows you how to get presentation properties (information about the presentation):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Update Presentation Properties**

Aspose.Slides provides the [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) method that allows you to make changes to presentation properties.

Let's say we have a PowerPoint presentation with the document properties shown below.

![Original document properties of the PowerPoint presentation](input_properties.png)

This code example shows you how to edit some presentation properties:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

The results of changing the document properties are shown below.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Password-Protect Presentations](/slides/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cpp/write-protected-presentation/)

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**

Look for [embedded-font information](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) at the presentation level, then compare those entries with the set of [fonts actually used across content](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/) to identify which fonts are critical for rendering.

**How can I quickly tell if the file has hidden slides and how many?**

Iterate through the [slide collection](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) and inspect each slide's [visibility flag](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/).

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**

Yes. Compare the current [slide size and orientation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slidesize/) with the standard presets; this helps anticipate behavior for printing and export.

**Is there a quick way to see if charts reference external data sources?**

Yes. Traverse all [charts](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), check their [data source](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), and note whether the data is internal or link-based, including any broken links.

**How can I assess 'heavy' slides that may slow rendering or PDF export?**

For each slide, tally object counts and look for large images, transparency, shadows, animations, and multimedia; assign a rough complexity score to flag potential performance hotspots.
