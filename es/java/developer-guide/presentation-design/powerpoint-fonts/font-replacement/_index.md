---
title: Optimiza el reemplazo de fuentes en presentaciones usando Java
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/java/font-replacement/
keywords:
- fuente
- reemplazar fuente
- reemplazo de fuentes
- cambiar fuente
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Reemplaza fuentes sin problemas en Aspose.Slides para Java y garantiza una tipografía coherente en presentaciones PowerPoint y OpenDocument."
---

## **Reemplazar fuentes**

Si cambia de opinión respecto a usar una fuente, puede reemplazar esa fuente por otra. Todas las instancias de la fuente antigua serán sustituidas por la nueva fuente. 

Aspose.Slides le permite reemplazar una fuente de esta manera:

1. Cargue la presentación correspondiente. 
2. Cargue la fuente que será reemplazada.
3. Cargue la nueva fuente. 
4. Reemplace la fuente. 
5. Guarde la presentación modificada como un archivo PPTX.

Este código Java muestra el reemplazo de fuentes:
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

Para establecer reglas que determinen lo que ocurre en ciertas condiciones (por ejemplo, si no se puede acceder a una fuente), consulte [**Sustitución de fuentes**](/slides/es/java/font-substitution/). 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre "reemplazo de fuentes", "sustitución de fuentes" y "fuentes de reserva"?**

El reemplazo es un cambio intencional de una familia a otra en todo el documento. [Sustitución](/slides/es/java/font-substitution/) es una regla como "si la fuente no está disponible, usar X". [Reserva](/slides/es/java/fallback-font/) se aplica de forma puntual para glifos faltantes individuales cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a las diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que usan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El [contenido OLE](/slides/es/java/manage-ole/) está controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos del OLE; puede mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente solo en parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambia la fuente a nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica general de selección de fuentes durante el renderizado sigue siendo la misma.

**¿Cómo puedo determinar de antemano qué fuentes usa la presentación?**

Utilice el [administrador de fuentes]https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/ de la presentación: proporciona una lista de las [familias en uso]https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getFonts-- y información sobre [sustituciones/"fuentes desconocidas"]https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getSubstitutions--, lo que ayuda a planificar el reemplazo.

**¿Funciona el reemplazo de fuentes al convertir a PDF/imágenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [secuencia de selección/sustitución de fuentes](/slides/es/java/font-selection-sequence/), de modo que un reemplazo realizado con anticipación será respetado durante la conversión.

**¿Necesito instalar la fuente de destino en el sistema o puedo adjuntar una carpeta de fuentes?**

No es necesaria la instalación: la biblioteca permite [cargar fuentes externas](/slides/es/java/custom-font/) desde carpetas de usuario para su uso durante el [renderizado y la exportación](/slides/es/java/convert-powerpoint/).

**¿El reemplazo corregirá el "tofu" (cuadrados) en lugar de los caracteres?**

Solo si la fuente de destino realmente contiene los glifos requeridos. De lo contrario, [configure la reserva](/slides/es/java/fallback-font/) para cubrir los caracteres faltantes.