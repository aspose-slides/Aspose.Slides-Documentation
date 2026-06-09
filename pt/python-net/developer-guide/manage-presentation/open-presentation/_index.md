---
title: Abrir Apresentações em Python
linktitle: Abrir Apresentações
type: docs
weight: 20
url: /pt/python-net/open-presentation/
keywords:
- abrir PowerPoint
- abrir apresentação
- abrir PPTX
- abrir PPT
- abrir ODP
- carregar apresentação
- carregar PPTX
- carregar PPT
- carregar ODP
- apresentação protegida
- apresentação grande
- recurso externo
- objeto binário
- Python
- Aspose.Slides
description: "Abra apresentações PowerPoint (.pptx, .ppt) e OpenDocument (.odp) sem esforço com Aspose.Slides para Python via .NET—rápido, confiável e totalmente funcional."
---
## **Introduction**

Além de criar apresentações PowerPoint do zero, o Aspose.Slides também permite abrir apresentações existentes. Após carregar uma apresentação, você pode obter informações sobre ela, editar o conteúdo dos slides, adicionar novos slides, remover os existentes e muito mais.

## **Open Presentations**

Para abrir uma apresentação existente, instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e passe o caminho do arquivo ao seu construtor.

O exemplo Python a seguir demonstra como abrir uma apresentação e obter a contagem de slides:

```python
import aspose.slides as slides

# Instancie a classe Presentation e passe o caminho do arquivo ao seu construtor.
with slides.Presentation("sample.pptx") as presentation:
    # Imprima o número total de slides na apresentação.
    print(presentation.slides.length)
```

## **Open Password-Protected Presentations**

Quando precisar abrir uma apresentação protegida por senha, passe a senha através da propriedade [password](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/password/) da classe [LoadOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/) para descriptografá‑la e carregá‑la. O código Python a seguir demonstra essa operação:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Execute operações na apresentação descriptografada.
```

## **Open Large Presentations**

O Aspose.Slides oferece opções—especialmente a propriedade [blob_management_options](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/blob_management_options/) na classe [LoadOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/)—para ajudá‑lo a carregar apresentações grandes.

Este código Python demonstra como carregar uma apresentação grande (por exemplo, 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Escolha o comportamento KeepLocked—o arquivo da apresentação permanecerá bloqueado durante a 
# instância Presentation, mas não precisa ser carregado na memória nem copiado para um arquivo temporário.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # A apresentação grande foi carregada e pode ser usada, enquanto o consumo de memória permanece baixo.

    # Faça alterações na apresentação.
    presentation.slides[0].name = "Large presentation"

    # Salve a apresentação em outro arquivo. O consumo de memória permanece baixo durante esta operação.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Não faça isso! Uma exceção de I/O será lançada porque o arquivo está bloqueado até que o objeto Presentation seja descartado.
    os.remove(file_path)

# É seguro fazer isso aqui. O arquivo de origem não está mais bloqueado pelo objeto Presentation.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
Para contornar certas limitações ao trabalhar com streams, o Aspose.Slides pode copiar o conteúdo de um stream. Carregar uma apresentação grande a partir de um stream faz com que a apresentação seja copiada e pode tornar o carregamento mais lento. Portanto, quando precisar carregar uma apresentação grande, recomendamos fortemente usar o caminho do arquivo da apresentação em vez de um stream.

Ao criar uma apresentação que contém objetos grandes (vídeo, áudio, imagens de alta resolução, etc.), você pode usar [BLOB management](/slides/pt/python-net/manage-blob/) para reduzir o consumo de memória.
{{%/alert %}}

## **Load Presentations Without Embedded Binary Objects**

Uma apresentação PowerPoint pode conter os seguintes tipos de objetos binários incorporados:

- Projeto VBA (acessível via [Presentation.vba_project](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/vba_project/));
- Dados incorporados de objeto OLE (acessíveis via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- Dados binários de controle ActiveX (acessíveis via [Control.active_x_control_binary](https://reference.aspose.com/slides/pt/python-net/aspose.slides/control/active_x_control_binary/)).

Usando a propriedade [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/), você pode carregar uma apresentação sem nenhum objeto binário incorporado.

Essa propriedade é útil para remover conteúdo binário potencialmente malicioso. O código Python a seguir demonstra como carregar uma apresentação sem nenhum conteúdo binário incorporado:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Execute operações na apresentação.
```

## **FAQ**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Você receberá uma exceção de validação/parsing de formato durante o carregamento. Esses erros geralmente mencionam uma estrutura ZIP inválida ou registros do PowerPoint corrompidos.

**O que acontece se fontes necessárias estiverem ausentes ao abrir?**

O arquivo será aberto, mas a [renderização/exportação](/slides/pt/python-net/convert-presentation/) posterior pode substituir as fontes. [Configure substituições de fontes](/slides/pt/python-net/font-substitution/) ou [adicione as fontes necessárias](/slides/pt/python-net/custom-font/) ao ambiente de tempo de execução.

**E quanto a mídias incorporadas (vídeo/áudio) ao abrir?**

Elas tornam‑se disponíveis como recursos da apresentação. Se as mídias forem referenciadas por caminhos externos, assegure‑se de que esses caminhos estejam acessíveis no seu ambiente; caso contrário, a [renderização/exportação](/slides/pt/python-net/convert-presentation/) pode omitir as mídias.