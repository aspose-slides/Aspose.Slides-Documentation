---
title: Limitações de Metadados de Saída
type: docs
weight: 320
url: /pt/net/api-limitations/
keywords:
- Limitações de API
- formato de exportação
- aplicação
- produtor
- propriedades de documento
- metadados
- gerador
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET grava metadados fixos de aplicação, criador e produtor em arquivos PPTX, PDF e ODP salvos, independentemente do nome da aplicação que você definir."
---
## **Visão geral**

Quando apresentações são criadas ou exportadas com Aspose.Slides, certos metadados técnicos são gravados no arquivo de saída. Este artigo explica as limitações relacionadas aos campos de metadados `Application`, `Creator`, `Producer` e generator em arquivos PPTX, PDF e ODP.

## **Aplicação e Produtor**

Ao criar ou exportar apresentações com Aspose.Slides for .NET, alguns metadados técnicos são gravados no arquivo. Dois campos frequentemente geram dúvidas:

**Application** identifica o programa que criou ou salvou pela última vez uma apresentação **PPTX**. No Aspose.Slides for .NET, esse valor é fixo e mostra o nome da biblioteca em vez do nome do seu aplicativo, mesmo que você defina [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pt/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifica o mecanismo de renderização que gerou o arquivo final durante a exportação. Nas exportações **PDF**, os metadados utilizam os campos **Creator** e **Producer**. Com Aspose.Slides for .NET, ambos são fixos e refletem a biblioteca e sua versão.

**O que é restrito**

Você não pode sobrescrever esses campos via API nos formatos acima. Para **PPTX**, a propriedade Application é gravada como "Aspose.Slides for .NET". Para **PDF**, as propriedades Creator e Producer são gravadas como "Aspose.Slides for .NET" seguidas da versão da biblioteca. Para **ODP**, o campo generator é gravado como "Aspose.Slides for .NET" seguido da versão da biblioteca. Esse comportamento é intencional e se aplica independentemente de como o arquivo é carregado ou salvo, e independentemente dos valores atribuídos a [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pt/net/aspose.slides/documentproperties/nameofapplication/).

Essa restrição não se aplica a arquivos **PPT**: em um arquivo PPT, o nome do aplicativo que você definiu em [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/pt/net/aspose.slides/documentproperties/nameofapplication/) é salvo.