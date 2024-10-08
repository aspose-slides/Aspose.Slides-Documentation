---
title: Présentation via VBA
type: docs
weight: 250
url: /fr/cpp/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, ajouter macro, supprimer macro, ajouter VBA, supprimer VBA, extraire macro, extraire VBA, macro PowerPoint, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Ajouter, supprimer et extraire des macros VBA dans des présentations PowerPoint en C++"
---

L'espace de noms [Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) contient des classes et des interfaces pour travailler avec des macros et du code VBA.

{{% alert title="Remarque" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros dans un autre format de fichier (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas incluses dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou que vous enregistrez à nouveau une présentation contenant des macros, Aspose.Slides écrit simplement les octets des macros.

Aspose.Slides **n'exécute jamais** les macros dans une présentation.

{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) pour vous permettre de créer des projets VBA (et des références de projet) et d'éditer des modules existants. Vous pouvez utiliser l'interface [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) pour ajouter un nouveau projet VBA.
1. Ajoutez un module au VbaProject.
1. Définissez le code source du module.
1. Ajoutez des références à <stdole>.
1. Ajoutez des références à **Microsoft Office**.
1. Associez les références au projet VBA.
1. Enregistrez la présentation.

Ce code C++ vous montre comment ajouter une macro VBA depuis le début à une présentation : 

```c++

// Le chemin vers le répertoire des documents.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Crée une instance de la classe de présentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Crée un nouveau projet VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Ajoute un module vide au projet VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Définit le code source du module
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Crée une référence à <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Crée une référence à Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Ajoute des références au projet VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Enregistre la présentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), qui est une application web gratuite utilisée pour supprimer des macros de documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer des macros VBA**

En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation contenant la macro.
1. Accédez au module Macro et supprimez-le.
1. Enregistrez la présentation modifiée.

Ce code C++ vous montre comment supprimer une macro VBA : 

```c++

// Le chemin vers le répertoire des documents.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Charge la présentation contenant la macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Accède au module Vba et le supprime 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Enregistre la présentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Extraire des macros VBA**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules contenus dans le projet VBA pour visualiser les macros.

Ce code C++ vous montre comment extraire des macros VBA d'une présentation contenant des macros : 

```c++
	// Le chemin vers le répertoire des documents.
	const String templatePath = u"../templates/VBA.pptm";

	// Charge la présentation contenant la macro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	if (pres->get_VbaProject() != NULL) // Vérifie si la Présentation contient un projet VBA
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