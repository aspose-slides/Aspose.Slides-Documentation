---
title: Proteger apresentações contra gravação no Android
linktitle: Proteção contra gravação
type: docs
weight: 25
url: /pt/androidjava/write-protected-presentation/
keywords:
- proteção contra gravação
- proteção contra gravação PowerPoint
- senha para modificar
- restringir edição da apresentação
- remover proteção contra gravação
- validar senha de modificação
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Defina, detecte, valide e remova senhas de proteção contra gravação em apresentações PowerPoint PPT e PPTX usando Aspose.Slides para Android via Java."
---
## **Introdução**

Uma senha de proteção contra gravação restringe a modificação de uma apresentação, mas não criptografa seu conteúdo. Os usuários podem carregar e visualizar uma apresentação protegida contra gravação sem a senha. Dependendo do aplicativo, eles também podem editar o conteúdo e salvá‑lo com um nome diferente, portanto a proteção contra gravação não deve ser tratada como um mecanismo de confidencialidade.

Uma senha de abertura tem um propósito diferente: ela criptografa a apresentação e é necessária para carregar seu conteúdo. Para criptografar uma apresentação ou validar uma senha de abertura, consulte [Apresentações protegidas por senha](/slides/pt/androidjava/password-protected-presentation/).

Os fluxos de trabalho neste artigo se aplicam a apresentações PPT e PPTX. Os exemplos usam arquivos PPTX; ao salvar em PPT, use a extensão `.ppt` e o formato de salvamento PPT correspondente.

## **Definir proteção contra gravação em uma apresentação**

Use [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) para atribuir uma senha para modificar uma apresentação. Salvar a apresentação preserva a configuração de proteção.

O exemplo a seguir define a proteção contra gravação em uma apresentação PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Carregar uma apresentação protegida contra gravação**

Como a proteção contra gravação não criptografa o conteúdo da apresentação, nenhuma senha é necessária para carregá‑la. A senha é relevante apenas ao validar a autorização para modificar a apresentação protegida.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Não passe uma senha de proteção contra gravação para [ILoadOptions.setPassword](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-). Esse método aceita uma senha de abertura para conteúdo criptografado. Se uma apresentação possuir ambos os tipos de proteção, forneça a senha de abertura para carregá‑la e trate a senha de proteção contra gravação separadamente.

## **Remover proteção contra gravação de uma apresentação**

Use [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) para remover a restrição de modificação e, em seguida, salve a apresentação.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verificar se uma apresentação está protegida contra gravação**

Para inspecionar um arquivo sem criar uma instância completa de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/), chame [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) e verifique [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--). O método usa [NullableBool](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/nullablebool/) e retorna `NullableBool.True` quando a proteção contra gravação é detectada.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

A sobrecarga de fluxo de [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) fornece a mesma informação para uma apresentação fornecida como fluxo.

## **Validar uma senha de proteção contra gravação**

Use [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) para validar uma senha de modificação sem carregar a apresentação completa. Verifique [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) primeiro, para que o aplicativo solicite ou valide uma senha somente quando a proteção contra gravação estiver presente.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) valida apenas a senha de proteção contra gravação. Ela não valida uma senha de abertura nem determina se o conteúdo criptografado pode ser carregado. Por outro lado, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) valida apenas uma senha de abertura. Se uma apresentação completa já foi carregada, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) fornece a verificação equivalente de proteção contra gravação por meio de seu gerenciador de proteção.

Em aplicativos de produção, não registre senhas nem as inclua em mensagens de diagnóstico. Evite tentativas repetidas desnecessárias de validação e mantenha as senhas na memória apenas pelo tempo necessário.

{{% alert color="info" title="Veja também" %}}
- [Apresentações protegidas por senha](/slides/pt/androidjava/password-protected-presentation/)
- [Apresentações somente leitura](/slides/pt/androidjava/read-only-presentation/)
- [Assinatura digital no PowerPoint](/slides/pt/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**A proteção contra gravação criptografa uma apresentação?**

Não. Ela restringe a modificação, mas deixa o conteúdo da apresentação disponível para carregamento e visualização.

**A senha de proteção contra gravação é necessária para abrir uma apresentação?**

Não. Apenas uma senha de abertura é necessária para carregar o conteúdo da apresentação criptografada.

**Uma apresentação pode ter tanto uma senha de abertura quanto uma senha de proteção contra gravação?**

Sim. Forneça a senha de abertura através das opções de carregamento para abrir a apresentação criptografada e valide a senha de proteção contra gravação separadamente quando for necessária autorização para modificação.