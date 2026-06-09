---
title: Apresentações seguras com senhas em JavaScript
linktitle: Proteção por Senha
type: docs
weight: 20
url: /pt/nodejs-java/password-protected-presentation/
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
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: Bloqueie e desbloqueie facilmente apresentações PowerPoint e OpenDocument protegidas por senha com Aspose.Slides para Node.js via Java. Proteja suas apresentações.
---
## **Introdução**

Quando você protege uma apresentação com senha, isso significa que está definindo uma senha que impõe certas restrições à apresentação. Para remover as restrições, a senha deve ser inserida. Uma apresentação protegida por senha é considerada uma apresentação bloqueada.

Normalmente, você pode definir uma senha para impor essas restrições em uma apresentação:

- **Modificação**

  Se você deseja que apenas determinados usuários modifiquem sua apresentação, pode definir uma restrição de modificação. Essa restrição impede que as pessoas modifiquem, alterem ou copiem itens em sua apresentação (a menos que forneçam a senha). 

  No entanto, nesse caso, mesmo sem a senha, um usuário poderá acessar seu documento e abri‑lo. Nesse modo somente‑leitura, o usuário pode visualizar o conteúdo ou itens — hyperlinks, animações, efeitos e outros — dentro da sua apresentação, mas não pode copiar itens nem salvar a apresentação. 

- **Abertura**

  Se você deseja que apenas determinados usuários abram sua apresentação, pode definir uma restrição de abertura. Essa restrição impede que as pessoas sequer visualizem o conteúdo da sua apresentação (a menos que forneçam a senha).

  Tecnicamente, a restrição de abertura também impede que os usuários modifiquem suas apresentações: quando as pessoas não podem abrir uma apresentação, não podem modificá‑la ou fazer alterações nela. 
  
  **Nota** que ao proteger uma apresentação com senha para impedir a abertura, o arquivo da apresentação torna‑se criptografado.

## **Como proteger uma apresentação com senha online**

