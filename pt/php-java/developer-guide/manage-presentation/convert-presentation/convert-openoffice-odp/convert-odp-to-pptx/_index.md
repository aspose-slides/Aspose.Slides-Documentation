---
title: Converter ODP para PPTX em PHP
linktitle: ODP para PPTX
type: docs
weight: 10
url: /pt/php-java/convert-odp-to-pptx/
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
- PHP
- Aspose.Slides
description: "Converter ODP para PPTX com Aspose.Slides para PHP via Java. Exemplos de código limpos, dicas de lote e resultados de alta qualidade—sem necessidade de PowerPoint."
---
## **Visão geral**

Este artigo explica como converter uma apresentação ODP para o formato PPTX usando Aspose.Slides.

## **Converter ODP para Apresentação PPTX/PPT**
Aspose.Slides para PHP via Java oferece a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) que representa um arquivo de apresentação. A classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) agora também pode acessar ODP através do construtor [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) quando o objeto é instanciado. O exemplo a seguir mostra como converter uma Apresentação ODP em uma Apresentação PPTX.

```php
// Abra o arquivo ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Salvando a apresentação ODP no formato PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Exemplo ao vivo**
Você pode visitar o aplicativo web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pt/conversion/) que foi desenvolvido com a **Aspose.Slides API.** O aplicativo demonstra como a conversão de ODP para PPTX pode ser implementada com a Aspose.Slides API.

## **FAQ**

**Preciso instalar Microsoft PowerPoint ou LibreOffice para converter ODP para PPTX?**

Não. Aspose.Slides funciona de forma independente e não requer aplicativos de terceiros para ler ou gravar ODP/PPTX.

**Os slides mestres, layouts e temas são preservados durante a conversão?**

Sim. A biblioteca usa um modelo completo de objeto de apresentação e mantém a estrutura, incluindo slides mestres e layouts, de modo que o design permanece correto após a conversão.

**Posso converter arquivos ODP protegidos por senha?**

Sim. Aspose.Slides suporta a detecção de proteção, a abertura e o trabalho com [apresentações protegidas](/slides/pt/php-java/password-protected-presentation/) (incluindo ODP) quando você fornece a senha, além de configurar criptografia e acesso às propriedades do documento.

**Aspose.Slides é adequado para serviços de conversão em nuvem ou baseados em REST?**

Sim. Você pode usar a biblioteca local em seu próprio back-end ou o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pt/family/) (REST API); ambas as opções suportam a conversão ODP → PPTX.