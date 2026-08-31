---
title: Aspose.Slides para Python via .NET
second_title: Aspose.Slides para Python
type: docs
weight: 35
url: /pt/python-net/
is_root: true
keywords:
- Aspose.Slides para Python
- Automação PowerPoint Python
- Biblioteca PPT Python
- Exportar PowerPoint para PDF Python
- Exportar PowerPoint para SVG Python
- Editar PowerPoint em Python
- PowerPoint Python sem Microsoft Office
- Gerenciar PPTX com Python
- Pré-visualização de slides Python
- Python adiciona áudio aos slides
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides para Python via .NET oferece um conjunto abrangente de recursos, incluindo gerenciamento de texto, formas, tabelas e animações, adição de áudio e vídeo aos slides, pré-visualização de slides e exportação para SVG, PDF e muito mais."
---
{{% alert color="info" %}}

**Bem-vindo ao Aspose.Slides para Python via .NET**

![Logotipo do Produto Aspose.Slides para Python via .NET](aspose_slides-for-python.png)

Aspose.Slides para Python via .NET é uma biblioteca de classes robusta que permite que suas aplicações leiam e gravem apresentações PowerPoint® sem exigir o Microsoft PowerPoint®.

É o primeiro e único componente que oferece gerenciamento completo de documentos PowerPoint® para desenvolvedores Python.

Aspose.Slides para Python via .NET inclui uma ampla variedade de recursos, como trabalhar com texto, formas, tabelas e animações; adicionar áudio e vídeo; pré‑visualizar slides; e exportar slides para formatos como SVG, PDF e outros.

{{% /alert %}}

## Instalar Aspose.Slides para Python via .NET

```bash
pip install aspose.slides
```

O pacote inclui o runtime .NET necessário, portanto não há mais nada a instalar e o Microsoft PowerPoint não é exigido. Python 3.7 ou superior no Windows, Linux ou macOS.

## Criar uma Apresentação PowerPoint em Python

Este exemplo cria uma apresentação, adiciona uma forma com texto ao primeiro slide e salva o resultado tanto como PPTX quanto como PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Ao executá‑lo, ele grava `presentation.pptx` (cerca de 34 KB) e `presentation.pdf` (cerca de 36 KB) no diretório de trabalho.

Sem uma licença, a biblioteca funciona em modo de avaliação, que adiciona uma marca d'água e limita o número de slides. Consulte [Licenciamento](/slides/pt/python-net/licensing/) para aplicar uma.

## Recursos do Aspose.Slides para Python via .NET

Explore estes recursos úteis:

- [Documentação Online do Aspose.Slides para Python via .NET](/slides/pt/python-net/)
- [Recursos do Aspose.Slides para Python via .NET](/slides/pt/python-net/features-overview/)
- [Notas de Versão do Aspose.Slides para Python via .NET](https://releases.aspose.com/slides/pt/python-net/release-notes/)
- [Página do Produto Aspose.Slides para Python via .NET](https://products.aspose.com/slides/pt/python-net/)
- [Download do Aspose.Slides para Python via .NET](https://releases.aspose.com/slides/pt/python-net/)
- [Instalar Pacote PyPi do Aspose.Slides para Python via .NET](https://pypi.org/project/aspose.slides/)
- [Guia de Referência da API do Aspose.Slides para Python via .NET](https://reference.aspose.com/slides/pt/python-net/)
- [Fórum de Suporte Gratuito do Aspose.Slides para Python via .NET](https://forum.aspose.com/c/slides/pt/11)
- [Helpdesk de Suporte Pago do Aspose.Slides para Python via .NET](https://helpdesk.aspose.com/)

## Perguntas Frequentes

### O que é Aspose.Slides para Python via .NET?

Aspose.Slides para Python via .NET é uma poderosa biblioteca Python que permite criar, editar e converter apresentações PowerPoint (PPT, PPTX, ODP) programaticamente sem a necessidade do Microsoft PowerPoint instalado.

### Quais recursos de apresentação o Aspose.Slides oferece?

A biblioteca oferece suporte ao gerenciamento de texto, formas, tabelas, gráficos, animações, slides mestre, áudio, vídeo e muito mais. Também possibilita a pré‑visualização de slides, renderização e exportação para formatos como PDF, SVG, HTML e imagens.

### Posso converter apresentações para outros formatos usando o Aspose.Slides?

Sim. Aspose.Slides permite a conversão de arquivos PowerPoint para PDF, SVG, HTML, JPG, PNG, TIFF e outros formatos com alta fidelidade e desempenho.

### O Microsoft PowerPoint é necessário para usar o Aspose.Slides?

Não. Aspose.Slides é uma API independente e não requer Microsoft Office ou qualquer software de terceiros.

### Em quais plataformas o Aspose.Slides para Python via .NET oferece suporte?

É multiplataforma e funciona em ambientes Windows, Linux e macOS.

### Como começar a usar o Aspose.Slides para Python?

Você pode instalá‑lo via PyPi e explorar o [Guia do Desenvolvedor](/slides/pt/python-net/developer-guide/) para iniciar com exemplos, referências de API e tutoriais.