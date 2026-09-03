---
title: Incrustar fuentes en presentaciones con Python
linktitle: Fuentes incrustadas
type: docs
weight: 40
url: /es/python-net/embedded-font/
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
- Python
- Aspose.Slides
description: "Gestiona fuentes incrustadas en PowerPoint con Aspose.Slides para Python mediante .NET. Usa Python para añadir, recuperar, eliminar y comprimir fuentes y así preservar la apariencia del texto y reducir el tamaño del archivo."
---
## **Introducción**

Incrustar fuentes almacena los datos de la fuente dentro de una presentación PowerPoint. Cuando un visor soporta fuentes incrustadas, puede mostrar el texto usando esas fuentes aunque no estén instaladas en el sistema de destino. Esto ayuda a conservar los saltos de línea, el espaciado del texto y el diseño de las diapositivas.

Aspose.Slides for Python via .NET le permite recuperar, añadir y eliminar fuentes incrustadas a través de la propiedad [fonts_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/fonts_manager/) de un objeto [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/). También puede reducir el tamaño de los datos de la fuente incrustada eliminando los caracteres que la presentación no utiliza.

Los ejemplos a continuación funcionan con archivos PPTX. Antes de incrustar una fuente, asegúrese de que sus datos estén disponibles para Aspose.Slides y de que su licencia permita la incrustación.

## **Obtener y eliminar fuentes incrustadas**

Utilice [get_embedded_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) para enumerar las fuentes almacenadas en una presentación. Para eliminar una, passe una fuente de esa lista a [remove_embedded_font](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/remove_embedded_font/), y luego guarde la presentación.

El siguiente ejemplo enumera las fuentes incrustadas en `EmbeddedFonts.pptx` y elimina Calibri si está presente:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Eliminar una fuente incrustada elimina sus datos almacenados; no cambia la fuente asignada al texto. Si la fuente está instalada en el sistema de destino, el texto aún puede usarla. De lo contrario, el renderizado puede requerir [font substitution](/slides/es/python-net/font-substitution/), lo que puede afectar el diseño.

## **Inspeccionar datos de fuentes y permisos de incrustación**

Utilice la clase [FontsManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/) para inspeccionar las fuentes antes de incrustarlas. Llame a [get_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_fonts/) para obtener las fuentes usadas en la presentación. Para cada fuente, pase un objeto [FontData](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontdata/) y el valor requerido de [FontStyleType](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontstyletype/) a [get_font_bytes](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_font_bytes/). El método devuelve los datos binarios de ese estilo de fuente, o `None` cuando la fuente o el estilo solicitado no están disponibles. No pase un resultado `None` a [get_font_embedding_level](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_font_embedding_level/), porque ese método requiere una matriz de bytes.

