---
title: Converter apresentações para HTML5 em .NET
linktitle: Apresentação para HTML5
type: docs
weight: 40
url: /pt/net/export-to-html5/
keywords:
- PowerPoint para HTML5
- OpenDocument para HTML5
- apresentação para HTML5
- slide para HTML5
- PPT para HTML5
- PPTX para HTML5
- ODP para HTML5
- salvar PPT como HTML5
- salvar PPTX como HTML5
- salvar ODP como HTML5
- exportar PPT para HTML5
- exportar PPTX para HTML5
- exportar ODP para HTML5
- .NET
- C#
- Aspose.Slides
description: "Exporte apresentações PowerPoint e OpenDocument para HTML5 responsivo com Aspose.Slides para .NET. Preserve formatação, animações e interatividade."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para HTML5 usando Aspose.Slides para .NET. Ele cobre exportação básica, controle de animações de formas e transições de slides, e layout de comentários. Também compara a saída HTML5 com a saída baseada em SVG da exportação padrão de HTML.

## **Exportar PowerPoint para HTML5**

O exemplo a seguir carrega uma apresentação do diretório de trabalho e a salva no formato HTML5. Ele usa as configurações padrão de exportação; o próximo exemplo mostra como controlar a reprodução de animações explicitamente. Substitua o caminho de entrada pelo caminho da sua apresentação.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Nota" %}}
Além do documento HTML, a exportação grava arquivos CSS e JavaScript de suporte para estilo de slides, animações, efeitos e navegação. Mantenha esses arquivos junto com o documento HTML ao mover ou publicar a saída. A página gerada também carrega jQuery e Anime.js de CDNs públicas; sem eles, a navegação e as animações dos slides não são executadas.
{{% /alert %}}

Para exportar sem reproduzir animações de formas ou transições de slides, defina [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) e [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) como `false` em [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Essas configurações são independentes, portanto você pode habilitar uma enquanto desabilita a outra. O exemplo exporta a apresentação com ambos os tipos de animação desativados na página gerada.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **Exportar PowerPoint para HTML**

A exportação padrão para HTML usa uma abordagem de renderização diferente: o conteúdo dos slides é representado por SVG dentro de uma página HTML. O exemplo a seguir converte uma apresentação para um documento HTML usando essa abordagem de renderização.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

A marcação simplificada abaixo ilustra a estrutura da página gerada. O elemento SVG contém o conteúdo renderizado do slide; o texto de espaço reservado representa esse conteúdo e não é a saída literal da exportação.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Aviso" color="warning" %}}
A exportação baseada em SVG não expõe as formas do PowerPoint como elementos HTML individuais. Use a exportação HTML5 quando precisar das opções de animação de formas e transição de slides demonstradas neste artigo.
{{% /alert %}}

## **Exportar PowerPoint para Visualização de Slides HTML5**

A exportação HTML5 produz uma página para visualizar e navegar pelos slides da apresentação em um navegador. Este exemplo habilita tanto [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) quanto [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) para que a visualização de slides exportada possa reproduzir os efeitos da apresentação original.

Use uma apresentação que já contenha animações de formas e transições de slides para ver o efeito dessas configurações. Habilitá‑las não adiciona novos efeitos a slides que não possuem nenhum. Após a exportação, abra o documento HTML5 gerado em um navegador com seus arquivos de suporte disponíveis.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **Converter uma Apresentação para um Documento HTML5 com Comentários**

Você pode incluir comentários de slide existentes na saída HTML5 para que os leitores vejam feedback ao lado do conteúdo do slide. O exemplo nesta seção espera que a apresentação origem contenha comentários, conforme ilustrado abaixo. Ele exporta esses comentários; não cria novos.

![Dois comentários no slide da apresentação](two_comments_pptx.png)

Atribua um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) à propriedade [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) de [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/). Defina [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) como `Right` a partir da enumeração [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) para posicionar os comentários à direita de cada slide.

O exemplo a seguir exporta a apresentação para HTML5 com esse layout de comentários. Uma apresentação sem comentários não terá texto de comentário para exibir.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

A imagem abaixo mostra o documento HTML5 exportado com os comentários exibidos ao lado do slide.

![Os comentários no documento HTML5 de saída](two_comments_html5.png)

## **Excluir Hiperlinks JavaScript Durante a Exportação**

Suponha que `hyperlinks.pptx` contenha texto vinculado com um destino `javascript:alert('Hello')` e um link comum `https://example.com/`. Para excluir o hiperlink JavaScript durante a exportação, defina [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) como `true`. O padrão é `false`, portanto esses links não são filtrados a menos que você habilite a opção.

O exemplo a seguir carrega a apresentação do diretório de trabalho e a exporta usando [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

O arquivo exportado omite o hiperlink JavaScript enquanto mantém seu texto e o link HTTPS comum. A apresentação origem permanece inalterada.

Esta opção filtra hiperlinks JavaScript; não remove todos os scripts ou outro conteúdo ativo, nem garante conformidade com CSP. Por exemplo, a saída HTML5 ainda inclui scripts para navegação de slides e animações.

## **Perguntas frequentes**

**Posso controlar se as animações de objetos e as transições de slides serão reproduzidas no HTML5?**

Sim, a exportação HTML5 fornece opções separadas para habilitar ou desabilitar [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) e [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/).

**Os comentários são suportados e onde podem ser posicionados em relação ao slide?**

Sim, comentários existentes podem ser incluídos na saída HTML5 e posicionados (por exemplo, à direita do slide) através das [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) para notas e comentários.

**Posso pular links que invocam JavaScript por motivos de segurança ou CSP?**

Sim, a configuração [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) permite pular hiperlinks com chamadas JavaScript durante a gravação. O padrão é `false`. Consulte [Exclude JavaScript Hyperlinks During Export](/slides/pt/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) para um exemplo simples de exportação em HTML, HTML5 e PDF e o escopo do filtro. Esta configuração não remove o JavaScript usado pelo visualizador HTML5 para navegação e animações.