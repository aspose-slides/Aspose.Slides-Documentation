---
title: Determinar o Formato Original da Apresentação em C++
linktitle: Formato de Origem
type: docs
weight: 35
url: /pt/cpp/detect-presentation-source-format/
keywords:
- formato de origem
- detectar formato de apresentação
- PowerPoint
- OpenDocument
- apresentação
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Leia o formato original de uma apresentação carregada em C++ com Aspose.Slides para C++, compare as APIs de detecção e manipule arquivos, fluxos e formatos legados."
---
## **Visão geral**

Depois de carregar uma apresentação, chame [Presentation::get_SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_sourceformat/) para determinar seu formato original. O método também está disponível através de [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_sourceformat/). Use-o quando o processamento subsequente depender do formato a partir do qual a instância atual foi carregada.

O formato de origem é distinto do [SaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/) selecionado para um arquivo de saída. Salvar em outro formato não altera o formato de origem da instância existente.

## **Ler o formato de origem de um arquivo**

Este exemplo requer um arquivo `sample.pptx` existente. Ele carrega o arquivo e seleciona uma política de processamento da aplicação usando [Presentation::get_SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_sourceformat/), em vez do nome de arquivo. Altere o caminho de entrada para experimentar outros formatos. O exemplo imprime a política selecionada; substitua as mensagens pela lógica da sua aplicação.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Reconhecer os valores suportados**

A enumeração [SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sourceformat/) distingue os seguintes formatos de apresentação. As extensões abaixo são extensões convencionais, não uma reconstrução do nome de arquivo original.

| Valor SourceFormat | Extensão | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Apresentação PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Apresentação Office Open XML |
| `Pptm` | `.pptm` | Apresentação Office Open XML com macros |
| `Pps` | `.pps` | Apresentação de slides PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Apresentação de slides Office Open XML |
| `Ppsm` | `.ppsm` | Apresentação de slides Office Open XML com macros |
| `Pot` | `.pot` | Modelo PowerPoint 97–2003 |
| `Potx` | `.potx` | Modelo Office Open XML |
| `Potm` | `.potm` | Modelo Office Open XML com macros |
| `Odp` | `.odp` | Apresentação OpenDocument |
| `Otp` | `.otp` | Modelo de apresentação OpenDocument |
| `Fodp` | `.fodp` | Apresentação OpenDocument XML plano |
| `Xml` | `.xml` | Apresentação PowerPoint XML |

## **Ler o formato de origem de um fluxo**

Este exemplo requer um arquivo `sample.pps` existente. Ler seus bytes em um fluxo de memória modela a entrada recebida sem um nome de arquivo, como um valor de banco de dados ou um array de bytes enviado. O construtor [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) recebe apenas o fluxo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS e POT usam o mesmo formato binário subjacente. Ao carregar por caminho de arquivo, a extensão pode ajudar a distinguir um slideshow ou modelo. Sem um nome de arquivo, conteúdo legado PPS e POT pode ser relatado como `SourceFormat::Ppt`; o exemplo PPS acima relata `Ppt`.

Se sua aplicação precisar preservar a distinção, mantenha o nome de arquivo original ou metadados de subtipo separadamente. Uma extensão é uma pista útil para esses subtipos legados, mas não deve ser a única base para identificar conteúdo arbitrário de apresentação.

## **Comparar a detecção antes e depois do carregamento**

Use [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationfactory/getpresentationinfo/) e [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/get_loadformat/) quando precisar inspecionar um arquivo antes de carregar seu modelo de objeto de apresentação completo. Use [Presentation::get_SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_sourceformat/) quando a instância já existir.

Este exemplo requer `sample.pptx` e imprime `Pptx` para ambas as verificações. Na produção, escolha a API apropriada ao seu estágio de processamento; uma apresentação já carregada não precisa de uma segunda inspeção apenas para obter seu formato de origem.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Os resultados têm tipos de enumeração diferentes: [LoadFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sourceformat/). Não os compare convertendo seus valores numéricos nem presuma que todo formato tem resultados de detecção idênticos. PowerPoint XML pode ser relatado como `LoadFormat::Unknown` antes do carregamento e `SourceFormat::Xml` depois do carregamento.

## **Manter os formatos de origem e de saída separados**

Este exemplo requer `sample.pptx` e grava `converted.odp`. Ele imprime `Pptx` tanto antes quanto depois de salvar a instância original. Somente a nova instância carregada a partir da saída ODP relata `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Uma apresentação criada do zero com `MakeObject<Presentation>()` relata `SourceFormat::Pptx`. Ela não tem arquivo de entrada: esse é o valor padrão para uma instância recém‑criada, não evidência de que um arquivo PPTX foi carregado. Controle se sua aplicação criou ou carregou a instância separadamente se essa distinção for importante.

## **Mapear um formato de origem para uma extensão**

O exemplo a seguir requer `sample.pptx`. Ele mapeia cada valor atualmente suportado de [SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/sourceformat/) para uma extensão convencional, sem analisar o nome de arquivo de entrada. O fallback evita atribuir silenciosamente uma extensão a um valor não reconhecido.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Esse mapeamento não converte um arquivo nem recupera um subtipo legado PPS/POT perdido durante o carregamento do fluxo. Para a gravação real, selecione um [SaveFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/saveformat/) explicitamente, ou use a conversão mostrada em [Save Presentations in Their Original Format](/slides/pt/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Verificar formatos salvando e reabrindo**

Este exemplo autocontido cria uma apresentação e grava três arquivos no diretório de trabalho, sobrescrevendo arquivos com os mesmos nomes. Ele reabre cada saída tanto por caminho quanto por meio de um fluxo de memória. Para PPTX e ODP, ambas as rotas relatam o formato salvo. Para PPS, o carregamento por caminho relata `Pps`, enquanto o carregamento dos mesmos bytes sem nome de arquivo relata `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

A tabela a seguir resume a identificação do formato de origem para apresentações com extensões correspondentes:

| Formato salvo | SourceFormat a partir de caminho de arquivo | SourceFormat a partir de fluxo sem nome |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivamente | Igual ao caminho de arquivo |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivamente | Igual ao caminho de arquivo |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivamente | Igual ao caminho de arquivo |
| ODP, OTP | `Odp`, `Otp` respectivamente | Igual ao caminho de arquivo |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Conteúdo legado PPS/POT é normalizado para `Ppt` em fluxos sem nome. A tabela descreve a identificação de formato, não a preservação de todos os recursos da apresentação durante a conversão.

## **FAQ**

**Salvar em ODP altera o formato de origem de uma apresentação carregada de PPTX?**

Não. A instância existente ainda relata `Pptx`. Uma instância carregada a partir do ODP salvo relata `Odp`.

**Um fluxo pode sempre distinguir uma apresentação legada, um slideshow e um modelo?**

Não. PPT, PPS e POT compartilham o formato binário. Mantenha o nome de arquivo ou metadados de subtipo separadamente quando essa distinção for necessária.

**Qual API devo usar se a apresentação já estiver carregada?**

Leia [Presentation::get_SourceFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_sourceformat/). Use [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationfactory/getpresentationinfo/) para inspeção antes do carregamento.