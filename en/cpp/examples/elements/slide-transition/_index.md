---
title: Slide Transition
type: docs
weight: 110
url: /cpp/examples/elements/slide-transition/
keywords:
- code example
- slide transition
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Master slide transitions in Aspose.Slides for C++: add, customize, and sequence effects and durations with C++ examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates applying slide transition effects and timings with **Aspose.Slides for C++**.

## **Add a Slide Transition**

Apply a fade transition effect to the first slide.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;
using namespace System;

static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Apply a fade transition.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Access a Slide Transition**

Read the transition type currently assigned to a slide.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;
using namespace System;

static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Access the transition type.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Remove a Slide Transition**

Clear any transition effect by setting the type to `None`.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;
using namespace System;

static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Remove transition by setting none.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Set Transition Duration**

Specify how long the slide is displayed before advancing automatically.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::SlideShow;
using namespace System;

static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // In milliseconds.

    presentation->Dispose();
}
```
