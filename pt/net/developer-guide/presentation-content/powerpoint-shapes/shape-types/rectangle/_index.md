---
title: Adicionar Retângulos a Apresentações em .NET
linktitle: Retângulo
type: docs
weight: 80
url: /pt/net/rectangle/
keywords:
- adicionar retângulo
- criar retângulo
- forma retangular
- retângulo simples
- retângulo formatado
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Melhore suas apresentações PowerPoint adicionando retângulos com Aspose.Slides para .NET—projete e modifique formas programaticamente com facilidade."
---
## **Visão geral**

Este artigo mostra como adicionar formas retangulares a slides do PowerPoint usando Aspose.Slides. Ele aborda a criação de um retângulo simples, a criação de um retângulo formatado e a gravação da apresentação atualizada como um arquivo PPTX.

Você também verá como aplicar formatação básica de retângulo, como cor de preenchimento sólido, cor da linha e largura da linha. Além disso, o FAQ do artigo aponta para tarefas relacionadas a retângulos, incluindo cantos arredondados, preenchimentos com imagem, efeitos visuais, hyperlinks, bloqueios de forma, opções de exportação e propriedades efetivas.

## **Criar um retângulo simples**
Como em tópicos anteriores, este também trata da adição de uma forma e, desta vez, a forma que discutiremos é o Retângulo. Neste tópico, descrevemos como os desenvolvedores podem adicionar retângulos simples ou formatados aos seus slides usando Aspose.Slides for .NET. Para adicionar um retângulo simples a um slide selecionado da apresentação, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu Índice.
1. Adicione um IAutoShape do tipo Rectangle usando o método AddAutoShape exposto pelo objeto IShapes.
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um retângulo simples ao primeiro slide da apresentação.

```c#
// Instanciar a classe Presentation que representa o PPTX
using (Presentation pres = new Presentation())
{

    // Obter o primeiro slide
    ISlide sld = pres.Slides[0];

    // Adicionar autoshape do tipo retângulo
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Gravar o arquivo PPTX no disco
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Criar um retângulo formatado**
Para adicionar um retângulo formatado a um slide, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de um slide usando seu Índice.
1. Adicione um IAutoShape do tipo Rectangle usando o método AddAutoShape exposto pelo objeto IShapes.
1. Defina o Tipo de Preenchimento do Retângulo como Solid.
1. Defina a Cor do Retângulo usando a propriedade SolidFillColor.Color exposta pelo objeto FillFormat associado ao objeto IShape.
1. Defina a Cor das linhas do Retângulo.
1. Defina a Largura das linhas do Retângulo.
1. Grave a apresentação modificada como arquivo PPTX.
   As etapas acima são implementadas no exemplo abaixo.

```c#
// Instanciar a classe Presentation que representa o PPTX
using (Presentation pres = new Presentation())
{

    // Obter o primeiro slide
    ISlide sld = pres.Slides[0];

    // Adicionar autoshape do tipo retângulo
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Aplicar alguma formatação ao retângulo
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Aplicar alguma formatação à linha do retângulo
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Gravar o arquivo PPTX no disco
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Como adiciono um retângulo com cantos arredondados?**

Use o [tipo de forma] de canto arredondado(https://reference.aspose.com/slides/pt/net/aspose.slides/shapetype/) e ajuste o raio do canto nas propriedades da forma; o arredondamento também pode ser aplicado por canto via ajustes de geometria.

**Como preencho um retângulo com uma imagem (textura)?**

Selecione o [tipo de preenchimento] de imagem(https://reference.aspose.com/slides/pt/net/aspose.slides/filltype/), forneça a origem da imagem e configure os [modos de estiramento/azulejo](https://reference.aspose.com/slides/pt/net/aspose.slides/picturefillmode/).

**Um retângulo pode ter sombra e brilho?**

Sim. [Sombra externa/interna, brilho e bordas suaves](/slides/pt/net/shape-effect/) estão disponíveis com parâmetros ajustáveis.

**Posso transformar um retângulo em um botão com hyperlink?**

Sim. [Atribua um hyperlink](/slides/pt/net/manage-hyperlinks/) ao clique da forma (ir para um slide, arquivo, endereço web ou e‑mail).

**Como posso proteger um retângulo contra movimentação e alterações?**

[Use bloqueios de forma](/slides/pt/net/applying-protection-to-presentation/): você pode impedir movimentação, redimensionamento, seleção ou edição de texto para preservar o layout.

**Posso converter um retângulo em imagem raster ou SVG?**

Sim. Você pode [renderizar a forma](http://reference.aspose.com/slides/pt/net/aspose.slides/shape/getimage/) para uma imagem com tamanho/escala especificados ou [exportá‑la como SVG](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/writeassvg/) para uso vetorial.

**Como obtenho rapidamente as propriedades reais (efetivas) de um retângulo considerando tema e herança?**

[Use as propriedades efetivas da forma](/slides/pt/net/shape-effective-properties/): a API retorna valores calculados que consideram estilos de tema, layout e configurações locais, simplificando a análise de formatação.