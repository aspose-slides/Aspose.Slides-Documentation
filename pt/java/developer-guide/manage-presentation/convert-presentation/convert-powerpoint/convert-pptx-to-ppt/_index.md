---
title: Converter PPTX para PPT em Java
linktitle: PPTX para PPT
type: docs
weight: 21
url: /pt/java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "Converta PPTX para PPT facilmente com Aspose.Slides para Java — garanta compatibilidade perfeita com os formatos do PowerPoint enquanto preserva o layout e a qualidade da sua apresentação."
---
## **Visão geral**

Este artigo explica como converter apresentações PowerPoint no formato PPTX para o formato PPT usando Java. O tópico a seguir é abordado.

- Convert PPTX to PPT in Java

## **Converter PPTX para PPT em Java**

Para obter código de exemplo Java para converter PPTX em PPT, consulte a seção abaixo, ou seja, [Convert PPTX to PPT](#convert-pptx-to-ppt). Ele apenas carrega o arquivo PPTX e o salva no formato PPT. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPTX em muitos outros formatos, como PDF, XPS, ODP, HTML etc., conforme discutido nestes artigos. 

- [Convert PPTX to PDF in Java](/slides/pt/java/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in Java](/slides/pt/java/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in Java](/slides/pt/java/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in Java](/slides/pt/java/save-presentation/)
- [Convert PPTX to PNG in Java](/slides/pt/java/convert-powerpoint-to-png/)

## **Converter PPTX para PPT**
Para converter um PPTX em PPT, basta passar o nome do arquivo e o formato de salvamento para o método **Save** da classe [**Presentation**](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation). O exemplo de código Java abaixo converte uma Presentation de PPTX para PPT usando as opções padrão.

```java
// instancia um objeto Presentation que representa um arquivo PPTX
Presentation presentation = new Presentation("template.pptx");

// salva a apresentação como PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Todos os efeitos e recursos do PPTX permanecem ao salvar no formato PPT legado (97–2003)?**

Nem sempre. O formato PPT carece de algumas capacidades mais recentes (por exemplo, certos efeitos, objetos e comportamentos), portanto, os recursos podem ser simplificados ou rasterizados durante a conversão.

**Posso converter apenas slides selecionados para PPT em vez de toda a apresentação?**

O salvamento direto tem como alvo toda a apresentação. Para converter slides específicos, crie uma nova apresentação contendo apenas esses slides e salve‑a como PPT; alternativamente, use um serviço/API que suporte parâmetros de conversão por slide.

**Apresentações protegidas por senha são suportadas?**

Sim. Você pode detectar se um arquivo está protegido, abri‑lo com uma senha e também [configure protection/encryption settings](/slides/pt/java/password-protected-presentation/) para o PPT salvo.