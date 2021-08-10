---
title: Manage Blob
type: docs
weight: 10
url: /cpp/manage-blob/
---



## **Add BLOB to Presentation**
Aspose.Slides for C++ provides a facility to add large files (video file in that case) and prevent a high memory consumption. An example is given below that shows how to add Blob in presentations.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddBlobToPresentation-AddBlobToPresentation.cpp" >}}

## **Export BLOB from Presentation**
Aspose.Slides for C++ provides a facility to Export large files (audio and video file in that case). We want to extract these files from the presentation and don't want to load this presentation into memory to keep our memory consumption low. Here's is an example given below how we can export blob from presentations.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ExportBlobFromPresentation-ExportBlobFromPresentation.cpp" >}}

## **Add Image as BLOB to Presentation**
Aspose.Slides for C++ added a new method to **IImageCollection** interface and **ImageCollection** class to support adding a large image as streams to treat them as BLOBs.

This example demonstrates how to include the large BLOB (image) and prevent a high memory consumption.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddBlobImageToPresentation-AddBlobImageToPresentation.cpp" >}}
