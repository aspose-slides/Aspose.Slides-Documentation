---
title: Converter PPTX para PPT em Python
linktitle: PPTX para PPT
type: docs
weight: 21
url: /pt/python-net/convert-pptx-to-ppt/
keywords:
- PPTX para PPT
- converter PPTX para PPT
- converter PowerPoint
- converter apresentação
- Python
- Aspose.Slides
description: "Converta facilmente PPTX para PPT com Aspose.Slides for Python via .NET—garanta compatibilidade perfeita com os formatos do PowerPoint enquanto preserva o layout e a qualidade da sua apresentação."
---
## **Visão geral**

Aspose.Slides for Python permite converter apresentações PPTX modernas para o formato legado PPT totalmente por código. Abra um PPTX e exporte‑o como PPT mantendo o conteúdo e o layout da apresentação, tornando o resultado compatível com versões mais antigas do PowerPoint. O mesmo fluxo de trabalho pode gerar outros tipos de saída — como PDF, XPS, ODP, HTML ou imagens — para que se encaixe perfeitamente em scripts, pipelines de CI e processamento em lote.

## **Converter PPTX para PPT**

Para converter um PPTX em PPT, basta passar o nome do arquivo e o formato de salvamento ao método [salvar](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) da classe [Apresentação](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). O exemplo em Python abaixo converte uma apresentação de PPTX para PPT usando as opções padrão.

```py
import aspose.slides as slides

# Instancie a classe Presentation que representa um arquivo PPTX.
presentation = slides.Presentation("presentation.pptx")

# Salve a apresentação como um arquivo PPT.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Perguntas frequentes**

**Todos os efeitos e recursos do PPTX são preservados ao salvar no formato legado PPT (97–2003)?**

Nem sempre. O formato PPT carece de algumas capacidades mais recentes (por exemplo, determinados efeitos, objetos e comportamentos), de modo que recursos podem ser simplificados ou rasterizados durante a conversão.

**Posso converter apenas slides selecionados para PPT em vez de toda a apresentação?**

A gravação direta visa a apresentação completa. Para converter slides específicos, crie uma nova apresentação contendo apenas esses slides e salve‑a como PPT; alternativamente, use um serviço/API que ofereça parâmetros de conversão por slide.

**Apresentações protegidas por senha são suportadas?**

Sim. Você pode detectar se um arquivo está protegido, abri‑lo com uma senha e também [configurar as opções de proteção/criptografia](/slides/pt/python-net/password-protected-presentation/) para o PPT salvo.

**Veja também:**
- [Converter PPT & PPTX para PDF em Python | Opções avançadas](/slides/pt/python-net/convert-powerpoint-to-pdf/)
- [Converter Apresentações PowerPoint para XPS em Python](/slides/pt/python-net/convert-powerpoint-to-xps/)
- [Converter Apresentações PowerPoint para HTML em Python](/slides/pt/python-net/convert-powerpoint-to-html/)
- [Converter Slides PowerPoint para PNG em Python](/slides/pt/python-net/convert-powerpoint-to-png/)