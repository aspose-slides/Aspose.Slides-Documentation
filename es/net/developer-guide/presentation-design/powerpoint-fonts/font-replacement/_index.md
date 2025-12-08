---
title: Reemplazo de fuentes - PowerPoint C# API
linktitle: Reemplazo de fuentes
type: docs
weight: 60
url: /es/net/font-replacement/
keywords: "Fuente, reemplazar fuente, presentación PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: Con la API de PowerPoint C#, puedes reemplazar una fuente explícitamente con otra fuente en la presentación.
---

## **Reemplazar fuentes**

Si cambia de idea sobre el uso de una fuente, puede reemplazar esa fuente por otra. Todas las instancias de la fuente antigua serán sustituidas por la nueva.

Aspose.Slides le permite reemplazar una fuente de esta manera:

1. Cargue la presentación correspondiente.  
2. Cargue la fuente que será reemplazada.  
3. Cargue la nueva fuente.  
4. Reemplace la fuente.  
5. Guarde la presentación modificada como archivo PPTX.

Este código C# demuestra el reemplazo de fuentes:
```c#
// Carga una presentación
Presentation presentation = new Presentation("Fonts.pptx");

// Carga la fuente origen que será reemplazada
IFontData sourceFont = new FontData("Arial");

// Carga la nueva fuente
IFontData destFont = new FontData("Times New Roman");

// Reemplaza las fuentes
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Guarda la presentación
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```


{{% alert title="Nota" color="warning" %}} 

Para establecer reglas que determinen qué ocurre en ciertas condiciones (por ejemplo, si una fuente no puede ser accedida), consulte **[Sustitución de fuentes](/slides/es/net/font-substitution/)**. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre "reemplazo de fuentes", "sustitución de fuentes" y "fuentes de respaldo"?**

El reemplazo es un cambio intencional de una familia a otra en todo el documento. **[Sustitución](/slides/es/net/font-substitution/)** es una regla como "si la fuente no está disponible, usar X". **[Fuentes de respaldo](/slides/es/net/fallback-font/)** se aplican de forma puntual para glifos individuales faltantes cuando la fuente base está instalada pero no contiene los caracteres requeridos.

**¿El reemplazo se aplica a diapositivas maestras, diseños, notas y comentarios?**

Sí. El reemplazo afecta a todos los objetos de la presentación que usan la fuente original, incluidas las diapositivas maestras y las notas; los comentarios también forman parte del documento y son tenidos en cuenta por el motor de fuentes.

**¿Cambiará la fuente dentro de objetos OLE incrustados (por ejemplo, Excel)?**

No. El **[contenido OLE](/slides/es/net/manage-ole/)** es controlado por su propia aplicación. El reemplazo en la presentación no reformatea los datos internos de OLE; pueden mostrarse como una imagen o como contenido editable externamente.

**¿Puedo reemplazar una fuente sólo en parte de la presentación (por diapositivas o regiones)?**

El reemplazo dirigido es posible si cambia la fuente a nivel de los objetos/rangos requeridos en lugar de aplicar un reemplazo global a todo el documento. La lógica general de selección de fuentes durante la renderización permanece igual.

**¿Cómo puedo determinar de antemano qué fuentes usa la presentación?**

Utilice el **[administrador de fuentes]**(https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) de la presentación: proporciona una lista de las **[familias en uso]**(https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) y información sobre las **[sustituciones/"fuentes desconocidas"]**(https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/), lo que ayuda a planificar el reemplazo.

**¿Funciona el reemplazo de fuentes al convertir a PDF/imágenes?**

Sí. Durante la exportación, Aspose.Slides aplica la misma **[secuencia de selección/sustitución de fuentes](/slides/es/net/font-selection-sequence/)**, por lo que un reemplazo realizado previamente será respetado durante la conversión.

**¿Necesito instalar la fuente objetivo en el sistema o puedo adjuntar una carpeta de fuentes?**

No es necesario instalarla: la biblioteca permite **[cargar fuentes externas](/slides/es/net/custom-font/)** desde carpetas del usuario para su uso durante la **[renderización y exportación](/slides/es/net/convert-powerpoint/)**.

**¿El reemplazo solucionará los “tofu” (cuadrados) en lugar de los caracteres?**

Solo si la fuente objetivo realmente contiene los glifos requeridos. De lo contrario, **[configure fuentes de respaldo](/slides/es/net/fallback-font/)** para cubrir los caracteres faltantes.