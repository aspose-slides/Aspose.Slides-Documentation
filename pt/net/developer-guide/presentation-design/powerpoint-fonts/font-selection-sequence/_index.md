---
title: Sequência de Seleção de Fonte no Aspose.Slides para .NET
linktitle: Seleção de Fonte
type: docs
weight: 80
url: /pt/net/font-selection-sequence/
keywords:
- seleção de fonte
- substituição de fonte
- substituição de fonte
- regra de substituição
- fonte disponível
- fonte ausente
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Descubra como o Aspose.Slides para .NET seleciona fontes, garantindo apresentações nítidas e consistentes de arquivos PPT, PPTX e ODP - melhore seus slides agora."
---
## **Visão geral**

Quando uma apresentação é carregada, renderizada ou convertida para outro formato, o Aspose.Slides considera suas fontes incorporadas e as fontes disponíveis para a aplicação. Se uma fonte necessária não estiver disponível, o Aspose.Slides seleciona uma fonte substituta que seja o mais próximo possível da que o PowerPoint utilizaria.

As fontes disponíveis podem incluir fontes do sistema, fontes carregadas pela aplicação e fontes incorporadas na apresentação. Para uma correspondência entre fonte incorporada e registrada, a preferência .NET 26.11 descrita abaixo controla qual tem prioridade. As regras de substituição de fontes definidas através de [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) são um mecanismo separado.

Você também pode adicionar fontes em tempo de execução da aplicação, usar fontes incorporadas de uma apresentação ou carregar fontes externas para documentos de saída, como arquivos PDF.

## **Seleção de Fonte**

O texto pode referenciar uma fonte de tema, como `+mn-lt`, em vez de um nome de família explícito. Consulte [Resolver Referências de Fonte do Tema](/slides/pt/net/presentation-theme/#resolve-theme-font-references) para obter a família especificada pelo tema aplicável. Resolver essa referência é separado da verificação da disponibilidade de fontes e da aplicação de substituição em tempo de renderização ou fallback de glifos; não identifica o arquivo de fonte usado finalmente para renderizar o texto.

Ao renderizar slides ou converter uma apresentação, verifique se as fontes solicitadas estão incorporadas ou disponíveis nas fontes registradas. Fontes ausentes podem exigir substituição ou troca; veja [**Substituição de Fonte**](/slides/pt/net/font-replacement/) e [**Substituição de Fonte**](/slides/pt/net/font-substitution/).

Quando investigar a seleção de fontes:

1. Resolva a família e o estilo solicitados, incluindo qualquer referência de tema.
2. Verifique as fontes incorporadas e as fontes registradas, incluindo fontes do sistema e fontes carregadas pela aplicação. Use a preferência abaixo quando versões incorporadas e registradas em correspondência competirem.
3. Revise as [regras de substituição de fonte](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) e o fallback de glifos se a fonte ou os caracteres solicitados não estiverem disponíveis.

O Aspose.Slides permite que você adicione fontes em tempo de execução da aplicação e, em seguida, use essas fontes. Consulte [**Fontes personalizadas**](/slides/pt/net/custom-font/).

Quando fontes adicionais são colocadas dentro de uma apresentação, elas são chamadas de [**Fontes incorporadas**](/slides/pt/net/embedded-font/).

O Aspose.Slides permite que você adicione fontes que são aplicadas *apenas* a documentos de saída. Por exemplo, se uma apresentação que você deseja converter para PDF contém fontes ausentes do seu sistema e fontes incorporadas, você pode adicionar ou carregar as fontes necessárias como **fontes externas**.

{{% alert title="Note" color="info" %}} 
Não distribuímos nenhuma fonte, seja paga ou gratuita. Nossa API permite que você carregue fontes externas e as incorpore em documentos, mas você faz isso com as fontes a seu critério e responsabilidade.
{{% /alert %}}

## **Preferir Fontes Registradas em vez de Fontes Incorporadas**

A partir do .NET 26.11, [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) permite que uma fonte registrada correspondente tenha prioridade sobre uma fonte incorporada durante a exportação. O padrão é `false`. A correspondência usa o nome e o estilo da fonte; um nome de família diferente não é uma correspondência de substituição. Fontes registradas podem vir do sistema ou de [fontes carregadas explicitamente](/slides/pt/net/custom-font/).

O exemplo a seguir usa o pacote **Aspose.Slides.NET6.CrossPlatform 26.11** no .NET 8. Siga o [guia de instalação](/slides/pt/net/installation/) para o seu ambiente. Forneça `embedded-fonts.pptx` com uma fonte incorporada e `preferred.ttf` com o mesmo nome de família e estilo. Os dois arquivos de fonte devem diferir visivelmente se você quiser comparar a saída.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Esta configuração altera a precedência das fontes durante a exportação; não renomeia a fonte do texto, remove dados de fonte incorporada ou reinsere o arquivo registrado. É uma configuração em tempo de execução: defina-a novamente após reabrir uma apresentação. Se nenhuma fonte registrada correspondente estiver disponível, habilitar a preferência não fornece uma; verifique a fonte e o layout resultantes no seu ambiente de destino.

A saída PNG e PDF com fontes regulares carregadas explicitamente foi verificada para a configuração acima. Verifique seus próprios arquivos de fonte, estilos, compilação do SDK e formatos de saída antes de depender de resultados idênticos. Métricas de fonte podem alterar quebras de linha e posicionamento. Use [substituição de fonte](/slides/pt/net/font-replacement/) ou [substituição](/slides/pt/net/font-substitution/) quando precisar de uma família diferente, e [operações de fonte incorporada](/slides/pt/net/embedded-font/) quando precisar alterar as fontes armazenadas na apresentação.

## **Perguntas Frequentes**

**Como posso determinar quais fontes são realmente usadas em uma apresentação antes da conversão?**

O Aspose.Slides permite que você inspecione as fontes usadas através do [gerenciador de fontes](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), para que você possa decidir se [incorpora](/slides/pt/net/embedded-font/), [substitui](/slides/pt/net/font-replacement/) ou adiciona [fontes externas](/slides/pt/net/custom-font/). Isso ajuda a evitar substituições indesejadas durante a renderização e exportação.

**Posso adicionar diretórios de fontes extras sem instalá-los no sistema operacional?**

Sim. Você pode registrar [fontes externas](/slides/pt/net/custom-font/) como pastas ou fluxos em memória para renderização e exportação. Isso remove a dependência das fontes do sistema host e mantém o layout previsível.

**Como impedir um fallback silencioso para uma fonte inadequada quando um glifo está ausente?**

Defina explicitamente [substituição de fonte](/slides/pt/net/font-replacement/) e [regras de fallback de fonte](/slides/pt/net/fallback-font/) com antecedência. Ao analisar as fontes usadas e definir uma prioridade controlada para os substitutos, você garante tipografia consistente e evita resultados inesperados.