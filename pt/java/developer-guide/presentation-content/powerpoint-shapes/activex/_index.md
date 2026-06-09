---
title: Gerenciar Controles ActiveX em Apresentações Usando Java
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
description: "Aprenda como o Aspose.Slides para Java utiliza ActiveX para automatizar e aprimorar apresentações do PowerPoint, proporcionando aos desenvolvedores controle avançado sobre os slides."
---
## **Introdução**

Os controles ActiveX são usados em apresentações. Aspose.Slides para Java permite adicionar e gerenciar controles ActiveX, mas eles são um pouco mais difíceis de gerenciar em comparação com formas de apresentação normais. Implementamos suporte para adicionar o controle Active Media Player no Aspose.Slides. Observe que os controles ActiveX não são formas; eles não fazem parte da apresentação's [IShapeCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/). Eles fazem parte da [IControlCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icontrolcollection/) separada. Neste tópico, mostraremos como trabalhar com eles. 

## **Adicionar um Controle ActiveX Media Player a um Slide**
Para adicionar um controle ActiveX Media Player, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e gere uma apresentação vazia.
1. Acesse o slide de destino na [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
1. Adicione o controle ActiveX Media Player usando o método [addControl](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) exposto por [IControlCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icontrolcollection/).
1. Acesse o controle ActiveX Media Player e defina o caminho do vídeo usando suas propriedades.
1. Salve a apresentação como um arquivo PPTX.

Este código de exemplo, baseado nas etapas acima, mostra como adicionar o Controle ActiveX Media Player a um slide:

```java
// Criar instância de apresentação vazia
Presentation pres = new Presentation();
try {
    // Adicionando o controle ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Acessar o controle ActiveX Media Player e definir o caminho do vídeo
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Salvar a apresentação
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificar um Controle ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides para Java 7.1.0 e versões mais recentes estão equipados com componentes para gerenciar controles ActiveX. Você pode acessar o controle ActiveX já adicionado na sua apresentação e modificá‑lo ou excluí‑lo através de suas propriedades.

{{% /alert %}} 

Para gerenciar um controle ActiveX simples, como uma caixa de texto e um botão de comando simples em um slide, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e carregue a apresentação que contém controles ActiveX.
1. Obtenha uma referência ao slide pelo seu índice.
1. Acesse os controles ActiveX no slide acessando a [IControlCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icontrolcollection/).
1. Acesse o controle ActiveX TextBox1 usando o objeto [IControl](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icontrol/).
1. Altere as propriedades do controle ActiveX TextBox1, que incluem texto, fonte, altura da fonte e posição da moldura.
1. Acesse o segundo controle chamado CommandButton1.
1. Altere a legenda do botão, a fonte e a posição.
1. Desloque a posição das molduras dos controles ActiveX.
1. Grave a apresentação modificada em um arquivo PPTX.

Este código de exemplo, baseado nas etapas acima, mostra como gerenciar um controle ActiveX simples: 

```java
// Acessando a apresentação com controles ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Acessando o primeiro slide na apresentação
    ISlide slide = pres.getSlides().get_Item(0);

    // alterando o texto da TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Alterando a imagem substituta. O PowerPoint substituirá esta imagem durante a ativação do ActiveX,
        // então, às vezes, é aceitável deixar a imagem inalterada.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Alterando a legenda do botão
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Alterando substituto
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // movendo 100 pontos para baixo
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // removendo controles
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

**O Aspose.Slides preserva os controles ActiveX ao ler e salvar novamente se eles não puderem ser executados no runtime Java?**

Sim. O Aspose.Slides trata-os como parte da apresentação e pode ler/modificar suas propriedades e molduras; executar os próprios controles não é necessário para preservá‑los.

**Como os controles ActiveX diferem de objetos OLE em uma apresentação?**

Os controles ActiveX são controles interativos gerenciados (botões, caixas de texto, reprodutor de mídia), enquanto [OLE](/slides/pt/java/manage-ole/) se refere a objetos de aplicação incorporados (por exemplo, uma planilha do Excel). Eles são armazenados e manipulados de forma diferente e possuem modelos de propriedades distintos.

**Eventos ActiveX e macros VBA funcionam se o arquivo foi modificado pelo Aspose.Slides?**

O Aspose.Slides preserva a marcação e os metadados existentes; porém, eventos e macros são executados apenas dentro do PowerPoint no Windows quando a segurança permite. A biblioteca não executa VBA.