---
title: Limitações da API
type: docs
weight: 320
url: /pt/java/api-limitations/
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
- Java
- Aspose.Slides
description: "Conheça os limites do Aspose.Slides for Java: exportações definem metadados fixos de Application/Producer em PPT, PPTX, ODP e PDF—ajudando você a planejar integrações sem surpresas."
---
## **Visão geral**

Quando apresentações são criadas ou exportadas com Aspose.Slides, certos metadados técnicos são gravados no arquivo de saída. Este artigo explica as limitações relacionadas aos campos de metadados `Application`, `Creator` e `Producer` em arquivos PPTX e PDF.

## **Application e Producer**

Quando você cria ou exporta apresentações com Aspose.Slides for Java, alguns metadados técnicos são gravados no arquivo. Dois campos frequentemente levantam dúvidas:

**Application** identifica o programa que criou ou salvou pela última vez uma apresentação **PPTX**. No Aspose.Slides for Java, esse valor é fixo e mostra o fornecedor da biblioteca em vez do nome da sua aplicação, mesmo que você use [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifica o motor de renderização que gerou o arquivo final durante a exportação. Nas exportações **PDF**, os metadados utilizam os campos **Creator** e **Producer**. Com Aspose.Slides for Java, ambos são fixos e refletem a biblioteca e sua versão.

**O que é restrito**

Você não pode substituir esses campos através da API para os formatos acima. Para **PPTX**, a propriedade Application é gravada como "Aspose.Slides for Java". Para **PDF**, as propriedades Creator e Producer são gravadas como "Aspose.Slides for Java x.x.x." Esse comportamento é intencional e se aplica independentemente de como você carrega ou salva o arquivo, e independentemente dos valores atribuídos usando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).