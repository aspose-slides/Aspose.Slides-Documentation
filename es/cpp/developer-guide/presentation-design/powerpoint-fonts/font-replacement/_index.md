---
title: Optimizar el reemplazo de fuentes en presentaciones usando С++
linktitle: Reemplazo de fuente
type: docs
weight: 60
url: /es/cpp/font-replacement/
keywords:
- fuente
- reemplazar fuente
- reemplazo de fuente
- cambiar fuente
- PowerPoint
- OpenDocument
- presentación
- С++
- Aspose.Slides
description: "Reemplace fuentes de forma fluida en Aspose.Slides para С++ y garantice una tipografía coherente en presentaciones de PowerPoint y OpenDocument."
---

## **Reemplazar fuentes**

Si cambias de opinión sobre el uso de una fuente, puedes reemplazar esa fuente por otra. Todas las instancias de la fuente antigua serán sustituidas por la nueva. 

Aspose.Slides permite reemplazar una fuente de esta manera:

1. Cargar la presentación relevante. 
2. Cargar la fuente que será reemplazada.
3. Cargar la nueva fuente. 
4. Reemplazar la fuente. 
5. Guardar la presentación modificada como archivo PPTX.

Este código C++ demuestra el reemplazo de fuentes:
``` cpp
// Carga una presentación
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Carga la fuente origen que será reemplazada
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Carga la nueva fuente
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Reemplaza las fuentes
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Guarda la presentación
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

Para establecer reglas que determinen qué ocurre en ciertas condiciones (por ejemplo, si una fuente no se puede acceder), consulta [**Sustitución de fuentes**](/slides/es/cpp/font-substitution/). 

{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre "reemplazo de fuentes", "sustitución de fuentes" y "fuentes de reserva"?**

El reemplazo es un cambio intencional de una familia a otra en todo el documento. [Sustitución](/slides/es/cpp/font-substitution/) es una regla del tipo "si la fuente no está disponible, usar X". [Reserva](/slides/es/cpp/fallback-font/) se aplica de forma puntual para glifos faltantes cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que usan la fuente original, incluidas las diapositivas maestras y notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El [contenido OLE](/slides/es/cpp/manage-ole/) está controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente solo en parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambias la fuente a nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica general de selección de fuentes durante el renderizado permanece igual.

**¿Cómo puedo determinar de antemano qué fuentes usa la presentación?**

Utiliza el [administrador de fuentes](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/): proporciona una lista de las [familias en uso](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/) e información sobre [sustituciones/"fuentes desconocidas"](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getsubstitutions/), lo que ayuda a planificar el reemplazo.

**¿El reemplazo de fuentes funciona al convertir a PDF/imagenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [secuencia de selección/sustitución de fuentes](/slides/es/cpp/font-selection-sequence/), por lo que un reemplazo realizado previamente será respetado durante la conversión.

**¿Necesito instalar la fuente objetivo en el sistema, o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite [cargar fuentes externas](/slides/es/cpp/custom-font/) desde carpetas de usuario para su uso durante el [renderizado y la exportación](/slides/es/cpp/convert-powerpoint/).

**¿El reemplazo corregirá el "tofu" (cuadrados) en lugar de los caracteres?**

Solo si la fuente objetivo realmente contiene los glifos requeridos. De lo contrario, [configure la reserva](/slides/es/cpp/fallback-font/) para cubrir los caracteres faltantes.