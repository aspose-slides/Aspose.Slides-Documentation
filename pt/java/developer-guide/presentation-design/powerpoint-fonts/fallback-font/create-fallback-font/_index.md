---
title: Especificar fontes de fallback para apresentações em Java
linktitle: Fonte de fallback
type: docs
weight: 10
url: /pt/java/create-fallback-font/
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
- Java
- Aspose.Slides
description: "Domine o Aspose.Slides para Java para definir fontes de fallback em arquivos PPT, PPTX e ODP, garantindo exibição de texto consistente em qualquer dispositivo ou sistema operacional."
---
## **Visão geral**

O Aspose.Slides permite que você especifique fontes de fallback para renderização e operações de exportação de apresentações. As fontes de fallback são usadas quando a fonte principal não contém glifos para determinados caracteres.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. Você pode definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar várias regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o próprio arquivo da apresentação e não são armazenadas dentro do arquivo PPTX.

## **Regras de Fallback**

O Aspose.Slides oferece suporte à interface [IFontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IFontFallBackRule) e à classe [FontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule) para especificar as regras de aplicação de uma fonte de fallback. A classe [FontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule) representa uma associação entre o intervalo Unicode especificado, usado para procurar glifos ausentes, e uma lista de fontes que podem conter os glifos corretos:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Usando várias maneiras você pode adicionar a lista de fontes:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Também é possível [remover](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) a fonte de fallback ou [addFallBackFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) em um objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRulesCollection) pode ser usada para organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule), quando houver necessidade de especificar regras de substituição de fonte de fallback para vários intervalos Unicode.

{{% alert color="primary" title="Veja também" %}} 
- [Criar coleção de fontes de fallback](/slides/pt/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Perguntas frequentes**

**Qual é a diferença entre uma fonte de fallback, substituição de fonte e incorporação de fonte?**

Uma fonte de fallback é usada apenas para caracteres ausentes na fonte principal. [Substituição de fonte](/slides/pt/java/font-substitution/) substitui toda a fonte especificada por outra fonte. [Incorporação de fonte](/slides/pt/java/embedded-font/) empacota as fontes dentro do arquivo de saída para que os destinatários possam visualizar o texto conforme esperado.

**As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização em tela?**

Sim. O fallback afeta todas as [operações de renderização e exportação](/slides/pt/java/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte de origem.

**Configurar fallback altera o próprio arquivo da apresentação e a configuração permanecerá nas próximas aberturas?**

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; elas não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

**O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes influenciam a seleção de fallback?**

Sim. O mecanismo resolve fontes a partir das pastas de sistema disponíveis e quaisquer [caminhos adicionais](/slides/pt/java/custom-font/) que você fornecer. Se uma fonte não estiver fisicamente disponível, uma regra que a referencia não poderá ser aplicada.

**O fallback funciona para WordArt, SmartArt e gráficos?**

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar caracteres ausentes.