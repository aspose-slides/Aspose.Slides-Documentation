---
title: Apresentações seguras com senhas usando Python
linktitle: Proteção por senha
type: docs
weight: 20
url: /pt/python-net/password-protected-presentation/
keywords:
- bloquear PowerPoint
- bloquear apresentação
- desbloquear PowerPoint
- desbloquear apresentação
- proteger PowerPoint
- proteger apresentação
- definir senha
- adicionar senha
- criptografar PowerPoint
- criptografar apresentação
- descriptografar PowerPoint
- descriptografar apresentação
- proteção contra gravação
- segurança do PowerPoint
- segurança da apresentação
- remover senha
- remover proteção
- remover criptografia
- desativar senha
- desativar proteção
- remover proteção contra gravação
- apresentação PowerPoint
- Python
- Aspose.Slides
description: "Aprenda a bloquear e desbloquear facilmente apresentações do PowerPoint e OpenDocument protegidas por senha com Aspose.Slides para Python via .NET. Aumente sua produtividade e proteja suas apresentações com nosso guia passo a passo."
---
## **Introdução**

Ao proteger uma apresentação com senha, você define uma senha que impõe certas restrições à apresentação. Para remover as restrições, a senha deve ser inserida. Uma apresentação protegida por senha é considerada uma apresentação bloqueada.

Normalmente, você pode definir uma senha para impor essas restrições a uma apresentação:

- **Modificação**

  Se você deseja que apenas usuários específicos modifiquem sua apresentação, pode definir uma restrição de modificação. Essa restrição impede que as pessoas modifiquem, alterem ou copiem itens na sua apresentação (a menos que forneçam a senha).

  No entanto, nesse caso, mesmo sem a senha, o usuário poderá acessar seu documento e abri‑lo. Nesse modo somente‑leitura, o usuário pode visualizar o conteúdo — hiperlinks, animações, efeitos e outros — dentro da apresentação, mas não pode copiar itens nem salvar a apresentação.

- **Abertura**

  Se você deseja que apenas usuários específicos abram sua apresentação, pode definir uma restrição de abertura. Essa restrição impede que as pessoas visualizem o conteúdo da sua apresentação (a menos que forneçam a senha).

  Tecnicamente, a restrição de abertura também impede que os usuários modifiquem suas apresentações: quando as pessoas não podem abrir uma apresentação, elas não podem fazer alterações nela.

  **Observação** que ao proteger uma apresentação com senha para impedir a abertura, o arquivo da apresentação passa a ser criptografado.

## Como proteger uma apresentação com senha online

