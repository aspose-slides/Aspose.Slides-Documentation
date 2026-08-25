---
title: Gerenciar fontes de tema específicas de script em .NET
linktitle: Fontes de tema específicas de script
type: docs
weight: 15
url: /pt/net/script-specific-font-mappings/
keywords:
- fonte específica de script
- mapeamento de fonte de tema
- apresentação multilíngue
- sistema de escrita
- fonte cirílica
- fonte árabe
- fonte japonesa
- fonte georgiana
- fonte thaana
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Inspecione, adicione, substitua e remova mapeamentos de fontes específicas de script em temas do PowerPoint com Aspose.Slides para .NET."
---
## **Visão geral**

Um tema de apresentação pode selecionar diferentes famílias de fontes para diferentes sistemas de escrita. Isso permite que texto multilíngue que ainda usa fontes do tema siga um esquema de fontes coordenado, ao mesmo tempo em que utiliza fontes adequadas para cirílico, árabe, japonês, georgiano, thaana e outros scripts.

O [IFontScheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/ifontscheme/) do tema contém uma coleção de fontes principais, tipicamente usada para títulos, e uma coleção de fontes secundárias, tipicamente usada para o corpo do texto. Além de suas propriedades de fontes latinas e de Leste Asiático, ambas as coleções expõem mapeamentos de tags de sistemas de escrita para nomes de famílias de fontes através da interface [IFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/ifonts/).

Este artigo mostra como inspecionar e modificar esses mapeamentos no tema mestre da apresentação e verificar se as alterações persistem após um ciclo de salvar e recarregar.

## **Entender tags de script**

Os métodos de fonte de script usam subtags de script BCP 47 de quatro letras para identificar sistemas de escrita. Valores comuns incluem:

| Tag de script | Sistema de escrita |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chinês simplificado |
| `Jpan` | Japonês |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Esses mapeamentos pertencem ao esquema de fontes do tema, não a trechos individuais de texto. Uma apresentação pode definir mapeamentos diferentes para as coleções principal e secundária, e pode omitir mapeamentos para alguns scripts.

## **Acessar e inspecionar mapeamentos de fonte de script**

Use [Presentation.MasterTheme](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/mastertheme/) para acessar o tema ao nível da apresentação. As propriedades [FontScheme.Major](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/fontscheme/major/) e [FontScheme.Minor](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/fontscheme/minor/) retornam as duas coleções [IFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/ifonts/).

Chame [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/pt/net/aspose.slides/fonts/getscriptfontmap/) para obter todos os mapeamentos de uma coleção. Para procurar um sistema de escrita específico, chame [IFonts.GetScriptFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fonts/getscriptfont/) com sua tag de script. `GetScriptFont` retorna `null` quando aquela coleção não define o mapeamento solicitado.

## **Modificar mapeamentos e verificar persistência**

Use [IFonts.SetScriptFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fonts/setscriptfont/) para criar um mapeamento ou substituir sua família de fontes atual. Use [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fonts/removescriptfont/) para remover um mapeamento.

O exemplo completo a seguir lê todos os mapeamentos principais e secundários existentes, localiza a fonte principal japonesa, altera a fonte principal cirílica, remove o mapeamento secundário thaana, salva a apresentação e a reabre para verificar ambas as alterações. Para tornar a etapa de remoção independente do tema inicial, o exemplo cria primeiro um mapeamento thaana somente quando ainda não está definido.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

A verificação usa o mesmo comportamento de `null` de uma pesquisa ordinária: após a remoção ser salva, `GetScriptFont("Thaa")` retorna `null` para a coleção secundária.

## **Diferenciar mapeamentos de tema de outras configurações de fonte**

Os mapeamentos de tema específicos de script participam da seleção de fontes, mas resolvem um problema diferente da formatação direta de texto, substituição e fallback:

