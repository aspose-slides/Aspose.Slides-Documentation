---
title: Adicionar Retângulos a Apresentações em Python
linktitle: Retângulo
type: docs
weight: 80
url: /pt/python-net/rectangle/
keywords:
- adicionar retângulo
- criar retângulo
- forma de retângulo
- retângulo simples
- retângulo formatado
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Impulsione suas apresentações PowerPoint & OpenDocument adicionando retângulos com Aspose.Slides para Python via .NET—programe e modifique formas facilmente."
---
## **Visão geral**

Este artigo mostra como adicionar formas de retângulo aos slides do PowerPoint usando Aspose.Slides. Ele cobre a criação de um retângulo simples, a criação de um retângulo formatado e a gravação da apresentação atualizada como um arquivo PPTX.

Você também verá como aplicar formatação básica de retângulo, como cor de preenchimento sólido, cor da linha e espessura da linha. Além disso, a seção de Perguntas frequentes do artigo aponta para tarefas relacionadas a retângulos, incluindo cantos arredondados, preenchimentos com imagem, efeitos visuais, hyperlinks, bloqueios de forma, opções de exportação e propriedades efetivas.

## **Criar retângulo simples**

Como nos tópicos anteriores, este também trata da adição de uma forma e, desta vez, a forma que discutiremos é Retângulo. Neste tópico, descrevemos como os desenvolvedores podem adicionar retângulos simples ou formatados aos seus slides usando Aspose.Slides for Python via .NET. Para adicionar um retângulo simples ao slide selecionado da apresentação, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha a referência de um slide usando seu Índice.
3. Adicione um IAutoShape do tipo Rectangle usando o método AddAutoShape exposto pelo objeto IShapes.
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um retângulo simples ao primeiro slide da apresentação.

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa o PPTX
with slides.Presentation() as pres:
    # Obter o primeiro slide
    sld = pres.slides[0]

    # Adicionar forma automática do tipo retângulo
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Escrever o arquivo PPTX no disco
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Criar retângulo formatado**

Para adicionar um retângulo formatado a um slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha a referência de um slide usando seu Índice.
3. Adicione um IAutoShape do tipo Rectangle usando o método AddAutoShape exposto pelo objeto IShapes.
4. Defina o Tipo de Preenchimento do Retângulo como Sólido.
5. Defina a Cor do Retângulo usando a propriedade SolidFillColor.Color, exposta pelo objeto FillFormat associado ao objeto IShape.
6. Defina a Cor das linhas do Retângulo.
7. Defina a Largura das linhas do Retângulo.
8. Grave a apresentação modificada como um arquivo PPTX.

Os passos acima são implementados no exemplo abaixo.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation que representa o PPTX
with slides.Presentation() as pres:
    # Obter o primeiro slide
    sld = pres.slides[0]

    # Adicionar forma automática do tipo retângulo
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Aplicar alguma formatação à forma de retângulo
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Aplicar alguma formatação à linha do retângulo
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Escrever o arquivo PPTX no disco
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas frequentes**

**Como adicionar um retângulo com cantos arredondados?**

Use o [tipo de forma](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapetype/) com cantos arredondados e ajuste o raio dos cantos nas propriedades da forma; o arredondamento também pode ser aplicado por canto via ajustes de geometria.

**Como preencho um retângulo com uma imagem (textura)?**

Selecione o [tipo de preenchimento](https://reference.aspose.com/slides/pt/python-net/aspose.slides/filltype/) de imagem, forneça a fonte da imagem e configure os [modos de esticamento/azulejamento](https://reference.aspose.com/slides/pt/python-net/aspose.slides/picturefillmode/).

**Um retângulo pode ter sombra e brilho?**

Sim. [Sombra externa/interna, brilho e bordas suaves](/slides/pt/python-net/shape-effect/) estão disponíveis com parâmetros ajustáveis.

**Posso transformar um retângulo em um botão com hyperlink?**

Sim. [Atribua um hyperlink](/slides/pt/python-net/manage-hyperlinks/) ao clique da forma (para um slide, arquivo, endereço web ou e‑mail).

**Como posso proteger um retângulo contra movimentação e alterações?**

[Use bloqueios de forma](/slides/pt/python-net/applying-protection-to-presentation/): você pode impedir movimentação, redimensionamento, seleção ou edição de texto para preservar o layout.

**Posso converter um retângulo em imagem raster ou SVG?**

Sim. Você pode [renderizar a forma](http://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_image/) em uma imagem com tamanho/escala especificados ou [exportá‑la como SVG](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/write_as_svg/) para uso vetorial.

**Como obter rapidamente as propriedades reais (efetivas) de um retângulo considerando tema e herança?**

[Use as propriedades efetivas da forma](/slides/pt/python-net/shape-effective-properties/): a API devolve valores calculados que consideram estilos de tema, layout e configurações locais, facilitando a análise de formatação.