---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 14.2.0
type: docs
weight: 40
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
---

## **API Pública y Cambios Incompatibles Hacia Atrás**
{{% alert color="primary" %}} 

Hemos realizado algunos cambios en la API de Aspose.Slides para .NET 14.2.0. Se han eliminado algunas propiedades y métodos y algunos han sido trasladados a otro espacio de nombres.

{{% /alert %}} 
### **Métodos Aspose.Slides.IPresentation.Write(…) Eliminados**
Estos métodos escribían objetos Presentation solo en archivos de formato PPTX. En la nueva API, la clase Presentation es para trabajar con todos los formatos. Es posible utilizar los métodos Presentation.Save(…) para guardar los objetos Presentation en todos los formatos compatibles.
### **Clases Relacionadas con Estilos de Tema Trasladadas al Espacio de Nombres Aspose.Slides.Theme**
Las siguientes clases han sido trasladadas del espacio de nombres Aspose.Slides al espacio de nombres Aspose.Slides.Theme.

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
### **Cambios de Aspose.Slides para .NET 8.X.0**
Las características de Aspose.Slides para .NET 8.4 se han añadido a Aspose.Slides para .NET 14.2.0