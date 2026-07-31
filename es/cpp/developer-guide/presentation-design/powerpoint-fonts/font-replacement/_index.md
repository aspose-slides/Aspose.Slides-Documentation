---
title: Optimizar el reemplazo de fuentes en presentaciones usando C++
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/cpp/font-replacement/
keywords:
- fuente
- reemplazar fuente
- reemplazo de fuentes
- cambiar fuente
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Reemplaza fuentes de forma fluida en Aspose.Slides para C++ y garantiza una tipografía coherente en presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Aspose.Slides le permite reemplazar una fuente por otra en toda la presentación. Cuando se reemplaza una fuente, todas las instancias de la fuente original se cambian a la nueva fuente.

Para realizar el reemplazo de fuentes, cargue la presentación, defina la fuente origen y la fuente de sustitución, invoque el método de reemplazo de fuentes y guarde la presentación modificada como archivo PPTX. Este enfoque es útil cuando desea cambiar intencionalmente de una familia tipográfica a otra en toda la presentación.

## **Reemplazar fuentes**

Si cambia de opinión sobre el uso de una fuente, puede sustituir esa fuente por otra. Todas las instancias de la fuente antigua serán reemplazadas por la nueva.

Aspose.Slides le permite reemplazar una fuente de la siguiente manera:

1. Cargue la presentación correspondiente. 
2. Cargue la fuente que será reemplazada. 
3. Cargue la nueva fuente. 
4. Reemplace la fuente. 
5. Guarde la presentación modificada como archivo PPTX.

Este código C++ muestra el reemplazo de fuentes:

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

Para establecer reglas que determinen qué ocurre en determinadas condiciones (por ejemplo, si no se puede acceder a una fuente), consulte [**Font Substitution**](/slides/es/cpp/font-substitution/). 

{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre "reemplazo de fuentes", "sustitución de fuentes" y "fuentes de reserva"?**

El reemplazo es un cambio intencional de una familia a otra en todo el documento. [Substitution](/slides/es/cpp/font-substitution/) es una regla como "si la fuente no está disponible, usar X". [Fallback](/slides/es/cpp/fallback-font/) se aplica de forma puntual para glifos ausentes cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que usan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El [contenido OLE](/slides/es/cpp/manage-ole/) es controlado por su propia aplicación. El reemplazo en la presentación no re-formatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente solo en una parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambia la fuente al nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica de selección de fuentes durante el renderizado sigue siendo la misma.

**¿Cómo puedo determinar de antemano qué fuentes utiliza la presentación?**

Utilice el [font manager] de la presentación (https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/): ofrece una lista de las [familias en uso](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/getfonts/) e información sobre [sustituciones/"fuentes desconocidas"](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsmanager/getsubstitutions/), lo que ayuda a planificar el reemplazo.

**¿Funciona el reemplazo de fuentes al convertir a PDF/imagenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma [secuencia de selección/sustitución de fuentes](/slides/es/cpp/font-selection-sequence/), por lo que un reemplazo realizado con antelación será respetado durante la conversión.

**¿Necesito instalar la fuente objetivo en el sistema o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite [cargar fuentes externas](/slides/es/cpp/custom-font/) desde carpetas de usuario para su uso durante el [renderizado y exportación](/slides/es/cpp/convert-powerpoint/).

**¿El reemplazo eliminará los "tofu" (cuadrados) en lugar de los caracteres?**

Solo si la fuente objetivo contiene realmente los glifos requeridos. En caso contrario, [configure fallback](/slides/es/cpp/fallback-font/) para cubrir los caracteres faltantes.