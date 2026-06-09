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
description: "Exportar apresentações PowerPoint e OpenDocument para HTML5 responsivo com Aspose.Slides para C++. Preserve a formatação, animações e interatividade."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para HTML5 usando Aspose.Slides. Ele cobre exportação básica para HTML5 sem extensões web ou dependências adicionais, bem como opções para controlar animações de formas e transições de slides. O artigo também mostra o processo padrão de exportação de PowerPoint para HTML, explica como gerar saída HTML5 no modo de visualização de slides e demonstra como incluir comentários no documento exportado configurando seu layout.

## **Exportar PowerPoint para HTML5**

Este código C++ mostra como exportar uma apresentação para HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
Neste caso, você obtém HTML limpo. 
{{% /alert %}}

Você pode especificar configurações para animações de formas e transições de slides desta forma:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Exportar PowerPoint para HTML**

Este C++ demonstra o processo padrão de exportação de PowerPoint para HTML:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

Neste caso, o conteúdo da apresentação é renderizado através de SVG em uma forma como esta:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Nota" color="warning" %}} 
Ao usar este método para exportar PowerPoint para HTML, devido à renderização em SVG, você não poderá aplicar estilos ou animar elementos específicos. 
{{% /alert %}}

## **Exportar PowerPoint para Visualização de Slides HTML5**

**Aspose.Slides** permite converter uma apresentação do PowerPoint para um documento HTML5 no qual os slides são apresentados em modo de visualização de slides. Nesse caso, ao abrir o arquivo HTML5 resultante em um navegador, você vê a apresentação em modo de visualização de slides em uma página web. 

Este código C++ demonstra o processo de exportação de PowerPoint para Visualização de Slides HTML5:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Converter uma Apresentação para um Documento HTML5 com Comentários**

Os comentários no PowerPoint são uma ferramenta que permite aos usuários deixar notas ou feedback nos slides da apresentação. Eles são especialmente úteis em projetos colaborativos, onde várias pessoas podem adicionar sugestões ou observações a elementos específicos dos slides sem alterar o conteúdo principal. Cada comentário exibe o nome do autor, facilitando rastrear quem deixou a observação.

Vamos supor que temos a seguinte apresentação do PowerPoint salva no arquivo "sample.pptx".

![Dois comentários no slide da apresentação](two_comments_pptx.png)

Ao converter uma apresentação do PowerPoint para um documento HTML5, você pode especificar facilmente se deseja incluir comentários da apresentação no documento de saída. Para isso, é necessário definir os parâmetros de exibição dos comentários no método `get_NotesCommentsLayouting` da classe [Html5Options](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/).

O exemplo de código a seguir converte uma apresentação para um documento HTML5 com comentários exibidos à direita dos slides.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

O documento "output.html" é exibido na imagem abaixo.

![Os comentários no documento HTML5 de saída](two_comments_html5.png)

## **FAQ**

**Posso controlar se as animações de objetos e as transições de slides serão reproduzidas em HTML5?**

Sim, o HTML5 fornece opções separadas para habilitar ou desabilitar [shape animations](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/set_animateshapes/) e [slide transitions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**O suporte à saída de comentários está disponível e onde eles podem ser posicionados em relação ao slide?**

Sim, os comentários podem ser adicionados em HTML5 e posicionados (por exemplo, à direita do slide) por meio das configurações de layout para notas e comentários.

**Posso ignorar links que invocam JavaScript por motivos de segurança ou CSP?**

Sim, há uma [setting](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) que permite ignorar hiperlinks com chamadas JavaScript durante a gravação. Isso ajuda a cumprir políticas de segurança rigorosas.