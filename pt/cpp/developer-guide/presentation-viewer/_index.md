---
title: Criar um Visualizador de Apresentação em C++
linktitle: Visualizador de Apresentação
type: docs
weight: 50
url: /pt/cpp/presentation-viewer/
keywords:
- visualizar apresentação
- visualizador de apresentação
- criar visualizador de apresentação
- visualizar PPT
- visualizar PPTX
- visualizar ODP
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Crie um visualizador de apresentação personalizado em C++ usando Aspose.Slides. Exiba facilmente arquivos PowerPoint e OpenDocument sem o Microsoft PowerPoint."
---
## **Introdução**

Aspose.Slides for C++ é usado para criar arquivos de apresentação com slides. Esses slides podem ser visualizados ao abrir apresentações no Microsoft PowerPoint, por exemplo. No entanto, às vezes os desenvolvedores podem precisar ver os slides como imagens em seu visualizador de imagens preferido ou criar seu próprio visualizador de apresentações. Nesses casos, o Aspose.Slides permite exportar um slide individual como imagem. Este artigo descreve como fazer isso.

## **Gerar uma Imagem SVG a partir de um Slide**

Para gerar uma imagem SVG a partir de um slide de apresentação com Aspose.Slides, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
1. Obtenha a referência do slide pelo seu índice.
1. Abra um fluxo de arquivo.
1. Salve o slide como uma imagem SVG no fluxo de arquivo.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Gerar um SVG com um ID de Forma Personalizado**

Aspose.Slides pode ser usado para gerar um [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de um slide com um ID de forma personalizado. Para isso, use o método `set_Id` da [ISvgShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isvgshape/). `CustomSvgShapeFormattingController` pode ser usado para definir o ID da forma.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Criar uma Imagem Miniatura de Slide**

Aspose.Slides ajuda a gerar imagens em miniatura de slides. Para gerar uma miniatura de um slide usando Aspose.Slides, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
1. Obtenha a referência do slide pelo seu índice.
1. Obtenha a imagem miniatura do slide referenciado em uma escala definida.
1. Salve a imagem miniatura em qualquer formato de imagem desejado.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Criar uma Miniatura de Slide com Dimensões Definidas pelo Usuário**

Para criar uma imagem miniatura de slide com dimensões definidas pelo usuário, siga as etapas abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
1. Obtenha a referência do slide pelo seu índice.
1. Obtenha a imagem miniatura do slide referenciado com as dimensões definidas.
1. Salve a imagem miniatura em qualquer formato de imagem desejado.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Criar uma Miniatura de Slide com Notas do Apresentador**

Para gerar a miniatura de um slide com notas do apresentador usando Aspose.Slides, siga as etapas abaixo:

1. Crie uma instância da classe [RenderingOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/renderingoptions/) .
1. Use o método `RenderingOptions.set_SlidesLayoutOptions` para definir a posição das notas do apresentador.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
1. Obtenha a referência do slide pelo seu índice.
1. Obtenha a imagem miniatura do slide referenciado com as opções de renderização.
1. Salve a imagem miniatura em qualquer formato de imagem desejado.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Exemplo ao Vivo**

Você pode experimentar o aplicativo gratuito [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pt/viewer/) para ver o que pode implementar com a API do Aspose.Slides:

![Visualizador Online do PowerPoint](online-PowerPoint-viewer.png)

## **Perguntas Frequentes**

**Posso incorporar um visualizador de apresentações em uma aplicação web?**

Sim. Você pode usar o Aspose.Slides no lado do servidor para renderizar slides como imagens ou HTML e exibí‑los no navegador. Recursos de navegação e zoom podem ser implementados com JavaScript para uma experiência interativa.

**Qual é a melhor forma de exibir slides dentro de um visualizador personalizado?**

A abordagem recomendada é renderizar cada slide como uma imagem (por exemplo, PNG ou SVG) ou convertê‑lo para HTML usando Aspose.Slides, e então exibir o resultado dentro de um picture box (para desktop) ou de um contêiner HTML (para web).

**Como lidar com apresentações grandes com muitos slides?**

Para decks grandes, considere carregamento preguiçoso (lazy‑loading) ou renderização sob demanda dos slides. Isso significa gerar o conteúdo de um slide somente quando o usuário navega até ele, reduzindo o consumo de memória e o tempo de carregamento.