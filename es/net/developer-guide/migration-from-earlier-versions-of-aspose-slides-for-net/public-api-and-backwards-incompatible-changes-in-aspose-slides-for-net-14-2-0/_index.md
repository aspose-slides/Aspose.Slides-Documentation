---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 14.2.0
linktitle: Aspose.Slides para .NET 14.2.0
type: docs
weight: 40
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---

## **API pública y cambios incompatibles hacia atrás**
{{% alert color="primary" %}} 

Hemos realizado algunos cambios en la API de Aspose.Slides para .NET 14.2.0. Algunas propiedades y métodos se han eliminado y algunos se han trasladado a otro espacio de nombres.

{{% /alert %}} 
### **Métodos Aspose.Slides.IPresentation.Write(…) eliminados**
Estos métodos escribían objetos Presentation solo en archivos de formato PPTX. En la nueva API, la clase Presentation sirve para trabajar con todos los formatos. Es posible usar los métodos Presentation.Save(…) para guardar los objetos Presentation en todos los formatos compatibles.
### **Clases relacionadas con estilos de tema trasladadas al espacio de nombres Aspose.Slides.Theme**
Las siguientes clases se han trasladado del espacio de nombres Aspose.Slides al espacio de nombres Aspose.Slides.Theme.

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
### **Cambios desde Aspose.Slides para .NET 8.X.0**
Las características de Aspose.Slides para .NET 8.4 se han añadido a Aspose.Slides para .NET 14.2.0