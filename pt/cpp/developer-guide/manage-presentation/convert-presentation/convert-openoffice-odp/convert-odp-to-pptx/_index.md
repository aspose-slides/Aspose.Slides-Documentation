---
title: Converter ODP para PPTX em C++
linktitle: ODP para PPTX
type: docs
weight: 10
url: /pt/cpp/convert-odp-to-pptx/
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
- C++
- Aspose.Slides
description: "Converta ODP para PPTX com Aspose.Slides para C++. Exemplos de código limpo, dicas em lote e resultados de alta qualidade — sem necessidade de PowerPoint."
---
## **Visão geral**

Este artigo explica como converter uma apresentação ODP para o formato PPTX usando o Aspose.Slides.

## **Conversão de ODP para PPTX**

Aspose.Slides para .NET oferece a classe Presentation que representa um arquivo de apresentação. [**Presentation**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) agora também pode acessar ODP através do construtor Presentation quando o objeto é instanciado. O exemplo a seguir mostra como converter uma apresentação ODP em uma apresentação PPTX.

``` cpp
// O caminho para o diretório de documentos.
String dataDir = GetDataPath();

// Abrir o arquivo ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Salvando a apresentação ODP no formato PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Exemplo ao vivo**

Você pode visitar o aplicativo web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pt/conversion/) que foi desenvolvido com a **Aspose.Slides API**. O aplicativo demonstra como a conversão de ODP para PPTX pode ser implementada com a Aspose.Slides API.

## **Perguntas frequentes**

**Preciso instalar o Microsoft PowerPoint ou o LibreOffice para converter ODP para PPTX?**

Não. Aspose.Slides funciona de forma independente e não requer aplicativos de terceiros para ler ou gravar ODP/PPTX.

**Os slides mestres, layouts e temas são preservados durante a conversão?**

Sim. A biblioteca usa um modelo de objeto de apresentação completo e mantém a estrutura, incluindo slides mestres e layouts, de modo que o design permanece correto após a conversão.

**Posso converter arquivos ODP protegidos por senha?**

Sim. Aspose.Slides oferece suporte à detecção de proteção, à abertura e ao trabalho com [protected presentations](/slides/pt/cpp/password-protected-presentation/) (incluindo ODP) quando você fornece a senha, além de permitir a configuração de criptografia e acesso às propriedades do documento.

**O Aspose.Slides é adequado para serviços de conversão em nuvem ou baseados em REST?**

Sim. Você pode usar a biblioteca local em seu próprio back-end ou [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pt/family/) (REST API); ambas as opções suportam a conversão de ODP → PPTX.