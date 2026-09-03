---
title: Incrustar fuentes en presentaciones en Java
linktitle: Fuentes incrustadas
type: docs
weight: 40
url: /es/java/embedded-font/
keywords:
- añadir fuente
- incrustar fuente
- incrustación de fuentes
- obtener fuente incrustada
- añadir fuente incrustada
- eliminar fuente incrustada
- comprimir fuente incrustada
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Gestiona fuentes incrustadas en PowerPoint con Aspose.Slides para Java. Añade, recupera, elimina y comprime fuentes para preservar la apariencia del texto y reducir el tamaño del archivo."
---
## **Introducción**

Incrustar fuentes almacena los datos de la fuente dentro de una presentación de PowerPoint. Cuando un visor admite fuentes incrustadas, puede mostrar el texto usando esas fuentes aunque no estén instaladas en el sistema de destino. Esto ayuda a conservar los saltos de línea, el espaciado del texto y el diseño de la diapositiva.

Aspose.Slides for Java le permite obtener, añadir y eliminar fuentes incrustadas a través de la interfaz [IFontsManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/) devuelta por [Presentation.getFontsManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/#getFontsManager--). También puede reducir el tamaño de los datos de fuentes incrustadas eliminando los caracteres que la presentación no utiliza.

Los ejemplos a continuación funcionan con archivos PPTX. Antes de incrustar una fuente, asegúrese de que sus datos de fuente estén disponibles para Aspose.Slides y de que su licencia permita la incrustación.

## **Obtener y eliminar fuentes incrustadas**

Utilice [getEmbeddedFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) para enumerar las fuentes almacenadas en una presentación. Para eliminar una, pase una fuente de esa lista a [removeEmbeddedFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), y luego guarde la presentación.

El siguiente ejemplo enumera las fuentes incrustadas en `EmbeddedFonts.pptx` y elimina Calibri si está presente:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Eliminar una fuente incrustada quita sus datos de fuente almacenados; no cambia la fuente asignada al texto. Si la fuente está instalada en el sistema de destino, el texto puede seguir utilizándola. De lo contrario, la representación puede requerir [sustitución de fuentes](/slides/es/java/font-substitution/), lo que puede afectar el diseño.

## **Inspeccionar datos de fuente y permisos de incrustación**

Utilice la interfaz [IFontsManager](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/) para inspeccionar las fuentes antes de incrustarlas. Llame a [IFontsManager.getFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#getFonts--) para obtener las fuentes usadas en la presentación. Para cada fuente, pase un objeto [IFontData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontdata/) y el valor requerido de [FontStyleType](https://reference.aspose.com/slides/es/java/com.aspose.slides/fontstyletype/) a [IFontsManager.getFontBytes](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). El método devuelve los datos binarios de ese estilo de fuente, o `null` cuando la fuente o el estilo solicitado no están disponibles. No pase un resultado `null` a [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), porque ese método requiere una matriz de bytes.

[EmbeddingLevel](https://reference.aspose.com/slides/es/java/com.aspose.slides/embeddinglevel/) es una enumeración de banderas que informa de las restricciones de incrustación almacenadas en la fuente:

- `Installable` permite la incrustación y la instalación permanente en otro sistema, sujeto a la licencia de la fuente.
- `Restricted` prohíbe la incrustación a menos que se obtenga permiso del propietario legal de la fuente cuando es la única bandera de permiso de uso.
- `PreviewPrint` permite el uso temporal para visualización e impresión; un documento que contenga la fuente debe ser de solo lectura.
- `Editable` permite el uso temporal y permite que el documento se edite y guarde.
- `NoSubsetting` es una restricción adicional que prohíbe incrustar solo un subconjunto de glifos. Incruste todos los caracteres cuando esté presente esta bandera.
- `BitmapOnly` es una restricción adicional que solo permite incrustar golpes de mapa de bits, no datos de contorno. Si la fuente no tiene golpes de mapa de bits, no puede ser incrustada.

Los cuatro primeros valores describen el permiso de uso, mientras que `NoSubsetting` y `BitmapOnly` pueden combinarse con ellos. Compruebe los modificadores con operaciones bit a bit. Dado que `Installable` es cero, enmascare los bits de permiso de uso y compare el resultado con `Installable` en lugar de comprobarlo como una bandera. Las fuentes actuales deben establecer como máximo un bit de permiso de uso. Para compatibilidad con fuentes más antiguas que establecen más de uno, el asistente a continuación selecciona el permiso menos restrictivo: `Editable`, luego `PreviewPrint`, luego `Restricted`.

El siguiente ejemplo audita los datos regular, negrita, cursiva y negrita‑cursiva disponibles para cada fuente devuelta por `getFonts`. Omite estilos no disponibles, fuentes restringidas, fuentes solo‑bitmap, fuentes limitadas a vista previa e impresión porque la salida sigue siendo editable, y fuentes ya incrustadas. Si algún estilo disponible tiene `NoSubsetting`, incrusta todos los caracteres para esa familia de fuentes.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Esta inspección informa de las restricciones codificadas en cada archivo de fuente. No otorga una licencia, no prueba que haya obtenido la fuente legalmente, ni sustituye la revisión del acuerdo de licencia de la fuente antes de distribuir una copia incrustada.

## **Añadir fuentes incrustadas**

Utilice [addEmbeddedFont](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) para incrustar una fuente. Sus sobrecargas aceptan ya sea un objeto [IFontData](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontdata/) o una matriz de bytes que contiene los datos de la fuente. La enumeración [EmbedFontCharacters](https://reference.aspose.com/slides/es/java/com.aspose.slides/embedfontcharacters/) controla qué caracteres se incluyen:

- [All](https://reference.aspose.com/slides/es/java/com.aspose.slides/embedfontcharacters/) incrusta todos los caracteres de la fuente. Use esta opción cuando los destinatarios necesiten editar la presentación e introducir texto nuevo.
- [OnlyUsed](https://reference.aspose.com/slides/es/java/com.aspose.slides/embedfontcharacters/) incrusta solo los caracteres usados en la presentación para reducir el tamaño del archivo. Elija esta opción para una presentación final que esté destinada principalmente a la visualización.

El siguiente ejemplo usa [getFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#getFonts--) para obtener las fuentes usadas en `Fonts.pptx` y las incrusta si aún no lo están. Las fuentes a añadir deben estar disponibles en la máquina que ejecuta el código. Las fuentes incrustadas existentes conservan sus conjuntos de caracteres actuales.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprimir fuentes incrustadas**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/es/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) reduce los datos de fuentes incrustadas eliminando los caracteres no usados. Actúa sobre fuentes que ya están incrustadas, por lo que la reducción de tamaño depende de cuántos datos de fuente no utilizados contenga la presentación.

El siguiente ejemplo comprime las fuentes en `EmbeddedFonts.pptx` y guarda el resultado como un archivo separado:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Conserve el archivo original si los destinatarios pueden necesitar añadir texto más tarde. Los caracteres eliminados durante la compresión ya no están disponibles en la fuente incrustada, incluso si originalmente incrustó todos los caracteres.

## **FAQ**

**¿Cómo puedo comprobar si una fuente incrustada seguirá siendo sustituida durante la representación?**

Llame a [getSubstitutions](https://reference.aspose.com/slides/es/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) en el entorno donde renderice la presentación para ver qué fuentes Aspose.Slides reemplazará. También revise la configuración de [sustitución de fuentes](/slides/es/java/font-substitution/) y las reglas de [fallback de fuentes](/slides/es/java/fallback-font/). El fallback gestiona los caracteres faltantes, por lo que incrustar una fuente no resuelve los caracteres que la propia fuente no contiene.

**¿Debo incrustar fuentes comunes como Arial y Calibri?**

Base la decisión en el entorno de destino. Si las fuentes requeridas están disponibles en cada máquina que abre o renderiza la presentación, incrustarlas puede añadir un tamaño de archivo innecesario. Si los destinatarios o servidores pueden no disponer de esas fuentes, incrustarlas puede ayudar a conservar la apariencia prevista, siempre que sus licencias lo permitan.