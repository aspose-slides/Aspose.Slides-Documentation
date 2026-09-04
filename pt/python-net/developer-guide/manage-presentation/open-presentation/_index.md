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
description: "Aprenda como abrir apresentações PowerPoint e OpenDocument em Python, fornecer senhas de abertura e reduzir o uso de memória com Aspose.Slides for Python via .NET."
---
## **Introdução**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/pt/python-net/) pode carregar apresentações PowerPoint e OpenDocument a partir de arquivos e streams. Depois que uma apresentação é carregada, você pode inspecionar sua estrutura, editar slides, gerenciar recursos e salvá‑la no formato original ou em outro formato suportado.

O comportamento de carregamento pode ser personalizado através da classe [LoadOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/). Por exemplo, você pode fornecer uma senha de abertura, manter objetos binários grandes fora da memória ou omitir dados binários incorporados.

## **Abrir Apresentações**

Para abrir uma apresentação existente, passe seu caminho de arquivo para o construtor [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Use uma instrução `with` para que os manipuladores de arquivos, dados temporários e outros recursos sejam liberados prontamente.

O exemplo Python a seguir mostra como abrir uma apresentação e obter a contagem de slides:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Abrir Apresentações Protegidas por Senha**

Uma senha de abertura criptografa o conteúdo da apresentação. Para carregar a apresentação completa, atribua a senha correta a [LoadOptions.password](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/password/) e passe as opções ao construtor [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). O carregamento falha quando a senha está ausente ou incorreta.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Para detecção de senha, validação e fluxos de trabalho de criptografia, veja [Password‑Protect Presentations](/slides/pt/python-net/password-protected-presentation/). Se uma apresentação criptografada foi salva deliberadamente com propriedades de documento públicas, essas propriedades podem ser lidas sem senha; veja [Manage Presentation Properties](/slides/pt/python-net/presentation-properties/).

## **Abrir Apresentações Grandes**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/blob_management_options/) controla como Aspose.Slides lida com objetos binários grandes, como imagens, áudio e vídeo. Você pode manter o arquivo fonte bloqueado, permitir arquivos temporários e limitar a quantidade de dados BLOB retidos na memória.

Este código Python demonstra o carregamento de uma apresentação grande (por exemplo, 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Com `PresentationLockingBehavior.KEEP_LOCKED`, o arquivo fonte permanece bloqueado até que o objeto `Presentation` seja descartado. Não mova, sobrescreva ou exclua o arquivo fonte enquanto esse objeto estiver ativo.

Aspose.Slides pode copiar o conteúdo de um stream de entrada ao carregá‑lo. Para apresentações grandes, um caminho de arquivo costuma ser mais eficiente que um stream. Consulte [Manage BLOBs](/slides/pt/python-net/manage-blob/) para opções adicionais de armazenamento e gerenciamento de memória.
{{% /alert %}}

## **Carregar Apresentações sem Objetos Binários Incorporados**

Uma apresentação pode conter dados binários incorporados que um aplicativo não precisa ou não deseja manter. Exemplos incluem:

- projetos VBA, disponíveis através de [Presentation.vba_project](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/vba_project/);
- dados OLE incorporados, disponíveis através de [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- dados de controle ActiveX, disponíveis através de [Control.active_x_control_binary](https://reference.aspose.com/slides/pt/python-net/aspose.slides/control/active_x_control_binary/).

Defina [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) como `True` para remover esses dados binários durante o carregamento. Salve a apresentação carregada para preservar o resultado sanitizado.

Essa opção reduz a exposição a cargas indesejadas incorporadas, mas não constitui um sistema completo de detecção de malware ou sanitização de conteúdo.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **Perguntas Frequentes**

**Como posso saber que um arquivo está corrompido e não pode ser aberto?**

Aspose.Slides lança uma exceção de análise ou de formato durante o carregamento. Trate essa falha separadamente de um erro de senha incorreta para que a aplicação possa relatar a causa com precisão.

**O que acontece se fontes necessárias estiverem ausentes?**

A apresentação ainda pode ser carregada, mas a renderização e a exportação podem substituir fontes. Você pode [configurar substituição de fontes](/slides/pt/python-net/font-substitution/) ou [fornecer fontes personalizadas](/slides/pt/python-net/custom-font/) para tornar a saída mais previsível.

**O carregamento de uma apresentação também carrega suas mídias incorporadas?**

Áudios e vídeos incorporados ficam disponíveis através do modelo de objeto da apresentação. Recursos externos são resolvidos de acordo com o comportamento padrão de carregamento de recursos e podem estar indisponíveis se seus locais não puderem ser acessados.