---
title: ActiveX
type: docs
weight: 200
url: /pt/net/examples/elements/activex/
keywords:
- ActiveX
- adicionar ActiveX
- acessar ActiveX
- remover ActiveX
- propriedades do ActiveX
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Veja exemplos de ActiveX do Aspose.Slides for .NET: inserir, configurar e controlar objetos ActiveX em apresentações PPT e PPTX com código C# claro."
---
Este artigo demonstra como adicionar, acessar, remover e configurar controles ActiveX em uma apresentação usando **Aspose.Slides for .NET**.

## **Adicionar um Controle ActiveX**

Insira um novo controle ActiveX e, opcionalmente, defina suas propriedades.

```csharp
static void AddActiveX()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Adiciona um novo controle ActiveX.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

    // Opcionalmente define algumas propriedades.
    control.Properties["Value"] = "Default text";

    presentation.Save("add_activex.pptm", SaveFormat.Pptm);
}
```

## **Acessar um Controle ActiveX**

Leia informações do primeiro controle ActiveX no slide.

```csharp
static void AccessActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    // Acessa o primeiro controle ActiveX.
    var control = slide.Controls.FirstOrDefault();
    if (control != null)
    {
        Console.WriteLine($"Control Name: {control.Name}");
        Console.WriteLine($"Value: {control.Properties["Value"]}");
    }
}
```

## **Remover um Controle ActiveX**

Exclua um controle ActiveX existente do slide.

```csharp
static void RemoveActiveX()
{
    using var presentation = new Presentation("add_activex.pptm");
    var slide = presentation.Slides[0];

    if (slide.Controls.Count > 0)
    {
        // Remove o primeiro controle ActiveX.
        slide.Controls.RemoveAt(0);
    }

    presentation.Save("removed_activex.pptm", SaveFormat.Pptm);
}
```

## **Definir Propriedades do ActiveX**

Adicione um controle e configure várias propriedades do ActiveX.

```csharp
static void SetActiveXProperties()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Adiciona um CommandButton e configura as propriedades.
    var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
    control.Properties["Caption"] = "Click Me";
    control.Properties["Enabled"] = "true";

    presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);
}
```