---
title: Especificar Fontes de Fallback para Apresentações em .NET
linktitle: Fonte de Fallback
type: docs
weight: 10
url: /pt/net/create-fallback-font/
keywords:
- fonte de fallback
- regra de fallback
- aplicar fonte
- substituir fonte
- faixa Unicode
- glifo ausente
- glifo correto
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Domine o Aspose.Slides para .NET para definir fontes de fallback em arquivos PPT, PPTX e ODP, garantindo a exibição consistente de texto em qualquer dispositivo ou sistema operacional."
---
## **Visão geral**

O Aspose.Slides permite especificar fontes de fallback para renderização e exportação de apresentações. As fontes de fallback são usadas quando a fonte principal não contém glifos para determinados caracteres.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. Você pode definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar múltiplas regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o arquivo da apresentação e não são armazenadas dentro do arquivo PPTX.

## **Regras de Fallback**

O Aspose.Slides oferece suporte à interface [IFontFallBackRule](https://reference.aspose.com/slides/pt/net/aspose.slides/iFontFallBackRule) e à classe [FontFallBackRule](https://reference.aspose.com/slides/pt/net/aspose.slides/FontFallBackRule) para especificar as regras de aplicação de uma fonte de fallback. A classe [FontFallBackRule](https://reference.aspose.com/slides/pt/net/aspose.slides/FontFallBackRule) representa uma associação entre o intervalo Unicode especificado, usado para procurar glifos ausentes, e uma lista de fontes que podem conter os glifos adequados:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Usando diferentes formas, você pode adicionar a lista de fontes:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Também é possível [Remove()](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontfallbackrule/methods/remove) a fonte de fallback ou [AddFallBackFonts()](https://reference.aspose.com/slides/pt/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) em um objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/net/aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/pt/net/aspose.slides/fontfallbackrulescollection) pode ser usado para organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/net/aspose.slides/FontFallBackRule), quando for necessário especificar regras de substituição de fonte de fallback para múltiplos intervalos Unicode.

{{% alert color="primary" title="Veja também" %}} 
- [Criar Coleção de Fontes de Fallback](/slides/pt/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Perguntas Frequentes**

**Qual é a diferença entre uma fonte de fallback, substituição de fonte e incorporação de fonte?**

Uma fonte de fallback é usada apenas para caracteres ausentes na fonte principal. **Substituição de fonte**[/slides/pt/net/font-substitution/] substitui toda a fonte especificada por outra fonte. **Incorporação de fonte**[/slides/pt/net/embedded-font/] inclui as fontes dentro do arquivo de saída para que os destinatários visualizem o texto como planejado.

**As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização na tela?**

Sim. O fallback afeta todas as [operações de renderização e exportação](/slides/pt/net/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte de origem.

**Configurar fallback altera o próprio arquivo da apresentação e a configuração persiste em aberturas futuras?**

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

**O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes influenciam a seleção de fallback?**

Sim. O mecanismo resolve fontes a partir das pastas do sistema disponíveis e de quaisquer [caminhos adicionais](/slides/pt/net/custom-font/) que você fornecer. Se uma fonte não estiver fisicamente disponível, uma regra que a referencia não poderá ser aplicada.

**O fallback funciona para WordArt, SmartArt e gráficos?**

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar os caracteres ausentes.