---
title: Gerenciar Controles ActiveX em Apresentações Usando Python
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
description: "Saiba como o Aspose.Slides for Python via Java usa ActiveX para automatizar e aprimorar apresentações do PowerPoint, oferecendo aos desenvolvedores controle avançado sobre os slides."
---
## **Introdução**

Controles ActiveX são usados em apresentações. Aspose.Slides for Python via Java permite que você adicione e gerencie controles ActiveX, mas eles são um pouco mais difíceis de manipular em comparação com formas normais de apresentação. Aspose.Slides oferece suporte à adição de controles ActiveX Media Player. Observe que os controles ActiveX não são formas; eles não fazem parte da [ShapeCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/) da apresentação. Eles fazem parte da separada [ControlCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/controlcollection/) em vez disso. Neste tópico, mostraremos como trabalhar com eles.

## **Adicionar um Controle ActiveX Media Player a um Slide**

Para adicionar um controle ActiveX Media Player, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e gere uma instância de apresentação vazia.
2. Acesse o slide de destino em [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
3. Adicione o controle ActiveX Media Player usando o método [addControl](https://reference.aspose.com/slides/pt/python-java/aspose.slides/controlcollection/#addControl) exposto por [ControlCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/controlcollection/).
4. Acesse o controle ActiveX Media Player e defina o caminho do vídeo usando suas propriedades.
5. Salve a apresentação como um arquivo PPTX.

Este código de exemplo, baseado nas etapas acima, mostra como adicionar um controle ActiveX Media Player a um slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Crie uma apresentação vazia.
presentation = Presentation()
try:
    # Adicione o controle ActiveX Media Player.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Defina o caminho do vídeo.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Salve a apresentação.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modificar um Controle ActiveX**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java fornece componentes para gerenciar controles ActiveX. Você pode acessar o controle ActiveX já adicionado em sua apresentação e modificá‑lo ou excluí‑lo através de suas propriedades.
{{% /alert %}}

Para gerenciar um controle ActiveX simples, como uma caixa de texto e um botão de comando simples em um slide, faça o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação que contém controles ActiveX.
2. Obtenha uma referência ao slide pelo seu índice.
3. Acesse os controles ActiveX no slide acessando a [ControlCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/controlcollection/).
4. Acesse o controle ActiveX TextBox1 usando o objeto [Control](https://reference.aspose.com/slides/pt/python-java/aspose.slides/control/).
5. Altere as propriedades do controle ActiveX TextBox1, que incluem texto, fonte, altura da fonte e posição da moldura.
6. Acesse o segundo controle ActiveX chamado CommandButton1.
7. Modifique a legenda do botão, a fonte e a posição.
8. Desloque a posição das molduras dos controles ActiveX.
9. Grave a apresentação modificada em um arquivo PPTM.

Este código de exemplo, baseado nas etapas acima, mostra como gerenciar um controle ActiveX simples:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Carregue a apresentação com controles ActiveX.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Acesse o primeiro slide.
        slide = presentation.getSlides().get_Item(0)

        # Altere o texto da caixa de texto.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Altere a imagem substituta. O PowerPoint a substitui durante a ativação do ActiveX,
            # portanto ela pode ficar inalterada às vezes.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Altere a legenda do botão.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Altere a imagem substituta.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Mova os controles para baixo em 100 pontos.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Remova os controles.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **Perguntas Frequentes**

**Aspose.Slides preserva os controles ActiveX ao ler e re‑salvar se eles não puderem ser executados no runtime Python?**

Sim. Aspose.Slides trata-os como parte da apresentação e pode ler/modificar suas propriedades e molduras; executar os próprios controles não é necessário para preservá‑los.

**Como os controles ActiveX diferem dos objetos OLE em uma apresentação?**

Os controles ActiveX são controles interativos gerenciados (botões, caixas de texto, player de mídia), enquanto [OLE](/slides/pt/python-java/manage-ole/) refere‑se a objetos de aplicativo incorporados (por exemplo, uma planilha Excel). Eles são armazenados e tratados de forma diferente e possuem modelos de propriedades distintos.

**Eventos ActiveX e macros VBA funcionam se o arquivo foi modificado pelo Aspose.Slides?**

Aspose.Slides preserva a marcação e os metadados existentes; entretanto, eventos e macros são executados apenas dentro do PowerPoint no Windows quando a segurança o permite. A biblioteca não executa VBA.