---
title: Aspose.Slides para .NET
second_title: Aspose.Slides para .NET
type: docs
weight: 10
url: /pt/net/
keywords:
- documentação
- processamento de apresentações
- conversão de apresentações
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Comece aqui: instale o Aspose.Slides for .NET, crie sua primeira apresentação e encontre os guias para tarefas comuns, implantação e a referência da API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET é uma biblioteca de classes para criar, ler, editar e converter apresentações PowerPoint e OpenDocument em aplicações .NET, sem o Microsoft PowerPoint ou automação do Office.

Ele carrega e salva PPT, PPTX, PPS, POT e ODP, incluindo variantes habilitadas para macro e modelos, e exporta para PDF, XPS, HTML, SVG, TIFF, Markdown e imagens.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Começar</b></p>
<hr>
<p>COMO COMEÇAR</p>
<ul>
<li><a href="/slides/pt/net/installation/">Instalação</a></li>
<li><a href="/slides/pt/net/create-presentation/">Criar sua primeira apresentação</a></li>
<li><a href="/slides/pt/net/system-requirements/">Requisitos do sistema</a></li>
<li><a href="/slides/pt/net/getting-started/">Guia de introdução</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/net/supported-file-formats/">Formatos de arquivo compatíveis</a></li>
<li><a href="/slides/pt/net/features-overview/">Visão geral dos recursos</a></li>
<li><a href="/slides/pt/net/evaluate-aspose-slides/">Limitações da avaliação</a></li>
<li><a href="/slides/pt/net/licensing/">Licenciamento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Desenvolver com Slides</b></p>
<hr>
<p>TAREFAS COMUNS</p>
<ul>
<li><a href="/slides/pt/net/open-presentation/">Abrir uma apresentação</a></li>
<li><a href="/slides/pt/net/save-presentation/">Salvar uma apresentação</a></li>
<li><a href="/slides/pt/net/convert-powerpoint-to-pdf/">Converter para PDF</a></li>
<li><a href="/slides/pt/net/convert-slide/">Renderizar slides como imagens</a></li>
<li><a href="/slides/pt/net/manage-text/">Editar texto e formas</a></li>
</ul>
<p>FLUXOS DE TRABALHO DO SLIDES</p>
<ul>
<li><a href="/slides/pt/net/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/pt/net/powerpoint-animation/">Animações</a></li>
<li><a href="/slides/pt/net/manage-media-files/">Áudio e vídeo</a></li>
<li><a href="/slides/pt/net/presentation-design/">Design de slides</a></li>
<li><a href="/slides/pt/net/merge-presentation/">Mesclar apresentações</a></li>
</ul>
<p>EXEMPLOS</p>
<ul>
<li><a href="/slides/pt/net/examples/">Exemplos por elemento de slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Exemplos no GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Implantar &amp; Suporte</b></p>
<hr>
<p>IMPLEMENTAR</p>
<ul>
<li><a href="/slides/pt/net/net6/">Multiplataforma (.NET 6+)</a></li>
<li><a href="/slides/pt/net/how-to-run-aspose-slides-in-docker/">Executar no Docker</a></li>
<li><a href="/slides/pt/net/deploy-fonts/">Fontes</a></li>
<li><a href="/slides/pt/net/security/">Segurança</a></li>
</ul>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/pt/net/">Referência da API</a></li>
<li><a href="https://releases.aspose.com/slides/pt/net/release-notes/">Notas de versão</a></li>
<li><a href="/slides/pt/net/known-issues/">Problemas conhecidos</a></li>
<li><a href="/slides/pt/net/api-limitations/">Limitações de metadados de saída</a></li>
<li><a href="https://releases.aspose.com/slides/pt/net/">Download</a></li>
</ul>
<p>SUPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/pt/11">Fórum de suporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk de suporte pago</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Sua primeira apresentação**

Crie um aplicativo de console com o .NET SDK 6 ou posterior:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Em seguida, adicione um pacote para sua plataforma:

- No Windows: `dotnet add package Aspose.Slides.NET`
- No Linux e macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — veja [Instalação](/slides/pt/net/installation/) para o pré-requisito Linux e para os sistemas que precisam de Aspose.Slides.NET em vez disso.

Substitua o conteúdo de *Program.cs* por este código e execute `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

O programa salva *hello.pptx* com um slide contendo uma caixa de texto. Sem uma licença, o arquivo salvo contém uma marca d'água de avaliação — veja [Licenciamento](/slides/pt/net/licensing/). Para mais formas de criar e preencher uma apresentação, veja [Criar Apresentações](/slides/pt/net/create-presentation/).