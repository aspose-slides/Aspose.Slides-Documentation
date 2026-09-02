---
title: Mesclar apresentações de forma eficiente em C++
linktitle: Mesclar apresentações
type: docs
weight: 40
url: /pt/cpp/merge-presentation/
keywords:
- mesclar PowerPoint
- mesclar apresentações
- mesclar slides
- mesclar PPT
- mesclar PPTX
- mesclar ODP
- combinar PowerPoint
- combinar apresentações
- combinar slides
- combinar PPT
- combinar PPTX
- combinar ODP
- C++
- Aspose.Slides
description: "Aprenda como mesclar apresentações PowerPoint e OpenDocument em C++ clonando slides, controlando mestres e layouts, redimensionando o conteúdo dos slides, preservando seções e lidando com arquivos protegidos ou grandes."
---
## **Visão geral**

Aspose.Slides for C++ mescla apresentações clonando slides de um [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) para outro. A operação principal é [ISlideCollection::AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/), que pode preservar a formatação do slide de origem ou anexar o slide clonado a um mestre ou layout na apresentação de destino.

Este artigo cobre os fluxos de trabalho de mesclagem mais comuns:

- mesclar todos os slides preservando sua formatação original;
- mesclar slides selecionados;
- aplicar um mestre da apresentação de destino;
- aplicar um layout específico da apresentação de destino;
- normalizar tamanhos de slide diferentes antes da mesclagem;
- adicionar slides clonados a uma seção;
- mesclar várias apresentações em um fluxo de trabalho de ponta a ponta;
- tratar mestres, recursos, notas, comentários, mídia, fontes, senhas, arquivos grandes e questões de multithreading.

## **Como a clonagem de slides afeta mestres e layouts**

Um slide herda grande parte de sua aparência do layout e do mestre. Por esse motivo, a sobrecarga de clonagem que você escolhe determina como o slide mesclado é integrado à apresentação de destino.

Use [ISlideCollection::AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) de uma destas maneiras:

- `AddClone(sourceSlide)` — preserva o layout e a formatação do slide de origem. Quando necessário, o mestre de origem pode ser clonado automaticamente para a apresentação de destino. Aspose.Slides rastreia mestres clonados automaticamente para que slides repetidos que utilizem o mesmo mestre de origem não causem clonagem repetida desse mestre.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — anexa o slide clonado a um [IMasterSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/) de destino específico. Aspose.Slides procura um layout correspondente sob esse mestre por tipo ou nome do layout.
- `AddClone(sourceSlide, destinationLayout)` — anexa o slide clonado diretamente a um [ILayoutSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/) de destino específico.

O mestre ou layout passado para uma sobrecarga `AddClone` deve pertencer à **apresentação de destino**, não à apresentação de origem.

## **Mesclar apresentações inteiras e preservar a formatação de origem**

A mesclagem mais simples copia cada slide da apresentação de origem para a apresentação de destino. Essa é a escolha apropriada quando os slides importados devem manter seu tema, mestre e relacionamentos de layout originais.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

A apresentação resultante pode conter vários mestres quando a origem e o destino usam designs diferentes. Isso é esperado quando a formatação de origem é preservada intencionalmente.

## **Mesclar slides selecionados**

Você não precisa clonar todos os slides. O exemplo a seguir importa apenas os índices de slides selecionados da apresentação de origem.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Valide os índices de slides antes de clonar quando eles vierem de entrada do usuário ou de configuração externa.

## **Mesclar slides usando um mestre de destino**

Use a sobrecarga [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) quando os slides importados devem seguir um mestre que já pertence à apresentação de destino.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides seleciona um layout apropriado sob o mestre especificado correspondendo ao tipo ou nome do layout de origem. Se nenhum layout adequado existir e `allowCloneMissingLayout` for `true`, o layout de origem é clonado para que o slide possa ser adicionado. Se for `false`, uma [PptxEditException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/details_pptxeditexception/) é lançada.

Use `false` quando quiser que a mesclagem falhe em vez de introduzir um layout adicional no mestre de destino.

## **Mesclar slides usando um layout de destino específico**

Use a sobrecarga [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) quando souber exatamente qual layout de destino os slides importados devem usar.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Aplicar um layout de destino altera a relação de layout herdada; não redesenha o conteúdo do slide de origem. Se os layouts de origem e destino tiverem estruturas de marcadores diferentes, inspecione o resultado para confirmar que a formatação herdada e o comportamento dos marcadores são adequados.

## **Mesclar apresentações com tamanhos de slide diferentes**

Apresentações com dimensões de slide diferentes podem ser mescladas, mas clonar um slide em uma apresentação com outro tamanho de slide não redesenha automaticamente seu conteúdo para a nova tela. Formas podem aparecer deslocadas, escaladas inesperadamente ou fora da área visível do slide.

