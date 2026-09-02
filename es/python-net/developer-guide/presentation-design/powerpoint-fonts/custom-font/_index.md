---
title: Personalizar fuentes de PowerPoint en Python
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/python-net/custom-font/
keywords:
- fuente
- fuente personalizada
- fuente externa
- cargar fuente
- gestionar fuentes
- carpeta de fuentes
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Incruste fuentes personalizadas en diapositivas de PowerPoint con Aspose.Slides para Python mediante .NET para que sus presentaciones permanezcan nítidas y coherentes en cualquier dispositivo."
---
## **Descripción general**

Aspose.Slides for Python permite proporcionar fuentes personalizadas en tiempo de ejecución, de modo que las presentaciones se rendericen correctamente aunque las fuentes requeridas no estén instaladas en el sistema host. Durante la exportación a PDF o imágenes, puede suministrar carpetas de fuentes o datos de fuentes en memoria para conservar el diseño del texto, las métricas de glifos y la tipografía. Esto hace que la renderización del lado del servidor sea predecible en diferentes entornos, elimina dependencias de fuentes a nivel del SO y evita sustituciones no deseadas o reorganizaciones del texto. El artículo muestra cómo registrar orígenes de fuentes.

Un tema de presentación puede hacer referencia a distintas familias tipográficas para sistemas de escritura individuales. Estas asignaciones almacenan nombres de fuentes pero no instalan ni cargan los archivos de fuentes. Consulte [Script-Specific Theme Fonts](/slides/es/python-net/script-specific-font-mappings/) para gestionar las asignaciones y use las opciones de carga a continuación para que las fuentes referenciadas estén disponibles y se garantice una renderización coherente.

Aspose.Slides le permite cargar las siguientes fuentes mediante los métodos `load_external_font` y `load_external_fonts` de la clase [FontsLoader](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsloader/):

- Fuentes TrueType (.ttf) y colecciones TrueType (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Cargar fuentes personalizadas**

Aspose.Slides permite cargar las fuentes utilizadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles— de modo que los documentos resultantes tengan un aspecto coherente en todos los entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsloader/load_external_fonts/) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader.clear_cache](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsloader/clear_cache/) para vaciar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:

```py
import aspose.slides as slides

# Definir carpetas que contienen archivos de fuentes personalizadas.
font_folders = ["fonts", "external_fonts"]

# Cargar fuentes personalizadas desde las carpetas especificadas.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Vaciar la caché de fuentes después de que el trabajo haya finalizado.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsloader/load_external_fonts/) añade carpetas adicionales a las rutas de búsqueda de fuentes, pero no modifica el orden de inicialización de las fuentes.
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.
1. Las rutas cargadas a través de [FontsLoader](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Obtener la carpeta de fuentes personalizadas**

Aspose.Slides proporciona el método `get_font_folders` para obtener las carpetas de fuentes. Devuelve tanto las carpetas añadidas mediante `load_external_fonts` como las carpetas de fuentes del sistema.

Este código Python muestra cómo usar `get_font_folders`:

```python
import aspose.slides as slides

# Esta llamada devuelve las carpetas comprobadas para archivos de fuentes.
# Estas incluyen carpetas añadidas mediante el método load_external_fonts y las carpetas de fuentes del sistema.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Especificar fuentes personalizadas para una presentación**

Aspose.Slides ofrece la propiedad `document_level_font_sources`, que permite especificar fuentes externas que se usarán con una presentación.

El siguiente ejemplo en Python muestra cómo usar `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Trabajar con la presentación.
    # CustomFont1, CustomFont2 y fuentes de las carpetas assets\fonts y global\fonts (y sus subcarpetas) están disponibles para la presentación.
    # ...
    print(len(presentation.slides))
```

## **Cargar fuentes externas a partir de datos binarios**

Aspose.Slides proporciona el método `load_external_font` para cargar fuentes externas a partir de datos binarios.

El siguiente ejemplo en Python demuestra la carga de una fuente desde un array de bytes:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Cargar fuentes externas desde matrices de bytes.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Las fuentes externas están disponibles durante la vida de esta instancia de presentación.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **Preguntas frecuentes**

### ¿Las fuentes personalizadas afectan la exportación a todos los formatos (PDF, PNG, SVG, HTML)?

Sí. Las fuentes conectadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

### ¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?

No. Registrar una fuente para la renderización no equivale a incrustarla en un PPTX. Si necesita que la fuente forme parte del archivo de la presentación, debe usar las [funciones de incrustación](/slides/es/python-net/embedded-font/).

### ¿Puedo controlar el comportamiento de sustitución cuando a una fuente personalizada le faltan algunos glifos?

Sí. Configure la [sustitución de fuentes](/slides/es/python-net/font-substitution/), las [reglas de reemplazo](/slides/es/python-net/font-replacement/) y los [conjuntos de fuentes de reserva](/slides/es/python-net/fallback-font/) para definir exactamente qué fuente se usará cuando el glifo solicitado no exista.

### ¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arrays de bytes. Esto elimina cualquier dependencia de directorios de fuentes del sistema en la imagen del contenedor.

### ¿Qué ocurre con la licencia: puedo incrustar cualquier fuente personalizada sin restricciones?

Usted es responsable del cumplimiento de la licencia de las fuentes. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.