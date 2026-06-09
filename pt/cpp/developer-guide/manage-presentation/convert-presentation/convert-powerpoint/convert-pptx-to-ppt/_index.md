---
title: Converter PPTX para PPT em C++
linktitle: PPTX para PPT
type: docs
weight: 21
url: /pt/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Converta facilmente PPTX para PPT com Aspose.Slides para C++ — garanta compatibilidade perfeita com os formatos do PowerPoint mantendo o layout e a qualidade da sua apresentação."
---
## **Visão geral**

Este artigo explica como converter uma apresentação PowerPoint no formato PPTX para o formato PPT usando C++. O tópico a seguir é coberto.

- Converter PPTX para PPT em C++

## **Converter PPTX para PPT em C++**

Para ver o código de exemplo em C++ para converter PPTX para PPT, veja a seção abaixo, ou seja, [Convert PPTX to PPT](#convert-pptx-to-ppt). Ele simplesmente carrega o arquivo PPTX e o salva no formato PPT. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPTX em vários outros formatos como PDF, XPS, ODP, HTML etc., conforme discutido nestes artigos. 

- [Converter PPTX para PDF em C++](/slides/pt/cpp/convert-powerpoint-to-pdf/)
- [Converter PPTX para XPS em C++](/slides/pt/cpp/convert-powerpoint-to-xps/)
- [Converter PPTX para HTML em C++](/slides/pt/cpp/convert-powerpoint-to-html/)
- [Converter PPTX para ODP em C++](/slides/pt/cpp/save-presentation/)
- [Converter PPTX para PNG em C++](/slides/pt/cpp/convert-powerpoint-to-png/)

## **Converter PPTX para PPT**
Para converter um PPTX para PPT, basta passar o nome do arquivo e o formato de salvamento para o método **Save** da classe [**Presentation**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/). O exemplo de código C++ abaixo converte uma Presentation de PPTX para PPT usando as opções padrão.

```cpp
// Carregue o PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Salvar no formato PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **Perguntas frequentes**

**Todos os efeitos e recursos do PPTX são preservados ao salvar no formato legado PPT (97–2003)?**

Nem sempre. O formato PPT carece de alguns recursos mais recentes (por exemplo, certos efeitos, objetos e comportamentos), portanto, os recursos podem ser simplificados ou rasterizados durante a conversão.

**Posso converter apenas slides selecionados para PPT em vez de toda a apresentação?**

O salvamento direto tem como alvo a apresentação inteira. Para converter slides específicos, crie uma nova apresentação contendo apenas esses slides e salve-a como PPT; alternativamente, use um serviço/API que suporte parâmetros de conversão por slide.

**Apresentações protegidas por senha são suportadas?**

Sim. Você pode detectar se um arquivo está protegido, abri‑lo com uma senha e também [configurar as configurações de proteção/criptografia](/slides/pt/cpp/password-protected-presentation/) para o PPT salvo.