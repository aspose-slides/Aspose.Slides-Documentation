---
title: Personalizar fuentes de PowerPoint en Python mediante Java
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/python-java/custom-font/
keywords:
- fuente
- fuente personalizada
- fuente externa
- cargar fuente
- gestionar fuentes
- carpeta de fuentes
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Personalice las fuentes en diapositivas de PowerPoint con Aspose.Slides para Python mediante Java para que sus presentaciones sean precisas y coherentes en cualquier dispositivo."
---
## **Visión general**

Aspose.Slides le permite usar fuentes personalizadas en presentaciones sin instalarlas en el sistema operativo. Puede cargar fuentes desde carpetas personalizadas, proporcionar fuentes para una presentación específica mediante fuentes a nivel de documento, o cargar fuentes externas directamente a partir de datos binarios.

Las fuentes cargadas se usan cuando una presentación se renderiza o exporta, por ejemplo a PDF, imágenes y otros formatos compatibles. Esto ayuda a mantener la salida de la presentación coherente en diferentes entornos. El artículo también explica cómo inspeccionar las carpetas de fuentes utilizadas por Aspose.Slides y cómo borrar la caché de fuentes después de trabajar con fuentes externas.

Registrar fuentes personalizadas para renderizado es independiente de incrustar fuentes en un archivo PPTX. Si una fuente debe almacenarse dentro de la propia presentación, utilice explícitamente las funciones de incrustación de fuentes.

Un tema de presentación puede hacer referencia a diferentes familias tipográficas para sistemas de escritura individuales. Estas asignaciones almacenan nombres de fuentes pero no instalan ni cargan los archivos de fuentes. Consulte [Fuentes de tema específicas por script](/slides/es/python-java/script-specific-font-mappings/) para administrar las asignaciones, y use las opciones de carga a continuación para que las fuentes referenciadas estén disponibles para un renderizado coherente.

{{% alert color="info" title="Note" %}}

Aspose.Slides le permite cargar estas fuentes usando el método [loadExternalFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Véase [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Véase [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes usadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles— de modo que los documentos resultantes tengan un aspecto coherente en todos los entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#loadExternalFonts) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/expórtese la presentación.
4. Llame a [FontsLoader.clearCache](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#clearCache) para borrar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Definir carpetas que contienen archivos de fuentes personalizados.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Cargar fuentes personalizadas desde las carpetas especificadas.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Renderizar/exportar la presentación usando las fuentes cargadas.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Borrar la caché de fuentes después de que el trabajo haya finalizado.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#loadExternalFonts) agrega carpetas adicionales a las rutas de búsqueda de fuentes, pero no modifica el orden de inicialización de las fuentes.  
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.
1. Las rutas cargadas mediante [FontsLoader](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**

Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#getFontFolders) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método [loadExternalFonts](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#loadExternalFonts) y las carpetas de fuentes del sistema.

Este código Python le muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Obtener carpetas añadidas mediante loadExternalFonts y carpetas de fuentes del sistema.
font_folders = FontsLoader.getFontFolders()
```

## **Especificar fuentes personalizadas usadas con una presentación**

Aspose.Slides proporciona el método [getDocumentLevelFontSources](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) para permitirle especificar fuentes externas que se usarán con la presentación.

Este código Python le muestra cómo usar el método [getDocumentLevelFontSources](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Trabajar con la presentación.
    # CustomFont1, CustomFont2 y fuentes de assets/fonts y global/fonts
    # y sus subcarpetas están disponibles para la presentación.
    pass
finally:
    presentation.dispose()
```

## **Administrar fuentes externamente**

Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/#loadExternalFont) para permitirle cargar fuentes externas a partir de datos binarios.

Este código Python demuestra el proceso de carga de fuentes a partir de un arreglo de bytes:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Las fuentes externas se cargan durante la vida útil de la presentación.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **Preguntas frecuentes**

**¿Afectan las fuentes personalizadas a la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente se lleve dentro del archivo de la presentación, debe usar explícitamente las [funciones de incrustación](/slides/es/python-java/embedded-font/).

**¿Puedo controlar el comportamiento de reserva cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/python-java/font-substitution/), las [reglas de reemplazo](/slides/es/python-java/font-replacement/) y los [conjuntos de reserva](/slides/es/python-java/fallback-font/) para definir exactamente qué fuente se usa cuando falta el glifo solicitado.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arreglos de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.