---
title: Especificar Fontes de Fallback para Apresentações em Java
linktitle: Fonte de Fallback
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

O Aspose.Slides permite que você especifique fontes de fallback para renderização e exportação de apresentações. As fontes de fallback são usadas quando a fonte principal não contém glifos para determinados caracteres.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. Você pode definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar várias regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o próprio arquivo de apresentação e não são armazenadas dentro do arquivo PPTX.

## **Regras de Fallback**

O Aspose.Slides oferece suporte à interface [IFontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IFontFallBackRule) e à classe [FontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule) para especificar as regras de aplicação de uma fonte de fallback. A classe [FontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule) representa uma associação entre o intervalo Unicode especificado, usado para buscar glifos ausentes, e uma lista de fontes que podem conter os glifos corretos:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Usando várias maneiras você pode adicionar a lista de fontes:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Também é possível [remover](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) a fonte de fallback ou [addFallBackFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) em um objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule) existente.

A classe [FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRulesCollection) pode ser usada para organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/java/com.aspose.slides/FontFallBackRule), quando houver necessidade de especificar regras de substituição de fontes de fallback para múltiplos intervalos Unicode.

{{% alert color="info" title="See also" %}} 
- [Criar Coleção de Fontes de Fallback](/slides/pt/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Perguntas Frequentes**

### Qual é a diferença entre uma fonte de fallback, substituição de fonte e incorporação de fonte?

Uma fonte de fallback é usada apenas para caracteres que faltam na fonte principal. A [substituição de fonte](/slides/pt/java/font-substitution/) substitui toda a fonte especificada por outra fonte. A [incorporação de fonte](/slides/pt/java/embedded-font/) inclui as fontes dentro do arquivo de saída para que os destinatários possam visualizar o texto como previsto.

### As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização em tela?

Sim. O fallback afeta todas as [operações de renderização e exportação](/slides/pt/java/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte de origem.

### Configurar fallback altera o próprio arquivo de apresentação e a configuração persiste em aberturas futuras?

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; elas não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

### O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes afetam a seleção de fallback?

Sim. O mecanismo resolve fontes a partir das pastas de sistema disponíveis e de quaisquer [caminhos adicionais](/slides/pt/java/custom-font/) que você fornecer. Se uma fonte não estiver fisicamente disponível, uma regra que a referencia não poderá ser aplicada.

### O fallback funciona para WordArt, SmartArt e gráficos?

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar caracteres ausentes.