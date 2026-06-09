---
title: Salvar Apresentações em Modo Somente Leitura Usando JavaScript
linktitle: Apresentação Somente Leitura
type: docs
weight: 30
url: /pt/nodejs-java/read-only-presentation/
keywords:
- somente leitura
- proteger apresentação
- impedir edição
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Carregue e salve arquivos PowerPoint em modo somente leitura com Aspose.Slides for Node.js via Java, oferecendo visualizações precisas de slides sem alterar suas apresentações."
---
## **Introdução**

No PowerPoint 2019, a Microsoft introduziu a configuração **Always Open Read-Only** como uma das opções que os usuários podem usar para proteger suas apresentações. Você pode querer usar essa configuração Read-Only para proteger uma apresentação quando

- Você deseja impedir edições acidentais e manter o conteúdo da sua apresentação seguro. 
- Você quer avisar às pessoas que a apresentação fornecida é a versão final. 

Depois de selecionar a opção **Always Open Read-Only** para uma apresentação, quando os usuários a abrem, eles veem a recomendação **Read-Only** e podem ver uma mensagem deste tipo: *Para evitar alterações acidentais, o autor definiu este arquivo para ser aberto como somente leitura.*

A recomendação **Read-Only** é um dissuasor simples, porém eficaz, que desencoraja a edição porque os usuários precisam executar uma tarefa para removê‑la antes de poderem editar a apresentação. Se você não deseja que os usuários façam alterações em uma apresentação e quer informá‑los de forma educada, a recomendação **Read-Only** pode ser uma boa opção para você. 

> Se uma apresentação com a proteção **Read-Only** for aberta em uma versão mais antiga do Microsoft PowerPoint — que não suporta a função recentemente introduzida — a recomendação **Read-Only** será ignorada (a apresentação será aberta normalmente).

## **Aplicar Modo Somente Leitura**

Aspose.Slides for Node.js via Java permite definir uma apresentação como **Read-Only**, o que significa que os usuários (após abrir a apresentação) veem a recomendação **Read-Only**. Este código de exemplo mostra como definir uma apresentação como **Read-Only** em JavaScript usando Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Nota**: A recomendação **Read-Only** destina‑se simplesmente a desencorajar a edição ou impedir que usuários façam alterações acidentais em uma apresentação PowerPoint. Se uma pessoa motivada — que sabe o que está fazendo — decidir editar sua apresentação, ela pode remover facilmente a configuração Read-Only. Se você realmente precisar impedir edições não autorizadas, é melhor usar [proteções mais rigorosas que envolvem criptografia e senhas](https://docs.aspose.com/slides/pt/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **Perguntas Frequentes**

**Como o 'Read-Only recommended' difere da proteção completa por senha?**

'Read-Only recommended' apenas exibe uma sugestão para abrir o arquivo no modo somente leitura e é fácil de contornar. [Proteção por senha](/slides/pt/nodejs-java/password-protected-presentation/) realmente restringe a abertura ou edição e é apropriada quando você precisa de controles de segurança reais.

**É possível combinar 'Read-Only recommended' com marcas d'água para desencorajar ainda mais edições?**

Sim. A recomendação pode ser combinada com [marcas d'água](/slides/pt/nodejs-java/watermark/) como um impedimento visual; são mecanismos separados e funcionam bem juntos.

**Uma macro ou ferramenta externa ainda pode modificar o arquivo quando a recomendação está habilitada?**

Sim. A recomendação não bloqueia alterações programáticas. Para impedir edições automatizadas, use [senhas e criptografia](/slides/pt/nodejs-java/password-protected-presentation/).

**Como o 'Read-Only recommended' se relaciona com as flags 'IsEncrypted' e 'IsWriteProtected'?**

São sinais diferentes. 'Read-Only recommended' é um prompt suave e opcional; [isWriteProtected](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) e [isEncrypted](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/protectionmanager/isencrypted/) indicam restrições reais de gravação ou leitura que dependem de senhas ou criptografia.