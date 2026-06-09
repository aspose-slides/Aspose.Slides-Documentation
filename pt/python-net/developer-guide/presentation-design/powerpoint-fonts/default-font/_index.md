---
title: Personalizar fontes padrão em apresentações com Python
linktitle: Fonte padrão
type: docs
weight: 30
url: /pt/python-net/default-font/
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
- Python
- Aspose.Slides
description: "Defina fontes padrão no Aspose.Slides para Python para garantir a conversão correta de PowerPoint (PPT, PPTX) e OpenDocument (ODP) para PDF, XPS e imagens."
---
## **Visão geral**

Aspose.Slides permite que você especifique fontes padrão que são usadas quando uma apresentação é renderizada. Isso é útil ao gerar miniaturas de slides ou exportar uma apresentação para formatos como PDF e XPS. As fontes padrão são configuradas através de `LoadOptions` antes que a apresentação seja carregada.

A propriedade `default_regular_font` define a fonte padrão para texto comum, enquanto `default_asian_font` define a fonte padrão para texto asiático. Após essas opções serem definidas, a apresentação pode ser carregada e renderizada usando as fontes especificadas.

## **Usando fontes padrão para renderizar a apresentação**
Aspose.Slides permite que você defina a fonte padrão para renderizar a apresentação em PDF, XPS ou miniaturas. Este artigo mostra como definir DefaultRegular Font e DefaultAsian Font para uso como fontes padrão. Siga os passos abaixo para carregar fontes de diretórios externos usando Aspose.Slides for Python via .NET API:

1. Crie uma instância de LoadOptions.  
1. Defina o DefaultRegularFont para a fonte desejada. No exemplo a seguir, eu usei Wingdings.  
1. Defina o DefaultAsianFont para a fonte desejada. Eu usei Wingdings no exemplo a seguir.  
1. Carregue a apresentação usando Presentation e definindo as opções de carregamento.  
1. Agora, gere a miniatura do slide, PDF e XPS para verificar os resultados.  

A implementação acima é apresentada abaixo.

```py
import aspose.slides as slides

# Use opções de carregamento para definir as fontes padrão regular e asiáticas# Use opções de carregamento para definir as fontes padrão regular e asiáticas
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Carregar a apresentação
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Gerar miniatura do slide
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Gerar PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Gerar XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**O que exatamente `default_regular_font` e `default_asian_font` afetam — apenas exportação ou também miniaturas, PDF, XPS, HTML e SVG?**

Eles participam do pipeline de renderização para todas as saídas suportadas. Isso inclui miniaturas de slides, [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/pt/python-net/convert-powerpoint-to-xps/), [imagens raster](/slides/pt/python-net/convert-powerpoint-to-png/), [HTML](/slides/pt/python-net/convert-powerpoint-to-html/), e [SVG](/slides/pt/python-net/render-a-slide-as-an-svg-image/), pois Aspose.Slides usa a mesma lógica de layout e resolução de glifos nesses destinos.

**As fontes padrão são aplicadas ao simplesmente ler e salvar um PPTX sem qualquer renderização?**

Não. As fontes padrão são relevantes quando o texto precisa ser medido e desenhado. Uma simples abertura e salvamento de uma apresentação não altera as sequências de fontes armazenadas nem a estrutura do arquivo. As fontes padrão entram em ação durante operações que renderizam ou reformatam o texto.

**Se eu adicionar minhas próprias pastas de fontes ou fornecer fontes da memória, elas serão consideradas ao escolher as fontes padrão?**

Sim. [Custom font sources](/slides/pt/python-net/custom-font/) expandem o catálogo de famílias e glifos disponíveis que o mecanismo pode usar. As fontes padrão e quaisquer [fallback rules](/slides/pt/python-net/fallback-font/) serão resolvidas primeiro contra essas fontes, proporcionando uma cobertura mais confiável em servidores e contêineres.

**As fontes padrão afetarão métricas de texto (kerning, avanços) e, portanto, quebras de linha e wrapping?**

Sim. Alterar a fonte muda as métricas dos glifos e pode modificar quebras de linha, ajustes de texto e paginação durante a renderização. Para estabilidade de layout, [embed the original fonts](/slides/pt/python-net/embedded-font/) ou selecione famílias padrão e de fallback compatíveis metricamente.

**Há algum sentido em definir fontes padrão se todas as fontes usadas na apresentação estão incorporadas?**

Frequentemente não é necessário, pois [embedded fonts](/slides/pt/python-net/embedded-font/) já garantem aparência consistente. As fontes padrão ainda ajudam como uma rede de segurança para caracteres não cobertos pelo subconjunto incorporado ou quando um arquivo mistura texto incorporado e não incorporado.