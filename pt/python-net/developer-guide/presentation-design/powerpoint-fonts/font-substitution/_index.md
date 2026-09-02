---
title: Configurar substituição de fonte em apresentações com Python
linktitle: Substituição de Fonte
type: docs
weight: 70
url: /pt/python-net/font-substitution/
keywords:
- fonte
- fonte substituta
- substituição de fonte
- substituir fonte
- substituição de fonte
- regra de substituição
- regra de substituição
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Configure regras de substituição de fonte e inspecione fontes substituídas no Aspose.Slides para Python via .NET ao renderizar ou converter apresentações PowerPoint e OpenDocument."
---
## **Visão Geral**

A substituição de fontes permite que o Aspose.Slides use uma fonte disponível no lugar de uma fonte que não pode ser acessada quando uma apresentação é renderizada ou convertida. A substituição afeta a saída renderizada; ela não altera a fonte atribuída ao conteúdo da apresentação.

Você pode definir a fonte a ser usada quando uma fonte específica não está disponível e pode inspecionar as substituições que o Aspose.Slides fará durante a renderização. Isso ajuda a manter a saída consistente em ambientes com diferentes fontes instaladas.

## **Obter Substituições de Fontes**

Use o método [FontsManager.get_substitutions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_substitutions/) para determinar quais fontes serão substituídas quando a apresentação for renderizada. O método retorna objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsubstitutioninfo/) que identificam os nomes da fonte original e da fonte substituta.

O exemplo Python a seguir lista todas as substituições de fontes para uma apresentação:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Obter Substituições de Fontes para Slides Selecionados**

Use [FontsManager.get_substitutions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_substitutions/) com uma lista de índices de slides para inspecionar apenas as substituições necessárias para renderizar slides específicos. Isso é útil quando você está renderizando ou exportando parte de uma apresentação, verificando incrementalmente uma apresentação grande, localizando slides que dependem de fontes indisponíveis, preparando um pacote mínimo de fontes para um servidor ou contêiner, ou diagnosticando diferenças de renderização sem processar slides não relacionados.

A lista contém índices de slides baseados em 1: `1` identifica o primeiro slide. Em contraste, a coleção [Presentation.slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slides/pt/) usa índice baseado em 0, de modo que o mesmo slide é acessado como `presentation.slides[0]`. Lembre‑se dessa diferença ao construir a lista para evitar erros de deslocamento.

Chame o método através da propriedade [Presentation.fonts_manager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/fonts_manager/). Ele retorna apenas as substituições determinadas ao renderizar os slides selecionados. Cada resultado é um objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsubstitutioninfo/) contendo os nomes da fonte original e da fonte substituta. O resultado reflete o ambiente de fontes atual, regras de fallback configuradas, regras de substituição armazenadas em uma [IFontSubstRuleCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ifontsubstrulecollection/) e [fonts carregados externamente](/slides/pt/python-net/custom-font/).

A mesma substituição pode ser exigida por mais de um slide selecionado. Desduplique os resultados ao criar um inventário de fontes ou um relatório de pré‑voo. O exemplo a seguir relata cada substituição retornada e, em seguida, cria uma lista ordenada de mapeamentos de fontes únicos:

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

A classe [FontsManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/) fornece ambas as formas do método. Escolha uma de acordo com o escopo da operação de renderização:

| Method call | Use it when |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | Você precisa de substituições para a apresentação inteira. |
| [get_substitutions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | Você precisa de substituições para um intervalo selecionado, verificação incremental ou exportação parcial. |

## **Definir Regras de Substituição de Fontes**

Para especificar a fonte que o Aspose.Slides deve usar quando uma fonte de origem não está disponível:

1. Carregue a apresentação.  
2. Crie definições de fonte para as fontes de origem e substituta.  
3. Crie um [FontSubstRule](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsubstrule/) com a condição [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsubstcondition/).  
4. Adicione a regra a uma [FontSubstRuleCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsubstrulecollection/).  
5. Atribua a coleção à propriedade [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).  
6. Renderize ou converta a apresentação.

O exemplo Python a seguir substitui `Arial` por `SomeRareFont` quando `SomeRareFont` não está disponível e, em seguida, renderiza o primeiro slide para verificar o resultado. A fonte substituta deve estar disponível para o Aspose.Slides.

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

{{% alert color="info" title="Note" %}}
Para uma alteração incondicional das fontes usadas em toda a apresentação, consulte [Substituição de Fonte](/slides/pt/python-net/font-replacement/).
{{% /alert %}}

## **Limitações para Fontes de Equações Matemáticas**

As regras de substituição de fontes fazem parte do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas funcionam para texto normal quando o Aspose.Slides pode substituir uma fonte inacessível pela fonte disponível especificada por uma regra.

Equações do Office Math têm um requisito adicional. Se uma equação usar **Cambria Math**, o Aspose.Slides pode precisar exatamente dessa fonte para calcular e renderizar o layout da equação. Uma regra que substitui outra fonte matemática, como **STIX Two Math**, não pode substituir **Cambria Math** para esse propósito, e a renderização ainda pode indicar que **Cambria Math** é necessária.

Para renderizar ou converter uma apresentação desse tipo, torne **Cambria Math** disponível ao Aspose.Slides. Instale-a no sistema operacional ou carregue-a como uma [fonte externa](/slides/pt/python-net/custom-font/).

Essa limitação aplica‑se ao layout de equações. As regras de substituição descritas acima continuam a ser aplicadas ao texto normal da apresentação.

## **Perguntas frequentes**

**Qual é a diferença entre troca de fonte e substituição de fonte?**  
[Font replacement](/slides/pt/python-net/font-replacement/) altera intencionalmente uma fonte por outra em toda a apresentação. A substituição de fonte seleciona uma fonte para a saída renderizada quando a condição configurada é atendida, como quando a fonte original está indisponível.

**Quando as regras de substituição são aplicadas?**  
As regras participam da [sequência de seleção de fontes](/slides/pt/python-net/font-selection-sequence/) durante a renderização e conversão. Com `WHEN_INACCESSIBLE`, uma regra é usada apenas quando o Aspose.Slides não pode acessar a fonte de origem.

**O que acontece quando uma fonte está faltando e nenhuma regra de substituição está configurada?**  
O Aspose.Slides seleciona a fonte disponível mais próxima de acordo com seu processo de seleção de fontes. O resultado depende das fontes disponíveis no ambiente de execução.

**Posso carregar fontes externas para evitar substituição?**  
Sim. Você pode [carregar fontes externas](/slides/pt/python-net/custom-font/) para que o Aspose.Slides as utilize durante a renderização e conversão.

**A Aspose distribui fontes com a biblioteca?**  
Não. Você é responsável por fornecer as fontes e cumprir suas licenças.

**Os resultados de substituição podem diferir entre Windows, Linux e macOS?**  
Sim. Fontes instaladas e locais de pesquisa de fontes variam por sistema operacional, de modo que uma fonte disponível em uma máquina pode exigir substituição em outra.

**Como posso tornar a seleção de fontes consistente em conversões em lote?**  
Use os mesmos arquivos de fonte e versões em todas as máquinas ou contêineres, [carregue as fontes externas necessárias](/slides/pt/python-net/custom-font/) e [incorpore fontes](/slides/pt/python-net/embedded-font/) quando as licenças permitirem. Você também pode chamar [FontsManager.get_substitutions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsmanager/get_substitutions/) antes da exportação para identificar substituições inesperadas.