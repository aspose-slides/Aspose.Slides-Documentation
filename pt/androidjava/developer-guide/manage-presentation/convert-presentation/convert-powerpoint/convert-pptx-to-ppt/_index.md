---
title: Converter PPTX para PPT no Android
linktitle: PPTX para PPT
type: docs
weight: 21
url: /pt/androidjava/convert-pptx-to-ppt/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPTX
- PPTX para PPT
- salvar PPTX como PPT
- exportar PPTX para PPT
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Converta PPTX para PPT facilmente com Aspose.Slides para Android via Java - garanta compatibilidade perfeita com os formatos do PowerPoint enquanto preserva o layout e a qualidade da sua apresentação."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint no formato PPTX para o formato PPT usando Java. O tópico a seguir está coberto.

- Converter PPTX para PPT em Java

## **Converter PPTX para PPT no Android**

Para o código de exemplo Java que converte PPTX para PPT, consulte a seção abaixo, ou seja, [Convert PPTX to PPT](#convert-pptx-to-ppt). Ele apenas carrega o arquivo PPTX e o salva no formato PPT. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPTX em muitos outros formatos, como PDF, XPS, ODP, HTML etc., conforme discutido nestes artigos. 

- [Converter PPTX para PDF no Android](/slides/pt/androidjava/convert-powerpoint-to-pdf/)
- [Converter PPTX para XPS no Android](/slides/pt/androidjava/convert-powerpoint-to-xps/)
- [Converter PPTX para HTML no Android](/slides/pt/androidjava/convert-powerpoint-to-html/)
- [Converter PPTX para ODP no Android](/slides/pt/androidjava/save-presentation/)
- [Converter PPTX para PNG no Android](/slides/pt/androidjava/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
Para converter um PPTX para PPT, basta passar o nome do arquivo e o formato de salvamento para o método **Save** da classe [**Presentation**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation). O exemplo de código Java abaixo converte uma Presentation de PPTX para PPT usando as opções padrão.

```java
// Instancia um objeto Presentation que representa um arquivo PPTX
Presentation presentation = new Presentation("template.pptx");

// Salva a apresentação como PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **Perguntas frequentes**

**Todos os efeitos e recursos do PPTX são preservados ao salvar no formato legado PPT (97–2003)?**

Nem sempre. O formato PPT carece de algumas capacidades mais recentes (por exemplo, certos efeitos, objetos e comportamentos), de modo que os recursos podem ser simplificados ou rasterizados durante a conversão.

**Posso converter apenas slides selecionados para PPT em vez de toda a apresentação?**

A gravação direta visa toda a apresentação. Para converter slides específicos, crie uma nova apresentação contendo apenas esses slides e salve-a como PPT; alternativamente, use um serviço/API que ofereça parâmetros de conversão por slide.

**Apresentações protegidas por senha são suportadas?**

Sim. É possível detectar se um arquivo está protegido, abri‑lo com uma senha e também [configurar as configurações de proteção/criptografia](/slides/pt/androidjava/password-protected-presentation/) para o PPT salvo.