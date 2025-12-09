---
title: Reemplazo de fuentes - API de JavaScript para PowerPoint
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/nodejs-java/font-replacement/
description: Aprenda cómo reemplazar fuentes usando el método de reemplazo explícito en PowerPoint con la API de JavaScript.
---

## **Reemplazar fuentes**

Si cambia de opinión sobre el uso de una fuente, puede reemplazar esa fuente por otra. Todas las instancias de la fuente anterior se sustituirán por la nueva.

Aspose.Slides le permite reemplazar una fuente de la siguiente manera:

1. Cargue la presentación correspondiente.  
2. Cargue la fuente que será reemplazada.  
3. Cargue la nueva fuente.  
4. Reemplace la fuente.  
5. Guarde la presentación modificada como un archivo PPTX.

Este código JavaScript muestra la sustitución de fuentes:
```javascript
// Carga una presentación
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Carga la fuente origen que será reemplazada
    var sourceFont = new aspose.slides.FontData("Arial");
    // Carga la nueva fuente
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Reemplaza las fuentes
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Guarda la presentación
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Nota" color="warning" %}} 

Para establecer reglas que determinen qué ocurre en ciertas condiciones (por ejemplo, si una fuente no puede ser accedida), consulte [**Sustitución de fuentes**](/slides/es/nodejs-java/font-substitution/).

{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre "reemplazo de fuentes", "sustitución de fuentes" y "fuentes de respaldo"?**

El reemplazo es un cambio intencional de una familia a otra en todo el documento. La [**sustitución de fuentes**](/slides/es/nodejs-java/font-substitution/) es una regla del tipo "si la fuente no está disponible, usar X". El [**recurso de respaldo**](/slides/es/nodejs-java/fallback-font/) se aplica de forma puntual para glifos individuales ausentes cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que usan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El [**contenido OLE**](/slides/es/nodejs-java/manage-ole/) está controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente solo en una parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambia la fuente a nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica de selección de fuentes durante el renderizado permanece sin cambios.

**¿Cómo puedo determinar de antemano qué fuentes usa la presentación?**

Utilice el [administrador de fuentes]([https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/)) de la presentación: proporciona una lista de las [familias en uso]([https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getfonts/)) y información sobre [sustituciones/"fuentes desconocidas"]([https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)), lo que ayuda a planificar el reemplazo.

**¿Funciona el reemplazo de fuentes al convertir a PDF/imagenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [secuencia de selección/sustitución de fuentes](/slides/es/nodejs-java/font-selection-sequence/), por lo que un reemplazo realizado con anticipación se respetará durante la conversión.

**¿Necesito instalar la fuente objetivo en el sistema o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite [cargar fuentes externas](/slides/es/nodejs-java/custom-font/) desde carpetas de usuario para su uso durante el [renderizado y la exportación](/slides/es/nodejs-java/convert-powerpoint/).

**¿El reemplazo corregirá los “tofu” (cuadrados) en lugar de los caracteres?**

Solo si la fuente objetivo realmente contiene los glifos requeridos. De lo contrario, [configure fuentes de respaldo](/slides/es/nodejs-java/fallback-font/) para cubrir los caracteres faltantes.