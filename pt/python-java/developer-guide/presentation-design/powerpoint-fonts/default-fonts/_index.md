---
title: Especificar fontes padrão da apresentação em Python via Java
linktitle: Fonte padrão
type: docs
weight: 30
url: /pt/python-java/default-font/
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
- Java
- Aspose.Slides
description: "Defina fontes padrão no Aspose.Slides para Python via Java para garantir a conversão correta de PowerPoint (PPT, PPTX) e OpenDocument (ODP) para PDF, XPS e imagens."
---
## **Visão geral**

Aspose.Slides permite especificar fontes padrão que são usadas quando uma apresentação é renderizada. Isso é útil ao gerar miniaturas de slides ou exportar uma apresentação para formatos como PDF e XPS. As fontes padrão são configuradas através de [LoadOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/) antes que a apresentação seja carregada.

O método [setDefaultRegularFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) define a fonte padrão para texto regular, enquanto [setDefaultAsianFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) define a fonte padrão para texto asiático. Após essas opções serem definidas, a apresentação pode ser carregada e renderizada usando as fontes especificadas.

## **Usar fontes padrão para renderizar uma apresentação**

Aspose.Slides permite definir fontes padrão para renderizar uma apresentação em PDF, XPS ou miniaturas. Esta seção mostra como definir fontes padrão para texto regular e asiático usando Aspose.Slides for Python via Java:

1. Crie uma instância de [LoadOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/).
2. Use [setDefaultRegularFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) para especificar a fonte desejada. O exemplo a seguir usa Wingdings.
3. Use [setDefaultAsianFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) para especificar a fonte desejada. O exemplo a seguir também usa Wingdings.
4. Carregue a apresentação usando [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) com as opções de carregamento.
5. Gere a miniatura do slide, o PDF e o XPS para verificar os resultados.

O exemplo a seguir implementa essas etapas:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Use opções de carregamento para definir as fontes padrão regular e asiática.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Carregar a apresentação.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Gerar uma miniatura de slide.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Salvar a imagem no disco.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Gerar um PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Gerar um documento XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**O que exatamente as fontes padrão regular e asiática afetam — apenas a exportação ou também miniaturas, PDF, XPS, HTML e SVG?**

Elas participam do pipeline de renderização para todas as saídas suportadas. Isso inclui miniaturas de slides, [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/python-java/convert-powerpoint-to-xps/), [imagens raster](/slides/pt/python-java/convert-powerpoint-to-png/), [HTML](/slides/pt/python-java/convert-powerpoint-to-html/) e [SVG](/slides/pt/python-java/render-a-slide-as-an-svg-image/), pois Aspose.Slides usa a mesma lógica de layout e resolução de glifos nesses destinos.

**As fontes padrão são aplicadas ao simplesmente ler e salvar um PPTX sem nenhuma renderização?**

Não. As fontes padrão são relevantes quando o texto precisa ser medido e desenhado. Uma simples operação de abrir‑salvar de uma apresentação não altera as execuções de fonte armazenadas nem a estrutura do arquivo. As fontes padrão entram em ação durante operações que renderizam ou reorganizam o texto.

**Se eu adicionar minhas próprias pastas de fontes ou fornecer fontes da memória, elas serão consideradas ao escolher as fontes padrão?**

Sim. [Custom font sources](/slides/pt/python-java/custom-font/) ampliam o catálogo de famílias e glifos disponíveis que o mecanismo pode usar. As fontes padrão e quaisquer [fallback rules](/slides/pt/python-java/fallback-font/) serão resolvidas contra essas fontes primeiro, proporcionando cobertura mais confiável em servidores e contêineres.

**As fontes padrão afetarão métricas de texto (kerning, avanços) e, portanto, quebras de linha e envolvimento?**

Sim. Alterar a fonte muda as métricas dos glifos e pode modificar quebras de linha, envolvimento e paginação durante a renderização. Para estabilidade de layout, [embed the original fonts](/slides/pt/python-java/embedded-font/) ou selecione famílias padrão e de fallback metricamente compatíveis.

**Há algum sentido em definir fontes padrão se todas as fontes usadas na apresentação estão incorporadas?**

Frequentemente não é necessário, pois [embedded fonts](/slides/pt/python-java/embedded-font/) já garantem aparência consistente. As fontes padrão ainda ajudam como rede de segurança para caracteres não cobertos pelo subconjunto incorporado ou quando um arquivo mistura texto incorporado e não incorporado.