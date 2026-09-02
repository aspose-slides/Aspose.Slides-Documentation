---
title: Gestionar fuentes de tema específicas de script en JavaScript
linktitle: Fuentes de tema específicas de script
type: docs
weight: 15
url: /es/nodejs-java/script-specific-font-mappings/
keywords:
- fuente de script específica
- mapeo de fuente de tema
- presentación multilingüe
- sistema de escritura
- fuente cirílica
- fuente árabe
- fuente japonesa
- fuente georgiana
- fuente thaana
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Inspeccionar, añadir, reemplazar y eliminar mapeos de fuentes específicas de script en temas de PowerPoint con Aspose.Slides para Node.js."
---
## **Resumen**

Un tema de presentación puede seleccionar diferentes familias tipográficas para distintos sistemas de escritura. Esto permite que el texto multilingüe que sigue usando las fuentes del tema mantenga un esquema tipográfico coordinado mientras utiliza fuentes adecuadas para cirílico, árabe, japonés, georgiano, thaana y otros scripts.

El [FontScheme](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontscheme/) del tema contiene una colección tipográfica principal, normalmente usada para encabezados, y una colección tipográfica secundaria, normalmente usada para el cuerpo del texto. Además de sus configuraciones tipográficas para latín y Asia Oriental, ambas colecciones exponen mapeos de etiquetas de sistema de escritura a nombres de familias tipográficas mediante la clase [Fonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fonts/).

Este artículo muestra cómo inspeccionar y modificar esos mapeos en el tema maestro de la presentación y verificar que los cambios sobrevivan a un ciclo de guardar y volver a cargar.

## **Entender las etiquetas de script**

Los métodos de fuentes de script utilizan subtags de script BCP 47 de cuatro letras para identificar los sistemas de escritura. Los valores comunes incluyen:

| Etiqueta de script | Sistema de escritura |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chino simplificado |
| `Jpan` | Japonés |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Estos mapeos pertenecen al esquema tipográfico del tema, no a porciones de texto individuales. Una presentación puede definir mapeos diferentes para las colecciones principal y secundaria, y puede omitir mapeos para algunos scripts.

## **Acceder e inspeccionar los mapeos de fuentes de script**

Use [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getmastertheme/) para acceder al tema a nivel de presentación. Los métodos [FontScheme.getMajor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontscheme/) y [FontScheme.getMinor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontscheme/) devuelven las dos colecciones de [Fonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fonts/).

Llame a [Fonts.getScriptFontMap](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fonts/) para obtener todos los mapeos de una colección. Para buscar un sistema de escritura concreto, llame a [Fonts.getScriptFont](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fonts/) con su etiqueta de script. `getScriptFont` devuelve `null` cuando esa colección no define el mapeo solicitado.

## **Modificar los mapeos y verificar la persistencia**

Use [Fonts.setScriptFont](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fonts/) para crear un mapeo o sustituir su familia tipográfica actual. Use [Fonts.removeScriptFont](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fonts/) para eliminar un mapeo.

El siguiente ejemplo de extremo a extremo lee todos los mapeos principales y secundarios existentes, busca la fuente principal japonesa, cambia la fuente principal cirílica, elimina el mapeo secundario thaana, guarda la presentación y la vuelve a abrir para verificar ambos cambios. Para que el paso de eliminación sea independiente del tema inicial, el ejemplo crea primero un mapeo thaana solo cuando no está ya definido.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

La verificación utiliza el mismo comportamiento `null` que una búsqueda ordinaria: después de que la eliminación se guarda, `getScriptFont("Thaa")` devuelve `null` para la colección secundaria.

## **Distinguir los mapeos del tema de otros ajustes tipográficos**

Los mapeos de tema específicos de script participan en la selección de fuentes, pero resuelven un problema distinto al formateo directo del texto, la sustitución y la reserva:

| Mecanismo | Propósito | Efecto de cambiar un mapeo del tema |
|---|---|---|
| Mapeo de fuente de tema específico de script | Selecciona una fuente principal o secundaria del tema para un sistema de escritura. | El texto que sigue usando la fuente del tema correspondiente puede resolverse a la nueva familia asignada. |
| Fuente asignada explícitamente a una porción de texto | Fija la familia tipográfica solicitada en esa porción en lugar de depender del tema. | La porción puede quedar sin cambios porque su formato directo sobrescribe la elección del tema. |
| Sustitución de fuentes | Reemplaza una fuente solicitada cuando esa fuente no está disponible o cuando se aplica una regla de sustitución. | Actúa después de que se ha solicitado una fuente; no redefine el mapeo de script del tema. |
| Reserva de fuentes | Proporciona glifos que la fuente seleccionada no contiene, a menudo para rangos Unicode específicos. | Rellena la cobertura de glifos faltantes; no cambia el mapeo del tema almacenado. |

Para obtener más información sobre los dos últimos mecanismos, consulte [Font Substitution](/slides/es/nodejs-java/font-substitution/) y [Fallback Fonts](/slides/es/nodejs-java/fallback-font/).

Cambiar un mapeo en [Presentation.getMasterTheme](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getmastertheme/) afecta solo al contenido cuyo formato efectivo sigue dependiendo de ese tema. El texto puede, en su lugar, heredar una anulación de tema de una diapositiva maestra, un diseño o una propia diapositiva, o usar una fuente asignada explícitamente. Inspeccione esos niveles cuando el resultado visible no siga el mapeo a nivel de presentación.

## **Hacer disponibles las fuentes mapeadas y validar el resultado**

Un mapeo de script almacena un nombre de familia tipográfica; no instala ni carga el archivo de fuente correspondiente. Para una renderización y exportación consistentes, cada fuente mapeada debe estar instalada en el entorno o suministrada a Aspose.Slides mediante una fuente personalizada como [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) o [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/). Consulte [Custom Fonts](/slides/es/nodejs-java/custom-font/) para conocer las opciones de carga disponibles.

Verificar el mapeo guardado confirma solo que la definición del tema se preservó. No prueba que la fuente esté disponible, que contenga todos los glifos requeridos o que produzca el diseño previsto. Renderice texto representativo para cada sistema de escritura requerido en una imagen o PDF y examine el resultado. Esto detecta fuentes faltantes, cobertura incompleta de glifos, comportamiento de reserva y cambios de diseño antes de distribuir la presentación. Consulte [Convert PowerPoint Presentations](/slides/es/nodejs-java/convert-powerpoint/) para ejemplos de renderizado y exportación.

## **FAQ**

**¿Qué devuelve `getScriptFont` cuando un script no está mapeado?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fonts/) devuelve `null` cuando el mapeo de script solicitado no está definido en esa colección principal o secundaria.

**¿`setScriptFont` añade un segundo mapeo cuando el script ya existe?**

No. [Fonts.setScriptFont](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fonts/) crea el mapeo cuando falta y reemplaza la familia tipográfica asignada cuando la misma etiqueta de script ya está presente.

**¿Por qué cambiar un mapeo del tema no modificó algún texto?**

El texto puede tener una fuente asignada explícitamente, heredar un tema diferente mediante una anulación, o verse afectado por sustitución o reserva durante la renderización. Un mapeo de script a nivel de presentación controla solo el texto cuyo formato efectivo aún hace referencia a esa colección de fuentes del tema.

**¿Es suficiente guardar y volver a abrir para validar la salida multilingüe?**

No. Volver a abrir verifica la persistencia de los datos del tema. También es necesario renderizar texto representativo de cada sistema de escritura requerido para confirmar que las fuentes mapeadas están disponibles y contienen los glifos necesarios.