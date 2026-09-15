---
title: Limitações da API
type: docs
weight: 320
url: /pt/python-java/api-limitations/
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
- Java
- Aspose.Slides
description: "Aprenda sobre as limitações do Aspose.Slides for Python via Java: metadados Application, Creator e Producer fixos em arquivos PPTX e PDF."
---
## **Visão geral**

Ao criar ou exportar apresentações com Aspose.Slides para Python via Java, certos metadados técnicos são gravados no arquivo de saída. Este artigo explica as limitações relacionadas aos campos de metadados `Application`, `Creator` e `Producer` em arquivos PPTX e PDF.

## **Aplicativo e Produtor**

Ao criar ou exportar apresentações com Aspose.Slides para Python via Java, alguns metadados técnicos são gravados no arquivo. Dois campos costumam gerar dúvidas:

**Application** identifica o programa que criou ou salvou pela última vez uma apresentação **PPTX**. No Aspose.Slides para Python via Java, esse valor é fixo e mostra o fornecedor da biblioteca em vez do nome da sua aplicação, mesmo que você use [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** identifica o mecanismo de renderização que gerou o arquivo final durante a exportação. Nas exportações **PDF**, os metadados utilizam os campos **Creator** e **Producer**. Com Aspose.Slides para Python via Java, ambos são fixos e refletem a biblioteca e sua versão.

**O que é restrito**

Não é possível sobrescrever esses campos via API para os formatos acima. Para **PPTX**, a propriedade Application é gravada como “Aspose.Slides for Java”. Para **PDF**, as propriedades Creator e Producer são gravadas como “Aspose.Slides for Java x.x.x.” Esse comportamento é intencional e se aplica independentemente de como o arquivo é carregado ou salvo, e independentemente dos valores atribuídos usando [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **FAQ**

**Posso substituir o valor Application em um arquivo PPTX pelo nome da minha aplicação?**

Não. O valor é fixo, mesmo se você usar [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/pt/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Posso sobrescrever os campos Creator e Producer nas exportações PDF?**

Não. Ambos os campos são fixos e refletem a biblioteca e sua versão, independentemente de como você carrega ou salva a apresentação.