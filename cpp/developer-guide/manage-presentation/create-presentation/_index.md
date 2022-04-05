---
title: Create Presentation - C++ PowerPoint API
linktitle: Create Presentation
type: docs
weight: 10
url: /cpp/create-presentation/
description: To create PowerPoint Presentation in C++ API, please follow the steps mentioned in this article. The code adds a line to the first slide of the presentation.
---

## **Create PowerPoint Presentation**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Line type using the AddAutoShape method exposed by Shapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

