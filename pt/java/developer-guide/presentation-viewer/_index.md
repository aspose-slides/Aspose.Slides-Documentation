---
title: Criar um Visualizador de Apresentação em Java
linktitle: Visualizador de Apresentação
type: docs
weight: 50
url: /pt/java/presentation-viewer/
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
- Java
- Aspose.Slides
description: "Crie um visualizador de apresentações personalizado em Java usando Aspose.Slides. Exiba facilmente arquivos PowerPoint e OpenDocument sem o Microsoft PowerPoint."
---
## **Introdução**

Aspose.Slides for Java é usado para criar arquivos de apresentação com slides. Esses slides podem ser visualizados ao abrir as apresentações no Microsoft PowerPoint, por exemplo. No entanto, às vezes os desenvolvedores podem precisar visualizar os slides como imagens em seu visualizador de imagens preferido ou criar seu próprio visualizador de apresentações. Nesses casos, o Aspose.Slides permite exportar um slide individual como imagem. Este artigo descreve como fazer isso.

## **Gerar uma imagem SVG a partir de um slide**

Para gerar uma imagem SVG a partir de um slide de apresentação com Aspose.Slides, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
2. Obtenha a referência do slide pelo seu índice.
3. Abra um fluxo de arquivo.
4. Salve o slide como uma imagem SVG no fluxo de arquivo.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Gerar um SVG com ID de forma personalizada**

O Aspose.Slides pode ser usado para gerar um [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de um slide com um ID de forma personalizado. Para isso, use o método `setId` de [ISvgShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` pode ser usado para definir o ID da forma.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Criar uma imagem miniatura de slide**

O Aspose.Slides ajuda a gerar imagens miniatura de slides. Para gerar uma miniatura de um slide usando Aspose.Slides, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
2. Obtenha a referência do slide pelo seu índice.
3. Obtenha a imagem miniatura do slide referenciado em uma escala definida.
4. Salve a imagem miniatura em qualquer formato de imagem desejado.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Criar uma miniatura de slide com dimensões definidas pelo usuário**

Para criar uma imagem miniatura de slide com dimensões definidas pelo usuário, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
2. Obtenha a referência do slide pelo seu índice.
3. Obtenha a imagem miniatura do slide referenciado com as dimensões definidas.
4. Salve a imagem miniatura em qualquer formato de imagem desejado.

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Criar uma miniatura de slide com notas do apresentador**

Para gerar a miniatura de um slide com notas do apresentador usando Aspose.Slides, siga os passos abaixo:

1. Crie uma instância da classe [RenderingOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/renderingoptions/).
2. Use o método `RenderingOptions.setSlidesLayoutOptions` para definir a posição das notas do apresentador.
3. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
4. Obtenha a referência do slide pelo seu índice.
5. Obtenha a imagem miniatura do slide referenciado com as opções de renderização.
6. Salve a imagem miniatura em qualquer formato de imagem desejado.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Exemplo ao vivo**

Você pode experimentar o aplicativo gratuito [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pt/viewer/) para ver o que pode implementar com a API do Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Posso incorporar um visualizador de apresentação em uma aplicação web?**

Sim. Você pode usar o Aspose.Slides no lado do servidor para renderizar slides como imagens ou HTML e exibí‑los no navegador. Recursos de navegação e zoom podem ser implementados com JavaScript para uma experiência interativa.

**Qual é a melhor maneira de exibir slides dentro de um visualizador personalizado?**

A abordagem recomendada é renderizar cada slide como uma imagem (por exemplo, PNG ou SVG) ou convertê‑lo para HTML usando Aspose.Slides, e então exibir o resultado dentro de um picture box (para desktop) ou de um contêiner HTML (para web).

**Como lidar com apresentações grandes com muitos slides?**

Para apresentações extensas, considere carregamento preguiçoso (lazy‑loading) ou renderização sob demanda dos slides. Isso significa gerar o conteúdo de um slide somente quando o usuário navega até ele, reduzindo o uso de memória e o tempo de carregamento.