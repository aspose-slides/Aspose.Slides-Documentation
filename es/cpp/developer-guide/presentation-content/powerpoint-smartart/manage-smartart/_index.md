---
title: Administrar SmartArt en presentaciones de PowerPoint usando C++
linktitle: Administrar SmartArt
type: docs
weight: 10
url: /es/cpp/manage-smartart/
keywords:
- SmartArt
- Texto de SmartArt
- Tipo de diseño
- Propiedad oculta
- Organigrama
- Organigrama de imagen
- PowerPoint
- Presentación
- C++
- Aspose.Slides
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para C++ utilizando ejemplos de código claros que aceleran el diseño de diapositivas y la automatización."
---

## **Obtener texto de un objeto SmartArt**
Ahora se ha añadido la propiedad TextFrame a la interfaz ISmartArtShape y a la clase SmartArtShape, respectivamente. Esta propiedad le permite obtener todo el texto de SmartArt si no solo tiene texto de nodos. El siguiente código de ejemplo le ayudará a obtener el texto de un nodo SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **Cambiar el tipo de diseño de un objeto SmartArt**
Para cambiar el tipo de diseño de SmartArt, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtenga la referencia de una diapositiva usando su índice.
- Añada SmartArt BasicBlockList.
- Cambie LayoutType a BasicProcess.
- Guarde la presentación como un archivo PPTX.

En el ejemplo a continuación, hemos añadido un conector entre dos formas.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Comprobar la propiedad Hidden de un objeto SmartArt**
Tenga en cuenta que el método com.aspose.slides.ISmartArtNode.isHidden() devuelve true si este nodo es un nodo oculto en el modelo de datos. Para comprobar la propiedad hidden de cualquier nodo de SmartArt, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Añada SmartArt RadialCycle.
- Añada un nodo en SmartArt.
- Compruebe la propiedad isHidden.
- Guarde la presentación como un archivo PPTX.

En el ejemplo a continuación, hemos añadido un conector entre dos formas.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **Obtener o establecer el tipo de organigrama**
Los métodos com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() y setOrganizationChartLayout(int) permiten obtener o establecer el tipo de organigrama asociado al nodo actual. Para obtener o establecer el tipo de organigrama, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Añada SmartArt en la diapositiva.
- Obtenga o establezca el tipo de organigrama.
- Guarde la presentación como un archivo PPTX.

En el ejemplo a continuación, hemos añadido un conector entre dos formas.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **Obtener o establecer el estado de un SmartArt**
Algunos diagramas SmartArt no admiten la inversión, por ejemplo; Vertical bullet list,Vertical Process,Descending Process,Funnel,Gear,,Balance,Circle Relationship,Hexagon Cluster,Reverse List,Stacked Venn. Para cambiar la orientación de SmartArt, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Añada SmartArt en la diapositiva.
- Obtenga o establezca el estado del diagrama SmartArt.
- Guarde la presentación como un archivo PPTX.

En el ejemplo a continuación, hemos añadido un conector entre dos formas.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Crear un organigrama Picture Organization**
Aspose.Slides for C++ proporciona una API sencilla para crear diagramas PictureOrganization de forma fácil. Para crear un diagrama en una diapositiva:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenga la referencia de una diapositiva por su índice.
3. Añada un diagrama con datos predeterminados junto con el tipo deseado (ChartType.PictureOrganizationChart).
4. Guarde la presentación modificada en un archivo PPTX

El siguiente código se utiliza para crear un diagrama.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```


## **Preguntas frecuentes**

**¿SmartArt admite la inversión/reflejo para idiomas RTL?**

Sí. El método [set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) cambia la dirección del diagrama (LTR/RTL) si el tipo de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación preservando el formato?**

Puede [clonar la forma SmartArt](/slides/es/cpp/shape-manipulations/) mediante la colección de formas ([ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/)) o [clonar la diapositiva completa](/slides/es/cpp/clone-slides/) que contiene esta forma. Ambos enfoques conservan el tamaño, la posición y el estilo.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Renderice la diapositiva](/slides/es/cpp/convert-powerpoint-to-png/) (o toda la presentación) a PNG/JPEG mediante la API que convierte diapositivas/presentaciones en imágenes — SmartArt se dibujará como parte de la diapositiva.

**¿Cómo puedo seleccionar programáticamente un SmartArt específico en una diapositiva si hay varios?**

Una práctica común es usar [texto alternativo](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) (Alt Text) o un [nombre](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) y buscar la forma por ese atributo dentro de [shapes de la diapositiva](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), luego comprobar el tipo para confirmar que es [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/). La documentación describe técnicas típicas para encontrar y trabajar con formas.