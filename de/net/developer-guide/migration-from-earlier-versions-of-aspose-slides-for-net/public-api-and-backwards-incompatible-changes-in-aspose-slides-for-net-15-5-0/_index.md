---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.5.0
linktitle: Aspose.Slides für .NET 15.5.0
type: docs
weight: 160
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie die öffentlichen API-Updates und breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP-Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
#### **CommonSlideViewProperties-Klasse und ICommonSlideViewProperties-Schnittstelle wurden hinzugefügt**
Die Aspose.Slides.CommonSlideViewProperties-Klasse und die Aspose.Slides.ICommonSlideViewProperties-Schnittstelle repräsentieren gemeinsame Folienansichtseigenschaften (derzeit Optionen für die Ansichtsskalierung).
#### **IAxis.LabelOffset-Eigenschaft wurde hinzugefügt**
Die IAxis.LabelOffset-Eigenschaft gibt den Abstand der Beschriftungen von der Achse an. Gilt für Kategorie- oder Datumsachse.
#### **IChartTextBlockFormat.AutofitType-Eigenschaft wurde hinzugefügt**
Das Ändern dieser Eigenschaft kann nur bei folgenden Diagrammteilen einen bestimmten Einfluss haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat es keine Auswirkung auf die Darstellung).
#### **IChartTextBlockFormat.WrapText-Eigenschaft wurde hinzugefügt**
Das Ändern dieser Eigenschaft kann nur bei folgenden Diagrammteilen einen bestimmten Einfluss haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2007/2013).
#### **Margin-Eigenschaften wurden zu IChartTextBlockFormat hinzugefügt**
Das Ändern dieser Eigenschaften kann nur bei folgenden Diagrammteilen einen bestimmten Einfluss haben: DataLabel und DataLabelFormat (vollständige Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat es keine Auswirkung auf die Darstellung).
#### **ViewProperties.NotesViewProperties-Eigenschaft wurde hinzugefügt**
Die Aspose.Slides.ViewProperties.NotesViewProperties-Eigenschaft wurde hinzugefügt. Sie gibt gemeinsame Ansichtseigenschaften an, die dem Notizansichtsmodus zugeordnet sind.
#### **ViewProperties.SlideViewProperties-Eigenschaft wurde hinzugefügt**
Die Aspose.Slides.ViewProperties.SlideViewProperties-Eigenschaft wurde hinzugefügt. Sie gibt gemeinsame Ansichtseigenschaften an, die dem Folienansichtsmodus zugeordnet sind.