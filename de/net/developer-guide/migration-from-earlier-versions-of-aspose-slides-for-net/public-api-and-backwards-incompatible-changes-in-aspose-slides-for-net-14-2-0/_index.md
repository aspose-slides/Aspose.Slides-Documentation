---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 14.2.0
linktitle: Aspose.Slides für .NET 14.2.0
type: docs
weight: 40
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
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
description: "Überblick über öffentliche API-Updates und inkompatible Änderungen in Aspose.Slides für .NET, um Ihre PowerPoint PPT, PPTX und ODP Präsentationslösungen reibungslos zu migrieren."
---

## **Öffentliche API und rückwärts inkompatible Änderungen**
{{% alert color="primary" %}} 

Wir haben einige Änderungen an der Aspose.Slides für .NET 14.2.0 API vorgenommen. Einige Eigenschaften und Methoden wurden entfernt und einige wurden in einen anderen Namespace verschoben.

{{% /alert %}} 
### **Methoden Aspose.Slides.IPresentation.Write(…) entfernt**
Diese Methoden schrieben Präsentationsobjekte nur in PPTX-Formatdateien. In der neuen API ist die Presentation-Klasse für die Arbeit mit allen Formaten vorgesehen. Es ist möglich, die Presentation.Save(…) Methoden zu verwenden, um die Präsentationsobjekte in alle unterstützten Formate zu speichern.
### **Klassen im Zusammenhang mit Theme-Stilen in den Aspose.Slides.Theme Namespace verschoben**
Die folgenden Klassen wurden vom Namespace Aspose.Slides in den Namespace Aspose.Slides.Theme verschoben.

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Änderungen seit Aspose.Slides für .NET 8.X.0**
Die Funktionen von Aspose.Slides für .NET 8.4 wurden zu Aspose.Slides für .NET 14.2.0 hinzugefügt.