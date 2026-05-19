---
title: Gestionar SmartArt en presentaciones de PowerPoint usando C++
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/cpp/manage-smartart/
keywords:
- SmartArt
- texto de SmartArt
- tipo de diseño
- propiedad oculta
- organigrama
- organigrama con imágenes
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para C++ utilizando ejemplos de código claros que aceleran el diseño y la automatización de diapositivas."
---
## **Visión general**

SmartArt es un diagrama de PowerPoint formado por nodos, formas de nodo y un diseño. Con Aspose.Slides para C++, puedes crear SmartArt, leer el texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas con imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo de SmartArt puede contener una o más formas. Para leer el texto visible, recorre [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartart/get_allnodes/), luego lee el [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) devuelto por [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **Cambiar el tipo de diseño de un objeto SmartArt**

El diseño de SmartArt controla cómo se disponen y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartartlayouttype/), lo cambia al valor `BasicProcess` y guarda la presentación.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Comprobar si un nodo de SmartArt está oculto**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura incluso cuando el diseño seleccionado no los muestra como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartartlayouttype/) y verifica el estado oculto del nodo.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Obtener o establecer el diseño del organigrama**

Para los diagramas SmartArt que usan un diseño de organigrama, [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) y [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) definen cómo se disponen los nodos hijos bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijos cuelguen a la izquierda, a la derecha o en ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño del primer nodo al valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/organizationchartlayouttype/).

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Crear un organigrama con imágenes**

Un organigrama con imágenes es un diseño de SmartArt creado para diagramas jerárquicos que incluyen marcadores de posición de imágenes. Usa el valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartartlayouttype/) al añadir el objeto SmartArt a una diapositiva.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preguntas frecuentes**

**¿SmartArt admite el reflejo o reversión para idiomas de escritura de derecha a izquierda?**

Sí. El método [SmartArt::set_IsReversed](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/smartart/set_isreversed/) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño de SmartArt seleccionado admite la reversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación conservando el formato?**

Puedes [clonar la forma SmartArt](/slides/es/cpp/shape-manipulations/) con [ShapeCollection::AddClone](https://reference.aspose.com/slides/es/cpp/aspose.slides/shapecollection/addclone/) o [clonar toda la diapositiva](/slides/es/cpp/clone-slides/) que contiene el SmartArt. Ambos enfoques conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

Renderiza la diapositiva [/slides/es/cpp/convert-powerpoint-to-png/](/slides/es/cpp/convert-powerpoint-to-png/) o toda la presentación a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt específico en una diapositiva si hay varios?**

Establece un [Shape::set_AlternativeText](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/set_alternativetext/) o un [Shape::set_Name](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/set_name/) distintivo en la forma SmartArt, busca ese valor en [BaseSlide::get_Shapes](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseslide/get_shapes/), y luego verifica que la forma coincidente sea un [ISmartArt](https://reference.aspose.com/slides/es/cpp/aspose.slides.smartart/ismartart/).