---
title: Gerenciar projetos VBA em apresentações com Python
linktitle: Apresentação via VBA
type: docs
weight: 250
url: /pt/python-net/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
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
- Aspose.Slides
description: "Descubra como gerar e manipular apresentações PowerPoint e OpenDocument via VBA com Aspose.Slides para Python via .NET para otimizar seu fluxo de trabalho."
---
## **Visão geral**

Este artigo examina os principais recursos do Aspose.Slides para Python via .NET para trabalhar com macros em apresentações do PowerPoint. A biblioteca fornece ferramentas convenientes para adicionar, remover e extrair macros, o que permite automatizar a criação e a modificação de apresentações.

Com Aspose.Slides, você pode:

- Acelerar o desenvolvimento de apresentações—a automação de tarefas rotineiras reduz o tempo necessário para preparar o material.
- Garantir flexibilidade—a capacidade de gerenciar macros permite adaptar as apresentações a tarefas e cenários específicos.
- Integrar dados—integração simples com fontes de dados externas ajuda a manter o conteúdo dos slides atualizado.
- Simplificar a manutenção—o gerenciamento centralizado de macros facilita a aplicação de alterações e a atualização de apresentações.

O artigo continua apresentando exemplos práticos de como usar o Aspose.Slides para trabalhar de forma eficaz com macros no PowerPoint.

O namespace [aspose.slides.vba](https://reference.aspose.com/slides/pt/python-net/aspose.slides.vba/) fornece classes para trabalhar com macros e código VBA.

{{% alert title="Note" color="warning" %}}
Ao converter uma apresentação que contém macros para outro formato (PDF, HTML, etc.), o Aspose.Slides ignora as macros—elas não são transferidas para o arquivo de saída.

Ao adicionar macros a uma apresentação ou salvar novamente uma apresentação que contém macros, o Aspose.Slides grava os bytes das macros como estão.

Aspose.Slides **nunca** executa macros em uma apresentação.
{{% /alert %}}

## **Adicionar macros VBA**

O Aspose.Slides fornece a classe [VbaProject](https://reference.aspose.com/slides/pt/python-net/aspose.slides.vba/vbaproject/) para criar projetos VBA (e referências de projeto) e editar módulos existentes.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Use o construtor [VbaProject](https://reference.aspose.com/slides/pt/python-net/aspose.slides.vba/vbaproject/#constructors) para adicionar um novo projeto VBA.
3. Adicione um módulo ao projeto VBA.
4. Defina o código-fonte do módulo.
5. Adicione uma referência a `<stdole>`.
6. Adicione uma referência ao **Microsoft Office**.
7. Associe as referências ao projeto VBA.
8. Salve a apresentação.

O código Python a seguir mostra como adicionar uma macro VBA do zero a uma apresentação:

```python
import aspose.slides as slides

# Crie uma instância da classe Presentation.
with slides.Presentation() as presentation:

    # Crie um novo projeto VBA.
    presentation.vba_project = slides.vba.VbaProject()

    # Adicione um módulo vazio ao projeto VBA.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Defina o código-fonte do módulo.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Crie uma referência a <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Crie uma referência ao Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Adicione as referências ao projeto VBA.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Salve a apresentação.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
Você pode querer experimentar o **Aspose** [Macro Remover](https://products.aspose.app/slides/pt/remove-macros), um aplicativo web gratuito para remover macros de documentos PowerPoint, Excel e Word.
{{% /alert %}}

## **Remover macros VBA**

Usando a propriedade [vba_project](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/vba_project/) da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/), você pode remover uma macro VBA.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação que contém a macro.
2. Acesse o módulo da macro e remova-o.
3. Salve a apresentação modificada.

O código Python a seguir mostra como remover uma macro VBA:

```python
import aspose.slides as slides

# Carregue a apresentação que contém a macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Acesse o módulo VBA.
    vba_module = presentation.vba_project.modules[0]

    # Remova o módulo VBA.
    presentation.vba_project.modules.remove(vba_module)

    # Salve a apresentação.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Extrair macros VBA**

Usando a propriedade `modules` na classe [VbaProject](https://reference.aspose.com/slides/pt/python-net/aspose.slides.vba/vbaproject/), você pode acessar todos os módulos de um projeto VBA. A classe [VbaModule](https://reference.aspose.com/slides/pt/python-net/aspose.slides.vba/vbamodule/) pode ser usada para extrair propriedades do módulo, como o nome e o código.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue a apresentação que contém a macro.
2. Verifique se a apresentação contém um projeto VBA.
3. Percorra todos os módulos no projeto VBA para visualizar as macros.

O código Python a seguir mostra como extrair macros VBA de uma apresentação:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Verifique se a apresentação contém um projeto VBA.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Verificar se um projeto VBA está protegido por senha**

Usando a propriedade [VbaProject.is_password_protected](https://reference.aspose.com/slides/pt/python-net/aspose.slides.vba/vbaproject/is_password_protected/), você pode determinar se as propriedades de um projeto estão protegidas por senha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e carregue uma apresentação que contém uma macro.
2. Verifique se a apresentação contém um [projeto VBA](https://reference.aspose.com/slides/pt/python-net/aspose.slides.vba/vbaproject/).
3. Verifique se o projeto VBA está protegido por senha para visualizar suas propriedades.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Verifique se a apresentação contém um projeto VBA.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**O que acontece com as macros se eu salvar a apresentação como PPTX?**

As macros serão removidas porque o PPTX não oferece suporte a VBA. Para manter as macros, escolha PPTM, PPSM ou POTM.

**O Aspose.Slides pode executar macros dentro de uma apresentação para, por exemplo, atualizar dados?**

Não. A biblioteca nunca executa código VBA; a execução só é possível dentro do PowerPoint com as configurações de segurança adequadas.

**É suportado trabalhar com controles ActiveX vinculados a código VBA?**

Sim, você pode acessar os [controles ActiveX](/slides/pt/python-net/activex/), modificar suas propriedades e removê-los. Isso é útil quando as macros interagem com ActiveX.