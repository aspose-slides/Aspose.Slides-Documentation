---
title: Converter PowerPoint para PDF no Node.js via .NET
linktitle: PowerPoint para PDF
type: docs
weight: 30
url: /pt/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint para PDF
- converter PowerPoint para PDF
- PPTX para PDF
- PPT para PDF
- ODP para PDF
- salvar apresentação como PDF
- PDF/A
- PdfOptions
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter apresentações PPTX, PPT e ODP para PDF em JavaScript com Aspose.Slides for Node.js via .NET, e gerar arquivos PDF/A de arquivamento com PdfOptions."
---
## **Visão geral**

Aspose.Slides for Node.js via .NET converte apresentações PowerPoint e OpenDocument para PDF sem o Microsoft PowerPoint. Cada slide visível se torna uma página PDF do mesmo tamanho do slide, e o texto permanece selecionável e pesquisável. Este artigo mostra a conversão padrão e uma conversão para PDF/A com [PdfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/).

Os exemplos esperam uma apresentação chamada `sample.pptx` na pasta do projeto que você configurou em [Installation](/slides/pt/nodejs-net/installation/). Qualquer apresentação PowerPoint serve. Salve cada exemplo como um arquivo `.js` na pasta do projeto e execute‑o a partir dessa pasta com `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET não tem sua própria referência de API. Ele espelha a API Aspose.Slides for .NET com nomes camelCase, de modo que os links de API neste artigo apontam para as classes e membros correspondentes na [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/pt/net/).
{{% /alert %}}

## **Converter uma Apresentação para PDF**

Para converter uma apresentação para PDF, siga estas etapas:

1. Abra a apresentação passando seu caminho para o construtor [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/presentation/). O mesmo código funciona para arquivos PPTX, PPT e ODP.  
2. Chame o método [save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) com o caminho de saída e `SaveFormat.Pdf`.  
3. Chame `dispose` em um bloco `finally` para liberar os recursos .NET que suportam a apresentação.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

O script grava `sample.pdf` na pasta do projeto. A conversão usa as configurações padrão: cada slide que não está oculto se torna uma página, na ordem dos slides. Sem uma licença, cada página também exibe uma marca d'água de avaliação; veja [Licensing](/slides/pt/nodejs-net/licensing/).

## **Converter uma Apresentação para PDF/A**

Para controlar a saída, passe um objeto [PdfOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/) como terceiro argumento de `save`. O exemplo a seguir define a propriedade [compliance](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/compliance/) para `PdfCompliance.PdfA2b`, que produz um arquivo PDF/A-2b. PDF/A é o padrão ISO para arquivamento de longo prazo: entre outras regras, ele exige que toda fonte usada pelo documento seja incorporada ao arquivo.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

O script grava `sample-pdfa.pdf` com as mesmas páginas da conversão padrão. Para confirmar que um arquivo atende ao padrão, verifique‑o com um validador PDF/A como o [veraPDF](https://verapdf.org/). Outros valores de [PdfCompliance](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfcompliance/) selecionam outros padrões, como `PdfA1b`, `PdfA2a` ou `PdfUa` para acessibilidade.

## **Perguntas Frequentes**

**Como incluir slides ocultos no PDF?**

Slides ocultos são ignorados por padrão. Defina a propriedade [showHiddenSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/showhiddenslides/) de `PdfOptions` como `true` e passe as opções para `save`.

**Posso proteger o PDF com senha?**

Sim. Defina a propriedade [password](https://reference.aspose.com/slides/pt/net/aspose.slides.export/pdfoptions/password/) de `PdfOptions` antes de chamar `save`. Os leitores de PDF então solicitarão essa senha antes de abrir o arquivo.

**Posso converter apenas alguns slides?**

Sim. Passe um array de posições de slides como quarto argumento de `save`. As posições começam em 1, e o terceiro argumento pode ser `null` se você não precisar de opções: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` gera um PDF com o primeiro e o terceiro slides.

**Por que o texto aparece diferente quando converto no Linux?**

Aspose.Slides só pode usar fontes que estejam instaladas na máquina que executa a conversão. Quando uma apresentação usa uma fonte ausente, como Calibri em um servidor Linux típico, Aspose.Slides utiliza uma fonte instalada em seu lugar, o que pode alterar a aparência do texto e onde as linhas são quebradas. Instale as fontes que suas apresentações utilizam para obter o mesmo resultado que no Windows.

**Posso obter o PDF como Buffer em vez de arquivo?**

Sim. `presentation.saveToBuffer(SaveFormat.Pdf)` devolve o PDF como um `Buffer` do Node.js, o que é conveniente quando você envia o resultado em uma resposta HTTP. Ele também aceita `PdfOptions` como segundo argumento.