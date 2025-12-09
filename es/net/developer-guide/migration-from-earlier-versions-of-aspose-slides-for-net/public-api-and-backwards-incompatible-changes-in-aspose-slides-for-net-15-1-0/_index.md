---
title: Cambios de API pública y incompatibles hacia atrás en Aspose.Slides para .NET 15.1.0
linktitle: Aspose.Slides para .NET 15.1.0
type: docs
weight: 130
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
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

{{% alert color="primary" %}} 
Esta página enumera todas las clases, métodos, propiedades, etc. [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) y demás cambios introducidos con la API de Aspose.Slides para .NET 15.1.0.
{{% /alert %}} 
## **Cambios de API pública**
#### **Se ha añadido la funcionalidad de sustitución de fuentes**
Se ha añadido la posibilidad de reemplazar fuentes de forma global en toda la presentación y temporalmente para la renderización.

Se ha introducido la nueva propiedad "FontsManager" de la clase Presentation. La clase FontsManager tiene los siguientes miembros:

**IFontSubstRuleCollection FontSubstRuleList** Property

Esta colección de instancias IFontSubstRule se usa para sustituir fuentes durante la renderización. IFontSubstRule tiene las propiedades SourceFont y DestFont que implementan la interfaz IFontData y la propiedad ReplaceFontCondition que permite elegir la condición de reemplazo ("WhenInaccessible" o "Always").

**IFontData[] GetFonts()** Method

Se usa para obtener todas las fuentes utilizadas en la presentación actual.

**ReplaceFont** Methods

Se usan para reemplazar permanentemente una fuente en la presentación.

El siguiente ejemplo muestra cómo reemplazar una fuente en la presentación:

```csharp
Presentation pres = new Presentation("PresContainsArialFont.pptx");
IFontData sourceFont = new FontData("Arial");
IFontData destFont = new FontData("Times New Roman");
pres.FontsManager.ReplaceFont(sourceFont, destFont);
pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);
```

Otro ejemplo demuestra la sustitución de fuentes para la renderización cuando la fuente no está disponible:

```csharp
Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
IFontData sourceFont = new FontData("SomeRareFont");
IFontData destFont = new FontData("Arial");
IFontSubstRule fontSubstRule = new FontSubstRule(
    sourceFont, destFont, FontSubstCondition.WhenInaccessible);
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);
pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;
// La fuente Arial se usará en lugar de SomeRareFont cuando no esté disponible
pres.Slides[0].GetThumbnail();
```