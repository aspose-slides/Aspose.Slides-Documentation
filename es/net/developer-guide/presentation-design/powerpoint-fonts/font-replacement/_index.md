---
title: Optimizar el reemplazo de fuentes en presentaciones en .NET
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/net/font-replacement/
keywords:
- fuente
- reemplazar fuente
- reemplazo de fuentes
- cambiar fuente
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Reemplace fuentes de forma fluida en Aspose.Slides para .NET y garantice una tipografía coherente en presentaciones de PowerPoint y OpenDocument."
---

## **Reemplazar fuentes**

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra. Todas las instancias de la fuente antigua se reemplazarán por la nueva. 

Aspose.Slides le permite reemplazar una fuente de esta manera:

1. Cargue la presentación correspondiente. 
2. Cargue la fuente que será reemplazada.
3. Cargue la nueva fuente. 
4. Reemplace la fuente. 
5. Guarde la presentación modificada como un archivo PPTX.

Este código C# muestra el reemplazo de fuentes:
```c#
// Carga una presentación
Presentation presentation = new Presentation("Fonts.pptx");

// Carga la fuente de origen que será reemplazada
IFontData sourceFont = new FontData("Arial");

// Carga la nueva fuente
IFontData destFont = new FontData("Times New Roman");

// Reemplaza las fuentes
presentation.FontsManager.ReplaceFont(sourceFont, destFont");

// Guarda la presentación
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```


{{% alert title="Note" color="warning" %}} 

Para establecer reglas que determinen qué ocurre en ciertas condiciones (por ejemplo, si no se puede acceder a una fuente), vea [**Sustitución de fuentes**](/slides/es/net/font-substitution/). 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre "reemplazo de fuentes", "sustitución de fuentes" y "fuentes de reserva"?**

El reemplazo es un cambio deliberado de una familia a otra en todo el documento. [Sustitución](/slides/es/net/font-substitution/) es una regla como “si la fuente no está disponible, usar X”. [Reserva](/slides/es/net/fallback-font/) se aplica de forma puntual para glifos faltantes individuales cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que utilizan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El [contenido OLE](/slides/es/net/manage-ole/) está controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente solo en una parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambia la fuente a nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica general de selección de fuentes durante el renderizado permanece igual.

**¿Cómo puedo determinar de antemano qué fuentes utiliza la presentación?**

Utilice el [administrador de fuentes](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) de la presentación: proporciona una lista de las [familias en uso](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) e información sobre [sustituciones/fuentes "desconocidas"](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/), lo que ayuda a planificar el reemplazo.

**¿Funciona el reemplazo de fuentes al convertir a PDF/imágenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [secuencia de selección/sustitución de fuentes](/slides/es/net/font-selection-sequence/), por lo que un reemplazo realizado con antelación se respetará durante la conversión.

**¿Necesito instalar la fuente objetivo en el sistema o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite [cargar fuentes externas](/slides/es/net/custom-font/) desde carpetas de usuario para su uso durante el [renderizado y la exportación](/slides/es/net/convert-powerpoint/).

**¿El reemplazo corregirá los “tofu” (cuadrados) en lugar de los caracteres?**

Solo si la fuente objetivo contiene realmente los glifos requeridos. Si no, [configure la reserva](/slides/es/net/fallback-font/) para cubrir los caracteres faltantes.