---
title: Converter ODP para PPTX em .NET
linktitle: ODP para PPTX
type: docs
weight: 10
url: /pt/net/convert-odp-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Converta ODP para PPTX com Aspose.Slides para .NET. Exemplos de código C# limpos, dicas para processamento em lote e resultados de alta qualidade — sem necessidade de PowerPoint."
---
## **Visão geral**

Este artigo explica como converter uma apresentação ODP para o formato PPTX usando Aspose.Slides.

## **Conversão de ODP para PPTX**

Aspose.Slides para .NET oferece a classe Presentation que representa um arquivo de apresentação. A classe [**Presentation**](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) agora também pode acessar ODP através do construtor Presentation quando o objeto é instanciado. O exemplo a seguir mostra como converter uma apresentação ODP em uma apresentação PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Etapas: Converter ODP para PPTX em C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Etapas: Converter ODP para PowerPoint em C#</strong></a>

```c#
// Abrir o arquivo ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Salvando a apresentação ODP no formato PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Exemplo ao vivo**

Você pode visitar o aplicativo web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pt/conversion/) que foi construído com a **API Aspose.Slides**. O aplicativo demonstra como a conversão de ODP para PPTX pode ser implementada com a API Aspose.Slides.

## **Perguntas frequentes**

**Preciso instalar o Microsoft PowerPoint ou o LibreOffice para converter ODP para PPTX?**

Não. Aspose.Slides funciona de forma independente e não requer aplicativos de terceiros para ler ou gravar ODP/PPTX.

**Os slides mestres, layouts e temas são preservados durante a conversão?**

Sim. A biblioteca usa um modelo completo de objeto de apresentação e mantém a estrutura, incluindo slides mestres e layouts, de modo que o design permanece correto após a conversão.

**Posso converter arquivos ODP protegidos por senha?**

Sim. Aspose.Slides suporta a detecção de proteção, a abertura e o trabalho com [presentações protegidas](/slides/pt/net/password-protected-presentation/) (incluindo ODP) quando você fornece a senha, além de configurar criptografia e acesso às propriedades do documento.

**O Aspose.Slides é adequado para serviços de conversão em nuvem ou baseados em REST?**

Sim. Você pode usar a biblioteca local em seu próprio back-end ou [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pt/family/) (API REST); ambas as opções suportam a conversão ODP → PPTX.