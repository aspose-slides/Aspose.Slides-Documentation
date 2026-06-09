---
title: Converter PPT e PPTX para JPG em C++
linktitle: PowerPoint para JPG
type: docs
weight: 60
url: /pt/cpp/convert-powerpoint-to-jpg/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para JPG
- apresentação para JPG
- slide para JPG
- PPT para JPG
- PPTX para JPG
- salvar PowerPoint como JPG
- salvar apresentação como JPG
- salvar slide como JPG
- salvar PPT como JPG
- salvar PPTX como JPG
- exportar PPT para JPG
- exportar PPTX para JPG
- C++
- Aspose.Slides
description: "Converter slides de PowerPoint (PPT, PPTX) em imagens JPG de alta qualidade em C++ com Aspose.Slides usando exemplos de código rápidos e confiáveis."
---
## **Introdução**

Converter apresentações PowerPoint e OpenDocument para imagens JPG ajuda a compartilhar slides, otimizar o desempenho e incorporar conteúdo em sites ou aplicativos. Aspose.Slides for C++ permite transformar arquivos PPTX, PPT e ODP em imagens JPEG de alta qualidade. Este guia explica diferentes métodos de conversão.

Com esses recursos, é fácil implementar seu próprio visualizador de apresentações e criar uma miniatura para cada slide. Isso pode ser útil se você quiser proteger os slides da apresentação contra cópia ou demonstrar a apresentação em modo somente leitura. Aspose.Slides permite converter toda a apresentação ou um slide específico em formatos de imagem.

## **Converter Slides de Apresentação para Imagens JPG**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Recupere o objeto de slide do tipo [ISlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/) a partir da coleção de slides da apresentação.
1. Crie uma imagem do slide usando o método [ISlide.GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/getimage/).
1. Chame o método [IImage.Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/save/) no objeto de imagem. Passe o nome do arquivo de saída e o formato da imagem como argumentos.

{{% alert color="primary" %}} 

**Nota:** A conversão de PPT, PPTX ou ODP para JPG difere da conversão para outros formatos na API Aspose.Slides for C++. Para outros formatos, normalmente você usa o método [IPresentation.Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/save/). No entanto, para conversão para JPG, é necessário usar o método [IImage.Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Crie uma imagem do slide na escala especificada.
    auto image = slide->GetImage(scaleX, scaleY);

    // Salve a imagem no disco no formato JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Converter Slides para JPG com Dimensões Personalizadas**

Para alterar as dimensões das imagens JPG resultantes, você pode definir o tamanho da imagem passando-o para o método [ISlide.GetImage(Size)](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Isso permite gerar imagens com valores específicos de largura e altura, garantindo que a saída atenda aos seus requisitos de resolução e proporção. Essa flexibilidade é particularmente útil ao gerar imagens para aplicativos web, relatórios ou documentação, onde são necessárias dimensões de imagem precisas.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Crie uma imagem do slide no tamanho especificado.
    auto image = slide->GetImage(imageSize);

    // Salve a imagem no disco no formato JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Renderizar Comentários ao Salvar Slides como Imagens**

Aspose.Slides for C++ oferece um recurso que permite renderizar comentários nos slides de uma apresentação ao convertê-los em imagens JPG. Essa funcionalidade é particularmente útil para preservar anotações, feedback ou discussões adicionadas por colaboradores em apresentações PowerPoint. Ao habilitar esta opção, você garante que os comentários sejam visíveis nas imagens geradas, facilitando a revisão e o compartilhamento de feedback sem precisar abrir o arquivo original da apresentação.

Suponha que tenhamos um arquivo de apresentação, "sample.pptx", com um slide que contém comentários:

![O slide com comentários](slide_with_comments.png)

O código C++ a seguir converte o slide em uma imagem JPG preservando os comentários:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Defina opções para os comentários do slide.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Converta o primeiro slide em uma imagem.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

O resultado:

![A imagem JPG com comentários](image_with_comments.png)

## **Veja Também**

- [Converter PowerPoint para GIF](/slides/pt/cpp/convert-powerpoint-to-animated-gif/)
- [Converter PowerPoint para PNG](/slides/pt/cpp/convert-powerpoint-to-png/)
- [Converter PowerPoint para TIFF](/slides/pt/cpp/convert-powerpoint-to-tiff/)
- [Converter PowerPoint para SVG](/slides/pt/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Para ver como o Aspose.Slides converte PowerPoint em imagens JPG, experimente estes conversores online gratuitos: PowerPoint [PPTX para JPG](https://products.aspose.app/slides/pt/conversion/pptx-to-jpg) e [PPT para JPG](https://products.aspose.app/slides/pt/conversion/ppt-to-jpg). 

{{% /alert %}}

![Conversor Online Gratuito de PPTX para JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

A Aspose fornece um [aplicativo web GRATUITO de Colagem](https://products.aspose.app/slides/pt/collage). Usando este serviço online, você pode mesclar imagens [JPG para JPG](https://products.aspose.app/slides/pt/collage/jpg) ou PNG para PNG, criar [grades de fotos](https://products.aspose.app/slides/pt/collage/photo-grid) e assim por diante. 

Usando os mesmos princípios descritos neste artigo, você pode converter imagens de um formato para outro. Para mais informações, veja estas páginas: converter [imagem para JPG](https://products.aspose.com/slides/pt/cpp/conversion/image-to-jpg/); converter [JPG para imagem](https://products.aspose.com/slides/pt/cpp/conversion/jpg-to-image/); converter [JPG para PNG](https://products.aspose.com/slides/pt/cpp/conversion/jpg-to-png/), converter [PNG para JPG](https://products.aspose.com/slides/pt/cpp/conversion/png-to-jpg/); converter [PNG para SVG](https://products.aspose.com/slides/pt/cpp/conversion/png-to-svg/), converter [SVG para PNG](https://products.aspose.com/slides/pt/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Este método suporta conversão em lote?**

Sim, o Aspose.Slides permite a conversão em lote de vários slides para JPG em uma única operação.

**A conversão suporta SmartArt, gráficos e outros objetos complexos?**

Sim, o Aspose.Slides renderiza todo o conteúdo, incluindo SmartArt, gráficos, tabelas, formas e muito mais. No entanto, a precisão da renderização pode variar um pouco em comparação com o PowerPoint, especialmente ao usar fontes personalizadas ou ausentes.

**Existem limitações no número de slides que podem ser processados?**

O próprio Aspose.Slides não impõe limites rígidos ao número de slides que você pode processar. No entanto, você pode encontrar erros de falta de memória ao trabalhar com apresentações grandes ou imagens de alta resolução.