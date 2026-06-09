---
title: Limitações da API
type: docs
weight: 320
url: /pt/net/api-limitations/
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
- .NET
- C#
- Aspose.Slides
description: "Conheça os limites do Aspose.Slides for .NET: exportações definem metadados fixos de Application/Producer em PPT, PPTX, ODP e PDF—ajudando você a planejar integrações sem surpresas."
---
## **Visão geral**

Quando apresentações são criadas ou exportadas com Aspose.Slides, certas metadados técnicos são gravados no arquivo de saída. Este artigo explica as limitações relacionadas aos campos de metadados `Application`, `Creator` e `Producer` em arquivos PPTX e PDF.

## **Aplicativo e Produtor**

Quando você cria ou exporta apresentações com Aspose.Slides for .NET, alguns metadados técnicos são gravados no arquivo. Dois campos costumam gerar dúvidas:

**Application** identifica o programa que criou ou salvou pela última vez uma apresentação **PPTX**. No Aspose.Slides for .NET, esse valor é fixo e mostra o fornecedor da biblioteca em vez do nome do seu aplicativo, mesmo que você defina [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pt/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifica o mecanismo de renderização que gerou o arquivo final durante a exportação. Nas exportações **PDF**, os metadados utilizam os campos **Creator** e **Producer**. Com Aspose.Slides for .NET, ambos são fixos e refletem a biblioteca e sua versão.

**O que é restrito**

Você não pode substituir esses campos através da API para os formatos acima. Para **PPTX**, a propriedade Application é gravada como "Aspose.Slides for .NET". Para **PDF**, as propriedades Creator e Producer são gravadas como "Aspose.Slides for .NET x.x.x". Esse comportamento é intencional e se aplica independentemente de como o arquivo é carregado ou salvo, e independentemente dos valores atribuídos a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pt/net/aspose.slides/documentproperties/nameofapplication/).