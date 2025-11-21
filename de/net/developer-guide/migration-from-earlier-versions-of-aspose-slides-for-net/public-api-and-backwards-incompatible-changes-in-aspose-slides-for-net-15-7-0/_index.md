---
title: Öffentliche API- und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.7.0
linktitle: Aspose.Slides für .NET 15.7.0
type: docs
weight: 180
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- Migration
- Legacy-Code
- Moderne Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überblick über öffentliche API-Updates und Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint-PPT, PPTX und ODP-Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) oder [entfernten](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 15.7.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **Enum ImagePixelFormat wurde hinzugefügt**
Der Enum Aspose.Slides.Export.ImagePixelFormat wurde hinzugefügt, um das Pixel-Format für die erzeugten Bilder anzugeben.
#### **Methode IChartDataPoint.GetAutomaticDataPointColor() wurde hinzugefügt**
Gibt eine automatische Farbe des Datenpunkts basierend auf dem Serienindex, dem Datenpunktindex, ParentSeriesGroup, der Eigenschaft IsColorVaried und dem Diagrammstil zurück.
Diese Farbe wird standardmäßig verwendet, wenn FillType den Wert NotDefined hat.
#### **Methode RenderToGraphics wurde zu Slide hinzugefügt**
Die Methode RenderToGraphics (und ihre Überladungen) wurde zu Aspose.Slides.Slide hinzugefügt, um eine Folie in ein Graphics-Objekt zu rendern.
#### **Eigenschaft PixelFormat wurde zu ITiffOptions und TiffOptions hinzugefügt**
Die Eigenschaft PixelFormat wurde zu Aspose.Slides.Export.ITiffOptions und Aspose.Slides.Export.TiffOptions hinzugefügt, um das Pixel-Format für die erzeugten TIFF-Bilder anzugeben.