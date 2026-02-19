---
title: Diapositiva maestra
type: docs
weight: 30
url: /es/cpp/examples/elements/master-slide/
keywords:
- ejemplo de código
- diapositiva maestra
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Explore ejemplos de diapositivas maestras de Aspose.Slides para C++: cree, edite y estilice maestros, marcadores de posición y temas en PPT, PPTX y ODP con código C++ claro."
---
Las diapositivas master forman el nivel superior de la jerarquía de herencia de diapositivas en PowerPoint. Una **diapositiva master** define elementos de diseño comunes, como fondos, logotipos y formato de texto. Las **diapositivas de diseño** heredan de las diapositivas master, y las **diapositivas normales** heredan de las diapositivas de diseño.

Este artículo muestra cómo crear, modificar y administrar diapositivas master usando Aspose.Slides para C++.

## **Agregar una diapositiva master**

Este ejemplo muestra cómo crear una nueva diapositiva master clonando la predeterminada. A continuación, añade una pancarta con el nombre de la empresa a todas las diapositivas mediante la herencia de diseño.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Clona la diapositiva maestra predeterminada.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Añade una pancarta con el nombre de la empresa en la parte superior de la diapositiva maestra.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Asigna la nueva diapositiva maestra a una diapositiva de diseño.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Asigna la diapositiva de diseño a la primera diapositiva de la presentación.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Nota 1:** Las diapositivas master ofrecen una forma de aplicar una identidad corporativa o elementos de diseño compartidos en todas las diapositivas. Cualquier cambio realizado en la master se reflejará automáticamente en las diapositivas de diseño y normales dependientes.

> 💡 **Nota 2:** Cualquier forma o formato añadido a una diapositiva master se hereda en las diapositivas de diseño y, a su vez, en todas las diapositivas normales que utilizan esos diseños.  
> La imagen a continuación ilustra cómo un cuadro de texto añadido en una diapositiva master se renderiza automáticamente en la diapositiva final.

![Master Inheritance Example](master-slide-banner.png)

## **Acceder a una diapositiva master**

Puede acceder a las diapositivas master mediante la colección master de la presentación. A continuación se muestra cómo obtenerlas y trabajar con ellas:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Cambiar el tipo de fondo.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Eliminar una diapositiva master**

Las diapositivas master pueden eliminarse por índice o por referencia.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Eliminar una diapositiva maestra por índice.
    presentation->get_Masters()->RemoveAt(0);

    // Eliminar una diapositiva maestra por referencia.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Eliminar diapositivas master no usadas**

Algunas presentaciones contienen diapositivas master que no se utilizan. Eliminar estas diapositivas puede ayudar a reducir el tamaño del archivo.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Eliminar todas las diapositivas maestras no usadas (incluso las marcadas como Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```