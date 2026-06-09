---
title: Salvar Apresentações no Modo Somente Leitura Usando C++
linktitle: Apresentação Somente Leitura
type: docs
weight: 30
url: /pt/cpp/read-only-presentation/
keywords:
- somente leitura
- proteger apresentação
- impedir edição
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Carregue e salve arquivos PowerPoint (PPT, PPTX) no modo somente leitura com Aspose.Slides para C++, oferecendo visualizações precisas dos slides sem alterar suas apresentações."
---
## **Introdução**

No PowerPoint 2019, a Microsoft introduziu a configuração **Always Open Read-Only** como uma das opções que os usuários podem usar para proteger suas apresentações. Você pode querer usar essa configuração Read-Only para proteger uma apresentação quando

- Você deseja impedir edições acidentais e manter o conteúdo da sua apresentação seguro. 
- Você deseja alertar as pessoas de que a apresentação que você forneceu é a versão final. 

Depois de selecionar a opção **Always Open Read-Only** para uma apresentação, quando os usuários abrem a apresentação, eles veem a recomendação **Read-Only** e podem ver uma mensagem neste formato: *Para evitar alterações acidentais, o autor definiu este arquivo para abrir como somente leitura.*

A recomendação **Read-Only** é um impedimento simples, porém eficaz, que desencoraja a edição porque os usuários precisam realizar uma tarefa para removê‑la antes de poderem editar a apresentação. Se você não deseja que os usuários façam alterações em uma apresentação e quer informá‑los sobre isso de maneira educada, a recomendação **Read-Only** pode ser uma boa opção para você. 

> Se uma apresentação com a proteção **Read-Only** for aberta em uma versão mais antiga do Microsoft PowerPoint - que não suporta a função recentemente introduzida - a recomendação **Read-Only** será ignorada (a apresentação é aberta normalmente).

## **Aplicar Modo de Somente Leitura**

Aspose.Slides for C++ permite definir uma apresentação como **Read-Only**, o que significa que os usuários (após abrir a apresentação) veem a recomendação **Read‑Only**. Este código de exemplo mostra como definir uma apresentação como **Read-Only** em C++ usando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Nota**: A recomendação **Read-Only** destina‑se simplesmente a desencorajar a edição ou impedir que os usuários façam alterações acidentais em uma apresentação PowerPoint. Se uma pessoa motivada - que sabe o que está fazendo - decidir editar sua apresentação, ela pode remover facilmente a configuração Read-Only. Se você realmente precisa impedir edições não autorizadas, é melhor usar [proteções mais rigorosas que envolvem criptografia e senhas](https://docs.aspose.com/slides/pt/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Como o 'Read-Only recommended' difere da proteção completa por senha?**

'Read-Only recommended' apenas exibe uma sugestão para abrir o arquivo no modo somente leitura e é fácil de contornar. [Proteção por senha](/slides/pt/cpp/password-protected-presentation/) realmente restringe a abertura ou edição e é adequada quando você precisa de controles de segurança reais.

**Pode o 'Read-Only recommended' ser combinado com marcas d'água para desencorajar ainda mais edições?**

Sim. A recomendação pode ser combinada com [marcas d'água](/slides/pt/cpp/watermark/) como um impedimento visual; são mecanismos separados e funcionam bem juntos.

**Uma macro ou ferramenta externa ainda pode modificar o arquivo quando a recomendação está habilitada?**

Sim. A recomendação não bloqueia alterações programáticas. Para impedir edições automatizadas, use [senhas e criptografia](/slides/pt/cpp/password-protected-presentation/).

**Como o 'Read-Only recommended' se relaciona com os indicadores 'is encrypted' e 'is write protected'?**

Eles são sinais diferentes. 'Read-Only recommended' é um aviso suave e opcional; [get_IsWriteProtected](https://reference.aspose.com/slides/pt/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) e [get_IsEncrypted](https://reference.aspose.com/slides/pt/cpp/aspose.slides/protectionmanager/get_isencrypted/) indicam restrições reais de escrita ou leitura que dependem de senhas ou criptografia.