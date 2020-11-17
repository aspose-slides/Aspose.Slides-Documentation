---
title: Open Presentation
type: docs
weight: 30
url: /net/open-presentation/
---

## **Open Presentation**
Using Aspose.Slides for .NET, developers can not only create PowerPoint presentations from scratch but also access or modify the existing ones. In this topic, we will discuss the simplest approach to open and access an existing presentation.

Aspose.Slides for .NET provides Presentation class that is used to open an existing presentation. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation.In the example given below, we have passed the name of the presentation file (to be opened) to the constructor of Presentation class. After the file is opened, we get the total number of slides present in the presentation to print on the screen. The following example shows how to Open a Presentation.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Opening-OpenPresentation-OpenPresentation.cs" >}}
## **Open Large Presentation**
Aspose.Slides for .NET provides facility to open very large presentations using Presentation class. Now you can load large presentations lets say presentation size is 2 Gb, you can easily open that with these sample codes provided below.



{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Opening-OpenVeryLargePresentation-OpenVeryLargePresentation.cs" >}}


## **Load Presentation**
New IResourceLoadingCallback interface has been added. This callback interface is used to manage external resources loading and has one method:

The code snippet below shows how to use IResourceLoadingCallback interface:

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Opening-LoadPresentation-LoadPresentation.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Opening-LoadPresentation-IResourceLoadingCallback.cs" >}}
