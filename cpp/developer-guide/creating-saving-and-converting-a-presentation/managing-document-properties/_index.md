---
title: Managing Document Properties
type: docs
weight: 80
url: /cpp/managing-document-properties/
---

## **Working with Document Properties**
As we have described earlier that Aspose.Slides for C++ supports two kinds of document properties, which are **Built-in** and **Custom** properties. So, developers can access both kinds of properties with the use of Aspose.Slides for C++ API. Aspose.Slides for C++ provides a class [IDocumentProperties](http://www.aspose.com/api/net/slides/aspose.slides/idocumentproperties) that represents the document properties associated with a presentation file through [Presentation.DocumentProperties](http://www.aspose.com/api/net/slides/aspose.slides/presentation/properties/documentproperties) property. Developers can use [IDocumentProperties](http://www.aspose.com/api/net/slides/aspose.slides/idocumentproperties/properties/index) property exposed by **Presentation** object to access the document properties of the presentation files as described below:

{{% alert color="primary" %}} 

Please note that you cannot set values against the **Application** and **Producer** fields, because Aspose Ltd. and Aspose.Slides for C++ x.x.x will be displayed against these fields.

{{% /alert %}} 


### **Managing Document Properties**
Microsoft PowerPoint provides a feature to add some properties to the presentation files. These document properties allow some useful information to be stored along with the documents (presentation files). There are two kinds of document properties as follows

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for C++, developers can access and modify the values of built-in properties as well as custom properties. Microsoft PowerPoint 2007 allows managing the document properties of the presentation files. All you have to do is to click the Office icon and further **Prepare | Properties | Advanced Properties** menu item of the Microsoft PowerPoint 2007. After you select **Advanced Properties** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file. In the **Properties Dialog**, you can see that there are many tab pages like **General, Summary, Statistics, Contents and Custom**. All these tab pages allow configuring different kinds of information related to the PowerPoint files. **Custom** tab is used to manage custom properties of the PowerPoint files.
### **Accessing Built-in Properties**
These properties as exposed by **IDocumentProperties** object include: **Creator(Author)**, **Description**, **KeyWords** **Created** (Creation Date), **Modified** Modification Date, **Printed** Last Print Date, **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** and **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}
### **Modifying Built-in Properties**
Modifying the built-in properties of presentation files is as easy as that of accessing them. You can simply assign a string value to any desired property and the property value would be modified. In the example given below, we have demonstrated that how we can modify the built-in document properties of the presentation file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}
### **Accessing and Modifying Custom Properties**
Aspose.Slides for C++ also allows developers to access the values of custom properties. An example is given below that shows how can you access and modify all of these custom properties for a presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}
### **Adding Custom Document Properties**
Aspose.Slides for C++ also allows developers to add the custom the values for presentation Document properties. An example is given below that shows how to set the custom properties for a presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}
