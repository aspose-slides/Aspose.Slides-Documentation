---
title: Configurar Substituição de Fonte em Apresentações no .NET
linktitle: Substituição de Fonte
type: docs
weight: 70
url: /pt/net/font-substitution/
keywords:
- fonte
- substituir fonte
- substituição de fonte
- trocar fonte
- substituição de fonte
- regra de substituição
- regra de substituição
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Habilite a substituição de fontes ideal no Aspose.Slides para .NET ao converter apresentações PowerPoint e OpenDocument para outros formatos de arquivo."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use outra fonte quando a fonte original da apresentação não está disponível durante a renderização ou conversão. Você pode verificar quais fontes foram substituídas usando o método `GetSubstitutions` da interface `IFontsManager`.

O Aspose.Slides também permite definir regras de substituição de fontes. Por exemplo, você pode especificar que uma fonte inacessível seja substituída por outra fonte disponível e então aplicar essas regras por meio do gerenciador de fontes da apresentação.

## **Obter substituições de fontes**

Para que você possa descobrir quais fontes da apresentação são substituídas durante o processo de renderização de uma apresentação, o Aspose.Slides fornece o método [GetSubstitution](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsmanager/getsubstitutions/) da interface [IFontsManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ifontsmanager/).

O código C# mostra como obter todas as substituições de fontes que são realizadas quando uma apresentação é renderizada:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Definir regras de substituição de fontes**

O Aspose.Slides permite definir regras para fontes que determinam o que deve ser feito em determinadas condições (por exemplo, quando uma fonte não pode ser acessada) da seguinte forma:

1. Carregue a apresentação relevante.  
2. Carregue a fonte que será substituída.  
3. Carregue a nova fonte.  
4. Adicione uma regra para a substituição.  
5. Adicione a regra à coleção de regras de substituição de fontes da apresentação.  
6. Gere a imagem do slide para observar o efeito.

Este código C# demonstra o processo de substituição de fontes:
```c#
// Carrega uma apresentação
Presentation presentation = new Presentation("Fonts.pptx");

// Carrega a fonte de origem que será substituída
IFontData sourceFont = new FontData("SomeRareFont");

// Carrega a nova fonte
IFontData destFont = new FontData("Arial");

// Adiciona uma regra de fonte para substituição de fonte
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Adiciona a regra à coleção de regras de substituição de fonte
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Adiciona a coleção de regras de fonte à lista de regras
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Salva a imagem no disco no formato JPEG
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Talvez você queira ver [**Font Replacement**](/slides/pt/net/font-replacement/). 
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes participam do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas são adequadas para cenários de texto regular em que o Aspose.Slides pode substituir uma fonte inacessível por outra fonte disponível de acordo com a regra configurada.

No entanto, as equações matemáticas do Office têm uma limitação importante. Se uma equação foi criada com **Cambria Math**, o Aspose.Slides ainda pode exigir a fonte original **Cambria Math** para calcular e renderizar o layout da equação corretamente. Por causa disso, substituir **Cambria Math** por outra fonte matemática, como **STIX Two Math**, não é suportado para a renderização de equações e pode ainda resultar em uma exceção indicando que **Cambria Math** é necessária.

Para converter essas apresentações com sucesso, certifique‑se de que **Cambria Math** esteja disponível para o Aspose.Slides em tempo de execução. Você pode instalar a fonte no sistema operacional ou fornecê‑la como uma [external font](/slides/pt/net/custom-font/) para que ela participe do processo normal de seleção de fontes durante a renderização e conversão.

Essa limitação é específica para a renderização de equações. As regras padrão de substituição de fontes descritas acima ainda se aplicam ao texto regular da apresentação quando a fonte original está inacessível.

## **Perguntas frequentes**

**Qual é a diferença entre Font Replacement e Font Substitution?**  
[Replacement](/slides/pt/net/font-replacement/) é uma substituição forçada de uma fonte por outra em toda a apresentação. Substitution é uma regra que é acionada sob uma condição específica, por exemplo quando a fonte original não está disponível, e então uma fonte de fallback designada é usada.

**Quando exatamente as regras de substituição são aplicadas?**  
As regras participam da sequência padrão de [font selection](/slides/pt/net/font-selection-sequence/) que é avaliada durante o carregamento, renderização e conversão; se a fonte escolhida não estiver disponível, será aplicada a substituição ou a substituição.

**Qual é o comportamento padrão se nem replacement nem substitution estiverem configurados e a fonte estiver ausente no sistema?**  
A biblioteca tentará escolher a fonte do sistema mais próxima disponível, similar ao comportamento do PowerPoint.

**Posso anexar fontes externas personalizadas em tempo de execução para evitar a substituição?**  
Sim. Você pode [add external fonts](/slides/pt/net/custom-font/) em tempo de execução para que a biblioteca as considere na seleção e renderização, inclusive para conversões subsequentes.

**A Aspose distribui alguma fonte com a biblioteca?**  
Não. A Aspose não distribui fontes pagas ou gratuitas; você adiciona e usa fontes por sua própria conta e risco.

**Existem diferenças no comportamento de substituição no Windows, Linux e macOS?**  
Sim. A descoberta de fontes começa a partir dos diretórios de fontes do sistema operacional. O conjunto de fontes padrão disponíveis e os caminhos de busca diferem entre as plataformas, o que afeta a disponibilidade e a necessidade de substituição.

**Como devo preparar o ambiente para minimizar substituições inesperadas durante conversões em lote?**  
Sincronize o conjunto de fontes entre máquinas ou contêineres, [add the external fonts](/slides/pt/net/custom-font/) necessárias para os documentos de saída e [embed fonts](/slides/pt/net/embedded-font/) nas apresentações, quando possível, para que as fontes escolhidas estejam disponíveis durante a renderização.