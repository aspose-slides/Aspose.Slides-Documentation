---
title: Gerenciar Controles ActiveX em Apresentações no .NET
linktitle: ActiveX
type: docs
weight: 80
url: /pt/net/activex/
keywords:
- ActiveX
- controle ActiveX
- gerenciar ActiveX
- adicionar ActiveX
- modificar ActiveX
- reprodutor de mídia
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Editar caixas de texto e botões ActiveX, atualizar visualizações de controle e reutilizar um controle Windows Media Player em apresentações do PowerPoint com Aspose.Slides para .NET."
---
## **Introdução**

Os controles ActiveX fornecem a um slide do PowerPoint elementos interativos, como caixas de texto, botões de comando e reprodutores de mídia. Aspose.Slides para .NET expõe os controles de um slide através de [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/). Use esta coleção para editar um controle, movê‑lo no slide ou removê‑lo.

## **Listar Controles ActiveX e Suas Propriedades Armazenadas**

Para inspecionar um modelo desconhecido, abra‑o para leitura e itere pelos controles em cada slide. O exemplo relata o número do slide, o nome do controle, [ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/), e cada par chave‑valor em [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties). Ele lê a apresentação sem ativar controles, disparar eventos ou macros, alterar valores ou salvar o arquivo.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

A saída selecionada de `ActiveX.pptm` mostra uma caixa de texto e um botão de comando.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Uma coleção de propriedades vazia aparece como `[]`. Para controles que usam armazenamento binário, `Properties` pode retornar `null`, exibido como `Properties unavailable`. Se precisar apenas dos nomes, use [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) após a verificação de null. O relatório lista as propriedades disponíveis na apresentação. Um controle pode suportar propriedades adicionais em tempo de execução.

## **Modificar Controles ActiveX**

O exemplo pressupõe uma apresentação habilitada para macros com uma caixa de texto chamada `TextBox1` e um botão de comando chamado `CommandButton1` no primeiro slide. Ele utiliza a [coleção de propriedades de controle](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) para alterar o valor da caixa de texto e a legenda do botão. Cada controle também possui uma visualização estática que o PowerPoint pode exibir antes da ativação. Forneça um PNG para cada controle mostrando seu texto e aparência atualizados. O exemplo atribui essas imagens através de [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/).

O exemplo move cada controle no primeiro slide 100 pontos para baixo, alterando seu [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/). Ele salva a apresentação editada no formato PPTM e, em seguida, usa [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) para salvar uma segunda cópia com todos os controles ActiveX removidos desse slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```

## **Adicionar um Controle ActiveX Media Player**

Para reutilizar um controle Windows Media Player configurado, comece com um modelo cujo primeiro slide contém um player chamado `WindowsMediaPlayer1`. [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) copia todo o slide para uma nova apresentação. O exemplo define a `URL` do player em sua [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) e salva o slide clonado como o único slide da saída. O vídeo permanece externo, portanto escolha um caminho que o player possa acessar durante a reprodução.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```

## **FAQ**

**O Aspose.Slides pode preservar controles ActiveX sem executá‑los?**

Sim. Aspose.Slides pode ler e salvar controles, incluindo suas propriedades e posições, sem ativá‑los.

**Como os controles ActiveX diferem dos objetos OLE?**

Os controles ActiveX permitem que os usuários interajam com um slide, por exemplo inserindo texto ou clicando em um botão. Um [OLE object](/slides/pt/net/manage-ole/) permite que um slide contenha ou vincule a conteúdo gerenciado por outra aplicação, como uma planilha do Excel.

**Os eventos ActiveX ainda dispararão macros VBA depois que eu salvar uma apresentação com Aspose.Slides?**

Salve a apresentação em um formato habilitado para macros, como PPTM, para manter seu projeto VBA. O PowerPoint para Windows pode executar os manipuladores de evento existentes quando suas configurações de segurança permitem tanto controles ActiveX quanto macros.