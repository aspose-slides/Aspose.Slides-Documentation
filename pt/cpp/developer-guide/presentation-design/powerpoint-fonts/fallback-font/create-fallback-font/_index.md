---
title: Especificar fontes de fallback para apresentações em C++
linktitle: Fonte de fallback
type: docs
weight: 10
url: /pt/cpp/create-fallback-font/
keywords:
- fonte de fallback
- regra de fallback
- aplicar fonte
- substituir fonte
- intervalo Unicode
- glifo ausente
- glifo correto
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Domine o Aspose.Slides para C++ e defina fontes de fallback em arquivos PPT, PPTX e ODP, garantindo a exibição consistente de texto em qualquer dispositivo ou sistema operacional."
---
## **Visão geral**

Aspose.Slides permite especificar fontes de fallback para a renderização e operações de exportação de apresentações. As fontes de fallback são usadas quando a fonte principal não contém glifos para caracteres específicos.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. Você pode definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar várias regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o arquivo da apresentação e não são armazenadas dentro do arquivo PPTX.

## **Regras de fallback**

Aspose.Slides oferece suporte à interface [IFontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontfallbackrule/) e à classe [FontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/) para especificar as regras de aplicação de uma fonte de fallback. A classe [FontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/) representa uma associação entre o intervalo Unicode especificado, usado para buscar glifos ausentes, e uma lista de fontes que podem conter os glifos corretos:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```



Também é possível [Remove()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontfallbackrule/remove/) uma fonte de fallback ou [AddFallBackFonts()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) em um objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrulescollection/) pode ser usada para organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/) quando for necessário especificar regras de substituição de fontes de fallback para múltiplos intervalos Unicode.

{{% alert color="primary" title="See also" %}} 
- [Criar coleção de fontes de fallback](/slides/pt/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **Perguntas frequentes**

**Qual é a diferença entre uma fonte de fallback, substituição de fonte e incorporação de fonte?**

Uma fonte de fallback é usada apenas para caracteres ausentes na fonte principal. [Font substitution](/slides/pt/cpp/font-substitution/) substitui toda a fonte especificada por outra fonte. [Font embedding](/slides/pt/cpp/embedded-font/) inclui as fontes dentro do arquivo de saída para que os destinatários vejam o texto como planejado.

**As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização em tela?**

Sim. O fallback afeta todas as [rendering and export operations](/slides/pt/cpp/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte de origem.

**Configurar fallback altera o próprio arquivo da apresentação e a configuração persiste em aberturas futuras?**

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; elas não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

**O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes afetam a seleção de fallback?**

Sim. O mecanismo resolve fontes a partir das pastas do sistema disponíveis e de quaisquer [additional paths](/slides/pt/cpp/custom-font/) que você fornecer. Se uma fonte não estiver fisicamente disponível, uma regra que a referencia não terá efeito.

**O fallback funciona para WordArt, SmartArt e gráficos?**

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar os caracteres ausentes.