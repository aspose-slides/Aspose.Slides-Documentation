---
title: Abrir Apresentações em Python via Java
linktitle: Abrir Apresentação
type: docs
weight: 20
url: /pt/python-java/open-presentation/
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
- Java
- Aspose.Slides
description: "Aprenda a abrir apresentações PowerPoint e OpenDocument em Python via Java, fornecer senhas de abertura, controlar o carregamento de recursos e reduzir o uso de memória com Aspose.Slides para Python via Java."
---
## **Introdução**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/pt/python-java/) pode carregar apresentações PowerPoint e OpenDocument a partir de arquivos e fluxos. Após uma apresentação ser carregada, você pode inspecionar sua estrutura, editar slides, gerenciar recursos e salvá‑la no formato original ou em outro formato suportado.

O comportamento de carregamento pode ser personalizado através da classe [LoadOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/). Por exemplo, você pode fornecer uma senha de abertura, manter objetos binários grandes fora da memória heap do Java, controlar recursos externos ou omitir dados binários incorporados.

## **Abrir apresentações**

Para abrir uma apresentação existente, passe o caminho do arquivo ao construtor [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/). Libere a apresentação após o uso para que manipuladores de arquivos, dados temporários e outros recursos sejam liberados prontamente.

O exemplo Python a seguir mostra como abrir uma apresentação e obter a contagem de slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Abrir apresentações protegidas por senha**

Uma senha de abertura criptografa o conteúdo da apresentação. Para carregar a apresentação completa, passe a senha correta para [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setPassword) e forneça as opções ao construtor [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/). O carregamento falha quando a senha está ausente ou incorreta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

Para detecção de senha, validação e fluxos de trabalho de criptografia, veja [Password‑Protect Presentations](/slides/pt/python-java/password-protected-presentation/). Se uma apresentação criptografada foi deliberadamente salva com propriedades de documento públicas, essas propriedades podem ser lidas sem senha; veja [Manage Presentation Properties](/slides/pt/python-java/presentation-properties/).

## **Abrir apresentações grandes**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) devolve opções que controlam como Aspose.Slides lida com objetos binários grandes, como imagens, áudio e vídeo. Você pode manter o arquivo de origem bloqueado, permitir arquivos temporários e limitar a quantidade de dados BLOB mantidos na memória.

O código Python a seguir demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Com [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked), o arquivo de origem permanece bloqueado até que a instância da apresentação seja liberada. Não mova, sobrescreva ou exclua o arquivo de origem enquanto essa instância estiver ativa.

Aspose.Slides pode copiar o conteúdo de um fluxo de entrada ao carregá‑lo. Para apresentações grandes, um caminho de arquivo geralmente é mais eficiente que um fluxo. Consulte [Manage BLOBs](/slides/pt/python-java/manage-blob/) para opções adicionais de armazenamento e gerenciamento de memória.

{{% /alert %}}

## **Controlar recursos externos**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) aceita um proxy JPype que implementa a interface de callback de carregamento de recursos Java. O callback pode fornecer dados de substituição, redirecionar um recurso, usar o carregador padrão ou pular o recurso. Isso é útil quando apresentações contêm imagens externas que precisam ser resolvidas de acordo com regras de segurança ou armazenamento específicas da aplicação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Carregar apresentações sem objetos binários incorporados**

Uma apresentação pode conter dados binários incorporados que a aplicação não necessita ou não deseja reter. Exemplos incluem:

- projetos VBA, disponíveis através de [Presentation.getVbaProject](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getVbaProject);
- dados OLE incorporados, disponíveis através de [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dados de controle ActiveX, disponíveis através de [Control.getActiveXControlBinary](https://reference.aspose.com/slides/pt/python-java/aspose.slides/control/#getActiveXControlBinary).

Defina [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) como `True` para remover esses dados binários durante o carregamento. Salve a apresentação carregada para persistir o resultado sanitizado.

Esta opção reduz a exposição a cargas úteis incorporadas indesejadas, mas não é um sistema completo de detecção de malware ou de sanitização de conteúdo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Aspose.Slides lança uma exceção de análise ou de formato durante o carregamento. Trate essa falha separadamente de um erro de senha incorreta para que a aplicação possa relatar a causa com precisão.

**O que acontece se fontes necessárias estiverem ausentes?**

A apresentação ainda pode ser carregada, mas a renderização e a exportação podem substituir as fontes. Você pode [configurar substituição de fontes](/slides/pt/python-java/font-substitution/) ou [fornecer fontes personalizadas](/slides/pt/python-java/custom-font/) para tornar a saída mais previsível.

**O carregamento de uma apresentação também carrega sua mídia incorporada?**

Áudio e vídeo incorporados ficam disponíveis através do modelo de objeto da apresentação. Recursos externos são resolvidos de acordo com o comportamento de carregamento configurado e podem estar indisponíveis se seus locais não puderem ser acessados.