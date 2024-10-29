---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para PHP a través de Java 15.1.0
type: docs
weight: 100
url: /es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/), métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introducidos con el API de Aspose.Slides para PHP a través de Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Hay problemas conocidos con algunas viñetas de imagen y objetos WordArt que serán solucionados en Aspose.Slides para PHP a través de Java 15.2.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Se ha añadido funcionalidad de sustitución de fuentes**
Se ha añadido la posibilidad de reemplazar fuentes globalmente en la presentación y temporalmente para la representación.

Se ha introducido el nuevo método getFontsManager() de la clase Presentation. La clase FontsManager tiene los siguientes miembros:

**IFontSubstRuleCollection getFontSubstRuleList**() método

Esta es la colección de instancias IFontSubstRule utilizadas para sustituir fuentes durante la representación. IFontSubstRule tiene los métodos getSourceFont() y getDestFont() que implementan la interfaz IFontData y el método getReplaceFontCondition() que permite elegir la condición de reemplazo ("WhenInaccessible" o "Always").

**IFontData[] getFonts()** método se puede utilizar para recuperar todas las fuentes utilizadas en la presentación actual.

**replaceFont(...)** métodos se pueden usar para reemplazar persistentemente una fuente en una presentación.

El siguiente ejemplo muestra cómo reemplazar una fuente en una presentación:

```php
  $pres = new Presentation("PresContainsArialFont.pptx");
  $sourceFont = new FontData("Arial");
  $destFont = new FontData("Times New Roman");
  $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
  $pres->save("PresContainsTimesNoewRomanFont.pptx", SaveFormat::Pptx);

```

Otro ejemplo, muestra la sustitución de fuentes para la representación cuando es inaccesible:

```php
  $pres = new Presentation("PresContainsSomeRareFontFont.pptx");
  $sourceFont = new FontData("SomeRareFont");
  $destFont = new FontData("Arial");
  $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
  $fontSubstRuleCollection = new FontSubstRuleCollection();
  $fontSubstRuleCollection->add($fontSubstRule);
  $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
  # Se usará la fuente Arial en lugar de SomeRareFont cuando no sea accesible
  $pres->getSlides()->get_Item(0)->getThumbnail(1, 1);

```