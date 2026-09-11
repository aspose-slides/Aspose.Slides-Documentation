---
title: Personalizar fontes do PowerPoint em Python via Java
linktitle: Fonte personalizada
type: docs
weight: 20
url: /pt/python-java/custom-font/
keywords:
- fonte
- fonte personalizada
- fonte externa
- carregar fonte
- gerenciar fontes
- pasta de fontes
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Personalize fontes em slides do PowerPoint com Aspose.Slides para Python via Java para manter suas apresentações nítidas e consistentes em qualquer dispositivo."
---
## **Visão geral**

Aspose.Slides permite que você use fontes personalizadas em apresentações sem instalá‑las no sistema operacional. Você pode carregar fontes de pastas personalizadas, fornecer fontes para uma apresentação específica por meio de fontes de nível de documento ou carregar fontes externas diretamente de dados binários.

As fontes carregadas são usadas quando uma apresentação é renderizada ou exportada, por exemplo para PDF, imagens e outros formatos suportados. Isso ajuda a manter a saída da apresentação consistente em diferentes ambientes. O artigo também explica como inspecionar as pastas de fontes usadas por Aspose.Slides e como limpar o cache de fontes após trabalhar com fontes externas.

Registrar fontes personalizadas para renderização é separado de incorporar fontes em um arquivo PPTX. Se uma fonte precisar ser armazenada dentro da própria apresentação, use os recursos de incorporação de fontes explicitamente.

Um tema de apresentação pode referenciar diferentes famílias de fontes para sistemas de escrita individuais. Esses mapeamentos armazenam nomes de fontes, mas não instalam nem carregam os arquivos de fontes. Consulte [Fontes de Tema Específicas por Script](/slides/pt/python-java/script-specific-font-mappings/) para gerenciar os mapeamentos e use as opções de carregamento abaixo para tornar as fontes referenciadas disponíveis para renderização consistente.

{{% alert color="info" title="Note" %}}
Aspose.Slides permite que você carregue essas fontes usando o método [loadExternalFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* TrueType (.ttf) e TrueType Collection (.ttc). Veja [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf). Veja [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carregar fontes personalizadas**

Aspose.Slides permite que você carregue as fontes usadas em uma apresentação sem instalá‑las no sistema. Isso afeta a saída da exportação — como PDF, imagens e outros formatos suportados — de modo que os documentos resultantes tenham aparência consistente em diferentes ambientes. As fontes são carregadas a partir de diretórios personalizados.

1. Especifique uma ou mais pastas que contenham os arquivos de fonte.
2. Chame o método estático [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#loadExternalFonts) para carregar fontes dessas pastas.
3. Carregue e renderize/exporte a apresentação.
4. Chame [FontsLoader.clearCache](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#clearCache) para limpar o cache de fontes.

O exemplo de código a seguir demonstra o processo de carregamento de fontes:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Defina pastas que contêm arquivos de fonte personalizados.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Carregue fontes personalizadas das pastas especificadas.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Renderize/exporte a apresentação usando as fontes carregadas.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Limpe o cache de fontes após o trabalho ser concluído.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#loadExternalFonts) adiciona pastas adicionais aos caminhos de pesquisa de fontes, mas não altera a ordem de inicialização das fontes.
As fontes são inicializadas nesta ordem:

1. O caminho padrão de fontes do sistema operacional.
1. Os caminhos carregados via [FontsLoader](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obter pastas de fontes personalizadas**
Aspose.Slides fornece o método [getFontFolders](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#getFontFolders) para permitir que você encontre pastas de fontes. Esse método retorna as pastas adicionadas por meio do método [loadExternalFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#loadExternalFonts) e as pastas de fontes do sistema.

Este código Python mostra como usar [getFontFolders](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Obtenha pastas adicionadas através de loadExternalFonts e pastas de fontes do sistema.
font_folders = FontsLoader.getFontFolders()
```

## **Especificar fontes personalizadas usadas com uma apresentação**
Aspose.Slides fornece o método [getDocumentLevelFontSources](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) para permitir que você especifique fontes externas que serão usadas com a apresentação.

Este código Python mostra como usar o método [getDocumentLevelFontSources](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Trabalhe com a apresentação.
    # CustomFont1, CustomFont2 e fontes de assets/fonts e global/fonts
    # e suas subpastas estão disponíveis para a apresentação.
    pass
finally:
    presentation.dispose()
```

## **Gerenciar fontes externamente**

Aspose.Slides fornece o método [loadExternalFont](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fontsloader/#loadExternalFont) para permitir que você carregue fontes externas a partir de dados binários.

Este código Python demonstra o processo de carregamento de fontes a partir de um array de bytes:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # As fontes externas são carregadas durante a vida útil da apresentação.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **Perguntas frequentes**

**As fontes personalizadas afetam a exportação para todos os formatos (PDF, PNG, SVG, HTML)?**

Sim. As fontes conectadas são usadas pelo renderizador em todos os formatos de exportação.

**As fontes personalizadas são incorporadas automaticamente ao PPTX resultante?**

Não. Registrar uma fonte para renderização não é o mesmo que incorporá‑la a um PPTX. Se precisar que a fonte esteja dentro do arquivo de apresentação, utilize os recursos explícitos de [incorporação](/slides/pt/python-java/embedded-font/).

**Posso controlar o comportamento de fallback quando uma fonte personalizada não possui certos glifos?**

Sim. Configure [substituição de fonte](/slides/pt/python-java/font-substitution/), [regras de substituição](/slides/pt/python-java/font-replacement/) e [conjuntos de fallback](/slides/pt/python-java/fallback-font/) para definir exatamente qual fonte será usada quando o glifo solicitado estiver ausente.

**Posso usar fontes em containers Linux/Docker sem instalá‑las em todo o sistema?**

Sim. Aponte para suas próprias pastas de fontes ou carregue fontes a partir de arrays de bytes. Isso elimina qualquer dependência dos diretórios de fontes do sistema na imagem do container.

**E quanto à licença — posso incorporar qualquer fonte personalizada sem restrições?**

Você é responsável por cumprir a licença da fonte. Os termos variam; algumas licenças proíbem a incorporação ou o uso comercial. Sempre revise o EULA da fonte antes de distribuir os resultados.