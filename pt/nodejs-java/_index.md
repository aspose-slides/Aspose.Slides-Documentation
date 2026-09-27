---
title: Aspose.Slides para Node.js via Java
second_title: Aspose.Slides para Node.js
type: docs
weight: 47
url: /pt/nodejs-java/
keywords:
- documentação
- processamento de apresentações
- conversão de apresentações
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Comece aqui: instale o Aspose.Slides para Node.js via Java, crie uma primeira apresentação e encontre os guias para tarefas comuns, a referência da API e o suporte."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-java.png" alt="Aspose.Slides for Node.js via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via Java é uma biblioteca para criar, ler, editar e converter apresentações PowerPoint e OpenDocument em aplicações Node.js, sem o Microsoft PowerPoint.

Ela carrega e salva PPT, PPTX, PPS, POT e ODP, incluindo variantes habilitadas para macro e modelos, e exporta para PDF, XPS, HTML, SVG, TIFF, Markdown e imagens.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Começar</b></p>
<hr>
<p>INICIANDO</p>
<ul>
<li><a href="/slides/pt/nodejs-java/installation/">Instalação</a></li>
<li><a href="/slides/pt/nodejs-java/create-presentation/">Crie sua primeira apresentação</a></li>
<li><a href="/slides/pt/nodejs-java/getting-started/">Guia de início</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/nodejs-java/supported-file-formats/">Formatos de arquivo suportados</a></li>
<li><a href="/slides/pt/nodejs-java/evaluate-aspose-slides/">Limitações da avaliação</a></li>
<li><a href="/slides/pt/nodejs-java/licensing/">Licenciamento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Construir com Slides</b></p>
<hr>
<p>TAREFAS COMUNS</p>
<ul>
<li><a href="/slides/pt/nodejs-java/open-presentation/">Abrir uma apresentação</a></li>
<li><a href="/slides/pt/nodejs-java/save-presentation/">Salvar uma apresentação</a></li>
<li><a href="/slides/pt/nodejs-java/convert-powerpoint-to-pdf/">Converter para PDF</a></li>
<li><a href="/slides/pt/nodejs-java/convert-slide/">Renderizar slides como imagens</a></li>
<li><a href="/slides/pt/nodejs-java/manage-text/">Editar texto e formas</a></li>
</ul>
<p>FLUXOS DE TRABALHO</p>
<ul>
<li><a href="/slides/pt/nodejs-java/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/pt/nodejs-java/powerpoint-animation/">Animações</a></li>
<li><a href="/slides/pt/nodejs-java/manage-media-files/">Áudio e vídeo</a></li>
<li><a href="/slides/pt/nodejs-java/presentation-design/">Design de slide</a></li>
<li><a href="/slides/pt/nodejs-java/merge-presentation/">Mesclar apresentações</a></li>
</ul>
<p>EXEMPLOS</p>
<ul>
<li><a href="/slides/pt/nodejs-java/examples/">Exemplos por elemento de slide</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referência &amp; Suporte</b></p>
<hr>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nodejs-java/">Referência da API</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/release-notes/">Notas de lançamento</a></li>
<li><a href="/slides/pt/nodejs-java/known-issues/">Problemas conhecidos</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-java/">Download</a></li>
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

Além do Node.js 20 ou posterior, o pacote requer um Java Development Kit (JDK), Python e uma cadeia de ferramentas de compilação C++, porque o npm compila sua ponte `java` durante a instalação. Consulte [Instalação](/slides/pt/nodejs-java/installation/) para as etapas em cada sistema operacional. Em seguida, crie um projeto e instale o pacote via npm:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Salve este código como *hello.js* na pasta do projeto:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides é executado em uma máquina virtual Java que mantém o Node.js em execução, portanto finalize o processo explicitamente.
process.exit(0);
```

Execute-o com `node hello.js`. O script salva *hello.pptx* com um slide contendo uma caixa de texto. Sem licença, o arquivo salvo contém uma marca d'água de avaliação — veja [Licenciamento](/slides/pt/nodejs-java/licensing/). Para mais maneiras de criar e preencher uma apresentação, veja [Criar apresentações](/slides/pt/nodejs-java/create-presentation/).