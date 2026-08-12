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
- apresentação para fluxo
- tipo de visualização predefinido
- Formato Strict Office Open XML
- modo Zip64
- atualizando miniatura
- progresso de salvamento
- C++
- Aspose.Slides
description: "Descubra como salvar apresentações em C++ usando Aspose.Slides—exportar para PowerPoint ou OpenDocument mantendo layouts, fontes e efeitos."
---
## **Visão geral**

[Open Presentations in C++](/slides/pt/cpp/open-presentation/) descreveu como usar a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) para abrir uma apresentação. Este artigo explica como criar e salvar apresentações. A classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) contém o conteúdo de uma apresentação. Seja criando uma apresentação do zero ou modificando uma existente, você desejará salvá‑la quando terminar. Com Aspose.Slides for C++, você pode salvar em um **arquivo** ou **fluxo**. Este artigo explica as diferentes maneiras de salvar uma apresentação.

## **Salvar apresentações em arquivos**

Salve uma apresentação em um arquivo chamando o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/). Passe o nome do arquivo e o formato de salvamento para o método. O exemplo a seguir mostra como salvar uma apresentação com Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancie a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Faça algum trabalho aqui...

// Salve a apresentação em um arquivo.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Salvar apresentações em fluxos**

Você pode salvar uma apresentação em um fluxo passando um fluxo de saída para o método `Save` da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/). Uma apresentação pode ser escrita em diversos tipos de fluxos. No exemplo abaixo, criamos uma nova apresentação e a salvamos em um fluxo de arquivo.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instancie a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Save the presentation to the stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Salvar apresentações com um tipo de visualização predefinido**

Aspose.Slides permite definir a visualização inicial que o PowerPoint usa quando a apresentação gerada é aberta através da classe [ViewProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/). Use o método [set_LastView](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/set_lastview/) com um valor da enumeração [ViewType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewtype/).

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Salvar apresentações no formato Strict Office Open XML**

Aspose.Slides permite salvar uma apresentação no formato Strict Office Open XML. Use a classe [PptxOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/) e defina sua propriedade `Conformance` ao salvar. Se você definir `Conformance.Iso29500_2008_Strict`, o arquivo de saída será salvo no formato Strict Office Open XML.

O exemplo abaixo cria uma apresentação e a salva no formato Strict Office Open XML.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instancie a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Salve a apresentação no formato Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo Office Open XML é um arquivo ZIP que impõe limites de 4 GB (2^32 bytes) para o tamanho não compactado de qualquer arquivo, o tamanho compactado de qualquer arquivo e o tamanho total do arquivo, além de limitar o número de arquivos a 65 535 (2^16‑1). As extensões do formato ZIP64 aumentam esses limites para 2^64.

O método [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) permite escolher quando usar as extensões do formato ZIP64 ao salvar um arquivo Office Open XML.

Este método pode ser usado com os seguintes modos:

- `IfNecessary` usa extensões de formato ZIP64 apenas se a apresentação exceder as limitações acima. Este é o modo padrão.  
- `Never` nunca usa extensões de formato ZIP64.  
- `Always` sempre usa extensões de formato ZIP64.

O código a seguir demonstra como salvar uma apresentação como um arquivo PPTX com as extensões de formato ZIP64 habilitadas:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTA" color="warning" %}}

Ao salvar com `Zip64Mode.Never`, uma [PptxException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptxexception/) é lançada se a apresentação não puder ser salva no formato ZIP32.

{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Ao trabalhar com apresentações grandes, você pode ajustar o nível de compressão para equilibrar o tamanho do arquivo e o tempo de processamento. Dependendo dos seus requisitos, pode preferir um processamento mais rápido ou arquivos de saída menores.

Aspose.Slides fornece o método [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/), que permite especificar o nível de compressão usado ao salvar uma apresentação no formato Office Open XML.

Os seguintes níveis de compressão estão disponíveis:

- **None**: Nenhuma compressão é aplicada. Os arquivos são armazenados como estão.  
- **Level1:** A compressão mais rápida com a menor taxa de compressão.  
- **Level2:** Compressão mais rápida com uma taxa de compressão ligeiramente melhor que **Level1**.  
- **Level3:** Oferece melhor compressão que **Level2** com impacto moderado no tempo de processamento.  
- **Level4:** Oferece melhor compressão que **Level3**.  
- **Level5:** Oferece compressão aprimorada em relação ao **Level4** com tempo de processamento adicional.  
- **Level6:** Compressão padrão que oferece um bom equilíbrio entre velocidade de processamento e tamanho do arquivo. Este é o *nível de compressão padrão*.  
- **Level7:** Oferece melhor compressão que **Level6** com processamento mais lento.  
- **Level8:** Oferece melhor compressão que **Level7**.  
- **Level9:** Compressão máxima. Produz o menor tamanho de arquivo ao custo do maior tempo de processamento.

O exemplo a seguir demonstra como salvar uma apresentação como um arquivo PPTX *sem compressão*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Este exemplo mostra como salvar uma apresentação como um arquivo PPTX com *compressão máxima*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Salvar apresentações sem atualizar a miniatura**

O método [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) controla a geração de miniaturas ao salvar uma apresentação em PPTX:

- Se definido como `true`, a miniatura é atualizada durante a gravação. Este é o padrão.  
- Se definido como `false`, a miniatura atual é preservada. Se a apresentação não tiver miniatura, nenhuma será gerada.

No código abaixo, a apresentação é salva em PPTX sem atualizar sua miniatura.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Informação" color="info" %}}

Esta opção ajuda a reduzir o tempo necessário para salvar uma apresentação no formato PPTX.

{{% /alert %}}

## **Salvar atualizações de progresso em porcentagem**

A interface [IProgressCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprogresscallback/) é usada via o método `set_ProgressCallback` exposto pela interface [ISaveOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isaveoptions/) e pela classe abstrata [SaveOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveoptions/). Atribua uma implementação de [IProgressCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprogresscallback/) com `set_ProgressCallback` para receber atualizações de progresso de salvamento em porcentagem.

Os trechos de código a seguir mostram como usar `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Use o valor percentual de progresso aqui.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// A classe de callback de progresso definida acima.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Informação" color="info" %}}

A Aspose desenvolveu um [aplicativo gratuito PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) usando sua própria API. O aplicativo permite dividir uma apresentação em vários arquivos salvando slides selecionados como novos arquivos PPTX ou PPT.

{{% /alert %}}

## **Perguntas frequentes**

**O "salvamento rápido" (salvamento incremental) é suportado para que apenas as alterações sejam gravadas?**

Não. Cada salvamento cria o arquivo de destino completo; o "salvamento rápido" incremental não é suportado.

**É seguro em termos de thread salvar a mesma instância de Presentation a partir de múltiplas threads?**

Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) **não é thread‑safe**; salve‑a a partir de um único thread.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar?**

[Hyperlinks](/slides/pt/cpp/manage-hyperlinks/) são preservados. Arquivos vinculados externamente (por exemplo, vídeos via caminhos relativos) não são copiados automaticamente — assegure‑se de que os caminhos referenciados permaneçam acessíveis.

**Posso definir/salvar metadados do documento (Autor, Título, Empresa, Data)?**

Sim. As propriedades padrão do documento [/slides/pt/cpp/presentation-properties/] são suportadas e serão gravadas no arquivo ao salvar.