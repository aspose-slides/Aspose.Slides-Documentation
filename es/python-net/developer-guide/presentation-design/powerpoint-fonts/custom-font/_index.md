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
description: "Incruste fuentes personalizadas en diapositivas de PowerPoint con Aspose.Slides para Python a través de .NET para que sus presentaciones se mantengan nítidas y consistentes en cualquier dispositivo."
---

## **Visión general**

Aspose.Slides for Python le permite proporcionar fuentes personalizadas en tiempo de ejecución para que las presentaciones se rendericen correctamente incluso cuando las fuentes requeridas no están instaladas en el sistema host. Durante la exportación a PDF o imágenes, puede suministrar carpetas de fuentes o datos de fuentes en memoria para preservar el diseño del texto, las métricas de glifos y la tipografía. Esto hace que la renderización del lado del servidor sea predecible en diferentes entornos, elimina las dependencias de fuentes a nivel del SO y evita retrocesos o reflujo no deseados. El artículo muestra cómo registrar fuentes.

Aspose.Slides permite cargar las siguientes fuentes usando los métodos `load_external_font` y `load_external_fonts` de la clase [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/):

- fuentes TrueType (.ttf) y TrueType Collection (.ttc). Ver [TrueType](https://en.wikipedia.org/wiki/TrueType).
- fuentes OpenType (.otf). Ver [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes para renderizar presentaciones sin instalarlas. Las fuentes se cargan desde un directorio personalizado.

1. Llame al método `load_external_fonts` de [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).
1. Cargue la presentación que se va a renderizar.
1. Borre la caché en la clase [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

El siguiente código Python muestra el proceso de carga de fuentes:
```python
import aspose.slides as slides

# Carpetas donde buscar fuentes.
font_folders = [ "C:\\MyFonts", "D:\\MyAdditionalFonts" ]

# Cargar fuentes de los directorios personalizados.
slides.FontsLoader.load_external_fonts(font_folders)

# Renderizar la presentación.
with slides.Presentation("Fonts.pptx") as presentation:
    presentation.save("Fonts_out.pdf", slides.export.SaveFormat.PDF)

# Borrar la caché de fuentes.
slides.FontsLoader.clear_cache()
```


## **Obtener la carpeta de fuentes personalizadas**

Aspose.Slides proporciona el método `get_font_folders` para recuperar carpetas de fuentes. Devuelve tanto las carpetas añadidas mediante `load_external_fonts` como las carpetas de fuentes del sistema.

Este código Python muestra cómo usar `get_font_folders`:
```python
import aspose.slides as slides

# Esta llamada devuelve las carpetas verificadas para archivos de fuentes.
# Estas incluyen carpetas añadidas mediante el método load_external_fonts y las carpetas de fuentes del sistema.
font_folders = slides.FontsLoader.get_font_folders()
```


## **Especificar fuentes personalizadas para una presentación**

Aspose.Slides ofrece la propiedad `document_level_font_sources`, que permite especificar fuentes externas para usar con una presentación.

El siguiente ejemplo Python muestra cómo usar `document_level_font_sources`:
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

El siguiente ejemplo Python demuestra la carga de una fuente a partir de una matriz de bytes:
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
        # Las fuentes externas están disponibles mientras exista esta instancia de presentación.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```


## **Preguntas frecuentes**

**¿Las fuentes personalizadas afectan la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son usadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para renderizar no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente quede incluida dentro del archivo de presentación, debe usar las [funciones de incrustación](/slides/es/python-net/embedded-font/).

**¿Puedo controlar el comportamiento de respaldo cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/python-net/font-substitution/), las [reglas de reemplazo](/slides/es/python-net/font-replacement/) y los [conjuntos de respaldo](/slides/es/python-net/fallback-font/) para definir exactamente qué fuente se usa cuando el glifo solicitado falta.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde matrices de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia, puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de las fuentes. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise la EULA de la fuente antes de distribuir los resultados.