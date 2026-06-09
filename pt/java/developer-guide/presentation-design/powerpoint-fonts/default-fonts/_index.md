---
title: Especificar fontes padrão de apresentação em Java
linktitle: Fonte padrão
type: docs
weight: 30
url: /pt/java/default-font/
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
- Java
- Aspose.Slides
description: "Defina fontes padrão no Aspose.Slides para Java para garantir a conversão correta de PowerPoint (PPT, PPTX) e OpenDocument (ODP) para PDF, XPS e imagens."
---
## **Visão geral**

Aspose.Slides permite especificar fontes padrão que são usadas quando uma apresentação é renderizada. Isso é útil ao gerar miniaturas de slides ou exportar uma apresentação para formatos como PDF e XPS. As fontes padrão são configuradas através de `LoadOptions` antes que a apresentação seja carregada.

O método `setDefaultRegularFont` define a fonte padrão para texto comum, enquanto `setDefaultAsianFont` define a fonte padrão para texto asiático. Após definir essas opções, a apresentação pode ser carregada e renderizada usando as fontes especificadas.

## **Usar fontes padrão para renderizar uma apresentação**
Aspose.Slides permite definir a fonte padrão ao renderizar a apresentação para PDF, XPS ou miniaturas. Este artigo mostra como definir DefaultRegularFont e DefaultAsianFont para uso como fontes padrão. Siga os passos abaixo para carregar fontes de diretórios externos usando a API Aspose.Slides for Java:

1. Crie uma instância de [LoadOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/LoadOptions).
1. [Defina o DefaultRegularFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) para a fonte desejada. No exemplo a seguir, foi usado Wingdings.
1. [Defina o DefaultAsianFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) para a fonte desejada. Usei Wingdings no exemplo a seguir.
1. Carregue a apresentação usando Presentation e definindo as opções de carregamento.
1. Agora, gere a miniatura do slide, PDF e XPS para verificar os resultados.

A implementação acima é apresentada a seguir.

```java
// Use opções de carregamento para definir as fontes padrão regular e asiática
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Carregar a apresentação
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

**O que exatamente o DefaultRegularFont e o DefaultAsianFont afetam — apenas exportação ou também miniaturas, PDF, XPS, HTML e SVG?**

Eles participam do pipeline de renderização para todas as saídas suportadas. Isso inclui miniaturas de slides, [PDF](/slides/pt/java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/java/convert-powerpoint-to-xps/), [imagens raster](/slides/pt/java/convert-powerpoint-to-png/), [HTML](/slides/pt/java/convert-powerpoint-to-html/) e [SVG](/slides/pt/java/render-a-slide-as-an-svg-image/), porque o Aspose.Slides usa a mesma lógica de layout e resolução de glifos nesses destinos.

**As fontes padrão são aplicadas ao simplesmente ler e salvar um PPTX sem renderização?**

Não. As fontes padrão importam quando o texto precisa ser medido e desenhado. Uma simples abertura e salvamento de uma apresentação não altera as execuções de fonte armazenadas nem a estrutura do arquivo. As fontes padrão entram em ação durante operações que renderizam ou reformatam o texto.

**Se eu adicionar minhas próprias pastas de fontes ou fornecer fontes da memória, elas serão consideradas ao escolher as fontes padrão?**

Sim. [Fontes personalizadas](/slides/pt/java/custom-font/) ampliam o catálogo de famílias e glifos disponíveis que o mecanismo pode usar. As fontes padrão e quaisquer [regras de fallback](/slides/pt/java/fallback-font/) serão resolvidas primeiro contra essas fontes, proporcionando cobertura mais confiável em servidores e contêineres.

**As fontes padrão afetarão métricas de texto (kerning, avanços) e, portanto, quebras de linha e envelopamento?**

Sim. Alterar a fonte modifica as métricas dos glifos e pode mudar quebras de linha, envelopamento e paginação durante a renderização. Para estabilidade de layout, [incorpore as fontes originais](/slides/pt/java/embedded-font/) ou selecione famílias padrão e de fallback compatíveis metricamente.

**Existe algum motivo para definir fontes padrão se todas as fontes usadas na apresentação estiverem incorporadas?**

Frequentemente não é necessário, pois [fontes incorporadas](/slides/pt/java/embedded-font/) já garantem aparência consistente. As fontes padrão ainda ajudam como rede de segurança para caracteres não cobertos pelo subconjunto incorporado ou quando um arquivo mistura texto incorporado e não incorporado.