---
title: Gerenciar Controles ActiveX em Apresentações Usando JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /pt/nodejs-java/activex/
keywords:
- ActiveX
- Controle ActiveX
- Gerenciar ActiveX
- Adicionar ActiveX
- Modificar ActiveX
- Reprodutor de mídia
- PowerPoint
- Apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como o Aspose.Slides para Node.js via Java utiliza ActiveX para automatizar e aprimorar apresentações do PowerPoint, proporcionando aos desenvolvedores controle poderoso sobre os slides."
---
## **Introdução**

Os controles ActiveX são usados em apresentações. O Aspose.Slides para Node.js via Java permite adicionar e gerenciar controles ActiveX, mas eles são um pouco mais difíceis de manipular em comparação com formas normais de apresentação. Implementamos suporte para adicionar o controle Active Media Player no Aspose.Slides. Observe que os controles ActiveX não são formas; eles não fazem parte da apresentação's [ShapeCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/). Eles fazem parte da [ControlCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/controlcollection/) separada. Neste tópico, mostraremos como trabalhar com eles.

## **Adicionando o Controle ActiveX Media Player ao Slide**
Para adicionar um controle ActiveX Media Player, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) e gere uma instância de apresentação vazia.  
2. Acesse o slide de destino na classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation).  
3. Adicione o controle ActiveX Media Player usando o método [addControl](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) exposto por [ControlCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/controlcollection/).  
4. Acesse o controle ActiveX Media Player e defina o caminho do vídeo usando suas propriedades.  
5. Salve a apresentação como um arquivo PPTX.  

Este código de exemplo, baseado nas etapas acima, demonstra como adicionar o Controle ActiveX Media Player a um slide:

```javascript
// Criar instância de apresentação vazia
var pres = new aspose.slides.Presentation();
try {
    // Adicionando o controle ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Acessar o controle ActiveX Media Player e definir o caminho do vídeo
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Salvar a apresentação
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modificando o Controle ActiveX**

Para gerenciar um controle ActiveX simples, como uma caixa de texto e um botão de comando simples em um slide, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) e carregue a apresentação que contém controles ActiveX.  
2. Obtenha uma referência ao slide pelo seu índice.  
3. Acesse os controles ActiveX no slide obtendo a [ControlCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/controlcollection/).  
4. Acesse o controle ActiveX TextBox1 usando o objeto [Control](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/control/).  
5. Altere as propriedades do controle ActiveX TextBox1, que incluem texto, fonte, altura da fonte e posição do quadro.  
6. Acesse o segundo controle chamado CommandButton1.  
7. Altere a legenda do botão, a fonte e a posição.  
8. Desloque a posição dos quadros dos controles ActiveX.  
9. Grave a apresentação modificada em um arquivo PPTX.  

Este código de exemplo, baseado nas etapas acima, demonstra como gerenciar um controle ActiveX simples:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Acessando a apresentação com controles ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Acessando o primeiro slide da apresentação
    var slide = pres.getSlides().get_Item(0);
    // alterando o texto da TextBox
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Alterando a imagem substituta. O PowerPoint substituirá esta imagem durante a ativação do ActiveX,
        // então às vezes é OK deixar a imagem inalterada.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Alterando a legenda do botão
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Alterando substituta
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // movendo 100 pontos para baixo
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // removendo controles
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**O Aspose.Slides preserva os controles ActiveX ao ler e regravar se eles não puderem ser executados no runtime Python?**

Sim. O Aspose.Slides os trata como parte da apresentação e pode ler/modificar suas propriedades e quadros; executar os próprios controles não é necessário para preservá-los.

**Como os controles ActiveX diferem dos objetos OLE em uma apresentação?**

Os controles ActiveX são controles interativos gerenciados (botões, caixas de texto, reprodutor de mídia), enquanto [OLE](/slides/pt/nodejs-java/manage-ole/) se refere a objetos de aplicativo incorporados (por exemplo, uma planilha do Excel). Eles são armazenados e manipulados de forma diferente e possuem modelos de propriedades distintos.

**Os eventos ActiveX e macros VBA funcionam se o arquivo foi modificado pelo Aspose.Slides?**

O Aspose.Slides preserva a marcação e os metadados existentes; entretanto, eventos e macros são executados apenas dentro do PowerPoint no Windows quando a segurança permite. A biblioteca não executa VBA.