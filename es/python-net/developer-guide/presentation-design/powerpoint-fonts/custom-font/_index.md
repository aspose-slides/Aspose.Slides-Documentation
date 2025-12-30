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
description: "Incruste fuentes personalizadas en diapositivas de PowerPoint con Aspose.Slides para Python a través de .NET para mantener sus presentaciones nítidas y coherentes en cualquier dispositivo."
---

## **Descripción general**

Aspose.Slides para Python le permite proporcionar fuentes personalizadas en tiempo de ejecución, de modo que las presentaciones se rendericen correctamente incluso cuando las fuentes requeridas no estén instaladas en el sistema host. Durante la exportación a PDF o imágenes, puede suministrar carpetas de fuentes o datos de fuentes en memoria para conservar el diseño del texto, las métricas de los glifos y la tipografía. Esto hace que la renderización del lado del servidor sea predecible en diferentes entornos, elimina las dependencias de fuentes a nivel del sistema operativo y evita sustituciones o reflujo no deseados. El artículo muestra cómo registrar fuentes.

Aspose.Slides le permite cargar las siguientes fuentes mediante los métodos `load_external_font` y `load_external_fonts` de la clase [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/):

- Fuentes TrueType (.ttf) y colecciones TrueType (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Cargar fuentes personalizadas**

Aspose.Slides permite cargar las fuentes utilizadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación—como PDF, imágenes y otros formatos admitidos—para que los documentos resultantes tengan el mismo aspecto en todos los entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuente.
2. Llame al método estático [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader.clear_cache](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/clear_cache/) para limpiar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:
```py
import aspose.slides as slides

# Definir carpetas que contienen archivos de fuentes personalizados.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Cargar fuentes personalizadas desde las carpetas especificadas.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Limpiar la caché de fuentes después de que el trabajo haya finalizado.
slides.FontsLoader.clear_cache()
```


{{% alert color="info" title="Nota" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) agrega carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de las fuentes.  
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.  
1. Las rutas cargadas mediante [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).  
{{%/alert %}}

## **Obtener la carpeta de fuentes personalizadas**

Aspose.Slides proporciona el método `get_font_folders` para recuperar las carpetas de fuentes. Devuelve tanto las carpetas añadidas a través de `load_external_fonts` como las carpetas de fuentes del sistema.

Este código Python muestra cómo usar `get_font_folders`:
```python
import aspose.slides as slides

# Esta llamada devuelve las carpetas comprobadas en busca de archivos de fuentes.
# Estas incluyen las carpetas añadidas mediante el método load_external_fonts y las carpetas de fuentes del sistema.
font_folders = slides.FontsLoader.get_font_folders()
```


## **Especificar fuentes personalizadas para una presentación**

Aspose.Slides proporciona la propiedad `document_level_font_sources`, que le permite especificar fuentes externas para usar con una presentación.

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


## **Cargar fuentes externas desde datos binarios**

Aspose.Slides ofrece el método `load_external_font` para cargar fuentes externas a partir de datos binarios.

El siguiente ejemplo en Python demuestra cómo cargar una fuente desde un arreglo de bytes:
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
        # Las fuentes externas están disponibles durante la vida útil de esta instancia de presentación.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```


## **Preguntas frecuentes**

**¿Las fuentes personalizadas afectan a la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son usadas por el renderizador en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para la renderización no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente forme parte del archivo de presentación, debe usar las [funciones de incrustación](/slides/es/python-net/embedded-font/).

**¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/python-net/font-substitution/), las [reglas de reemplazo](/slides/es/python-net/font-replacement/) y los [conjuntos de sustitución](/slides/es/python-net/fallback-font/) para definir exactamente qué fuente se usa cuando falta el glifo solicitado.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arreglos de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.