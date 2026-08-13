---
title: Gerenciar Projetos VBA em Apresentações em .NET
linktitle: Apresentação via VBA
type: docs
weight: 250
url: /pt/net/presentation-via-vba/
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
- .NET
- C#
- Aspose.Slides
description: "Descubra como gerar e manipular apresentações PowerPoint e OpenDocument via VBA com Aspose.Slides para .NET e otimizar seu fluxo de trabalho."
---
## **Introdução**

O namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/pt/net/aspose.slides.vba/) contém classes e interfaces para trabalhar com macros e código VBA.

{{% alert title="Nota" color="warning" %}} 
Ao converter uma apresentação que contém macros para um formato de arquivo diferente (PDF, HTML, etc.), o Aspose.Slides ignora todas as macros (as macros não são transferidas para o arquivo resultante).

Ao adicionar macros a uma apresentação ou salvar novamente uma apresentação que contém macros, o Aspose.Slides simplesmente grava os bytes das macros.

O Aspose.Slides **nunca** executa as macros em uma apresentação.
{{% /alert %}}

## **Adicionar Macros VBA**

O Aspose.Slides fornece a classe [VbaProject](https://reference.aspose.com/slides/pt/net/aspose.slides.vba/vbaproject/) para permitir que você crie projetos VBA (e referências de projeto) e edite módulos existentes. Você pode usar a interface [IVbaProject](https://reference.aspose.com/slides/pt/net/aspose.slides.vba/ivbaproject/) para gerenciar VBA incorporado em uma apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) .
2. Use o construtor [VbaProject](https://reference.aspose.com/slides/pt/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) para adicionar um novo projeto VBA.
3. Adicione um módulo ao VbaProject.
4. Defina o código-fonte do módulo.
5. Adicione referências a <stdole>.
6. Adicione referências a **Microsoft Office**.
7. Associe as referências ao projeto VBA.
8. Salve a apresentação.

Este código C# mostra como adicionar uma macro VBA do zero a uma apresentação:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// Cria uma instância da classe de apresentação
using (Presentation presentation = new Presentation())
{
    // Cria um novo Projeto VBA
    presentation.VbaProject = new VbaProject();

    // Adiciona um módulo vazio ao projeto VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // Define o código-fonte do módulo
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Cria uma referência a <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Cria uma referência ao Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Adiciona referências ao projeto VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // Salva a Apresentação
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 
Você pode querer conferir o **Aspose** [Macro Remover](https://products.aspose.app/slides/pt/remove-macros), que é um aplicativo web gratuito usado para remover macros de documentos PowerPoint, Excel e Word. 
{{% /alert %}} 

## **Remover Macros VBA**

Usando a propriedade [VbaProject](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/vbaproject/) da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/), você pode remover uma macro VBA.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e carregue a apresentação que contém a macro.
2. Acesse o módulo Macro e remova‑o.
3. Salve a apresentação modificada.

Este código C# mostra como remover uma macro VBA:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Carrega a apresentação que contém a macro
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Acessa o módulo Vba e o remove
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Salva a Apresentação
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Extrair Macros VBA**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e carregue a apresentação que contém a macro.
2. Verifique se a apresentação contém um Projeto VBA.
3. Percorra todos os módulos contidos no Projeto VBA para visualizar as macros.

Este código C# mostra como extrair macros VBA de uma apresentação que contém macros:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // Carrega a apresentação que contém a macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Verifica se a Apresentação contém um Projeto VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Verificar se um Projeto VBA está protegido por senha**

Usando a propriedade [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/pt/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), você pode determinar se as propriedades de um projeto estão protegidas por senha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e carregue uma apresentação que contém uma macro.
2. Verifique se a apresentação contém um [Projeto VBA](https://reference.aspose.com/slides/pt/net/aspose.slides.vba/vbaproject/).
3. Verifique se o projeto VBA está protegido por senha para visualizar suas propriedades.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Verifica se a apresentação contém um projeto VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

### O que acontece com as macros se eu salvar a apresentação como PPTX?

As macros serão removidas porque o PPTX não suporta VBA. Para manter as macros, escolha PPTM, PPSM ou POTM.

### O Aspose.Slides pode executar macros dentro de uma apresentação para, por exemplo, atualizar dados?

Não. A biblioteca nunca executa código VBA; a execução só é possível dentro do PowerPoint com as configurações de segurança apropriadas.

### É suportado trabalhar com controles ActiveX vinculados a código VBA?

Sim, você pode acessar os [controles ActiveX](/slides/pt/net/activex/) existentes, modificar suas propriedades e removê‑los. Isso é útil quando as macros interagem com ActiveX.