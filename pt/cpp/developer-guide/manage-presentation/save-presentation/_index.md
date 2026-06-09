---
title: Salvar apresentações em C++
linktitle: Salvar apresentação
type: docs
weight: 80
url: /pt/cpp/save-presentation/
keywords:
- salvar PowerPoint
- salvar OpenDocument
- salvar apresentação
- salvar slide
- salvar PPT
- salvar PPTX
- salvar ODP
- apresentação para arquivo
- apresentação para stream
- tipo de visualização predefinido
- Formato Strict Office Open XML
- modo Zip64
- atualizar miniatura
- progresso de salvamento
- C++
- Aspose.Slides
description: "Descubra como salvar apresentações em C++ usando Aspose.Slides — exportar para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Open Presentations in C++](/slides/pt/cpp/open-presentation/) descreve como usar a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você precisará salvá‑la quando terminar. Com Aspose.Slides para C++, você pode salvar em um **arquivo** ou **stream**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Faça algum trabalho aqui...

// Salve a apresentação em um arquivo.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Salvar apresentações em streams**

Você pode salvar uma apresentação em um stream passando um stream de saída para o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/). Uma apresentação pode ser gravada em muitos tipos de stream. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um stream de arquivo.

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Salvar a apresentação no stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Salvar apresentações com um tipo de visualização predefinido**

Aspose.Slides permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta através da classe [ViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/). Use o método [set_LastView](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/set_lastview/) com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewtype/).

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Salvar apresentações no formato Strict Office Open XML**

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/) e defina sua propriedade `Conformance` ao salvar. Se você definir `Conformance.Iso29500_2008_Strict`, o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo abaixo cria uma apresentação e a salva no formato Strict Office Open XML.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Salvar a apresentação no formato Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) ao tamanho descompactado de qualquer arquivo, ao tamanho compactado de qualquer arquivo e ao tamanho total do arquivo, além de limitar o arquivo a 65 535 (2^16‑1) arquivos. As extensões de formato ZIP64 aumentam esses limites para 2^64.

O método [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) permite escolher quando usar as extensões de formato ZIP64 ao salvar um arquivo Office Open XML.

Este método pode ser usado com os seguintes modos:

- `IfNecessary` usa as extensões ZIP64 somente se a apresentação exceder as limitações acima. Este é o modo padrão.
- `Never` nunca usa as extensões ZIP64.
- `Always` sempre usa as extensões ZIP64.

O código a seguir demonstra como salvar uma apresentação como PPTX com as extensões ZIP64 habilitadas:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Ao salvar com `Zip64Mode.Never`, uma [PptxException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.
{{% /alert %}}

## **Salvar apresentações sem atualizar a miniatura**

O método [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) controla a geração da miniatura ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não possuir miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Esta opção ajuda a reduzir o tempo necessário para salvar uma apresentação no formato PPTX.
{{% /alert %}}

## **Atualizações de progresso de salvamento em percentual**

A interface [IProgressCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprogresscallback/) é usada via o método `set_ProgressCallback` exposto pela interface [ISaveOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isaveoptions/) e pela classe abstrata [SaveOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveoptions/). Atribua uma implementação de [IProgressCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprogresscallback/) com `set_ProgressCallback` para receber atualizações de progresso de salvamento em percentual.

Os trechos de código a seguir mostram como usar `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Use o valor da porcentagem de progresso aqui.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
A Aspose desenvolveu um [app gratuito de divisão de PowerPoint](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O app permite dividir uma apresentação em vários arquivos, salvando os slides selecionados como novos arquivos PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**O “salvamento rápido” (salvamento incremental) é suportado para que apenas as alterações sejam gravadas?**

Não. Cada salvamento cria o arquivo de destino completo; o “salvamento rápido” incremental não é suportado.

**É thread‑safe salvar a mesma instância de Presentation a partir de múltiplas threads?**

Não. Uma [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) [não é thread‑safe](/slides/pt/cpp/multithreading/); salve‑a a partir de uma única thread.

**O que acontece com hiperlinks e arquivos vinculados externamente ao salvar?**

[Hiperlinks](/slides/pt/cpp/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — assegure‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As propriedades padrão do [documento](/slides/pt/cpp/presentation-properties/) são suportadas e serão gravadas no arquivo ao salvar.