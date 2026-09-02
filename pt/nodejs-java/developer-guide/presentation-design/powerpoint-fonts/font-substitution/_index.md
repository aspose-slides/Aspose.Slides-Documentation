---
title: Configurar Substituição de Fontes em Apresentações Usando JavaScript
linktitle: Substituição de Fontes
type: docs
weight: 70
url: /pt/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Configure regras de substituição de fontes e inspecione fontes substituídas no Aspose.Slides para Node.js via Java ao renderizar ou converter apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use uma fonte disponível no lugar de uma fonte que não pode ser acessada quando uma apresentação é renderizada ou convertida. A substituição afeta a saída renderizada; não altera a fonte atribuída ao conteúdo da apresentação.

Você pode definir a fonte a ser usada quando uma fonte específica está indisponível e pode inspeccionar as substituições que o Aspose.Slides realizará durante a renderização. Isso ajuda a manter a saída consistente entre ambientes com fontes instaladas diferentes.

## **Obter substituições de fontes**

Use o [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) para determinar quais fontes serão substituídas quando a apresentação for renderizada. O método devolve objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsubstitutioninfo/) que identificam os nomes da fonte original e da fonte substituta.

O exemplo JavaScript a seguir lista todas as substituições de fontes para uma apresentação:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Obter substituições de fontes para slides selecionados**

Use a sobrecarga [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) com um array de índices de slides para inspecionar apenas as substituições necessárias para renderizar slides específicos. Isso é útil quando você está renderizando ou exportando parte de uma apresentação, verificando uma apresentação grande de forma incremental, localizando slides que dependem de fontes indisponíveis, preparando um pacote mínimo de fontes para um servidor ou contêiner, ou diagnosticando diferenças de renderização sem processar slides não relacionados.

A sobrecarga espera um primitivo Java `int[]`. Crie‑o com `java.newArray("int", [...])`; um array JavaScript simples é convertido para `Integer[]` e não corresponde a essa sobrecarga.

O array contém índices de slides baseados em 1: `1` identifica o primeiro slide. Em contraste, o acessador de coleção [Presentation.getSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getslides/) usa indexação baseada em 0, de modo que o mesmo slide é acessado como `presentation.getSlides().get_Item(0)`. Mantenha essa diferença em mente ao montar o array para evitar erros de deslocamento.

Chame a sobrecarga através de [Presentation.getFontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getfontsmanager/). Ele devolve apenas as substituições determinadas ao renderizar os slides selecionados. Cada resultado é um objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsubstitutioninfo/) contendo os nomes da fonte original e da fonte substituta. O resultado reflete o ambiente de fontes atual, regras de fallback configuradas, regras de substituição armazenadas em uma [FontSubstRuleCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsubstrulecollection/) e [fonts carregados externamente](/slides/pt/nodejs-java/custom-font/).

A mesma substituição pode ser necessária para mais de um slide selecionado. Deduplice os resultados ao criar um inventário de fontes ou um relatório de pré‑verificação. O exemplo a seguir relata cada substituição retornada e depois cria uma lista ordenada de mapeamentos de fontes únicos:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

A classe [FontsManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/) fornece ambas as sobrecargas. Escolha a que se ajusta ao escopo da operação de renderização:

| Sobrecarga | Use quando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) sem argumentos | Você precisa de substituições para a apresentação inteira. |
| [getSubstitutions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) com um `int[]` Java de índices de slides | Você precisa de substituições para um intervalo selecionado, verificação incremental ou exportação parcial. |

## **Definir regras de substituição de fontes**

Para especificar a fonte que o Aspose.Slides deve usar quando uma fonte de origem está indisponível:

1. Carregue a apresentação.  
2. Crie definições de fonte para as fontes de origem e substituta.  
3. Crie um [FontSubstRule](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsubstrule/) com a condição [WhenInaccessible](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsubstcondition/).  
4. Adicione a regra a uma [FontSubstRuleCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. Atribua a coleção usando o método [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Renderize ou converta a apresentação.

O exemplo JavaScript a seguir substitui `Arial` por `SomeRareFont` quando `SomeRareFont` está indisponível e, em seguida, renderiza o primeiro slide para verificar o resultado. A fonte substituta deve estar disponível para o Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Para uma alteração incondicional das fontes usadas em toda a apresentação, consulte [Font Replacement](/slides/pt/nodejs-java/font-replacement/).
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes fazem parte do processo padrão de seleção de fontes usado durante renderização e conversão. Elas funcionam para texto normal quando o Aspose.Slides pode substituir uma fonte inacessível pela fonte disponível especificada pela regra.

Equações do Office Math têm um requisito adicional. Se uma equação usar **Cambria Math**, o Aspose.Slides pode precisar exatamente dessa fonte para calcular e renderizar o layout da equação. Uma regra que substitui outra fonte matemática, como **STIX Two Math**, não pode substituir **Cambria Math** para esse fim, e a renderização ainda pode relatar que **Cambria Math** é necessária.

Para renderizar ou converter tal apresentação, torne **Cambria Math** disponível ao Aspose.Slides. Instale-a no sistema operacional ou carregue‑a como uma [fonte externa](/slides/pt/nodejs-java/custom-font/).

Essa limitação se aplica ao layout da equação. As regras de substituição descritas acima ainda se aplicam ao texto regular da apresentação.

## **Perguntas frequentes**

**Qual é a diferença entre substituição de fontes e substituição (replacement) de fontes?**

[Font replacement](/slides/pt/nodejs-java/font-replacement/) altera intencionalmente uma fonte por outra em toda a apresentação. A substituição de fontes seleciona uma fonte para a saída renderizada quando a condição configurada é atendida, como quando a fonte original está indisponível.

**Quando as regras de substituição são aplicadas?**

As regras participam da [sequência de seleção de fontes](/slides/pt/nodejs-java/font-selection-sequence/) durante renderização e conversão. Com `WhenInaccessible`, a regra é usada apenas quando o Aspose.Slides não pode acessar a fonte de origem.

**O que acontece quando uma fonte está ausente e nenhuma regra de substituição está configurada?**

O Aspose.Slides seleciona a fonte disponível mais próxima de acordo com seu processo de seleção de fontes. O resultado depende das fontes disponíveis no ambiente de tempo de execução.

**Posso carregar fontes externas para evitar substituição?**

Sim. Você pode [carregar fontes externas](/slides/pt/nodejs-java/custom-font/) para que o Aspose.Slides as use durante renderização e conversão.

**A Aspose distribui fontes com a biblioteca?**

Não. Você é responsável por fornecer as fontes e observar suas licenças.

**Os resultados de substituição podem diferir entre Windows, Linux e macOS?**

Sim. Fontes instaladas e locais de pesquisa de fontes diferem entre sistemas operacionais, de modo que uma fonte disponível em uma máquina pode exigir substituição em outra.

**Como tornar a seleção de fontes consistente em conversões em lote?**

Use os mesmos arquivos e versões de fontes em cada máquina ou contêiner, [carregue as fontes externas necessárias](/slides/pt/nodejs-java/custom-font/), e [incorpore fontes](/slides/pt/nodejs-java/embedded-font/) quando a licença permitir. Você também pode chamar [FontsManager.getSubstitutions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) antes da exportação para identificar substituições inesperadas.