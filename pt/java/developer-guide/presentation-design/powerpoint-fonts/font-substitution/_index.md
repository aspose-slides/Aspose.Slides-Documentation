---
title: Configurar substituição de fonte em apresentações usando Java
linktitle: Substituição de fonte
type: docs
weight: 70
url: /pt/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Configure regras de substituição de fontes e inspecione as fontes substituídas no Aspose.Slides para Java ao renderizar ou converter apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use uma fonte disponível no lugar de uma fonte que não pode ser acessada quando uma apresentação é renderizada ou convertida. A substituição afeta a saída renderizada; não altera a fonte atribuída ao conteúdo da apresentação.

Você pode definir a fonte a ser usada quando uma fonte específica não está disponível e pode inspecionar as substituições que o Aspose.Slides fará durante a renderização. Isso ajuda a manter a saída consistente em ambientes com diferentes fontes instaladas.

Se uma fonte está disponível, mas não possui um tipo de negrito dedicado, veja [Manipular fontes sem um tipo de negrito dedicado](/slides/pt/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Essa seção explica como rasterizar o texto afetado durante a exportação para PDF e as consequências para seleção de texto, pesquisa e dimensionamento.

## **Obter substituições de fontes**

Use o método [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) para determinar quais fontes serão substituídas quando a apresentação for renderizada. O método retorna objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) que identificam os nomes das fontes originais e substituídas.

O exemplo Java a seguir lista todas as substituições de fontes para uma apresentação:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Obter substituições de fontes para slides selecionados**

Use a sobrecarga [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) com um argumento `int[] slides` para inspecionar apenas as substituições necessárias para renderizar slides específicos. Isso é útil quando você está renderizando ou exportando parte de uma apresentação, verificando uma grande apresentação de forma incremental, localizando slides que dependem de fontes indisponíveis, preparando um pacote mínimo de fontes para um servidor ou contêiner, ou diagnosticando diferenças de renderização sem processar slides não relacionados.

O array `slides` contém índices de slides baseados em 1: `1` identifica o primeiro slide. Em contraste, o acessador de coleção [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) usa indexação baseada em zero, de modo que o mesmo slide é acessado como `presentation.getSlides().get_Item(0)`. Mantenha essa diferença em mente ao construir o array para evitar erros de deslocamento de índice.

Chame a sobrecarga através do método [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--). Ele retorna apenas as substituições determinadas durante a renderização dos slides selecionados. Cada resultado é um objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) contendo os nomes das fontes original e substituída. O resultado reflete o ambiente de fontes atual, as regras de fallback configuradas e [fontes carregadas externamente](/slides/pt/java/custom-font/). As regras de substituição armazenadas em um [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) são aplicadas quando a apresentação é renderizada, mas o resultado não as lista; verifique as fontes no arquivo de saída.

A mesma substituição pode ser necessária em mais de um slide selecionado. Desduplicar os resultados ao criar um inventário de fontes ou relatório de pré‑voo. O exemplo a seguir relata cada substituição retornada e então cria uma lista ordenada de mapeamentos de fontes únicos:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

A interface [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) fornece ambas as sobrecargas. Escolha uma de acordo com o escopo da operação de renderização:

| Sobrecarga | Quando usar |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Você precisa de substituições para toda a apresentação. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Você precisa de substituições para um intervalo selecionado, verificação incremental ou exportação parcial. |

## **Definir regras de substituição de fontes**

Para especificar a fonte que o Aspose.Slides deve usar quando uma fonte de origem está indisponível:

1. Carregue a apresentação.
2. Crie definições de fonte para as fontes de origem e substituta.
3. Crie um [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) com a condição [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/).
4. Adicione a regra a uma [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/).
5. Atribua a coleção usando o método [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Renderize ou converta a apresentação.

O exemplo Java a seguir substitui `Arial` por `SomeRareFont` quando `SomeRareFont` está indisponível e, em seguida, renderiza o primeiro slide para verificar o resultado. A fonte substituta deve estar disponível para o Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Para uma alteração incondicional nas fontes usadas em toda a apresentação, veja [Substituição de fonte](/slides/pt/java/font-replacement/).
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes fazem parte do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas funcionam para texto regular quando o Aspose.Slides pode substituir uma fonte inacessível pela fonte disponível especificada por uma regra.

Equações do Office Math têm um requisito adicional. Se uma equação usa **Cambria Math**, o Aspose.Slides pode precisar dessa fonte exata para calcular e renderizar o layout da equação. Uma regra que substitui outra fonte matemática, como **STIX Two Math**, não pode substituir **Cambria Math** para esse fim, e a renderização ainda pode relatar que **Cambria Math** é necessária.

Para renderizar ou converter essa apresentação, torne **Cambria Math** disponível para o Aspose.Slides. Instale-a no sistema operacional ou carregue-a como uma [fonte externa](/slides/pt/java/custom-font/).

Esta limitação se aplica ao layout de equações. As regras de substituição descritas acima ainda se aplicam ao texto regular da apresentação.

## **FAQ**

**Qual é a diferença entre substituição de fonte e substituição de fontes?**

[Substituição de fonte](/slides/pt/java/font-replacement/) altera intencionalmente uma fonte por outra em toda a apresentação. A substituição de fontes seleciona uma fonte para a saída renderizada quando a condição configurada é atendida, como quando a fonte original está indisponível.

**Quando as regras de substituição são aplicadas?**

As regras participam da [sequência de seleção de fonte](/slides/pt/java/font-selection-sequence/) durante a renderização e conversão. Com `WhenInaccessible`, uma regra é usada somente quando o Aspose.Slides não pode acessar a fonte de origem.

**O que acontece quando uma fonte está ausente e nenhuma regra de substituição está configurada?**

O Aspose.Slides seleciona a fonte disponível mais próxima de acordo com seu processo de seleção de fontes. O resultado depende das fontes disponíveis no ambiente de execução.

**Posso carregar fontes externas para evitar substituição?**

Sim. Você pode [carregar fontes externas](/slides/pt/java/custom-font/) para que o Aspose.Slides possa usá‑las durante a renderização e conversão.

**A Aspose distribui fontes com a biblioteca?**

Não. Você é responsável por fornecer as fontes e cumprir suas licenças.

**Os resultados de substituição podem diferir entre Windows, Linux e macOS?**

Sim. As fontes instaladas e os locais de busca de fontes diferem entre sistemas operacionais, de modo que uma fonte disponível em uma máquina pode exigir substituição em outra.

**Como posso tornar a seleção de fontes consistente em conversões em lote?**

Use os mesmos arquivos de fonte e versões em cada máquina ou contêiner, [carregue as fontes externas necessárias](/slides/pt/java/custom-font/), e [incorpore fontes](/slides/pt/java/embedded-font/) quando a licença permitir. Você também pode chamar [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) antes da exportação para identificar substituições inesperadas.