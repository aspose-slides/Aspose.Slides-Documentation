---
title: Apresentações protegidas por senha em Python
linktitle: Proteção por senha
type: docs
weight: 20
url: /pt/python-net/password-protected-presentation/
keywords:
- apresentação protegida por senha
- senha de abertura
- criptografar PowerPoint
- descriptografar PowerPoint
- validar senha da apresentação
- verificar senha da apresentação
- abrir apresentação criptografada
- remover criptografia
- PowerPoint
- PPT
- PPTX
- apresentação
- Python
- Aspose.Slides
description: "Criptografe, detecte, valide, abra e descriptografe apresentações PowerPoint PPT e PPTX protegidas por senha em Python com Aspose.Slides."
---
## **Visão geral**

Uma senha de abertura criptografa uma apresentação. A senha correta é necessária para carregar e visualizar o conteúdo da apresentação, portanto essa proteção fornece confidencialidade.

Uma senha de abertura difere de uma senha de proteção contra gravação. A proteção contra gravação restringe a modificação, mas não criptografa o conteúdo nem impede que a apresentação seja carregada. Para gerenciar senhas para modificar apresentações, veja [Write-Protect Presentations](/slides/pt/python-net/write-protected-presentation/).

Os fluxos de trabalho abaixo se aplicam a apresentações PPT e PPTX. Os exemplos usam ambos os formatos quando seu comportamento baseado em arquivo e em fluxo é importante.

## **Criptografar uma apresentação com uma senha de abertura**

Use [ProtectionManager.encrypt](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/encrypt/) para atribuir uma senha de abertura. Em seguida, use [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) para persistir a apresentação criptografada.

O exemplo a seguir criptografa uma apresentação PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Manter as propriedades do documento públicas**

Por padrão, Aspose.Slides inclui as propriedades do documento na criptografia da apresentação. A propriedade [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) controla esse comportamento independentemente da criptografia do conteúdo dos slides. Defina‑a como `False` antes de chamar [ProtectionManager.encrypt](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/encrypt/) quando um sistema de indexação, classificação, pesquisa ou gerenciamento de documentos precisar ler os metadados sem a senha de abertura.

O exemplo a seguir cria uma apresentação PPTX criptografada mantendo suas propriedades de documento internas públicas:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Definir `encrypt_document_properties` como `False` não torna slides, mestres, layouts, formas, mídia ou outro conteúdo da apresentação público. Afeta apenas as propriedades do documento. Para ler essas propriedades sem carregar o conteúdo criptografado, veja [Manage Presentation Properties](/slides/pt/python-net/presentation-properties/).

## **Carregar uma apresentação criptografada**

Defina [LoadOptions.password](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/password/) como a senha de abertura e passe as opções para [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) ao carregar o arquivo. O carregamento falha quando uma senha de abertura é exigida, mas a senha fornecida está ausente ou incorreta.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Trabalhe com a apresentação descriptografada.
    pass
```

## **Remover a criptografia de uma apresentação**

Carregue a apresentação com sua senha de abertura, chame [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/remove_encryption/) e salve o resultado. A apresentação salva pode então ser carregada sem senha.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Validar uma senha de abertura antes de carregar**

Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) para obter um [PresentationInfo](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/) sem criar uma instância completa da apresentação. Verifique [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/is_password_protected/) antes de solicitar ou validar uma senha. Quando a proteção está presente, valide o valor fornecido com [PresentationInfo.check_password](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/check_password/).

### **Fluxo de trabalho com caminho de arquivo**

O exemplo a seguir valida uma senha de abertura para um arquivo PPTX, passa o valor validado para [LoadOptions.password](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/password/) e então carrega a apresentação completa:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Fluxo de trabalho com fluxo**

A sobrecarga de fluxo de [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) fornece o mesmo fluxo de trabalho. Redefina a posição de um fluxo buscável antes de carregar a apresentação completa a partir desse fluxo.

O exemplo a seguir usa um arquivo PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Valores de retorno de CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/check_password/) retorna `True` somente quando a apresentação possui uma senha de abertura e a senha fornecida está correta. Retorna `False` em cada um destes casos:

- A senha está incorreta.
- A apresentação não possui senha de abertura.
- A senha fornecida é `None` ou vazia.

O comportamento é o mesmo para apresentações PPT e PPTX.

## **Verificar se uma apresentação carregada está criptografada**

Depois de carregar uma apresentação com a senha correta, inspecione [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/is_encrypted/) para confirmar que a apresentação de origem foi criptografada. Para detectar a proteção por senha de abertura antes do carregamento, use `PresentationInfo.is_password_protected` conforme mostrado acima.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Recomendações de segurança**

{{% alert color="warning" title="Security" %}}
Não registre senhas de abertura nem as inclua em mensagens de diagnóstico. Evite tentativas repetidas de validação desnecessárias, mantenha as senhas na memória apenas pelo tempo necessário e reutilize um resultado de validação bem‑sucedido ao carregar a apresentação imediatamente.
As propriedades públicas do documento podem divulgar nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados mesmo que o conteúdo da apresentação esteja criptografado. Criptografe metadados sensíveis juntamente com a apresentação. Deixar as propriedades públicas deve ser uma decisão explícita feita apenas quando os sistemas precisam indexar, classificar, pesquisar ou gerenciar o arquivo sem uma senha de abertura.
{{% /alert %}}

## **Proteger uma apresentação com senha online**

1. Abra o aplicativo [Aspose.Slides Lock](https://products.aspose.app/slides/pt/lock).
1. Selecione ou faça upload da apresentação.
1. Insira uma senha para proteção de visualização.
1. Opcionalmente, insira uma senha separada para proteção de edição.
1. Aplique a proteção e baixe o arquivo resultante.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/pt/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/pt/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Qual é a diferença entre uma senha de abertura e uma senha de proteção contra gravação?**

Uma senha de abertura criptografa a apresentação e é necessária para carregar seu conteúdo. Uma senha de proteção contra gravação restringe a modificação sem criptografar o conteúdo.

**Posso validar uma senha de abertura sem carregar todos os slides?**

Sim. Obtenha informações da apresentação, verifique se a proteção por senha de abertura está presente e valide a senha antes de criar uma instância completa da apresentação.

**Um aplicativo pode ler metadados sem a senha de abertura?**

Sim, mas somente quando a apresentação foi criptografada com `encrypt_document_properties` definido como `False`. O aplicativo deve então usar o modo de carregamento apenas de propriedades do documento descrito em [Manage Presentation Properties](/slides/pt/python-net/presentation-properties/).

**Os fluxos de trabalho de verificação de senha suportam tanto PPT quanto PPTX?**

Sim. A detecção e validação de senha baseadas em caminho de arquivo ou em fluxo comportam‑se da mesma forma para apresentações PPT e PPTX.