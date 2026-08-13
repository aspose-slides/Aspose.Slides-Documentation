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

No PowerPoint 2019, a Microsoft introduziu a configuração **Sempre Abrir Somente Leitura** como uma das opções que os usuários podem usar para proteger suas apresentações. Você pode querer usar essa configuração Somente Leitura para proteger uma apresentação quando

- Deseja impedir edições acidentais e manter o conteúdo da sua apresentação seguro.  
- Deseja avisar as pessoas de que a apresentação fornecida é a versão final.  

Depois de selecionar a opção **Sempre Abrir Somente Leitura** para uma apresentação, ao abrir a apresentação, os usuários veem a recomendação **Somente Leitura** e podem ver uma mensagem neste formato: *Para evitar alterações acidentais, o autor definiu este arquivo para abrir como somente leitura.*

A recomendação Somente Leitura é um impedimento simples, porém eficaz, que desencoraja a edição porque os usuários precisam executar uma tarefa para removê‑la antes de poderem editar a apresentação. Se você não deseja que os usuários façam alterações em uma apresentação e quer comunicar isso de forma educada, a recomendação Somente Leitura pode ser uma boa opção para você.

> Se uma apresentação com a proteção **Somente Leitura** for aberta em uma versão mais antiga do Microsoft PowerPoint — que não suporta a funcionalidade introduzida recentemente — a recomendação **Somente Leitura** será ignorada (a apresentação será aberta normalmente).

## **Aplicar Modo Somente Leitura**

Aspose.Slides for C++ permite definir uma apresentação como **Somente Leitura**, o que significa que os usuários (após abrir a apresentação) veem a recomendação **Somente Leitura**. Este código de exemplo mostra como definir uma apresentação como **Somente Leitura** em C++ usando Aspose.Slides:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Observação**: A recomendação **Somente Leitura** tem o objetivo simples de desencorajar a edição ou evitar alterações acidentais em uma apresentação do PowerPoint. Se uma pessoa motivada — que sabe o que está fazendo — decidir editar sua apresentação, ela pode remover facilmente a configuração Somente Leitura. Se você realmente precisa impedir edições não autorizadas, é melhor usar [proteções mais rigorosas que envolvem criptografia e senhas](https://docs.aspose.com/slides/pt/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **Perguntas Frequentes**

### Como o “Somente Leitura recomendado” difere da proteção completa por senha?

“Somente Leitura recomendado” apenas exibe uma sugestão para abrir o arquivo no modo somente leitura e é fácil de contornar. [Proteção por senha](/slides/pt/cpp/password-protected-presentation/) realmente restringe a abertura ou edição e é adequada quando você precisa de controles de segurança reais.

### O “Somente Leitura recomendado” pode ser combinado com marcas d'água para desencorajar ainda mais edições?

Sim. A recomendação pode ser associada a [marcas d'água](/slides/pt/cpp/watermark/) como um impedimento visual; elas são mecanismos separados e funcionam bem juntos.

### Uma macro ou ferramenta externa ainda pode modificar o arquivo quando a recomendação está habilitada?

Sim. A recomendação não bloqueia alterações programáticas. Para impedir edições automatizadas, use [senhas e criptografia](/slides/pt/cpp/password-protected-presentation/).

### Como o “Somente Leitura recomendado” se relaciona com os indicadores “is encrypted” e “is write protected”?

São sinais diferentes. “Somente Leitura recomendado” é um aviso suave e opcional; [get_IsWriteProtected](https://reference.aspose.com/slides/pt/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) e [get_IsEncrypted](https://reference.aspose.com/slides/pt/cpp/aspose.slides/protectionmanager/get_isencrypted/) indicam restrições reais de escrita ou leitura que dependem de senhas ou criptografia.