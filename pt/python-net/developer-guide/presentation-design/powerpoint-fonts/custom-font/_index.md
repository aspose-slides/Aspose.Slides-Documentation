---
title: Personalizar fontes do PowerPoint em Python
linktitle: Fonte personalizada
type: docs
weight: 20
url: /pt/python-net/custom-font/
keywords:
- fonte
- fonte personalizada
- fonte externa
- carregar fonte
- gerenciar fontes
- pasta de fontes
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Incorpore fontes personalizadas em slides do PowerPoint com Aspose.Slides para Python via .NET para manter suas apresentações nítidas e consistentes em qualquer dispositivo."
---
## **Visão geral**

Aspose.Slides for Python permite que você forneça fontes personalizadas em tempo de execução, de modo que as apresentações sejam renderizadas corretamente mesmo quando as fontes necessárias não estejam instaladas no sistema host. Durante a exportação para PDF ou imagens, você pode fornecer pastas de fontes ou dados de fontes em memória para preservar o layout do texto, as métricas dos glifos e a tipografia. Isso torna a renderização no lado do servidor previsível em diferentes ambientes, elimina dependências de fontes ao nível do sistema operacional e impede substituições indesejadas ou reformatação. O artigo mostra como registrar fontes.

Um tema de apresentação pode referenciar diferentes famílias de fontes para sistemas de escrita individuais. Esses mapeamentos armazenam os nomes das fontes, mas não instalam nem carregam os arquivos de fonte. Consulte [Script-Specific Theme Fonts](/slides/pt/python-net/script-specific-font-mappings/) para gerenciar os mapeamentos e use as opções de carregamento abaixo para disponibilizar as fontes referenciadas para renderização consistente.

Aspose.Slides permite que você carregue as seguintes fontes usando os métodos `load_external_font` e `load_external_fonts` da classe [FontsLoader](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsloader/):

- TrueType (.ttf) e TrueType Collection (.ttc) fonts. Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) fonts. Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Carregar fontes personalizadas**

Aspose.Slides permite que você carregue as fontes usadas em uma apresentação sem instalá‑las no sistema. Isso afeta a saída de exportação—como PDF, imagens e outros formatos suportados—para que os documentos resultantes tenham aparência consistente entre ambientes. As fontes são carregadas a partir de diretórios personalizados.

1. Especifique uma ou mais pastas que contenham os arquivos de fonte.
2. Chame o método estático [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsloader/load_external_fonts/) para carregar fontes dessas pastas.
3. Carregue e renderize/exporte a apresentação.
4. Chame [FontsLoader.clear_cache](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsloader/clear_cache/) para limpar o cache de fontes.

O exemplo de código a seguir demonstra o processo de carregamento de fontes:

```py
import aspose.slides as slides

# Defina pastas que contêm arquivos de fontes personalizados.
font_folders = ["fonts", "external_fonts"]

# Carregue fontes personalizadas das pastas especificadas.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Renderize/exporte a apresentação (por exemplo, para PDF, imagens ou outros formatos) usando as fontes carregadas.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Limpe o cache de fontes após concluir o trabalho.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsloader/load_external_fonts/) adiciona pastas adicionais aos caminhos de pesquisa de fontes, mas não altera a ordem de inicialização das fontes.  
As fontes são inicializadas nesta ordem:

1. O caminho padrão de fontes do sistema operacional.
1. Os caminhos carregados via [FontsLoader](https://reference.aspose.com/slides/pt/python-net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obter a pasta de fontes personalizadas**

Aspose.Slides fornece o método `get_font_folders` para recuperar as pastas de fontes. Ele devolve tanto as pastas adicionadas através de `load_external_fonts` quanto as pastas de fontes do sistema.

Este código Python mostra como usar `get_font_folders`:

```python
import aspose.slides as slides

# Esta chamada retorna as pastas verificadas para arquivos de fonte.
# Estas incluem pastas adicionadas via o método load_external_fonts e as pastas de fontes do sistema.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Especificar fontes personalizadas para uma apresentação**

Aspose.Slides fornece a propriedade `document_level_font_sources`, que permite especificar fontes externas a serem usadas em uma apresentação.

O exemplo Python a seguir mostra como usar `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Trabalhe com a apresentação.
    # CustomFont1, CustomFont2 e fontes das pastas assets\fonts e global\fonts (e suas subpastas) estão disponíveis para a apresentação.
    # ...
    print(len(presentation.slides))
```

## **Carregar fontes externas a partir de dados binários**

Aspose.Slides fornece o método `load_external_font` para carregar fontes externas a partir de dados binários.

O exemplo Python a seguir demonstra o carregamento de uma fonte a partir de um array de bytes:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Carregue fontes externas a partir de arrays de bytes.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Fontes externas estão disponíveis durante a vida útil desta instância de apresentação.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

### As fontes personalizadas afetam a exportação para todos os formatos (PDF, PNG, SVG, HTML)?

Sim. As fontes conectadas são usadas pelo renderizador em todos os formatos de exportação.

### As fontes personalizadas são incorporadas automaticamente ao PPTX resultante?

Não. Registrar uma fonte para renderização não equivale a incorporá‑la a um PPTX. Se precisar que a fonte seja transportada dentro do arquivo de apresentação, use os recursos explícitos de [embedding features](/slides/pt/python-net/embedded-font/).

### Posso controlar o comportamento de substituição quando uma fonte personalizada não possui certos glifos?

Sim. Configure [font substitution](/slides/pt/python-net/font-substitution/), [replacement rules](/slides/pt/python-net/font-replacement/) e [fallback sets](/slides/pt/python-net/fallback-font/) para definir exatamente qual fonte será usada quando o glifo solicitado estiver ausente.

### Posso usar fontes em contêineres Linux/Docker sem instalá‑las no sistema?

Sim. Aponte para suas próprias pastas de fontes ou carregue fontes a partir de arrays de bytes. Isso elimina qualquer dependência de diretórios de fontes do sistema na imagem do contêiner.

### E quanto à licença—posso incorporar qualquer fonte personalizada sem restrições?

Você é responsável pela conformidade de licenciamento das fontes. Os termos variam; algumas licenças proíbem a incorporação ou o uso comercial. Sempre revise a EULA da fonte antes de distribuir os resultados.