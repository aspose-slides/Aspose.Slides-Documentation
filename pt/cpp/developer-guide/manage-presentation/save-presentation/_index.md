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
- atualização de miniatura
- progresso de salvamento
- C++
- Aspose.Slides
description: "Salve apresentações PowerPoint e OpenDocument em arquivos ou fluxos em C++ com Aspose.Slides, e configure a saída PPTX e o relatório de progresso."
---
## **Visão geral**

Depois de criar uma apresentação ou [abrir uma existente](/slides/pt/cpp/open-presentation/), use o método [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) para gravar o resultado. Aspose.Slides for C++ pode salvar uma apresentação em um arquivo ou fluxo nos formatos PowerPoint, OpenDocument, PDF e outros. As seções a seguir cobrem as operações padrão de salvamento e as opções disponíveis para saída PPTX.

## **Salvar apresentações em arquivos**

Para salvar uma apresentação em um arquivo, passe o caminho de saída e um valor de [SaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/) para o método [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/). O valor de formato determina o tipo de arquivo que o Aspose.Slides cria.

O exemplo a seguir cria uma apresentação e a salva como um arquivo PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Adicione ou modifique o conteúdo da apresentação aqui.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Salvar apresentações no formato original**

Para exemplos de detecção de arquivo e fluxo, o comportamento de apresentações recém‑criadas e a distinção entre formatos de origem e de saída, veja [Determine the Original Presentation Format](/slides/pt/cpp/detect-presentation-source-format/).

Em um aplicativo de processamento em lote, o formato de entrada pode não ser conhecido antecipadamente. Depois de carregar um arquivo, leia seu formato original com [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_sourceformat/). Passe o valor resultante de [SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sourceformat/) para [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/tosaveformat/) para obter o correspondente valor de [SaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/), e então use [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) para gravar a apresentação modificada.

