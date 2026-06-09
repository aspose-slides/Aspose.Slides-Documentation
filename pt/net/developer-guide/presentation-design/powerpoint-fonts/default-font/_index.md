---
title: Especificar fontes padrão de apresentação no .NET
linktitle: Fonte padrão
type: docs
weight: 30
url: /pt/net/default-font/
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
- .NET
- C#
- Aspose.Slides
description: "Defina fontes padrão no Aspose.Slides para .NET para garantir a conversão correta de PowerPoint (PPT, PPTX) e OpenDocument (ODP) para PDF, XPS e imagens."
---
## **Visão geral**

Aspose.Slides permite que você especifique fontes padrão que são usadas quando uma apresentação é renderizada. Isso é útil ao gerar miniaturas de slides ou ao exportar uma apresentação para formatos como PDF e XPS. As fontes padrão são configuradas através de `LoadOptions` antes de a apresentação ser carregada.

A propriedade `DefaultRegularFont` define a fonte padrão para texto normal, enquanto `DefaultAsianFont` define a fonte padrão para texto asiático. Após essas opções serem definidas, a apresentação pode ser carregada e renderizada usando as fontes especificadas.

## **Usar fontes padrão para renderizar uma apresentação**
Aspose.Slides permite que você defina a fonte padrão para renderizar a apresentação em PDF, XPS ou miniaturas. Este artigo mostra como definir DefaultRegularFont e DefaultAsianFont para uso como fontes padrão. Siga os passos abaixo para carregar fontes de diretórios externos usando a API Aspose.Slides para .NET:

1. Crie uma instância de LoadOptions.  
2. Defina DefaultRegularFont para a fonte desejada. No exemplo a seguir, usei Wingdings.  
3. Defina DefaultAsianFont para a fonte desejada. Usei Wingdings no exemplo a seguir.  
4. Carregue a apresentação usando Presentation e definindo as opções de carregamento.  
5. Agora, gere a miniatura do slide, PDF e XPS para verificar os resultados.

A implementação acima é apresentada a seguir.

```c#
// Use as opções de carregamento para especificar fontes padrão regular e asiática
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **FAQ**

**O que exatamente os DefaultRegularFont e DefaultAsianFont afetam—apenas a exportação ou também miniaturas, PDF, XPS, HTML e SVG?**

Eles participam do pipeline de renderização para todas as saídas suportadas. Isso inclui miniaturas de slides, [PDF](/slides/pt/net/convert-powerpoint-to-pdf/), [XPS](/slides/pt/net/convert-powerpoint-to-xps/), [imagens raster](/slides/pt/net/convert-powerpoint-to-png/), [HTML](/slides/pt/net/convert-powerpoint-to-html/), e [SVG](/slides/pt/net/render-a-slide-as-an-svg-image/), pois o Aspose.Slides usa a mesma lógica de layout e resolução de glifos nesses alvos.

**As fontes padrão são aplicadas ao simplesmente ler e salvar um PPTX sem qualquer renderização?**

Não. As fontes padrão são relevantes quando o texto precisa ser medido e desenhado. Um simples abrir‑salvar de uma apresentação não altera as execuções de fonte armazenadas nem a estrutura do arquivo. As fontes padrão entram em ação durante operações que renderizam ou reorganizam o texto.

**Se eu adicionar minhas próprias pastas de fontes ou fornecer fontes da memória, elas serão consideradas ao escolher as fontes padrão?**

Sim. [Custom font sources](/slides/pt/net/custom-font/) ampliam o catálogo de famílias e glifos disponíveis que o mecanismo pode usar. As fontes padrão e quaisquer [fallback rules](/slides/pt/net/fallback-font/) serão resolvidas contra essas fontes primeiro, proporcionando uma cobertura mais confiável em servidores e containers.

**As fontes padrão afetarão as métricas de texto (kerning, avanços) e, portanto, quebras de linha e envolvimento?**

Sim. Alterar a fonte muda as métricas dos glifos e pode modificar quebras de linha, envolvimento e paginação durante a renderização. Para estabilidade de layout, [incorpore as fontes originais](/slides/pt/net/embedded-font/) ou selecione famílias padrão e de fallback compatíveis metricamente.

**Há algum motivo para definir fontes padrão se todas as fontes usadas na apresentação estiverem incorporadas?**

Frequentemente não é necessário, pois [fontes incorporadas](/slides/pt/net/embedded-font/) já garantem aparência consistente. As fontes padrão ainda ajudam como rede de segurança para caracteres não cobertos pelo subconjunto incorporado ou quando um arquivo mistura texto incorporado e não incorporado.