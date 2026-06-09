---
title: Salvar apresentações no modo somente leitura usando Python
linktitle: Apresentação Somente Leitura
type: docs
weight: 30
url: /pt/python-net/read-only-presentation/
keywords:
- somente leitura
- proteger apresentação
- impedir edição
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Carregue e salve arquivos PowerPoint (PPT, PPTX) no modo somente leitura com Aspose.Slides para Python via .NET, oferecendo pré-visualizações precisas de slides sem alterar suas apresentações."
---
## **Introdução**

No PowerPoint 2019, a Microsoft introduziu a configuração **Always Open Read-Only** como uma das opções que os usuários podem usar para proteger suas apresentações. Você pode desejar usar essa configuração de Somente Leitura para proteger uma apresentação quando

- Você deseja impedir edições acidentais e manter o conteúdo da sua apresentação seguro. 
- Você deseja alertar as pessoas de que a apresentação fornecida é a versão final. 

Depois de selecionar a opção **Always Open Read-Only** para uma apresentação, quando os usuários a abrem, eles veem a recomendação **Read-Only** e podem ver uma mensagem neste formato: *Para impedir alterações acidentais, o autor definiu este arquivo para ser aberto como somente leitura.*

A recomendação **Read-Only** é um dissuasor simples, porém eficaz, que desencoraja a edição porque os usuários precisam realizar uma ação para removê‑la antes de poderem editar uma apresentação. Se você não deseja que os usuários façam alterações em uma apresentação e quer informá‑los disso de maneira educada, a recomendação **Read-Only** pode ser uma boa opção para você. 

> Se uma apresentação com a proteção **Read-Only** for aberta em uma versão mais antiga do Microsoft PowerPoint — que não suporta a função recentemente introduzida — a recomendação **Read-Only** será ignorada (a apresentação é aberta normalmente).

## **Aplicar Modo Somente Leitura**

Aspose.Slides para Python via .NET permite definir uma apresentação como **Read-Only**, o que significa que os usuários (após abrirem a apresentação) veem a recomendação **Read-Only**. Este código de exemplo mostra como definir uma apresentação como **Read-Only** em Python usando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Nota**: A recomendação **Read-Only** destina‑se simplesmente a desencorajar a edição ou impedir que os usuários façam alterações acidentais em uma apresentação do PowerPoint. Se uma pessoa motivada — que sabe o que está fazendo — decidir editar sua apresentação, ela pode remover facilmente a configuração **Read-Only**. Se você realmente precisar impedir edições não autorizadas, é melhor usar [proteções mais restritivas que envolvem criptografia e senhas](https://docs.aspose.com/slides/pt/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **Perguntas Frequentes**

**Como o 'Read-Only recommended' difere da proteção total por senha?**

'Read-Only recommended' exibe apenas uma sugestão para abrir o arquivo no modo somente leitura e é fácil de contornar. [Proteção por senha](/slides/pt/python-net/password-protected-presentation/) realmente restringe a abertura ou edição e é apropriada quando você precisa de controles de segurança reais.

**É possível combinar o 'Read-Only recommended' com marcas d'água para desencorajar ainda mais edições?**

Sim. A recomendação pode ser combinada com [marcas d'água](/slides/pt/python-net/watermark/) como um impedimento visual; são mecanismos separados e funcionam bem juntos.

**Uma macro ou ferramenta externa ainda pode modificar o arquivo quando a recomendação está ativada?**

Sim. A recomendação não bloqueia alterações programáticas. Para impedir edições automatizadas, use [senhas e criptografia](/slides/pt/python-net/password-protected-presentation/).

**Como o 'Read-Only recommended' se relaciona com os indicadores 'is_encrypted' e 'is_write_protected'?**

Eles são sinais diferentes. 'Read-Only recommended' é um aviso suave e opcional; [is_write_protected](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/is_write_protected/) e [is_encrypted](https://reference.aspose.com/slides/pt/python-net/aspose.slides/protectionmanager/is_encrypted/) indicam restrições reais de escrita ou leitura que dependem de senhas ou criptografia.