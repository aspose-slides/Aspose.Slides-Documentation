---
title: Especificar fontes de fallback para apresentações em Python
linktitle: Fonte de fallback
type: docs
weight: 10
url: /pt/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "Domine o Aspose.Slides para Python via .NET para definir fontes de fallback em arquivos PPT, PPTX e ODP, garantindo exibição consistente de texto em qualquer dispositivo ou sistema operacional."
---
## **Visão geral**

Aspose.Slides permite especificar fontes de fallback para renderização de apresentações e operações de exportação. As fontes de fallback são usadas quando a fonte principal não contém glifos para determinados caracteres.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. Você pode definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar várias regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o arquivo da apresentação e não são armazenadas dentro do arquivo PPTX.

## **Especificar fontes de fallback**

Aspose.Slides oferece suporte à classe [FontFallBackRule](https://reference.aspose.com/slides/pt/python-net/aspose.slides/FontFallBackRule/) para especificar as regras que aplicam uma fonte de fallback. A classe [FontFallBackRule](https://reference.aspose.com/slides/pt/python-net/aspose.slides/FontFallBackRule/) representa uma associação entre o intervalo Unicode especificado, usado para pesquisar glifos ausentes, e uma lista de fontes que podem conter os glifos adequados:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Usando várias maneiras, você pode adicionar lista de fontes:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```



Também é possível [remove](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontfallbackrule/remove/) uma fonte de fallback ou [add_fall_back_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) em um objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/python-net/aspose.slides/FontFallBackRule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontfallbackrulescollection/) pode ser usada para organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/python-net/aspose.slides/FontFallBackRule/) quando for necessário especificar regras de substituição de fontes de fallback para vários intervalos Unicode.

{{% alert color="primary" title="Veja também" %}} 
- [Create Fallback Fonts Collection](/slides/pt/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **Perguntas frequentes**

**Qual a diferença entre fonte de fallback, substituição de fonte e incorporação de fonte?**

Uma fonte de fallback é usada apenas para caracteres ausentes na fonte principal. [Font substitution](/slides/pt/python-net/font-substitution/) substitui toda a fonte especificada por outra fonte. [Font embedding](/slides/pt/python-net/embedded-font/) inclui as fontes dentro do arquivo de saída para que os destinatários vejam o texto como pretendido.

**As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização na tela?**

Sim. O fallback afeta todas as [rendering and export operations](/slides/pt/python-net/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte de origem.

**Configurar o fallback altera o próprio arquivo da apresentação e a configuração persiste em aberturas futuras?**

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

**O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes influenciam a seleção de fallback?**

Sim. O mecanismo resolve fontes a partir das pastas do sistema disponíveis e de quaisquer [additional paths](/slides/pt/python-net/custom-font/) que você forneça. Se uma fonte não estiver fisicamente disponível, uma regra que a referencia não pode entrar em vigor.

**O fallback funciona para WordArt, SmartArt e gráficos?**

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar os caracteres ausentes.