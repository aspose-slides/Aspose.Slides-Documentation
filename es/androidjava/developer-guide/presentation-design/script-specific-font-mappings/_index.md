---
title: Administrar fuentes de tema específicas de script en Android
linktitle: Fuentes de tema específicas de script
type: docs
weight: 15
url: /es/androidjava/script-specific-font-mappings/
keywords:
- fuente específica de script
- mapeo de fuentes del tema
- presentación multilingüe
- sistema de escritura
- fuente cirílica
- fuente árabe
- fuente japonesa
- fuente georgiana
- fuente thaana
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Inspeccionar, añadir, reemplazar y eliminar mapeos de fuentes específicas de script en temas de PowerPoint con Aspose.Slides para Android mediante Java."
---
## **Descripción general**

Un tema de presentación puede seleccionar distintas familias tipográficas para diferentes sistemas de escritura. Esto permite que el texto multilingüe que sigue utilizando las fuentes del tema mantenga un esquema tipográfico coordinado mientras emplea fuentes adecuadas para cirílico, árabe, japonés, georgiano, thaana y otros scripts.

El [IFontScheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontscheme/) del tema contiene una colección de fuentes mayor, típicamente usada para encabezados, y una colección de fuentes menor, típicamente usada para el cuerpo del texto. Además de sus configuraciones tipográficas para latín y Asia Oriental, ambas colecciones exponen mapeos de etiquetas de sistema de escritura a nombres de familia tipográfica mediante la interfaz [IFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifonts/).

Este artículo muestra cómo inspeccionar y modificar esos mapeos en el tema maestro de la presentación y verificar que los cambios sobrevivan a un ciclo de guardado y recarga.

## **Comprender las etiquetas de script**

Los métodos de fuentes de script utilizan subtags de script BCP 47 de cuatro letras para identificar sistemas de escritura. Los valores más comunes son:

| Etiqueta de script | Sistema de escritura |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chino simplificado |
| `Jpan` | Japonés |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Estos mapeos pertenecen al esquema de fuentes del tema, no a porciones de texto individuales. Una presentación puede definir mapeos diferentes para las colecciones mayor y menor, y puede omitir mapeos para algunos scripts.

## **Acceder e inspeccionar los mapeos de fuentes de script**

Utilice [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getMasterTheme--) para acceder al tema a nivel de presentación. Los métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontscheme/#getMajor--) y [IFontScheme.getMinor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifontscheme/#getMinor--) devuelven las dos colecciones [IFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ifonts/).

Llame a [IFonts.getScriptFontMap](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) para obtener todos los mapeos de una colección. Para buscar un sistema de escritura concreto, llame a [IFonts.getScriptFont](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) con su etiqueta de script. `getScriptFont` devuelve `null` cuando esa colección no define el mapeo solicitado.

## **Modificar los mapeos y verificar la persistencia**

Utilice [IFonts.setScriptFont](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) para crear un mapeo o reemplazar la familia tipográfica actual. Utilice [IFonts.removeScriptFont](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) para eliminar un mapeo.

El siguiente ejemplo completo lee todos los mapeos mayor y menor existentes, busca la fuente mayor japonesa, cambia la fuente mayor cirílica, elimina el mapeo menor thaana, guarda la presentación y la vuelve a abrir para verificar ambos cambios. Para que el paso de eliminación sea independiente del tema inicial, el ejemplo crea primero un mapeo thaana solo cuando no está ya definido.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

La verificación utiliza el mismo comportamiento `null` que una búsqueda ordinaria: después de guardar la eliminación, `getScriptFont("Thaa")` devuelve `null` para la colección menor.

## **Distinguir los mapeos del tema de otras configuraciones de fuente**

Los mapeos de tema específicos de script participan en la selección de fuentes, pero resuelven un problema distinto al formato directo del texto, la sustitución y la reserva de fuentes:

| Mecanismo | Propósito | Efecto de cambiar un mapeo del tema |
|---|---|---|
| Mapeo de fuente de tema específico de script | Selecciona una fuente mayor o menor del tema para un sistema de escritura. | El texto que sigue usando la fuente del tema correspondiente puede resolverse a la nueva familia asignada. |
| Fuente asignada explícitamente a una porción de texto | Fija la familia tipográfica solicitada en esa porción en lugar de depender del tema. | La porción puede permanecer sin cambios porque su formato directo anula la elección del tema. |
| Sustitución de fuentes | Reemplaza una fuente solicitada cuando esa fuente no está disponible o se aplica una regla de sustitución. | Actúa después de que se ha solicitado una fuente; no redefine el mapeo de script del tema. |
| Reserva de fuentes | Proporciona glifos que la fuente seleccionada no contiene, a menudo para rangos Unicode específicos. | Completa la cobertura de glifos faltantes; no cambia el mapeo almacenado del tema. |

Para obtener más información sobre los dos últimos mecanismos, consulte [Sustitución de fuentes](/slides/es/androidjava/font-substitution/) y [Fuentes de reserva](/slides/es/androidjava/fallback-font/).

Cambiar un mapeo en [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#getMasterTheme--) afecta solo al contenido cuyo formato efectivo sigue dependiendo de ese tema. El texto puede, en su lugar, heredar una anulación de tema de un maestro, diseño o diapositiva, o usar una fuente asignada explícitamente. Inspeccione esos niveles cuando el resultado visible no siga el mapeo a nivel de presentación.

## **Hacer que las fuentes mapeadas estén disponibles y validar el resultado**

Un mapeo de script almacena un nombre de familia tipográfica; no instala ni carga el archivo de fuente correspondiente. Para una representación y exportación consistentes, cada fuente mapeada debe estar instalada en el entorno o suministrada a Aspose.Slides a través de una fuente personalizada como [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) o [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Consulte [Fuentes personalizadas](/slides/es/androidjava/custom-font/) para conocer las opciones de carga disponibles.

Verificar el mapeo guardado confirma solo que la definición del tema se conservó. No prueba que la fuente esté disponible, que contenga todos los glifos necesarios o que produzca el diseño previsto. Renderice texto representativo para cada sistema de escritura requerido en una imagen o PDF y examine el resultado. Esto detecta fuentes faltantes, cobertura de glifos incompleta, comportamiento de reserva y cambios de diseño antes de distribuir la presentación. Consulte [Convertir presentaciones de PowerPoint](/slides/es/androidjava/convert-powerpoint/) para ejemplos de renderizado y exportación.

## **Preguntas frecuentes**

**¿Qué devuelve `getScriptFont` cuando un script no está mapeado?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) devuelve `null` cuando el mapeo de script solicitado no está definido en esa colección mayor o menor.

**¿`setScriptFont` añade un segundo mapeo cuando el script ya existe?**

No. [IFonts.setScriptFont](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) crea el mapeo cuando falta y reemplaza la familia tipográfica asignada cuando la misma etiqueta de script ya está presente.

**¿Por qué al cambiar un mapeo del tema no cambió algún texto?**

El texto puede tener una fuente asignada explícitamente, heredar un tema diferente mediante una anulación, o verse afectado por sustitución o reserva durante el renderizado. Un mapeo de script a nivel de presentación controla solo el texto cuyo formato efectivo aún hace referencia a esa colección de fuentes del tema.

**¿Bastar guardar y volver a abrir para validar la salida multilingüe?**

No. Volver a abrir verifica la persistencia de los datos del tema. Además, renderice texto representativo de cada sistema de escritura requerido para confirmar que las fuentes mapeadas están disponibles y contienen los glifos necesarios.