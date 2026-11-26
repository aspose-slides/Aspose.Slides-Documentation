---
title: Gerenciar controles ActiveX em apresentações usando Python
linktitle: ActiveX
type: docs
weight: 80
url: /pt/python-java/activex/
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
description: "Edite caixas de texto e botões ActiveX, atualize as visualizações dos controles e reutilize um controle Windows Media Player em apresentações do PowerPoint com Aspose.Slides para Python via Java."
---
## **Introdução**

Os controles ActiveX fornecem a um slide do PowerPoint elementos interativos, como caixas de texto, botões de comando e reprodutores de mídia. Aspose.Slides para Python via Java expõe os controles de um slide através de [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Use esta coleção para editar um controle, movê‑lo no slide ou removê‑lo.

## **Listar controles ActiveX e suas propriedades armazenadas**

Para inspecionar um modelo desconhecido, abra‑o para leitura e itere pelos controles em cada slide. O exemplo relata o número do slide, o nome do controle, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), e cada par chave‑valor em [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Ele lê a apresentação sem ativar os controles, invocar eventos ou macros, alterar valores ou salvar o arquivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
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

Uma coleção de propriedades vazia aparece como `[]`. Para controles que utilizam armazenamento binário, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) pode retornar `None`, mostrado como `Properties unavailable`. Se precisar apenas dos nomes, use [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) após verificar se a coleção está disponível. O relatório lista as propriedades disponíveis na apresentação. Um controle pode suportar propriedades adicionais em tempo de execução.

## **Modificar controles ActiveX**

O exemplo espera uma apresentação com macro habilitada contendo uma caixa de texto chamada `TextBox1` e um botão de comando chamado `CommandButton1` no primeiro slide. Ele usa a [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) para alterar o valor da caixa de texto e a legenda do botão. Cada controle também possui uma visualização estática que o PowerPoint pode exibir antes da ativação. Forneça um PNG para cada controle mostrando seu texto e aparência atualizados. O exemplo atribui essas imagens através de [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

O exemplo move cada controle no primeiro slide 100 pontos para baixo, definindo sua moldura com [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Ele salva a apresentação editada no formato PPTM e, em seguida, usa [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) para salvar uma segunda cópia com todos os controles ActiveX removidos daquele slide.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Adicionar um controle ActiveX Media Player**

Para reutilizar um controle Windows Media Player configurado, comece com um modelo cujo primeiro slide contenha um reprodutor chamado `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) copia todo o slide para uma nova apresentação. O exemplo define a `URL` do reprodutor em sua [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) e salva o slide clonado como o único slide na saída. O vídeo permanece externo, portanto escolha um caminho que o reprodutor possa acessar durante a reprodução.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **Perguntas frequentes**

**O Aspose.Slides pode preservar controles ActiveX sem executá‑los?**

Sim. O Aspose.Slides pode ler e salvar os controles, incluindo suas propriedades e posições, sem ativá‑los.

**Como os controles ActiveX diferem dos objetos OLE?**

Os controles ActiveX permitem que os usuários interajam com um slide, por exemplo inserindo texto ou clicando em um botão. Um [objeto OLE](/slides/pt/python-java/manage-ole/) permite que um slide contenha ou vincule a conteúdo gerenciado por outro aplicativo, como uma planilha do Excel.

**Os eventos ActiveX ainda dispararão macros VBA depois que eu salvar uma apresentação com Aspose.Slides?**

Salve a apresentação em um formato com macro habilitada, como PPTM, para preservar seu projeto VBA. O PowerPoint para Windows pode executar os manipuladores de eventos existentes quando suas configurações de segurança permitem tanto controles ActiveX quanto macros.