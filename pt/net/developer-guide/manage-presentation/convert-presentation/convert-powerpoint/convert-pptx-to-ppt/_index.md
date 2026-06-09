---
title: Converter PPTX para PPT no .NET
linktitle: PPTX para PPT
type: docs
weight: 21
url: /pt/net/convert-pptx-to-ppt/
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
- .NET
- C#
- Aspose.Slides
description: "Converta facilmente PPTX para PPT com Aspose.Slides para .NET — garanta compatibilidade perfeita com os formatos do PowerPoint enquanto preserva o layout e a qualidade da sua apresentação."
---
## **Visão geral**

Este artigo explica como converter uma apresentação PowerPoint no formato PPTX para o formato PPT usando C#. O tópico a seguir é abordado.

- Converter PPTX para PPT em C#

## **Converter PPTX para PPT no .NET**

Para obter um exemplo de código C# que converte PPTX para PPT, veja a seção abaixo, ou seja, [Convert PPTX to PPT](#convert-pptx-to-ppt). Ele apenas carrega o arquivo PPTX e salva no formato PPT. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPTX em muitos outros formatos, como PDF, XPS, ODP, HTML etc., conforme discutido nestes artigos. 

- [Converter PPTX para PDF no .NET](/slides/pt/net/convert-powerpoint-to-pdf/)
- [Converter PPTX para XPS no .NET](/slides/pt/net/convert-powerpoint-to-xps/)
- [Converter PPTX para HTML no .NET](/slides/pt/net/convert-powerpoint-to-html/)
- [Converter PPTX para ODP no .NET](/slides/pt/net/save-presentation/)
- [Converter PPTX para PNG no .NET](/slides/pt/net/convert-powerpoint-to-png/)

## **Converter PPTX para PPT**
Para converter um PPTX para PPT, basta passar o nome do arquivo e o formato de salvamento para o método [**Save**](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) da classe [**Presentation**](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). O exemplo de código C# abaixo converte uma Presentation de PPTX para PPT usando as opções padrão.

```c#
// Instanciar um objeto Presentation que representa um arquivo PPTX
Presentation pres = new Presentation("presentation.pptx");

// Salvando a apresentação PPTX no formato PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **FAQ**

**Todos os efeitos e recursos do PPTX são mantidos ao salvar no formato legado PPT (97–2003)?**

Nem sempre. O formato PPT carece de algumas capacidades mais recentes (por exemplo, determinados efeitos, objetos e comportamentos), de modo que os recursos podem ser simplificados ou rasterizados durante a conversão.

**Posso converter apenas slides selecionados para PPT em vez de toda a apresentação?**

A gravação direta visa toda a apresentação. Para converter slides específicos, crie uma nova apresentação contendo apenas esses slides e salve-a como PPT; alternativamente, use um serviço/API que ofereça parâmetros de conversão por slide.

**Apresentações protegidas por senha são suportadas?**

Sim. Você pode detectar se um arquivo está protegido, abri‑lo com uma senha e também [configurar configurações de proteção/criptografia](/slides/pt/net/password-protected-presentation/) para o PPT salvo.