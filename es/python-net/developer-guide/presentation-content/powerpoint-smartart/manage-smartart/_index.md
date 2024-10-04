---
title: Administrar SmartArt
type: docs
weight: 10
url: /es/python-net/manage-smartart/
keywords: "SmartArt, texto de SmartArt, gráfico de tipo organización, gráfico de organización con imágenes, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "SmartArt y gráfico de tipo organización en presentaciones de PowerPoint en Python"
---

## **Obtener Texto de SmartArt**
Ahora se ha añadido la propiedad TextFrame a la interfaz ISmartArtShape y a la clase SmartArtShape respectivamente. Esta propiedad permite obtener todo el texto de SmartArt si no tiene solo texto de nodos. El siguiente código de ejemplo te ayudará a obtener texto del nodo SmartArt.

```py
import aspose.slides as slides

with slides.Presentation(path + "SmartArt.pptx") as pres:
    slide = pres.slides[0]
    smartArt = slide.shapes[0]

    for smartArtNode in smartArt.all_nodes:
        for nodeShape in smartArtNode.shapes:
            if nodeShape.text_frame != None:
                print(nodeShape.text_frame.text)
```



## **Cambiar Tipo de Diseño de SmartArt**
Para cambiar el tipo de diseño de SmartArt. Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de una diapositiva usando su índice.
- Agrega SmartArt BasicBlockList.
- Cambia el LayoutType a BasicProcess.
- Guarda la presentación como un archivo PPTX.
  En el ejemplo dado a continuación, hemos añadido un conector entre dos formas.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Agregar SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Cambiar LayoutType a BasicProcess
    smart.layout = art.SmartArtLayoutType.BASIC_PROCESS
    # Guardando la presentación
    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Verificar Propiedad Oculta de SmartArt**
Ten en cuenta que el método com.aspose.slides.ISmartArtNode.isHidden() devuelve verdadero si este nodo es un nodo oculto en el modelo de datos. Para verificar la propiedad oculta de cualquier nodo de SmartArt. Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase `Presentation`.
- Agrega SmartArt RadialCycle.
- Agrega un nodo en SmartArt.
- Verifica la propiedad isHidden.
- Guarda la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos añadido un conector entre dos formas.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Agregar SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.RADIAL_CYCLE)
    # Agregar nodo en SmartArt 
    node = smart.all_nodes.add_node()
    # Verificar la propiedad isHidden
    if node.is_hidden:
        print("oculto")
        # Realizar alguna acción o notificación
    # Guardando la presentación
    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Obtener o Establecer Tipo de Gráfico de Organización**
Los métodos com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permiten obtener o establecer el tipo de gráfico de organización asociado con el nodo actual. Para obtener o establecer el tipo de gráfico de organización. Por favor, sigue los pasos a continuación:

- Crea una instancia de la clase `Presentation`.
- Agrega SmartArt en la diapositiva.
- Obtén o establece el tipo de gráfico de organización.
- Guarda la presentación como un archivo PPTX.
  En el ejemplo dado a continuación, hemos añadido un conector entre dos formas.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Agregar SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.ORGANIZATION_CHART)
    # Obtener o Establecer el tipo de gráfico de organización 
    smart.nodes[0].organization_chart_layout = art.OrganizationChartLayoutType.LEFT_HANGING
    # Guardando la presentación
    presentation.save("OrganizeChartLayoutType_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Crear Gráfico de Organización con Imágenes**
Aspose.Slides para Python a través de .NET proporciona una API simple para crear gráficos de tipo PictureOrganization de manera fácil. Para crear un gráfico en una diapositiva:

1. Crea una instancia de la clase `Presentation`.
1. Obtén la referencia de una diapositiva usando su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.PictureOrganizationChart).
1. Guarda la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as pres:
    smartArt = pres.slides[0].shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    pres.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```