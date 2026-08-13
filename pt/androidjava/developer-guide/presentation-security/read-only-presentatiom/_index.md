---
title: Salvar Apresentações em Modo Somente-Leitura no Android
linktitle: Apresentação Somente-Leitura
type: docs
weight: 30
url: /pt/androidjava/read-only-presentation/
keywords:
- somente-leitura
- proteger apresentação
- impedir edição
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Salve arquivos PowerPoint (PPT, PPTX) em modo somente-leitura com Aspose.Slides for Android via Java, oferecendo visualizações precisas dos slides sem alterar suas apresentações."
---
## **Introdução**

No PowerPoint 2019, a Microsoft introduziu a configuração **Always Open Read-Only** como uma das opções que os usuários podem usar para proteger suas apresentações. Você pode querer usar essa configuração Somente‑Leitura para proteger uma apresentação quando

- Você deseja impedir edições acidentais e manter o conteúdo da sua apresentação seguro.  
- Você quer avisar as pessoas de que a apresentação que você forneceu é a versão final.  

Depois de selecionar a opção **Always Open Read-Only** para uma apresentação, quando os usuários a abrem, eles veem a recomendação **Read-Only** e podem observar uma mensagem neste formato: *Para evitar alterações acidentais, o autor definiu este arquivo para ser aberto como somente‑leitura.*

A recomendação **Read-Only** é um impedimento simples, mas eficaz, que desencoraja a edição porque os usuários precisam realizar uma ação para removê‑la antes de poderem editar a apresentação. Se você não quiser que os usuários façam alterações em uma apresentação e quiser informá‑los disso de forma educada, a recomendação **Read-Only** pode ser uma boa opção para você. 

> Se uma apresentação com a proteção **Read-Only** for aberta em uma versão mais antiga do Microsoft PowerPoint—que não suporta a função recém‑introduzida—, a recomendação **Read-Only** será ignorada (a apresentação será aberta normalmente).

## **Aplicar Modo Somente‑Leitura**

Aspose.Slides for Android via Java permite definir uma apresentação como **Read-Only**, o que significa que os usuários (depois de abrir a apresentação) veem a recomendação **Read-Only**. Este código de exemplo mostra como definir uma apresentação como **Read-Only** em Java usando Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Observação**: A recomendação **Read-Only** destina‑se apenas a desencorajar a edição ou impedir alterações acidentais em uma apresentação do PowerPoint. Se uma pessoa motivada—que sabe o que está fazendo—decidir editar sua apresentação, ela pode remover facilmente a configuração **Read-Only**. Se você precisar realmente impedir edições não autorizadas, é melhor usar [proteções mais rigorosas que envolvem criptografia e senhas](https://docs.aspose.com/slides/pt/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **Perguntas Frequentes**

### Como o “Read-Only recommended” difere da proteção completa por senha?

“Read-Only recommended” exibe apenas uma sugestão para abrir o arquivo no modo somente‑leitura e é fácil de contornar. [Proteção por senha](/slides/pt/androidjava/password-protected-presentation/) realmente restringe a abertura ou edição e é apropriada quando você precisa de controles de segurança reais.

### O “Read-Only recommended” pode ser combinado com marcas d'água para desencorajar ainda mais edições?

Sim. A recomendação pode ser combinada com [marcas d'água](/slides/pt/androidjava/watermark/) como um impedimento visual; são mecanismos separados e funcionam bem juntos.

### Uma macro ou ferramenta externa ainda pode modificar o arquivo quando a recomendação está habilitada?

Sim. A recomendação não bloqueia alterações programáticas. Para impedir edições automatizadas, use [senhas e criptografia](/slides/pt/androidjava/password-protected-presentation/).

### Como o “Read-Only recommended” se relaciona com os métodos “isEncrypted” e “isWriteProtected”?

São sinais diferentes. “Read-Only recommended” é um prompt suave e opcional; [isWriteProtected](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) e [isEncrypted](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indicam restrições reais de gravação ou leitura que dependem de senhas ou criptografia.