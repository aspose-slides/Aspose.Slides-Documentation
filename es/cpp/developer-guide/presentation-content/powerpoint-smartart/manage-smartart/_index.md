---
title: Administrar SmartArt
type: docs
weight: 10
url: /es/cpp/manage-smartart/
---

## **Obtener texto de SmartArt**
Ahora se ha añadido la propiedad TextFrame a la interfaz ISmartArtShape y a la clase SmartArtShape, respectivamente. Esta propiedad te permite obtener todo el texto de SmartArt si no tiene solo texto de nodos. El siguiente código de muestra te ayudará a obtener texto del nodo de SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **Cambiar el tipo de diseño de cualquier SmartArt**
Para cambiar el tipo de diseño de SmartArt, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtén la referencia de una diapositiva utilizando su índice.
- Añade SmartArt BasicBlockList.
- Cambia LayoutType a BasicProcess.
- Escribe la presentación como un archivo PPTX.
  En el ejemplo que se da a continuación, hemos añadido un conector entre dos formas.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Comprobar la propiedad oculta de SmartArt**
Ten en cuenta que el método com.aspose.slides.ISmartArtNode.isHidden() devuelve verdadero si este nodo es un nodo oculto en el modelo de datos. Para comprobar la propiedad oculta de cualquier nodo de SmartArt, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Añade SmartArt RadialCycle.
- Añade un nodo en SmartArt.
- Comprueba la propiedad isHidden.
- Escribe la presentación como un archivo PPTX.

En el ejemplo que se da a continuación, hemos añadido un conector entre dos formas.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **Obtener o establecer el tipo de diagrama organizacional**
Los métodos com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permiten obtener o establecer el tipo de diagrama organizacional asociado con el nodo actual. Para obtener o establecer el tipo de diagrama organizacional, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Añade SmartArt en la diapositiva.
- Obtén o establece el tipo de diagrama organizacional.
- Escribe la presentación como un archivo PPTX.
  En el ejemplo que se da a continuación, hemos añadido un conector entre dos formas.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **Obtener o establecer el estado de SmartArt**
Algunos diagramas de SmartArt no admiten la inversión, por ejemplo; Lista de viñetas vertical, Proceso vertical, Proceso descendente, Embudo, Engranaje, Balance, Relación circular, Agrupación hexagonal, Lista invertida, Diagrama de Venn apilado. Para cambiar la orientación de SmartArt, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Añade SmartArt en la diapositiva.
- Obtén o establece el estado del diagrama de SmartArt.
- Escribe la presentación como un archivo PPTX.
  En el ejemplo que se da a continuación, hemos añadido un conector entre dos formas.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Crear un diagrama organizacional de imagen**
Aspose.Slides para C++ proporciona una API simple para crear y diagramas organizacionales de imagen de manera sencilla. Para crear un diagrama en una diapositiva:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva por su índice.
1. Añade un diagrama con datos predeterminados junto con el tipo deseado (ChartType.PictureOrganizationChart).
1. Escribe la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un diagrama.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```