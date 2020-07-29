---
title: Working with ActiveX Controls
type: docs
weight: 60
url: /java/working-with-activex-controls/
---

## **Adding Media Player ActiveX Controls in the Slide**
{{% alert color="primary" %}} 

ActiveX control are used in presentations. Aspose.Slides for Java lets you add and manage ActiveX controls, but managing them is bit trickier and different from normal presentation shapes. The support for adding Media Player ActiveX control has been added in Aspose.Slides. Remember, ActiveX controls are not shapes and are not part of the presentation's [IShapeCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IShapeCollection) but the separate [IControlCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IControlCollection). This article shows how to work with them.

{{% /alert %}} 
### **Linking Video with already added Media Player ActiveX Control in the Slide**
To manage a Media Player ActiveX control, please perform following steps:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the sample presentation with Media Player ActiveX controls in it.
1. Create an instance of target [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and generate empty presentation instance.
1. Clone the slide with Media Player ActiveX control in template presentation to target [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation).
1. Access the cloned slide in target [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation).
1. Access the ActiveX controls in the slide by accessing the [IControlCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IControlCollection).
1. Access the Media Player ActiveX control and set the video path by using its properties.
1. Save the presentation to a PPTX file.

The above steps are implemented in the code examples given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-ActiveXControls-LinkingVideoWithMediaPlayerActiveXControl-LinkingVideoWithMediaPlayerActiveXControl.java" >}}




|![todo:image_alt_text](http://i.imgur.com/h2K0cAM.png)|
| :- |
|**Figure: The source ActiveX controls**|


|![todo:image_alt_text](http://i.imgur.com/FrKHGmB.png)|
| :- |
|**Figure: Modified ActiveX controls**|
### **Adding Media Player ActiveX Control in Slides**
In order to add a Media Player ActiveX control, please perform following steps:

1. Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and generate empty presentation instance.
1. Access the target slide in [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation).
1. Add the Media Player ActiveX control using AddControl method exposed by [IControlCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IControlCollection).
1. Access the Media Player ActiveX control and set the video path by using its properties.
1. Save the presentation to a PPTX file.

The above steps are implemented in the code examples given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-ActiveXControls-AddingMediaPlayerActiveXControlInSlides-AddingMediaPlayerActiveXControlInSlides.java" >}}
## **Modifying ActiveX Controls in Slide**
{{% alert color="primary" %}} 

ActiveX control are used in presentations. Aspose.Slides for Java lets you manage ActiveX controls, but managing them is bit trickier and different from normal presentation shapes. From Aspose.Slides for Java 7.1.0, the component supports managing ActiveX controls. At the moment, you can access already added ActiveX control in your presentation and modify or delete it by using its various properties. Remember, ActiveX controls are not shapes and are not part of the presentation's IShapeCollection but the separate IControlCollection. This article shows how to work with them.

{{% /alert %}} 

To manage a simple ActiveX control like a text box and simple command button on a slide:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation with ActiveX controls in it.
1. Obtain a slide reference by its index.
1. Access the ActiveX controls in the slide by accessing the [IControlCollection](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IControlCollection).
1. Access the TextBox1 ActiveX control using the [ControlEx](http://www.aspose.com/api/java/slides/com.aspose.slides/interfaces/IControl) object.
1. Change the different properties of the TextBox1 ActiveX control including text, font, font height and frame position.
1. Access the second access control called CommandButton1.
1. Change the button caption, font and position.
1. Shift the position of the ActiveX controls frames.
1. Write the modified presentation to a PPTX file.

The above steps are implemented in the code examples given below.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-ActiveXControls-ModifyingActiveXControlsInSlide-ModifyingActiveXControlsInSlide.java" >}}

|![todo:image_alt_text](http://i.imgur.com/IWdejot.png)|
| :- |
|**Figure: The source ActiveX controls**|


|![todo:image_alt_text](http://i.imgur.com/wN63XDe.png)|
| :- |
|**Figure: Modified ActiveX controls**|

