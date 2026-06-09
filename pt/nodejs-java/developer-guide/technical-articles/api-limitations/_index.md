---
title: Limitações da API
type: docs
weight: 320
url: /pt/nodejs-java/api-limitations/
keywords:
- Limitações da API
- formato de exportação
- aplicação
- produtor
- propriedades do documento
- metadados
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Conheça os limites do Aspose.Slides for Node.js: exportações definem metadados fixos de Application/Producer em PPT, PPTX, ODP e PDF—ajudando você a planejar integrações sem surpresas."
---
## **Visão geral**

Quando as apresentações são criadas ou exportadas com Aspose.Slides, certos metadados técnicos são gravados no arquivo de saída. Este artigo explica as limitações relacionadas aos campos de metadados `Application`, `Creator` e `Producer` em arquivos PPTX e PDF.

## **Aplicação e Produtor**

Ao criar ou exportar apresentações com Aspose.Slides for Node.js via Java, alguns metadados técnicos são gravados no arquivo. Dois campos frequentemente geram dúvidas:

**Application** identifica o programa que criou ou salvou pela última vez uma apresentação **PPTX**. No Aspose.Slides for Node.js via Java, esse valor é fixo e mostra o fornecedor da biblioteca em vez do nome do seu aplicativo, mesmo se você usar [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifica o mecanismo de renderização que gerou o arquivo final durante a exportação. Nas exportações **PDF**, os metadados utilizam os campos **Creator** e **Producer**. No Aspose.Slides for Node.js via Java, ambos são fixos e refletem a biblioteca e sua versão.

**O que é restrito**

Você não pode sobrescrever esses campos através da API nos formatos acima. Para **PPTX**, a propriedade Application é gravada como "Aspose.Slides for Node.js via Java". Para **PDF**, as propriedades Creator e Producer são gravadas como "Aspose.Slides for Node.js via Java x.x.x.". Esse comportamento é deliberado e se aplica independentemente de como o arquivo é carregado ou salvo, e independentemente dos valores atribuídos usando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/documentproperties/setnameofapplication/).