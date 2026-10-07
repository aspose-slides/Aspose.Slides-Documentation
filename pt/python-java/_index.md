---
title: Aspose.Slides para Python via Java
second_title: Aspose.Slides para Python
type: docs
weight: 47
url: /pt/python-java/
is_root: true
keywords:
- Aspose.Slides para Python via Java
- Biblioteca PowerPoint para Python
- gerenciar apresentações PowerPoint em Python
- ler e gravar PowerPoint em Python
- editar slides PowerPoint em Python
- exportar PowerPoint para PDF em Python
- exportar PowerPoint para SVG em Python
- visualizar slides em Python
- adicionar áudio e vídeo aos slides em Python
- PowerPoint sem Microsoft Office
- Python
- Java
- Aspose.Slides
description: "Comece aqui: instale Aspose.Slides para Python via Java, crie sua primeira apresentação e encontre os guias para tarefas comuns, a referência da API e o suporte."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides para Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java é uma biblioteca para criar, ler, editar e converter apresentações PowerPoint e OpenDocument em aplicações Python, sem Microsoft PowerPoint; ela executa o mecanismo Aspose.Slides Java no seu processo Python através do JPype.

Ela carrega e salva PPT, PPTX, PPS, POT e ODP, incluindo variantes com macros e modelos, e exporta para PDF, XPS, HTML, SVG, TIFF, Markdown e imagens.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Começar</b></p>
<hr>
<p>COMEÇANDO</p>
<ul>
<li><a href="/slides/pt/python-java/installation/">Instalação</a></li>
<li><a href="/slides/pt/python-java/create-presentation/">Crie sua primeira apresentação</a></li>
<li><a href="/slides/pt/python-java/getting-started/">Guia de introdução</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/python-java/supported-file-formats/">Formatos de arquivo suportados</a></li>
<li><a href="/slides/pt/python-java/evaluate-aspose-slides/">Limitações da avaliação</a></li>
<li><a href="/slides/pt/python-java/licensing/">Licença</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Desenvolver com Slides</b></p>
<hr>
<p>TAREFAS COMUNS</p>
<ul>
<li><a href="/slides/pt/python-java/open-presentation/">Abrir uma apresentação</a></li>
<li><a href="/slides/pt/python-java/save-presentation/">Salvar uma apresentação</a></li>
<li><a href="/slides/pt/python-java/convert-powerpoint-to-pdf/">Converter para PDF</a></li>
<li><a href="/slides/pt/python-java/convert-slide/">Renderizar slides como imagens</a></li>
<li><a href="/slides/pt/python-java/manage-text/">Editar texto e formas</a></li>
</ul>
<p>FLUXOS DE TRABALHO DO SLIDES</p>
<ul>
<li><a href="/slides/pt/python-java/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/pt/python-java/powerpoint-animation/">Animações</a></li>
<li><a href="/slides/pt/python-java/manage-media-files/">Áudio e vídeo</a></li>
<li><a href="/slides/pt/python-java/presentation-design/">Design de slide</a></li>
<li><a href="/slides/pt/python-java/merge-presentation/">Mesclar apresentações</a></li>
</ul>
<p>EXEMPLOS</p>
<ul>
<li><a href="/slides/pt/python-java/examples/">Exemplos por elemento de slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referência &amp; Suporte</b></p>
<hr>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">Referência da API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Notas de versão</a></li>
<li><a href="/slides/pt/python-java/known-issues/">Problemas conhecidos</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">Página do produto</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Download</a></li>
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

Instale o Python e um JDK, configure `JAVA_HOME`, e crie e ative um ambiente virtual conforme descrito em [Instalação](/slides/pt/python-java/installation/). Em seguida, instale JPype e Aspose.Slides do PyPI:

```sh
python -m pip install JPype1 aspose-slides-java
```

Salve este código como *hello.py*. Ele inicia a Máquina Virtual Java, adiciona uma forma de nuvem com texto ao primeiro slide de uma nova apresentação e salva a apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Crie uma apresentação com um slide em branco.
presentation = Presentation()
try:
    # Obtenha o primeiro slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicione uma forma de nuvem e defina seu texto.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Salve a apresentação como um arquivo PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Execute‑o no mesmo ambiente virtual:

```sh
python hello.py
```

O script salva *new_presentation.pptx* com um slide contendo uma forma de nuvem com o texto "Hello, Aspose!". Sem uma licença, o arquivo salvo também apresenta uma marca d'água de avaliação — veja [Licença](/slides/pt/python-java/licensing/). Para mais maneiras de criar e preencher uma apresentação, veja [Criar Apresentações](/slides/pt/python-java/create-presentation/).