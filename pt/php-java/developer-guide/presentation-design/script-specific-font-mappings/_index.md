---
title: Gerenciar fontes de tema específicas de script em PHP
linktitle: Fontes de Tema Específicas de Script
type: docs
weight: 15
url: /pt/php-java/script-specific-font-mappings/
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
- PHP
- Aspose.Slides
description: "Inspecione, adicione, substitua e remova mapeamentos de fonte específicos de script em temas do PowerPoint com Aspose.Slides para PHP via Java."
---
## **Visão geral**

Um tema de apresentação pode selecionar diferentes famílias de fontes para diferentes sistemas de escrita. Isso permite que texto multilíngue que ainda usa as fontes do tema siga um esquema de fontes coordenado, ao mesmo tempo em que utiliza fontes adequadas para cirílico, árabe, japonês, georgiano, thaana e outros scripts.

O [FontScheme](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontscheme/) do tema contém uma coleção de fontes principal, tipicamente usada para títulos, e uma coleção de fontes secundária, tipicamente usada para o corpo do texto. Além das configurações de fontes latinas e do Leste Asiático, ambas as coleções de [Fonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fonts/) expõem mapeamentos de tags de sistema de escrita para nomes de famílias de fontes.

Este artigo mostra como inspecionar e modificar esses mapeamentos no tema mestre da apresentação e verificar se as alterações sobrevivem a um ciclo de salvar e recarregar.

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

Esses mapeamentos pertencem ao esquema de fontes do tema, não a trechos individuais de texto. Uma apresentação pode definir mapeamentos diferentes para as coleções principais e secundárias, e pode omitir mapeamentos para alguns scripts.

## **Acessar e inspecionar mapeamentos de fontes de script**

Use [Presentation::getMasterTheme](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getMasterTheme) para acessar o tema ao nível da apresentação. Os métodos [MasterTheme::getFontScheme](https://reference.aspose.com/slides/pt/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontscheme/#getMajor) e [FontScheme::getMinor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontscheme/#getMinor) fornecem acesso às duas coleções de [Fonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fonts/).

Chame [Fonts::getScriptFontMap](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fonts/#getScriptFontMap) para obter todos os mapeamentos de uma coleção. Para procurar um sistema de escrita, chame [Fonts::getScriptFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fonts/#getScriptFont) com sua tag de script. `Fonts::getScriptFont` retorna `null` quando a coleção não define o mapeamento solicitado.

## **Modificar mapeamentos e verificar persistência**

Use [Fonts::setScriptFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fonts/#setScriptFont) para criar um mapeamento ou substituir a família de fontes atual. Use [Fonts::removeScriptFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fonts/#removeScriptFont) para remover um mapeamento.

O exemplo completo a seguir lê todos os mapeamentos principais e secundários existentes, localiza a fonte principal japonesa, altera a fonte principal cirílica, remove o mapeamento secundário thaana, salva a apresentação e a reabre para verificar ambas as alterações. Para tornar a etapa de remoção independente do tema inicial, o exemplo cria primeiro um mapeamento thaana apenas quando ainda não estiver definido.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

A verificação usa o mesmo comportamento de `null` de uma consulta comum: após a remoção ser salva, `Fonts::getScriptFont("Thaa")` retorna `null` para a coleção secundária.

## **Distinguir mapeamentos de tema de outras configurações de fonte**

Os mapeamentos de tema específicos de script participam da seleção de fontes, mas resolvem um problema diferente da formatação direta de texto, substituição e fallback:

| Mecanismo | Propósito | Efeito de mudar um mapeamento de tema |
|---|---|---|
| Mapeamento de fonte de tema específico de script | Seleciona uma fonte de tema principal ou secundária para um sistema de escrita. | Texto que ainda usa a fonte de tema correspondente pode ser resolvido para a nova família mapeada. |
| Fonte atribuída explicitamente a um trecho de texto | fixa a família de fontes solicitada naquele trecho em vez de depender do tema. | O trecho pode permanecer inalterado porque sua formatação direta sobrescreve a escolha do tema. |
| Substituição de fonte | Substitui uma fonte solicitada quando ela não está disponível ou quando uma regra de substituição se aplica. | Atua após a fonte ter sido solicitada; não redefine o mapeamento de script do tema. |
| Fallback de fonte | Fornece glifos que a fonte selecionada não contém, geralmente para intervalos Unicode específicos. | Preenche a cobertura de glifos ausentes; não altera o mapeamento armazenado no tema. |

Para mais informações sobre os dois últimos mecanismos, veja [Font Substitution](/slides/pt/php-java/font-substitution/) e [Fallback Fonts](/slides/pt/php-java/fallback-font/).

Alterar um mapeamento em [Presentation::getMasterTheme](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getMasterTheme) afeta apenas o conteúdo cujo formato efetivo ainda depende desse tema. O texto pode, em vez disso, herdar uma sobrescrita de tema de um master, layout ou slide, ou usar uma fonte atribuída explicitamente. Inspecione esses níveis quando o resultado visível não seguir o mapeamento ao nível da apresentação.

## **Disponibilizar fontes mapeadas e validar o resultado**

Um mapeamento de script armazena o nome de uma família de fontes; ele não instala nem carrega o arquivo de fonte correspondente. Para renderização e exportação consistentes, toda fonte mapeada deve estar instalada no ambiente ou fornecida ao Aspose.Slides por meio de uma fonte personalizada, como [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fontsloader/#loadExternalFonts) ou [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Consulte [Custom Fonts](/slides/pt/php-java/custom-font/) para as opções de carregamento disponíveis.

Verificar o mapeamento salvo confirma apenas que a definição do tema foi preservada. Não prova que a fonte está disponível, contém todos os glifos necessários ou produz o layout pretendido. Renderize texto representativo para cada sistema de escrita exigido em uma imagem ou PDF e inspecione o resultado. Isso detecta fontes ausentes, cobertura incompleta de glifos, comportamento de fallback e alterações de layout antes de distribuir a apresentação. Veja [Convert PowerPoint Presentations](/slides/pt/php-java/convert-powerpoint/) para exemplos de renderização e exportação.

## **FAQ**

**O que `Fonts::getScriptFont` retorna quando um script não está mapeado?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fonts/#getScriptFont) retorna `null` quando o mapeamento de script solicitado não está definido naquela coleção de fontes principal ou secundária.

**`Fonts::setScriptFont` adiciona um segundo mapeamento quando o script já existe?**

Não. [Fonts::setScriptFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fonts/#setScriptFont) cria o mapeamento quando ele está ausente e substitui a família de fontes mapeada quando a mesma tag de script já está presente.

**Por que a alteração de um mapeamento de tema não mudou algum texto?**

O texto pode ter uma fonte atribuída explicitamente, herdar um tema diferente por meio de uma sobrescrita ou ser afetado por substituição ou fallback durante a renderização. Um mapeamento de script ao nível da apresentação controla apenas o texto cujo formato efetivo ainda faz referência àquela coleção de fontes do tema.

**Salvar e reabrir é suficiente para validar a saída multilíngue?**

Não. Reabrir verifica a persistência dos dados do tema. Também é necessário renderizar texto representativo de cada sistema de escrita exigido para confirmar que as fontes mapeadas estão disponíveis e contêm os glifos necessários.