[EmbeddingLevel](https://reference.aspose.com/slides/es/python-net/aspose.slides/embeddinglevel/) es una enumeración de banderas que informa de las restricciones de incrustación almacenadas en la fuente:

- `INSTALLABLE` permite la incrustación y la instalación permanente en otro sistema, siempre que la licencia de la fuente lo permita.
- `RESTRICTED` prohíbe la incrustación a menos que se obtenga permiso del propietario legal de la fuente cuando es la única bandera de permiso de uso.
- `PREVIEW_PRINT` permite el uso temporal para visualización e impresión; un documento que contenga la fuente debe ser de solo lectura.
- `EDITABLE` permite el uso temporal y permite que el documento se edite y guarde.
- `NO_SUBSETTING` es una restricción adicional que prohíbe incrustar solo un subconjunto de los glifos. Incruste todos los caracteres cuando esté presente esta bandera.
- `BITMAP_ONLY` es una restricción adicional que permite incrustar solo imágenes de mapa de bits, no datos de contorno. Si la fuente no tiene imágenes de mapa de bits, no puede incrustarse.

Los primeros cuatro valores describen el permiso de uso, mientras que `NO_SUBSETTING` y `BITMAP_ONLY` pueden combinarse con ellos. Verifique los modificadores con operaciones bit a bit. Dado que `INSTALLABLE` es cero, enmascare los bits de permiso de uso y compare el resultado con `INSTALLABLE`. Las fuentes actuales deberían establecer a lo sumo un bit de permiso de uso. Para compatibilidad con fuentes más antiguas que establecen más de uno, el asistente a continuación selecciona el permiso menos restrictivo: `EDITABLE`, luego `PREVIEW_PRINT`, luego `RESTRICTED`.

El siguiente ejemplo audita los datos regular, negrita, cursiva y negrita‑cursiva disponibles para cada fuente devuelta por `get_fonts`. Omite estilos no disponibles, fuentes restringidas, fuentes solo bitmap, fuentes limitadas a vista previa e impresión porque la salida sigue siendo editable, y fuentes que ya están incrustadas. Si algún estilo disponible tiene `NO_SUBSETTING`, incrusta todos los caracteres para esa familia de fuentes.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Esta inspección informa de las restricciones codificadas en cada archivo de fuente. No otorga una licencia, no prueba que haya obtenido la fuente legalmente, ni reemplaza la comprobación del contrato de licencia de la fuente antes de distribuir una copia incrustada.

## **Añadir fuentes incrustadas**

Utilice [add_embedded_font](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/add_embedded_font/) para incrustar una fuente. Sus sobrecargas aceptan ya sea un objeto [FontData](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontdata/) o una matriz de bytes que contenga los datos de la fuente. La enumeración [EmbedFontCharacters](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/embedfontcharacters/) controla qué caracteres se incluyen:

- [ALL](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/embedfontcharacters/) incrusta todos los caracteres de la fuente. Use esta opción cuando los destinatarios necesiten editar la presentación e introducir texto nuevo.
- [ONLY_USED](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/embedfontcharacters/) incrusta solo los caracteres usados en la presentación para reducir el tamaño del archivo. Elija esta opción para una presentación final que esté destinada principalmente a la visualización.

El siguiente ejemplo usa [get_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_fonts/) para obtener las fuentes usadas en `Fonts.pptx` e incrusta aquellas que aún no lo están. Las fuentes a añadir deben estar disponibles en la máquina que ejecuta el código. Las fuentes incrustadas existentes conservan sus conjuntos de caracteres actuales.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprimir fuentes incrustadas**

[compress_embedded_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) reduce los datos de fuentes incrustadas eliminando los caracteres que no se usan. Actúa sobre fuentes que ya están incrustadas, por lo que la reducción de tamaño depende de la cantidad de datos de fuente no utilizados que contenga la presentación.

El siguiente ejemplo comprime las fuentes en `EmbeddedFonts.pptx` y guarda el resultado como un archivo separado:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Mantenga el archivo original si los destinatarios pueden necesitar añadir texto más adelante. Los caracteres eliminados durante la compresión ya no están disponibles desde la fuente incrustada, incluso si originalmente incrustó todos los caracteres.

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si una fuente incrustada seguirá siendo sustituida durante el renderizado?**

Llame a [get_substitutions](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_substitutions/) en el entorno donde renderice la presentación para ver qué fuentes Aspose.Slides reemplazará. También revise la configuración de [font substitution](/slides/es/python-net/font-substitution/) y las reglas de [font fallback](/slides/es/python-net/fallback-font/). El fallback gestiona los caracteres ausentes, por lo que incrustar una fuente no resuelve los caracteres que la propia fuente no contiene.

**¿Debo incrustar fuentes comunes como Arial y Calibri?**

Base la decisión en el entorno de destino. Si las fuentes requeridas están disponibles en cada máquina que abra o renderice la presentación, incrustarlas puede añadir un tamaño de archivo innecesario. Si los destinatarios o servidores pueden carecer de esas fuentes, incrustarlas puede ayudar a conservar la apariencia prevista, siempre que sus licencias lo permitan.