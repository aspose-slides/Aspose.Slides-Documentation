---
title: Gerenciar fontes de tema específicas de script em JavaScript
linktitle: Fontes de tema específicas de script
type: docs
weight: 15
url: /pt/nodejs-java/script-specific-font-mappings/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Inspecionar, adicionar, substituir e remover mapeamentos de fontes específicos de script em temas do PowerPoint com Aspose.Slides para Node.js."
---
## **Visão geral**

Um tema de apresentação pode selecionar diferentes famílias de fontes para diferentes sistemas de escrita. Isso permite que texto multilíngue que ainda usa fontes do tema siga um esquema de fontes coordenado, usando fontes adequadas para cirílico, árabe, japonês, georgiano, thaana e outros scripts.

O [FontScheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontscheme/) do tema contém uma coleção principal de fontes, tipicamente usada para títulos, e uma coleção secundária de fontes, tipicamente usada para o corpo do texto. Além das definições de fontes latinas e de Leste Asiático, ambas as coleções expõem mapeamentos de tags de sistema de escrita para nomes de família de fontes através da classe [Fonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fonts/).

Este artigo mostra como inspecionar e modificar esses mapeamentos no tema mestre da apresentação e verificar se as alterações persistem após um ciclo de salvar e recarregar.

## **Compreender tags de script**

Os métodos de fonte de script usam subtags de script BCP 47 de quatro letras para identificar sistemas de escrita. Valores comuns incluem:

| Tag de script | Sistema de escrita |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chinês Simplificado |
| `Jpan` | Japonês |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Esses mapeamentos pertencem ao esquema de fontes do tema, não a porções individuais de texto. Uma apresentação pode definir mapeamentos diferentes para as coleções principal e secundária, e pode omitir mapeamentos para alguns scripts.

## **Acessar e inspecionar mapeamentos de fontes de script**

Use [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getmastertheme/) para acessar o tema ao nível da apresentação. Os métodos [FontScheme.getMajor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontscheme/) e [FontScheme.getMinor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontscheme/) retornam as duas coleções [Fonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fonts/).

Chame [Fonts.getScriptFontMap](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fonts/) para obter todos os mapeamentos de uma coleção. Para buscar um sistema de escrita, chame [Fonts.getScriptFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fonts/) com sua tag de script. `getScriptFont` retorna `null` quando essa coleção não define o mapeamento solicitado.

## **Modificar mapeamentos e verificar persistência**

Use [Fonts.setScriptFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fonts/) para criar um mapeamento ou substituir a família de fontes atual. Use [Fonts.removeScriptFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fonts/) para remover um mapeamento.

O exemplo de ponta a ponta a seguir lê todos os mapeamentos principais e secundários existentes, localiza a fonte principal japonesa, altera a fonte principal cirílica, remove o mapeamento secundário thaana, salva a apresentação e a reabre para verificar ambas as alterações. Para tornar a etapa de remoção independente do tema inicial, o exemplo cria um mapeamento thaana apenas quando ainda não está definido.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

A verificação usa o mesmo comportamento de `null` de uma busca ordinária: após a remoção ser salva, `getScriptFont("Thaa")` retorna `null` para a coleção secundária.

## **Distinguir mapeamentos de tema de outras configurações de fonte**

Os mapeamentos de tema específicos de script participam da seleção de fontes, mas resolvem um problema diferente da formatação direta de texto, substituição e fallback:

| Mecanismo | Propósito | Efeito de mudar um mapeamento de tema |
|---|---|---|
| Mapeamento de fonte de tema específico de script | Seleciona uma fonte de tema principal ou secundária para um sistema de escrita. | Texto que ainda usa a fonte de tema correspondente pode resolver para a nova família mapeada. |
| Fonte atribuída explicitamente a uma porção de texto | fixa a família de fontes solicitada nessa porção em vez de depender do tema. | A porção pode permanecer inalterada porque sua formatação direta sobrescreve a escolha do tema. |
| Substituição de fonte | Substitui uma fonte solicitada quando essa fonte não está disponível ou quando uma regra de substituição se aplica. | Atua após a solicitação da fonte; não redefine o mapeamento de script do tema. |
| Fallback de fonte | Fornece glifos que a fonte selecionada não contém, frequentemente para intervalos Unicode específicos. | Preenche a cobertura de glifos faltantes; não altera o mapeamento de tema armazenado. |

Para mais informações sobre os dois últimos mecanismos, consulte [Font Substitution](/slides/pt/nodejs-java/font-substitution/) e [Fallback Fonts](/slides/pt/nodejs-java/fallback-font/).

Alterar um mapeamento em [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getmastertheme/) afeta apenas o conteúdo cujo formatado efetivo ainda depende desse tema. O texto pode, em vez disso, herdar uma sobrescrição de tema de um mestre, layout ou slide, ou usar uma fonte atribuída explicitamente. Inspecione esses níveis quando o resultado visível não segue o mapeamento ao nível da apresentação.

## **Disponibilizar fontes mapeadas e validar o resultado**

Um mapeamento de script armazena um nome de família de fonte; ele não instala ou carrega o arquivo de fonte correspondente. Para renderização e exportação consistentes, cada fonte mapeada deve estar instalada no ambiente ou ser fornecida ao Aspose.Slides por meio de uma fonte personalizada, como [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) ou [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/). Veja [Custom Fonts](/slides/pt/nodejs-java/custom-font/) para as opções de carregamento disponíveis.

Verificar o mapeamento salvo confirma apenas que a definição do tema foi preservada. Não comprova que a fonte está disponível, contém todos os glifos necessários ou produz o layout pretendido. Renderize texto representativo para cada sistema de escrita requerido em uma imagem ou PDF e inspecione a saída. Isso identifica fontes ausentes, cobertura de glifos incompleta, comportamento de fallback e alterações de layout antes da distribuição da apresentação. Consulte [Convert PowerPoint Presentations](/slides/pt/nodejs-java/convert-powerpoint/) para exemplos de renderização e exportação.

## **Perguntas frequentes**

**O que `getScriptFont` retorna quando um script não está mapeado?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fonts/) retorna `null` quando o mapeamento de script solicitado não está definido naquela coleção de fontes principal ou secundária.

**`setScriptFont` adiciona um segundo mapeamento quando o script já existe?**

Não. [Fonts.setScriptFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fonts/) cria o mapeamento quando está ausente e substitui a família de fontes mapeada quando a mesma tag de script já está presente.

**Por que mudar um mapeamento de tema não alterou algum texto?**

O texto pode ter uma fonte atribuída explicitamente, herdar um tema diferente por meio de uma sobrescrição ou ser afetado por substituição ou fallback durante a renderização. Um mapeamento de script ao nível da apresentação controla apenas o texto cujo formatado efetivo ainda se refere a essa coleção de fontes do tema.

**Salvar e reabrir é suficiente para validar a saída multilíngue?**

Não. Reabrir verifica a persistência dos dados do tema. Também é necessário renderizar texto representativo de cada sistema de escrita requerido para confirmar que as fontes mapeadas estão disponíveis e contêm os glifos necessários.