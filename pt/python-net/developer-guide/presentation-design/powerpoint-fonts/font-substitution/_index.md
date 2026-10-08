---
title: Configurar substituição de fontes em apresentações com Python
linktitle: Substituição de fontes
type: docs
weight: 70
url: /pt/python-net/font-substitution/
keywords:
- fonte
- fonte substituta
- substituição de fonte
- trocar fonte
- substituição de fonte
- regra de substituição
- regra de troca
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Configure regras de substituição de fontes e inspecione fontes substituídas no Aspose.Slides para Python via .NET ao renderizar ou converter apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

A substituição de fontes permite que Aspose.Slides use uma fonte disponível no lugar de uma fonte que não pode ser acessada quando uma apresentação é renderizada ou convertida. A substituição afeta a saída renderizada; ela não altera a fonte atribuída ao conteúdo da apresentação.

Você pode definir a fonte a ser usada quando uma fonte específica não está disponível e pode inspecionar as substituições que o Aspose.Slides fará durante a renderização. Isso ajuda a manter a saída consistente em ambientes com diferentes fontes instaladas.

Se uma fonte está disponível mas não possui um tipo de negrito dedicado, veja [Manipular fontes sem um tipo de negrito dedicado](/slides/pt/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Essa seção explica como rasterizar o texto afetado durante a exportação para PDF e as consequências para seleção de texto, pesquisa e dimensionamento.

## **Obter substituições de fontes**

Use o método [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) para determinar quais fontes serão substituídas quando a apresentação for renderizada. O método retorna objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) que identificam os nomes das fontes originais e substituídas.

O exemplo Python a seguir lista todas as substituições de fontes para uma apresentação:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Obter substituições de fontes para slides selecionados**

Use [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) com uma lista de índices de slides para inspecionar apenas as substituições necessárias para renderizar slides específicos. Isso é útil quando você está renderizando ou exportando parte de uma apresentação, verificando uma grande apresentação incrementalmente, localizando slides que dependem de fontes indisponíveis, preparando um pacote mínimo de fontes para um servidor ou contêiner, ou diagnosticando diferenças de renderização sem processar slides não relacionados.

A lista contém índices de slides baseados em 1: `1` identifica o primeiro slide. Em contraste, a coleção [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) é baseada em zero, de modo que o mesmo slide é acessado como `presentation.slides[0]`. Mantenha essa diferença em mente ao montar a lista para evitar erros de deslocamento.

Chame o método através da propriedade [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). Ele retorna apenas as substituições determinadas durante a renderização dos slides selecionados. Cada resultado é um objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) contendo os nomes das fontes originais e substituídas. O resultado reflete o ambiente de fontes atual, as regras de fallback configuradas, as regras de substituição armazenadas em uma [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), e [fontes carregadas externamente](/slides/pt/python-net/custom-font/).

A mesma substituição pode ser necessária para mais de um slide selecionado. Desduplicar os resultados ao criar um inventário de fontes ou relatório de pré‑voo. O exemplo a seguir relata cada substituição retornada e, em seguida, cria uma lista ordenada de mapeamentos de fontes únicos:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

A classe [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) fornece ambas as formas do método. Escolha uma de acordo com o escopo da operação de renderização:

| Chamada do método | Use quando |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) sem argumentos | Você precisa de substituições para a apresentação inteira. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) com uma lista de índices de slides | Você precisa de substituições para um intervalo selecionado, verificação incremental ou exportação parcial. |

## **Definir regras de substituição de fontes**

Para especificar a fonte que o Aspose.Slides deve usar quando uma fonte de origem está indisponível:

1. Carregue a apresentação.
2. Crie definições de fontes para as fontes de origem e substituta.
3. Crie um [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) com a condição [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/).
4. Adicione a regra a uma [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).
5. Atribua a coleção à propriedade [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Renderize ou converta a apresentação.

O exemplo Python a seguir substitui `Arial` por `SomeRareFont` quando `SomeRareFont` está indisponível e, em seguida, renderiza o primeiro slide para verificar o resultado. A fonte substituta deve estar disponível para o Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Nota" %}}
Para uma alteração incondicional nas fontes usadas em toda a apresentação, veja [Substituição de fontes](/slides/pt/python-net/font-replacement/).
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes fazem parte do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas funcionam para texto comum quando o Aspose.Slides pode substituir uma fonte inacessível pela fonte disponível especificada por uma regra.

As equações Office Math têm um requisito adicional. Se uma equação usa **Cambria Math**, o Aspose.Slides pode precisar dessa fonte exata para calcular e renderizar o layout da equação. Uma regra que substitui outra fonte matemática, como **STIX Two Math**, não pode substituir **Cambria Math** para esse fim, e a renderização ainda pode indicar que **Cambria Math** é necessária.

Para renderizar ou converter essa apresentação, disponibilize **Cambria Math** para o Aspose.Slides. Instale-a no sistema operacional ou carregue-a como uma [fonte externa](/slides/pt/python-net/custom-font/).

Essa limitação se aplica ao layout da equação. As regras de substituição descritas acima continuam válidas para o texto regular da apresentação.

## **Perguntas frequentes**

**Qual é a diferença entre substituição de fontes e substituição de fontes?**

[Substituição de fontes](/slides/pt/python-net/font-replacement/) altera intencionalmente uma fonte por outra em toda a apresentação. A substituição de fontes seleciona uma fonte para a saída renderizada quando a condição configurada é atendida, como quando a fonte original está indisponível.

**Quando as regras de substituição são aplicadas?**

As regras participam da [sequência de seleção de fontes](/slides/pt/python-net/font-selection-sequence/) durante a renderização e conversão. Com `WHEN_INACCESSIBLE`, uma regra é usada apenas quando o Aspose.Slides não consegue acessar a fonte de origem.

**O que acontece quando uma fonte está ausente e nenhuma regra de substituição está configurada?**

O Aspose.Slides seleciona a fonte disponível mais próxima de acordo com seu processo de seleção de fontes. O resultado depende das fontes disponíveis no ambiente de tempo de execução.

**Posso carregar fontes externas para evitar substituição?**

Sim. Você pode [carregar fontes externas](/slides/pt/python-net/custom-font/) para que o Aspose.Slides as use durante a renderização e conversão.

**A Aspose distribui fontes com a biblioteca?**

Não. Você é responsável por fornecer as fontes e cumprir suas licenças.

**Os resultados de substituição podem diferir entre Windows, Linux e macOS?**

Sim. As fontes instaladas e os locais de busca de fontes diferem entre sistemas operacionais, de modo que uma fonte disponível em uma máquina pode exigir substituição em outra.

**Como tornar a seleção de fontes consistente em conversões em lote?**

Use os mesmos arquivos e versões de fontes em todas as máquinas ou contêineres, [carregue as fontes externas necessárias](/slides/pt/python-net/custom-font/), e [incorpore fontes](/slides/pt/python-net/embedded-font/) quando a licença permitir. Você também pode chamar [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) antes da exportação para identificar substituições inesperadas.