---
title: Gerenciar controles ActiveX em apresentações com Python
linktitle: ActiveX
type: docs
weight: 80
url: /pt/python-net/activex/
keywords:
- ActiveX
- controle ActiveX
- gerenciar ActiveX
- adicionar ActiveX
- modificar ActiveX
- reprodutor de mídia
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Editar caixas de texto e botões ActiveX, atualizar pré‑visualizações de controles e reutilizar um controle Windows Media Player em apresentações do PowerPoint com Aspose.Slides for Python via .NET."
---
## **Introdução**

Os controles ActiveX fornecem a um slide do PowerPoint elementos interativos, como caixas de texto, botões de comando e reprodutores de mídia. Aspose.Slides for Python via .NET expõe os controles de um slide por meio de [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Use esta coleção para editar um controle, movê-lo no slide ou removê-lo.

## **Listar controles ActiveX e suas propriedades armazenadas**

Para inspecionar um modelo desconhecido, abra-o para leitura e itere pelos controles em cada slide. O exemplo relata o número do slide, o nome do controle, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), e cada par chave‑valor em [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Ele lê a apresentação sem ativar os controles, invocar eventos ou macros, alterar valores ou salvar o arquivo.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
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

Uma coleção de propriedades vazia aparece como `[]`. Para controles que utilizam armazenamento binário, `properties` pode retornar `None`, exibido como `Properties unavailable`. Se você precisar somente dos nomes, use [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) após verificar se é `None`. O relatório lista as propriedades disponíveis na apresentação. Um controle pode suportar propriedades adicionais em tempo de execução.

## **Modificar controles ActiveX**

O exemplo espera uma apresentação com macro habilitada contendo uma caixa de texto chamada `TextBox1` e um botão de comando chamado `CommandButton1` no primeiro slide. Ele usa a [coleção de propriedades do controle](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) para alterar o valor da caixa de texto e a legenda do botão. Cada controle também possui uma pré‑visualização estática que o PowerPoint pode exibir antes da ativação. Forneça um PNG para cada controle mostrando seu texto e aparência atualizados. O exemplo atribui essas imagens através de [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

O exemplo move todos os controles do primeiro slide para baixo em 100 pontos alterando seu [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Ele salva a apresentação editada em formato PPTM e, em seguida, usa [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) para salvar uma segunda cópia com todos os controles ActiveX removidos desse slide.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Adicionar um controle ActiveX Media Player**

Para reutilizar um controle Windows Media Player configurado, comece com um modelo cujo primeiro slide contém um player chamado `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) copia o slide inteiro para uma nova apresentação. O exemplo define o `URL` do player em sua [coleção de propriedades](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) e salva o slide clonado como o único slide na saída. O vídeo permanece externo, portanto escolha um caminho que o player possa acessar durante a reprodução.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**O Aspose.Slides pode preservar controles ActiveX sem executá‑los?**

Sim. O Aspose.Slides pode ler e salvar os controles, incluindo suas propriedades e posições, sem ativá‑los.

**Como os controles ActiveX diferem dos objetos OLE?**

Os controles ActiveX permitem que os usuários interajam com um slide, por exemplo inserindo texto ou clicando em um botão. Um [objeto OLE](/slides/pt/python-net/manage-ole/) permite que um slide contenha ou vincule conteúdo gerenciado por outro aplicativo, como uma planilha do Excel.

**Os eventos ActiveX ainda dispararão macros VBA após eu salvar uma apresentação com Aspose.Slides?**

Salve a apresentação em um formato habilitado para macros, como PPTM, para manter seu projeto VBA. O PowerPoint para Windows pode executar os manipuladores de eventos existentes quando as configurações de segurança permitem tanto controles ActiveX quanto macros.