---
title: Converter Apresentações PowerPoint para Markdown em C++
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/cpp/convert-powerpoint-to-markdown/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para MD
- apresentação para MD
- slide para MD
- PPT para MD
- PPTX para MD
- salvar PowerPoint como Markdown
- salvar apresentação como Markdown
- salvar slide como Markdown
- salvar PPT como MD
- salvar PPTX como MD
- exportar PPT para MD
- exportar PPTX para MD
- PowerPoint
- apresentação
- Markdown
- C++
- Aspose.Slides
description: "Converter slides PowerPoint—PPT, PPTX—para Markdown limpo com Aspose.Slides para C++, automatizar documentação e manter a formatação."
---
## **Introdução**

Aspose.Slides permite converter apresentações PowerPoint para Markdown, o que pode ser útil em fluxos de documentação, geração de sites estáticos, migração de conteúdo e publicação de texto versionado. A API oferece exportação direta de apresentações PPT e PPTX para arquivos MD e fornece opções adicionais para controlar como o conteúdo dos slides é representado no documento Markdown resultante.

Você pode exportar apresentações como Markdown puro, escolher entre vários sabores de Markdown, como CommonMark e GitHub Flavored Markdown, e configurar como as imagens são tratadas durante a exportação. Para apresentações que contêm conteúdo visual, o Aspose.Slides também permite salvar as imagens em uma pasta separada e referenciá‑las a partir do arquivo Markdown gerado.

{{% alert color="warning" %}} 

A exportação de PowerPoint para markdown é **sem imagens** por padrão. Se você quiser exportar um documento PowerPoint que contém imagens, precisa definir `SaveOptions::MarkdownExportType::Visual)` e também definir o `BasePath` onde as imagens referenciadas no documento markdown serão salvas.

{{% /alert %}} 

## **Converter PowerPoint para Markdown**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) para representar um objeto de apresentação.  
2. Use o método [Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) para salvar o objeto como um arquivo markdown.

Este código C++ mostra como converter PowerPoint para markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **Converter PowerPoint para um Sabor de Markdown**

Aspose.Slides permite converter PowerPoint para markdown (contendo sintaxe básica), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab e 17 outros sabores de markdown.

Este código C++ mostra como converter PowerPoint para CommonMark:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

Os 23 sabores de markdown suportados estão [listados na enumeração Flavor](https://reference.aspose.com/slides/pt/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) da classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Converter uma Apresentação contendo Imagens para Markdown**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) fornece propriedades e enumerações que permitem usar determinadas opções ou configurações para o arquivo markdown resultante. O enum [MarkdownExportType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), por exemplo, pode ser definido com valores que determinam como as imagens são renderizadas ou tratadas: `Sequential`, `TextOnly`, `Visual`.

### **Converter Imagens Sequencialmente**

Se você desejar que as imagens apareçam individualmente, uma após a outra, no markdown resultante, deve escolher a opção sequencial. Este código C++ mostra como converter uma apresentação contendo imagens para markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **Converter Imagens Visualmente**

Se você quiser que as imagens apareçam juntas no markdown resultante, deve escolher a opção visual. Nesse caso, as imagens serão salvas no diretório atual da aplicação (e um caminho relativo será criado para elas no documento markdown), ou você pode especificar o caminho e o nome da pasta de sua preferência.

Este código C++ demonstra a operação:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **FAQ**

**Os hyperlinks permanecem após a exportação para Markdown?**

Sim. Os [hyperlinks](/slides/pt/cpp/manage-hyperlinks/) de texto são preservados como links Markdown padrão. As [transições](/slides/pt/cpp/slide-transition/) e [animações](/slides/pt/cpp/powerpoint-animation/) dos slides não são convertidas.

**Posso acelerar a conversão executando‑a em múltiplas threads?**

É possível paralelizar por arquivos, mas [não compartilhe](/slides/pt/cpp/multithreading/) a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) entre threads. Use instâncias/processos separados por arquivo para evitar contenção.

**O que acontece com as imagens — onde são salvas e os caminhos são relativos?**

As [imagens](/slides/pt/cpp/image/) são exportadas para uma pasta dedicada, e o arquivo Markdown as referencia com caminhos relativos por padrão. Você pode configurar o caminho de saída base e o nome da pasta de ativos para manter uma estrutura de repositório previsível.