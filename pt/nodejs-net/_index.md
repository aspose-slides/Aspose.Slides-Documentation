---
title: Aspose.Slides para Node.js via .NET
second_title: Aspose.Slides para Node.js
type: docs
weight: 47
url: /pt/nodejs-net/
keywords:
- documentação
- processamento de apresentações
- conversão de apresentações
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Comece aqui: instale o Aspose.Slides for Node.js via .NET, crie sua primeira apresentação e encontre os guias para tarefas comuns, licenciamento, referência de API e suporte."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides para Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET é uma biblioteca para criar, ler, editar e converter apresentações PowerPoint e OpenDocument em aplicações Node.js, sem a necessidade do Microsoft PowerPoint ou automação do Office. Ela executa o Aspose.Slides para .NET através da ponte edge‑js, portanto sua API JavaScript espelha a API .NET, com nomes de membros em camelCase.

Carrega e grava arquivos PPT, PPTX, PPS, POT e ODP, incluindo variantes habilitadas para macros e modelos, e exporta para PDF, XPS, HTML, TIFF, Markdown e imagens.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Começar</b></p>
<hr>
<p>COMEÇANDO</p>
<ul>
<li><a href="/slides/pt/nodejs-net/installation/">Instalação</a></li>
<li><a href="/slides/pt/nodejs-net/create-presentation/">Crie sua primeira apresentação</a></li>
<li><a href="/slides/pt/nodejs-net/developer-guide/">Guia do desenvolvedor</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/nodejs-net/evaluate-aspose-slides/">Limitações da versão de avaliação</a></li>
<li><a href="/slides/pt/nodejs-net/licensing/">Licenciamento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Desenvolver com Slides</b></p>
<hr>
<p>TAREFAS COMUNS</p>
<ul>
<li><a href="/slides/pt/nodejs-net/open-presentation/">Abrir e salvar uma apresentação</a></li>
<li><a href="/slides/pt/nodejs-net/convert-powerpoint-to-pdf/">Converter para PDF</a></li>
<li><a href="/slides/pt/nodejs-net/convert-slide/">Renderizar slides como imagens</a></li>
<li><a href="/slides/pt/nodejs-net/manage-text/">Editar texto</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referência &amp; Suporte</b></p>
<hr>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">Referência da API .NET</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Notas de versão</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Página do produto</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">Download</a></li>
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

Você precisa do Node.js 22 ou 24 e do .NET SDK 8 ou superior; Linux também requer alguns pacotes do sistema. A página [Installation](/slides/pt/nodejs-net/installation/) lista-os e as plataformas testadas. Crie um projeto, adicione uma sobrescrita que indique ao npm qual versão do edge‑js instalar e instale o pacote:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Uma única vez por máquina, restaure os pacotes .NET dos quais a biblioteca depende. Salve o arquivo `deps.csproj` de [Restore the .NET Dependencies](/slides/pt/nodejs-net/installation/#restore-the-net-dependencies) em uma pasta `deps` dentro da pasta do projeto e, em seguida, execute:

```sh
dotnet restore deps/deps.csproj
```

Salve este código como *hello.js* na pasta do projeto:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Uma nova apresentação contém um slide vazio.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Posição e tamanho estão em pontos (1/72 polegada): x, y, largura, altura.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Libere o objeto .NET que suporta a apresentação.
    presentation.dispose();
}
```

Execute-o a partir da pasta do projeto:

```sh
node hello.js
```

O script exibe `Saved hello.pptx` e grava *hello.pptx* com um slide contendo um retângulo com o texto. Sem uma licença, o arquivo salvo contém uma marca d'água de avaliação — veja [Licensing](/slides/pt/nodejs-net/licensing/). Para conhecer mais maneiras de criar e preencher uma apresentação, consulte [Create a Presentation](/slides/pt/nodejs-net/create-presentation/).