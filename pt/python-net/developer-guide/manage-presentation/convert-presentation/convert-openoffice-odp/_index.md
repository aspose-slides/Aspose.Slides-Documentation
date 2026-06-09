---
title: Converter apresentações OpenDocument em Python
linktitle: Converter OpenDocument
type: docs
weight: 10
url: /pt/python-net/convert-openoffice-odp/
keywords:
- converter OpenDocument
- converter ODP
- ODP para PDF
- ODP para PPT
- ODP para PPTX
- ODP para XPS
- ODP para HTML
- ODP para TIFF
- ODP para SWF
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Converter OpenDocument ODP para PDF, PPT, PPTX, XPS, HTML, TIFF ou SWF em Python com Aspose.Slides: exemplos de código, alta fidelidade, conversão em lote e personalização."
---
## **Introdução**

[**Aspose.Slides API**](https://products.aspose.com/slides/pt/python-net/) permite converter apresentações OpenDocument (ODP) para vários formatos (HTML, PDF, TIFF, SWF, XPS, etc.). A API usada para converter arquivos ODP para outros formatos de documento é a mesma usada para operações de conversão do PowerPoint (PPT e PPTX).

Por exemplo, se você precisar converter uma apresentação ODP para PDF, pode fazê‑lo da seguinte maneira:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **Perguntas frequentes**

**Posso converter ODP para PPTX sem instalar LibreOffice ou OpenOffice?**

Sim. Aspose.Slides é uma biblioteca totalmente autônoma que manipula tanto formatos PowerPoint quanto OpenOffice sem exigir aplicativos externos.

**O Aspose.Slides abre e salva arquivos ODP/OTP protegidos por senha?**

Sim. Ele pode [carregar apresentações criptografadas](/slides/pt/python-net/password-protected-presentation/) quando você fornece a senha e também pode salvar apresentações com configurações de criptografia e proteção.

**Posso extrair arquivos de mídia incorporados (áudio/vídeo) de um ODP antes de convertê‑lo?**

Sim. Aspose.Slides permite acessar e extrair [áudio](/slides/pt/python-net/audio-frame/) e [vídeo](/slides/pt/python-net/video-frame/) incorporados nas apresentações, o que é útil para processamento pré‑conversão ou reutilização separada.

**Posso salvar o ODP convertido como Strict Office Open XML?**

Sim. Ao salvar em PPTX, você pode ativar o Strict OOXML através das [opções de salvamento](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pptxoptions/) para atender a requisitos de conformidade mais rigorosos.