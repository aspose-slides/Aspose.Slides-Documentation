---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.1.0
linktitle: Aspose.Slides para .NET 15.1.0
type: docs
weight: 130
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migración
- código legado
- código moderno
- enfoque legado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc., [added](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) o [removed](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) y demás cambios introducidos con la API de Aspose.Slides for .NET 15.1.0.

{{% /alert %}} 
## **Cambios de la API pública**
#### **Se ha añadido la funcionalidad de sustitución de fuentes**
Se ha añadido la posibilidad de sustituir fuentes globalmente en toda la presentación y de forma temporal para la renderización.

Se ha introducido la nueva propiedad "FontsManager" de la clase Presentation. La clase FontsManager tiene los siguientes miembros:

**IFontSubstRuleCollection FontSubstRuleList** Property

Esta colección de instancias IFontSubstRule se utiliza para sustituir fuentes durante la renderización. IFontSubstRule tiene las propiedades SourceFont y DestFont que implementan la interfaz IFontData y la propiedad ReplaceFontCondition que permite elegir la condición de sustitución ("WhenInaccessible" o "Always").

**IFontData[] GetFonts()** Method

Se usa para obtener todas las fuentes utilizadas en la presentación actual.

**ReplaceFont** Methods

Se usa para sustituir una fuente de forma persistente en la presentación.

El siguiente ejemplo muestra cómo sustituir una fuente en la presentación:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Otro ejemplo demuestra la sustitución de fuentes para la renderización cuando la fuente no está accesible:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // La fuente Arial se usará en lugar de SomeRareFont cuando sea inaccesible

            pres.Slides[0].GetImage();

```