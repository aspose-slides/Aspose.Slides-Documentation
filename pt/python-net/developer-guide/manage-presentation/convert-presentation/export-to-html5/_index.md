---
title: Converter Apresentações para HTML5 em Python
linktitle: Apresentação para HTML5
type: docs
weight: 40
url: /pt/python-net/export-to-html5/
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
- Python
- Aspose.Slides
description: "Exportar apresentações PowerPoint e OpenDocument para HTML5 responsivo com Aspose.Slides for Python via .NET. Preservar formatação, animações e interatividade."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para HTML5 usando Aspose.Slides for Python via .NET. Ele cobre exportação básica, controle de animações de formas e transições de slides, e layout de comentários. Também compara a saída HTML5 com a saída baseada em SVG da exportação HTML padrão.

## **Exportar PowerPoint para HTML5**

O exemplo a seguir carrega uma apresentação do diretório de trabalho e a salva no formato HTML5. Ele usa as configurações padrão de exportação; o próximo exemplo mostra como controlar a reprodução de animações explicitamente. Substitua o caminho de entrada pelo caminho da sua apresentação.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
Além do documento HTML, a exportação grava arquivos CSS e JavaScript de apoio para estilização de slides, animações, efeitos e navegação. Mantenha esses arquivos com o documento HTML ao mover ou publicar a saída. A página gerada também carrega jQuery e Anime.js de CDNs públicas; sem eles, a navegação de slides e as animações não funcionam.
{{% /alert %}}

Para exportar sem reproduzir animações de formas ou transições de slides, defina [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) e [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) como `False` em [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Essas configurações são independentes, portanto você pode habilitar uma enquanto desabilita a outra. O exemplo exporta a apresentação com ambos os tipos de animação desativados na página gerada.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Exportar PowerPoint para HTML**

A exportação padrão para HTML usa uma abordagem de renderização diferente: o conteúdo dos slides é representado por SVG dentro de uma página HTML. O exemplo a seguir converte uma apresentação para um documento HTML usando essa abordagem de renderização.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
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

## **Exportar PowerPoint para Visualização de Slides HTML5**

A exportação HTML5 produz uma página para visualizar e navegar pelos slides da apresentação em um navegador. Este exemplo habilita tanto [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) quanto [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) para que a visualização de slides exportada possa reproduzir os efeitos da apresentação original.

Use uma apresentação que já contenha animações de formas e transições de slides para ver o efeito dessas configurações. Habilitá‑las não adiciona novos efeitos a slides que não os possuam. Após a exportação, abra o documento HTML5 gerado em um navegador com seus arquivos de suporte disponíveis.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **Converter uma Apresentação para um Documento HTML5 com Comentários**

Você pode incluir comentários de slide existentes na saída HTML5 para que os leitores vejam feedback ao lado do conteúdo do slide. O exemplo nesta seção pressupõe que a apresentação fonte contenha comentários, conforme ilustrado abaixo. Ele exporta esses comentários; não cria novos.

![Dois comentários no slide da apresentação](two_comments_pptx.png)

Atribua um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) à propriedade [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) de [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/). Defina [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) como `RIGHT` a partir da enumeração [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) para posicionar os comentários à direita de cada slide.

O exemplo a seguir exporta a apresentação para HTML5 com esse layout de comentários. Uma apresentação sem comentários não terá texto de comentário para exibir.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

A imagem abaixo mostra o documento HTML5 exportado com os comentários exibidos ao lado do slide.

![Os comentários no documento HTML5 de saída](two_comments_html5.png)

## **Excluir Hiperlinks JavaScript Durante a Exportação**

Suponha que `hyperlinks.pptx` contenha texto vinculado com um alvo `javascript:alert('Hello')` e um link ordinário `https://example.com/`. Para excluir o hiperlink JavaScript durante a exportação, defina [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) como `True`. O padrão é `False`, portanto esses links não são filtrados a menos que você habilite a opção.

O exemplo a seguir carrega a apresentação do diretório de trabalho e a exporta usando [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/):

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

O arquivo exportado omite o hiperlink JavaScript enquanto mantém seu texto e o link HTTPS comum. A apresentação fonte permanece inalterada.

Esta opção filtra hiperlinks JavaScript; ela não remove todos os scripts ou outro conteúdo ativo, nem garante conformidade com CSP. Por exemplo, a saída HTML5 ainda inclui scripts para navegação de slides e animações.

## **FAQ**

**Posso controlar se as animações de objetos e as transições de slide serão reproduzidas em HTML5?**

Sim, a exportação HTML5 fornece opções separadas para habilitar ou desabilitar [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) e [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/).

**Os comentários são suportados, e onde eles podem ser posicionados em relação ao slide?**

Sim, comentários existentes podem ser incluídos na saída HTML5 e posicionados (por exemplo, à direita do slide) através das [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) para notas e comentários.

**Posso pular links que invocam JavaScript por motivos de segurança ou CSP?**

Sim, a configuração [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) permite ignorar hiperlinks com chamadas JavaScript durante a gravação. O padrão é `False`. Consulte [Exclude JavaScript Hyperlinks During Export](/slides/pt/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) para um exemplo de exportação HTML5 e o escopo do filtro. Esta configuração não remove o JavaScript usado pelo visualizador HTML5 para navegação e animações.