Uma abordagem prática é redimensionar a apresentação de origem antes de clonar. O método [SlideSize::SetSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidesize/setsize/) pode escalonar o conteúdo existente ao alterar as dimensões do slide. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidesizescaletype/) escala o conteúdo para caber no tamanho solicitado.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

O redimensionamento altera o objeto da apresentação de origem na memória. Se precisar da apresentação de origem original inalterada para outras operações, abra uma instância separada para a mesclagem.

## **Mesclar slides em uma seção de apresentação**

O loop básico de clonagem de slides não recria a hierarquia de seções da apresentação de origem. Se as seções forem importantes na saída, crie ou selecione seções na apresentação de destino e clone os slides nelas explicitamente com [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Os slides clonados são adicionados à seção de destino especificada. Para preservar várias seções de origem, recrie essas seções no destino e mapeie cada slide de origem para a seção de destino correspondente.

## **Mesclar várias apresentações com segurança**

O exemplo de ponta a ponta a seguir usa a primeira apresentação como destino, normaliza o tamanho do slide de cada origem adicional, mantém cada origem aberta apenas enquanto está sendo copiada e salva o arquivo final uma única vez.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Este é um ponto de partida útil para preservar a formatação de origem dos slides importados. Se sua saída deve usar um tema único de destino, substitua a chamada simples `AddClone(slide)` pela sobrecarga de mestre ou layout de destino apropriada mostrada anteriormente.

## **Considerações práticas**

### **Mestres, layouts e fidelidade de formatação**

A clonagem padrão de slides pode trazer automaticamente um mestre de origem necessário para a apresentação de destino. Aspose.Slides mantém um registro interno de mestres clonados automaticamente para evitar a clonagem repetida do mesmo mestre. Mestres clonados manualmente não são rastreados por esse registro, portanto evite pré-clonar mestres a menos que precise de controle explícito sobre a estrutura de mestres.

Não presuma que dois mestres ou layouts com o mesmo nome sejam visualmente equivalentes. Se um modelo corporativo deve controlar a aparência final, escolha um mestre ou layout de destino explicitamente e verifique o resultado após a mesclagem.

### **Notas e comentários**

Notas de apresentador e comentários de slide estão associados ao conteúdo do slide e são copiados quando um slide é clonado. Aspose.Slides também expõe APIs dedicadas para [presentation notes](https://docs.aspose.com/slides/pt/cpp/presentation-notes/) e [presentation comments](https://docs.aspose.com/slides/pt/cpp/presentation-comments/).

Se a formatação da página de notas for importante, verifique a apresentação mesclada porque mestres de notas são objetos ao nível da apresentação e podem diferir entre arquivos de origem. Para fluxos de revisão, também verifique os autores dos comentários e comentários em cadeia após combinar arquivos de diferentes autores ou modelos.

### **Imagens, áudio, vídeo, objetos OLE e links externos**

Slides podem referenciar recursos ao nível da apresentação, como imagens, áudio incorporado, vídeo incorporado e dados OLE. Clone o próprio slide em vez de copiar apenas suas formas visíveis para que Aspose.Slides mantenha os relacionamentos do slide com seus recursos.

Recursos incorporados e vinculados devem ser tratados de forma diferente. Um áudio, vídeo, objeto OLE ou hyperlink vinculado permanece dependente de seu destino externo; clonar um slide não transforma um link externo em conteúdo incorporado. Teste caminhos e URLs de recursos vinculados no ambiente onde a apresentação mesclada será aberta.

Aspose.Slides rastreia explicitamente mestres clonados automaticamente, mas isso não deve ser considerado uma garantia geral de que recursos binários idênticos de apresentações de origem não relacionadas serão sempre deduplicados. Se o tamanho do arquivo de saída for importante, inspecione o pacote mesclado e meça o resultado em vez de confiar em deduplicação implícita.

### **Fontes incorporadas e disponibilidade de fontes**

Fontes são gerenciadas ao nível da apresentação. Se a tipografia deve permanecer consistente entre máquinas, não presuma que clonar apenas slides garante que todas as fontes necessárias estejam disponíveis no ambiente de destino. Você pode inspecionar fontes incorporadas com [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontsmanager/getembeddedfonts/) e gerenciar a incorporação explicitamente conforme descrito em [Embed Fonts in Presentations](https://docs.aspose.com/slides/pt/cpp/embedded-font/).

Também verifique se tem permissão para incorporar as fontes usadas pelos arquivos de origem. Licenças de fontes podem restringir a incorporação.

### **Apresentações protegidas por senha**

Uma origem protegida por senha deve ser aberta com sucesso antes que seus slides possam ser clonados. Forneça a senha através de [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Abrir uma origem criptografada não aplica automaticamente a mesma proteção à apresentação de destino. Configure a proteção de saída separadamente quando necessário.

### **Apresentações grandes e uso de memória**

Apresentações grandes contendo imagens de alta resolução, áudio, vídeo ou outros objetos binários grandes podem consumir memória significativa. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) fornece controles para o tratamento de BLOBs e uso de arquivos temporários. Consulte [Manage Presentation BLOBs](https://docs.aspose.com/slides/pt/cpp/manage-blob/) para estratégias com arquivos grandes.

Para arquivos grandes, prefira carregar a partir de caminhos de arquivo quando possível, descarte cada apresentação de origem assim que ela for mesclada e evite salvar resultados intermediários repetidamente, a menos que o fluxo de trabalho exija pontos de verificação.

### **Segurança de threads**

Não carregue, modifique, salve ou clone a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) simultaneamente a partir de múltiplas threads. Mantenha cada instância de apresentação confinada a uma operação de mesclagem. Se paralelizar trabalhos independentes, use instâncias de apresentação independentes e siga as diretrizes de multithreading da [Aspose.Slides](https://docs.aspose.com/slides/pt/cpp/multithreading/).

## **FAQ**

**Como mantenho o design original de cada apresentação de origem?**

Use [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) sem fornecer um mestre ou layout de destino. Aspose.Slides pode clonar automaticamente o mestre de origem quando ele for necessário para o slide importado.

**Como faço os slides importados usarem o tema de destino?**

Use a sobrecarga que aceita um mestre de destino. Passe um mestre da apresentação de destino, não da origem. Aspose.Slides tentará mapear cada slide de origem para um layout adequado sob esse mestre.

**Quando devo usar um layout de destino específico em vez de um mestre de destino?**

Use um layout específico quando cada slide importado deve usar um layout conhecido. Use um mestre quando quiser que Aspose.Slides selecione entre os layouts daquele mestre com base no tipo ou nome do layout de origem.

**Apresentações com tamanhos de slide diferentes podem ser mescladas?**

Sim, mas o conteúdo do slide não é redesenhado automaticamente para as dimensões de destino. Redimensione a apresentação de origem primeiro quando precisar de posicionamento previsível, por exemplo com [SlideSize::SetSize](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidesize/setsize/) e [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidesizescaletype/).

**Posso mesclar apresentações PPT, PPTX e ODP em um único arquivo?**

Sim. Carregue cada apresentação de origem, clone os slides necessários em um destino e salve o destino em um formato de saída suportado. Como os formatos de apresentação não suportam exatamente o mesmo conjunto de recursos, verifique o conteúdo complexo após mesclagens entre formatos diferentes. Consulte [Supported File Formats](https://docs.aspose.com/slides/pt/cpp/supported-file-formats/).

**As seções de origem são preservadas automaticamente?**

Não por um loop básico que apenas clona slides. Recrie as seções necessárias no destino e use a sobrecarga de seção de [AddClone](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) quando a estrutura de seções precisar ser preservada.

**Notas do apresentador e comentários são preservados?**

Eles são copiados com o slide clonado. Para fluxos de trabalho que dependem da estilização do mestre de notas, autores de comentários ou dados de revisão em cadeia, verifique o resultado mesclado porque esses cenários envolvem estruturas ao nível da apresentação além do conteúdo ao nível do slide.

**O que acontece com áudio, vídeo, objetos OLE e hyperlinks?**

Conteúdos incorporados são transportados como parte dos relacionamentos de recursos do slide clonado. Links externos permanecem externos, portanto seus arquivos ou URLs de destino ainda precisam estar disponíveis após a mesclagem.

**Fontes incorporadas de cada origem são garantidas no resultado mesclado?**

Não dependa apenas da clonagem de slides para implantação de fontes. Inspecione as fontes incorporadas no destino e gerencie explicitamente a incorporação de fontes ou a disponibilidade de fontes externas quando a tipografia for importante.

**Como mesclro um arquivo protegido por senha?**

Abra-o com o [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/) correto e, em seguida, clone seus slides normalmente. A proteção de saída é configurada separadamente.

**Como devo lidar com apresentações muito grandes?**

Use a gestão de BLOBs quando objetos binários grandes dominarem o uso de memória, prefira o carregamento por caminho de arquivo para arquivos muito grandes, descarte rapidamente as apresentações de origem e salve o resultado final apenas quando necessário.

**Posso mesclar slides a partir de múltiplas threads?**

Não use a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) simultaneamente em múltiplas threads. Mantenha cada operação de mesclagem isolada em suas próprias instâncias de apresentação.