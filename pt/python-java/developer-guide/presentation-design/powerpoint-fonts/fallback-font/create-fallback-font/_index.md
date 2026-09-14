---
title: Especificar fontes de fallback para apresentações em Python via Java
linktitle: Fonte de fallback
type: docs
weight: 10
url: /pt/python-java/create-fallback-font/
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
- Python
- Java
- Aspose.Slides
description: "Domine o Aspose.Slides para Python via Java para definir fontes de fallback em arquivos PPT, PPTX e ODP, garantindo exibição de texto consistente em qualquer dispositivo ou SO."
---
## **Visão geral**

O Aspose.Slides permite especificar fontes de fallback para a renderização e exportação de apresentações. As fontes de fallback são usadas quando a fonte principal não contém glifos para determinados caracteres.

O comportamento de fallback é configurado por meio de regras de fallback. Cada regra associa um intervalo Unicode a uma ou mais fontes que podem conter os glifos necessários. Você pode definir regras para diferentes intervalos de caracteres, adicionar ou remover fontes de fallback de regras existentes e organizar várias regras em uma coleção de regras de fontes de fallback.

As regras de fallback são configurações de renderização em tempo de execução. Elas não modificam o arquivo da apresentação e não são armazenadas dentro do arquivo PPTX.

## **Regras de fallback**

O Aspose.Slides fornece a classe [FontFallBackRule](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrule/) para especificar regras de aplicação de fontes de fallback. Esta classe representa uma associação entre um intervalo Unicode usado para buscar glifos ausentes e uma lista de fontes que podem conter os glifos necessários:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Use múltiplas maneiras de especificar uma lista de fontes.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Você também pode remover uma fonte de fallback usando [remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrule/#remove) ou adicionar fontes de fallback usando [addFallBackFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) em um objeto [FontFallBackRule](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrule/) existente.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrulescollection/) pode organizar uma lista de objetos [FontFallBackRule](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontfallbackrule/) quando você precisar especificar regras de substituição de fontes de fallback para vários intervalos Unicode.

{{% alert color="info" title="See also" %}} 
- [Criar coleção de fontes de fallback](/slides/pt/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre uma fonte de fallback, substituição de fonte e incorporação de fonte?**

Uma fonte de fallback é usada apenas para caracteres ausentes na fonte principal. [Font substitution](/slides/pt/python-java/font-substitution/) substitui toda a fonte especificada por outra fonte. [Font embedding](/slides/pt/python-java/embedded-font/) incorpora as fontes dentro do arquivo de saída para que os destinatários possam visualizar o texto como previsto.

**As fontes de fallback são aplicadas durante exportações como PDF, PNG ou SVG, ou apenas na renderização em tela?**

Sim. O fallback afeta todas as [rendering and export operations](/slides/pt/python-java/convert-presentation/) onde os caracteres precisam ser desenhados, mas estão ausentes na fonte de origem.

**Configurar fallback altera o próprio arquivo da apresentação e a configuração persiste em aberturas futuras?**

Não. As regras de fallback são configurações de renderização em tempo de execução no seu código; elas não são armazenadas dentro do .pptx e não aparecerão no PowerPoint.

**O sistema operacional (Windows/Linux/macOS) e o conjunto de diretórios de fontes afetam a seleção de fallback?**

Sim. O mecanismo resolve fontes das pastas do sistema disponíveis e de quaisquer [additional paths](/slides/pt/python-java/custom-font/) que você forneça. Se uma fonte não estiver fisicamente disponível, uma regra que a referencia não poderá ter efeito.

**O fallback funciona para WordArt, SmartArt e gráficos?**

Sim. Quando esses objetos contêm texto, o mesmo mecanismo de substituição de glifos é aplicado para renderizar os caracteres ausentes.