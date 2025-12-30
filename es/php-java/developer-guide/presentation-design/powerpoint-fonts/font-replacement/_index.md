---
title: Optimiza el reemplazo de fuentes en presentaciones usando PHP
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/php-java/font-replacement/
keywords:
- fuente
- reemplazar fuente
- reemplazo de fuente
- cambiar fuente
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Reemplace fuentes sin problemas en Aspose.Slides para PHP mediante Java para garantizar una tipografía coherente en presentaciones PowerPoint y OpenDocument."
---

## **Reemplazar fuentes**

Si cambias de idea respecto al uso de una fuente, puedes reemplazar esa fuente por otra. Todas las instancias de la fuente antigua se sustituirán por la fuente nueva.

Aspose.Slides permite reemplazar una fuente de la siguiente manera:

1. Carga la presentación correspondiente. 
2. Carga la fuente que será reemplazada.
3. Carga la fuente nueva. 
4. Reemplaza la fuente. 
5. Guarda la presentación modificada como un archivo PPTX.

Este código PHP muestra la sustitución de fuentes:
```php
  # Carga una presentación
  $pres = new Presentation("Fonts.pptx");
  try {
    # Carga la fuente de origen que será reemplazada
    $sourceFont = new FontData("Arial");
    # Carga la nueva fuente
    $destFont = new FontData("Times New Roman");
    # Reemplaza las fuentes
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Guarda la presentación
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Note" color="warning" %}} 
Para establecer reglas que determinen lo que ocurre en determinadas condiciones (por ejemplo, si no se puede acceder a una fuente), consulta [**Font Substitution**](/slides/es/php-java/font-substitution/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre "font replacement", "font substitution" y "fallback fonts"?**

La sustitución (replacement) es un cambio intencional de una familia a otra en todo el documento. La [Substitution](/slides/es/php-java/font-substitution/) es una regla del tipo "si la fuente no está disponible, usar X". El [Fallback](/slides/es/php-java/fallback-font/) se aplica de forma puntual a glifos individuales que faltan cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿La sustitución se aplica a diapositivas maestras, diseños, notas y comentarios?**

Sí. La sustitución afecta a todos los objetos de la presentación que usan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El [OLE content](/slides/es/php-java/manage-ole/) está controlado por su propia aplicación. La sustitución en la presentación no reformatea los datos internos del OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo sustituir una fuente solo en una parte de la presentación (por diapositivas o regiones)?**

Es posible realizar una sustitución dirigida si cambias la fuente a nivel de los objetos/rangos necesarios en lugar de aplicar una sustitución global a todo el documento. La lógica de selección de fuentes durante la renderización sigue siendo la misma.

**¿Cómo puedo determinar de antemano qué fuentes usa la presentación?**

Utiliza el [font manager]https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/ de la presentación: proporciona una lista de las [familias en uso]https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/ y información sobre [sustituciones/"fuentes desconocidas"]https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/, lo que ayuda a planificar la sustitución.

**¿Funciona la sustitución de fuentes al convertir a PDF/imágenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [font selection/substitution sequence](/slides/es/php-java/font-selection-sequence/), por lo que una sustitución realizada con antelación se respeta durante la conversión.

**¿Necesito instalar la fuente objetivo en el sistema o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite [cargar fuentes externas](/slides/es/php-java/custom-font/) desde carpetas de usuario para su uso durante la [renderización y exportación](/slides/es/php-java/convert-powerpoint/).

**¿La sustitución solucionará los “tofu” (cuadrados) en lugar de los caracteres?**

Solo si la fuente objetivo contiene realmente los glifos requeridos. Si no, [configure fallback](/slides/es/php-java/fallback-font/) para cubrir los caracteres que faltan.