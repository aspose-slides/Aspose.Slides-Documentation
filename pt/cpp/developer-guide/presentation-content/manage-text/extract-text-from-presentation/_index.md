---
title: Extração Avançada de Texto de Apresentações em C++
linktitle: Extrair Texto
type: docs
weight: 90
url: /pt/cpp/extract-text-from-presentation/
keywords:
- extrair texto
- extrair texto de slide
- extrair texto de apresentação
- extrair texto de PowerPoint
- extrair texto de OpenDocument
- extrair texto de PPT
- extrair texto de PPTX
- extrair texto de ODP
- recuperar texto
- recuperar texto de slide
- recuperar texto de apresentação
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Extraia rapidamente texto de apresentações PowerPoint e OpenDocument usando Aspose.Slides para C++. Siga nosso guia simples, passo a passo, para economizar tempo."
---
## **Visão Geral**

Extrair texto de apresentações é uma tarefa comum, porém essencial, para desenvolvedores que trabalham com conteúdo de slides. Seja lidando com arquivos Microsoft PowerPoint nos formatos PPT ou PPTX, ou apresentações OpenDocument (ODP), acessar e recuperar dados textuais pode ser crítico para análise, automação, indexação ou migração de conteúdo.

Este artigo fornece um guia abrangente sobre como extrair texto de forma eficiente de vários formatos de apresentação, incluindo PPT, PPTX e ODP, usando Aspose.Slides for C++. Você aprenderá como iterar sistematicamente pelos elementos da apresentação para recuperar com precisão o conteúdo textual de que precisa.

## **Extrair Texto de um Slide**

Aspose.Slides for C++ fornece o namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/) que inclui a classe [SlideUtil](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/). Essa classe expõe vários métodos estáticos sobrecarregados para extrair todo o texto de uma apresentação ou slide. Para extrair texto de um slide em uma apresentação, use o método [GetAllTextBoxes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/getalltextboxes/). Esse método aceita um objeto do tipo [IBaseSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/) como parâmetro. Quando executado, o método varre todo o slide em busca de texto e devolve um array de objetos do tipo [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/), preservando qualquer formatação de texto.

O trecho de código a seguir extrai todo o texto do primeiro slide da apresentação:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Extrair Texto de uma Apresentação**

Para analisar texto de toda a apresentação, use o método estático [GetAllTextFrames](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/getalltextframes/) exposto pela classe [SlideUtil](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/). Ele aceita dois parâmetros:

1. Primeiro, um objeto [IPresentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/) que representa uma apresentação PowerPoint ou OpenDocument da qual o texto será extraído.  
2. Segundo, um valor `Boolean` que indica se os slides mestre devem ser incluídos ao analisar o texto da apresentação.

O método devolve um array de objetos do tipo [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/), incluindo informações de formatação de texto. O código abaixo analisa o texto e os detalhes de formatação de uma apresentação, incluindo os slides mestres.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Extração de Texto Categorizada e Rápida**

A classe [PresentationFactory](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationfactory/) também fornece métodos para extrair todo o texto de apresentações:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

O argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides/textextractionarrangingmode/) indica o modo de organização do resultado da extração de texto e pode ser definido com os seguintes valores:
- `Unarranged` - O texto bruto sem considerar sua posição no slide.  
- `Arranged` - O texto é organizado na mesma ordem do slide.

O modo não organizado pode ser usado quando a velocidade é crítica; ele é mais rápido que o modo organizado.

[IPresentationText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationtext/) representa o texto bruto extraído da apresentação. Seu método `get_SlidesText()` devolve um array de objetos do tipo [ISlideText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidetext/). Cada objeto representa o texto no slide correspondente. O objeto do tipo [ISlideText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidetext/) possui os seguintes métodos:

- `get_Text()` - O texto dentro das formas do slide.  
- `get_MasterText()` - O texto dentro das formas do slide mestre associadas a este slide.  
- `get_LayoutText()` - O texto dentro das formas do slide de layout associadas a este slide.  
- `get_NotesText()` - O texto dentro das formas do slide de notas associadas a este slide.  
- `get_CommentsText()` - O texto dentro dos comentários associados a este slide.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Quão rápido o Aspose.Slides processa apresentações grandes durante a extração de texto?**

Aspose.Slides está otimizado para alto desempenho e pode processar até [grandes apresentações](/slides/pt/cpp/open-presentation/), tornando‑se adequado para cenários de processamento em tempo real ou em lote.

**O Aspose.Slides pode extrair texto de tabelas e gráficos dentro das apresentações?**

Sim. Aspose.Slides pode extrair texto de muitos elementos de slide, incluindo tabelas e objetos relacionados a gráficos, permitindo que você acesse e analise o conteúdo textual em estruturas comuns de apresentação.

**Preciso de uma licença especial do Aspose.Slides para extrair texto de apresentações?**

É possível extrair texto usando a versão de avaliação gratuita do Aspose.Slides, embora ela tenha [certas limitações](/slides/pt/cpp/licensing/), como processar um número limitado de slides. Para uso irrestrito e para manipular apresentações maiores, recomenda‑se adquirir uma licença completa.