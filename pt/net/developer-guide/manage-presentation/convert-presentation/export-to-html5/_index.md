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
description: "Exporte apresentações PowerPoint e OpenDocument para HTML5 responsivo com Aspose.Slides para .NET. Preserve a formatação, animações e interatividade."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para HTML5 usando Aspose.Slides. Ele cobre a exportação básica para HTML5 sem extensões web ou dependências adicionais, bem como opções para controlar animações de formas e transições de slides. O artigo também mostra o processo padrão de exportação de PowerPoint para HTML, explica como gerar saída HTML5 no modo de visualização de slides e demonstra como incluir comentários no documento exportado configurando seu layout.

## **Exportar PowerPoint para HTML5**

Este código C# mostra como exportar uma apresentação para HTML5 sem extensões web e dependências:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 

Neste caso, você obtém HTML limpo. 

{{% /alert %}}

Você pode especificar configurações para animações de formas e transições de slides desta forma:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Exportar PowerPoint para HTML**

Este C# demonstra o processo padrão de exportação de PowerPoint para HTML:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

Neste caso, o conteúdo da apresentação é renderizado através de SVG em um formato como este:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 

Ao usar este método para exportar PowerPoint para HTML, devido à renderização SVG, você não poderá aplicar estilos ou animar elementos específicos. 

{{% /alert %}}

## **Exportar PowerPoint para Visualização de Slides HTML5**

**Aspose.Slides** permite converter uma apresentação do PowerPoint em um documento HTML5 no qual os slides são apresentados em modo de visualização de slides. Neste caso, ao abrir o arquivo HTML5 resultante em um navegador, você vê a apresentação em modo de visualização de slides em uma página web. 

Este código C# demonstra o processo de exportação de PowerPoint para Visualização de Slides HTML5:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Converter uma Apresentação em um Documento HTML5 com Comentários**

Comentários no PowerPoint são uma ferramenta que permite aos usuários deixar notas ou feedback nos slides da apresentação. Eles são especialmente úteis em projetos colaborativos, onde várias pessoas podem adicionar sugestões ou observações a elementos específicos dos slides sem alterar o conteúdo principal. Cada comentário mostra o nome do autor, facilitando rastrear quem deixou a observação.

Suponha que tenhamos a seguinte apresentação do PowerPoint salva no arquivo "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

Ao converter uma apresentação do PowerPoint para um documento HTML5, você pode especificar facilmente se deseja incluir os comentários da apresentação no documento de saída. Para fazer isso, é necessário especificar os parâmetros de exibição dos comentários na propriedade `NotesCommentsLayouting` da classe [Html5Options](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/) .

O exemplo de código a seguir converte uma apresentação em um documento HTML5 com comentários exibidos à direita dos slides.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

O documento "output.html" é mostrado na imagem abaixo.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Posso controlar se as animações de objetos e as transições de slides serão reproduzidas em HTML5?**

Sim, o HTML5 oferece opções separadas para habilitar ou desabilitar [animações de formas](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/animateshapes/) e [transições de slides](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/animatetransitions/).

**O suporte à saída de comentários está disponível e onde eles podem ser posicionados em relação ao slide?**

Sim, comentários podem ser adicionados em HTML5 e posicionados (por exemplo, à direita do slide) através das [configurações de layout](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/notescommentslayouting/) para notas e comentários.

**Posso pular links que invocam JavaScript por razões de segurança ou CSP?**

Sim, existe uma [configuração](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) que permite pular hiperlinks com chamadas JavaScript durante a gravação. Isso ajuda a cumprir políticas de segurança rigorosas.