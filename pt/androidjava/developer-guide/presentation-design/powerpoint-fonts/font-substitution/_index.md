---
title: Configurar Substituição de Fonte em Apresentações no Android
linktitle: Substituição de Fonte
type: docs
weight: 70
url: /pt/androidjava/font-substitution/
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
- presentation
- Android
- Java
- Aspose.Slides
description: "Configure regras de substituição de fonte e inspecione as fontes substituídas no Aspose.Slides para Android via Java ao renderizar ou converter apresentações."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use uma fonte disponível no lugar de uma fonte que não pode ser acessada quando uma apresentação é renderizada ou convertida. A substituição afeta a saída renderizada; não altera a fonte atribuída ao conteúdo da apresentação.

Você pode definir a fonte a ser usada quando uma fonte específica não estiver disponível e pode inspecionar as substituições que o Aspose.Slides fará durante a renderização. Isso ajuda a manter a saída consistente em dispositivos Android e ambientes com diferentes fontes disponíveis.

Se uma fonte estiver disponível mas não tiver um tipo negrito dedicado, veja [Manipular Fontes Sem um Tipo Negrito Dedicado](/slides/pt/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Essa seção explica como rasterizar o texto afetado durante a exportação para PDF e as consequências para seleção de texto, pesquisa e dimensionamento.

## **Obter Substituições de Fonte**

Use o método [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) para determinar quais fontes serão substituídas quando a apresentação for renderizada. O método retorna objetos [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) que identificam os nomes das fontes originais e substituídas.

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

## **Obter Substituições de Fonte para Slides Selecionados**

Use a sobrecarga [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) com um argumento `int[] slides` para inspecionar apenas as substituições necessárias para renderizar slides específicos. Isso é útil quando você está renderizando ou exportando parte de uma apresentação, verificando uma grande apresentação de forma incremental, localizando slides que dependem de fontes indisponíveis, preparando um pacote mínimo de fontes para um aplicativo Android ou diagnosticando diferenças de renderização sem processar slides não relacionados.

A matriz `slides` contém índices de slides baseados em 1: `1` identifica o primeiro slide. Em contraste, o acessor de coleção [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) usa indexação baseada em zero, de modo que o mesmo slide é acessado como `presentation.getSlides().get_Item(0)`. Mantenha essa diferença em mente ao construir a matriz para evitar erros de deslocamento.

Chame a sobrecarga através do método [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--). Ele retorna apenas as substituições determinadas ao renderizar os slides selecionados. Cada resultado é um objeto [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) contendo os nomes das fontes originais e substituídas. O resultado reflete o ambiente de fontes atual, as regras de fallback configuradas, as regras de substituição armazenadas em uma [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/) e [fonts carregados externamente](/slides/pt/androidjava/custom-font/).

A mesma substituição pode ser necessária por mais de um slide selecionado. Desduplicar os resultados ao criar um inventário de fontes ou relatório de pré‑voo. O exemplo a seguir relata cada substituição retornada e, em seguida, cria uma lista ordenada de mapeamentos de fontes únicos:

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

A interface [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) fornece ambas as sobrecargas. Escolha uma de acordo com o escopo da operação de renderização:

| Sobrecarga | Quando usar |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) sem argumentos | Você precisa de substituições para a apresentação inteira. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) com `int[] slides` | Você precisa de substituições para um intervalo selecionado, verificação incremental ou exportação parcial. |

## **Definir Regras de Substituição de Fonte**

Para especificar a fonte que o Aspose.Slides deve usar quando uma fonte de origem não estiver disponível:

1. Carregue a apresentação.
2. Crie definições de fontes para as fontes de origem e substituta.
3. Crie uma [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) com a condição [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/).
4. Adicione a regra a uma [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Atribua a coleção usando o método [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Renderize ou converta a apresentação.

O exemplo Java a seguir substitui `Arial` por `SomeRareFont` quando `SomeRareFont` não está disponível e, em seguida, renderiza o primeiro slide para verificar o resultado. A fonte substituta deve estar disponível para o Aspose.Slides.

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
Para uma alteração incondicional nas fontes usadas em toda a apresentação, veja [Substituição de Fonte](/slides/pt/androidjava/font-replacement/).
{{% /alert %}}

## **Limitações para Fontes de Equações Matemáticas**

As regras de substituição de fontes fazem parte do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas funcionam para texto normal quando o Aspose.Slides pode substituir uma fonte inacessível pela fonte disponível especificada por uma regra.

Equações do Office Math têm um requisito adicional. Se uma equação usar **Cambria Math**, o Aspose.Slides pode precisar dessa fonte exata para calcular e renderizar o layout da equação. Uma regra que substitui outra fonte matemática, como **STIX Two Math**, não pode substituir **Cambria Math** para esse fim, e a renderização ainda pode indicar que **Cambria Math** é necessária.

Para renderizar ou converter essa apresentação, torne **Cambria Math** disponível para o Aspose.Slides. Carregue‑a como uma [fonte externa](/slides/pt/androidjava/custom-font/) para que o aplicativo possa usá‑la durante a renderização e conversão.

Essa limitação se aplica ao layout da equação. As regras de substituição descritas acima ainda se aplicam ao texto normal da apresentação.

## **FAQ**

**Qual é a diferença entre substituição de fonte e substituição de fonte?**  
[Substituição de Fonte](/slides/pt/androidjava/font-replacement/) altera intencionalmente uma fonte por outra em toda a apresentação. A substituição de fonte seleciona uma fonte para a saída renderizada quando a condição configurada é atendida, como quando a fonte original não está disponível.

**Quando as regras de substituição são aplicadas?**  
As regras participam da [sequência de seleção de fonte](/slides/pt/androidjava/font-selection-sequence/) durante a renderização e conversão. Com `WhenInaccessible`, uma regra é usada apenas quando o Aspose.Slides não pode acessar a fonte de origem.

**O que acontece quando uma fonte está faltando e nenhuma regra de substituição está configurada?**  
O Aspose.Slides seleciona a fonte disponível mais próxima de acordo com seu processo de seleção de fontes. O resultado depende das fontes disponíveis no ambiente de tempo de execução.

**Posso carregar fontes externas para evitar substituição?**  
Sim. Você pode [carregar fontes externas](/slides/pt/androidjava/custom-font/) para que o Aspose.Slides possa usá‑las durante a renderização e conversão.

**A Aspose distribui fontes com a biblioteca?**  
Não. Você é responsável por fornecer as fontes e por cumprir suas licenças.

**Os resultados de substituição podem diferir entre dispositivos Android?**  
Sim. As fontes do sistema disponíveis podem variar entre versões do Android, dispositivos e fabricantes, de modo que uma fonte disponível em um ambiente pode exigir substituição em outro.

**Como posso tornar a seleção de fontes consistente em dispositivos Android?**  
Empacote os mesmos arquivos de fontes necessários com o aplicativo, [carregue‑os como fontes externas](/slides/pt/androidjava/custom-font/) e [incorpore fontes](/slides/pt/androidjava/embedded-font/) quando a licença permitir. Você também pode chamar [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) antes da exportação para identificar substituições inesperadas.