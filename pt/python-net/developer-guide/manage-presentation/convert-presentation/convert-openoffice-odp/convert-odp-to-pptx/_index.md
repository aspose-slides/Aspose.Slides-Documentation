---
title: Converter ODP para PPTX em Python
linktitle: ODP para PPTX
type: docs
weight: 10
url: /pt/python-net/convert-odp-to-pptx/
keywords:
- converter OpenDocument
- converter ODP
- OpenDocument para PPTX
- ODP para PPTX
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Converter ODP para PPTX com Aspose.Slides para Python via .NET. Exemplos de código limpos, dicas de lote e resultados de alta qualidade - sem necessidade de PowerPoint."
---
## **Visão geral**

Este artigo explica como converter uma apresentação ODP para o formato PPTX usando o Aspose.Slides.

## **Exportar ODP para PPTX**

O Aspose.Slides for Python via .NET oferece a classe Presentation que representa um arquivo de apresentação. A classe [**Presentation**](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) agora também pode acessar ODP através do construtor Presentation quando o objeto é instanciado. O exemplo a seguir mostra como converter uma apresentação ODP em uma apresentação PPTX.

```py
# Importar o módulo Aspose.Slides para Python via .NET
import aspose.slides as slides

# Abrir o arquivo ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Salvar a apresentação ODP no formato PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Exemplo ao vivo**

Você pode acessar o aplicativo web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pt/conversion/) que foi desenvolvido com a **Aspose.Slides API**. O aplicativo demonstra como a conversão de ODP para PPTX pode ser implementada com a Aspose.Slides API.

## **FAQ**

**Preciso instalar o Microsoft PowerPoint ou o LibreOffice para converter ODP para PPTX?**

Não. O Aspose.Slides funciona de forma independente e não requer aplicativos de terceiros para ler ou gravar ODP/PPTX.

**Slides mestres, layouts e temas são preservados durante a conversão?**

Sim. A biblioteca usa um modelo completo de objetos de apresentação e mantém a estrutura, incluindo slides mestres e layouts, de modo que o design permanece correto após a conversão.

**Posso converter arquivos ODP protegidos por senha?**

Sim. O Aspose.Slides suporta a detecção de proteção, a abertura e o trabalho com [protected presentations](/slides/pt/python-net/password-protected-presentation/) (incluindo ODP) quando você fornece a senha, bem como a configuração de criptografia e o acesso às propriedades do documento.

**O Aspose.Slides é adequado para serviços de conversão em nuvem ou baseados em REST?**

Sim. Você pode usar a biblioteca local em seu próprio backend ou o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pt/family/) (REST API); ambas as opções suportam a conversão ODP → PPTX.