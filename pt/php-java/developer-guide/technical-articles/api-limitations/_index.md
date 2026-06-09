---
title: Limitações da API
type: docs
weight: 320
url: /pt/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Conheça os limites do Aspose.Slides para PHP: exportações definem metadados fixos de Aplicação/Produtor em PPT, PPTX, ODP e PDF—ajudando você a planejar integrações sem surpresas."
---
## **Visão geral**

Quando apresentações são criadas ou exportadas com Aspose.Slides, certos metadados técnicos são gravados no arquivo de saída. Este artigo explica as limitações relacionadas aos campos de metadados `Application`, `Creator` e `Producer` em arquivos PPTX e PDF.

## **Aplicação e Produtor**

Ao criar ou exportar apresentações com Aspose.Slides for PHP via Java, alguns metadados técnicos são gravados no arquivo. Dois campos costumam gerar dúvidas:

**Application** identifica o programa que criou ou salvou pela última vez uma apresentação **PPTX**. No Aspose.Slides for PHP via Java, esse valor é fixo e mostra o fornecedor da biblioteca em vez do nome do seu aplicativo, mesmo que você use [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** identifica o motor de renderização que gerou o arquivo final durante a exportação. Nas exportações **PDF**, os metadados usam os campos **Creator** e **Producer**. Com o Aspose.Slides for PHP via Java, ambos são fixos e refletem a biblioteca e sua versão.

**O que é restrito**

Você não pode sobrescrever esses campos através da API para os formatos acima. Para **PPTX**, a propriedade Application é gravada como "Aspose.Slides for PHP via Java". Para **PDF**, as propriedades Creator e Producer são gravadas como "Aspose.Slides for PHP via Java x.x.x." Esse comportamento é intencional e se aplica independentemente de como você carrega ou salva o arquivo, e independentemente dos valores atribuídos usando [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/pt/php-java/aspose.slides/documentproperties/setnameofapplication/).