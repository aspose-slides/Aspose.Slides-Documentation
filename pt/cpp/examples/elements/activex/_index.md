---
title: ActiveX
type: docs
weight: 200
url: /pt/cpp/examples/elements/activex/
keywords:
  - exemplo de código
  - ActiveX
  - PowerPoint
  - apresentação
  - C++
  - Aspose.Slides
description: "Veja exemplos de ActiveX do Aspose.Slides for C++: inserir, configurar e controlar objetos ActiveX em apresentações PPT e PPTX com código C++ claro."
---
Este artigo demonstra como adicionar, acessar, remover e configurar controles ActiveX em uma apresentação usando **Aspose.Slides for C++**.

## **Adicionar um controle ActiveX**

Insira um novo controle ActiveX e, opcionalmente, defina suas propriedades.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adicionar um novo controle ActiveX.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Opcionalmente definir algumas propriedades.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Acessar um controle ActiveX**

Leia informações do primeiro controle ActiveX no slide.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Acessar o primeiro controle ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Remover um controle ActiveX**

Exclua um controle ActiveX existente do slide.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Remover o primeiro controle ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Definir propriedades ActiveX**

Adicione um controle e configure várias propriedades ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adicionar um controle Windows Media Player e configurar propriedades.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```