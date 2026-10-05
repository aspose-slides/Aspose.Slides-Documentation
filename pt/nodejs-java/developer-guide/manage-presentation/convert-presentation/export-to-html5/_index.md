---
title: Converter Apresentações para HTML5 em JavaScript
linktitle: Apresentação para HTML5
type: docs
weight: 40
url: /pt/nodejs-java/export-to-html5/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Exporte apresentações PowerPoint e OpenDocument para HTML5 responsivo com Aspose.Slides para Node.js. Preserve formatação, animações e interatividade."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para HTML5 usando Aspose.Slides para Node.js via Java. Ele aborda a exportação básica, o controle de animações de formas e transições de slides, e o layout de comentários. Também compara a saída HTML5 com a saída baseada em SVG da exportação HTML padrão.

## **Exportar PowerPoint para HTML5**

O exemplo a seguir carrega uma apresentação do diretório de trabalho e a salva no formato HTML5. Ele usa as configurações padrão de exportação; o próximo exemplo mostra como controlar a reprodução de animações explicitamente. Substitua o caminho de entrada pelo caminho da sua apresentação.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Além do documento HTML, a exportação grava arquivos CSS e JavaScript de suporte para estilos de slides, animações, efeitos e navegação. Mantenha esses arquivos com o documento HTML ao mover ou publicar a saída. A página gerada também carrega jQuery e Anime.js de CDNs públicas; sem eles, a navegação e as animações dos slides não funcionam.
{{% /alert %}}

Para exportar sem reproduzir animações de formas ou transições de slides, passe `false` para [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) e [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) em [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Essas configurações são independentes, portanto você pode habilitar uma enquanto desabilita a outra. O exemplo exporta a apresentação com ambos os tipos de animação desativados na página gerada.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Exportar PowerPoint para HTML**

A exportação padrão para HTML usa uma abordagem de renderização diferente: o conteúdo dos slides é representado por SVG dentro de uma página HTML. O exemplo a seguir converte uma apresentação em um documento HTML usando essa abordagem de renderização.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

O markup simplificado abaixo ilustra a estrutura da página gerada. O elemento SVG contém o conteúdo do slide renderizado; o texto do placeholder representa esse conteúdo e não é a saída literal da exportação.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
A exportação baseada em SVG não expõe as formas do PowerPoint como elementos HTML individuais. Use a exportação HTML5 quando precisar das opções de animação de formas e transição de slides demonstradas neste artigo.
{{% /alert %}}

## **Exportar PowerPoint para Visualização de Slides HTML5**

A exportação HTML5 produz uma página para visualizar e navegar pelos slides da apresentação em um navegador. Este exemplo habilita tanto [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) quanto [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) para que a visualização de slides exportada possa reproduzir os efeitos da apresentação original.

Use uma apresentação que já contenha animações de formas e transições de slides para ver o efeito dessas configurações. Habilitá‑las não adiciona novos efeitos a slides que não os possuam. Após a exportação, abra o documento HTML5 gerado em um navegador com seus arquivos de suporte disponíveis.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **Converter uma Apresentação em um Documento HTML5 com Comentários**

Você pode incluir comentários de slide existentes na saída HTML5 para que os leitores vejam feedback ao lado do conteúdo do slide. O exemplo nesta seção espera que a apresentação de origem contenha comentários, conforme ilustrado abaixo. Ele exporta esses comentários; não cria novos.

![Two comments on the presentation slide](two_comments_pptx.png)

Passe um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) para o método [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) de [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/). Use [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) para selecionar `Right` da enumeração [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) e posicionar os comentários à direita de cada slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

O exemplo a seguir exporta a apresentação para HTML5 com este layout de comentários. Uma apresentação sem comentários não terá texto de comentário para exibir.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Excluir Hyperlinks JavaScript Durante a Exportação**

Suponha que `hyperlinks.pptx` contenha texto vinculado com um destino `javascript:alert('Hello')` e um link comum `https://example.com/`. Para excluir o hyperlink JavaScript durante a exportação, passe `true` para [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-). O padrão é `false`, portanto esses links não são filtrados a menos que a opção seja ativada.

O exemplo a seguir carrega a apresentação do diretório de trabalho e a exporta usando [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

O arquivo exportado omite o hyperlink JavaScript enquanto mantém seu texto e o link HTTPS normal. A apresentação de origem permanece inalterada.

Esta opção filtra hyperlinks JavaScript; não remove todos os scripts ou outro conteúdo ativo, nem garante conformidade com CSP. Por exemplo, a saída HTML5 ainda inclui scripts para navegação de slides e animações.

## **Perguntas Frequentes**

**Posso controlar se as animações de objetos e transições de slides serão reproduzidas no HTML5?**

Sim, a exportação HTML5 oferece opções distintas para habilitar ou desabilitar [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) e [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Os comentários são suportados e onde podem ser posicionados em relação ao slide?**

Sim, os comentários existentes podem ser incluídos na saída HTML5 e posicionados (por exemplo, à direita do slide) através das [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) para notas e comentários.

**Posso ignorar links que invocam JavaScript por razões de segurança ou CSP?**

Sim, a configuração [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) permite pular hyperlinks com chamadas JavaScript durante a gravação. O padrão é `false`. Consulte [Excluir Hyperlinks JavaScript Durante a Exportação](/slides/pt/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) para um exemplo de exportação HTML5 e o escopo do filtro. Esta configuração não remove o JavaScript usado pelo visualizador HTML5 para navegação e animações.