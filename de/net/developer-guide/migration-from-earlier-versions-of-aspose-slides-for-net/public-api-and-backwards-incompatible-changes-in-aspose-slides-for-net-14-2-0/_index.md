---
title: Öffentliche API und nicht rückwärtskompatible Änderungen in Aspose.Slides für .NET 14.2.0
type: docs
weight: 40
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
---

## **Öffentliche API und nicht rückwärtskompatible Änderungen**
{{% alert color="primary" %}} 

Wir haben einige Änderungen an der Aspose.Slides für .NET 14.2.0 API vorgenommen. Einige Eigenschaften und Methoden wurden entfernt, und einige wurden in andere Namensräume verschoben.

{{% /alert %}} 
### **Methoden Aspose.Slides.IPresentation.Write(…) entfernt**
Diese Methoden schrieben Präsentationsobjekte nur in das PPTX-Format. In der neuen API dient die Präsentationsklasse dazu, mit allen Formaten zu arbeiten. Es ist möglich, die Methoden Presentation.Save(…) zu verwenden, um die Präsentationsobjekte in alle unterstützten Formate zu speichern.
### **Klassen, die mit Theme-Stilen verbunden sind, in den Aspose.Slides.Theme Namensraum verschoben**
Die folgenden Klassen wurden vom Aspose.Slides Namensraum in den Aspose.Slides.Theme Namensraum verschoben.

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
### **Änderungen von Aspose.Slides für .NET 8.X.0**
Die Funktionen von Aspose.Slides für .NET 8.4 wurden zu Aspose.Slides für .NET 14.2.0 hinzugefügt.