---
title: Öffentliche API und rückwärtsinkompatible Änderungen in Aspose.Slides für .NET 15.5.0
linktitle: Aspose.Slides für .NET 15.5.0
type: docs
weight: 160
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- Migration
- Altcode
- Moderner Code
- Altansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die breaking changes in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

{{% alert color="primary" %}} 

Diese Seite listet alle [added](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) oder [removed](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for .NET 15.5.0 API eingeführt wurden.

{{% /alert %}} 
## **Public API-Änderungen**
#### **Klasse CommonSlideViewProperties und Schnittstelle ICommonSlideViewProperties wurden hinzugefügt**
Die Klasse Aspose.Slides.CommonSlideViewProperties und die Schnittstelle Aspose.Slides.ICommonSlideViewProperties repräsentieren gemeinsame Folienansichtseigenschaften (derzeit Optionen für die Ansichtsskalierung).
#### **Eigenschaft IAxis.LabelOffset wurde hinzugefügt**
Die Eigenschaft IAxis.LabelOffset gibt den Abstand der Beschriftungen von der Achse an. Wird auf Kategorie- oder Datumsachsen angewendet.
#### **Eigenschaft IChartTextBlockFormat.AutofitType wurde hinzugefügt**
Das Ändern dieser Eigenschaft kann nur für die folgenden Diagrammteile einen bestimmten Einfluss haben: DataLabel und DataLabelFormat (volle Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat sie keine Auswirkung auf das Rendering).
#### **Eigenschaft IChartTextBlockFormat.WrapText wurde hinzugefügt**
Das Ändern dieser Eigenschaft kann nur für die folgenden Diagrammteile einen bestimmten Einfluss haben: DataLabel und DataLabelFormat (volle Unterstützung in PowerPoint 2007/2013).
#### **Rand‑Eigenschaften wurden zu IChartTextBlockFormat hinzugefügt**
Das Ändern dieser Eigenschaften kann nur für die folgenden Diagrammteile einen bestimmten Einfluss haben: DataLabel und DataLabelFormat (volle Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat sie keine Auswirkung auf das Rendering).
#### **Eigenschaft ViewProperties.NotesViewProperties wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.ViewProperties.NotesViewProperties wurde hinzugefügt. Sie gibt gemeinsame Ansichtseigenschaften an, die mit dem Notizansichtsmodus verbunden sind.
#### **Eigenschaft ViewProperties.SlideViewProperties wurde hinzugefügt**
Die Eigenschaft Aspose.Slides.ViewProperties.SlideViewProperties wurde hinzugefügt. Sie gibt gemeinsame Ansichtseigenschaften an, die mit dem Folienansichtsmodus verbunden sind.