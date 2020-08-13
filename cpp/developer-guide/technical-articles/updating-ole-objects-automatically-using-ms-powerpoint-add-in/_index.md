---
title: Updating OLE objects automatically using MS PowerPoint Add In
type: docs
weight: 120
url: /cpp/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

#### **About updating OLE objects automatically**
One of t he most frequent question s asked by the Aspose.Slides for C++ customers is how to create or change editable charts or any other OLE objects and have them automatically updated when opening the presentation. Unfortunately PowerPoint does not support any automatic macros, which are available in Excel and Word. The only ones available are the Auto_Open and Auto_Close macros. However, those only run automatically from an add-in. This short technical tip shows how to achieve that. 

First, there are available several freeware add-ins that add the Auto_Open macro feature to PowerPoint for example [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) and [Event Generator](http://officeone.mvps.org/eventgen/eventgen.html) . 

After installing such Add-in, just add Auto_Open() macro (OnPresentationOpen() in case of "Event Generator") to your template presentation as shown below: 

**Visual Basic**

``` cpp



 Sub Auto_Open()

 Dim oShape As Shape

 Dim oSlide As Slide

 Dim oGraph As Object

 ' Loop through each slide in the presentation.

 For Each oSlide In ActivePresentation.Slides

     ' Loop through all the shapes on the current slide.

     For Each oShape In oSlide.Shapes

 	' Check whether the shape is an OLE object.

 	If oShape.Type = msoEmbeddedOLEObject Then

    	 		' Found an OLE object; obtain object reference, and then update.

    		oObject = oShape.OLEFormat.Object

    		 	oObject.Application.Update()

     			' Now, quit out of the OLE server program. This frees

     		' memory, and prevents any problems. Also, set oObject equal

     			' to Nothing to release the object.

     			oObject.Application.Quit()

    		oObject = Nothing

    		End If

     Next oShape

  Next oSlide

End Sub



```

{{% alert color="primary" %}} 

Any change made to OLE objects with Aspose.Slides for C++ , will be updated automatically when PowerPoint opens the presentation. If you have many OLE objects in a presentation and do not want to update them all, just add a custom tag to the shapes you need to process and check it in the macro. 

{{% /alert %}}
