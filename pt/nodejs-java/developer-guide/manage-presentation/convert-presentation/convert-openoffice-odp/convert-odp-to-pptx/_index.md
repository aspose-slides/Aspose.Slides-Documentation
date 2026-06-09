---
title: Converter ODP para PPTX em JavaScript
linktitle: ODP para PPTX
type: docs
weight: 10
url: /pt/nodejs-java/convert-odp-to-pptx/
keywords:
- converter OpenDocument
- converter apresentação
- converter slide
- converter ODP
- OpenDocument para PPTX
- ODP para PPTX
- salvar ODP como PPTX
- exportar ODP para PPTX
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Converta ODP para PPTX com Aspose.Slides para Node.js. Exemplos de código JavaScript limpos, dicas de lote e resultados de alta qualidade—não é necessário o PowerPoint."
---
## **Visão geral**

Este artigo explica como converter uma apresentação ODP para o formato PPTX usando o Aspose.Slides.

## **Converter ODP para Apresentação PPTX/PPT**
O Aspose.Slides for Node.js via Java oferece a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) que representa um arquivo de apresentação. A classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) agora também pode acessar ODP através do construtor [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) quando o objeto é instanciado. O exemplo a seguir mostra como converter uma apresentação ODP em uma apresentação PPTX.

```javascript
// Abra o arquivo ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Salvar a apresentação ODP no formato PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Exemplo ao Vivo**
Você pode visitar o aplicativo web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pt/conversion/) web app, que foi construído com a **Aspose.Slides API**. O aplicativo demonstra como a conversão de ODP para PPTX pode ser implementada com a Aspose.Slides API.

## **Perguntas frequentes**

**Preciso instalar Microsoft PowerPoint ou LibreOffice para converter ODP para PPTX?**

Não. O Aspose.Slides funciona de forma independente e não requer aplicativos de terceiros para ler ou escrever ODP/PPTX.

**Os slides mestres, layouts e temas são preservados durante a conversão?**

Sim. A biblioteca usa um modelo de objeto de apresentação completo e mantém a estrutura, incluindo slides mestres e layouts, de modo que o design permanece correto após a conversão.

**Posso converter arquivos ODP protegidos por senha?**

Sim. O Aspose.Slides suporta a detecção de proteção, a abertura e o trabalho com [protected presentations](/slides/pt/nodejs-java/password-protected-presentation/) (incluindo ODP) quando você fornece a senha, bem como a configuração de criptografia e acesso às propriedades do documento.

**O Aspose.Slides é adequado para serviços de conversão em nuvem ou baseados em REST?**

Sim. Você pode usar a biblioteca local em seu próprio backend ou [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pt/family/) (REST API); ambas as opções suportam a conversão ODP → PPTX.