1. Acesse a página do nosso [**Aspose.Slides Lock**](https://products.aspose.app/slides/pt/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Clique em **Drop or upload your files**.

3. Selecione o arquivo que deseja proteger com senha no seu computador.

4. Digite a senha preferida para proteção de edição; digite a senha preferida para proteção de visualização.

5. Se quiser que os usuários vejam sua apresentação como a cópia final, marque a caixa de seleção **Mark as final**.

6. Clique em **PROTECT NOW.**

7. Clique em **DOWNLOAD NOW.**

## **Proteção por senha para apresentações no Aspose.Slides**
**Formatos compatíveis**

Aspose.Slides oferece proteção por senha, criptografia e operações semelhantes para apresentações nos seguintes formatos:

- PPTX e PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Operações compatíveis**

Aspose.Slides permite usar proteção por senha em apresentações para impedir modificações das seguintes maneiras:

- Criptografar uma apresentação
- Definir proteção contra gravação em uma apresentação

**Outras operações**

Aspose.Slides permite executar outras tarefas envolvendo proteção por senha e criptografia das seguintes maneiras:

- Descriptografar uma apresentação; abrir uma apresentação criptografada
- Remover a criptografia; desabilitar a proteção por senha
- Remover a proteção contra gravação de uma apresentação
- Obter as propriedades de uma apresentação criptografada
- Verificar se uma apresentação está criptografada
- Verificar se uma apresentação está protegida por senha.

## **Criptografando uma apresentação**

Você pode criptografar uma apresentação definindo uma senha. Em seguida, para modificar a apresentação bloqueada, o usuário precisa fornecer a senha.

Para criptografar ou proteger por senha uma apresentação, use o método `encrypt` (de [ProtectionManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/)) para definir uma senha para a apresentação. Passe a senha ao método `encrypt` e use o método `save` para salvar a apresentação agora criptografada.

Este exemplo de código mostra como criptografar uma apresentação:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Definindo proteção contra gravação em uma apresentação**

Você pode adicionar uma marca indicando “Não modificar” a uma apresentação. Dessa forma, informa aos usuários que você não deseja que eles façam alterações na apresentação.

**Observação** que o processo de proteção contra gravação não criptografa a apresentação. Portanto, os usuários — se realmente quiserem — podem modificar a apresentação, mas, para salvar as alterações, precisarão criar uma apresentação com um nome diferente.

Para definir proteção contra gravação, use o método `setWriteProtection`. Este exemplo de código mostra como definir proteção contra gravação em uma apresentação:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Descriptografando uma apresentação; abrindo uma apresentação criptografada**

Aspose.Slides permite carregar um arquivo criptografado fornecendo sua senha. Para descriptografar uma apresentação, chame o método [remove_encryption](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/) sem parâmetros. Em seguida, será necessário inserir a senha correta para carregar a apresentação.

Este exemplo de código mostra como descriptografar uma apresentação:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Removendo a criptografia; desabilitando a proteção por senha**

Você pode remover a criptografia ou a proteção por senha de uma apresentação. Dessa forma, os usuários podem acessar ou modificar a apresentação sem restrições.

Para remover a criptografia ou a proteção por senha, chame o método [remove_encryption](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/). Este exemplo de código mostra como remover a criptografia de uma apresentação:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Removendo a proteção contra gravação de uma apresentação**

Você pode usar Aspose.Slides para remover a proteção contra gravação usada em um arquivo de apresentação. Assim, os usuários podem modificar livremente e não recebem avisos ao realizar essas tarefas.

Remova a proteção contra gravação de uma apresentação usando o método [remove_write_protection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/). Este exemplo de código demonstra como remover a proteção contra gravação de uma apresentação:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Obter propriedades de uma apresentação criptografada**

Geralmente, os usuários têm dificuldade em recuperar as propriedades de documento de uma apresentação criptografada ou protegida por senha. Contudo, Aspose.Slides oferece um mecanismo que permite proteger por senha uma apresentação mantendo a capacidade de os usuários acessarem suas propriedades.

**Observação:** Por padrão, quando Aspose.Slides criptografa uma apresentação, as propriedades de documento da apresentação também ficam protegidas por senha. Se for necessário tornar as propriedades de documento acessíveis mesmo após a criptografia, Aspose.Slides permite fazer exatamente isso.

Se desejar que os usuários mantenham a possibilidade de acessar as propriedades de uma apresentação criptografada, defina a propriedade `encrypt_document_properties` de [ProtectionManager](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/) como `False`. Este exemplo de código mostra como criptografar uma apresentação mantendo o acesso dos usuários às propriedades de documento:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Carregar apenas propriedades de documento de uma apresentação criptografada**

Para inspecionar os metadados de uma apresentação criptografada sem carregar seus slides ou outro conteúdo, crie um objeto [LoadOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/) e defina [only_load_document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/only_load_document_properties/) como `True`. Nesse modo, Aspose.Slides ignora a senha e carrega apenas as propriedades de documento que são publicamente acessíveis.

O exemplo de código a seguir lê as propriedades de documento incorporadas e lista propriedades de documento personalizadas por meio de [Presentation.document_properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Ler propriedades de documento internas.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Listar propriedades de documento personalizadas.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Esse fluxo de trabalho funciona apenas quando as propriedades de documento foram deixadas sem criptografia (públicas) no momento da criptografia da apresentação. Se as propriedades de documento estiverem criptografadas, definir `only_load_document_properties` como `True` provoca uma exceção, pois a senha é ignorada nesse modo. Para acessar propriedades de documento criptografadas ou carregar a apresentação completa, incluindo seus slides e outros conteúdos, forneça o valor correto de `password` em [LoadOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides/loadoptions/).

## **Verificando se uma apresentação está protegida por senha antes de carregá‑la**

Antes de carregar uma apresentação, pode ser necessário verificar e confirmar que a apresentação não está protegida por senha. Dessa forma, você evita erros e problemas semelhantes que ocorrem quando uma apresentação protegida por senha é carregada sem a senha.

Este código Python demonstra como examinar uma apresentação para determinar se está protegida por senha (sem carregar a própria apresentação):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Verificando se uma apresentação está criptografada**

Aspose.Slides permite verificar se uma apresentação está criptografada. Para executar essa tarefa, use a propriedade [is_encrypted](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/), que devolve `True` se a apresentação estiver criptografada ou `False` caso contrário.

Este exemplo de código mostra como verificar se uma apresentação está criptografada:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Verificando se uma apresentação está protegida contra gravação**

Aspose.Slides permite verificar se uma apresentação está protegida contra gravação. Para executar essa tarefa, use a propriedade [is_write_protected](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/), que devolve `True` se a apresentação estiver protegida contra gravação ou `False` caso contrário.

Este exemplo de código demonstra como verificar se uma apresentação está protegida contra gravação:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Validando ou confirmando que uma senha específica foi usada para proteger uma apresentação**

Pode ser necessário confirmar que uma senha específica foi usada para proteger um documento de apresentação. Aspose.Slides fornece meios para validar uma senha.

Este exemplo de código mostra como validar uma senha:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # verificar se "pass" corresponde
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Ele devolve `True` se a apresentação foi criptografada com a senha especificada. Caso contrário, devolve `False`.

{{% alert color="primary" title="Veja também" %}} 
- [Assinatura Digital no PowerPoint](/slides/pt/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Perguntas frequentes**

**Quais métodos de criptografia são suportados pelo Aspose.Slides?**

Aspose.Slides suporta métodos de criptografia modernos, incluindo algoritmos baseados em AES, garantindo um alto nível de segurança dos dados das suas apresentações.

**O que acontece se uma senha incorreta for inserida ao tentar abrir uma apresentação?**

Uma exceção é lançada se uma senha incorreta for usada, alertando que o acesso à apresentação foi negado. Isso ajuda a impedir acesso não autorizado e protege o conteúdo da apresentação.

**Existem implicações de desempenho ao trabalhar com apresentações protegidas por senha?**

O processo de criptografia e descriptografia pode introduzir um pequeno overhead durante as operações de abertura e salvamento. Na maioria dos casos, esse impacto de desempenho é mínimo e não afeta significativamente o tempo total de processamento das tarefas da sua apresentação.