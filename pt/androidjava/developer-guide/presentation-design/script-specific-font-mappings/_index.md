---
title: Gerenciar Fontes de Tema Específicas de Script no Android
linktitle: Fontes de Tema Específicas de Script
type: docs
weight: 15
url: /pt/androidjava/script-specific-font-mappings/
keywords:
- fonte de script específica
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
- Android
- Java
- Aspose.Slides
description: "Inspecione, adicione, substitua e remova mapeamentos de fontes específicas de script em temas do PowerPoint com Aspose.Slides para Android via Java."
---
## **Visão geral**

Um tema de apresentação pode selecionar diferentes famílias de fontes para diferentes sistemas de escrita. Isso permite que texto multilíngue que ainda usa fontes do tema siga um esquema de fontes coordenado, ao mesmo tempo em que utiliza fontes adequadas para cirílico, árabe, japonês, georgiano, thaana e outros scripts.

O [IFontScheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontscheme/) do tema contém uma coleção de fontes principal, tipicamente usada para cabeçalhos, e uma coleção de fontes secundária, tipicamente usada para o texto do corpo. Além de suas configurações de fontes latinas e do Leste Asiático, ambas as coleções expõem mapeamentos de tags de sistemas de escrita para nomes de famílias de fontes através da interface [IFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifonts/).

Este artigo mostra como inspecionar e modificar esses mapeamentos no tema mestre da apresentação e verificar se as alterações persistem em um ciclo de salvar e recarregar.

## **Compreender tags de script**

Os métodos de fonte de script utilizam subtags de script BCP 47 de quatro letras para identificar sistemas de escrita. Valores comuns incluem:

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

Use [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getMasterTheme--) para acessar o tema ao nível da apresentação. Os métodos [IFontScheme.getMajor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontscheme/#getMajor--) e [IFontScheme.getMinor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifontscheme/#getMinor--) retornam as duas coleções [IFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ifonts/).

Chame [IFonts.getScriptFontMap](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) para obter todos os mapeamentos de uma coleção. Para buscar um sistema de escrita, chame [IFonts.getScriptFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) com sua tag de script. `getScriptFont` retorna `null` quando aquela coleção não define o mapeamento solicitado.

## **Modificar mapeamentos e verificar persistência**

Use [IFonts.setScriptFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) para criar um mapeamento ou substituir sua família de fontes atual. Use [IFonts.removeScriptFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) para remover um mapeamento.

O exemplo completo a seguir lê todos os mapeamentos principais e secundários existentes, procura a fonte principal japonesa, altera a fonte principal cirílica, remove o mapeamento secundário de Thaana, salva a apresentação e a reabre para verificar ambas as alterações. Para tornar a etapa de remoção independente do tema inicial, o exemplo primeiro cria um mapeamento de Thaana somente quando ainda não está definido.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

A verificação usa o mesmo comportamento `null` de uma pesquisa ordinária: após a remoção ser salva, `getScriptFont("Thaa")` retorna `null` para a coleção secundária.

## **Diferenciar mapeamentos de tema de outras configurações de fonte**

Os mapeamentos de tema específicos de script participam da seleção de fontes, mas resolvem um problema diferente da formatação direta de texto, substituição e fallback:

| Mecanismo | Objetivo | Efeito de alterar um mapeamento de tema |
|---|---|---|
| Mapeamento de fonte de tema específico de script | Seleciona uma fonte de tema principal ou secundária para um sistema de escrita. | Texto que ainda usa a fonte de tema correspondente pode ser resolvido para a nova família mapeada. |
| Fonte atribuída explicitamente a uma porção de texto | Fixa a família de fontes solicitada nessa porção ao invés de depender do tema. | A porção pode permanecer inalterada porque sua formatação direta sobrescreve a escolha do tema. |
| Substituição de fonte | Substitui uma fonte solicitada quando essa fonte não está disponível ou quando uma regra de substituição se aplica. | Ela age após a fonte ter sido solicitada; não redefine o mapeamento de script do tema. |
| Fallback de fonte | Fornece glifos que a fonte selecionada não contém, frequentemente para intervalos Unicode específicos. | Preenche a cobertura de glifos ausentes; não altera o mapeamento de tema armazenado. |

Para mais informações sobre os dois últimos mecanismos, veja [Font Substitution](/slides/pt/androidjava/font-substitution/) e [Fallback Fonts](/slides/pt/androidjava/fallback-font/).  
Alterar um mapeamento em [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getMasterTheme--) afeta somente o conteúdo cujo formato efetivo ainda depende desse tema. O texto pode, em vez disso, herdar uma sobrescrita de tema de um mestre, layout ou slide, ou usar uma fonte atribuída explicitamente. Inspecione esses níveis quando o resultado visível não segue o mapeamento ao nível da apresentação.

## **Disponibilizar fontes mapeadas e validar o resultado**

Um mapeamento de script armazena o nome de uma família de fontes; ele não instala nem carrega o arquivo de fonte correspondente. Para renderização e exportação consistentes, cada fonte mapeada deve estar instalada no ambiente ou ser fornecida ao Aspose.Slides por meio de uma fonte personalizada, como [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) ou [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Veja [Custom Fonts](/slides/pt/androidjava/custom-font/) para as opções de carregamento disponíveis.

Verificar o mapeamento salvo confirma apenas que a definição do tema foi preservada. Não prova que a fonte está disponível, contém todos os glifos necessários ou produz o layout pretendido. Renderize texto representativo para cada sistema de escrita requerido em uma imagem ou PDF e inspecione o resultado. Isso detecta fontes ausentes, cobertura incompleta de glifos, comportamento de fallback e alterações de layout antes da distribuição da apresentação. Veja [Convert PowerPoint Presentations](/slides/pt/androidjava/convert-powerpoint/) para exemplos de renderização e exportação.

## **Perguntas frequentes**

**O que `getScriptFont` retorna quando um script não está mapeado?**  
[IFonts.getScriptFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) retorna `null` quando o mapeamento de script solicitado não está definido naquela coleção de fontes principal ou secundária.

**`setScriptFont` adiciona um segundo mapeamento quando o script já existe?**  
Não. [IFonts.setScriptFont](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) cria o mapeamento quando ele está ausente e substitui a família de fontes mapeada quando a mesma tag de script já está presente.

**Por que alterar um mapeamento de tema não mudou algum texto?**  
O texto pode ter uma fonte atribuída explicitamente, herdar um tema diferente por meio de uma sobrescrita, ou ser afetado por substituição ou fallback durante a renderização. Um mapeamento de script ao nível da apresentação controla somente o texto cujo formato efetivo ainda se refere àquela coleção de fontes do tema.

**Salvar e reabrir é suficiente para validar a saída multilíngue?**  
Não. Reabrir verifica a persistência dos dados do tema. Também renderize texto representativo de cada sistema de escrita requerido para confirmar que as fontes mapeadas estão disponíveis e contêm os glifos necessários.