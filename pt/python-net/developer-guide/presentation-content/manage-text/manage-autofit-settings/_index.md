---
title: Aprimore Suas Apresentações com AutoFit em Python
linktitle: Configurações de Autofit
type: docs
weight: 30
url: /pt/python-net/manage-autofit-settings/
keywords:
- caixa de texto
- ajuste automático
- não ajustar automaticamente
- ajustar texto
- reduzir texto
- quebrar texto
- redimensionar forma
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a gerenciar as configurações de AutoFit no Aspose.Slides para Python via .NET para otimizar a exibição de texto em suas apresentações PowerPoint e OpenDocument e melhorar a legibilidade do conteúdo."
---
## **Introdução**

Por padrão, quando você adiciona uma caixa de texto, o Microsoft PowerPoint usa a configuração **Redimensionar forma para ajustar texto** para a caixa de texto—ele redimensiona automaticamente a caixa de texto para garantir que seu texto sempre caiba nela. 

![caixa-de-texto-no-powerpoint](textbox-in-powerpoint.png)

* Quando o texto na caixa de texto fica mais longo ou maior, o PowerPoint aumenta automaticamente a caixa de texto—incrementa sua altura—para permitir que contenha mais texto. 
* Quando o texto na caixa de texto fica mais curto ou menor, o PowerPoint reduz automaticamente a caixa de texto—diminui sua altura—para eliminar espaço redundante. 

No PowerPoint, estes são os 4 parâmetros ou opções importantes que controlam o comportamento de ajuste automático para uma caixa de texto: 

* **Não ajustar automaticamente**
* **Reduzir texto em excesso**
* **Redimensionar forma para ajustar texto**
* **Quebrar texto na forma**.

![opções-de-ajuste-automático-no-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET fornece opções semelhantes—algumas propriedades da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/)—que permitem controlar o comportamento de ajuste automático para caixas de texto em apresentações. 

## **Redimensionar Formas para Ajustar Texto**

Se você deseja que o texto em uma caixa sempre caiba nessa caixa após alterações no texto, deve usar a opção **Redimensionar forma para ajustar texto**. Para especificar essa configuração, defina a propriedade [autofit_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) como `SHAPE`.

![configuracao-sempre-ajuste-no-powerpoint](alwaysfit-setting-powerpoint.png)

Este código Python mostra como especificar que um texto deve sempre caber em sua caixa em uma apresentação PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Se o texto ficar mais longo ou maior, a caixa de texto será redimensionada automaticamente (aumentará em altura) para garantir que todo o texto caiba. Se o texto ficar mais curto, ocorre o inverso. 

## **Não Ajustar Automaticamente**

Se você deseja que uma caixa de texto ou forma mantenha suas dimensões independentemente das alterações feitas no texto que contém, deve usar a opção **Não ajustar automaticamente**. Para especificar essa configuração, defina a propriedade [autofit_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) como `NONE`. 

![configuracao-nao-ajuste-no-powerpoint](donotautofit-setting-powerpoint.png)

Este código Python mostra como especificar que uma caixa de texto deve sempre manter suas dimensões em uma apresentação PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Quando o texto se torna longo demais para sua caixa, ele transborda. 

## **Reduzir Texto em Excesso**

Se um texto ficar muito longo para sua caixa, através da opção **Reduzir texto em excesso**, você pode especificar que o tamanho e o espaçamento do texto sejam reduzidos para que caiba na caixa. Para especificar essa configuração, defina a propriedade [autofit_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) como `NORMAL`.

![configuracao-reduzir-texto-no-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código Python mostra como especificar que um texto deve ser reduzido em excesso em uma apresentação PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Quando a opção **Reduzir texto em excesso** é usada, a configuração é aplicada somente quando o texto fica muito longo para sua caixa. 
{{% /alert %}}

## **Quebrar Texto**

Se você deseja que o texto em uma forma seja quebrado dentro dessa forma quando o texto ultrapassa a borda da forma (apenas a largura), deve usar o parâmetro **Quebrar texto na forma**. Para especificar essa configuração, defina a propriedade [wrap_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframeformat/) como `NullableBool.TRUE`. 

Este código Python mostra como usar a configuração Quebrar Texto em uma apresentação PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
Se você definir a propriedade `wrap_text` como `NullableBool.FALSE` para uma forma, quando o texto dentro da forma ficar mais longo que a largura da forma, o texto se estenderá além das bordas da forma em uma única linha. 
{{% /alert %}}

## **Perguntas Frequentes**

**As margens internas do quadro de texto afetam o AutoFit?**

Sim. O preenchimento (margens internas) reduz a área utilizável para texto, portanto o AutoFit será acionado mais cedo—encolhendo a fonte ou redimensionando a forma antes. Verifique e ajuste as margens antes de sintonizar o AutoFit.

**Como o AutoFit interage com quebras de linha manuais e suaves?**

Quebras forçadas permanecem no lugar, e o AutoFit adapta o tamanho da fonte e o espaçamento ao redor delas. Remover quebras desnecessárias costuma reduzir a agressividade com que o AutoFit precisa encolher o texto.

**Alterar a fonte do tema ou acionar substituição de fonte afeta os resultados do AutoFit?**

Sim. Substituir por uma fonte com métricas de glifo diferentes altera a largura/altura do texto, o que pode mudar o tamanho final da fonte e a quebra de linhas. Após qualquer mudança ou substituição de fonte, revise os slides.