O exemplo completo a seguir processa cada arquivo em um diretório de entrada, atualiza seu título e o salva em um diretório de saída no formato em que foi carregado:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/tosaveformat/) mapeia PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML para seus respectivos formatos de salvamento de apresentação. Ele mapeia apenas formatos de origem de apresentação; não tem a intenção de selecionar formatos de exportação como PDF, HTML, TIFF ou imagens. Passar um valor de [SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sourceformat/) não suportado ou inválido resulta em uma [ArgumentException](https://reference.aspose.com/slides/pt/cpp/system/argumentexception/).

Arquivos legados PPT, PPS e POT utilizam o mesmo contêiner binário. Quando tal apresentação é carregada de um fluxo sem extensão de arquivo, um arquivo PPS ou POT pode, portanto, ser identificado como PPT. Se for necessário preservar esses subtipos legados, mantenha o nome de arquivo original ou os metadados de formato separadamente e use‑os ao escolher o nome e o formato de saída.

## **Salvar apresentações em fluxos**

Para gravar uma apresentação sem depender de um caminho de arquivo final, passe um [Stream](https://reference.aspose.com/slides/pt/cpp/system.io/stream/) gravável e um valor de [SaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/) para o método [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/). Essa abordagem é útil quando a saída deve ser retornada de um serviço web, armazenada em um banco de dados ou processada na memória.

O exemplo a seguir salva uma nova apresentação em um fluxo de arquivo:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Salvar apresentações com um tipo de visualização predefinido**

Você pode especificar a visualização na qual o PowerPoint abre inicialmente uma apresentação salva. Chame [ViewProperties::set_LastView](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewproperties/set_lastview/) com um valor de [ViewType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/viewtype/) antes de salvar.

O exemplo a seguir configura a visualização Slide Master como visualização inicial:

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

Para criar um arquivo PPTX que esteja em conformidade com o perfil Strict do Office Open XML, crie uma instância de [PptxOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/) e chame [PptxOptions::set_Conformance](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/set_conformance/) com `Conformance::Iso29500_2008_Strict`. Em seguida, passe as opções para o método [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/).

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Salvar apresentações no formato Office Open XML no modo Zip64**

Um arquivo ZIP padrão limita o tamanho compactado e descompactado de cada entrada, o tamanho total do arquivo e o número de entradas. Como um arquivo PPTX é um ZIP, uma apresentação muito grande pode ultrapassar esses limites. As extensões ZIP64 elevam os limites de tamanho e contagem de entradas aplicáveis.

Use [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) para controlar se o Aspose.Slides grava extensões ZIP64:

- `IfNecessary` usa ZIP64 somente quando a apresentação excede os limites padrão de ZIP. Este é o modo padrão.
- `Never` desativa as extensões ZIP64.
- `Always` grava sempre extensões ZIP64.

O exemplo a seguir habilita sempre extensões ZIP64 para a apresentação de saída:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Aviso" %}}
Se `Zip64Mode` for definido como `Never` e a apresentação não couber dentro dos limites padrão de ZIP, a operação de salvamento lançará uma [PptxException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salvar apresentações no formato Office Open XML com níveis de compressão**

Para saída PPTX, você pode equilibrar velocidade de salvamento e tamanho do arquivo chamando [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). A enumeração [CompressionLevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/compressionlevel/) fornece esses valores:

- `None` armazena dados sem compressão.
- `Level1` oferece a compressão mais rápida e o maior tamanho compactado.
- `Level2` a `Level5` favorecem progressivamente tamanho menor em detrimento da velocidade de salvamento.
- `Level6` equilibra velocidade de salvamento e tamanho do arquivo. Este é o nível padrão.
- `Level7` e `Level8` favorecem ainda mais tamanho menor em detrimento da velocidade.
- `Level9` fornece a compressão mais forte e requer mais tempo de processamento.

O exemplo a seguir salva uma apresentação sem compressão:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

O exemplo a seguir usa o nível máximo de compressão:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Salvar apresentações sem atualizar a miniatura**

Quando uma apresentação é salva como PPTX, [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) controla sua miniatura de documento:

- `true` regenera a miniatura durante a operação de salvamento. Este é o valor padrão.
- `false` preserva a miniatura existente. Se a apresentação não possuir miniatura, o Aspose.Slides não gera uma.

O exemplo a seguir salva uma apresentação sem atualizar sua miniatura:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Observação" %}}
Desabilitar a atualização da miniatura pode reduzir o tempo necessário para salvar um arquivo PPTX.
{{% /alert %}}

## **Atualizações de progresso de salvamento em percentual**

Para monitorar uma operação de salvamento, implemente a interface [IProgressCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprogresscallback/) e passe a implementação para [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). O Aspose.Slides então chama [IProgressCallback::Reporting](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprogresscallback/reporting/) com valores de progresso durante a exportação.

O exemplo a seguir relata o progresso de uma exportação PDF no console:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Observação" %}}
A Aspose oferece um [PowerPoint Splitter](https://products.aspose.app/slides/pt/splitter) gratuito, construído com a API Aspose.Slides. Ele salva slides selecionados de uma apresentação como arquivos PPT ou PPTX separados.
{{% /alert %}}

## **Perguntas frequentes**

**O Aspose.Slides suporta salvamento incremental ou “salvamento rápido”?**  
Não. Cada operação de salvamento grava um arquivo de saída completo, em vez de atualizar apenas as partes alteradas.

**Vários threads podem salvar a mesma instância de Presentation?**  
Não. Uma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) **não é thread‑safe** (/slides/pt/cpp/multithreading/). Acesse e salve cada instância apenas de um thread por vez.

**O que acontece com hyperlinks e arquivos vinculados externamente ao salvar uma apresentação?**  
[Hyperlinks](/slides/pt/cpp/manage-hyperlinks/) permanecem na apresentação. O Aspose.Slides não copia arquivos vinculados externamente, portanto a apresentação salva ainda deverá ser capaz de acessar seus locais.

**Posso salvar metadados do documento, como autor, título, empresa e data de criação?**  
Sim. Defina as [propriedades do documento](/slides/pt/cpp/presentation-properties/) apropriadas antes de salvar, e o Aspose.Slides as grava no arquivo de saída.