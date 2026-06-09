---
title: Especificar Fontes Padrão de Apresentação em JavaScript
linktitle: Fonte Padrão
type: docs
weight: 30
url: /pt/nodejs-java/default-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Defina fontes padrão no Aspose.Slides para Node.js via Java para garantir conversão adequada de PowerPoint (PPT, PPTX) e OpenDocument (ODP) para PDF, XPS e imagens."
---
## **Visão Geral**

Aspose.Slides permite que você especifique fontes padrão que são usadas quando uma apresentação é renderizada. Isso é útil ao gerar miniaturas de slides ou ao exportar uma apresentação para formatos como PDF e XPS. As fontes padrão são configuradas através de `LoadOptions` antes da apresentação ser carregada.

O método `setDefaultRegularFont` define a fonte padrão para texto normal, enquanto `setDefaultAsianFont` define a fonte padrão para texto asiático. Após definir essas opções, a apresentação pode ser carregada e renderizada usando as fontes especificadas.

## **Usando Fontes Padrão para Renderizar a Apresentação**
Aspose.Slides permite que você defina a fonte padrão para renderizar a apresentação em PDF, XPS ou miniaturas. Este artigo mostra como definir DefaultRegularFont e DefaultAsianFont para uso como fontes padrão. Siga os passos abaixo para carregar fontes de diretórios externos usando Aspose.Slides para Node.js via API Java:

1. Crie uma instância de [LoadOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LoadOptions).
2. [Defina o DefaultRegularFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) para a fonte desejada. No exemplo a seguir, usei Wingdings.
3. [Defina o DefaultAsianFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) para a fonte desejada. Usei Wingdings no exemplo a seguir.
4. Carregue a apresentação usando Presentation e definindo as opções de carga.
5. Agora, gere a miniatura do slide, PDF e XPS para verificar os resultados.

A implementação acima é apresentada abaixo.

```javascript
// Use opções de carregamento para definir as fontes padrão regular e asiática
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Carregue a apresentação
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Gere miniatura do slide
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // salve a imagem no disco.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Gere PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Gere XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**O que exatamente os DefaultRegularFont e DefaultAsianFont afetam — apenas exportação ou também miniaturas, PDF, XPS, HTML e SVG?**

Eles participam do pipeline de renderização para todas as saídas suportadas. Isso inclui miniaturas de slides, [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/nodejs-java/convert-powerpoint-to-xps/), [imagens raster](/slides/pt/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/), e [SVG](/slides/pt/nodejs-java/render-a-slide-as-an-svg-image/), pois o Aspose.Slides usa a mesma lógica de layout e resolução de glifos nesses alvos.

**As fontes padrão são aplicadas ao simplesmente ler e salvar um PPTX sem qualquer renderização?**

Não. As fontes padrão entram em ação quando o texto precisa ser medido e desenhado. Uma simples abertura e salvamento de uma apresentação não altera as execuções de fonte armazenadas nem a estrutura do arquivo. As fontes padrão são consideradas durante operações que renderizam ou refluem o texto.

**Se eu adicionar minhas próprias pastas de fontes ou fornecer fontes da memória, elas serão consideradas ao escolher as fontes padrão?**

Sim. [Fontes personalizadas](/slides/pt/nodejs-java/custom-font/) ampliam o catálogo de famílias e glifos disponíveis que o mecanismo pode usar. As fontes padrão e quaisquer [regras de fallback](/slides/pt/nodejs-java/fallback-font/) serão resolvidas contra essas fontes primeiro, proporcionando cobertura mais confiável em servidores e contêineres.

**As fontes padrão afetam métricas de texto (kerning, avanços) e, portanto, quebras de linha e envolvimento?**

Sim. Alterar a fonte muda as métricas dos glifos e pode modificar quebras de linha, envolvimento e paginação durante a renderização. Para estabilidade de layout, [incorpore as fontes originais](/slides/pt/nodejs-java/embedded-font/) ou selecione famílias padrão e de fallback metricamente compatíveis.

**Há algum sentido em definir fontes padrão se todas as fontes usadas na apresentação estão incorporadas?**

Frequentemente não é necessário, pois [fontes incorporadas](/slides/pt/nodejs-java/embedded-font/) já garantem aparência consistente. As fontes padrão ainda servem como rede de segurança para caracteres não cobertos pelo subconjunto incorporado ou quando um arquivo combina texto incorporado e não incorporado.