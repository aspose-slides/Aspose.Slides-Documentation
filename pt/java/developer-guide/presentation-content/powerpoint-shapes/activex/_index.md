---
title: Gerenciar controles ActiveX em apresentações em Java
linktitle: ActiveX
type: docs
weight: 80
url: /pt/java/activex/
keywords:
- ActiveX
- controle ActiveX
- gerenciar ActiveX
- adicionar ActiveX
- modificar ActiveX
- reprodutor de mídia
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Edite caixas de texto e botões ActiveX, atualize pré-visualizações de controles e reutilize um controle Windows Media Player em apresentações do PowerPoint com Aspose.Slides for Java."
---
## **Introdução**

Os controles ActiveX fornecem a um slide do PowerPoint elementos interativos, como caixas de texto, botões de comando e reprodutores de mídia. Aspose.Slides for Java expõe os controles de um slide através de [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Use essa coleção para editar um controle, movê‑lo no slide ou removê‑lo.

## **Listar Controles ActiveX e Suas Propriedades Armazenadas**

Para inspecionar um modelo desconhecido, abra‑o para leitura e itere pelos controles em cada slide. O exemplo relata o número do slide, o nome do controle, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), e cada par chave‑valor em [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Ele lê a apresentação sem ativar os controles, invocar eventos ou macros, alterar valores ou salvar o arquivo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
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

Uma coleção de propriedades vazia aparece como `[]`. Para controles que utilizam armazenamento binário, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) pode retornar `null`, exibido como `Properties unavailable`. Se precisar apenas dos nomes, use [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) após a verificação de null. O relatório lista as propriedades disponíveis na apresentação. Um controle pode suportar propriedades adicionais em tempo de execução.

## **Modificar Controles ActiveX**

O exemplo espera uma apresentação habilitada para macro com uma caixa de texto chamada `TextBox1` e um botão de comando chamado `CommandButton1` no primeiro slide. Ele usa a [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) para alterar o valor da caixa de texto e a legenda do botão. Cada controle também possui uma visualização estática que o PowerPoint pode exibir antes da ativação. Forneça um PNG para cada controle mostrando seu texto e aparência atualizados. O exemplo atribui essas imagens através de [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

O exemplo move cada controle no primeiro slide para baixo em 100 pontos, definindo sua moldura com [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Ele salva a apresentação editada no formato PPTM e, em seguida, usa [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) para salvar uma segunda cópia com todos os controles ActiveX removidos desse slide.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Adicionar um Controle Media Player ActiveX**

Para reutilizar um controle Windows Media Player configurado, comece com um modelo cujo primeiro slide contém um player chamado `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) copia todo o slide para uma nova apresentação. O exemplo define o `URL` do player em sua [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) e salva o slide clonado como o único slide na saída. O vídeo permanece externo, então escolha um caminho que o player possa acessar durante a reprodução.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **FAQ**

**Can Aspose.Slides preserve ActiveX controls without running them?**  
Sim. O Aspose.Slides pode ler e salvar controles, incluindo suas propriedades e posições, sem ativá‑los.

**How do ActiveX controls differ from OLE objects?**  
Os controles ActiveX permitem que os usuários interajam com um slide, por exemplo inserindo texto ou clicando em um botão. Um [OLE object](/slides/pt/java/manage-ole/) permite que um slide contenha ou vincule conteúdo gerenciado por outro aplicativo, como uma planilha do Excel.

**Will ActiveX events still trigger VBA macros after I save a presentation with Aspose.Slides?**  
Salve a apresentação em um formato habilitado para macro, como PPTM, para manter seu projeto VBA. O PowerPoint para Windows pode executar os manipuladores de eventos existentes quando suas configurações de segurança permitem tanto controles ActiveX quanto macros.