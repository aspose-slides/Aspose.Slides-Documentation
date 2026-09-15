---
title: Gerenciar projetos VBA em apresentações usando Python
linktitle: Apresentação via VBA
type: docs
weight: 250
url: /pt/python-java/presentation-via-vba/
keywords:
- macro
- VBA
- Macro VBA
- adicionar macro
- remover macro
- extrair macro
- adicionar VBA
- remover VBA
- extrair VBA
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Descubra como gerar e manipular apresentações PowerPoint e OpenDocument via VBA com Aspose.Slides para Python via Java para otimizar seu fluxo de trabalho."
---
## **Introdução**

Aspose.Slides fornece classes e interfaces para trabalhar com macros e código VBA.

{{% alert title="Aviso" color="warning" %}} 

Quando você converte uma apresentação que contém macros para um formato de arquivo diferente (PDF, HTML, etc.), Aspose.Slides ignora todas as macros (as macros não são transferidas para o arquivo resultante).

Quando você adiciona macros a uma apresentação ou salva novamente uma apresentação que contém macros, Aspose.Slides simplesmente grava os bytes das macros.

Aspose.Slides **nunca** executa as macros em uma apresentação.

{{% /alert %}}

## **Adicionar Macros VBA**

Aspose.Slides fornece a classe [VbaProject](https://reference.aspose.com/slides/pt/python-java/aspose.slides/vbaproject/) para permitir que você crie projetos VBA (e referências de projeto) e edite módulos existentes. Você pode usar a classe [VbaProject](https://reference.aspose.com/slides/pt/python-java/aspose.slides/vbaproject/) para gerenciar VBA incorporado em uma apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Use o construtor da [VbaProject](https://reference.aspose.com/slides/pt/python-java/aspose.slides/vbaproject/#vbaproject) para adicionar um novo projeto VBA.
1. Adicione um módulo ao projeto VBA.
1. Defina o código-fonte do módulo.
1. Adicione referências a `stdole`.
1. Adicione referências a **Microsoft Office**.
1. Associe as referências ao projeto VBA.
1. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Criar um novo projeto VBA.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Adicionar um módulo vazio e definir seu código-fonte.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Criar referências para stdole e Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Adicionar referências ao projeto VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Salvar a apresentação.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Observação" %}} 

Você pode querer conferir o **Aspose** [Macro Remover](https://products.aspose.app/slides/pt/remove-macros), que é um aplicativo web gratuito usado para remover macros de documentos PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Remover Macros VBA**

Usando o método [getVbaProject](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getvbaproject) da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), você pode remover uma macro VBA.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação que contém a macro.
1. Acesse o módulo da macro e remova-o.
1. Salve a apresentação modificada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Carregar a apresentação que contém a macro.
presentation = Presentation("VBA.pptm")
try:
    # Acessar o módulo VBA e removê-lo.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Salvar a apresentação.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Extrair Macros VBA**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue a apresentação que contém a macro.
2. Verifique se a apresentação contém um Projeto VBA.
3. Percorra todos os módulos contidos no Projeto VBA para visualizar as macros.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Carregar a apresentação que contém a macro.
presentation = Presentation("VBA.pptm")
try:
    # Verificar se a apresentação contém um projeto VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Verificar se um Projeto VBA está Protegido por Senha**

Usando o método [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/pt/python-java/aspose.slides/vbaproject/#ispasswordprotected), você pode determinar se as propriedades de um projeto estão protegidas por senha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e carregue uma apresentação que contém uma macro.
2. Verifique se a apresentação contém um [projeto VBA](https://reference.aspose.com/slides/pt/python-java/aspose.slides/vbaproject/).
3. Verifique se o projeto VBA está protegido por senha para visualizar suas propriedades.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Verificar se a apresentação contém um projeto VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **FAQ**

**O que acontece com as macros se eu salvar a apresentação como PPTX?**

As macros serão removidas porque o PPTX não suporta VBA. Para manter as macros, escolha PPTM, PPSM ou POTM.

**O Aspose.Slides pode executar macros dentro de uma apresentação para, por exemplo, atualizar dados?**

Não. A biblioteca nunca executa código VBA; a execução só é possível dentro do PowerPoint com as configurações de segurança adequadas.

**É suportado trabalhar com controles ActiveX vinculados a código VBA?**

Sim, você pode acessar os [controles ActiveX](/slides/pt/python-java/activex/) existentes, modificar suas propriedades e removê-los. Isso é útil quando as macros interagem com ActiveX.