---
title: Converter apresentações PowerPoint para Markdown em Python via Java
linktitle: PowerPoint para Markdown
type: docs
weight: 140
url: /pt/python-java/convert-powerpoint-to-markdown/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para MD
- apresentação para MD
- slide para MD
- PPT para MD
- PPTX para MD
- salvar PowerPoint como Markdown
- salvar apresentação como Markdown
- salvar slide como Markdown
- salvar PPT como MD
- salvar PPTX como MD
- exportar PPT para MD
- exportar PPTX para MD
- exportação de imagem Markdown
- links de imagem CDN
- PowerPoint
- apresentação
- Markdown
- Python
- Java
- Aspose.Slides
description: "Converter apresentações PPT e PPTX para Markdown em Python via Java e controlar onde as imagens bitmap, metafile e SVG exportadas são salvas e referenciadas."
---
## **Visão geral**

Aspose.Slides for Python via Java pode converter apresentações PPT e PPTX para Markdown para documentação, sites estáticos, migração de conteúdo e fluxos de trabalho de controle de versão. Você pode escolher um sabor de Markdown, controlar como o conteúdo dos slides é renderizado e decidir onde as imagens exportadas são armazenadas e como o Markdown gerado as referencia.

Por padrão, a exportação para Markdown usa saída apenas de texto. Para exportar conteúdo visual, defina o tipo de exportação com o método [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/#setExportType) para o valor `Sequential` ou `Visual` da enumeração [MarkdownExportType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownexporttype/). `Sequential` renderiza os itens dos slides separadamente e em ordem, enquanto `Visual` mantém os itens agrupados juntos para preservar seu relacionamento visual. O valor `TextOnly` não emite recursos de imagem, portanto os callbacks de salvamento de imagem não são invocados nesse modo.

## **Converter uma Apresentação para Markdown**

Carregue o arquivo fonte com a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e, em seguida, chame o método [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) com o valor `Md` da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Cada exemplo lê `presentation.pptx` do diretório de trabalho atual. Instale o Aspose.Slides for Python via Java e um runtime Java compatível antes de executar os exemplos. Inicie a JVM uma vez por processo Python.

## **Selecionar um Sabor de Markdown**

O método [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/#setFlavor) controla a especificação de Markdown usada na saída. A enumeração [Flavor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/flavor/) inclui CommonMark, GitHub Flavored Markdown e outras variantes suportadas.

O exemplo a seguir exporta uma apresentação como CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Exportar Imagens Usando o Comportamento Padrão de Salvamento Local**

A classe [MarkdownSaveOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/) fornece dois métodos para configurar imagens salvas localmente:

- [setBasePath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/#setBasePath) especifica o diretório base para o documento Markdown e seus recursos.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) especifica o subdiretório de imagens. Seu valor padrão é `Images`.

O exemplo a seguir renderiza conteúdo visual, grava imagens em `output/assets` e cria referências de imagem relativas no documento Markdown:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Esse comportamento também serve como reserva quando um manipulador de salvamento de imagem personalizado retorna `False`.

## **Personalizar Salvamento de Imagens e Links Markdown**

Use o método [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/) para registrar um callback para recursos bitmap e metafile que não sejam SVG emitidos durante a exportação para Markdown. Seu callback `MarkdownImageSavingHandler` recebe o objeto de imagem, seu valor [ImageFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imageformat/) e o link Markdown gerado como um parâmetro `String[]` de um elemento. Salve ou envie a imagem com o formato fornecido e substitua `link[0]` pela referência que deve aparecer na saída Markdown.

Recursos emitidos em formato SVG são tratados separadamente. Registre um callback com o método [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/). Seu callback `MarkdownSvgImageSavingHandler` recebe um objeto [SvgImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgimage/) e o parâmetro `String[] link` de um elemento. Um SVG não possui argumento `ImageFormat`; grave ou envie seus dados XML usando o método [SvgImage.getSvgData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgimage/#getSvgData). Dependendo do modo de exportação e do agrupamento visual, um SVG na apresentação de origem pode ser rasterizado ou combinado com outro conteúdo; o recurso não‑SVG resultante é então passado ao callback de salvamento de imagem. Registre ambos os callbacks quando cada recurso visual exportado exigir processamento customizado.

O valor de retorno do manipulador determina quem processa a imagem:

- Retorne `True` depois que o manipulador salvar, enviar, transformar ou processar a imagem de alguma forma e atribuir um valor válido a `link[0]`. O Aspose.Slides grava esse valor no documento Markdown e não executa seu salvamento local padrão.
- Retorne `False` para que o Aspose.Slides salve a imagem localmente e gere seu link de acordo com os valores definidos por [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/#setBasePath) e [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}
Um manipulador que retorna `True` assume a responsabilidade pela imagem. Se ele retornar `True` sem atribuir um link válido e não vazio, a exportação falhará com uma `InvalidOperationException`.
{{% /alert %}}

Em Python, registre esses callbacks com `jpype.JProxy`, implementando a interface de callback Java através de seu método `invoke`. O argumento `link` é um array Java de strings mutável: converta `link[0]` para uma string Python antes de processá‑lo, então atribua a URL de substituição de volta a `link[0]`.

### **Salvar Imagens em um Diretório de Origem CDN e Usar URLs Externas**

O exemplo a seguir trata `cdn-origin/presentations/quarterly-report` como um diretório de origem CDN montado ou sincronizado. Cada manipulador extrai o nome de arquivo gerado, salva a imagem nesse diretório personalizado e substitui a referência local gerada por uma URL pública de CDN. O exemplo em si não realiza upload de rede: a URL só se torna válida após o diretório ser montado como origem CDN ou seus arquivos serem publicados na CDN. Para armazenamento de objetos, substitua a gravação no sistema de arquivos pela operação de upload do SDK de armazenamento e atribua `link[0]` somente após o upload ser concluído.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

O manipulador de bitmap retorna deliberadamente `False` para imagens menores que 128 × 128 pixels, de modo que o Aspose.Slides salva essas imagens em `output/fallback-images` usando o comportamento padrão. Recursos de bitmap e metafile maiores, bem como recursos SVG, são tratados pelo código customizado. Por exemplo, uma referência local gerada como `fallback-images/image1.png` torna‑se `https://cdn.example.com/presentations/quarterly-report/image1.png`. Os manipuladores usam caminhos do sistema operacional apenas ao gravar arquivos; os links gravados no Markdown utilizam barras normais e nomes de arquivos escapados em URL. Aplique a mesma regra ao construir links relativos: use `/`, não o separador de diretório específico da plataforma.

## **FAQ**

**Um manipulador pode processar tanto imagens raster quanto imagens SVG?**

Não. Use [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/) para recursos bitmap e metafile emitidos e [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pt/python-java/aspose.slides/markdownsaveoptions/) para recursos emitidos como SVG. O primeiro fornece um objeto de imagem e um valor [ImageFormat]; o segundo fornece um objeto [SvgImage] cujo dados SVG podem ser lidos com [SvgImage.getSvgData]. Um SVG de origem que é rasterizado durante a exportação é processado pelo callback de salvamento de imagem.

**O que acontece quando um manipulador de salvamento de imagem retorna `False`?**

O Aspose.Slides usa seu comportamento padrão de salvamento local. A localização da imagem e a referência gerada são controladas pelos valores definidos em [MarkdownSaveOptions.setBasePath] e [MarkdownSaveOptions.setImagesSaveFolderName].

**Um manipulador pode fornecer uma URL sem salvar a imagem localmente?**

Sim. O manipulador pode enviar a imagem para armazenamento de objetos ou outro serviço, atribuir a URL resultante a `link[0]` e retornar `True`. O manipulador deve concluir o processamento por conta própria; retornar `True` impede o salvamento local padrão.

**Por que a exportação para Markdown lança uma `InvalidOperationException` a partir de um manipulador?**

Essa exceção ocorre quando o manipulador retorna `True` mas não fornece um link válido. Atribua o caminho relativo ou a URL externa que deve ser escrita no Markdown antes de retornar `True`.

**Qual separador de caminho os links de imagem devem usar?**

Use barras (`/`) em links Markdown e URLs. Use `pathlib.Path` apenas para caminhos do sistema de arquivos e, em seguida, construa ou normalize a referência Markdown separadamente.

**Os hyperlinks são preservados durante a exportação para Markdown?**

Sim. Os [hyperlinks](/slides/pt/python-java/manage-hyperlinks/) de texto são preservados como links Markdown padrão. As [transições](/slides/pt/python-java/slide-transition/) e [animações](/slides/pt/python-java/powerpoint-animation/) dos slides não são convertidas.

**As apresentações podem ser convertidas para Markdown em paralelo?**

É possível processar arquivos de apresentação diferentes em paralelo, mas não compartilhe a mesma instância de [Presentation] entre threads. Siga as [diretrizes de multithreading](/slides/pt/python-java/multithreading/) e use uma instância separada para cada arquivo.