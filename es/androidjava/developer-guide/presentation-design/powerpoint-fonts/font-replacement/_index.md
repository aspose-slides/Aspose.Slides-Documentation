---
title: Optimizar el reemplazo de fuentes en presentaciones en Android
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/androidjava/font-replacement/
keywords:
- fuente
- reemplazar fuente
- reemplazo de fuentes
- cambiar fuente
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Reemplaza fuentes sin problemas en Aspose.Slides para Android mediante Java para garantizar una tipografía consistente en presentaciones PowerPoint y OpenDocument."
---

## **Reemplazar fuentes**

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra fuente. Todas las instancias de la fuente antigua serán reemplazadas por la nueva fuente. 

Aspose.Slides le permite reemplazar una fuente de esta manera:

1. Cargue la presentación correspondiente. 
2. Cargue la fuente que será reemplazada.
3. Cargue la nueva fuente. 
4. Reemplace la fuente. 
5. Guarde la presentación modificada como un archivo PPTX.

Este código Java demuestra el reemplazo de fuentes:
```java
// Carga una presentación
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Carga la fuente origen que será reemplazada
    IFontData sourceFont = new FontData("Arial");
    
    // Carga la nueva fuente
    IFontData destFont = new FontData("Times New Roman");
    
    // Reemplaza las fuentes
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Guarda la presentación
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Para establecer reglas que determinen qué sucede en ciertas condiciones (por ejemplo, si no se puede acceder a una fuente), consulte [**Sustitución de fuentes**](/slides/es/androidjava/font-substitution/).

{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre "reemplazo de fuentes", "sustitución de fuentes" y "fuentes de reserva"?**

El reemplazo es un cambio intencional de una familia a otra en todo el documento. [Substitution](/slides/es/androidjava/font-substitution/) es una regla como "si la fuente no está disponible, use X". [Fallback](/slides/es/androidjava/fallback-font/) se aplica de forma puntual para glifos faltantes individuales cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a las diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que utilizan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. [OLE content](/slides/es/androidjava/manage-ole/) está controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editado externamente.

**¿Puedo reemplazar una fuente solo en una parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambia la fuente a nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica de selección de fuentes general durante el renderizado permanece igual.

**¿Cómo puedo determinar de antemano qué fuentes utiliza la presentación?**

Utilice el [font manager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/): brinda una lista de los [families in use](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getFonts--) e información sobre [substitutions/"unknown" fonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), lo que ayuda a planificar el reemplazo.

**¿Funciona el reemplazo de fuentes al convertir a PDF/imágenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [font selection/substitution sequence](/slides/es/androidjava/font-selection-sequence/), por lo que un reemplazo realizado con antelación será respetado durante la conversión.

**¿Necesito instalar la fuente de destino en el sistema, o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite [loading external fonts](/slides/es/androidjava/custom-font/) desde carpetas de usuario para su uso durante [rendering and export](/slides/es/androidjava/convert-powerpoint/).

**¿El reemplazo solucionará el problema de “tofu” (cuadrados) en lugar de caracteres?**

Solo si la fuente de destino realmente contiene los glifos requeridos. De lo contrario, [configure fallback](/slides/es/androidjava/fallback-font/) para cubrir los caracteres faltantes.