---
title: Presentation Properties
type: docs
weight: 70
url: /java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint provides a feature to add some properties to the presentation files. These document properties allow some useful information to be stored along with the documents (presentation files). There are two kinds of document properties as follows

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

**Built-in** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for Java, developers can access and modify the values of built-in properties as well as custom properties.

{{% /alert %}} 

## **Document Properties in PowerPoint**
Microsoft PowerPoint 2007 allows managing the document properties of the presentation files. All you have to do is to click the Office icon and further **Prepare | Properties | Advanced Properties** menu item of the Microsoft PowerPoint 2007 as shown below:

{{% alert color="primary" %}} 

Please note that you cannot set values against the **Application** and **Producer** fields, because Aspose Ltd. and Aspose.Slides for Java x.x.x will be displayed against these fields.

{{% /alert %}} 

|**Selecting Advanced Properties menu item**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/ZrmuCD6.jpg)| |
After you select **Advanced Properties** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file as shown below in the figure:

|**Properties Dialog**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/LibmdQd.jpg)| |
In the above **Properties Dialog**, you can see that there are many tab pages like **General**, **Summary**, **Statistics**, **Contents** and **Custom**. All these tab pages allow configuring different kinds of information related to the PowerPoint files. **Custom** tab is used to manage the custom properties of the PowerPoint files.



Working with Document Properties Using Aspose.Slides for Java

As we have described earlier that Aspose.Slides for Java supports two kinds of document properties, which are **Built-in** and **Custom** properties. So, developers can access both kinds of properties with the use of Aspose.Slides for Java API. Aspose.Slides for Java provides a class [IDocumentProperties](https://apireference.aspose.com/java/slides/com.aspose.slides/idocumentproperties) that represents the document properties associated with a presentation file through **Presentation.DocumentProperties** property.

Developers can use **IDocumentProperties** property exposed by [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) object to access the document properties of the presentation files as described below:

## **Access Built-in Properties**
These properties as exposed by [IDocumentProperties](https://apireference.aspose.com/java/slides/com.aspose.slides/idocumentproperties) object include: **Creator** (Author), **Description**, **Keywords** **Created** (Creation Date), **Modified** Modification Date, **Printed** Last Print Date, **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** and **Title**



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-AccessingBuiltInProperties-AccessingBuiltInProperties.java" >}}
## **Modify Built-in Properties**
Modifying the built-in properties of presentation files is as easy as that of accessing them. You can simply assign a string value to any desired property and the property value would be modified. In the example given below, we have demonstrated how we can modify the built-in document properties of the presentation file using Aspose.Slides for Java.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-ModifyingBuiltInProperties-ModifyingBuiltInProperties.java" >}}



This example modifies the built-in properties of the presentation that can be viewed as shown below:

|**Built-in document properties after modification**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/zz1N9de.jpg)| |

## **Add Custom Document Properties**
Aspose.Slides for Java also allows developers to add the custom the values for presentation Document properties. An example is given below that shows how to set the custom properties for a presentation.


{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-AddingCustomDocumentProperties-AddingCustomDocumentProperties.java" >}}

|**Custom Document Properties Added**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/HdKcxI9.png)| |

## **Access and Modify Custom Properties**
Aspose.Slides for Java also allows developers to access the values of custom properties. An example is given below that shows how can you access and modify all of these custom properties for a presentation.


{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-AccessingAndModifyingCustomProperties-AccessingAndModifyingCustomProperties.java" >}}

This example modifies the custom properties of the [PPTX ](https://wiki.fileformat.com/presentation/pptx/)presentation. Following figures show the presentation custom properties before and after modification:

|**Custom Properties before Modification**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/Ze7YHvi.jpg)| |


|**Custom Properties after Modification**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/Tofu0CL.jpg)| |

## **Advanced Document Properties**
{{% alert color="primary" %}} 

New methods [ReadDocumentProperties](https://apireference.aspose.com/java/slides/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://apireference.aspose.com/java/slides/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), and [WriteBindedPresentation](https://apireference.aspose.com/java/slides/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) have been added to [IPresentationInfo](https://apireference.aspose.com/java/slides/com.aspose.slides/IPresentationInfo), logic of the [IDocumentProperties.setLastSavedTime](https://apireference.aspose.com/java/slides/com.aspose.slides/IDocumentProperties#setLastSavedTime-java.util.Date-) property setter has been changed.

{{% /alert %}} 

The two new methods ReadDocumentProperties and UpdateDocumentProperties have been added to IPresentationInfo interface. They provide quick access to document properties and allow to change and update properties without loading a whole presentation.

The typical scenario load the properties, change some value and update the document can be implemented in the following way:



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-ReadAndUpdateDocumentProperties-ReadAndUpdateDocumentProperties.java" >}}

There is another way to use properties of a particular presentation as a template to update properties in other presentations:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-UpdateOtherPresentationsusingPresentationPropertiesAsTemplate-UpdateOtherPresentationsusingPresentationPropertiesAsTemplate.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-UpdateOtherPresentationsusingPresentationPropertiesAsTemplate-updateByTemplate.java" >}}


A new template can be created from scratch and then used to update multiple presentations:


{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-CreateNewTemplateAndUpdateMultiplePresentations-CreateNewTemplateAndUpdateMultiplePresentations.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-UpdateOtherPresentationsusingPresentationPropertiesAsTemplate-updateByTemplate.java" >}}


## **Check if Presentation is Modified or Created**
Aspose.Slides for Java provides the facility to check if a presentation is modified or created. An example is given below that shows how to check if the presentation is created or modified.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-CheckPresentationModified-CheckPresentationModified.java" >}}

