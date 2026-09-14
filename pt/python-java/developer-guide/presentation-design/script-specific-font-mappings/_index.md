---
title: Gerenciar fontes de tema específicas de script em Python via Java
linktitle: Fontes de tema específicas de script
type: docs
weight: 15
url: /pt/python-java/script-specific-font-mappings/
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
- Python
- Java
- Aspose.Slides
description: "Inspecionar, adicionar, substituir e remover mapeamentos de fonte específicos de script em temas do PowerPoint com Aspose.Slides para Python via Java."
---
## **Visão geral**

Um tema de apresentação pode selecionar diferentes famílias de fontes para diferentes sistemas de escrita. Isso permite texto multilíngue que ainda usa as fontes do tema seguir um esquema de fontes coordenado enquanto utiliza fontes adequadas para cirílico, árabe, japonês, georgiano, thaana e outros scripts.

O [FontScheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontscheme/) do tema contém uma coleção de fontes principal, tipicamente usada para títulos, e uma coleção de fontes secundária, tipicamente usada para o corpo do texto. Além de suas configurações de fontes latinas e asiáticas orientais, ambas as coleções expõem mapeamentos de tags de sistema de escrita para nomes de família de fontes através da classe [Fonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fonts/).

Este artigo mostra como inspecionar e modificar esses mapeamentos no tema mestre da apresentação e verificar se as alterações permanecem após um ciclo de salvar e recarregar.

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

Esses mapeamentos pertencem ao esquema de fonte do tema, não a porções individuais de texto. Uma apresentação pode definir mapeamentos diferentes para as coleções principal e secundária, e pode omitir mapeamentos para alguns scripts.

## **Acessar e inspecionar mapeamentos de fonte de script**

Use [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasterTheme) para acessar o tema a nível de apresentação. Os métodos [FontScheme.getMajor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontscheme/#getMajor) e [FontScheme.getMinor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontscheme/#getMinor) retornam as duas coleções [Fonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fonts/).

Chame [Fonts.getScriptFontMap](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fonts/#getScriptFontMap) para obter todos os mapeamentos de uma coleção. Para procurar um sistema de escrita, chame [Fonts.getScriptFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fonts/#getScriptFont) com sua tag de script. `getScriptFont` retorna `None` quando aquela coleção não define o mapeamento solicitado.

## **Modificar mapeamentos e verificar persistência**

Use [Fonts.setScriptFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fonts/#setScriptFont) para criar um mapeamento ou substituir sua família de fontes atual. Use [Fonts.removeScriptFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fonts/#removeScriptFont) para remover um mapeamento.

O exemplo completo a seguir lê todos os mapeamentos principais e secundários existentes, procura a fonte principal japonesa, altera a fonte principal cirílica, remove o mapeamento secundário thaana, salva a apresentação e a reabre para verificar ambas as alterações. Para tornar a etapa de remoção independente do tema inicial, o exemplo cria primeiro um mapeamento thaana apenas quando ele ainda não está definido.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

A verificação usa o mesmo comportamento `None` de uma busca comum: após a remoção ser salva, `getScriptFont("Thaa")` retorna `None` para a coleção secundária.

## **Distinguir mapeamentos de tema de outras configurações de fonte**

Os mapeamentos de tema específicos de script participam da seleção de fontes, mas resolvem um problema diferente da formatação direta de texto, substituição e fallback:

| Mecanismo | Propósito | Efeito de mudar um mapeamento de tema |
|---|---|---|
| Mapeamento de fonte de tema específico de script | Seleciona uma fonte de tema principal ou secundária para um sistema de escrita. | Texto que ainda usa a fonte de tema correspondente pode ser resolvido para a nova família mapeada. |
| Fonte atribuída explicitamente a uma porção de texto | Fixar a família de fontes solicitada naquela porção ao invés de depender do tema. | A porção pode permanecer inalterada porque sua formatação direta sobrescreve a escolha do tema. |
| Substituição de fonte | Substitui uma fonte solicitada quando ela não está disponível ou quando uma regra de substituição se aplica. | Atua depois que a fonte foi solicitada; não redefine o mapeamento de script do tema. |
| Fallback de fonte | Fornece glifos que a fonte selecionada não contém, geralmente para intervalos Unicode específicos. | Preenche cobertura de glifos ausentes; não altera o mapeamento de tema armazenado. |

Para mais informações sobre os dois últimos mecanismos, consulte [Font Substitution](/slides/pt/python-java/font-substitution/) e [Fallback Fonts](/slides/pt/python-java/fallback-font/).

Alterar um mapeamento em [Presentation.getMasterTheme](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getMasterTheme) afeta apenas o conteúdo cujo formatação efetiva ainda depende desse tema. O texto pode, em vez disso, herdar uma sobrescrita de tema de um mestre, layout ou slide, ou usar uma fonte atribuída explicitamente. Inspecione esses níveis quando o resultado visível não seguir o mapeamento a nível de apresentação.

## **Disponibilizar fontes mapeadas e validar o resultado**

Um mapeamento de script armazena um nome de família de fontes; não instala nem carrega o arquivo de fonte correspondente. Para renderização e exportação consistentes, cada fonte mapeada deve estar instalada no ambiente ou ser fornecida ao Aspose.Slides através de uma fonte personalizada, como [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#loadExternalFonts) ou [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Consulte [Custom Fonts](/slides/pt/python-java/custom-font/) para as opções de carregamento disponíveis.

Verificar o mapeamento salvo confirma apenas que a definição do tema foi preservada. Não prova que a fonte está disponível, contém todos os glifos necessários ou produz o layout pretendido. Renderize texto representativo para cada sistema de escrita exigido em uma imagem ou PDF e inspecione o resultado. Isso captura fontes ausentes, cobertura de glifos incompleta, comportamento de fallback e alterações de layout antes que a apresentação seja distribuída. Veja [Convert PowerPoint Presentations](/slides/pt/python-java/convert-powerpoint/) para exemplos de renderização e exportação.

## **FAQ**

**O que `getScriptFont` retorna quando um script não está mapeado?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fonts/#getScriptFont) retorna `None` quando o mapeamento de script solicitado não está definido naquela coleção principal ou secundária.

**`setScriptFont` adiciona um segundo mapeamento quando o script já existe?**

Não. [Fonts.setScriptFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fonts/#setScriptFont) cria o mapeamento quando ele está ausente e substitui a família de fontes mapeada quando a mesma tag de script já está presente.

**Por que mudar um mapeamento de tema não alterou algum texto?**

O texto pode ter uma fonte atribuída explicitamente, herdar um tema diferente por meio de uma sobrescrita ou ser afetado por substituição ou fallback durante a renderização. Um mapeamento de script a nível de apresentação controla apenas o texto cuja formatação efetiva ainda se refere àquela coleção de fontes do tema.

**Salvar e reabrir é suficiente para validar a saída multilíngue?**

Não. Reabrir verifica a persistência dos dados do tema. Também é necessário renderizar texto representativo de cada sistema de escrita exigido para confirmar que as fontes mapeadas estão disponíveis e contêm os glifos necessários.