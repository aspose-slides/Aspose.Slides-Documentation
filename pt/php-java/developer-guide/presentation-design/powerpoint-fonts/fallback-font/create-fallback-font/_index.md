---
title: Especificar fontes de fallback para apresentações em PHP
linktitle: Fonte de fallback
type: docs
weight: 10
url: /pt/php-java/create-fallback-font/
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
- PHP
- Aspose.Slides
description: "Domine o Aspose.Slides para PHP via Java para definir fontes de fallback em arquivos PPT, PPTX e ODP, garantindo exibição consistente do texto em qualquer dispositivo ou sistema operacional."
---
## **Visão geral**

O Aspose.Slides permite especificar fontes de fallback para a renderização e operações de exportação de apresentações. As fontes de fallback são usadas quando a fonte principal não contém glifos para determinados caracteres.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. É possível definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar várias regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o arquivo da apresentação em si e não são armazenadas dentro do arquivo PPTX.

## **Regras de fallback**

O Aspose.Slides oferece a classe [FontFallBackRule](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRule) para especificar as regras de aplicação de uma fonte de fallback. A classe [FontFallBackRule](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRule) representa uma associação entre o intervalo Unicode especificado, usado para buscar glifos ausentes, e uma lista de fontes que podem conter os glifos corretos:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Usando várias maneiras, você pode adicionar a lista de fontes:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Também é possível [remover](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontfallbackrule/remove/) fonte de fallback ou [addFallBackFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) em um objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRule) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRulesCollection) pode ser usada para organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/php-java/aspose.slides/FontFallBackRule), quando houver a necessidade de especificar regras de substituição de fontes de fallback para vários intervalos Unicode.

{{% alert color="primary" title="Veja também" %}} 
- [Criar coleção de fontes de fallback](/slides/pt/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **Perguntas frequentes**

**Qual a diferença entre fonte de fallback, substituição de fonte e incorporação de fonte?**

Uma fonte de fallback é usada apenas para os caracteres ausentes na fonte principal. A [substituição de fonte](/slides/pt/php-java/font-substitution/) substitui toda a fonte especificada por outra fonte. A [incorporação de fonte](/slides/pt/php-java/embedded-font/) inclui as fontes dentro do arquivo de saída para que os destinatários possam visualizar o texto conforme pretendido.

**As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização na tela?**

Sim. O fallback afeta todas as [operações de renderização e exportação](/slides/pt/php-java/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte original.

**Configurar fallback altera o próprio arquivo da apresentação e a configuração persiste em aberturas futuras?**

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; elas não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

**O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes afetam a seleção de fallback?**

Sim. O mecanismo resolve fontes a partir das pastas do sistema disponíveis e de quaisquer [caminhos adicionais](/slides/pt/php-java/custom-font/) que você fornecer. Se uma fonte não estiver fisicamente disponível, uma regra que a referencie não poderá ser aplicada.

**O fallback funciona para WordArt, SmartArt e gráficos?**

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar os caracteres ausentes.