---
title: Especificar fontes padrão da apresentação em PHP
linktitle: Fonte padrão
type: docs
weight: 30
url: /pt/php-java/default-font/
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
- PHP
- Aspose.Slides
description: "Defina as fontes padrão no Aspose.Slides para PHP via Java para garantir a conversão correta de PowerPoint (PPT, PPTX) e OpenDocument (ODP) para PDF, XPS e imagens."
---
## **Visão geral**

Aspose.Slides permite especificar as fontes padrão que são usadas quando uma apresentação é renderizada. Isso é útil ao gerar miniaturas de slides ou ao exportar uma apresentação para formatos como PDF e XPS. As fontes padrão são configuradas através de `LoadOptions` antes de a apresentação ser carregada.

O método `setDefaultRegularFont` define a fonte padrão para texto comum, enquanto `setDefaultAsianFont` define a fonte padrão para texto asiático. Após essas opções serem definidas, a apresentação pode ser carregada e renderizada usando as fontes especificadas.

## **Usar fontes padrão para renderizar uma apresentação**
Aspose.Slides permite definir a fonte padrão para renderizar a apresentação em PDF, XPS ou miniaturas. Este artigo mostra como definir DefaultRegularFont e DefaultAsianFont como fontes padrão. Siga os passos abaixo para carregar fontes de diretórios externos usando Aspose.Slides para PHP via API Java:

1. Crie uma instância de [LoadOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) para a fonte desejada. No exemplo a seguir, usei Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) para a fonte desejada. Usei Wingdings no exemplo a seguir.
1. Carregue a apresentação usando Presentation e definições de load options.
1. Agora, gere a miniatura do slide, o PDF e o XPS para verificar os resultados.

A implementação acima é mostrada a seguir.

```php
  # Use opções de carregamento para definir as fontes padrão regular e asiática
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Carregue a apresentação
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Gere a miniatura do slide
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # salve a imagem no disco.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Gerar PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Gerar XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**O que exatamente afetam DefaultRegularFont e DefaultAsianFont — somente exportação, ou também miniaturas, PDF, XPS, HTML e SVG?**

Eles participam do pipeline de renderização para todas as saídas suportadas. Isso inclui miniaturas de slides, [PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/php-java/convert-powerpoint-to-xps/), [imagens raster](/slides/pt/php-java/convert-powerpoint-to-png/), [HTML](/slides/pt/php-java/convert-powerpoint-to-html/), e [SVG](/slides/pt/php-java/render-a-slide-as-an-svg-image/), porque Aspose.Slides usa a mesma lógica de layout e resolução de glifos nesses destinos.

**As fontes padrão são aplicadas ao simplesmente ler e salvar um PPTX sem renderização?**

Não. As fontes padrão são relevantes quando o texto precisa ser medido e desenhado. Uma simples abertura e salvamento de uma apresentação não altera as execuções de fonte armazenadas nem a estrutura do arquivo. As fontes padrão entram em ação durante operações que renderizam ou reformatam o texto.

**Se eu adicionar minhas próprias pastas de fontes ou fornecer fontes a partir da memória, elas serão consideradas ao escolher as fontes padrão?**

Sim. [Fontes personalizadas](/slides/pt/php-java/custom-font/) expandem o catálogo de famílias e glifos disponíveis que o mecanismo pode usar. As fontes padrão e quaisquer [regras de fallback](/slides/pt/php-java/fallback-font/) serão resolvidas contra essas fontes primeiro, proporcionando maior cobertura em servidores e contêineres.

**As fontes padrão afetam métricas de texto (kerning, avanços) e, portanto, quebras de linha e envolvimento?**

Sim. Alterar a fonte modifica as métricas dos glifos e pode mudar quebras de linha, envolvimento e paginação durante a renderização. Para estabilidade de layout, [incorpore as fontes originais](/slides/pt/php-java/embedded-font/) ou selecione famílias padrão e de fallback compatíveis metricamente.

**Há alguma utilidade em definir fontes padrão se todas as fontes usadas na apresentação estão incorporadas?**

Frequentemente não é necessário, pois [fonts incorporados](/slides/pt/php-java/embedded-font/) já garantem aparência consistente. As fontes padrão ainda ajudam como rede de segurança para caracteres não cobertos pelo subconjunto incorporado ou quando um arquivo mistura texto incorporado e não incorporado.