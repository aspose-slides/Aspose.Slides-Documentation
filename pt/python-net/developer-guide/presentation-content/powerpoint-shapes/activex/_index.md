---
title: Gerenciar Controles ActiveX em Apresentações com Python
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
description: "Aprenda como o Aspose.Slides for Python via .NET utiliza ActiveX para automatizar e aprimorar apresentações do PowerPoint, oferecendo aos desenvolvedores controle avançado sobre os slides."
---
## **Introdução**

Os controles ActiveX são usados em apresentações. Aspose.Slides for Python via .NET permite gerenciar controles ActiveX, mas seu gerenciamento é um pouco mais complicado e diferente dos shapes normais de apresentação. A partir do Aspose.Slides for Python via .NET 6.9.0, o componente suporta o gerenciamento de controles ActiveX. No momento, você pode acessar o controle ActiveX já adicionado em sua apresentação e modificá-lo ou excluí-lo usando suas várias propriedades. Lembre-se de que os controles ActiveX não são shapes e não fazem parte da IShapeCollection da apresentação, mas sim da IControlCollection separada. Este artigo mostra como trabalhar com eles.
## **Modificar Controles ActiveX**
Para gerenciar um controle ActiveX simples como uma caixa de texto e um botão de comando em um slide:

1. Crie uma instância da classe Presentation e carregue a apresentação que contém controles ActiveX.
1. Obtenha uma referência ao slide pelo seu índice.
1. Acesse os controles ActiveX no slide por meio da IControlCollection.
1. Acesse o controle ActiveX TextBox1 usando o objeto ControlEx.
1. Altere as diferentes propriedades do controle ActiveX TextBox1, incluindo texto, fonte, altura da fonte e posição da moldura.
1. Acesse o segundo controle chamado CommandButton1.
1. Altere a legenda do botão, a fonte e a posição.
1. Desloque a posição das molduras dos controles ActiveX.
1. Grave a apresentação modificada em um arquivo PPTX.

O trecho de código abaixo atualiza os controles ActiveX nos slides da apresentação conforme mostrado abaixo.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Acessando a apresentação com controles ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Acessando o primeiro slide na apresentação
    slide = presentation.slides[0]

    # alterando o texto da TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # alterando a imagem substituta. O PowerPoint substituirá esta imagem durante a ativação do ActiveX, então às vezes é aceitável deixar a imagem sem alterações.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # alterando a legenda do Botão
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # alterando substituta
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Movendo quadros ActiveX 100 pontos para baixo
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Salvar a apresentação com Controles ActiveX Editados
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Agora removendo controles
    slide.controls.clear()

    # Salvando a apresentação com controles ActiveX limpos
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Adicionar Controle ActiveX Media Player**
Para adicionar o controle ActiveX Media Player, siga os passos abaixo:

1. Crie uma instância da classe Presentation e carregue a apresentação de exemplo que contém controles ActiveX Media Player.
1. Crie uma instância da classe Presentation de destino e gere uma instância de apresentação vazia.
1. Clone o slide com o controle ActiveX Media Player da apresentação modelo para a apresentação de destino.
1. Acesse o slide clonado na apresentação de destino.
1. Acesse os controles ActiveX no slide por meio da IControlCollection.
1. Acesse o controle ActiveX Media Player e defina o caminho do vídeo usando suas propriedades.
1. Salve a apresentação em um arquivo PPTX.

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Criar instância de apresentação vazia
    with slides.Presentation() as newPresentation:

        # Remover slide padrão
        newPresentation.slides.remove_at(0)

        # Clonar slide com o controle ActiveX Media Player
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Acessar o controle ActiveX Media Player e definir o caminho do vídeo
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Salvar a apresentação
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**O Aspose.Slides preserva os controles ActiveX ao ler e regravar se eles não puderem ser executados no runtime do Python?**

Sim. O Aspose.Slides trata‑os como parte da apresentação e pode ler/modificar suas propriedades e molduras; a execução dos próprios controles não é necessária para preservá‑los.

**Como os controles ActiveX diferem dos objetos OLE em uma apresentação?**

Os controles ActiveX são controles interativos gerenciados (botões, caixas de texto, media player), enquanto [OLE](/slides/pt/python-net/manage-ole/) se refere a objetos de aplicação incorporados (por exemplo, uma planilha do Excel). Eles são armazenados e manipulados de forma diferente e possuem modelos de propriedades distintos.

**Os eventos ActiveX e macros VBA funcionam se o arquivo foi modificado pelo Aspose.Slides?**

O Aspose.Slides preserva a marcação e os metadados existentes; entretanto, eventos e macros são executados apenas dentro do PowerPoint no Windows quando a segurança permite. A biblioteca não executa VBA.