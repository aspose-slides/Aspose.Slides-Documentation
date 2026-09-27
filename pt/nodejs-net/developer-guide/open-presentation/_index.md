---
title: Abrir Apresentações em Node.js via .NET
linktitle: Abrir Apresentação
type: docs
weight: 20
url: /pt/nodejs-net/open-presentation/
keywords:
- abrir apresentação
- abrir PowerPoint
- abrir PPTX
- abrir PPT
- abrir ODP
- carregar apresentação
- apresentação a partir de buffer
- contagem de slides
- converter apresentação
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Abra apresentações PPTX, PPT e ODP em JavaScript com Aspose.Slides for Node.js via .NET: carregue a partir de um caminho de arquivo ou de um Buffer, leia a contagem de slides e salve em outro formato."
---
## **Visão geral**

Aspose.Slides for Node.js via .NET abre apresentações PowerPoint e OpenDocument, como arquivos PPTX, PPT e ODP, a partir de um caminho de arquivo ou de um `Buffer` do Node.js. Este artigo mostra ambas as maneiras, lê o número de slides e salva uma apresentação aberta em outro formato.

Os exemplos esperam uma apresentação chamada `sample.pptx` na pasta do projeto que você configurou em [Instalação](/slides/pt/nodejs-net/installation/). Qualquer apresentação PowerPoint serve. Salve cada exemplo como um arquivo `.js` na pasta do projeto e execute‑o a partir dessa pasta com `node`.

{{% alert color="info" title="Nota" %}}
Aspose.Slides for Node.js via .NET não possui sua própria referência de API. Ela espelha a API do Aspose.Slides for .NET com nomes camelCase, portanto os links de API neste artigo levam às classes e membros correspondentes na [referência da API do Aspose.Slides for .NET](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Abrir uma Apresentação a partir de um Arquivo**

Para abrir uma apresentação, passe seu caminho ao construtor [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Aspose.Slides detecta o formato a partir do conteúdo do arquivo em vez da extensão, portanto o mesmo código abre arquivos PPTX, PPT e ODP. Um caminho relativo é resolvido em relação ao diretório de trabalho atual, que é a pasta do projeto quando você executa o script a partir dela.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

O script imprime o número de slides em `sample.pptx`, por exemplo `Slide count: 9`. A propriedade `count` da coleção de [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) inclui slides ocultos. Chame `dispose` em um bloco `finally`, como mostrado, para que os recursos .NET por trás da apresentação sejam liberados mesmo que seu código falhe.

## **Abrir uma Apresentação a partir de um Buffer**

Quando uma apresentação vem de um banco de dados, de um upload HTTP ou de outra fonte que fornece bytes em vez de um caminho de arquivo, passe um `Buffer` do Node.js como segundo argumento do construtor e `null` como o primeiro. O exemplo a seguir lê `sample.pptx` para um buffer simulando tal fonte:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

O script imprime a mesma contagem de slides do exemplo anterior. O segundo argumento deve ser um `Buffer`. Para qualquer outro tipo, como um `Uint8Array`, o construtor não relata erro; ele cria uma nova apresentação com um slide vazio. Converta outros tipos binários primeiro com `Buffer.from`.

## **Salvar uma Apresentação em Outro Formato**

Para converter uma apresentação para outro formato de apresentação, abra‑a e salve‑a com um valor diferente de [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). O exemplo a seguir imprime o formato que o Aspose.Slides detectou, que a propriedade [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) retorna, e salva a apresentação como uma apresentação OpenDocument:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

O script imprime `Source format: Pptx` e grava `sample.odp`, que contém os mesmos slides. `sourceFormat` retorna `Ppt`, `Pptx` ou `Odp`. Para salvar como PDF ou como imagens, consulte [Converter PowerPoint para PDF](/slides/pt/nodejs-net/convert-powerpoint-to-pdf/) e [Converter Slides para Imagens](/slides/pt/nodejs-net/convert-slide/).

## **FAQ**

**Como abrir uma apresentação protegida por senha?**

Crie um objeto [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), defina sua propriedade [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) e passe o objeto como terceiro argumento do construtor: `new Presentation("protected.pptx", null, loadOptions)`. Sem a senha correta, o construtor lança um erro.

**Por que o construtor lança um `Error` com mensagem vazia?**

Quando o construtor `Presentation` falha no .NET, por exemplo porque o arquivo está ausente, não é uma apresentação ou requer uma senha diferente, o JavaScript recebe um `Error` cuja mensagem está vazia. Antes de abrir um arquivo, verifique se ele existe em relação ao diretório de trabalho, por exemplo com `fs.existsSync`.

**Quais formatos posso abrir?**

Formatos de apresentação PowerPoint e OpenDocument, incluindo PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP e FODP.