1. Acesse nossa página [**Aspose.Slides Lock**](https://products.aspose.app/slides/pt/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Clique em **Solte ou carregue seus arquivos**.

3. Selecione o arquivo que deseja proteger com senha no seu computador. 

4. Insira a senha de sua preferência para proteção de edição; Insira a senha de sua preferência para proteção de visualização. 

5. Se quiser que os usuários vejam sua apresentação como a cópia final, marque a caixa de seleção **Mark as final**.

6. Clique em **PROTECT NOW.** 

7. Clique em **DOWNLOAD NOW.**

## **Proteção por senha para apresentações no Aspose.Slides**
**Formatos suportados**

Aspose.Slides suporta proteção por senha, criptografia e operações semelhantes para apresentações nesses formatos: 

- PPTX and PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Operações suportadas**

Aspose.Slides permite usar proteção por senha em apresentações para impedir modificações das seguintes maneiras:

- Criptografar uma apresentação
- Definir proteção contra gravação em uma apresentação

**Outras operações**

Aspose.Slides permite realizar outras tarefas envolvendo proteção por senha e criptografia das seguintes maneiras:

- Descriptografar uma apresentação; abrir uma apresentação criptografada
- Remover criptografia; desativar proteção por senha
- Remover proteção contra gravação de uma apresentação
- Obter as propriedades de uma apresentação criptografada
- Verificar se uma apresentação está criptografada
- Verificar se uma apresentação está protegida por senha.

## **Criptografando uma apresentação**

Você pode criptografar uma apresentação definindo uma senha. Em seguida, para modificar a apresentação bloqueada, o usuário precisa fornecer a senha. 

Para criptografar ou proteger por senha uma apresentação, você deve usar o método encrypt (de [ProtectionManager](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ProtectionManager)) para definir uma senha para a apresentação. Você passa a senha para o método encrypt e usa o método save para salvar a apresentação agora criptografada.

Este código de exemplo mostra como criptografar uma apresentação:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Definindo proteção contra gravação em uma apresentação**

Você pode adicionar uma marca indicando “Não modificar” a uma apresentação. Dessa forma, você informa aos usuários que não deseja que eles façam alterações na apresentação.  

**Nota** que o processo de proteção contra gravação não criptografa a apresentação. Portanto, os usuários—se realmente quiserem—podem modificar a apresentação, mas para salvar as alterações, precisarão criar a apresentação com um nome diferente. 

Para definir uma proteção contra gravação, você deve usar o método [setWriteProtection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Este código de exemplo mostra como definir proteção contra gravação em uma apresentação:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Descriptografando uma apresentação; abrindo uma apresentação criptografada**

Aspose.Slides permite carregar um arquivo criptografado passando sua senha. Para descriptografar uma apresentação, você deve chamar o método [removeEncryption](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) sem parâmetros. Em seguida, será necessário inserir a senha correta para carregar a apresentação.

Este código de exemplo mostra como descriptografar uma apresentação: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // trabalhar com a apresentação descriptografada
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Removendo criptografia; desativando proteção por senha**

Você pode remover a criptografia ou a proteção por senha de uma apresentação. Dessa forma, os usuários podem acessar ou modificar a apresentação sem restrições. 

Para remover criptografia ou proteção por senha, você deve chamar o método [removeEncryption](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Este código de exemplo mostra como remover a criptografia de uma apresentação:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Removendo proteção contra gravação de uma apresentação**

Você pode usar o Aspose.Slides para remover a proteção contra gravação usada em um arquivo de apresentação. Dessa forma, os usuários podem modificar como quiserem — e não recebem avisos ao realizar essas tarefas.

Você pode remover a proteção contra gravação de uma apresentação usando o método [removeWriteProtection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). Este código de exemplo mostra como remover a proteção contra gravação de uma apresentação:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Obtendo as propriedades de uma apresentação criptografada**

Normalmente, os usuários têm dificuldade em obter as propriedades do documento de uma apresentação criptografada ou protegida por senha. O Aspose.Slides, porém, oferece um mecanismo que permite proteger a apresentação por senha mantendo a possibilidade de os usuários acessarem as propriedades daquela apresentação.

**Nota** que quando o Aspose.Slides criptografa uma apresentação, as propriedades do documento da apresentação também ficam protegidas por senha por padrão. Mas se precisar tornar as propriedades da apresentação acessíveis (mesmo após a apresentação ser criptografada), o Aspose.Slides permite fazer exatamente isso. 

Se você quiser que os usuários mantenham a capacidade de acessar as propriedades de uma apresentação que você criptografou, pode definir a propriedade [encryptDocumentProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) como `true`. Este código de exemplo mostra como criptografar uma apresentação enquanto oferece meios para os usuários acessarem suas propriedades de documento:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Verificando se uma apresentação está protegida por senha antes de carregá‑la**

Antes de carregar uma apresentação, talvez você queira verificar e confirmar que a apresentação não está protegida por senha. Dessa forma, você evita erros e problemas semelhantes que surgem quando uma apresentação protegida por senha é carregada sem a senha.

Este código JavaScript mostra como examinar uma apresentação para verificar se está protegida por senha (sem carregar a própria apresentação):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Verificando se uma apresentação está criptografada**

O Aspose.Slides permite verificar se uma apresentação está criptografada. Para executar essa tarefa, você pode usar a propriedade [isEncrypted](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) , que retorna `true` se a apresentação estiver criptografada ou `false` se não estiver.

Este código de exemplo mostra como verificar se uma apresentação está criptografada:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Verificando se uma apresentação está protegida contra gravação**

O Aspose.Slides permite verificar se uma apresentação está protegida contra gravação. Para executar essa tarefa, você pode usar a propriedade [isWriteProtected](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) , que retorna `true` se a apresentação estiver protegida contra gravação ou `false` se não estiver.

Este código de exemplo mostra como verificar se uma apresentação está protegida contra gravação:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Validando ou confirmando que uma senha específica foi usada para proteger uma apresentação**

Você pode querer verificar e confirmar que uma senha específica foi usada para proteger um documento de apresentação. O Aspose.Slides fornece os meios para validar uma senha. 

Este código de exemplo mostra como validar uma senha:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // verificar se "pass" corresponde a
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Retorna `true` se a apresentação foi criptografada com a senha especificada. Caso contrário, retorna `false`. 

{{% alert color="primary" title="Veja também" %}} 
- [Assinatura digital no PowerPoint](/slides/pt/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quais métodos de criptografia são suportados pelo Aspose.Slides?**

O Aspose.Slides suporta métodos modernos de criptografia, incluindo algoritmos baseados em AES, garantindo um alto nível de segurança dos dados para suas apresentações.

**O que acontece se uma senha incorreta for inserida ao tentar abrir uma apresentação?**

Uma exceção é lançada se uma senha incorreta for usada, alertando que o acesso à apresentação foi negado. Isso ajuda a impedir o acesso não autorizado e protege o conteúdo da apresentação.

**Existem implicações de desempenho ao trabalhar com apresentações protegidas por senha?**

O processo de criptografia e descriptografia pode introduzir uma leve sobrecarga durante as operações de abertura e gravação. Na maioria dos casos, esse impacto de desempenho é mínimo e não afeta significativamente o tempo total de processamento das suas tarefas de apresentação.