---
title: Converter apresentações para HTML5 em C++
linktitle: Apresentação para HTML5
type: docs
weight: 40
url: /pt/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Exportar apresentações PowerPoint e OpenDocument para HTML5 responsivo com Aspose.Slides para C++. Preservar formatação, animações e interatividade."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para HTML5 usando Aspose.Slides para C++. Ele abrange a exportação básica, o controle de animações de formas e transições de slides, e o layout de comentários. Também compara a saída HTML5 com a saída baseada em SVG da exportação HTML padrão.

## **Exportar PowerPoint para HTML5**

O exemplo a seguir carrega uma apresentação do diretório de trabalho e a salva no formato HTML5. Ele usa as configurações padrão de exportação; o próximo exemplo mostra como controlar a reprodução de animações explicitamente. Substitua o caminho de entrada pelo caminho da sua apresentação.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Além do documento HTML, a exportação grava arquivos CSS e JavaScript de suporte para estilo dos slides, animações, efeitos e navegação. Mantenha esses arquivos junto com o documento HTML ao mover ou publicar a saída. A página gerada também carrega jQuery e Anime.js de CDNs públicas; sem eles, a navegação e as animações dos slides não funcionam.
{{% /alert %}}

Para exportar sem reproduzir animações de formas ou transições de slides, passe `false` para [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) e [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) em [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Essas configurações são independentes, então você pode habilitar uma enquanto desabilita a outra. O exemplo exporta a apresentação com ambos os tipos de animação desativados na página gerada.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Exportar PowerPoint para HTML**

A exportação HTML padrão usa uma abordagem de renderização diferente: o conteúdo do slide é representado por SVG dentro de uma página HTML. O exemplo a seguir converte uma apresentação para um documento HTML usando essa abordagem de renderização.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

A marcação simplificada abaixo ilustra a estrutura da página gerada. O elemento SVG contém o conteúdo do slide renderizado; o texto de espaço reservado representa esse conteúdo e não é a saída literal da exportação.

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

## **Exportar PowerPoint para visualização de slides em HTML5**

A exportação HTML5 produz uma página para visualização e navegação dos slides da apresentação em um navegador. Este exemplo passa `true` tanto para [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) quanto para [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) para que a visualização de slides exportada possa reproduzir os efeitos da apresentação original.

Use uma apresentação que já contenha animações de formas e transições de slides para observar o efeito dessas configurações. Habilitá‑las não adiciona novos efeitos a slides que não os possuam. Após a exportação, abra o documento HTML5 gerado em um navegador com seus arquivos de suporte disponíveis.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Converter uma apresentação para um documento HTML5 com comentários**

Você pode incluir comentários de slide existentes na saída HTML5 para que os leitores vejam o feedback ao lado do conteúdo do slide. O exemplo nesta seção pressupõe que a apresentação de origem contenha comentários, como ilustrado abaixo. Ele exporta esses comentários; não cria novos.

![Dois comentários no slide da apresentação](two_comments_pptx.png)

Passe um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) para o método [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) de [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Chame [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) com `CommentsPositions::Right` da enumeração [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) para posicionar os comentários à direita de cada slide.

O exemplo a seguir exporta a apresentação para HTML5 com esse layout de comentários. Uma apresentação sem comentários não terá texto de comentário para exibir.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

A imagem abaixo mostra o documento HTML5 exportado com os comentários exibidos ao lado do slide.

![Os comentários no documento HTML5 de saída](two_comments_html5.png)

## **Excluir hiperlinks JavaScript durante a exportação**

Suponha que `hyperlinks.pptx` contenha texto vinculado com um destino `javascript:alert('Hello')` e um link ordinário `https://example.com/`. Para excluir o hiperlink JavaScript durante a exportação, chame [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) com `true`. O padrão é `false`, portanto esses links não são filtrados a menos que você habilite a opção.

O exemplo a seguir carrega a apresentação do diretório de trabalho e a exporta usando [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

O arquivo exportado omite o hiperlink JavaScript mantendo seu texto e o link HTTPS comum. A apresentação de origem permanece inalterada.

Essa opção filtra hiperlinks JavaScript; não remove todos os scripts ou outro conteúdo ativo, nem garante conformidade com CSP. Por exemplo, a saída HTML5 ainda inclui scripts para navegação e animações dos slides.

## **Perguntas frequentes**

**Posso controlar se as animações de objetos e transições de slides serão reproduzidas em HTML5?**

Sim, a exportação HTML5 oferece opções separadas para habilitar ou desabilitar [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) e [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Os comentários são suportados e onde podem ser posicionados em relação ao slide?**

Sim, comentários existentes podem ser incluídos na saída HTML5 e posicionados (por exemplo, à direita do slide) através das [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) para notas e comentários.

**Posso ignorar links que invocam JavaScript por motivos de segurança ou CSP?**

Sim, o método [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) permite omitir hiperlinks com chamadas JavaScript durante a gravação. O padrão é `false`. Veja [Excluir hiperlinks JavaScript durante a exportação](/slides/pt/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) para um exemplo de exportação HTML5 e o escopo do filtro. Essa configuração não remove o JavaScript usado pelo visualizador HTML5 para navegação e animações.