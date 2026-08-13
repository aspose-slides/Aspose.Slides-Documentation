---
title: Öffentliche API und rückwärts inkompatible Änderungen in Aspose.Slides für .NET 14.2.0
linktitle: Aspose.Slides für .NET 14.2.0
type: docs
weight: 40
url: /de/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- Migration
- Legacy-Code
- moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie die Aktualisierungen der öffentlichen API und die Breaking Changes in Aspose.Slides für .NET, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
## **Öffentliche API und rückwärts inkompatible Änderungen**
{{% alert color="info" %}} 

Wir haben einige Änderungen an der Aspose.Slides für .NET 14.2.0 API vorgenommen. Einige Eigenschaften und Methoden wurden entfernt und einige wurden in einen anderen Namensraum verschoben.

{{% /alert %}} 
### **Methoden Aspose.Slides.IPresentation.Write(…) entfernt**
Diese Methoden schrieben Präsentationsobjekte ausschließlich in PPTX‑Dateien. In der neuen API dient die Klasse Presentation zur Arbeit mit allen Formaten. Es ist möglich, die Methoden Presentation.Save(…) zu verwenden, um die Präsentationsobjekte in allen unterstützten Formaten zu speichern.
### **Klassen im Zusammenhang mit Theme‑Stilen in den Namensraum Aspose.Slides.Theme verschoben**
Die folgenden Klassen wurden vom Namensraum Aspose.Slides in den Namensraum Aspose.Slides.Theme verschoben.

- Typen ColorScheme
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
Funktionen von Aspose.Slides für .NET 8.4 wurden zu Aspose.Slides für .NET 14.2.0 hinzugefügt.