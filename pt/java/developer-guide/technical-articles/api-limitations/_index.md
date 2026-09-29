---
title: Limitações de Metadados de Saída
type: docs
weight: 320
url: /pt/java/api-limitations/
keywords:
- limitações da API
- formato de exportação
- aplicação
- produtor
- propriedades do documento
- metadados
- gerador
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Aspose.Slides for Java grava metadados fixos de aplicação, criador e produtor em arquivos PPTX, PDF e ODP salvos, independentemente do nome da aplicação que você definir."
---
## **Visão geral**

Quando apresentações são criadas ou exportadas com Aspose.Slides, certos metadados técnicos são gravados no arquivo de saída. Este artigo explica as limitações relacionadas aos campos de metadados `Application`, `Creator`, `Producer` e generator em arquivos PPTX, PDF e ODP.

## **Aplicação e Produtor**

Ao criar ou exportar apresentações com Aspose.Slides for Java, alguns metadados técnicos são gravados no arquivo. Dois campos frequentemente levantam dúvidas:

**Application** identifica o programa que criou ou salvou pela última vez uma apresentação **PPTX**. No Aspose.Slides for Java, esse valor é fixo e exibe o nome da biblioteca em vez do nome do seu aplicativo, mesmo se você usar [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** identifica o motor de renderização que gerou o arquivo final durante a exportação. Em exportações **PDF**, os metadados utilizam os campos **Creator** e **Producer**. No Aspose.Slides for Java, ambos são fixos e refletem a biblioteca e sua versão.

**O que é restrito**

Você não pode sobrescrever esses campos através da API para os formatos acima. Para **PPTX**, a propriedade Application é gravada como "Aspose.Slides for Java". Para **PDF**, as propriedades Creator e Producer são gravadas como "Aspose.Slides for Java" seguidas da versão da biblioteca. Para **ODP**, o campo generator é gravado como "Aspose.Slides for Java" seguido da versão da biblioteca. Esse comportamento foi projetado dessa forma e se aplica independentemente de como você carrega ou salva o arquivo, e independentemente dos valores atribuídos usando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Essa restrição não se aplica a arquivos **PPT**: em um arquivo PPT, o nome do aplicativo que você definiu com [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) é salvo.