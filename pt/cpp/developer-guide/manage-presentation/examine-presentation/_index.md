---
title: "Recuperar e atualizar informações da apresentação em C++"
linktitle: "Informações da apresentação"
type: docs
weight: 30
url: /pt/cpp/examine-presentation/
keywords:
- "formato de apresentação"
- "propriedades da apresentação"
- "propriedades do documento"
- "obter propriedades"
- "ler propriedades"
- "alterar propriedades"
- "modificar propriedades"
- "atualizar propriedades"
- "examinar PPTX"
- "examinar PPT"
- "examinar ODP"
- "PowerPoint"
- "OpenDocument"
- "apresentação"
- "C++"
- "Aspose.Slides"
description: "Explore slides, estrutura e metadados em apresentações PowerPoint e OpenDocument usando C++ para obter insights mais rápidos e auditorias de conteúdo mais inteligentes."
---
## **Visão geral**

Aspose.Slides pode identificar o formato de uma apresentação e ler seus metadados de documento sem criar um modelo de objeto de apresentação completo. Isso é útil quando você precisa classificar arquivos, criar um inventário ou inspecionar propriedades antes de decidir se deve carregar e processar o conteúdo da apresentação.

Este artigo demonstra a inspeção leve através de [PresentationFactory](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationfactory/) e [IPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/), bem como atualizações direcionadas através de [IDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/).

## **Verificar o formato de uma apresentação**

Se você já tem uma apresentação carregada, consulte [Determinar o formato original da apresentação](/slides/pt/cpp/detect-presentation-source-format/) para detecção após o carregamento e as limitações dos fluxos legados PPT, PPS e POT.

Use [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) para inspecionar um arquivo sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/). O método [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/get_loadformat/) relata o formato detectado, como PPTX, PPT ou ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Criar um inventário leve de apresentações**

Quando você processa muitos arquivos de apresentação, pode precisar de um inventário compacto para validação, indexação ou um sistema de gerenciamento de documentos. Nesse cenário, use [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) para obter um objeto [IPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/) e, em seguida, chame [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) para ler os metadados do documento. Essa abordagem não cria uma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) nem exige que você percorra o modelo completo de objeto da apresentação.

As propriedades estendidas expostas por [IDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/) fornecem os seguintes valores de inventário:

