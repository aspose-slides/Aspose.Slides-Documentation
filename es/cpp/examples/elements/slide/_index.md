---
title: Diapositiva
type: docs
weight: 10
url: /es/cpp/examples/elements/slide/
keywords:
- ejemplo de código
- diapositiva
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Controlar diapositivas en Aspose.Slides for C++: crear, clonar, reordenar, redimensionar, establecer fondos y aplicar transiciones con C++ para presentaciones PPT, PPTX y ODP."
---
Este artículo proporciona una serie de ejemplos que demuestran cómo trabajar con diapositivas usando **Aspose.Slides for C++**. Aprenderá a añadir, acceder, clonar, reordenar y eliminar diapositivas usando la clase `Presentation`.

Cada ejemplo a continuación incluye una breve explicación seguida de un fragmento de código en C++.

## **Añadir una diapositiva**

Para añadir una nueva diapositiva, primero debe seleccionar un diseño. En este ejemplo, utilizamos el diseño `Blank` y añadimos una diapositiva vacía a la presentación.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Nota:** Cada diseño de diapositiva se deriva de una diapositiva maestra, que define el diseño general y la estructura de los marcadores de posición. La imagen a continuación ilustra cómo se organizan las diapositivas maestras y sus diseños asociados en PowerPoint.

![Relación entre diapositiva maestra y diseño](master-layout-slide.png)

## **Acceder a diapositivas por índice**

Puede acceder a las diapositivas usando su índice, o encontrar el índice de una diapositiva basándose en una referencia. Esto es útil para iterar o modificar diapositivas específicas.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Añadir otra diapositiva vacía.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Acceder a diapositivas por índice.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Obtener el índice de la diapositiva a partir de una referencia, y luego acceder a ella por índice.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Clonar una diapositiva**

Este ejemplo demuestra cómo clonar una diapositiva existente. La diapositiva clonada se añade automáticamente al final de la colección de diapositivas.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Reordenar diapositivas**

Puede cambiar el orden de las diapositivas moviendo una a un nuevo índice. En este caso, movemos una diapositiva clonada a la primera posición.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Eliminar una diapositiva**

Para eliminar una diapositiva, simplemente haga referencia a ella y llame a `Remove`. Este ejemplo añade una segunda diapositiva y luego elimina la original, dejando solo la nueva.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```