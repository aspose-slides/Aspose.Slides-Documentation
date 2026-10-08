---
title: Configurar substituição de fontes em apresentações em C++
linktitle: Substituição de Fontes
type: docs
weight: 70
url: /pt/cpp/font-substitution/
keywords:
- fonte
- fonte substituta
- substituição de fonte
- substituir fonte
- troca de fonte
- regra de substituição
- regra de troca
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Configure regras de substituição de fontes e inspeccione fontes substituídas no Aspose.Slides para C++ ao renderizar ou converter apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use uma fonte disponível no lugar de uma fonte que não pode ser acessada quando uma apresentação é renderizada ou convertida. A substituição afeta a saída renderizada; não altera a fonte atribuída ao conteúdo da apresentação.

Você pode definir a fonte a ser usada quando uma fonte específica não está disponível e pode inspecionar as substituições que o Aspose.Slides fará durante a renderização. Isso ajuda a manter a saída consistente em ambientes com diferentes fontes instaladas.

Se uma fonte está disponível, mas não possui um tipo de negrito dedicado, veja [Manipular fontes sem um tipo de negrito dedicado](/slides/pt/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Essa seção explica como rasterizar o texto afetado durante a exportação para PDF e as consequências para seleção de texto, pesquisa e dimensionamento.

## **Obter substituições de fontes**

Use o método [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) para determinar quais fontes serão substituídas quando a apresentação for renderizada. O método retorna objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) que identificam os nomes das fontes originais e substituídas.

O exemplo C++ a seguir lista todas as substituições de fontes para uma apresentação:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Obter substituições de fontes para slides selecionados**

Use a sobrecarga do [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) com um argumento `System::ArrayPtr<int32_t> slides` para inspecionar apenas as substituições necessárias para renderizar slides específicos. Isso é útil quando você está renderizando ou exportando parte de uma apresentação, verificando uma grande apresentação de forma incremental, localizando slides que dependem de fontes indisponíveis, preparando um pacote mínimo de fontes para um servidor ou contêiner, ou diagnosticando diferenças de renderização sem processar slides não relacionados.

A matriz `slides` contém índices de slides baseados em 1: `1` identifica o primeiro slide. Em contraste, o método [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) usa um índice baseado em zero, de modo que o mesmo slide é acessado como `presentation->get_Slide(0)`. Mantenha essa diferença em mente ao construir a matriz para evitar erros de deslocamento.

Chame a sobrecarga através do método [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/). Ele retorna apenas as substituições determinadas durante a renderização dos slides selecionados. Cada resultado é um objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) contendo os nomes das fontes original e substituta. O resultado reflete o ambiente de fontes atual, as regras de fallback configuradas, as regras de substituição armazenadas em uma [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/), e [fontes carregadas externamente](/slides/pt/cpp/custom-font/).

A mesma substituição pode ser necessária em mais de um slide selecionado. Desduplicar os resultados ao criar um inventário de fontes ou um relatório de pré‑verificação. O exemplo a seguir relata cada substituição retornada e, em seguida, cria uma lista ordenada de mapeamentos de fontes exclusivos:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

A interface [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) fornece ambas as sobrecargas. Escolha uma de acordo com o escopo da operação de renderização:

| Sobrecarga | Quando usar |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) sem argumentos | Você precisa de substituições para toda a apresentação. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) com `System::ArrayPtr<int32_t> slides` | Você precisa de substituições para um intervalo selecionado, verificação incremental ou exportação parcial. |

## **Definir regras de substituição de fontes**

Para especificar a fonte que o Aspose.Slides deve usar quando uma fonte de origem está indisponível:

1. Carregue a apresentação.
2. Crie definições de fonte para as fontes de origem e substituta.
3. Crie um [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) com a condição [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/).
4. Adicione a regra a uma [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/).
5. Atribua a coleção usando o método [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Renderize ou converta a apresentação.

O exemplo C++ a seguir substitui `Arial` por `SomeRareFont` quando `SomeRareFont` está indisponível e, em seguida, renderiza o primeiro slide para verificar o resultado. A fonte substituta deve estar disponível para o Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Para uma alteração incondicional nas fontes usadas em toda a apresentação, veja [Substituição de fontes](/slides/pt/cpp/font-replacement/).
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes fazem parte do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas funcionam para texto normal quando o Aspose.Slides pode substituir uma fonte inacessível pela fonte disponível especificada por uma regra.

Equações do Office Math têm um requisito adicional. Se uma equação usa **Cambria Math**, o Aspose.Slides pode precisar dessa fonte exata para calcular e renderizar o layout da equação. Uma regra que substitui outra fonte matemática, como **STIX Two Math**, não pode substituir **Cambria Math** para esse fim, e a renderização ainda pode relatar que **Cambria Math** é necessária.

Para renderizar ou converter tal apresentação, torne **Cambria Math** disponível ao Aspose.Slides. Instale-a no sistema operacional ou carregue-a como uma [fonte externa](/slides/pt/cpp/custom-font/).

Essa limitação se aplica ao layout da equação. As regras de substituição descritas acima ainda se aplicam ao texto regular da apresentação.

## **Perguntas frequentes**

**Qual é a diferença entre substituição de fontes e substituição de fontes (replacement)?**  
[Substituição de fontes](/slides/pt/cpp/font-replacement/) altera intencionalmente uma fonte por outra em toda a apresentação. A substituição de fontes seleciona uma fonte para a saída renderizada quando a condição configurada é atendida, como quando a fonte original está indisponível.

**Quando as regras de substituição são aplicadas?**  
As regras participam da [sequência de seleção de fontes](/slides/pt/cpp/font-selection-sequence/) durante a renderização e conversão. Com `WhenInaccessible`, uma regra é usada apenas quando o Aspose.Slides não consegue acessar a fonte de origem.

**O que acontece quando uma fonte está ausente e nenhuma regra de substituição está configurada?**  
O Aspose.Slides seleciona a fonte disponível mais próxima de acordo com seu processo de seleção de fontes. O resultado depende das fontes disponíveis no ambiente de tempo de execução.

**Posso carregar fontes externas para evitar a substituição?**  
Sim. Você pode [carregar fontes externas](/slides/pt/cpp/custom-font/) para que o Aspose.Slides as use durante a renderização e conversão.

**A Aspose distribui fontes com a biblioteca?**  
Não. Você é responsável por fornecer as fontes e por cumprir suas licenças.

**Os resultados de substituição podem diferir entre Windows, Linux e macOS?**  
Sim. As fontes instaladas e os locais de pesquisa de fontes diferem por sistema operacional, de modo que uma fonte disponível em uma máquina pode precisar de substituição em outra.

**Como garantir que a seleção de fontes seja consistente em conversões em lote?**  
Use os mesmos arquivos e versões de fontes em todas as máquinas ou contêineres, [carregue as fontes externas necessárias](/slides/pt/cpp/custom-font/), e [incorpore fontes](/slides/pt/cpp/embedded-font/) quando a licença permitir. Você também pode chamar [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) antes da exportação para identificar substituições inesperadas.