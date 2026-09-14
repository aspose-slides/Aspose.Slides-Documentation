---
title: Incrustar fuentes en presentaciones en Python vía Java
linktitle: Fuentes incrustadas
type: docs
weight: 40
url: /es/python-java/embedded-font/
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
- Java
- Aspose.Slides
description: "Gestiona fuentes incrustadas en PowerPoint con Aspose.Slides para Python vía Java. Añade, recupera, elimina y comprime fuentes para preservar la apariencia del texto y reducir el tamaño del archivo."
---
## **Introducción**

Incrustar fuentes almacena los datos de la fuente dentro de una presentación de PowerPoint. Cuando un visor admite fuentes incrustadas, puede mostrar el texto utilizando esas fuentes aunque no estén instaladas en el sistema de destino. Esto ayuda a conservar los saltos de línea, el espaciado del texto y el diseño de las diapositivas.

Aspose.Slides for Python via Java le permite recuperar, añadir y eliminar fuentes incrustadas a través de la clase [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/) devuelta por [Presentation.getFontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getFontsManager). También puede reducir el tamaño de los datos de fuentes incrustadas eliminando los caracteres que la presentación no utiliza.

Los ejemplos a continuación funcionan con archivos PPTX. Antes de incrustar una fuente, asegúrese de que sus datos estén disponibles para Aspose.Slides y de que su licencia permita la incrustación.

## **Obtener y eliminar fuentes incrustadas**

Utilice [getEmbeddedFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) para enumerar las fuentes almacenadas en una presentación. Para eliminar una, pase una fuente de esa lista a [removeEmbeddedFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) y, a continuación, guarde la presentación.

El siguiente ejemplo enumera las fuentes incrustadas en `EmbeddedFonts.pptx` y elimina Calibri si está presente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

Eliminar una fuente incrustada elimina sus datos almacenados; no cambia la fuente asignada al texto. Si la fuente está instalada en el sistema de destino, el texto puede seguir utilizándola. De lo contrario, el renderizado puede requerir sustitución de fuentes, lo que puede afectar el diseño.

## **Inspeccionar datos de fuentes y permisos de incrustación**

Utilice la clase [FontsManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/) para inspeccionar las fuentes antes de incrustarlas. Llame a [FontsManager.getFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getFonts) para obtener las fuentes utilizadas en la presentación. Para cada fuente, pase un objeto [FontData](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontdata/) y el valor requerido de [FontStyleType](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontstyletype/) a [FontsManager.getFontBytes](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getFontBytes). El método devuelve los datos binarios de ese estilo de fuente, o `None` cuando la fuente o el estilo solicitados no están disponibles. No pase un resultado `None` a [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), porque ese método requiere una matriz de bytes.

`EmbeddingLevel` es una enumeración de indicadores que informa de las restricciones de incrustación almacenadas en la fuente:

- `Installable` permite la incrustación y la instalación permanente en otro sistema, sujeto a la licencia de la fuente.
- `Restricted` prohíbe la incrustación a menos que se obtenga permiso del propietario legal de la fuente cuando es el único indicador de permiso de uso.
- `PreviewPrint` permite el uso temporal para visualización e impresión; un documento que contenga la fuente debe ser de solo lectura.
- `Editable` permite el uso temporal y permite que el documento se edite y guarde.
- `NoSubsetting` es una restricción adicional que prohíbe incrustar solo un subconjunto de glifos. Incruste todos los caracteres cuando este indicador está presente.
- `BitmapOnly` es una restricción adicional que permite incrustar solo versiones bitmap, no datos de contorno. Si la fuente no tiene versiones bitmap, no puede ser incrustada.

Los cuatro primeros valores describen el permiso de uso, mientras que `NoSubsetting` y `BitmapOnly` pueden combinarse con ellos. Verifique los modificadores con operaciones bit a bit. Dado que `Installable` es cero, enmascare los bits de permiso de uso y compare el resultado con `Installable` en lugar de comprobarlo como un indicador. Las fuentes actuales deben establecer como máximo un bit de permiso de uso. Para compatibilidad con fuentes antiguas que establecen más de uno, el asistente siguiente selecciona el permiso menos restrictivo: `Editable`, luego `PreviewPrint`, luego `Restricted`.

El siguiente ejemplo registra los datos normales, negrita, cursiva y negrita‑cursiva disponibles para cada fuente devuelta por `getFonts`. Omite los estilos no disponibles, fuentes restringidas, fuentes solo bitmap, fuentes limitadas a vista previa e impresión porque la salida sigue siendo editable, y fuentes que ya están incrustadas. Si algún estilo disponible tiene `NoSubsetting`, incrusta todos los caracteres de esa familia de fuentes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Esta inspección informa de las restricciones codificadas en cada archivo de fuente. No otorga una licencia, no demuestra que haya obtenido la fuente legalmente, ni sustituye la comprobación del acuerdo de licencia de la fuente antes de distribuir una copia incrustada.

## **Añadir fuentes incrustadas**

Utilice [addEmbeddedFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) para incrustar una fuente. Sus sobrecargas aceptan ya sea un objeto [FontData](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontdata/) o una matriz de bytes que contiene los datos de la fuente. La enumeración [EmbedFontCharacters](https://reference.aspose.com/slides/es/python-java/aspose.slides/embedfontcharacters/) controla qué caracteres se incluyen:

- `All` incrusta todos los caracteres de la fuente. Use esta opción cuando los destinatarios necesiten editar la presentación e introducir texto nuevo.
- `OnlyUsed` incrusta sólo los caracteres utilizados en la presentación para reducir el tamaño del archivo. Elija esta opción para una presentación final que se destine principalmente a la visualización.

El siguiente ejemplo utiliza [getFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getFonts) para obtener las fuentes usadas en `Fonts.pptx` e incrusta aquellas que aún no están incrustadas. Las fuentes a añadir deben estar disponibles en la máquina que ejecuta el código. Las fuentes ya incrustadas conservan sus juegos de caracteres actuales.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comprimir fuentes incrustadas**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/compress/#compressEmbeddedFonts) reduce los datos de fuentes incrustadas eliminando los caracteres no usados. funciona sobre fuentes que ya están incrustadas, por lo que la reducción de tamaño depende de cuántos datos de fuente no utilizados contiene la presentación.

El siguiente ejemplo comprime las fuentes en `EmbeddedFonts.pptx` y guarda el resultado como un archivo separado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Conserve el archivo original si los destinatarios pueden necesitar añadir texto más tarde. Los caracteres eliminados durante la compresión ya no están disponibles en la fuente incrustada, incluso si originalmente incrustó todos los caracteres.

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si una fuente incrustada seguirá siendo sustituida durante el renderizado?**

Llame a [getSubstitutions](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/#getSubstitutions) en el entorno donde renderice la presentación para ver qué fuentes reemplazará Aspose.Slides. También verifique la configuración de sustitución de fuentes y las reglas de respaldo de fuentes. El respaldo maneja los caracteres ausentes, por lo que incrustar una fuente no resuelve los caracteres que la propia fuente no contiene.

**¿Debo incrustar fuentes comunes como Arial y Calibri?**

Base la decisión en el entorno de destino. Si las fuentes requeridas están disponibles en cada máquina que abre o renderiza la presentación, incrustarlas puede añadir un tamaño de archivo innecesario. Si los destinatarios o servidores pueden no disponer de esas fuentes, incrustarlas puede ayudar a conservar la apariencia prevista, siempre que sus licencias lo permitan.