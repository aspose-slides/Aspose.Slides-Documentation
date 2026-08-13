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
description: "Überblick über öffentliche API‑Updates und inkompatible Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}}

Diese Seite listet alle [hinzugefügt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) oder [entfernt](/slides/de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides für .NET 15.5.0 API eingeführt wurden.

{{% /alert %}}
## **Änderungen der öffentlichen API**
#### **CommonSlideViewProperties-Klasse und ICommonSlideViewProperties-Schnittstelle wurden hinzugefügt**
Die Klasse Aspose.Slides.CommonSlideViewProperties und die Schnittstelle Aspose.Slides.ICommonSlideViewProperties repräsentieren gemeinsame Folienansichtseigenschaften (derzeit Optionen für die Ansichtsskalierung).
#### **IAxis.LabelOffset-Eigenschaft wurde hinzugefügt**
Die IAxis.LabelOffset-Eigenschaft gibt den Abstand der Beschriftungen von der Achse an. Wird auf Kategorie‑ oder Datumsachsen angewendet.
#### **IChartTextBlockFormat.AutofitType-Eigenschaft wurde hinzugefügt**
Das Ändern dieser Eigenschaft kann nur für die folgenden Diagrammteile einen Einfluss haben: DataLabel und DataLabelFormat (volle Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat sie keine Auswirkung auf die Darstellung).
#### **IChartTextBlockFormat.WrapText-Eigenschaft wurde hinzugefügt**
Das Ändern dieser Eigenschaft kann nur für die folgenden Diagrammteile einen Einfluss haben: DataLabel und DataLabelFormat (volle Unterstützung in PowerPoint 2007/2013).
#### **Rand‑Eigenschaften wurden zu IChartTextBlockFormat hinzugefügt**
Das Ändern dieser Eigenschaften kann nur für die folgenden Diagrammteile einen Einfluss haben: DataLabel und DataLabelFormat (volle Unterstützung in PowerPoint 2013; in PowerPoint 2007 hat sie keine Auswirkung auf die Darstellung).
#### **ViewProperties.NotesViewProperties‑Eigenschaft wurde hinzugefügt**
Die ViewProperties.NotesViewProperties‑Eigenschaft wurde hinzugefügt. Sie gibt gemeinsame Ansichtseigenschaften an, die mit dem Notizansichtsmodus verbunden sind.
#### **ViewProperties.SlideViewProperties‑Eigenschaft wurde hinzugefügt**
Die ViewProperties.SlideViewProperties‑Eigenschaft wurde hinzugefügt. Sie gibt gemeinsame Ansichtseigenschaften an, die mit dem Folienansichtsmodus verbunden sind.