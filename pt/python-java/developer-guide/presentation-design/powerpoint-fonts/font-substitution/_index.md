---
title: Configurar Substituição de Fonte em Apresentações Usando Python via Java
linktitle: Substituição de Fonte
type: docs
weight: 70
url: /pt/python-java/font-substitution/
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
- Java
- Aspose.Slides
description: "Configure regras de substituição de fonte e inspeccione fontes substituídas no Aspose.Slides para Python via Java ao renderizar ou converter apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use uma fonte disponível no lugar de uma fonte que não pode ser acessada quando uma apresentação é renderizada ou convertida. A substituição afeta a saída renderizada; não altera a fonte atribuída ao conteúdo da apresentação.

Você pode definir a fonte a ser usada quando uma fonte específica estiver indisponível e pode inspecionar as substituições que o Aspose.Slides fará durante a renderização. Isso ajuda a manter a saída consistente em ambientes com fontes instaladas diferentes.

## **Obter substituições de fontes**

Use o método [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#getSubstitutions) para determinar quais fontes serão substituídas quando a apresentação for renderizada. O método retorna objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsubstitutioninfo/) que identificam os nomes das fontes original e substituída.

O exemplo Python a seguir lista todas as substituições de fontes para uma apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Obter substituições de fontes para slides selecionados**

Use a sobrecarga [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#getSubstitutions) com um argumento de array de inteiros Java para inspecionar apenas as substituições necessárias para renderizar slides específicos. Isso é útil quando você está renderizando ou exportando parte de uma apresentação, verificando uma grande apresentação incrementalmente, localizando slides que dependem de fontes indisponíveis, preparando um pacote mínimo de fontes para um servidor ou contêiner, ou diagnosticando diferenças de renderização sem processar slides não relacionados.

O array `slides` contém índices de slides baseados em 1: `1` identifica o primeiro slide. Em contraste, o acessor de coleção [Presentation.getSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlides) usa indexação baseada em 0, de modo que o mesmo slide é acessado como `presentation.getSlides().get_Item(0)`. Mantenha essa diferença em mente ao montar o array para evitar erros de deslocamento.

Chame a sobrecarga através do método [Presentation.getFontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getFontsManager). Ele retorna apenas as substituições determinadas ao renderizar os slides selecionados. Cada resultado é um objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsubstitutioninfo/) contendo os nomes da fonte original e substituída. O resultado reflete o ambiente de fontes atual, as regras de fallback configuradas, as regras de substituição armazenadas em um [FontSubstRuleCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsubstrulecollection/), e [fonts carregados externamente](/slides/pt/python-java/custom-font/).

A mesma substituição pode ser exigida por mais de um slide selecionado. Desduplicar os resultados ao criar um inventário de fontes ou relatório de pré‑voo. O exemplo a seguir relata cada substituição retornada e então cria uma lista ordenada de mapeamentos de fontes únicos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

A classe [FontsManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/) fornece ambas as sobrecargas. Escolha uma de acordo com o escopo da operação de renderização:

| Sobrecarga | Use quando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#getSubstitutions) sem argumentos | Você precisa de substituições para a apresentação inteira. |
| [getSubstitutions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#getSubstitutions) com um array de inteiros Java | Você precisa de substituições para um intervalo selecionado, verificação incremental ou exportação parcial. |

## **Definir regras de substituição de fontes**

Para especificar a fonte que o Aspose.Slides deve usar quando uma fonte de origem está indisponível:

1. Carregue a apresentação.  
2. Crie definições de fonte para a fonte de origem e a fonte substituta.  
3. Crie um [FontSubstRule](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsubstrule/) com a condição [WhenInaccessible](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. Adicione a regra a um [FontSubstRuleCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsubstrulecollection/).  
5. Atribua a coleção usando o método [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. Renderize ou converta a apresentação.

O exemplo Python a seguir substitui `Arial` por `SomeRareFont` quando `SomeRareFont` está indisponível e, em seguida, renderiza o primeiro slide para verificar o resultado. A fonte substituta deve estar disponível para o Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Para uma alteração incondicional das fontes usadas em toda a apresentação, veja [Substituição de Fontes](/slides/pt/python-java/font-replacement/).
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

Regras de substituição de fontes fazem parte do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas funcionam para texto normal quando o Aspose.Slides pode substituir uma fonte inacessível pela fonte disponível especificada por uma regra.

Equações do Office Math têm um requisito adicional. Se uma equação usa **Cambria Math**, o Aspose.Slides pode precisar exatamente dessa fonte para calcular e renderizar o layout da equação. Uma regra que substitui outra fonte matemática, como **STIX Two Math**, não pode substituir **Cambria Math** para esse propósito, e a renderização ainda pode relatar que **Cambria Math** é necessária.

Para renderizar ou converter tal apresentação, disponibilize **Cambria Math** ao Aspose.Slides. Instale-a no sistema operacional ou carregue-a como uma [fonte externa](/slides/pt/python-java/custom-font/).

Essa limitação se aplica ao layout da equação. As regras de substituição descritas acima ainda se aplicam ao texto regular da apresentação.

## **Perguntas frequentes**

**Qual a diferença entre substituição de fonte e substituição de fonte?**

[Substituição de fonte](/slides/pt/python-java/font-replacement/) altera intencionalmente uma fonte por outra em toda a apresentação. Substituição de fonte seleciona uma fonte para a saída renderizada quando a condição configurada é atendida, como quando a fonte original está indisponível.

**Quando as regras de substituição são aplicadas?**

As regras participam da [sequência de seleção de fontes](/slides/pt/python-java/font-selection-sequence/) durante a renderização e conversão. Com `WhenInaccessible`, uma regra é usada apenas quando o Aspose.Slides não pode acessar a fonte de origem.

**O que acontece quando uma fonte falta e nenhuma regra de substituição está configurada?**

O Aspose.Slides seleciona a fonte disponível mais próxima de acordo com seu processo de seleção de fontes. O resultado depende das fontes disponíveis no ambiente de tempo de execução.

**Posso carregar fontes externas para evitar a substituição?**

Sim. Você pode [carregar fontes externas](/slides/pt/python-java/custom-font/) para que o Aspose.Slides as use durante a renderização e conversão.

**A Aspose distribui fontes com a biblioteca?**

Não. Você é responsável por fornecer as fontes e cumprir suas licenças.

**Os resultados de substituição podem diferir entre Windows, Linux e macOS?**

Sim. Fontes instaladas e locais de pesquisa de fontes diferem por sistema operacional, de modo que uma fonte disponível em uma máquina pode exigir substituição em outra.

**Como tornar a seleção de fontes consistente em conversões em lote?**

Use os mesmos arquivos e versões de fontes em todas as máquinas ou contêineres, [carregue as fontes externas necessárias](/slides/pt/python-java/custom-font/), e [incorpore fontes](/slides/pt/python-java/embedded-font/) quando as licenças permitirem. Você também pode chamar [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsmanager/#getSubstitutions) antes da exportação para identificar substituições inesperadas.