---
title: Aspose.Slides para Python via .NET
second_title: Aspose.Slides para Python
type: docs
weight: 35
url: /pt/python-net/
is_root: true
keywords:
- Aspose.Slides para Python
- Automação de PowerPoint com Python
- Biblioteca PPT para Python
- Exportar PowerPoint para PDF com Python
- Exportar PowerPoint para SVG com Python
- Editar PowerPoint em Python
- PowerPoint Python sem Microsoft Office
- Gerenciar PPTX com Python
- Visualização de slides em Python
- Adicionar áudio a slides com Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Comece aqui: instale Aspose.Slides para Python via .NET, crie sua primeira apresentação e encontre os guias para tarefas comuns, a referência da API e o suporte."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides para Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides para Python via .NET é uma biblioteca Python para criar, ler, editar e converter apresentações PowerPoint e OpenDocument, sem precisar do Microsoft PowerPoint ou do Microsoft Office.

Ele carrega e salva PPT, PPTX, PPS, POT e ODP, incluindo variantes com macros e modelos, e exporta para PDF, XPS, HTML, SVG, TIFF, Markdown e imagens.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Começar</b></p>
<hr>
<p>INICIANDO</p>
<ul>
<li><a href="/slides/pt/python-net/installation/">Instalação</a></li>
<li><a href="/slides/pt/python-net/create-presentation/">Crie sua primeira apresentação</a></li>
<li><a href="/slides/pt/python-net/getting-started/">Guia de início rápido</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/python-net/supported-file-formats/">Formatos de arquivo suportados</a></li>
<li><a href="/slides/pt/python-net/evaluate-aspose-slides/">Limitações da avaliação</a></li>
<li><a href="/slides/pt/python-net/licensing/">Licenciamento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Desenvolver com Slides</b></p>
<hr>
<p>TAREFAS COMUNS</p>
<ul>
<li><a href="/slides/pt/python-net/open-presentation/">Abrir uma apresentação</a></li>
<li><a href="/slides/pt/python-net/save-presentation/">Salvar uma apresentação</a></li>
<li><a href="/slides/pt/python-net/convert-powerpoint-to-pdf/">Converter para PDF</a></li>
<li><a href="/slides/pt/python-net/convert-slide/">Renderizar slides como imagens</a></li>
<li><a href="/slides/pt/python-net/manage-text/">Editar texto e formas</a></li>
</ul>
<p>FLUXOS DE TRABALHO DO SLIDES</p>
<ul>
<li><a href="/slides/pt/python-net/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/pt/python-net/powerpoint-animation/">Animações</a></li>
<li><a href="/slides/pt/python-net/manage-media-files/">Áudio e vídeo</a></li>
<li><a href="/slides/pt/python-net/presentation-design/">Design de slide</a></li>
<li><a href="/slides/pt/python-net/merge-presentation/">Mesclar apresentações</a></li>
</ul>
<p>EXEMPLOS</p>
<ul>
<li><a href="/slides/pt/python-net/examples/">Exemplos por elemento de slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">Exemplos no GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referência &amp; Suporte</b></p>
<hr>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-net/">Referência da API</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">Notas de versão</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">Página do produto</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">Download</a></li>
</ul>
<p>SUPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Fórum de suporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk de suporte pago</a></li>
</ul>
</div>
</div>

------

## **Sua primeira apresentação**

Instale o pacote a partir do PyPI:

```bash
pip install aspose.slides
```

O pacote inclui o runtime .NET que ele usa, portanto você não precisa instalar o .NET. No Linux, também instale as bibliotecas libgdiplus e ICU, e com o Python do sistema do Debian ou Ubuntu, execute o comando em um ambiente virtual. O macOS tem pré‑requisitos adicionais, e não verificamos a instalação nele. Consulte [Instalação](/slides/pt/python-net/installation/) para os comandos, os pré‑requisitos do macOS e as versões do Python suportadas.

Salve este código como *hello.py*:

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma forma automática do tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Salvar a apresentação como arquivo PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Execute‑o com `python hello.py`. O script salva *new_presentation.pptx* na pasta atual, com um slide contendo uma forma de nuvem que exibe "Hello, Aspose!". Sem uma licença, o arquivo salvo recebe uma marca d'água de avaliação — veja [Licenciamento](/slides/pt/python-net/licensing/). Para mais maneiras de criar e preencher uma apresentação, veja [Criar apresentações](/slides/pt/python-net/create-presentation/).