---
title: Problemas conhecidos no Aspose.Slides for Java 14.3.0
type: docs
weight: 20
url: /pt/java/known-issues-in-aspose-slides-for-java-14-3-0/
keywords:
- problema conhecido
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise os problemas conhecidos no Aspose.Slides for Java 14.3.0 para garantir um trabalho preciso com arquivos PowerPoint e OpenDocument e evitar surpresas em suas apresentações."
---
Aspose.Slides for Java 14.3.0 (14.4.0) fornece uma implementação completamente nova do processamento de PPT. Há muitas melhorias, conversão parcial de PPTX para PPT. Mas há alguns recursos não implementados:

- Algumas formas têm geometria incorreta em documentos PPT serializados (Balões de chamada)
- Nem todos os recursos de formatação de texto do PPTX são suportados na serialização para PPT
- Informações sobre o idioma do texto e configurações de ortografia não estão presentes em documentos PPT serializados
- Nem todos os recursos dos temas do PPTX são suportados na serialização para PPT

**Existem algumas diferenças em comparação com Aspose.Slides for Java 8.6.0:**

- Existem problemas conhecidos na serialização OLE/ActiveX de PPT para PPT

**Existem algumas diferenças em comparação com Aspose.Slides for .NET 14.3.0:**

- O suporte à impressão de apresentações não está disponível no momento no Aspose.Slides for Java