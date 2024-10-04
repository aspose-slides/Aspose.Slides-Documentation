---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para .NET 15.1.0
type: docs
weight: 130
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las clases, métodos, propiedades, etc., que se [agregaron](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) o [eliminaron](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/), y otros cambios introducidos con la API de Aspose.Slides para .NET 15.1.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Se ha añadido la funcionalidad de sustitución de fuentes**
Se ha añadido la posibilidad de reemplazar una fuente de manera global en la presentación y temporalmente para la renderización.

Se ha introducido la nueva propiedad "FontsManager" de la clase Presentation. La clase FontsManager tiene los siguientes miembros:

**IFontSubstRuleCollection FontSubstRuleList** Propiedad

Esta colección de instancias de IFontSubstRule se utiliza para sustituir fuentes durante la renderización. IFontSubstRule tiene propiedades SourceFont y DestFont que implementan la interfaz IFontData, y la propiedad ReplaceFontCondition que permite elegir la condición de reemplazo ("WhenInaccessible" o "Always").

**IFontData[] GetFonts()** Método

Utilizado para recuperar todas las fuentes utilizadas en la presentación actual.

**ReplaceFont** Métodos

Utilizados para reemplazar de manera persistente la fuente en la presentación.

El siguiente ejemplo muestra cómo reemplazar una fuente en la presentación:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

``` 

Otro ejemplo, demuestra la sustitución de fuente para la renderización cuando es inaccesible:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Se utilizará la fuente Arial en lugar de SomeRareFont cuando no esté disponible

            pres.Slides[0].GetThumbnail();

``` 