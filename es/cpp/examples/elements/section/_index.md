---
title: Sección
type: docs
weight: 90
url: /es/cpp/examples/elements/section/
keywords:
- ejemplo de código
- sección
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Gestiona secciones de diapositivas en Aspose.Slides para C++: crea, renombra, reordena y agrupa diapositivas con ejemplos en C++ para PPT, PPTX y ODP."
---
Ejemplos para gestionar secciones de presentación—añadir, acceder, eliminar y renombrar programáticamente usando **Aspose.Slides for C++**.

## **Agregar una sección**

Crear una sección que comience en una diapositiva específica.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Especifica la diapositiva que marca el inicio de la sección.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Acceder a una sección**

Leer la información de la sección de una presentación.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Accede a una sección por índice.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Eliminar una sección**

Eliminar una sección añadida previamente.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Elimina la primera sección.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Renombrar una sección**

Cambiar el nombre de una sección existente.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```