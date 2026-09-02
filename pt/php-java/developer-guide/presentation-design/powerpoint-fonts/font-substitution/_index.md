---
title: Configurar substituição de fontes em apresentações usando PHP
linktitle: Substituição de fontes
type: docs
weight: 70
url: /pt/php-java/font-substitution/
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
- PHP
- Aspose.Slides
description: "Configure regras de substituição de fontes e inspecione as fontes substituídas no Aspose.Slides para PHP via Java ao renderizar ou converter apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use uma fonte disponível no lugar de uma fonte que não pode ser acessada quando uma apresentação é renderizada ou convertida. A substituição afeta a saída renderizada; não altera a fonte atribuída ao conteúdo da apresentação.

Você pode definir a fonte a ser usada quando uma fonte específica não está disponível e pode inspecionar as substituições que o Aspose.Slides fará durante a renderização. Isso ajuda a manter a saída consistente entre ambientes com diferentes fontes instaladas.

## **Obter substituições de fontes**

Use o método [FontsManager::getSubstitutions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getsubstitutions/) para determinar quais fontes serão substituídas quando a apresentação for renderizada. O método devolve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsubstitutioninfo/) que identificam os nomes das fontes original e substituta.

O exemplo PHP a seguir lista todas as substituições de fontes para uma apresentação:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Obter substituições de fontes para slides selecionados**

Use a sobrecarga [FontsManager::getSubstitutions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getsubstitutions/) com um argumento `int[] slides` para inspecionar apenas as substituições necessárias para renderizar slides específicos. Isso é útil quando você está renderizando ou exportando parte de uma apresentação, verificando uma apresentação grande de forma incremental, localizando slides que dependem de fontes indisponíveis, preparando um pacote mínimo de fontes para um servidor ou contêiner, ou diagnosticando diferenças de renderização sem processar slides não relacionados.

A matriz `slides` contém índices de slide baseados em 1: `1` identifica o primeiro slide. Em contraste, o acessor de coleção [Presentation::getSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getSlides) usa indexação baseada em zero, de modo que o mesmo slide é acessado como `$presentation->getSlides()->get_Item(0)`. Mantenha essa diferença em mente ao montar a matriz para evitar erros de deslocamento.

Chame a sobrecarga através do método [Presentation::getFontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getFontsManager). Ele devolve apenas as substituições determinadas ao renderizar os slides selecionados. Cada resultado é um objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsubstitutioninfo/) contendo os nomes das fontes original e substituta. O resultado reflete o ambiente de fontes atual, as regras de fallback configuradas, as regras de substituição armazenadas em uma [FontSubstRuleCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsubstrulecollection/), e [fontes carregadas externamente](/slides/pt/php-java/custom-font/).

A mesma substituição pode ser exigida por mais de um slide selecionado. Desduplicar os resultados ao criar um inventário de fontes ou um relatório de pré‑verificação. O exemplo a seguir relata cada substituição retornada e, em seguida, cria uma lista ordenada de mapeamentos de fontes exclusivos:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

A classe [FontsManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/) fornece ambas as sobrecargas. Escolha uma de acordo com o escopo da operação de renderização:

| Sobrecarga | Use quando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getsubstitutions/) sem argumentos | Você precisa de substituições para toda a apresentação. |
| [getSubstitutions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getsubstitutions/) com `int[] slides` | Você precisa de substituições para um intervalo selecionado, verificação incremental ou exportação parcial. |

## **Definir regras de substituição de fontes**

Para especificar a fonte que o Aspose.Slides deve usar quando uma fonte de origem não está disponível:

1. Carregue a apresentação.  
2. Crie definições de fonte para as fontes de origem e de substituição.  
3. Crie um [FontSubstRule](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsubstrule/) com a condição [WhenInaccessible](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsubstcondition/).  
4. Adicione a regra a uma [FontSubstRuleCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsubstrulecollection/).  
5. Atribua a coleção usando o método [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Renderize ou converta a apresentação.

O exemplo PHP a seguir substitui `Arial` por `SomeRareFont` quando `SomeRareFont` não está disponível e, em seguida, renderiza o primeiro slide para verificar o resultado. A fonte substituta deve estar disponível para o Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Para uma alteração incondicional das fontes usadas em toda a apresentação, veja [Substituição de fontes](/slides/pt/php-java/font-replacement/).
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes fazem parte do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas funcionam para texto normal quando o Aspose.Slides pode substituir uma fonte inacessível pela fonte disponível especificada por uma regra.

Equações do Office Math têm um requisito adicional. Se uma equação usa **Cambria Math**, o Aspose.Slides pode precisar exatamente dessa fonte para calcular e renderizar o layout da equação. Uma regra que substitui outra fonte matemática, como **STIX Two Math**, não pode substituir **Cambria Math** para esse propósito, e a renderização ainda pode relatar que **Cambria Math** é necessária.

Para renderizar ou converter tal apresentação, disponibilize **Cambria Math** ao Aspose.Slides. Instale-a no sistema operacional ou carregue-a como uma [fonte externa](/slides/pt/php-java/custom-font/).

Esta limitação se aplica ao layout da equação. As regras de substituição descritas acima ainda se aplicam ao texto normal da apresentação.

## **Perguntas frequentes**

**Qual é a diferença entre substituição de fontes e substituição de fontes?**  
[Substituição de fontes](/slides/pt/php-java/font-replacement/) altera intencionalmente uma fonte por outra em toda a apresentação. A substituição de fontes seleciona uma fonte para a saída renderizada quando a condição configurada é atendida, como quando a fonte original não está disponível.

**Quando as regras de substituição são aplicadas?**  
As regras participam da [sequência de seleção de fontes](/slides/pt/php-java/font-selection-sequence/) durante a renderização e conversão. Com `WhenInaccessible`, uma regra é usada somente quando o Aspose.Slides não pode acessar a fonte de origem.

**O que acontece quando uma fonte está ausente e nenhuma regra de substituição está configurada?**  
O Aspose.Slides seleciona a fonte disponível mais próxima de acordo com seu processo de seleção de fontes. O resultado depende das fontes disponíveis no ambiente de tempo de execução.

**Posso carregar fontes externas para evitar substituição?**  
Sim. Você pode [carregar fontes externas](/slides/pt/php-java/custom-font/) para que o Aspose.Slides as use durante a renderização e conversão.

**A Aspose distribui fontes com a biblioteca?**  
Não. Você é responsável por fornecer as fontes e cumprir suas licenças.

**Os resultados de substituição podem diferir entre Windows, Linux e macOS?**  
Sim. As fontes instaladas e os locais de pesquisa de fontes diferem por sistema operacional, de modo que uma fonte disponível em uma máquina pode exigir substituição em outra.

**Como garantir que a seleção de fontes seja consistente em conversões em lote?**  
Use os mesmos arquivos e versões de fontes em todas as máquinas ou contêineres, [carregue as fontes externas necessárias](/slides/pt/php-java/custom-font/) e [incorpore fontes](/slides/pt/php-java/embedded-font/) quando a licença permitir. Você também pode chamar [FontsManager::getSubstitutions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsmanager/getsubstitutions/) antes da exportação para identificar substituições inesperadas.