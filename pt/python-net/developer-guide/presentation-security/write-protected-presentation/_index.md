---
title: Proteção contra gravação de apresentações em Python
linktitle: Proteção contra gravação
type: docs
weight: 25
url: /pt/python-net/write-protected-presentation/
keywords:
- proteção contra gravação
- proteção contra gravação PowerPoint
- senha para modificar
- restrição de edição da apresentação
- remover proteção contra gravação
- validar senha de modificação
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Definir, detectar, validar e remover senhas de proteção contra gravação em apresentações PowerPoint PPT e PPTX usando Aspose.Slides para Python."
---
## **Introdução**

Uma senha de proteção contra gravação restringe a modificação de uma apresentação, mas não criptografa seu conteúdo. Os usuários podem carregar e visualizar uma apresentação protegida contra gravação sem a senha. Dependendo da aplicação, eles também podem editar o conteúdo e salvá-lo com outro nome, portanto a proteção contra gravação não deve ser considerada um mecanismo de confidencialidade.

Uma senha de abertura tem um propósito diferente: ela criptografa a apresentação e é necessária para carregar seu conteúdo. Para criptografar uma apresentação ou validar uma senha de abertura, consulte [Apresentações protegidas por senha](/slides/pt/python-net/password-protected-presentation/).

Os fluxos de trabalho neste artigo se aplicam a apresentações PPT e PPTX. Os exemplos utilizam arquivos PPTX; ao salvar como PPT, use a extensão `.ppt` e o formato de salvamento PPT correspondente.

## **Definir proteção contra gravação em uma apresentação**

Use [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/set_write_protection/) para atribuir uma senha para modificar uma apresentação. Salvar a apresentação mantém a configuração de proteção.

O exemplo a seguir define proteção contra gravação em uma apresentação PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Carregar uma apresentação protegida contra gravação**

Como a proteção contra gravação não criptografa o conteúdo da apresentação, nenhuma senha é necessária para carregá‑la. A senha é relevante apenas ao validar a autorização para modificar a apresentação protegida.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Não passe uma senha de proteção contra gravação para [LoadOptions.password](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/password/). Essa propriedade aceita uma senha de abertura para conteúdo criptografado. Se uma apresentação possuir ambos os tipos de proteção, forneça a senha de abertura para carregá‑la e trate a senha de proteção contra gravação separadamente.

## **Remover proteção contra gravação de uma apresentação**

Use [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/remove_write_protection/) para remover a restrição de modificação e, em seguida, salve a apresentação.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Verificar se uma apresentação está protegida contra gravação**

Para inspecionar um arquivo sem criar uma instância completa de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/), chame [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) e verifique [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/is_write_protected/). A propriedade usa [NullableBool](https://reference.aspose.com/slides/pt/python-net/aspose.slides/nullablebool/) e retorna `NullableBool.TRUE` quando a proteção contra gravação é detectada.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

A sobrecarga de fluxo de [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationfactory/get_presentation_info/) fornece as mesmas informações para uma apresentação fornecida como fluxo.

## **Validar uma senha de proteção contra gravação**

Use [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/check_write_protection/) para validar uma senha de modificação sem carregar a apresentação completa. Verifique [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/is_write_protected/) primeiro para que a aplicação solicite ou valide uma senha somente quando a proteção contra gravação estiver presente.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/check_write_protection/) valida apenas a senha de proteção contra gravação. Ela não valida uma senha de abertura nem determina se o conteúdo criptografado pode ser carregado. Por outro lado, [PresentationInfo.check_password](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentationinfo/check_password/) valida apenas uma senha de abertura. Se uma apresentação completa já foi carregada, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/check_write_protection/) fornece a verificação equivalente de proteção contra gravação por meio de seu gerenciador de proteção.

Em aplicativos de produção, não registre senhas nem as inclua em mensagens de diagnóstico. Evite tentativas de validação repetidas desnecessárias e mantenha as senhas na memória apenas enquanto forem necessárias.

{{% alert color="info" title="Veja também" %}}
- [Apresentações protegidas por senha](/slides/pt/python-net/password-protected-presentation/)
- [Apresentações somente leitura](/slides/pt/python-net/read-only-presentation/)
- [Assinatura digital no PowerPoint](/slides/pt/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Perguntas frequentes**

**A proteção contra gravação criptografa uma apresentação?**

Não. Ela restringe a modificação, mas deixa o conteúdo da apresentação disponível para carregamento e visualização.

**A senha de proteção contra gravação é necessária para abrir uma apresentação?**

Não. Apenas uma senha de abertura é necessária para carregar o conteúdo da apresentação criptografada.

**Uma apresentação pode ter tanto uma senha de abertura quanto uma senha de proteção contra gravação?**

Sim. Forneça a senha de abertura através das opções de carregamento para abrir a apresentação criptografada e valide a senha de proteção contra gravação separadamente quando a autorização de modificação for necessária.