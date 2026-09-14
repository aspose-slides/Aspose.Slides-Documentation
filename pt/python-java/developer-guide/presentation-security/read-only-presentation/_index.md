---
title: Salvar apresentações em modo somente-leitura usando Python
linktitle: Apresentação somente-leitura
type: docs
weight: 30
url: /pt/python-java/read-only-presentation/
keywords:
- somente-leitura
- proteger apresentação
- impedir edição
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Carregue e salve arquivos PowerPoint (PPT, PPTX) em modo somente-leitura com Aspose.Slides for Python via Java, oferecendo pré-visualizações precisas dos slides sem alterar suas apresentações."
---
## **Introdução**

No PowerPoint 2019, a Microsoft introduziu a configuração **Always Open Read-Only** como uma das opções que os usuários podem usar para proteger suas apresentações. Você pode querer usar essa configuração Read-Only para proteger uma apresentação quando:

- Você deseja impedir edições acidentais e manter o conteúdo da sua apresentação seguro.
- Você deseja alertar as pessoas de que a apresentação que você forneceu é a versão final.

Depois de selecionar a opção **Always Open Read-Only** para uma apresentação, quando os usuários abrem a apresentação, eles veem a recomendação **Read-Only** e podem ver uma mensagem neste formato: *Para impedir alterações acidentais, o autor definiu este arquivo para ser aberto como somente‑leitura.*

A recomendação **Read-Only** é um impedimento simples, porém eficaz, que desencoraja a edição porque os usuários precisam realizar uma tarefa para removê‑la antes de poderem editar a apresentação. Se você não quer que os usuários façam alterações em uma apresentação e deseja informá‑los sobre isso de maneira educada, então a recomendação **Read-Only** pode ser uma boa opção para você.

> Se uma apresentação com a proteção **Read-Only** for aberta em uma versão mais antiga do Microsoft PowerPoint — que não suporta a função recentemente introduzida — a recomendação **Read-Only** será ignorada (a apresentação será aberta normalmente).

## **Aplicar Modo Read-Only**

Aspose.Slides for Python via Java permite definir uma apresentação como **Read-Only**, o que significa que os usuários (depois de abrir a apresentação) veem a recomendação **Read-Only**. Este código de exemplo mostra como definir uma apresentação como **Read-Only** em Python usando Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
A recomendação **Read-Only** destina‑se simplesmente a desencorajar a edição ou impedir que os usuários façam alterações acidentais em uma apresentação do PowerPoint. Se uma pessoa motivada — que sabe o que está fazendo — decidir editar sua apresentação, ela pode remover facilmente a configuração Read-Only. Se você realmente precisa impedir edições não autorizadas, é melhor usar [proteções mais rigorosas que envolvem criptografia e senhas](/slides/pt/python-java/password-protected-presentation/). 
{{% /alert %}} 

## **FAQ**

**Como o 'Read-Only recommended' difere da proteção completa por senha?**  
'Read-Only recommended' exibe apenas uma sugestão para abrir o arquivo no modo somente‑leitura e é fácil de contornar. [Proteção por senha](/slides/pt/python-java/password-protected-presentation/) realmente restringe a abertura ou edição e é adequada quando você precisa de controles de segurança reais.

**É possível combinar 'Read-Only recommended' com marcas d'água para desencorajar ainda mais as edições?**  
Sim. A recomendação pode ser combinada com [marcas d'água](/slides/pt/python-java/watermark/) como um impedimento visual; são mecanismos separados e funcionam bem juntos.

**Uma macro ou ferramenta externa ainda pode modificar o arquivo quando a recomendação está ativada?**  
Sim. A recomendação não impede alterações programáticas. Para impedir edições automatizadas, use [senhas e criptografia](/slides/pt/python-java/password-protected-presentation/).

**Como o 'Read-Only recommended' se relaciona com os métodos [isEncrypted](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#isEncrypted) e [isWriteProtected](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**  
Eles são sinais diferentes. 'Read-Only recommended' é um aviso suave e opcional; [isWriteProtected](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#isWriteProtected) e [isEncrypted](https://reference.aspose.com/slides/pt/python-java/aspose.slides/protectionmanager/#isEncrypted) indicam restrições reais de gravação ou leitura que dependem de senhas ou criptografia.