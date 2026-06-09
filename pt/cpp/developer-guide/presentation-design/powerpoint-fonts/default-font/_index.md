---
title: Especificar fontes padrão de apresentação em C++
linktitle: Fonte padrão
type: docs
weight: 30
url: /pt/cpp/default-font/
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
- C++
- Aspose.Slides
description: "Defina fontes padrão no Aspose.Slides para C++ para garantir a conversão correta de PowerPoint (PPT, PPTX) e OpenDocument (ODP) para PDF, XPS e imagens."
---
## **Visão geral**

O Aspose.Slides permite especificar fontes padrão que são usadas quando uma apresentação é renderizada. Isso é útil ao gerar miniaturas de slides ou ao exportar uma apresentação para formatos como PDF e XPS. As fontes padrão são configuradas através de `LoadOptions` antes da apresentação ser carregada.

O método `set_DefaultRegularFont` define a fonte padrão para texto regular, enquanto `set_DefaultAsianFont` define a fonte padrão para texto asiático. Depois que essas opções são definidas, a apresentação pode ser carregada e renderizada usando as fontes especificadas.

## **Usar fontes padrão ao renderizar uma apresentação**
O Aspose.Slides permite definir a fonte padrão ao renderizar a apresentação para PDF, XPS ou miniaturas. Este artigo mostra como definir DefaultRegularFont e DefaultAsianFont para uso como fontes padrão. Siga os passos abaixo para carregar fontes de diretórios externos usando a API Aspose.Slides para C++:

1. Crie uma instância de LoadOptions.  
1. Defina DefaultRegularFont para a fonte desejada. No exemplo a seguir, eu usei Wingdings.  
1. Defina DefaultAsianFont para a fonte desejada. Usei Wingdings no exemplo a seguir.  
1. Carregue a apresentação usando Presentation e definindo as opções de carregamento.  
1. Agora, gere a miniatura do slide, PDF e XPS para verificar os resultados.

A implementação acima é apresentada abaixo.

```cpp
// Use as opções de carregamento para especificar fontes padrão regular e asiática
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **FAQ**

**O que exatamente DefaultRegularFont e DefaultAsianFont afetam — apenas exportação ou também miniaturas, PDF, XPS, HTML e SVG?**

Eles participam do pipeline de renderização para todas as saídas suportadas. Isso inclui miniaturas de slides, [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/pt/cpp/convert-powerpoint-to-xps/), [imagens raster](/slides/pt/cpp/convert-powerpoint-to-png/), [HTML](/slides/pt/cpp/convert-powerpoint-to-html/) e [SVG](/slides/pt/cpp/render-a-slide-as-an-svg-image/), porque o Aspose.Slides usa a mesma lógica de layout e resolução de glifos nesses destinos.

**As fontes padrão são aplicadas ao simplesmente ler e salvar um PPTX sem renderizar?**

Não. As fontes padrão são relevantes quando o texto precisa ser medido e desenhado. Uma simples abertura e salvamento de uma apresentação não altera as execuções de fonte armazenadas nem a estrutura do arquivo. As fontes padrão entram em ação durante operações que renderizam ou reorganizam o texto.

**Se eu adicionar minhas próprias pastas de fontes ou fornecer fontes da memória, elas serão consideradas ao escolher as fontes padrão?**

Sim. [Custom font sources](/slides/pt/cpp/custom-font/) expandem o catálogo de famílias e glifos disponíveis que o mecanismo pode usar. As fontes padrão e quaisquer [fallback rules](/slides/pt/cpp/fallback-font/) serão resolvidas contra essas fontes primeiro, proporcionando uma cobertura mais confiável em servidores e containers.

**As fontes padrão afetarão métricas de texto (kerning, avanços) e, consequentemente, quebras de linha e envolvimento?**

Sim. Alterar a fonte muda as métricas dos glifos e pode modificar quebras de linha, envolvimento de texto e paginação durante a renderização. Para estabilidade de layout, [embed the original fonts](/slides/pt/cpp/embedded-font/) ou selecione famílias padrão e de fallback compatíveis metricamente.

**Há algum sentido em definir fontes padrão se todas as fontes usadas na apresentação estiverem incorporadas?**

Frequentemente não é necessário, pois [embedded fonts](/slides/pt/cpp/embedded-font/) já garantem aparência consistente. As fontes padrão ainda ajudam como uma rede de segurança para caracteres não cobertos pelo subconjunto incorporado ou quando um arquivo mistura texto incorporado e não incorporado.