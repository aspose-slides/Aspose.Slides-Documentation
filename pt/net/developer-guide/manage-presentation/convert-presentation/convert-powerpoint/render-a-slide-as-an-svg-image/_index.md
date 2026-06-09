---
title: Renderizar Slides de Apresentação como Imagens SVG no .NET
linktitle: Slide para SVG
type: docs
weight: 50
url: /pt/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint para SVG
- apresentação para SVG
- slide para SVG
- PPT para SVG
- PPTX para SVG
- salvar PPT como SVG
- salvar PPTX como SVG
- exportar PPT para SVG
- exportar PPTX para SVG
- renderizar slide
- converter slide
- exportar slide
- imagem vetorial
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a renderizar slides de PowerPoint como imagens SVG usando Aspose.Slides para .NET. Visualizações de alta qualidade com exemplos simples de código C#."
---
## **Visão geral**

Este artigo explica como renderizar slides de apresentação como imagens SVG usando Aspose.Slides. Ele descreve o formato SVG e suas vantagens, incluindo escalabilidade, acessibilidade e adequação ao desenvolvimento web.

Você aprenderá como carregar um arquivo de apresentação, iterar pelos seus slides e salvar cada slide como um arquivo SVG separado. O artigo cobre formatos de apresentação PowerPoint e OpenDocument, incluindo PPT, PPTX, ODP e PPS, e mostra como realizar a conversão programaticamente com a classe `Presentation` e o método `WriteAsSvg`.

## **Formato SVG**
SVG—sigla para Scalable Vector Graphics—é um tipo ou formato padrão de gráficos usado para renderizar imagens bidimensionais. SVG armazena imagens como vetores em XML com detalhes que definem seu comportamento ou aparência. 

SVG é um dos poucos formatos de imagens que atende a padrões muito elevados nesses termos: escalabilidade, interatividade, desempenho, acessibilidade, programabilidade e outros. Por essas razões, é comumente usado no desenvolvimento web. 

Você pode desejar usar arquivos SVG quando precisar

- **imprimir sua apresentação em um *formato muito grande*.** As imagens SVG podem ser dimensionadas para qualquer resolução ou nível. Você pode redimensionar as imagens SVG quantas vezes forem necessárias sem sacrificar a qualidade.
- **usar gráficos e diagramas dos seus slides em *diferentes meios ou plataformas*.** A maioria dos visualizadores pode interpretar arquivos SVG. 
- **usar o *menor tamanho possível de imagens*.** Arquivos SVG geralmente são menores que seus equivalentes de alta resolução em outros formatos, especialmente aqueles baseados em bitmap (JPEG ou PNG).

## **Renderizar um slide como imagem SVG**

Aspose.Slides for .NET permite exportar slides em suas apresentações como imagens SVG. Siga estas etapas para gerar imagens SVG:

_Etapas: Conversões de PowerPoint para SVG em C#_

- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Etapas: Converter PowerPoint para SVG em C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Etapas: Converter PPT para SVG em C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Etapas: Converter PPTX para SVG em C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Etapas: Converter ODP para SVG em C#</strong></a>

_Etapas de código:_

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
   * extensão _.ppt_ para carregar arquivo **PPT** dentro da classe _Presentation_.
   * extensão _.pptx_ para carregar arquivo **PPTX** dentro da classe _Presentation_.
   * extensão _.odp_ para carregar arquivo **ODP** dentro da classe _Presentation_.
   * extensão _.pps_ para carregar arquivo **PPS** dentro da classe _Presentation_.
2. Iterate through all the slides in the presentation.
3. Grame cada slide em seu próprio arquivo SVG usando FileStream.

