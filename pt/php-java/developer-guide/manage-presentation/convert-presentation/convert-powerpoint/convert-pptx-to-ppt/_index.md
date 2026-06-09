---
title: Converter PPTX para PPT em PHP
linktitle: PPTX para PPT
type: docs
weight: 21
url: /pt/php-java/convert-pptx-to-ppt/
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
- PHP
- Aspose.Slides
description: "Converta PPTX para PPT facilmente com Aspose.Slides — garanta compatibilidade perfeita com os formatos do PowerPoint enquanto preserva o layout e a qualidade da sua apresentação."
---
## **Visão Geral**

Este artigo explica como converter apresentações do PowerPoint no formato PPTX para o formato PPT usando PHP. O tópico a seguir é abordado.

- Converter PPTX para PPT

## **Converter PPTX para PPT em PHP**

Para ver um exemplo de código Java para converter PPTX para PPT, consulte a seção abaixo, ou seja, [Convert PPTX to PPT](#convert-pptx-to-ppt). Ele apenas carrega o arquivo PPTX e o salva no formato PPT. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPTX em vários outros formatos, como PDF, XPS, ODP, HTML etc., conforme discutido nestes artigos. 

- [Converter PPTX para PDF em PHP](/slides/pt/php-java/convert-powerpoint-to-pdf/)
- [Converter PPTX para XPS em PHP](/slides/pt/php-java/convert-powerpoint-to-xps/)
- [Converter PPTX para HTML em PHP](/slides/pt/php-java/convert-powerpoint-to-html/)
- [Converter PPTX para ODP em PHP](/slides/pt/php-java/save-presentation/)
- [Converter PPTX para PNG em PHP](/slides/pt/php-java/convert-powerpoint-to-png/)

## **Converter PPTX para PPT**
Para converter um PPTX para PPT, basta passar o nome do arquivo e o formato de salvamento ao método **Save** da classe [**Presentation**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation). O exemplo de código PHP abaixo converte uma Presentation de PPTX para PPT usando as opções padrão.

```php
  # instanciar um objeto Presentation que representa um arquivo PPTX
  $presentation = new Presentation("template.pptx");
  # salvar a apresentação como PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **FAQ**

**Todos os efeitos e recursos do PPTX são preservados ao salvar no formato PPT legado (97–2003)?**

Nem sempre. O formato PPT carece de alguns recursos mais recentes (por exemplo, certos efeitos, objetos e comportamentos), portanto, os recursos podem ser simplificados ou rasterizados durante a conversão.

**Posso converter apenas slides selecionados para PPT em vez da apresentação inteira?**

A gravação direta tem como alvo toda a apresentação. Para converter slides específicos, crie uma nova apresentação contendo apenas esses slides e salve‑a como PPT; alternativamente, use um serviço/API que ofereça parâmetros de conversão por slide.

**Apresentações protegidas por senha são suportadas?**

Sim. Você pode detectar se um arquivo está protegido, abri‑lo com uma senha e também [configurar as configurações de proteção/criptografia](/slides/pt/php-java/password-protected-presentation/) para o PPT salvo.