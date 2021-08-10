---
title: Manage Hyperlinks
type: docs
weight: 20
url: /cpp/manage-hyperlinks/
---


## **Add Hyperlink to Presentation**
To add hyperlink in a presentation on the presentation level:

1. Create an instance of the Presentation class and access the desired presentation.
1. Add an AutoShape of Rectangle type using AddAutoShape method exposed by Shapes object.
1. Add hyperlink.
1. Save presentation as a PPTX file.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddHyperlink-AddHyperlink.cpp" >}}


## **Remove Hyperlink from Presentation**
To remove hyperlinks from a presentation on the presentation level:

1. Create an instance of the Presentation class and access the desired presentation.
1. Remove the hyperlinks in the presentation on the presentation level by accessing [IPresentation.HyperlinkQueries](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries) and calling the [RemoveAllHyperlinks()](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks) method.
1. Write the modified presentation as a PPTX file.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-Hyperlinks-RemoveHyperlinks.cpp" >}}


## **Mutable Hyperlink**
Hyperlink class changed to be mutable. Now it is possible to use the following methods:

- Hyperlink::set_TargetFrame()
- Hyperlink::set_Tooltip()
- Hyperlink::set_History()
- Hyperlink::set_HighlightClick()
- Hyperlink::set_StopSoundOnClick()

The code snippet below shows adding a hyperlink to the slide and editing its tooltip later:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-MutableHyperlink-MutableHyperlink.cpp" >}}


## **Set Hyperlink Color**
New get_ColorSource() and set_ColorSource() methods have been added to IHyperlink and Hyperlink classes.

These methods allow to get or set the source of hyperlink color, which could be obtained either from slide/presentation styles or corresponding PortionFormat properties. This is a new feature of PowerPoint 2019 and any changes made to this property will take affect only in PowerPoint 2019 or higher versions.

The code snippet below shows a sample of adding two hyperlinks with different colors to the same slide:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetHyperlinkColor-SetHyperlinkColor.cpp" >}}


## **Create TextBox with Hyperlink**
In this topic, we will create a TextBox with a Hyperlink. You will have to instantiate IHyperlinkManager class and assign it to the desired portion of the TextFrame associated with the TextBox. Please follow the steps below to create a TextBox with Hyperlink by using Aspose.Slides for C++ API:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class.
- Obtain the reference of the first slide in the presentation which is created on instantiation of Presentation.
- Add an AutoShape with ShapeType as Rectangle at a specified position of the slide and obtain the reference of that newly added AutoShape object.
- Add a TextFrame to the AutoShape containing Aspose TextBox as default text.
- Instantiate the IHyperlinkManager class.
- Assign the IHyperlinkManager object to the HLinkClick property associated with the desired portion of the TextFrame.
- Finally, write the PPTX file using the Presentation object.

The implementation of the above steps is demonstrated below in an example.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxHyperlink-TextBoxHyperlink.cpp" >}}

## **IHyperlinkQueries Properties**
The IHyperlinkQueries class can be accessed from the presentation, slide and text frame that the hyperlink is defined for.

- [IPresentation.HyperlinkQueries](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](http://www.aspose.com/api/net/slides/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](http://www.aspose.com/api/net/slides/aspose.slides/itextframe/properties/hyperlinkqueries)

The IHyperlinkQueries class supports the following methods and properties.

- [IHyperlinkQueries.GetHyperlinkClicks();](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](http://www.aspose.com/api/net/slides/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)
