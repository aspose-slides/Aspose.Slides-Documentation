---
title: Criar Miniaturas de Formas de Apresentação em C++
linktitle: Miniaturas de Formas
type: docs
weight: 70
url: /pt/cpp/shape-thumbnails/
keywords:
- miniatura de forma
- imagem de forma
- renderizar forma
- renderização de forma
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Gere miniaturas de forma de alta qualidade a partir de slides do PowerPoint com Aspose.Slides para C++ – crie e exporte miniaturas de apresentações facilmente."
---
## **Introdução**

Aspose.Slides é usado para criar arquivos de apresentação onde cada página é um slide. Esses slides podem ser visualizados abrindo os arquivos de apresentação usando o Microsoft PowerPoint. Mas às vezes, os desenvolvedores podem precisar visualizar as imagens das formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides ajuda a gerar imagens em miniatura das formas do slide. Como usar esse recurso é descrito neste artigo.  
Este artigo explica como gerar miniaturas de slides de diferentes maneiras:

- Gerar uma miniatura de forma dentro de um slide.
- Gerar uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.
- Gerar uma miniatura de forma nos limites da aparência de uma forma.

## **Gerar uma Miniatura de Forma a partir de um Slide**
Para gerar uma miniatura de forma a partir de qualquer slide usando Aspose.Slides for C++:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de qualquer slide usando seu ID ou índice.
3. Recupere a imagem em miniatura da forma do slide referenciado na escala padrão.
4. Salve a imagem em miniatura no formato de imagem desejado.

O exemplo abaixo gera uma miniatura de forma.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Gerar uma Miniatura com Fator de Escala Definido pelo Usuário**
Para gerar a miniatura da forma de qualquer forma de slide usando Aspose.Slides for C++:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de qualquer slide usando seu ID ou índice.
3. Recupere a imagem em miniatura do slide referenciado com os limites da forma.
4. Salve a imagem em miniatura no formato de imagem desejado.

O exemplo abaixo gera uma miniatura com fator de escala definido pelo usuário.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Escala nos eixos X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Criar uma Miniatura de Aparência de Forma Baseada em Limites**
Este método para criar miniaturas de formas permite que os desenvolvedores gerem uma miniatura dentro dos limites da aparência da forma. Ele leva em consideração todos os efeitos da forma. A miniatura de forma gerada é limitada pelos limites do slide. Para gerar uma miniatura de qualquer forma de slide dentro dos limites de sua aparência, use o código de exemplo a seguir:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Obtenha a referência de qualquer slide usando seu ID ou índice.
3. Recupere a imagem em miniatura do slide referenciado com os limites da forma como aparência.
4. Salve a imagem em miniatura no formato de imagem desejado.

O exemplo abaixo cria uma miniatura com fator de escala definido pelo usuário.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Escala nos eixos X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Perguntas Frequentes**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de forma?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imageformat/), e outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/writeassvg/) salvando o conteúdo da forma como SVG.

**Qual é a diferença entre os limites Shape e Appearance ao renderizar uma miniatura?**

`Shape` usa a geometria da forma; `Appearance` considera os [efeitos visuais](/slides/pt/cpp/shape-effect/) (sombras, brilhos, etc.).

**O que acontece se uma forma for marcada como oculta? Ela ainda será renderizada como miniatura?**

Uma forma oculta continua sendo parte do modelo e pode ser renderizada; a bandeira oculta afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Formas de grupo, gráficos, SmartArt e outros objetos complexos são suportados?**

Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chart/) e [SmartArt](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartart/)) pode ser salvo como miniatura ou como SVG.

**As fontes instaladas no sistema afetam a qualidade das miniaturas de formas de texto?**

Sim. Você deve [fornecer as fontes necessárias](/slides/pt/cpp/custom-font/) (ou [configurar substituições de fontes](/slides/pt/cpp/font-substitution/)) para evitar substituições indesejadas e refluência de texto.