| Mecanismo | Propósito | Efeito ao alterar um mapeamento de tema |
|---|---|---|
| Mapeamento de fonte de tema específico de script | Seleciona uma fonte principal ou secundária do tema para um sistema de escrita. | O texto que ainda usa a fonte de tema correspondente pode ser resolvido para a nova família mapeada. |
| Fonte atribuída explicitamente a um trecho de texto | fixa a família de fontes solicitada naquele trecho em vez de depender do tema. | O trecho pode permanecer inalterado porque sua formatação direta substitui a escolha do tema. |
| Substituição de fonte | Substitui uma fonte solicitada quando esta não está disponível ou quando uma regra de substituição se aplica. | Atua após a fonte ter sido solicitada; não redefine o mapeamento de script do tema. |
| Fallback de fonte | Fornece glifos que a fonte selecionada não contém, frequentemente para intervalos Unicode específicos. | Preenche cobertura de glifos faltantes; não altera o mapeamento armazenado no tema. |

Para mais informações sobre os dois últimos mecanismos, veja [Font Substitution](/slides/pt/net/font-substitution/) e [Fallback Fonts](/slides/pt/net/fallback-font/).

Alterar um mapeamento em [Presentation.MasterTheme](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/mastertheme/) afeta somente o conteúdo cujo formato efetivo ainda depende desse tema. O texto pode, alternativamente, herdar uma sobrescrita de tema de um mestre, layout ou slide, ou usar uma fonte atribuída explicitamente. Inspecione esses níveis quando o resultado visível não seguir o mapeamento ao nível da apresentação.

## **Disponibilizar fontes mapeadas e validar o resultado**

Um mapeamento de script armazena o nome de uma família de fontes; ele não instala nem carrega o arquivo de fonte correspondente. Para renderização e exportação consistentes, cada fonte mapeada deve estar instalada no ambiente ou ser fornecida ao Aspose.Slides por meio de uma fonte personalizada, como [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pt/net/aspose.slides/fontsloader/loadexternalfonts/) ou [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/documentlevelfontsources/). Consulte [Custom Fonts](/slides/pt/net/custom-font/) para as opções de carregamento disponíveis.

Verificar o mapeamento salvo confirma apenas que a definição do tema foi preservada. Não prova que a fonte está disponível, contém todos os glifos necessários ou produz o layout esperado. Renderize texto representativo para cada sistema de escrita exigido em uma imagem ou PDF e inspecione a saída. Isso captura fontes ausentes, cobertura de glifos incompleta, comportamento de fallback e alterações de layout antes da distribuição da apresentação. Veja [Convert PowerPoint Presentations](/slides/pt/net/convert-powerpoint/) para exemplos de renderização e exportação.

## **Perguntas frequentes**

**O que `GetScriptFont` retorna quando um script não está mapeado?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fonts/getscriptfont/) retorna `null` quando o mapeamento de script solicitado não está definido naquela coleção principal ou secundária.

**`SetScriptFont` adiciona um segundo mapeamento quando o script já existe?**

Não. [IFonts.SetScriptFont](https://reference.aspose.com/slides/pt/net/aspose.slides/fonts/setscriptfont/) cria o mapeamento quando está ausente e substitui a família de fontes mapeada quando a mesma tag de script já está presente.

**Por que a alteração de um mapeamento de tema não mudou algum texto?**

O texto pode ter uma fonte atribuída explicitamente, herdar um tema diferente por meio de uma sobrescrita, ou ser afetado por substituição ou fallback durante a renderização. Um mapeamento de script ao nível da apresentação controla apenas o texto cujo formato efetivo ainda faz referência àquela coleção de fontes de tema.

**Salvar e reabrir é suficiente para validar a saída multilíngue?**

Não. Reabrir verifica a persistência dos dados do tema. Também é necessário renderizar texto representativo de cada sistema de escrita exigido para confirmar que as fontes mapeadas estão disponíveis e contêm os glifos necessários.