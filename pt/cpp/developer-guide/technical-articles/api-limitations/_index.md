---
title: Limitações da API
type: docs
weight: 320
url: /pt/cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "Conheça os limites do Aspose.Slides for C++: exportações definem metadados fixos de Application/Producer em PPT, PPTX, ODP e PDF—ajudando você a planejar integrações sem surpresas."
---
## **Visão geral**

Quando as apresentações são criadas ou exportadas com Aspose.Slides, certos metadados técnicos são gravados no arquivo de saída. Este artigo explica as limitações relacionadas aos campos de metadados `Application`, `Creator` e `Producer` em arquivos PPTX e PDF.

## **Aplicativo e Produtor**

Ao criar ou exportar apresentações com Aspose.Slides for C++, alguns metadados técnicos são gravados no arquivo. Dois campos frequentemente suscitam dúvidas:

**Application** identifica o programa que criou ou salvou pela última vez uma apresentação **PPTX**. No Aspose.Slides for C++, esse valor é fixo e exibe o fornecedor da biblioteca em vez do nome do seu aplicativo, mesmo que você use [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/pt/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** identifica o mecanismo de renderização que gerou o arquivo final durante a exportação. Nas exportações **PDF**, os metadados usam os campos **Creator** e **Producer**. No Aspose.Slides for C++, ambos são fixos e refletem a biblioteca e sua versão.

**O que é restrito**

Você não pode sobrescrever esses campos através da API para os formatos acima. Para **PPTX**, a propriedade Application é gravada como "Aspose.Slides for C++". Para **PDF**, as propriedades Creator e Producer são gravadas como "Aspose.Slides for C++ x.x.x". Esse comportamento é intencional e se aplica independentemente de como você carrega ou salva o arquivo, e independentemente dos valores atribuídos usando [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/pt/cpp/aspose.slides/documentproperties/set_nameofapplication/).