| Método | Valor do inventário |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_slides/) | Número total de slides. |
| [get_HiddenSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Número de slides ocultos. |
| [get_Notes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_notes/) | Número de slides que contêm notas. |
| [get_Paragraphs](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Número total de parágrafos, quando disponível. |
| [get_Words](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_words/) | Número total de palavras. |
| [get_MultimediaClips](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Número total de clipes de áudio e vídeo. |

O exemplo a seguir lê esses valores sem criar um objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e imprime um inventário compacto. Ele também combina [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_headingpairs/) com [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) para exibir grupos de conteúdo como fontes, temas e títulos de slides.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Cada [IHeadingPair](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iheadingpair/) fornece um nome de grupo por meio de [IHeadingPair::get_Name](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iheadingpair/get_name/) e o número de itens nesse grupo por meio de [IHeadingPair::get_Count](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) devolve um array plano e ordenado, portanto consuma o número de títulos consecutivos especificados por cada par de cabeçalho.

### **Metadados armazenados e limitações de formato**

As propriedades de inventário retornadas por [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) refletem os metadados disponíveis no documento de origem. Aspose.Slides não carrega e percorre o modelo de objeto da apresentação para recalcular esses valores para essa chamada. Propriedades ausentes são representadas por valores padrão, e valores armazenados podem estar desatualizados se a aplicação que salvou o arquivo pela última vez não atualizou suas propriedades de documento.

- **PPTX:** O formato fornece propriedades de documento estendidas para contagens de slide, nota, slide oculto, parágrafo, palavra e multimídia, bem como pares de cabeçalhos e títulos de partes. A disponibilidade depende de quais propriedades foram gravadas pelo produtor do documento.
- **PPT:** O formato binário pode armazenar propriedades resumidas correspondentes. Se uma propriedade estiver ausente ou não for atualizada pelo produtor do documento, Aspose.Slides retorna seu valor armazenado ou padrão em vez de calculá‑lo a partir dos slides.
- **ODP:** Os metadados OpenDocument fornecem estatísticas gerais do documento, como contagens de página, parágrafo e palavra, mas esses valores não correspondem a todas as propriedades estendidas específicas do PowerPoint. Metadados de slide oculto, slide de notas, multimídia, pares de cabeçalhos e títulos de partes podem estar indisponíveis, e as propriedades de inventário podem retornar valores padrão. Não trate um valor zero ou um array vazio como prova autoritativa de que o conteúdo correspondente está ausente.

Use a abordagem de metadados leves para inventários e verificações preliminares. Carregue a apresentação e inspecione seu modelo de objeto ao vivo quando o resultado precisar refletir alterações em memória ou quando for necessário verificar o conteúdo real da apresentação.

## **Atualizar propriedades da apresentação**

As propriedades retornadas por [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) também podem ser alteradas sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/). Aplique as alterações com [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) e, em seguida, grave a apresentação vinculada com [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

A imagem a seguir mostra as propriedades originais do documento da apresentação PowerPoint.

![Propriedades originais do documento da apresentação PowerPoint](input_properties.png)

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

A imagem a seguir mostra as propriedades atualizadas do documento da apresentação PowerPoint.

![Propriedades atualizadas do documento da apresentação PowerPoint](output_properties.png)

## **Links úteis**

Para verificações de segurança relacionadas e configurações de proteção, consulte os artigos a seguir:

- [Apresentações protegidas por senha](/slides/pt/cpp/password-protected-presentation/)
- [Apresentações protegidas contra gravação](/slides/pt/cpp/write-protected-presentation/)

## **Perguntas frequentes**

**Como posso verificar se as fontes estão incorporadas e quais são?**

Carregue a apresentação e use [Presentation::get_FontsManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_fontsmanager/). Chame [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/getembeddedfonts/) para obter as fontes incorporadas e [FontsManager::GetFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/getfonts/) para obter as fontes usadas pela apresentação. Compare os dois resultados para encontrar fontes que são necessárias para renderização, mas não estão incorporadas.

**Como posso rapidamente saber se o arquivo tem slides ocultos e quantos?**

Quando os metadados armazenados do documento são suficientes, leia [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) através de [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) e [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Isso é adequado para um inventário leve. Se a apresentação foi modificada em memória, os metadados armazenados podem estar ausentes ou desatualizados, ou se precisar verificar valores ao vivo, itere por [Presentation::get_Slides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_slides/) e inspecione o método [Slide::get_Hidden](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slide/get_hidden/) de cada slide.

**Posso detectar se um tamanho de slide personalizado e orientação são usados, e se diferem dos padrões?**

Sim. Carregue a apresentação e leia [Presentation::get_SlideSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_slidesize/). Inspecione [ISlideSize::get_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidesize/get_size/) e [ISlideSize::get_Orientation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidesize/get_orientation/) para comparar as configurações atuais com o preset e as dimensões esperadas.

**Existe uma maneira rápida de ver se os gráficos referenciam fontes de dados externas?**

Sim. Localize cada [Chart](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chart/) e inspecione [ChartData::get_DataSourceType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Para uma pasta de trabalho externa, leia [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). O tipo de fonte de dados e o caminho identificam uma referência externa, mas verificar se o destino está disponível requer uma verificação de recurso separada.

**Como posso avaliar slides 'pesados' que podem desacelerar a renderização ou exportação em PDF?**

Não há uma única propriedade de complexidade. Percorra [Presentation::get_Slides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_slides/) e a coleção de [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseslide/get_shapes/) de cada slide. Use contagens de formas e a presença de imagens grandes, efeitos, animações ou multimídia como sinais de triagem, e meça uma renderização ou exportação representativa antes de considerar um slide como um gargalo de desempenho confirmado.