---
title: Converter PPTX para PPT em JavaScript
linktitle: PPTX para PPT
type: docs
weight: 21
url: /pt/nodejs-java/convert-pptx-to-ppt/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPTX
- PPTX para PPT
- salvar PPTX como PPT
- exportar PPTX para PPT
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Converta PPTX para PPT facilmente com Aspose.Slides—garanta compatibilidade perfeita com os formatos PowerPoint enquanto preserva o layout e a qualidade da sua apresentação."
---
## **Visão geral**

Este artigo explica como converter uma apresentação do PowerPoint no formato PPTX para o formato PPT usando JavaScript. O tópico a seguir é abordado.

- Converter PPTX para PPT em JavaScript

## **Conversão de PPTX para PPT em JavaScript**

Para o código de exemplo em JavaScript que converte PPTX para PPT, veja a seção abaixo, ou seja, [Converter PPTX para PPT](#convert-pptx-to-ppt). Ele apenas carrega o arquivo PPTX e o salva no formato PPT. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPTX em muitos outros formatos, como PDF, XPS, ODP, HTML etc., conforme discutido nestes artigos.

- [Converter PPTX para PDF em JavaScript](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/)
- [Converter PPTX para XPS em JavaScript](/slides/pt/nodejs-java/convert-powerpoint-to-xps/)
- [Converter PPTX para HTML em JavaScript](/slides/pt/nodejs-java/convert-powerpoint-to-html/)
- [Converter PPTX para ODP em JavaScript](/slides/pt/nodejs-java/save-presentation/)
- [Converter PPTX para PNG em JavaScript](/slides/pt/nodejs-java/convert-powerpoint-to-png/)

## **Converter PPTX para PPT**

Para converter um PPTX para PPT, basta passar o nome do arquivo e o formato de salvamento para o método **Save** da classe [**Presentation**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation). O exemplo de código JavaScript abaixo converte uma apresentação de PPTX para PPT usando as opções padrão.

```javascript
// instanciar um objeto Presentation que representa um arquivo PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// salvar a apresentação como PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **FAQ**

**Todos os efeitos e recursos do PPTX são mantidos ao salvar no formato PPT legado (97–2003)?**

Nem sempre. O formato PPT carece de algumas funcionalidades mais recentes (por exemplo, determinados efeitos, objetos e comportamentos), de modo que os recursos podem ser simplificados ou rasterizados durante a conversão.

**Posso converter apenas slides selecionados para PPT em vez de toda a apresentação?**

A gravação direta tem como alvo toda a apresentação. Para converter slides específicos, crie uma nova apresentação contendo apenas esses slides e salve-a como PPT; alternativamente, use um serviço/API que ofereça parâmetros de conversão por slide.

**Apresentações protegidas por senha são suportadas?**

Sim. Você pode detectar se um arquivo está protegido, abri‑lo com uma senha e também [configurar as configurações de proteção/criptografia](/slides/pt/nodejs-java/password-protected-presentation/) para o PPT salvo.