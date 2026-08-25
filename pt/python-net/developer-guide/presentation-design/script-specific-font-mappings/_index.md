---
title: Gerenciar Fontes de Tema Específicas por Script em Python
linktitle: Fontes de Tema Específicas por Script
type: docs
weight: 15
url: /pt/python-net/script-specific-font-mappings/
keywords:
  - fonte específica por script
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
  - Aspose.Slides
description: "Inspecionar, adicionar, substituir e remover mapeamentos de fontes específicas por script em temas do PowerPoint com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Um tema de apresentação pode selecionar diferentes famílias de fontes para diferentes sistemas de escrita. Isso permite que texto multilíngue que ainda usa as fontes do tema siga um esquema de fontes coordenado, ao mesmo tempo em que utiliza fontes adequadas para cirílico, árabe, japonês, georgiano, thaana e outros scripts.

O [FontScheme](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/fontscheme/) do tema contém uma coleção de fontes principal, tipicamente usada para títulos, e uma coleção de fontes secundária, tipicamente usada para o corpo do texto. Além de suas propriedades de fontes latinas e do Leste Asiático, ambas as coleções expõem mapeamentos de tags de sistemas de escrita para nomes de famílias de fontes por meio da classe [Fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fonts/).

Este artigo mostra como inspecionar e modificar esses mapeamentos no tema mestre da apresentação e verificar se as alterações permanecem após um ciclo de salvar e recarregar.

## **Entender tags de script**

Os métodos de fontes de script usam subtags de script BCP 47 de quatro letras para identificar sistemas de escrita. Valores comuns incluem:

| Tag de script | Sistema de escrita |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chinês Simplificado |
| `Jpan` | Japonês |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Esses mapeamentos pertencem ao esquema de fontes do tema, não a porções individuais de texto. Uma apresentação pode definir mapeamentos diferentes para as coleções principal e secundária e pode omitir mapeamentos para alguns scripts.

## **Acessar e inspecionar mapeamentos de fontes de script**

Use [Presentation.master_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/master_theme/) para acessar o tema no nível da apresentação. As propriedades [FontScheme.major](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/fontscheme/major/) e [FontScheme.minor](https://reference.aspose.com/slides/pt/python-net/aspose.slides.theme/fontscheme/minor/) retornam as duas coleções de [Fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fonts/).

Chame [Fonts.get_script_font_map](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fonts/get_script_font_map/) para obter todos os mapeamentos de uma coleção. Para procurar um sistema de escrita, chame [Fonts.get_script_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fonts/get_script_font/) com sua tag de script. `get_script_font` devolve `None` quando aquela coleção não define o mapeamento solicitado.

## **Modificar mapeamentos e verificar persistência**

Use [Fonts.set_script_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fonts/set_script_font/) para criar um mapeamento ou substituir sua família de fontes atual. Use [Fonts.remove_script_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fonts/remove_script_font/) para remover um mapeamento.

O exemplo completo a seguir lê todos os mapeamentos principais e secundários existentes, procura a fonte principal japonesa, altera a fonte principal cirílica, remove o mapeamento secundário thaana, salva a apresentação e a reabre para verificar ambas as mudanças. Para tornar a etapa de remoção independente do tema inicial, o exemplo cria primeiro um mapeamento thaana apenas quando ainda não está definido.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

A verificação usa o mesmo comportamento de `None` de uma busca comum: após a remoção ser salva, `get_script_font("Thaa")` devolve `None` para a coleção secundária.

## **Distinguindo mapeamentos de tema de outras configurações de fonte**

Os mapeamentos de tema específicos de script participam da seleção de fontes, mas resolvem um problema diferente da formatação direta de texto, substituição e fallback:

| Mecanismo | Objetivo | Efeito de mudar um mapeamento do tema |
|---|---|---|
| Mapeamento de fonte de tema específico de script | Seleciona uma fonte principal ou secundária do tema para um sistema de escrita. | O texto que ainda usa a fonte correspondente do tema pode ser resolvido para a nova família mapeada. |
| Fonte atribuída explicitamente a uma porção de texto | Fixam a família de fontes solicitada naquela porção em vez de depender do tema. | A porção pode permanecer inalterada porque sua formatação direta substitui a escolha do tema. |
| Substituição de fonte | Substitui uma fonte solicitada quando ela não está disponível ou quando uma regra de substituição se aplica. | Atua depois que uma fonte foi solicitada; não redefine o mapeamento de script do tema. |
| Fallback de fonte | Fornece glifos que a fonte selecionada não contém, geralmente para intervalos Unicode específicos. | Preenche cobertura de glifos ausentes; não altera o mapeamento armazenado no tema. |

Para mais informações sobre os dois últimos mecanismos, veja [Substituição de Fonte](/slides/pt/python-net/font-substitution/) e [Fontes de Fallback](/slides/pt/python-net/fallback-font/).

Alterar um mapeamento em [Presentation.master_theme](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/master_theme/) afeta apenas o conteúdo cujo formatação efetiva ainda depende desse tema. O texto pode, ao invés disso, herdar uma sobrescrita de tema de um mestre, layout ou slide, ou usar uma fonte atribuída explicitamente. Inspecione esses níveis quando o resultado visível não segue o mapeamento no nível da apresentação.

## **Disponibilizar fontes mapeadas e validar o resultado**

Um mapeamento de script armazena apenas o nome da família de fontes; ele não instala nem carrega o respectivo arquivo de fonte. Para renderização e exportação consistentes, cada fonte mapeada deve estar instalada no ambiente ou ser fornecida ao Aspose.Slides por meio de uma origem personalizada, como [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsloader/load_external_fonts/) ou [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/document_level_font_sources/). Consulte [Fontes Personalizadas](/slides/pt/python-net/custom-font/) para as opções de carregamento disponíveis.

Verificar o mapeamento salvo confirma apenas que a definição do tema foi preservada. Não prova que a fonte está disponível, contém todos os glifos necessários ou produz o layout pretendido. Renderize texto representativo para cada sistema de escrita exigido em uma imagem ou PDF e inspecione o resultado. Isso detecta fontes ausentes, cobertura de glifos incompleta, comportamento de fallback e alterações de layout antes da distribuição da apresentação. Veja [Converter Apresentações PowerPoint](/slides/pt/python-net/convert-powerpoint/) para exemplos de renderização e exportação.

## **FAQ**

**O que `get_script_font` devolve quando um script não está mapeado?**

[Fonts.get_script_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fonts/get_script_font/) devolve `None` quando o mapeamento de script solicitado não está definido naquela coleção principal ou secundária.

**`set_script_font` adiciona um segundo mapeamento quando o script já existe?**

Não. [Fonts.set_script_font](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fonts/set_script_font/) cria o mapeamento quando ele está ausente e substitui a família de fontes mapeada quando a mesma tag de script já está presente.

**Por que mudar um mapeamento de tema não alterou algum texto?**

O texto pode ter uma fonte atribuída explicitamente, herdar um tema diferente por meio de uma sobrescrita ou ser afetado por substituição ou fallback durante a renderização. Um mapeamento de script no nível da apresentação controla apenas o texto cuja formatação efetiva ainda se refere àquela coleção de fontes do tema.

**Salvar e reabrir é suficiente para validar a saída multilíngue?**

Não. Reabrir verifica a persistência dos dados do tema. Também é necessário renderizar texto representativo de cada sistema de escrita requerido para confirmar que as fontes mapeadas estão disponíveis e contêm os glifos necessários.