---
title: Converter apresentações para HTML5 em PHP
linktitle: Apresentação para HTML5
type: docs
weight: 40
url: /pt/php-java/export-to-html5/
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
- PHP
- Aspose.Slides
description: "Exportar apresentações PowerPoint e OpenDocument para HTML5 responsivo com Aspose.Slides para PHP via Java. Preserve a formatação, animações e interatividade."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para HTML5 usando Aspose.Slides for PHP via Java. Ele cobre a exportação básica, o controle de animações de forma e transições de slides, e o layout de comentários. Também compara a saída HTML5 com a saída baseada em SVG da exportação HTML padrão.

## **Exportar PowerPoint para HTML5**

O exemplo a seguir carrega uma apresentação do diretório de trabalho e a salva no formato HTML5. Ele usa as configurações padrão de exportação; o próximo exemplo mostra como controlar a reprodução de animações explicitamente. Substitua o caminho de entrada pelo caminho da sua apresentação.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Além do documento HTML, a exportação grava arquivos CSS e JavaScript de suporte para estilo de slides, animações, efeitos e navegação. Mantenha esses arquivos junto com o documento HTML ao mover ou publicar a saída. A página gerada também carrega jQuery e Anime.js a partir de CDNs públicas; sem eles, a navegação de slides e as animações não funcionam.
{{% /alert %}}

Para exportar sem reproduzir animações de forma ou transições de slides, passe `false` para [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) e [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) em [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Essas configurações são independentes, portanto você pode habilitar uma e desabilitar a outra. O exemplo exporta a apresentação com ambos os tipos de animação desativados na página gerada.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Exportar PowerPoint para HTML**

A exportação HTML padrão usa uma abordagem de renderização diferente: o conteúdo dos slides é representado por SVG dentro de uma página HTML. O exemplo a seguir converte uma apresentação para um documento HTML usando essa abordagem de renderização.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
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

{{% alert title="Warning" color="warning" %}}
A exportação baseada em SVG não expõe as formas do PowerPoint como elementos HTML individuais. Use a exportação HTML5 quando precisar das opções de animação de forma e transição de slide demonstradas neste artigo.
{{% /alert %}}

## **Exportar PowerPoint para visualização de slides HTML5**

A exportação HTML5 produz uma página para visualização e navegação dos slides da apresentação em um navegador. Este exemplo habilita tanto [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) quanto [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) para que a visualização de slides exportada possa reproduzir efeitos da apresentação original.

Use uma apresentação que já contenha animações de forma e transições de slides para ver o efeito dessas configurações. Habilitá‑las não adiciona novos efeitos a slides que não possuam nenhum. Depois da exportação, abra o documento HTML5 gerado em um navegador com seus arquivos de suporte disponíveis.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **Converter uma apresentação para um documento HTML5 com comentários**

Você pode incluir os comentários existentes dos slides na saída HTML5 para que os leitores vejam o feedback ao lado do conteúdo do slide. O exemplo nesta seção espera que a apresentação de origem contenha comentários, conforme ilustrado abaixo. Ele exporta esses comentários; não cria novos.

![Dois comentários no slide da apresentação](two_comments_pptx.png)

Passe um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) para o método [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) de [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). Use [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) para selecionar `Right` na enumeração [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) e colocar os comentários à direita de cada slide.

O exemplo a seguir exporta a apresentação para HTML5 com esse layout de comentários. Uma apresentação sem comentários não terá texto de comentário para exibir.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

A imagem abaixo mostra o documento HTML5 exportado com os comentários exibidos ao lado do slide.

![Os comentários no documento HTML5 de saída](two_comments_html5.png)

## **Excluir hiperlinks JavaScript durante a exportação**

Suponha que `hyperlinks.pptx` contenha texto vinculado com um destino `javascript:alert('Hello')` e um link comum `https://example.com/`. Para excluir o hiperlink JavaScript durante a exportação, passe `true` para [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). O padrão é `false`, portanto esses links não são filtrados a menos que a opção seja habilitada.

O exemplo a seguir carrega a apresentação do diretório de trabalho e a exporta usando [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

O arquivo exportado omite o hiperlink JavaScript enquanto mantém seu texto e o link HTTPS comum. A apresentação original permanece inalterada.

Esta opção filtra hiperlinks JavaScript; não remove todos os scripts ou outro conteúdo ativo, nem garante conformidade com CSP. Por exemplo, a saída HTML5 ainda inclui scripts para navegação de slides e animações.

## **FAQ**

**Posso controlar se as animações de objetos e as transições de slide serão reproduzidas no HTML5?**

Sim, a exportação HTML5 fornece opções separadas para habilitar ou desabilitar [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) e [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions).

**Os comentários são suportados, e onde podem ser posicionados em relação ao slide?**

Sim, comentários existentes podem ser incluídos na saída HTML5 e posicionados (por exemplo, à direita do slide) através das [configurações de layout](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) de notas e comentários.

**Posso ignorar links que invocam JavaScript por motivos de segurança ou CSP?**

Sim, a configuração [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) permite ignorar hiperlinks com chamadas JavaScript durante a gravação. O padrão é `false`. Veja [Excluir hiperlinks JavaScript durante a exportação](/slides/pt/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) para um exemplo de exportação HTML5 e o escopo do filtro. Essa configuração não remove o JavaScript usado pelo visualizador HTML5 para navegação e animações.