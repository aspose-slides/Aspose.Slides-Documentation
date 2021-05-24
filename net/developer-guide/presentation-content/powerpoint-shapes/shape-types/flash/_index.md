---
title: Flash
type: docs
weight: 10
url: /net/flash/
---

## **Extract Flash Objects from Presentation**
Aspose.Slides for .NET provides a facility for extracting flash objects from presentation. You can access the flash control by name and extract it from presentation and including store SWF object data.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_PresentationProperties();

using (Presentation pres = new Presentation(dataDir+"withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```

