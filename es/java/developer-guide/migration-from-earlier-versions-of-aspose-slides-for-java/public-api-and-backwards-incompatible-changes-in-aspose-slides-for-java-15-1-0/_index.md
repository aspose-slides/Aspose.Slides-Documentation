---
title: API público y cambios incompatibles con versiones anteriores en Aspose.Slides para Java 15.1.0
type: docs
weight: 100
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las [clases añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/), métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introducidos con la API de Aspose.Slides para Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Hay problemas conocidos con algunas viñetas de imagen y objetos WordArt que se corregirán en Aspose.Slides para Java 15.2.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Se ha añadido la funcionalidad de sustitución de fuentes**
Se ha añadido la posibilidad de reemplazar fuentes a nivel global en la presentación y de forma temporal para la renderización.

Se ha introducido un nuevo método getFontsManager() de la clase Presentation. La clase FontsManager tiene los siguientes miembros:

**IFontSubstRuleCollection getFontSubstRuleList**() método

Esta es la colección de instancias de IFontSubstRule utilizadas para sustituir fuentes durante la renderización. IFontSubstRule tiene los métodos getSourceFont() y getDestFont() que implementan la interfaz IFontData y el método getReplaceFontCondition() que permite elegir la condición de reemplazo ("WhenInaccessible" o "Always").

**IFontData[] getFonts()** método se puede utilizar para recuperar todas las fuentes utilizadas en la presentación actual.

**replaceFont(...)** métodos se pueden utilizar para reemplazar de forma persistente una fuente en una presentación.

El siguiente ejemplo muestra cómo reemplazar una fuente en una presentación:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Otro ejemplo muestra la sustitución de fuentes para la renderización cuando no está accesible:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Se utilizará la fuente Arial en lugar de SomeRareFont cuando no esté accesible

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```