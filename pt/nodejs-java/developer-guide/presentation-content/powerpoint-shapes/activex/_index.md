---
title: Gerenciar controles ActiveX em apresentações usando JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /pt/nodejs-java/activex/
keywords:
- ActiveX
- controle ActiveX
- gerenciar ActiveX
- adicionar ActiveX
- modificar ActiveX
- reprodutor de mídia
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Edite caixas de texto e botões ActiveX, atualize as pré-visualizações dos controles e reutilize um controle Windows Media Player em apresentações PowerPoint com Aspose.Slides para Node.js via Java."
---
## **Introdução**

Os controles ActiveX fornecem a um slide do PowerPoint elementos interativos, como caixas de texto, botões de comando e reprodutores de mídia. Aspose.Slides para Node.js via Java expõe os controles de um slide através de [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Use esta coleção para editar um controle, movê-lo no slide ou removê-lo.

## **Listar Controles ActiveX e Suas Propriedades Armazenadas**

Para inspecionar um modelo desconhecido, abra‑o para leitura e itere pelos controles em cada slide. O exemplo relata o número do slide, o nome do controle, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), e cada par chave‑valor em [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Ele lê a apresentação sem ativar os controles, invocar eventos ou macros, alterar valores ou salvar o arquivo.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
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

Uma coleção de propriedades vazia aparece como `[]`. Para controles que usam armazenamento binário, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) pode retornar `null`, exibido como `Properties unavailable`. Se você precisar apenas dos nomes, use [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) após a verificação de null. O relatório lista as propriedades disponíveis na apresentação. Um controle pode suportar propriedades adicionais em tempo de execução.

## **Modificar Controles ActiveX**

O exemplo pressupõe uma apresentação habilitada para macro com uma caixa de texto chamada `TextBox1` e um botão de comando chamado `CommandButton1` no primeiro slide. Ele usa a [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) para alterar o valor da caixa de texto e a legenda do botão. Cada controle também possui uma pré‑visualização estática que o PowerPoint pode exibir antes da ativação. Forneça um PNG para cada controle mostrando seu texto e aparência atualizados. O exemplo atribui essas imagens através de [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

O exemplo move cada controle no primeiro slide para baixo em 100 pontos, definindo sua moldura com [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Ele salva a apresentação editada no formato PPTM e, em seguida, usa [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) para salvar uma segunda cópia com todos os controles ActiveX removidos desse slide.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **Adicionar um Controle ActiveX Media Player**

Para reutilizar um controle Windows Media Player configurado, inicie com um modelo cujo primeiro slide contém um player chamado `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) copia todo o slide para uma nova apresentação. O exemplo define o `URL` do player em sua [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) e salva o slide clonado como o único slide na saída. O vídeo permanece externo, portanto escolha um caminho que o player possa acessar durante a reprodução.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **Perguntas Frequentes**

**O Aspose.Slides pode preservar controles ActiveX sem executá‑los?**

Sim. Aspose.Slides pode ler e salvar controles, incluindo suas propriedades e posições, sem ativá‑los.

**Como os controles ActiveX diferem dos objetos OLE?**

Os controles ActiveX permitem que os usuários interajam com um slide, por exemplo inserindo texto ou clicando em um botão. Um [OLE object](/slides/pt/nodejs-java/manage-ole/) permite que um slide contenha ou faça link para conteúdo gerenciado por outra aplicação, como uma planilha Excel.

**Os eventos ActiveX continuarão acionando macros VBA após eu salvar uma apresentação com Aspose.Slides?**

Salve a apresentação em um formato habilitado para macro, como PPTM, para manter seu projeto VBA. O PowerPoint para Windows pode executar os manipuladores de eventos existentes quando suas configurações de segurança permitem tanto controles ActiveX quanto macros.