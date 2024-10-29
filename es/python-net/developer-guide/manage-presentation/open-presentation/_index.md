---
title: Abrir Presentación
type: docs
weight: 20
url: /es/python-net/open-presentation/
keywords: "Abrir PowerPoint, PPTX, PPT, Abrir Presentación, Cargar Presentación, Python"
description: "Abrir o cargar Presentación PPT, PPTX, ODP en Python"
---

Además de crear presentaciones de PowerPoint desde cero, Aspose.Slides te permite abrir presentaciones existentes. Después de cargar una presentación, puedes obtener información sobre la presentación, editar la presentación (contenido en sus diapositivas), agregar nuevas diapositivas o eliminar las existentes, etc. 

## Abrir Presentación

Para abrir una presentación existente, simplemente tienes que instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y pasar la ruta del archivo (de la presentación que deseas abrir) a su constructor. 

Este código Python te muestra cómo abrir una presentación y también averiguar el número de diapositivas que contiene: 

```python
import aspose.slides as slides

# Instanciar la clase Presentation y pasar la ruta del archivo a su constructor
with slides.Presentation("pres.pptx") as pres:
    # Imprime el número total de diapositivas presentes en la presentación
    print(pres.slides.length)
```

## **Abrir Presentación Protegida por Contraseña**

Cuando tienes que abrir una presentación protegida por contraseña, puedes pasar la contraseña a través de la propiedad `password` (de la clase [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)) para desencriptar la presentación y cargar la presentación. Este código Python demuestra la operación:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "CONTRASEÑA"
with slides.Presentation("pres.pptx", load_options) as pres:
    ...
```

## Abrir Presentación Grande

Aspose.Slides proporciona opciones (la propiedad `blob_management_options` en particular) bajo la clase [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) para permitirte cargar presentaciones grandes. 

Este Python demuestra una operación en la que se carga una presentación grande (digamos de 2GB de tamaño):

```python
import aspose.slides as slides
import os

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("pres.pptx", loadOptions) as pres:
    # Se ha cargado la presentación grande y se puede usar, pero el consumo de memoria sigue siendo bajo.

    # Realiza cambios en la presentación.
    pres.slides[0].name = "Presentación muy grande"

    # La presentación se guardará en otro archivo. El consumo de memoria se mantiene bajo durante la operación
    pres.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # ¡No se puede hacer eso! Se lanzará una excepción de IO porque el archivo está bloqueado mientras los objetos pres
    # no se eliminarán
    os.remove("pres.pptx")

# Está bien hacerlo aquí. El archivo fuente no está bloqueado por el objeto pres.
os.remove("pres.pptx")
```

{{% alert color="info" title="Información" %}}

Para sortear ciertas limitaciones al interactuar con flujos, Aspose.Slides puede copiar el contenido del flujo. Cargar una presentación grande a través de su flujo resultará en la copia del contenido de la presentación y causará una carga lenta. Por lo tanto, cuando pretendas cargar una presentación grande, te recomendamos encarecidamente que utilices la ruta del archivo de la presentación y no su flujo.

Cuando desees crear una presentación que contenga objetos grandes (video, audio, imágenes grandes, etc.), puedes utilizar la [facilidad Blob](https://docs.aspose.com/slides/python-net/manage-blob/) para reducir el consumo de memoria.

{{%/alert %}} 


## Cargar Presentación

Aspose.Slides proporciona [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) con un único método para permitirte gestionar recursos externos. Este código Python te muestra cómo usar la interfaz `IResourceLoadingCallback`:

```python
# [TODO[no_soportado_aún]: implementación de python de interfaces .net]
```

<h2>Abrir y Guardar Presentación</h2>

<a name="python-net-open-save-presentation"><strong>Pasos: Abrir y Guardar Presentación en Python</strong></a>

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y pasa el archivo que deseas abrir. 
2. Guarda la presentación. 

```python
import aspose.slides as slides

# Instanciar un objeto Presentation que represente un archivo PPT
with slides.Presentation() as presentation:
    
    #...hacer algún trabajo aquí...

    # Guarda tu presentación en un archivo
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```