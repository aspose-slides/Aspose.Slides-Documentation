---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 15.7.0
type: docs
weight: 180
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) oder [entfernten](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) Klassen, Methoden, Eigenschaften usw. sowie andere Änderungen auf, die mit der Aspose.Slides für .NET 15.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Enum ImagePixelFormat wurde hinzugefügt**
Das Enum Aspose.Slides.Export.ImagePixelFormat wurde hinzugefügt, um das Pixel-Format für die generierten Bilder anzugeben.
#### **Die Methode IChartDataPoint.GetAutomaticDataPointColor() wurde hinzugefügt**
Gibt eine automatische Farbe des Datenpunkts basierend auf dem Serienindex, Datenpunktindex, ParentSeriesGroup, der IsColorVaried-Eigenschaft und dem Diagrammstil zurück.
Diese Farbe wird standardmäßig verwendet, wenn FillType NotDefined entspricht.
#### **Die Methode RenderToGraphics wurde zu Slide hinzugefügt**
Die Methode RenderToGraphics (und ihre Überladungen) wurde zu Aspose.Slides.Slide hinzugefügt, um eine Folie in ein Graphics-Objekt zu rendern.
#### **Die Eigenschaft PixelFormat wurde zu ITiffOptions und TiffOptions hinzugefügt**
Die Eigenschaft PixelFormat wurde zu Aspose.Slides.Export.ITiffOptions und Aspose.Slides.Export.TiffOptions hinzugefügt, um das Pixel-Format für die generierten TIFF-Bilder anzugeben.