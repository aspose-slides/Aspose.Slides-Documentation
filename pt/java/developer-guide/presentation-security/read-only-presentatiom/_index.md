---
title: Salvar Apresentações em Modo Somente Leitura Usando Java
linktitle: Apresentação Somente Leitura
type: docs
weight: 30
url: /pt/java/read-only-presentation/
keywords:
- somente leitura
- proteger apresentação
- evitar edição
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Carregue e salve arquivos PowerPoint (PPT, PPTX) em modo somente leitura com Aspose.Slides for Java, oferecendo pré‑visualizações precisas de slides sem alterar suas apresentações."
---
## **Introdução**

No PowerPoint 2019, a Microsoft introduziu a configuração **Always Open Read-Only** como uma das opções que os usuários podem usar para proteger suas apresentações. Você pode querer usar essa configuração Read-Only para proteger uma apresentação quando

- Você deseja impedir edições acidentais e manter o conteúdo da sua apresentação seguro. 
- Você quer avisar as pessoas de que a apresentação que você forneceu é a versão final. 

Depois de selecionar a opção **Always Open Read-Only** para uma apresentação, quando os usuários a abrem, eles veem a recomendação **Read-Only** e podem ver uma mensagem neste formato: *Para impedir alterações acidentais, o autor definiu este arquivo para ser aberto como somente leitura.*

A recomendação Read-Only é um impedimento simples, porém eficaz, que desencoraja a edição porque os usuários precisam realizar uma tarefa para removê‑la antes de poderem editar uma apresentação. Se você não deseja que os usuários façam alterações em uma apresentação e quer informá‑los disso de maneira educada, a recomendação Read-Only pode ser uma boa opção para você. 

> Se uma apresentação com a proteção **Read-Only** for aberta em uma versão mais antiga do Microsoft PowerPoint — que não suporta a função recentemente introduzida — a recomendação **Read-Only** será ignorada (a apresentação é aberta normalmente).

## **Aplicar Modo Read-Only**

O Aspose.Slides for Java permite definir uma apresentação como **Read-Only**, o que significa que os usuários (depois de abrir a apresentação) veem a recomendação **Read-Only**. Este código de exemplo mostra como definir uma apresentação como **Read-Only** em Java usando o Aspose.Slides:

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
**Nota**: A recomendação **Read-Only** destina‑se simplesmente a desencorajar a edição ou impedir que os usuários façam alterações acidentais em uma apresentação do PowerPoint. Se uma pessoa motivada — que sabe o que está fazendo — decidir editar sua apresentação, ela pode remover facilmente a configuração Read-Only. Se você precisar realmente impedir edições não autorizadas, é melhor usar [proteções mais rigorosas que envolvem criptografia e senhas](https://docs.aspose.com/slides/pt/java/password-protected-presentation/). 
{{% /alert %}} 

## **Perguntas Frequentes**

**Como o 'Read-Only recommended' difere da proteção completa por senha?**

'Read-Only recommended' exibe apenas uma sugestão para abrir o arquivo no modo somente leitura e é fácil de contornar. [Proteção por senha](/slides/pt/java/password-protected-presentation/) realmente restringe a abertura ou edição e é apropriado quando você precisa de controles de segurança reais.

**Pode o 'Read-Only recommended' ser combinado com marcas d'água para desencorajar ainda mais as edições?**

Sim. A recomendação pode ser combinada com [marcas d'água](/slides/pt/java/watermark/) como um impedimento visual; são mecanismos separados e funcionam bem juntos.

**Uma macro ou ferramenta externa ainda pode modificar o arquivo quando a recomendação está habilitada?**

Sim. A recomendação não bloqueia alterações programáticas. Para impedir edições automatizadas, use [senhas e criptografia](/slides/pt/java/password-protected-presentation/).

**Como o 'Read-Only recommended' se relaciona com os métodos 'isEncrypted' e 'isWriteProtected'?**

São sinais diferentes. 'Read-Only recommended' é um prompt suave e opcional; [isWriteProtected](https://reference.aspose.com/slides/pt/java/com.aspose.slides/protectionmanager/#isWriteProtected--) e [isEncrypted](https://reference.aspose.com/slides/pt/java/com.aspose.slides/protectionmanager/#isEncrypted--) indicam restrições reais de escrita ou leitura que dependem de senhas ou criptografia.