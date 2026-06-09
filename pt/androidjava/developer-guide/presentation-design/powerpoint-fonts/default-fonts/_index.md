---
title: Especificar fontes padrão de apresentação no Android
linktitle: Fonte padrão
type: docs
weight: 30
url: /pt/androidjava/default-font/
keywords:
- fonte padrão
- fonte regular
- fonte normal
- fonte asiática
- exportação PDF
- exportação XPS
- exportação de imagem
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Defina fontes padrão no Aspose.Slides para Android via Java para garantir a conversão adequada de PowerPoint (PPT, PPTX) e OpenDocument (ODP) para PDF, XPS e imagens."
---
## **Visão geral**

Aspose.Slides permite que você especifique fontes padrão que são usadas quando uma apresentação é renderizada. Isso é útil ao gerar miniaturas de slides ou exportar uma apresentação para formatos como PDF e XPS. As fontes padrão são configuradas através de `LoadOptions` antes de a apresentação ser carregada.

O método `setDefaultRegularFont` define a fonte padrão para texto regular, enquanto `setDefaultAsianFont` define a fonte padrão para texto asiático. Após essas opções serem definidas, a apresentação pode ser carregada e renderizada usando as fontes especificadas.

## **Usar fontes padrão para renderizar uma apresentação**
Aspose.Slides permite definir a fonte padrão para renderizar a apresentação em PDF, XPS ou miniaturas. Este artigo mostra como definir DefaultRegularFont e DefaultAsianFont para uso como fontes padrão. Siga os passos abaixo para carregar fontes de diretórios externos usando Aspose.Slides para Android via API Java:

1. Crie uma instância de [LoadOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LoadOptions).
1. [Defina o DefaultRegularFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) para a fonte desejada. No exemplo a seguir, usei Wingdings.
1. [Defina o DefaultAsianFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) para a fonte desejada. Usei Wingdings no exemplo a seguir.
1. Carregue a apresentação usando Presentation e definindo as opções de carga.
1. Agora, gere a miniatura do slide, PDF e XPS para verificar os resultados.

A implementação acima é apresentada a seguir.

```java
// Use opções de carregamento para definir as fontes padrão regular e asiática
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Load the presentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Gerar miniatura do slide
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // salvar a imagem no disco.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Gerar PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Gerar XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**O que exatamente o DefaultRegularFont e o DefaultAsianFont afetam — apenas exportação, ou também miniaturas, PDF, XPS, HTML e SVG?**

Eles participam do pipeline de renderização para todas as saídas suportadas. Isso inclui miniaturas de slides, [PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/pt/androidjava/convert-powerpoint-to-xps/), [imagens raster](/slides/pt/androidjava/convert-powerpoint-to-png/), [HTML](/slides/pt/androidjava/convert-powerpoint-to-html/), e [SVG](/slides/pt/androidjava/render-a-slide-as-an-svg-image/), porque Aspose.Slides usa a mesma lógica de layout e resolução de glifos nesses alvos.

**As fontes padrão são aplicadas ao simplesmente ler e salvar um PPTX sem nenhuma renderização?**

Não. As fontes padrão importam quando o texto precisa ser medido e desenhado. Uma simples abertura e salvamento de uma apresentação não altera as execuções de fonte armazenadas ou a estrutura do arquivo. As fontes padrão entram em ação durante operações que renderizam ou reorganizam o texto.

**Se eu adicionar minhas próprias pastas de fontes ou fornecer fontes a partir da memória, elas serão consideradas ao escolher as fontes padrão?**

Sim. [Custom font sources](/slides/pt/androidjava/custom-font/) ampliam o catálogo de famílias e glifos disponíveis que o motor pode usar. As fontes padrão e quaisquer [fallback rules](/slides/pt/androidjava/fallback-font/) serão resolvidas contra essas fontes primeiro, proporcionando cobertura mais confiável em servidores e contêineres.

**As fontes padrão afetam as métricas de texto (kerning, avanços) e, portanto, quebras de linha e envolvimento?**

Sim. Alterar a fonte muda as métricas dos glifos e pode alterar quebras de linha, envolvimento e paginação durante a renderização. Para estabilidade de layout, [embed the original fonts](/slides/pt/androidjava/embedded-font/) ou selecione famílias padrão e de fallback metricamente compatíveis.

**Há algum sentido em definir fontes padrão se todas as fontes usadas na apresentação estão incorporadas?**

Frequentemente não é necessário, pois [embedded fonts](/slides/pt/androidjava/embedded-font/) já garantem aparência consistente. As fontes padrão ainda ajudam como rede de segurança para caracteres não cobertos pelo subconjunto incorporado ou quando um arquivo mistura texto incorporado e não incorporado.