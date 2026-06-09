---
title: Limitações da API
type: docs
weight: 210
url: /pt/python-net/api-limitations/
keywords:
- Limitações da API
- formato de exportação
- aplicativo
- produtor
- propriedades do documento
- metadados
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Conheça as limitações do Aspose.Slides for Python: as exportações definem metadados fixos de Application/Producer em PPT, PPTX, ODP e PDF—ajudando você a planejar integrações sem surpresas."
---
## **Visão geral**

Quando apresentações são criadas ou exportadas com Aspose.Slides, determinados metadados técnicos são gravados no arquivo de saída. Este artigo explica as limitações relacionadas aos campos de metadados `Application`, `Creator` e `Producer` em arquivos PPTX e PDF.

## **Aplicativo e Produtor**

Quando você cria ou exporta apresentações com Aspose.Slides for Python via .NET, alguns metadados técnicos são gravados no arquivo. Dois campos frequentemente levantam dúvidas:

**Application** identifica o programa que criou ou salvou pela última vez uma apresentação **PPTX**. No Aspose.Slides for Python via .NET, esse valor é fixo e mostra o fornecedor da biblioteca em vez do nome da sua aplicação, mesmo se você definir [DocumentProperties.name_of_application](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** identifica o mecanismo de renderização que gerou o arquivo final durante a exportação. Em exportações **PDF**, os metadados utilizam os campos **Creator** e **Producer**. Com Aspose.Slides for Python via .NET, ambos são fixos e refletem a biblioteca e sua versão.

**O que está restrito**

Você não pode sobrescrever esses campos através da API para os formatos acima. Para **PPTX**, a propriedade Application é gravada como "Aspose.Slides for Python via .NET". Para **PDF**, as propriedades Creator e Producer são gravadas como "Aspose.Slides for Python via .NET x.x.x". Esse comportamento é intencional e se aplica independentemente de como o arquivo é carregado ou salvo, e independentemente dos valores atribuídos a [DocumentProperties.name_of_application](https://reference.aspose.com/slides/pt/python-net/aspose.slides/documentproperties/name_of_application/).