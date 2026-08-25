---
title: Gestionar fuentes de tema específicas de script en Java
linktitle: Fuentes de tema específicas de script
type: docs
weight: 15
url: /es/java/script-specific-font-mappings/
keywords:
- fuente de tema específica de script
- asignación de fuente de tema
- presentación multilingüe
- sistema de escritura
- fuente cirílica
- fuente árabe
- fuente japonesa
- fuente georgiana
- fuente thaana
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Inspeccionar, añadir, sustituir y eliminar asignaciones de fuentes específicas de script en los temas de PowerPoint con Aspose.Slides para Java."
---
## **Descripción general**

Un tema de presentación puede seleccionar diferentes familias tipográficas para distintos sistemas de escritura. Esto permite que el texto multilingüe que sigue utilizando las fuentes del tema siga un esquema tipográfico coordinado mientras emplea fuentes adecuadas para cirílico, árabe, japonés, georgiano, thaana y otros sistemas de escritura.

El [IFontScheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontscheme/) del tema contiene una colección de fuentes principal, normalmente utilizada para los encabezados, y una colección de fuentes secundaria, normalmente utilizada para el cuerpo del texto. Además de sus configuraciones tipográficas para Latin y Este de Asia, ambas colecciones exponen asignaciones de etiquetas de sistemas de escritura a nombres de familias tipográficas mediante la interfaz [IFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifonts/).

Este artículo muestra cómo inspeccionar y modificar esas asignaciones en el tema maestro de la presentación y verificar que los cambios sobrevivan a un ciclo de guardado y recarga.

## **Comprender las etiquetas de script**

Los métodos de fuentes de script utilizan subtags de script BCP 47 de cuatro letras para identificar los sistemas de escritura. Los valores más comunes incluyen:

| Script tag | Sistema de escritura |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chino simplificado |
| `Jpan` | Japonés |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Estas asignaciones pertenecen al esquema tipográfico del tema, no a porciones individuales de texto. Una presentación puede definir distintas asignaciones para las colecciones principal y secundaria, y puede omitir asignaciones para algunos scripts.

## **Acceder e inspeccionar las asignaciones de fuentes de script**

Utilice [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getMasterTheme--) para acceder al tema a nivel de presentación. Los métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontscheme/#getMajor--) y [IFontScheme.getMinor](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontscheme/#getMinor--) devuelven las dos colecciones [IFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifonts/).

Llame a [IFonts.getScriptFontMap](https://reference.aspose.com/slides/es/java/com.aspose.slides/fonts/#getScriptFontMap--) para obtener todas las asignaciones de una colección. Para buscar un sistema de escritura, llame a [IFonts.getScriptFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) con su etiqueta de script. `getScriptFont` devuelve `null` cuando esa colección no define la asignación solicitada.

## **Modificar asignaciones y verificar la persistencia**

Utilice [IFonts.setScriptFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) para crear una asignación o reemplazar su familia tipográfica actual. Utilice [IFonts.removeScriptFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) para eliminar una asignación.

El siguiente ejemplo de extremo a extremo lee todas las asignaciones principales y secundarias existentes, busca la fuente principal japonesa, cambia la fuente principal cirílica, elimina la asignación secundaria de Thaana, guarda la presentación y la vuelve a abrir para verificar ambos cambios. Para que el paso de eliminación sea independiente del tema inicial, el ejemplo primero crea una asignación de Thaana solo cuando no está ya definida.

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

La verificación utiliza el mismo comportamiento `null` que una búsqueda ordinaria: después de que la eliminación se guarda, `getScriptFont("Thaa")` devuelve `null` para la colección secundaria.

## **Distinguir las asignaciones del tema de otros ajustes tipográficos**

Las asignaciones de tema específicas de script participan en la selección de fuentes, pero resuelven un problema diferente al del formato de texto directo, sustitución y fallback:

| Mecanismo | Propósito | Efecto de cambiar una asignación del tema |
|---|---|---|
| Asignación de fuente de tema específica de script | Selecciona una fuente de tema principal o secundaria para un sistema de escritura. | El texto que sigue usando la fuente del tema correspondiente puede resolverse a la nueva familia asignada. |
| Fuente asignada explícitamente a una porción de texto | Fija la familia tipográfica solicitada en esa porción en lugar de depender del tema. | La porción puede permanecer sin cambios porque su formato directo anula la elección del tema. |
| Sustitución de fuentes | Reemplaza una fuente solicitada cuando esa fuente no está disponible o cuando se aplica una regla de sustitución. | Actúa después de que se ha solicitado una fuente; no redefine la asignación de script del tema. |
| Fallback de fuentes | Proporciona glifos que la fuente seleccionada no contiene, a menudo para rangos Unicode específicos. | Rellena la cobertura de glifos faltantes; no cambia la asignación del tema almacenada. |

Para obtener más información sobre los dos últimos mecanismos, consulte [Font Substitution](/slides/es/java/font-substitution/) y [Fallback Fonts](/slides/es/java/fallback-font/).

Cambiar una asignación en [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getMasterTheme--) afecta solo al contenido cuyo formato efectivo todavía depende de ese tema. El texto puede, en su lugar, heredar una anulación de tema de un maestro, diseño o diapositiva, o usar una fuente asignada explícitamente. Inspeccione esos niveles cuando el resultado visible no siga la asignación a nivel de presentación.

## **Hacer que las fuentes asignadas estén disponibles y validar el resultado**

Una asignación de script almacena un nombre de familia tipográfica; no instala ni carga el archivo de fuente correspondiente. Para una representación y exportación coherentes, cada fuente asignada debe estar instalada en el entorno o suministrada a Aspose.Slides mediante una fuente personalizada como [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) o [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Consulte [Custom Fonts](/slides/es/java/custom-font/) para conocer las opciones de carga disponibles.

Verificar la asignación guardada confirma sólo que la definición del tema se preservó. No prueba que la fuente esté disponible, que contenga todos los glifos requeridos o que produzca el diseño previsto. Renderice texto representativo para cada sistema de escritura requerido a una imagen o PDF e inspeccione el resultado. Esto detecta fuentes ausentes, cobertura de glifos incompleta, comportamiento de fallback y cambios de diseño antes de distribuir la presentación. Consulte [Convert PowerPoint Presentations](/slides/es/java/convert-powerpoint/) para ejemplos de renderizado y exportación.

## **FAQ**

**¿Qué devuelve `getScriptFont` cuando un script no está asignado?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) devuelve `null` cuando la asignación de script solicitada no está definida en esa colección de fuentes principal o secundaria.

**¿`setScriptFont` añade una segunda asignación cuando el script ya existe?**

No. [IFonts.setScriptFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) crea la asignación cuando falta y reemplaza la familia tipográfica asignada cuando la misma etiqueta de script ya está presente.

**¿Por qué al cambiar una asignación del tema no se modificó cierto texto?**

El texto puede tener una fuente asignada explícitamente, heredar un tema diferente mediante una anulación, o verse afectado por sustitución o fallback durante el renderizado. Una asignación de script a nivel de presentación controla sólo el texto cuyo formato efectivo aún hace referencia a esa colección de fuentes del tema.

**¿Es suficiente guardar y volver a abrir para validar la salida multilingüe?**

No. Volver a abrir verifica la persistencia de los datos del tema. Además, renderice texto representativo de cada sistema de escritura requerido para confirmar que las fuentes asignadas están disponibles y contienen los glifos necesarios.