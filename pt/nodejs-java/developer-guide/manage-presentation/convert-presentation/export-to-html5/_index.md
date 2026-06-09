---
title: Converter apresentações para HTML5 em JavaScript
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
description: "Exportar apresentações PowerPoint e OpenDocument para HTML5 responsivo com Aspose.Slides para Node.js. Preserve formatação, animações e interatividade."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint para HTML5 usando o Aspose.Slides. Ele aborda a exportação básica para HTML5 sem extensões web ou dependências adicionais, bem como opções para controlar animações de formas e transições de slides. O artigo também mostra o processo padrão de exportação de PowerPoint para HTML, explica como gerar a saída HTML5 no modo de visualização de slides e demonstra como incluir comentários no documento exportado configurando seu layout.

## **Exportar PowerPoint para HTML5**

Este código JavaScript mostra como exportar uma apresentação para HTML5 sem extensões web e dependências:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Neste caso, você obtém HTML limpo. 
{{% /alert %}}

Você pode querer especificar configurações para animações de formas e transições de slides desta maneira:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Exportar PowerPoint para HTML**

Este JavaScript demonstra o processo padrão de exportação de PowerPoint para HTML:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Nesse caso, o conteúdo da apresentação é renderizado através de SVG em um formato como este:

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
Ao usar este método para exportar PowerPoint para HTML, devido à renderização em SVG, você não poderá aplicar estilos ou animar elementos específicos. 
{{% /alert %}}

## **Exportar PowerPoint para Visualização de Slides em HTML5**

**Aspose.Slides** permite converter uma apresentação do PowerPoint em um documento HTML5 no qual os slides são apresentados em modo de visualização de slides. Nesse caso, ao abrir o arquivo HTML5 resultante em um navegador, você vê a apresentação em modo de visualização de slides em uma página web. 

Este código JavaScript demonstra o processo de exportação de PowerPoint para Visualização de Slides em HTML5:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Converter uma Apresentação em um Documento HTML5 com Comentários**

Os comentários no PowerPoint são uma ferramenta que permite aos usuários deixar notas ou feedback nos slides da apresentação. Eles são especialmente úteis em projetos colaborativos, onde várias pessoas podem adicionar suas sugestões ou observações a elementos específicos dos slides sem alterar o conteúdo principal. Cada comentário mostra o nome do autor, facilitando rastrear quem deixou a observação.

Suponha que temos a seguinte apresentação do PowerPoint salva no arquivo "sample.pptx".

![Dois comentários no slide da apresentação](two_comments_pptx.png)

Ao converter uma apresentação do PowerPoint em um documento HTML5, você pode especificar facilmente se inclui comentários da apresentação no documento de saída. Para isso, é necessário especificar os parâmetros de exibição dos comentários na propriedade `notes_comments_layouting` da classe [Html5Options](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/html5options/).

O exemplo de código a seguir converte uma apresentação em um documento HTML5 com comentários exibidos à direita dos slides.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

O documento "output.html" é mostrado na imagem abaixo.

![Os comentários no documento HTML5 de saída](two_comments_html5.png)

## **Perguntas frequentes**

**Posso controlar se as animações de objetos e as transições de slides serão reproduzidas em HTML5?**

Sim, o HTML5 oferece opções separadas para habilitar ou desabilitar [animações de formas](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/html5options/setanimateshapes/) e [transições de slides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**A saída de comentários é suportada, e onde eles podem ser posicionados em relação ao slide?**

Sim, os comentários podem ser adicionados em HTML5 e posicionados (por exemplo, à direita do slide) por meio das [configurações de layout](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) para notas e comentários.

**Posso ignorar links que invocam JavaScript por motivos de segurança ou CSP?**

Sim, existe uma [configuração](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) que permite ignorar hiperlinks com chamadas JavaScript durante a gravação. Isso ajuda a cumprir políticas de segurança rigorosas.