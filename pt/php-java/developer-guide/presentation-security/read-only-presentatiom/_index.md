---
title: Salvar apresentações em modo somente leitura usando PHP
linktitle: Apresentação Somente Leitura
type: docs
weight: 30
url: /pt/php-java/read-only-presentation/
keywords:
- somente leitura
- proteger apresentação
- evitar edição
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Carregue e salve arquivos PowerPoint (PPT, PPTX) em modo somente leitura com Aspose.Slides para PHP, oferecendo pré-visualizações precisas dos slides sem alterar suas apresentações."
---
## **Introdução**

No PowerPoint 2019, a Microsoft introduziu a configuração **Always Open Read-Only** como uma das opções que os usuários podem usar para proteger suas apresentações. Você pode querer usar essa configuração de Somente Leitura para proteger uma apresentação quando

- Deseja impedir edições acidentais e manter o conteúdo da sua apresentação seguro.  
- Deseja avisar as pessoas que a apresentação que você forneceu é a versão final.  

Depois de selecionar a opção **Always Open Read-Only** para uma apresentação, quando os usuários a abrirem, eles verão a recomendação **Read-Only** e podem ver uma mensagem neste formato: *Para evitar alterações acidentais, o autor definiu este arquivo para abrir como somente leitura.*

A recomendação **Read-Only** é um impedimento simples, porém eficaz, que desencoraja a edição porque os usuários precisam executar uma tarefa para removê‑la antes de poderem editar a apresentação. Se você não quiser que os usuários façam alterações em uma apresentação e quiser comunicar isso de maneira educada, a recomendação **Read-Only** pode ser uma boa opção para você.  

> Se uma apresentação com a proteção **Read-Only** for aberta em uma versão mais antiga do Microsoft PowerPoint — que não oferece suporte à funcionalidade recém‑introduzida — a recomendação **Read-Only** será ignorada (a apresentação será aberta normalmente).

## **Aplicar modo Somente Leitura**

Aspose.Slides for PHP via Java permite definir uma apresentação como **Read-Only**, o que significa que os usuários (depois de abrir a apresentação) verão a recomendação **Read-Only**. Este código de exemplo mostra como definir uma apresentação como **Read-Only** usando Aspose.Slides:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Observação**: A recomendação **Read-Only** destina‑se simplesmente a desencorajar a edição ou impedir alterações acidentais em uma apresentação do PowerPoint. Se uma pessoa motivada — que sabe o que está fazendo — decidir editar sua apresentação, ela pode remover facilmente a configuração de Somente Leitura. Se precisar impedir seriamente edições não autorizadas, é melhor usar [proteções mais rigorosas que envolvem criptografia e senhas](https://docs.aspose.com/slides/pt/php-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Como o 'Read-Only recommended' difere da proteção por senha completa?**

'Read-Only recommended' apenas exibe uma sugestão para abrir o arquivo no modo somente leitura e é fácil de contornar. [Password protection](/slides/pt/php-java/password-protected-presentation/) realmente restringe a abertura ou edição e é apropriada quando você precisa de controles de segurança reais.

**É possível combinar 'Read-Only recommended' com marcas d'água para desencorajar ainda mais edições?**

Sim. A recomendação pode ser combinada com [watermarks](/slides/pt/php-java/watermark/) como um impedimento visual; são mecanismos separados e funcionam bem juntos.

**Uma macro ou ferramenta externa ainda pode modificar o arquivo quando a recomendação está habilitada?**

Sim. A recomendação não bloqueia alterações programáticas. Para impedir edições automatizadas, use [passwords and encryption](/slides/pt/php-java/password-protected-presentation/).

**Como o 'Read-Only recommended' se relaciona com os métodos 'isEncrypted' e 'isWriteProtected'?**

Eles são sinais diferentes. 'Read-Only recommended' é um prompt suave e opcional; [isWriteProtected](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/iswriteprotected/) e [isEncrypted](https://reference.aspose.com/slides/pt/php-java/aspose.slides/protectionmanager/isencrypted/) indicam restrições reais de escrita ou leitura que dependem de senhas ou criptografia.