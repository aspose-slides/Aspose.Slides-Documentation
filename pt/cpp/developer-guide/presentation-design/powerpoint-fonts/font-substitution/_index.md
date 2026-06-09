---
title: Configurar Substituição de Fonte em Apresentações Usando C++
linktitle: Substituição de Fonte
type: docs
weight: 70
url: /pt/cpp/font-substitution/
keywords:
- fonte
- fonte substituta
- substituição de fonte
- substituir fonte
- substituição de fonte
- regra de substituição
- regra de substituição
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Habilite a substituição ideal de fontes no Aspose.Slides para C++ ao converter apresentações PowerPoint e OpenDocument para outros formatos de arquivo."
---
## **Visão geral**

A substituição de fontes permite que o Aspose.Slides use outra fonte quando a fonte original da apresentação não está disponível durante a renderização ou conversão. Você pode verificar quais fontes foram substituídas usando o método `GetSubstitutions` da interface `IFontsManager`.

O Aspose.Slides também permite que você defina regras de substituição de fontes. Por exemplo, é possível especificar que uma fonte inacessível seja substituída por outra fonte disponível e, em seguida, aplicar essas regras por meio do gerenciador de fontes da apresentação.

## **Definir regras de substituição de fontes**

O Aspose.Slides permite que você defina regras para fontes que determinam o que deve ser feito em determinadas condições (por exemplo, quando uma fonte não pode ser acessada) da seguinte maneira:

1. Carregue a apresentação relevante.  
2. Carregue a fonte que será substituída.  
3. Carregue a nova fonte.  
4. Adicione uma regra para a substituição.  
5. Adicione a regra à coleção de regras de substituição de fontes da apresentação.  
6. Gere a imagem do slide para observar o efeito.

Este código C++ demonstra o processo de substituição de fontes:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Carrega uma apresentação
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Define a fonte que será substituída e a nova fonte
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Adiciona uma regra de fonte para substituição
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Adiciona a regra à coleção de regras de substituição de fontes
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Adiciona a coleção de regras de fonte à lista de regras
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Salva o PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Você pode querer ver [**Substituição de Fonte**](/slides/pt/cpp/font-replacement/). 
{{% /alert %}}

## **Limitações para fontes de equações matemáticas**

As regras de substituição de fontes participam do processo padrão de seleção de fontes usado durante a renderização e conversão. Elas são adequadas para cenários de texto comum, onde o Aspose.Slides pode substituir uma fonte inacessível por outra fonte disponível de acordo com a regra configurada.

No entanto, as equações matemáticas do Office têm uma limitação importante. Se uma equação foi criada com **Cambria Math**, o Aspose.Slides ainda pode exigir a fonte original **Cambria Math** para calcular e renderizar o layout da equação corretamente. Por causa disso, substituir **Cambria Math** por outra fonte matemática, como **STIX Two Math**, não é suportado para a renderização de equações e ainda pode resultar em uma exceção indicando que **Cambria Math** é necessária.

Para converter essas apresentações com sucesso, certifique‑se de que **Cambria Math** esteja disponível para o Aspose.Slides em tempo de execução. Você pode instalar a fonte no sistema operacional ou fornecê‑la como uma [fonte externa](/slides/pt/cpp/custom-font/) para que ela possa participar do processo normal de seleção de fontes durante a renderização e conversão.

Esta limitação é específica para a renderização de equações. As regras padrão de substituição de fontes descritas acima ainda se aplicam ao texto regular da apresentação quando a fonte original está inacessível.

## **Perguntas frequentes**

**Qual é a diferença entre substituição de fonte e substituição de fonte?**  
[Substituição de Fonte](/slides/pt/cpp/font-replacement/) é uma sobrescrita forçada de uma fonte por outra em toda a apresentação. Substituição é uma regra que é acionada sob uma condição específica, por exemplo quando a fonte original está indisponível, e então uma fonte de fallback designada é usada.

**Quando exatamente as regras de substituição são aplicadas?**  
As regras participam da sequência padrão de [seleção de fontes](/slides/pt/cpp/font-selection-sequence/) que é avaliada durante o carregamento, renderização e conversão; se a fonte escolhida não estiver disponível, a substituição ou a substituição será aplicada.

**Qual é o comportamento padrão se nem substituição nem substituição estiver configurada e a fonte estiver ausente no sistema?**  
A biblioteca tentará escolher a fonte do sistema mais próxima disponível, semelhante ao comportamento do PowerPoint.

**Posso anexar fontes externas personalizadas em tempo de execução para evitar a substituição?**  
Sim. Você pode [adicionar fontes externas](/slides/pt/cpp/custom-font/) em tempo de execução para que a biblioteca as considere na seleção e renderização, inclusive para conversões subsequentes.

**A Aspose distribui alguma fonte com a biblioteca?**  
Não. A Aspose não distribui fontes pagas ou gratuitas; você adiciona e usa fontes por sua própria conta e risco.

**Existem diferenças no comportamento de substituição no Windows, Linux e macOS?**  
Sim. A descoberta de fontes começa a partir dos diretórios de fontes do sistema operacional. O conjunto de fontes padrão disponíveis e os caminhos de pesquisa diferem entre as plataformas, o que afeta a disponibilidade e a necessidade de substituição.

**Como devo preparar o ambiente para minimizar substituições inesperadas durante conversões em lote?**  
Sincronize o conjunto de fontes entre máquinas ou contêineres, [adicione as fontes externas](/slides/pt/cpp/custom-font/) necessárias para os documentos de saída e [incorpore fontes](/slides/pt/cpp/embedded-font/) nas apresentações sempre que possível, para que as fontes escolhidas estejam disponíveis durante a renderização.