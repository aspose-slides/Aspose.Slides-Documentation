---
title: Save Presentations in Read-Only Mode Using Python
linktitle: Read-Only Presentation
type: docs
weight: 30
url: /python-net/read-only-presentation/
keywords:
- read only
- protect presentation
- prevent editing
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Load and save PowerPoint files (PPT, PPTX) in read-only mode with Aspose.Slides for Python via .NET, offering precise slide previews without altering your presentations."
---

In PowerPoint 2019, Microsoft introduced the **Always Open Read-Only** setting as one of the options users can use to protect their presentations. You may want to use this Read-Only setting to protect a presentation when

- You want to prevent accidental edits and keep the content of your presentation safe. 
- You want to alert people that the presentation you provided is the final version. 

After you select the **Always Open Read-Only** option for a presentation, when users open the presentation, they see the **Read-Only** recommendation and may see a message in this form: *To prevent accidental changes, the author has set this file to open as read-only.*

The Read-Only recommendation is a simple yet effective deterrent that discourages editing because users have to perform a task to remove it before they are allowed to edit a presentation. If you do not want users to make changes to a presentation and want to tell them about this in a polite way, then the Read-Only recommendation may a good option for you. 

> If a presentation with the **Read-Only** protection gets opened in an older Microsoft PowerPoint application—which does not support the recently introduced function—the **Read-Only** recommendation gets ignored (the presentation is opened normally).

Aspose.Slides for Python via .NET allows you to set a presentation to **Read-Only**, which means users (after they open the presentation) see the **Read-Only** recommendation. This sample code shows you how to set a presentation to **Read-Only** in Python using Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Note**: The **Read-Only** recommendation is simply meant to discourage editing or stop users from making accidental changes to a PowerPoint presentation. If a motivated person—who knows what they are doing—decides to edit your presentation, they can easily remove the Read-Only setting. If you seriously need to prevent unauthorized editing, you are better off using [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/python-net/password-protected-presentation/). 

{{% /alert %}} 