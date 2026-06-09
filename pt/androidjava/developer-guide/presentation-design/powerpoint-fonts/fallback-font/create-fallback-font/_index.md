---
title: Especificar fontes de fallback para apresentações no Android
linktitle: Fonte de fallback
type: docs
weight: 10
url: /pt/androidjava/create-fallback-font/
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
- Android
- Java
- Aspose.Slides
description: "Domine o Aspose.Slides para Android via Java para definir fontes de fallback em arquivos PPT, PPTX e ODP, garantindo a exibição consistente de texto em qualquer dispositivo ou sistema operacional."
---
## **Visão geral**

Aspose.Slides permite especificar fontes de fallback para renderização e exportação de apresentações. As fontes de fallback são usadas quando a fonte principal não contém glifos para caracteres específicos.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. Você pode definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar várias regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o arquivo da apresentação e não são armazenadas dentro do arquivo PPTX.

## **Regras de fallback**

Aspose.Slides oferece a interface [IFontFallBackRule](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IFontFallBackRule) e a classe [FontFallBackRule](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRule) para especificar as regras de aplicação de uma fonte de fallback. A classe [FontFallBackRule](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRule) representa uma associação entre o intervalo Unicode especificado, usado para buscar glifos ausentes, e uma lista de fontes que podem conter os glifos corretos:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Usando várias maneiras, você pode adicionar a lista de fontes:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Também é possível [remove](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) a fonte de fallback ou [addFallBackFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) em um objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRulesCollection) pode ser usada para organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/FontFallBackRule), quando há necessidade de especificar regras de substituição de fontes de fallback para vários intervalos Unicode.

{{% alert color="primary" title="Veja também" %}} 
- [Criar coleção de fontes de fallback](/slides/pt/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre fonte de fallback, substituição de fonte e incorporação de fonte?**

Uma fonte de fallback é usada apenas para caracteres que faltam na fonte principal. [Substituição de fonte](/slides/pt/androidjava/font-substitution/) substitui toda a fonte especificada por outra fonte. [Incorporação de fonte](/slides/pt/androidjava/embedded-font/) inclui as fontes dentro do arquivo de saída para que os destinatários visualizem o texto como pretendido.

**As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização na tela?**

Sim. O fallback afeta todas as [operações de renderização e exportação](/slides/pt/androidjava/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte de origem.

**Configurar fallback altera o próprio arquivo da apresentação e a configuração persiste em aberturas futuras?**

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; elas não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

**O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes influenciam a seleção de fallback?**

Sim. O mecanismo resolve fontes a partir das pastas do sistema disponíveis e de quaisquer [caminhos adicionais](/slides/pt/androidjava/custom-font/) que você fornecer. Se uma fonte não estiver fisicamente disponível, uma regra que a referencia não pode entrar em vigor.

**O fallback funciona para WordArt, SmartArt e gráficos?**

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar os caracteres ausentes.