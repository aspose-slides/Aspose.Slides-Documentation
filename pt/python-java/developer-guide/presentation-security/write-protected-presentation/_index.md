---
title: Proteção contra gravação de apresentações em Python
linktitle: Proteção de gravação
type: docs
weight: 25
url: /pt/python-java/write-protected-presentation/
keywords:
- proteção contra gravação
- PowerPoint com proteção contra gravação
- senha para modificar
- restringir edição da apresentação
- remover proteção contra gravação
- validar senha de modificação
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Defina, detecte, valide e remova senhas de proteção contra gravação em apresentações PowerPoint PPT e PPTX usando Aspose.Slides para Python via Java."
---
## **Introdução**

Uma senha de proteção contra gravação restringe a modificação de uma apresentação, mas não criptografa seu conteúdo. Os usuários podem carregar e visualizar uma apresentação com proteção contra gravação sem a senha. Dependendo do aplicativo, eles também podem editar o conteúdo e salvá‑lo com outro nome, portanto a proteção contra gravação não deve ser tratada como um mecanismo de confidencialidade.

Uma senha de abertura tem um propósito diferente: criptografa a apresentação e é necessária para carregar seu conteúdo. Para criptografar uma apresentação ou validar uma senha de abertura, consulte [Password-Protect Presentations](/slides/pt/python-java/password-protected-presentation/).

Os fluxos de trabalho neste artigo se aplicam a apresentações PPT e PPTX. Os exemplos usam arquivos PPTX; ao salvar como PPT, use a extensão `.ppt` e o formato de salvamento PPT correspondente.

## **Definir proteção contra gravação em uma apresentação**

Use [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#setWriteProtection) para atribuir uma senha que permita modificar a apresentação. Salvar a apresentação persiste a configuração de proteção.

O exemplo a seguir define proteção contra gravação em uma apresentação PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Carregar uma apresentação protegida contra gravação**

Como a proteção contra gravação não criptografa o conteúdo da apresentação, nenhuma senha é necessária para carregá‑la. A senha é relevante apenas ao validar a autorização para modificar a apresentação protegida.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Não passe uma senha de proteção contra gravação para [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setPassword). Esse método aceita uma senha de abertura para conteúdo criptografado. Se uma apresentação possuir ambos os tipos de proteção, forneça a senha de abertura para carregá‑la e trate a senha de proteção contra gravação separadamente.

## **Remover proteção contra gravação de uma apresentação**

Use [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#removeWriteProtection) para remover a restrição de modificação e, em seguida, salvar a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verificar se uma apresentação está protegida contra gravação**

Para inspecionar um arquivo sem criar uma instância completa de [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), chame [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationfactory/#getPresentationInfo) e verifique [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#isWriteProtected). O método usa [NullableBool](https://reference.aspose.com/slides/pt/python-java/aspose.slides/nullablebool/) e retorna `NullableBool.True_` quando a proteção contra gravação é detectada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

A sobrecarga de stream de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationfactory/#getPresentationInfo) fornece as mesmas informações para uma apresentação fornecida como stream.

## **Validar uma senha de proteção contra gravação**

Use [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#checkWriteProtection) para validar uma senha de modificação sem carregar a apresentação completa. Verifique [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#isWriteProtected) primeiro, de modo que o aplicativo solicite ou valide uma senha somente quando a proteção contra gravação estiver presente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#checkWriteProtection) valida apenas a senha de proteção contra gravação. Ela não valida uma senha de abertura nem determina se o conteúdo criptografado pode ser carregado. Por outro lado, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentationinfo/#checkPassword) valida apenas uma senha de abertura. Se uma apresentação completa já foi carregada, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#checkWriteProtection) fornece a verificação equivalente de proteção contra gravação por meio do seu gerenciador de proteção.

Em aplicativos de produção, não registre senhas nem as inclua em mensagens de diagnóstico. Evite tentativas desnecessárias de validação repetida e retenha senhas na memória somente pelo tempo necessário.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/pt/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/pt/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/pt/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**A proteção contra gravação criptografa uma apresentação?**

Não. Ela restringe a modificação, mas deixa o conteúdo da apresentação disponível para carregamento e visualização.

**A senha de proteção contra gravação é necessária para abrir uma apresentação?**

Não. Apenas uma senha de abertura é necessária para carregar o conteúdo criptografado da apresentação.

**Uma apresentação pode ter tanto uma senha de abertura quanto uma senha de proteção contra gravação?**

Sim. Forneça a senha de abertura através das opções de carregamento para abrir a apresentação criptografada e valide a senha de proteção contra gravação separadamente quando a autorização de modificação for necessária.