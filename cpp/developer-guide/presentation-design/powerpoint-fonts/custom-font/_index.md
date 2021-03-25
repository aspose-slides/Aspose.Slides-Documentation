---
title: Custom Font
type: docs
weight: 20
url: /cpp/custom-font/
---


## **Use Custom Fonts without Installing**
Aspose.Slides lets you load fonts for rendering in presentations without even installing them. This article shows how to load fonts from custom directories without installing them. Please follow the steps below to loading Fonts from external directories by using Aspose.Slides for C++ API:

- Create an instance of FontsLoader Class and call the static method LoadExternalFonts.
- Perform render the presentation.
- Clear the cache in the FontsLoader Class.

The implementation of the above is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UseCustomFonts-UseCustomFonts.cpp" >}}

## **Manage Fonts Externally**
Now, you can also load fonts externally into a byte array. FontsLoader class now offer, LoadExternalFont(byte[] data) method that allows to add fonts from binary data. The implementation of the above steps is given below.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SpecifyFontsUsedWithPresentation-SpecifyFontsUsedWithPresentation.cpp" >}}

