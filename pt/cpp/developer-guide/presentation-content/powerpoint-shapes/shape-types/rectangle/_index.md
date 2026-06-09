---
title: Adicionar Retângulos às Apresentações em C++
linktitle: Retângulo
type: docs
weight: 80
url: /pt/cpp/rectangle/
keywords:
- adicionar retângulo
- criar retângulo
- forma de retângulo
- retângulo simples
- retângulo formatado
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Impulsione suas apresentações PowerPoint adicionando retângulos com Aspose.Slides para C++ — projetando e modificando formas programaticamente com facilidade."
---
## **Visão geral**

Este artigo mostra como adicionar formas de retângulo aos slides do PowerPoint usando Aspose.Slides. Ele cobre a criação de um retângulo simples, a criação de um retângulo formatado e a gravação da apresentação atualizada como um arquivo PPTX.

## **Criar um Retângulo Simples**
Como nos tópicos anteriores, este também trata da adição de uma forma e, desta vez, a forma que vamos discutir é o Retângulo. Neste tópico, descrevemos como os desenvolvedores podem adicionar retângulos simples ou formatados aos seus slides usando Aspose.Slides para C++. Para adicionar um retângulo simples a um slide selecionado da apresentação, siga as etapas abaixo:

1. Crie uma instância da [Presentation class](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de um slide usando seu Índice.
3. Adicione um IAutoShape do tipo Rectangle usando o método AddAutoShape exposto pelo objeto IShapes.
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um retângulo simples ao primeiro slide da apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Criar um Retângulo Formatado**
Para adicionar um retângulo formatado a um slide, siga as etapas abaixo:

1. Crie uma instância da [Presentation class](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de um slide usando seu Índice.
3. Adicione um IAutoShape do tipo Rectangle usando o método AddAutoShape exposto pelo objeto IShapes.
4. Defina o Tipo de Preenchimento do Retângulo como Sólido.
5. Defina a Cor do Retângulo usando a propriedade SolidFillColor.Color exposta pelo objeto FillFormat associado ao objeto IShape.
6. Defina a Cor das linhas do Retângulo.
7. Defina a Largura das linhas do Retângulo.
8. Grave a apresentação modificada como um arquivo PPTX.
   As etapas acima são implementadas no exemplo abaixo.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **Perguntas frequentes**

**Como adiciono um retângulo com cantos arredondados?**

Use o [tipo de forma de canto arredondado](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapetype/) e ajuste o raio do canto nas propriedades da forma; o arredondamento também pode ser aplicado por canto via ajustes de geometria.

**Como preencho um retângulo com uma imagem (textura)?**

Selecione o [tipo de preenchimento de imagem](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/), forneça a origem da imagem e configure os modos de [esticamento/azulejamento](https://reference.aspose.com/slides/pt/cpp/aspose.slides/picturefillmode/).

**Um retângulo pode ter sombra e brilho?**

Sim. [Sombra externa/interna, brilho e bordas suaves](/slides/pt/cpp/shape-effect/) estão disponíveis com parâmetros ajustáveis.

**Posso transformar um retângulo em um botão com hyperlink?**

Sim. [Atribua um hyperlink](/slides/pt/cpp/manage-hyperlinks/) ao clique da forma (ir para um slide, arquivo, endereço da web ou e‑mail).

**Como posso proteger um retângulo contra movimentação e alterações?**

[Use bloqueios de forma](/slides/pt/cpp/applying-protection-to-presentation/): você pode impedir movimentação, redimensionamento, seleção ou edição de texto para preservar o layout.

**Posso converter um retângulo em imagem raster ou SVG?**

Sim. Você pode [renderizar a forma](http://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/) para uma imagem com tamanho/escala especificados ou [exportá‑la como SVG](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/writeassvg/) para uso vetorial.

**Como obtenho rapidamente as propriedades reais (efetivas) de um retângulo considerando tema e herança?**

[Use as propriedades efetivas da forma](/slides/pt/cpp/shape-effective-properties/): a API retorna valores calculados que levam em conta estilos de tema, layout e configurações locais, simplificando a análise de formatação.