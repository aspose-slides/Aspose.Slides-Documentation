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
description: "Domine o Aspose.Slides para C++ para definir fontes de fallback em arquivos PPT, PPTX e ODP, garantindo exibição de texto consistente em qualquer dispositivo ou sistema operacional."
---
## **Visão geral**

O Aspose.Slides permite que você especifique fontes de fallback para a renderização e operações de exportação de apresentações. As fontes de fallback são usadas quando a fonte principal não contém glifos para caracteres específicos.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. Você pode definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar várias regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o próprio arquivo da apresentação e não são armazenadas dentro do arquivo PPTX.

## **Regras de fallback**

O Aspose.Slides oferece suporte à interface [IFontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontfallbackrule/) e à classe [FontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/) para especificar as regras a serem aplicadas a uma fonte de fallback. A classe [FontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/) representa uma associação entre o intervalo Unicode especificado, usado para buscar glifos ausentes, e uma lista de fontes que podem conter os glifos corretos:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Usando várias maneiras você pode adicionar lista de fontes:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Também é possível [Remove()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontfallbackrule/remove/) a fonte de fallback ou [AddFallBackFonts()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) em um objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrulescollection/) pode ser usado para organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fontfallbackrule/), quando for necessário especificar regras de substituição de fontes de fallback para vários intervalos Unicode.

{{% alert color="primary" title="Veja também" %}} 
- [Criar coleção de fontes de fallback](/slides/pt/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre uma fonte de fallback, substituição de fonte e incorporação de fonte?**

Uma fonte de fallback é usada apenas para caracteres que faltam na fonte principal. [Font substitution](/slides/pt/cpp/font-substitution/) substitui toda a fonte especificada por outra fonte. [Font embedding](/slides/pt/cpp/embedded-font/) incorpora as fontes dentro do arquivo de saída para que os destinatários possam visualizar o texto como pretendido.

**As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização em tela?**

Sim. O fallback afeta todas as [operações de renderização e exportação](/slides/pt/cpp/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte de origem.

**Configurar fallback altera o próprio arquivo da apresentação, e a configuração persistirá em futuras aberturas?**

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; elas não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

**O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes afetam a seleção de fallback?**

Sim. O mecanismo resolve fontes a partir das pastas de sistema disponíveis e de quaisquer [caminhos adicionais](/slides/pt/cpp/custom-font/) que você fornecer. Se uma fonte não estiver fisicamente disponível, uma regra que a referencie não poderá ter efeito.

**O fallback funciona para WordArt, SmartArt e gráficos?**

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar os caracteres ausentes.