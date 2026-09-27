---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /pt/cpp/
keywords:
- documentação
- processamento de apresentação
- conversão de apresentação
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Comece aqui: instale o Aspose.Slides for C++, crie a primeira apresentação e encontre os guias para tarefas comuns, a referência da API e o suporte."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ é uma biblioteca nativa C++ para criar, ler, editar e converter apresentações PowerPoint e OpenDocument, sem precisar do Microsoft PowerPoint ou da automação do Office.

Ela carrega e salva PPT, PPTX, PPS, POT e ODP, incluindo variantes com macros e modelos, e exporta para PDF, XPS, HTML, SVG, TIFF, Markdown e imagens.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Começar</b></p>
<hr>
<p>INICIANDO</p>
<ul>
<li><a href="/slides/pt/cpp/installation/">Instalação</a></li>
<li><a href="/slides/pt/cpp/create-presentation/">Crie sua primeira apresentação</a></li>
<li><a href="/slides/pt/cpp/getting-started/">Guia de início rápido</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/cpp/supported-file-formats/">Formatos de arquivo suportados</a></li>
<li><a href="/slides/pt/cpp/evaluate-aspose-slides/">Limitações da avaliação</a></li>
<li><a href="/slides/pt/cpp/licensing/">Licenciamento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Desenvolver com Slides</b></p>
<hr>
<p>TAREFAS COMUNS</p>
<ul>
<li><a href="/slides/pt/cpp/open-presentation/">Abrir uma apresentação</a></li>
<li><a href="/slides/pt/cpp/save-presentation/">Salvar uma apresentação</a></li>
<li><a href="/slides/pt/cpp/convert-powerpoint-to-pdf/">Converter para PDF</a></li>
<li><a href="/slides/pt/cpp/convert-slide/">Renderizar slides como imagens</a></li>
<li><a href="/slides/pt/cpp/manage-text/">Editar texto e formas</a></li>
</ul>
<p>FLUXOS DE TRABALHO DO SLIDES</p>
<ul>
<li><a href="/slides/pt/cpp/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/pt/cpp/powerpoint-animation/">Animações</a></li>
<li><a href="/slides/pt/cpp/manage-media-files/">Áudio e vídeo</a></li>
<li><a href="/slides/pt/cpp/presentation-design/">Design de slides</a></li>
<li><a href="/slides/pt/cpp/merge-presentation/">Mesclar apresentações</a></li>
</ul>
<p>EXEMPLOS</p>
<ul>
<li><a href="/slides/pt/cpp/examples/">Exemplos por elemento de slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Exemplos no GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referência &amp; Suporte</b></p>
<hr>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/pt/cpp/">Referência da API</a></li>
<li><a href="https://releases.aspose.com/slides/pt/cpp/release-notes/">Notas de lançamento</a></li>
<li><a href="/slides/pt/cpp/known-issues/">Problemas conhecidos</a></li>
<li><a href="https://releases.aspose.com/slides/pt/cpp/">Download</a></li>
</ul>
<p>SUPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/pt/11">Fórum de suporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk de suporte pago</a></li>
</ul>
</div>
</div>

------

## **Sua primeira apresentação**

No Windows, crie um projeto C++ **Console App** no Visual Studio e instale o pacote NuGet no Console do Gerenciador de Pacotes (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

No Linux, faça o download do pacote ZIP para Linux e configure o projeto CMake descrito em [Instalação](/slides/pt/cpp/installation/#linux).

Em seguida, use este código como o arquivo fonte principal do seu programa. Ele cria uma apresentação com uma caixa de texto e a salva:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Para executá‑lo no Windows, selecione a plataforma **x64** na barra de ferramentas e pressione **Ctrl+F5**. No Linux, salve‑o como *main.cpp* na pasta do projeto, então compile e execute‑o lá:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

O programa salva *hello.pptx* com um slide contendo uma caixa de texto. Sem uma licença, o arquivo salvo possui uma marca d'água de avaliação — veja [Licenciamento](/slides/pt/cpp/licensing/). Para mais maneiras de criar e preencher uma apresentação, veja [Criar apresentações](/slides/pt/cpp/create-presentation/).