---
title: ActiveX
type: docs
weight: 200
url: /es/cpp/examples/elements/activex/
keywords:
- ejemplo de código
- ActiveX
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Vea ejemplos de ActiveX de Aspose.Slides para C++: inserte, configure y controle objetos ActiveX en presentaciones PPT y PPTX con código C++ claro."
---
Este artículo muestra cómo añadir, acceder, eliminar y configurar controles ActiveX en una presentación usando **Aspose.Slides for C++**.

## **Añadir un control ActiveX**

Inserte un nuevo control ActiveX y, opcionalmente, establezca sus propiedades.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Añadir un nuevo control ActiveX.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Opcionalmente establecer algunas propiedades.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Acceder a un control ActiveX**

Lea información del primer control ActiveX de la diapositiva.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Acceder al primer control ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Eliminar un control ActiveX**

Elimine un control ActiveX existente de la diapositiva.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Eliminar el primer control ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Establecer propiedades ActiveX**

Añada un control y configure varias propiedades ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Añadir un control de Windows Media Player y configurar propiedades.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```