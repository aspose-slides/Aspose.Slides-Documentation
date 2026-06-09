---
title: Especificar fontes de fallback para apresentações em JavaScript
linktitle: Fonte de fallback
type: docs
weight: 10
url: /pt/nodejs-java/create-fallback-font/
keywords:
- fonte de fallback
- regra de fallback
- aplicar fonte
- substituir fonte
- intervalo Unicode
- glifo ausente
- glifo adequado
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine o Aspose.Slides para Node.js para definir fontes de fallback em arquivos PPT, PPTX e ODP em JavaScript, garantindo a exibição consistente de texto em qualquer dispositivo ou sistema operacional."
---
## **Visão geral**

Aspose.Slides permite que você especifique fontes de fallback para a renderização e exportação de apresentações. As fontes de fallback são usadas quando a fonte principal não contém glifos para determinados caracteres.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. Você pode definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar várias regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o próprio arquivo da apresentação e não são armazenadas dentro do arquivo PPTX.

## **Regras de fallback**

Aspose.Slides suporta a classe [FontFallBackRule](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule) e [FontFallBackRule](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule) para especificar as regras a serem aplicadas a uma fonte de fallback. A classe [FontFallBackRule](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule) representa uma associação entre o intervalo Unicode especificado, usado para buscar glifos ausentes, e uma lista de fontes que podem conter glifos adequados:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Usando diferentes formas, você pode adicionar a lista de fontes:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Também é possível [remove](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) a fonte de fallback ou [addFallBackFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) no objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRulesCollection) pode ser usada para organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/FontFallBackRule) quando houver necessidade de especificar regras de substituição de fontes de fallback para vários intervalos Unicode.

{{% alert color="primary" title="Veja também" %}} 
- [Criar coleção de fontes de fallback](/slides/pt/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre uma fonte de fallback, substituição de fonte e incorporação de fonte?**

Uma fonte de fallback é usada apenas para caracteres ausentes na fonte principal. [Font substitution](/slides/pt/nodejs-java/font-substitution/) substitui toda a fonte especificada por outra fonte. [Font embedding](/slides/pt/nodejs-java/embedded-font/) incorpora as fontes dentro do arquivo de saída para que os destinatários possam visualizar o texto como previsto.

**As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização em tela?**

Sim. O fallback afeta todas as [operações de renderização e exportação](/slides/pt/nodejs-java/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte de origem.

**Configurar fallback altera o próprio arquivo da apresentação e a configuração persistirá em aberturas futuras?**

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; elas não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

**O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes afetam a seleção de fallback?**

Sim. O mecanismo resolve fontes a partir das pastas do sistema disponíveis e de quaisquer [caminhos adicionais](/slides/pt/nodejs-java/custom-font/) que você forneça. Se uma fonte não estiver fisicamente disponível, uma regra que a referencia não terá efeito.

**O fallback funciona para WordArt, SmartArt e gráficos?**

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar caracteres ausentes.