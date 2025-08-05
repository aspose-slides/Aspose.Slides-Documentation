---
title: Update OLE Objects Automatically Using a PowerPoint Add-In
type: docs
weight: 10
url: /net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE object
- update OLE
- automatically
- add-in
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Discover how to auto-update OLE charts and objects in PowerPoint with an add-in and Aspose.Slides for .NET, featuring practical code and optimization tips."
---

## **Updating OLE Objects Automatically**

One of the most frequent questions asked by Aspose.Slides for .NET customers is how to create or modify editable charts (or other OLE objects) so that they update automatically when the presentation is opened. Unfortunately, PowerPoint doesn’t support automatic macros in the same way Excel and Word do. The only macros available are `Auto_Open` and `Auto_Close`, and these only run automatically from an add-in. This short technical tip shows how to achieve that.

First, several freeware add-ins are available that add the Auto_Open macro feature to PowerPoint, for example [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) and [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

After installing one of these add-ins, simply add the `Auto_Open()` macro (or `OnPresentationOpen()` if you’re using Event Generator) to your template presentation as shown below:

```cs
public void Auto_Open()
{
    // Loop through each slide in the presentation.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Loop through all the shapes on the current slide.
        foreach (var oShape in oSlide.Shapes)
        {
            // Check whether the shape is an OLE object.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Found an OLE object. Obtain its object reference and then update it.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Now, quit out of the OLE server program.
                // This frees memory, and prevents any problems.
                // Also, set oObject to Nothing to release the object.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Any changes made to OLE objects with Aspose.Slides for .NET will be automatically updated when PowerPoint opens the presentation. If you have many OLE objects and don’t want to update them all, simply add a custom tag to the shapes you need to process and check for it in the macro.
