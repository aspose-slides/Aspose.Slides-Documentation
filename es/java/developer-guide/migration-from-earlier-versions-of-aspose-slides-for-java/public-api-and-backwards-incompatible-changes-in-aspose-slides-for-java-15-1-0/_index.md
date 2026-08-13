---
title: Cambios en la API pública y cambios incompatibles hacia atrás en Aspose.Slides for Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides for Java para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las clases, métodos, propiedades y demás [añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) , cualquier restricción nueva y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introducidos con la API de Aspose.Slides for Java 15.1.0.

{{% /alert %}} {{% alert color="info" %}} 

Se conocen problemas con algunas viñetas de imagen y objetos WordArt que se solucionarán en Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Se ha añadido la funcionalidad de sustitución de fuentes**
Se ha añadido la posibilidad de reemplazar fuentes de forma global en toda la presentación y temporalmente para la renderización.

Se ha introducido el nuevo método getFontsManager() de la clase Presentation. La clase FontsManager tiene los siguientes miembros:

**IFontSubstRuleCollection getFontSubstRuleList**() método

Esta es la colección de instancias IFontSubstRule utilizadas para sustituir fuentes durante la renderización. IFontSubstRule tiene los métodos getSourceFont() y getDestFont() que implementan la interfaz IFontData y el método getReplaceFontCondition() que permite elegir la condición de sustitución ("WhenInaccessible" o "Always").

El método **IFontData[] getFonts()** puede usarse para obtener todas las fuentes utilizadas en la presentación actual.

Los métodos **replaceFont(...)** pueden usarse para reemplazar permanentemente una fuente en una presentación. 

El siguiente ejemplo muestra cómo reemplazar una fuente en una presentación:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Otro ejemplo muestra la sustitución de fuentes para la renderización cuando no está accesible:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // La fuente Arial se usará en lugar de SomeRareFont cuando no esté accesible.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```