{{% alert color="primary" %}} 
Você pode querer experimentar nosso [aplicativo web gratuito](https://products.aspose.app/slides/pt/conversion/ppt-to-svg) no qual implementamos a função de conversão de PPT para SVG do Aspose.Slides for .NET.
{{% /alert %}} 

Este código de exemplo em C# mostra como converter PowerPoint para SVG usando Aspose.Slides: 

``` csharp
// O objeto Presentation pode carregar formatos PowerPoint como PPT, PPTX, ODP etc.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **Perguntas frequentes**

**Por que o SVG resultante pode parecer diferente em diferentes navegadores?**

O suporte a recursos específicos do SVG é implementado de forma diferente pelos motores dos navegadores. Os parâmetros [SVGOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/svgoptions/) ajudam a suavizar incompatibilidades.

**É possível exportar não apenas slides, mas também formas individuais para SVG?**

Sim. Qualquer [forma pode ser salva como um SVG separado](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/writeassvg/), o que é conveniente para ícones, pictogramas e reutilização de gráficos.

**É possível combinar vários slides em um único SVG (faixa/documento)?**

O cenário padrão é um slide → um SVG. Combinar vários slides em uma única tela SVG é uma etapa de pós-processamento realizada no nível da aplicação.

## **Veja também** 

Este artigo também abrange estes tópicos. Os códigos são os mesmos acima.

_Formato_: **PowerPoint**
- [Código C# PowerPoint para SVG](#csharp-powerpoint-to-svg)
- [API C# PowerPoint para SVG](#csharp-powerpoint-to-svg)
- [Programaticamente C# PowerPoint para SVG](#csharp-powerpoint-to-svg)
- [Biblioteca C# PowerPoint para SVG](#csharp-powerpoint-to-svg)
- [Salvar PowerPoint como SVG em C#](#csharp-powerpoint-to-svg)
- [Gerar SVG a partir de PowerPoint em C#](#csharp-powerpoint-to-svg)
- [Criar SVG a partir de PowerPoint em C#](#csharp-powerpoint-to-svg)
- [Conversor C# PowerPoint para SVG](#csharp-powerpoint-to-svg)

_Formato_: **PPT**
- [Código C# PPT para SVG](#csharp-ppt-to-svg)
- [API C# PPT para SVG](#csharp-ppt-to-svg)
- [Programaticamente C# PPT para SVG](#csharp-ppt-to-svg)
- [Biblioteca C# PPT para SVG](#csharp-ppt-to-svg)
- [Salvar PPT como SVG em C#](#csharp-ppt-to-svg)
- [Gerar SVG a partir de PPT em C#](#csharp-ppt-to-svg)
- [Criar SVG a partir de PPT em C#](#csharp-ppt-to-svg)
- [Conversor C# PPT para SVG](#csharp-ppt-to-svg)

_Formato_: **PPTX**
- [Código C# PPTX para SVG](#csharp-pptx-to-svg)
- [API C# PPTX para SVG](#csharp-pptx-to-svg)
- [Programaticamente C# PPTX para SVG](#csharp-pptx-to-svg)
- [Biblioteca C# PPTX para SVG](#csharp-pptx-to-svg)
- [Salvar PPTX como SVG em C#](#csharp-pptx-to-svg)
- [Gerar SVG a partir de PPTX em C#](#csharp-pptx-to-svg)
- [Criar SVG a partir de PPTX em C#](#csharp-pptx-to-svg)
- [Conversor C# PPTX para SVG](#csharp-pptx-to-svg)

_Formato_: **ODP**
- [Código C# ODP para SVG](#csharp-odp-to-svg)
- [API C# ODP para SVG](#csharp-odp-to-svg)
- [Programaticamente C# ODP para SVG](#csharp-odp-to-svg)
- [Biblioteca C# ODP para SVG](#csharp-odp-to-svg)
- [Salvar ODP como SVG em C#](#csharp-odp-to-svg)
- [Gerar SVG a partir de ODP em C#](#csharp-odp-to-svg)
- [Criar SVG a partir de ODP em C#](#csharp-odp-to-svg)
- [Conversor C# ODP para SVG](#csharp-odp-to-svg)