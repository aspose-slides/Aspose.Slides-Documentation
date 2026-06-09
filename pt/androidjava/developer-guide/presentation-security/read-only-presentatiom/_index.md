---
title: Salvar Apresentações em Modo Somente Leitura no Android
linktitle: Apresentação Somente Leitura
type: docs
weight: 30
url: /pt/androidjava/read-only-presentation/
keywords:
- somente leitura
- proteger apresentação
- impedir edição
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Salve arquivos PowerPoint (PPT, PPTX) em modo somente leitura com Aspose.Slides for Android via Java, oferecendo visualizações precisas dos slides sem alterar suas apresentações."
---
## **Introdução**

No PowerPoint 2019, a Microsoft introduziu a configuração **Always Open Read-Only** como uma das opções que os usuários podem usar para proteger suas apresentações. Você pode querer usar essa configuração de Read-Only para proteger uma apresentação quando

- Você deseja impedir edições acidentais e manter o conteúdo da sua apresentação seguro. 
- Você quer avisar às pessoas que a apresentação que você forneceu é a versão final. 

Depois de selecionar a opção **Always Open Read-Only** para uma apresentação, quando os usuários abrem a apresentação, eles veem a recomendação **Read-Only** e podem ver uma mensagem neste formato: *Para evitar alterações acidentais, o autor definiu este arquivo para abrir como somente leitura.*

A recomendação **Read-Only** é um impedimento simples, porém eficaz, que desencoraja a edição porque os usuários precisam executar uma tarefa para removê‑la antes de poderem editar uma apresentação. Se você não deseja que os usuários façam alterações em uma apresentação e quer informá‑los disso de forma educada, então a recomendação **Read-Only** pode ser uma boa opção para você. 

> Se uma apresentação com a proteção **Read-Only** for aberta em um Microsoft PowerPoint mais antigo — que não oferece suporte à função introduzida recentemente — a recomendação **Read-Only** será ignorada (a apresentação será aberta normalmente).

## **Aplicar Modo Read-Only**

Aspose.Slides for Android via Java permite definir uma apresentação como **Read-Only**, o que significa que os usuários (após abrir a apresentação) veem a recomendação **Read-Only**. Este código de exemplo mostra como definir uma apresentação como **Read-Only** em Java usando Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Nota**: A recomendação **Read-Only** destina‑se simplesmente a desencorajar a edição ou impedir que os usuários façam alterações acidentais em uma apresentação PowerPoint. Se uma pessoa motivada — que sabe o que está fazendo — decidir editar sua apresentação, ela pode remover facilmente a configuração Read-Only. Se você realmente precisar impedir edições não autorizadas, é melhor usar [proteções mais rigorosas que envolvem criptografia e senhas](https://docs.aspose.com/slides/pt/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **Perguntas Frequentes**

**Como o 'Read-Only recommended' difere da proteção completa por senha?**

`Read-Only recommended` apenas exibe uma sugestão para abrir o arquivo no modo somente leitura e é fácil de contornar. [Password protection](/slides/pt/androidjava/password-protected-presentation/) realmente restringe a abertura ou edição e é adequado quando você precisa de controles de segurança reais.

**O 'Read-Only recommended' pode ser combinado com marcas d'água para desencorajar ainda mais edições?**

Sim. A recomendação pode ser combinada com [watermarks](/slides/pt/androidjava/watermark/) como um impedimento visual; são mecanismos separados e funcionam bem juntos.

**Uma macro ou ferramenta externa ainda pode modificar o arquivo quando a recomendação está habilitada?**

Sim. A recomendação não bloqueia alterações programáticas. Para impedir edições automatizadas, use [passwords and encryption](/slides/pt/androidjava/password-protected-presentation/).

**Como o 'Read-Only recommended' se relaciona com os métodos 'isEncrypted' e 'isWriteProtected'?**

Eles são sinais diferentes. `Read-Only recommended` é um prompt suave e opcional; [isWriteProtected](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) e [isEncrypted](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indicam restrições reais de escrita ou leitura que dependem de senhas ou criptografia.