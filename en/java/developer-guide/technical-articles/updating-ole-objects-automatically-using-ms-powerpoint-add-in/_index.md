---
title: Updating OLE objects automatically using MS PowerPoint Add In
type: docs
weight: 10
url: /java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **About updating OLE objects automatically**
One of t he most frequent question s asked by the Aspose.Slides customers is how to create or change editable charts or any other OLE objects and have them automatically updated when opening the presentation. Unfortunately PowerPoint does not support any automatic macros, which are available in Excel and Word. The only ones available are the Auto_Open and Auto_Close macros. However, those only run automatically from an add-in. This short technical tip shows how to achieve that. 

First, there are available several freeware add-ins that add the Auto_Open macro feature to PowerPoint for example [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) and [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html) . 

After installing such Add-in, just add Auto_Open() macro (OnPresentationOpen() in case of "Event Generator") to your template presentation as shown below: 

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}





{{% alert color="primary" %}} 

Any change made to OLE objects with Aspose.Slides, will be updated automatically when PowerPoint opens the presentation. If you have many OLE objects in a presentation and do not want to update them all, just add a custom tag to the shapes you need to process and check it in the macro. 

{{% /alert %}}
