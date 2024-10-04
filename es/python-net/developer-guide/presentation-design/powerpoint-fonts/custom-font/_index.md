---
title: Fuente Personalizada de PowerPoint en Python
linktitle: Fuente Personalizada
type: docs
weight: 20
url: /es/python-net/custom-font/
keywords: "Fuentes, fuentes personalizadas, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Fuentes personalizadas de PowerPoint en Python"
---

{{% alert color="primary" %}} 

Aspose Slides te permite cargar estas fuentes utilizando el método `load_external_fonts` de la clase [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/):

* Fuentes TrueType (.ttf) y Colección TrueType (.ttc). Ver [TrueType](https://es.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Ver [OpenType](https://es.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar Fuentes Personalizadas**

Aspose.Slides te permite cargar fuentes que se renderizan en presentaciones sin tener que instalar esas fuentes. Las fuentes se cargan desde un directorio personalizado. 

1. Crea una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) y llama al método `load_external_fonts`.
2. Carga la presentación que será renderizada.
3. Limpia la caché en la clase [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

Este código Python demuestra el proceso de carga de fuentes:

```python
import aspose.slides as slides

# La ruta al directorio de documentos.
dataDir = "C:\\"

# carpetas para buscar fuentes
folders = [ dataDir ]

# Carga las fuentes del directorio de fuentes personalizadas
slides.FontsLoader.load_external_fonts(folders)

# Realiza algunas tareas y renderiza la presentación/diapositiva
with slides.Presentation(path + "DefaultFonts.pptx") as presentation:
    presentation.save("NewFonts_out.pptx", slides.export.SaveFormat.PPTX)

# Limpia la caché de fuentes
slides.FontsLoader.clear_cache()
```

## **Obtener Carpeta de Fuentes Personalizadas**
Aspose.Slides proporciona el método `get_font_folders()` para permitirte encontrar carpetas de fuentes. Este método devuelve carpetas añadidas a través del método `LoadExternalFonts` y carpetas de fuentes del sistema.

Este código Python te muestra cómo usar `get_font_folders()`:

```python
#  Esta línea imprime las carpetas que se revisan en busca de archivos de fuentes.
# Esas son carpetas añadidas a través del método load_external_fonts y carpetas de fuentes del sistema.
fontFolders = slides.FontsLoader.get_font_folders()

```


## **Especificar Fuentes Personalizadas Utilizadas con la Presentación**
Aspose.Slides proporciona la propiedad `document_level_font_sources` para permitirte especificar fuentes externas que serán utilizadas con la presentación.

Este código Python te muestra cómo usar la propiedad `document_level_font_sources`:

```python
import aspose.slides as slides

with open(path + "CustomFont1.ttf", "br") as font1:
    memoryFont1 = font1.read()
    with open(path + "CustomFont2.ttf", "br") as font2:
        memoryFont2 = font2.read()

        loadOptions = slides.LoadOptions()
        loadOptions.document_level_font_sources.font_folders =  ["assets\\fonts", "global\\fonts"] 
        loadOptions.document_level_font_sources.memory_fonts = [ memoryFont1, memoryFont2 ]
        with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as presentation:
            # Trabajar con la presentación
            # CustomFont1, CustomFont2, y fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
            print(len(presentation.slides))
```

## **Gestionar Fuentes Externamente**

Aspose.Slides proporciona el método `load_external_font`(data) para permitirte cargar fuentes externas desde datos binarios.

Este código Python demuestra el proceso de carga de fuentes desde un array de bytes:

```python
from aspose.slides import FontsLoader, Presentation

def read_all_bytes(path):
    with open(path, "rb") as in_file:
        bytes = in_file.read()
    return bytes

FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with Presentation() as pres:
        # fuente externa cargada durante la vida útil de la presentación
        print("procesando")
finally:
    FontsLoader.clear_cache()

```