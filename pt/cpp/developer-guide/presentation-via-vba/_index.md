---
title: Gerenciar Projetos VBA em Apresentações Usando C++
linktitle: Apresentação via VBA
type: docs
weight: 250
url: /pt/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "Descubra como gerar e manipular apresentações PowerPoint e OpenDocument via VBA com Aspose.Slides para C++ para otimizar seu fluxo de trabalho."
---
## **Introdução**

O namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides.vba/) contém classes e interfaces para trabalhar com macros e código VBA.

{{% alert title="Note" color="warning" %}} 
Ao converter uma apresentação contendo macros para um formato de arquivo diferente (PDF, HTML, etc.), o Aspose.Slides ignora todas as macros (as macros não são transferidas para o arquivo resultante).

Ao adicionar macros a uma apresentação ou salvar novamente uma apresentação contendo macros, o Aspose.Slides simplesmente grava os bytes das macros.

O Aspose.Slides **nunca** executa as macros em uma apresentação.
{{% /alert %}}

## **Adicionar Macros VBA**

O Aspose.Slides fornece a classe [VbaProject](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.vba.vba_project) para permitir a criação de projetos VBA (e referências de projeto) e a edição de módulos existentes. Você pode usar a interface [IVbaProject](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.vba.i_vba_project/) para gerenciar o VBA incorporado em uma apresentação.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Use o construtor da [VbaProject](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) para adicionar um novo projeto VBA.
3. Adicione um módulo ao VbaProject.
4. Defina o código-fonte do módulo.
5. Adicione referências a <stdole>.
6. Adicione referências a **Microsoft Office**.
7. Associe as referências ao projeto VBA.
8. Salve a apresentação.

Este código C++ mostra como adicionar uma macro VBA do zero a uma apresentação: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// Caminho para o diretório de documentos.
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

{{% alert color="info" %}} 
Você pode querer conferir o **Aspose** [Macro Remover](https://products.aspose.app/slides/pt/remove-macros), que é um aplicativo web gratuito usado para remover macros de documentos PowerPoint, Excel e Word. 
{{% /alert %}} 

## **Remover Macros VBA**

Usando a propriedade [VbaProject](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation), você pode remover uma macro VBA.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation) e carregue a apresentação que contém a macro.
2. Acesse o módulo Macro e remova-o.
3. Salve a apresentação modificada.

Este código C++ mostra como remover uma macro VBA: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// O caminho para o diretório de documentos.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Carrega a apresentação que contém a macro
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
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// O caminho para o diretório de documentos.
	const String templatePath = u"../templates/VBA.pptm";

	// Carrega a apresentação que contém a macro
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

## **Verificar se um Projeto VBA é Protegido por Senha**

Usando a propriedade [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/pt/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/), você pode determinar se as propriedades de um projeto estão protegidas por senha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e carregue uma apresentação que contém uma macro.
2. Verifique se a apresentação contém um [projeto VBA](https://reference.aspose.com/slides/pt/cpp/aspose.slides.vba/vbaproject/).
3. Verifique se o projeto VBA está protegido por senha para visualizar suas propriedades.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

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

## **FAQ**

### O que acontece com as macros se eu salvar a apresentação como PPTX?

As macros serão removidas porque o PPTX não suporta VBA. Para manter as macros, escolha PPTM, PPSM ou POTM.

### O Aspose.Slides pode executar macros dentro de uma apresentação para, por exemplo, atualizar dados?

Não. A biblioteca nunca executa código VBA; a execução só é possível dentro do PowerPoint com as configurações de segurança apropriadas.

### O trabalho com controles ActiveX vinculados a código VBA é suportado?

Sim, você pode acessar os [controles ActiveX](/slides/pt/cpp/activex/), modificar suas propriedades e removê-los. Isso é útil quando macros interagem com ActiveX.