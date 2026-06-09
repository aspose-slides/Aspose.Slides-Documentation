---
title: Problemas Conhecidos no Aspose.Slides for Java 14.4.0
type: docs
weight: 30
url: /pt/java/known-issues-in-aspose-slides-for-java-14-4-0/
keywords:
- problema conhecido
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise os problemas conhecidos no Aspose.Slides for Java 14.4.0 para garantir um trabalho preciso com arquivos PowerPoint e OpenDocument e evitar surpresas em suas apresentações."
---
{{% alert color="primary" %}} 

Aspose.Slides for Java 14.4.0 oferece nova decisão para o processamento de documentos PowerPoint. Existem algumas restrições e problemas conhecidos, que serão removidos nas próximas versões:

- Algumas formas têm geometria incorreta em documentos PPT serializados (arco, seta circular, balões de chamada).
- Nem todos os recursos de formatação de texto do PPTX são suportados na serialização para PPT (limitações de tabulação, recuo e formatação de parágrafo).
- Informações sobre idioma do texto e configurações de ortografia não estão presentes em documentos PPT serializados.
- Nem todos os recursos de tema do PPTX são suportados na serialização para PPT (apenas a serialização de formatos de preenchimento, formatos de linha e fontes).
- Existem problemas conhecidos na serialização OLE/ActiveX de PPT para PPT.
- A serialização e renderização de WordArt não são suportadas.

{{% /alert %}}