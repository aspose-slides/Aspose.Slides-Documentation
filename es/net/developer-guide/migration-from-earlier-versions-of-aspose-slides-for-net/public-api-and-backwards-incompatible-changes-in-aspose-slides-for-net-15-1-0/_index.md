---
title: Cambios en la API pública y incompatibilidades retroactivas en Aspose.Slides para .NET 15.1.0
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
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página enumera todos los [added](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) o [removed](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) clases, métodos, propiedades y demás, y otros cambios introducidos con la API de Aspose.Slides for .NET 15.1.0 API.

{{% /alert %}} 
## **Cambios de la API Pública**
#### **Se ha añadido la funcionalidad de sustitución de fuentes**
Se ha añadido la posibilidad de reemplazar fuentes de forma global en toda la presentación y de forma temporal para la renderización.

Se ha introducido la nueva propiedad "FontsManager" de la clase Presentation. La clase FontsManager tiene los siguientes miembros:

Propiedad **IFontSubstRuleCollection FontSubstRuleList**

Esta colección de instancias IFontSubstRule se utiliza para sustituir fuentes durante la renderización. IFontSubstRule tiene las propiedades SourceFont y DestFont que implementan la interfaz IFontData y la propiedad ReplaceFontCondition que permite elegir la condición de sustitución ("WhenInaccessible" o "Always").

Método **IFontData[] GetFonts()**

Se utiliza para obtener todas las fuentes usadas en la presentación actual.

Métodos **ReplaceFont**

Se utilizan para reemplazar permanentemente una fuente en la presentación. 

El siguiente ejemplo muestra cómo reemplazar una fuente en la presentación:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Otro ejemplo muestra la sustitución de fuentes para la renderización cuando no están accesibles:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial font will be used instead of SomeRareFont when inaccessible

            pres.Slides[0].GetThumbnail();

```