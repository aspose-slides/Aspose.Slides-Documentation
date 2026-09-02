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
- limites visuais
- limites da forma
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Gere miniaturas de forma de alta qualidade a partir de slides do PowerPoint com Aspose.Slides para C++ – crie e exporte miniaturas de apresentação facilmente."
---
## **Introdução**

Aspose.Slides é usado para criar arquivos de apresentação onde cada página é um slide. Esses slides podem ser visualizados abrindo os arquivos de apresentação com o Microsoft PowerPoint. Mas, às vezes, os desenvolvedores podem precisar ver as imagens das formas separadamente em um visualizador de imagens. Nesses casos, o Aspose.Slides ajuda a gerar miniaturas das formas dos slides. Como usar esse recurso é descrito neste artigo.  
Este artigo explica como gerar miniaturas de slide de diferentes maneiras:

- Gerar uma miniatura de forma dentro de um slide.  
- Gerar uma miniatura de forma para uma forma de slide com dimensões definidas pelo usuário.  
- Gerar uma miniatura de forma nos limites da aparência de uma forma.

## **Gerar uma Miniatura de Forma a partir de um Slide**
Para gerar uma miniatura de forma a partir de qualquer slide usando Aspose.Slides para C++:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) classe.  
1. Obtenha a referência de qualquer slide usando seu ID ou índice.  
1. Recupere a imagem da miniatura da forma do slide referenciado na escala padrão.  
1. Salve a imagem da miniatura no formato de imagem desejado.

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
Para gerar a miniatura da forma de qualquer forma de slide usando Aspose.Slides para C++:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) classe.  
1. Obtenha a referência de qualquer slide usando seu ID ou índice.  
1. Recupere a imagem da miniatura do slide referenciado com os limites da forma.  
1. Salve a imagem da miniatura no formato de imagem desejado.

O exemplo abaixo gera uma miniatura com fator de escala definido pelo usuário.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Escalonamento nos eixos X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Criar uma Miniatura de Aparência de Forma Baseada em Limites**
Este método de criação de miniaturas de formas permite que os desenvolvedores gerem uma miniatura dentro dos limites da aparência da forma. Ele leva em conta todos os efeitos da forma. A miniatura de forma gerada é limitada pelos limites do slide. Para gerar uma miniatura de qualquer forma de slide dentro dos limites de sua aparência, use o código de exemplo a seguir:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) classe.  
1. Obtenha a referência de qualquer slide usando seu ID ou índice.  
1. Recupere a imagem da miniatura do slide referenciado com os limites da forma como aparência.  
1. Salve a imagem da miniatura no formato de imagem desejado.

O exemplo abaixo cria uma miniatura com fator de escala definido pelo usuário.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Escalonamento nos eixos X e Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Obter os Limites Visuais Reais de uma Forma**

As propriedades de quadro de [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/)—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` e `IShape::get_Height()`—descrevem o retângulo armazenado no modelo da apresentação. O conteúdo que realmente é renderizado pode se estender além desse quadro ou ocupar um retângulo alinhado a eixos diferente. Rotação, contornos, pontas de setas, layout e transbordamento de texto, geometria gerada de SmartArt e outros efeitos de renderização podem mudar a área ocupada.

Use [Shape::GetVisualBounds](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getvisualbounds/) para calcular essa área ocupada sem criar uma imagem. O método devolve um [RectangleF](https://reference.aspose.com/slides/pt/cpp/system.drawing/rectanglef/) nas coordenadas do slide. O retângulo retornado não é recortado ao slide, portanto suas coordenadas podem ser negativas quando o conteúdo se estende além da origem do slide.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getvisualbounds/) ainda não está declarado na interface [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/). Portanto, mantenha a forma obtida da coleção de formas do slide como um valor de interface e faça o casting apenas ao chamar o método.

O exemplo a seguir obtém e compara os limites do quadro e os limites visuais:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

O mesmo [RectangleF](https://reference.aspose.com/slides/pt/cpp/system.drawing/rectanglef/) pode ser usado para alinhar formas próximas ao seu `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` ou `RectangleF::get_Bottom()`; reservar espaço suficiente em um layout gerado; ou detectar conteúdo fora de uma região permitida. Os limites visuais são especialmente úteis para SmartArt, caixas de texto, setas, imagens, formas giradas e formas agrupadas, onde o quadro armazenado pode não representar o resultado renderizado completo.

Use [Shape::GetVisualBounds](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getvisualbounds/) quando precisar de coordenadas para layout ou validação e não precisar de um bitmap. Use [IShape::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/getimage/) quando precisar renderizar a forma. Com [ShapeThumbnailBounds](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` dimensiona a imagem a partir dos limites da forma, incluindo as configurações de contorno, enquanto `ShapeThumbnailBounds::Appearance` dimensiona-a a partir da aparência da forma e restringe o resultado aos limites do slide. Em contraste, [Shape::GetVisualBounds](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getvisualbounds/) retorna apenas o retângulo calculado e não o recorta ao slide.

## **Perguntas Frequentes**

**Quais formatos de imagem podem ser usados ao salvar miniaturas de forma?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imageformat/), entre outros. As formas também podem ser [exportadas como SVG vetorial](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/writeassvg/) salvando o conteúdo da forma como SVG.

**Qual a diferença entre limites de Forma e de Aparência ao renderizar uma miniatura?**  
`Shape` usa a geometria da forma; `Appearance` leva em conta [efeitos visuais](/slides/pt/cpp/shape-effect/) (sombras, brilhos etc.).

**O que acontece se uma forma estiver marcada como oculta? Ela ainda será renderizada como miniatura?**  
Uma forma oculta continua parte do modelo e pode ser renderizada; a bandeira de ocultação afeta a exibição da apresentação, mas não impede a geração da imagem da forma.

**Formas agrupadas, gráficos, SmartArt e outros objetos complexos são suportados?**  
Sim. Qualquer objeto representado como [Shape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/) (incluindo [GroupShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chart/) e [SmartArt](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartart/)) pode ser salvo como miniatura ou como SVG.

**As fontes instaladas no sistema afetam a qualidade das miniaturas para formas de texto?**  
Sim. Você deve [fornecer as fontes necessárias](/slides/pt/cpp/custom-font/) (ou [configurar substituições de fontes](/slides/pt/cpp/font-substitution/)) para evitar substituições indesejadas e reflow de texto.