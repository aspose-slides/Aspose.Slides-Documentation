---
title: Gerenciar Projetos VBA em Apresentações Usando C++
linktitle: Apresentação via VBA
type: docs
weight: 250
url: /pt/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "Descubra como gerar e manipular apresentações PowerPoint e OpenDocument via VBA com Aspose.Slides para C++ para otimizar seu fluxo de trabalho."
---
## **Introdução**

O namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.vba/) contém classes e interfaces para trabalhar com macros e código VBA.

{{% alert title="Note" color="warning" %}} 

Quando você converte uma apresentação que contém macros para um formato de arquivo diferente (PDF, HTML, etc.), o Aspose.Slides ignora todas as macros (as macros não são transportadas para o arquivo resultante).

Ao adicionar macros a uma apresentação ou regravar uma apresentação que contém macros, o Aspose.Slides simplesmente grava os bytes das macros.

O Aspose.Slides **nunca** executa as macros em uma apresentação.

{{% /alert %}}

## **Adicionar Macros VBA**

O Aspose.Slides fornece a classe [VbaProject](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.vba.vba_project) para permitir a criação de projetos VBA (e referências de projeto) e a edição de módulos existentes. Você pode usar a interface [IVbaProject](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.vba.i_vba_project/) para gerenciar VBA incorporado em uma apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Use o construtor [VbaProject](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) para adicionar um novo projeto VBA.
1. Adicione um módulo ao VbaProject.
1. Defina o código-fonte do módulo.
1. Adicione referências a <stdole>.
1. Adicione referências ao **Microsoft Office**.
1. Associe as referências ao projeto VBA.
1. Salve a apresentação.

Este código C++ mostra como adicionar uma macro VBA do zero a uma apresentação: 

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Cria uma instância da classe Presentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Cria um novo Projeto VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Adiciona um módulo vazio ao projeto VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Define o código-fonte do módulo
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Cria uma referência a <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Cria uma referência ao Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Adiciona referências ao projeto VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Salva a Apresentação
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

Você pode querer conferir o **Aspose** [Macro Remover](https://products.aspose.app/slides/pt/remove-macros), que é um aplicativo web gratuito usado para remover macros de documentos PowerPoint, Excel e Word. 

{{% /alert %}} 

## **Remover Macros VBA**

Usando a propriedade [VbaProject](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation), você pode remover uma macro VBA.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) e carregue a apresentação que contém a macro.
1. Acesse o módulo Macro e remova‑o.
1. Salve a apresentação modificada.

Este código C++ mostra como remover uma macro VBA: 

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Carrega a apresentação contendo a macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Acessa o módulo Vba e o remove 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Salva a Apresentação
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Extrair Macros VBA**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) e carregue a apresentação que contém a macro.
2. Verifique se a apresentação contém um Projeto VBA.
3. Percorra todos os módulos contidos no Projeto VBA para visualizar as macros.

Este código C++ mostra como extrair macros VBA de uma apresentação que contém macros: 

```c++
	// O caminho para o diretório de documentos.
	const String templatePath = u"../templates/VBA.pptm";

	// Carrega a apresentação contendo a macro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Verifica se a Apresentação contém um Projeto VBA
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **Verificar se um Projeto VBA está protegido por senha**

Usando a propriedade [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/pt/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/), você pode determinar se as propriedades de um projeto estão protegidas por senha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e carregue uma apresentação que contém uma macro.
2. Verifique se a apresentação contém um [projeto VBA](https://reference.aspose.com/slides/pt/cpp/aspose.slides.vba/vbaproject/).
3. Verifique se o projeto VBA está protegido por senha para visualizar suas propriedades.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Verifica se a apresentação contém um projeto VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **Perguntas Frequentes**

**O que acontece com as macros se eu salvar a apresentação como PPTX?**

As macros serão removidas porque o PPTX não suporta VBA. Para manter as macros, escolha PPTM, PPSM ou POTM.

**O Aspose.Slides pode executar macros dentro de uma apresentação para, por exemplo, atualizar dados?**

Não. A biblioteca nunca executa código VBA; a execução só é possível dentro do PowerPoint com as configurações de segurança apropriadas.

**Trabalhar com controles ActiveX vinculados a código VBA é suportado?**

Sim, você pode acessar os [controles ActiveX](/slides/pt/cpp/activex/), modificar suas propriedades e removê‑los. Isso é útil quando as macros interagem com ActiveX.