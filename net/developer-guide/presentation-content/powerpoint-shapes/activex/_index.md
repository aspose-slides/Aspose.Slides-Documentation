---
title: ActiveX
type: docs
weight: 70
url: /net/activex/
---



ActiveX controls are used in presentations. Aspose.Slides for .NET lets you manage ActiveX controls, but managing them is bit trickier and different from normal presentation shapes. From Aspose.Slides for .NET 6.9.0, the component supports managing ActiveX controls. At the moment, you can access already added ActiveX control in your presentation and modify or delete it by using its various properties. Remember, ActiveX controls are not shapes and are not part of the presentation's IShapeCollection but the separate IControlCollection. This article shows how to work with them.
## **Modify ActiveX Controls**
To manage a simple ActiveX control like a text box and simple command button on a slide:

1. Create an instance of the Presentation class and load the presentation with ActiveX controls in it.
1. Obtain a slide reference by its index.
1. Access the ActiveX controls in the slide by accessing the IControlCollection.
1. Access the TextBox1 ActiveX control using the ControlEx object.
1. Change the different properties of the TextBox1 ActiveX control including text, font, font height and frame position.
1. Access the second access control called CommandButton1.
1. Change the button caption, font and position.
1. Shift the position of the ActiveX controls frames.
1. Write the modified presentation to a PPTX file.

The code snippet below updates the ActiveX controls on the presentation slides to the slide as shown below.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-ActiveX-ManageActiveXControl-ManageActiveXControl.cs" >}}
## **Add ActiveX Media Player Control**
To add ActiveX Media Player control, please perform following steps:

1. Create an instance of the Presentation class and load the sample presentation with Media Player ActiveX controls in it.
1. Create an instance of target Presentation class and generate empty presentation instance.
1. Clone the slide with Media Player ActiveX control in template presentation to target Presentation.
1. Access the cloned slide in target Presentation.
1. Access the ActiveX controls in the slide by accessing the IControlCollection.
1. Access the Media Player ActiveX control and set the video path by using its properties.
1. Save the presentation to a PPTX file.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-ActiveX-LinkingVideoActiveXControl-LinkingVideoActiveXControl.cs" >}}
