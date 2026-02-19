---
title: Diapositiva de diseño
type: docs
weight: 20
url: /es/cpp/examples/elements/layout-slide/
keywords:
- ejemplo de código
- diapositiva de diseño
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Domina las diapositivas de diseño en Aspose.Slides para C++: elige, aplica y personaliza diseños de diapositivas, marcadores de posición y patrones maestros con ejemplos en C++ para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo trabajar con **Diapositivas de diseño** en Aspose.Slides para C++. Una diapositiva de diseño define el diseño y el formato heredados por las diapositivas normales. Puedes añadir, acceder, clonar y eliminar diapositivas de diseño, así como limpiar las que no se usan para reducir el tamaño de la presentación.

## **Agregar una diapositiva de diseño**

Puedes crear una diapositiva de diseño personalizada para definir un formato reutilizable. Por ejemplo, podrías añadir un cuadro de texto que aparezca en todas las diapositivas que usan este diseño.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Crear una diapositiva de diseño con un tipo de diseño en blanco y un nombre personalizado.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Añadir un cuadro de texto a la diapositiva de diseño.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Añadir dos diapositivas usando este diseño; ambas heredarán el texto del diseño.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Nota 1:** Las diapositivas de diseño actúan como plantillas para diapositivas individuales. Puedes definir elementos comunes una sola vez y reutilizarlos en muchas diapositivas.

> 💡 **Nota 2:** Cuando añades formas o texto a una diapositiva de diseño, todas las diapositivas basadas en ese diseño mostrarán ese contenido compartido automáticamente.  
> La captura de pantalla a continuación muestra dos diapositivas, cada una heredando un cuadro de texto de la misma diapositiva de diseño.

![Diapositivas heredando contenido de diseño](layout-slide-result.png)

## **Acceder a una diapositiva de diseño**

Las diapositivas de diseño pueden accederse por índice o por tipo de diseño (p. ej., `Blank`, `Title`, `SectionHeader`, etc.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Acceder a una diapositiva de diseño por índice.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Acceder a una diapositiva de diseño por tipo.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Eliminar una diapositiva de diseño**

Puedes eliminar una diapositiva de diseño específica si ya no es necesaria.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Obtener una diapositiva de diseño por tipo y eliminarla.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Eliminar diapositivas de diseño no utilizadas**

Para reducir el tamaño de la presentación, puede que desees eliminar las diapositivas de diseño que no son utilizadas por ninguna diapositiva normal.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Elimina automáticamente todas las diapositivas de diseño que no están referenciadas por ninguna diapositiva.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Clonar una diapositiva de diseño**

Puedes duplicar una diapositiva de diseño usando el método `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Obtener una diapositiva de diseño existente por tipo.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Clonar la diapositiva de diseño al final de la colección de diapositivas de diseño.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Resumen:** Las diapositivas de diseño son herramientas potentes para gestionar un formato coherente en todas las diapositivas. Aspose.Slides permite un control total sobre la creación, gestión y optimización de diapositivas de diseño.