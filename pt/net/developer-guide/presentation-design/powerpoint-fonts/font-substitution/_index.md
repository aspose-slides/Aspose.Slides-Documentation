---
title: Configurar substituição de fontes em apresentações em .NET
linktitle: Substituição de fontes
type: docs
weight: 70
url: /pt/net/font-substitution/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- trocar fonte
- substituição de fonte
- regra de substituição
- regra de troca
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Configure regras de substituição de fontes e inspecione as fontes substituídas no Aspose.Slides para .NET ao renderizar ou converter apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

A substituição de fonte permite que o Aspose.Slides use uma fonte disponível no lugar de uma fonte que não pode ser acessada quando uma apresentação é renderizada ou convertida. A substituição afeta a saída renderizada; ela não altera a fonte atribuída ao conteúdo da apresentação.

Você pode definir a fonte a ser usada quando uma fonte específica não estiver disponível e pode inspecionar as substituições que o Aspose.Slides fará durante a renderização. Isso ajuda a manter a saída consistente em ambientes com fontes instaladas diferentes.

## **Obter substituições de fontes**

Use o método [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getsubstitutions/) para determinar quais fontes serão substituídas quando a apresentação for renderizada. O método retorna objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsubstitutioninfo/) que identificam os nomes das fontes originais e substituídas.

O exemplo C# a seguir lista todas as substituições de fontes para uma apresentação:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Obter substituições de fontes para slides selecionados**

Use a sobrecarga [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getsubstitutions/) com um argumento `int[] slides` para inspecionar apenas as substituições necessárias para renderizar slides específicos. Isso é útil quando você está renderizando ou exportando parte de uma apresentação, verificando uma grande apresentação incrementalmente, localizando slides que dependem de fontes indisponíveis, preparando um pacote mínimo de fontes para um servidor ou contêiner, ou diagnosticando diferenças de renderização sem processar slides não relacionados.

A matriz `slides` contém índices de slides baseados em 1: `1` identifica o primeiro slide. Em contraste, o indexador da coleção [Presentation.Slides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slides/pt/) é baseado em zero, de modo que o mesmo slide é acessado como `presentation.Slides[0]`. Tenha essa diferença em mente ao construir a matriz para evitar erros de deslocamento.

Chame a sobrecarga através da propriedade [Presentation.FontsManager](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/fontsmanager/). Ela retorna apenas as substituições determinadas durante a renderização dos slides selecionados. Cada resultado é um objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsubstitutioninfo/) contendo os nomes das fontes original e substituída. O resultado reflete o ambiente de fontes atual e [fontes carregadas externamente](/slides/pt/net/custom-font/). Regras de substituição armazenadas em um [IFontSubstRuleCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsubstrulecollection/) alteram a saída renderizada, mas não são refletidas no resultado.

A mesma substituição pode ser exigida por mais de um slide selecionado. Desduplique os resultados ao criar um inventário de fontes ou relatório de pré‑verificação. O exemplo a seguir relata cada substituição retornada e, em seguida, cria uma lista ordenada de mapeamentos de fontes exclusivos:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

A interface [IFontsManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/) oferece ambas as sobrecargas. Escolha uma de acordo com o escopo da operação de renderização:

| Sobrecarga | Quando usar |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getsubstitutions/) sem argumentos | Você precisa de substituições para toda a apresentação. |
| [GetSubstitutions](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getsubstitutions/) com `int[] slides` | Você precisa de substituições para um intervalo selecionado, verificação incremental ou exportação parcial. |

## **Definir regras de substituição de fontes**

Para especificar a fonte que o Aspose.Slides deve usar quando uma fonte de origem está indisponível:

1. Carregue a apresentação.  
2. Crie definições de fontes para as fontes de origem e substituta.  
3. Crie um [FontSubstRule](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsubstrule/) com a condição [WhenInaccessible](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsubstcondition/).  
4. Adicione a regra a uma [FontSubstRuleCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsubstrulecollection/).  
5. Atribua a coleção à propriedade [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. Renderize ou converta a apresentação.

O exemplo C# a seguir substitui `Arial` por `SomeRareFont` quando `SomeRareFont` está indisponível e, em seguida, renderiza o primeiro slide para verificar o resultado. A fonte substituta deve estar disponível para o Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Para uma mudança incondicional nas fontes usadas em toda a apresentação, veja [Substituição de fonte](/slides/pt/net/font-replacement/).
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes fazem parte do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas funcionam para texto normal quando o Aspose.Slides pode substituir uma fonte inacessível pela fonte disponível especificada por uma regra.

Equações do Office Math têm um requisito adicional. Se uma equação usar **Cambria Math**, o Aspose.Slides pode precisar exatamente dessa fonte para calcular e renderizar o layout da equação. Uma regra que substitui outra fonte matemática, como **STIX Two Math**, não pode substituir **Cambria Math** para esse fim, e a renderização ainda pode relatar que **Cambria Math** é necessária.

Para renderizar ou converter tal apresentação, torne **Cambria Math** disponível ao Aspose.Slides. Instale-a no sistema operacional ou carregue-a como uma [fonte externa](/slides/pt/net/custom-font/).

Essa limitação se aplica ao layout da equação. As regras de substituição descritas acima ainda se aplicam ao texto regular da apresentação.

## **Perguntas frequentes**

**Qual é a diferença entre substituição de fonte e substituição de fonte?**

A [Substituição de fonte](/slides/pt/net/font-replacement/) altera intencionalmente uma fonte por outra em toda a apresentação. A substituição de fonte seleciona uma fonte para a saída renderizada quando a condição configurada é atendida, como quando a fonte original não está disponível.

**Quando as regras de substituição são aplicadas?**

As regras participam da [sequência de seleção de fontes](/slides/pt/net/font-selection-sequence/) durante a renderização e conversão. Com `WhenInaccessible`, uma regra é usada somente quando o Aspose.Slides não pode acessar a fonte de origem.

**O que acontece quando uma fonte está ausente e nenhuma regra de substituição está configurada?**

O Aspose.Slides seleciona a fonte disponível mais próxima de acordo com seu processo de seleção de fontes. O resultado depende das fontes disponíveis no ambiente de tempo de execução.

**Posso carregar fontes externas para evitar a substituição?**

Sim. Você pode [carregar fontes externas](/slides/pt/net/custom-font/) para que o Aspose.Slides as use durante a renderização e conversão.

**O Aspose distribui fontes com a biblioteca?**

Não. Você é responsável por fornecer as fontes e cumprir suas licenças.

**Os resultados de substituição podem diferir entre Windows, Linux e macOS?**

Sim. Fontes instaladas e locais de pesquisa de fontes diferem por sistema operacional, de modo que uma fonte disponível em uma máquina pode exigir substituição em outra.

**Como posso tornar a seleção de fontes consistente em conversões em lote?**

Use os mesmos arquivos e versões de fontes em cada máquina ou contêiner, [carregue as fontes externas necessárias](/slides/pt/net/custom-font/), e [incorpore fontes](/slides/pt/net/embedded-font/) quando as licenças permitirem. Você também pode chamar [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/getsubstitutions/) antes da exportação para identificar substituições inesperadas.