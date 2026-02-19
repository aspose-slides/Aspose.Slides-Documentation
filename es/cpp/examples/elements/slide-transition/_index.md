---
title: Transición de diapositiva
type: docs
weight: 110
url: /es/cpp/examples/elements/slide-transition/
keywords:
- ejemplo de código
- transición de diapositiva
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domina las transiciones de diapositivas en Aspose.Slides for C++: agrega, personaliza y encadena efectos y duraciones con ejemplos en C++ para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo aplicar efectos de transición de diapositivas y tiempos con **Aspose.Slides for C++**.

## **Agregar una transición de diapositiva**
Aplicar un efecto de transición de desvanecimiento a la primera diapositiva.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Aplicar una transición de desvanecimiento.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Acceder a una transición de diapositiva**
Leer el tipo de transición asignado actualmente a una diapositiva.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Acceder al tipo de transición.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Eliminar una transición de diapositiva**
Eliminar cualquier efecto de transición estableciendo el tipo a `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Eliminar la transición estableciendo None.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Establecer la duración de la transición**
Especificar cuánto tiempo se muestra la diapositiva antes de avanzar automáticamente.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // En milisegundos.

    presentation->Dispose();
}
```