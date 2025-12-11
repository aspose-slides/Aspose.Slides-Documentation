---
title: Gérer les projets VBA dans les présentations avec C++
linktitle: Présentation via VBA
type: docs
weight: 250
url: /fr/cpp/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- ajouter une macro
- supprimer une macro
- extraire une macro
- ajouter VBA
- supprimer VBA
- extraire VBA
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment générer et manipuler des présentations PowerPoint et OpenDocument via VBA avec Aspose.Slides pour C++ afin d'optimiser votre flux de travail."
---

Le namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) contient des classes et des interfaces pour travailler avec les macros et le code VBA.

{{% alert title="Note" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros dans un autre format de fichier (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas conservées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou que vous réenregistrez une présentation contenant des macros, Aspose.Slides écrit simplement les octets des macros.

Aspose.Slides **jamais** exécute les macros dans une présentation.

{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) pour vous permettre de créer des projets VBA (et des références de projet) et de modifier des modules existants. Vous pouvez utiliser l'interface [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) pour ajouter un nouveau projet VBA.
1. Ajoutez un module au VbaProject.
1. Définissez le code source du module.
1. Ajoutez des références à <stdole>.
1. Ajoutez des références à **Microsoft Office**.
1. Associez les références au projet VBA.
1. Enregistrez la présentation.

Ce code C++ montre comment ajouter une macro VBA à partir de zéro à une présentation : 
```c++
// Le chemin du répertoire des documents.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Crée une instance de la classe Presentation
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Crée un nouveau projet VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Ajoute un module vide au projet VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Définit le code source du module
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Crée une référence vers <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Crée une référence vers Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Ajoute des références au projet VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Enregistre la présentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


{{% alert color="primary" %}} 

Vous pouvez consulter **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), une application web gratuite permettant de supprimer les macros des documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer des macros VBA**

En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation contenant la macro.
1. Accédez au module Macro et supprimez-le.
1. Enregistrez la présentation modifiée.

Ce code C++ montre comment supprimer une macro VBA : 
```c++
// Le chemin du répertoire des documents.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Charge la présentation contenant la macro
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Accède au module VBA et le supprime 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Enregistre la présentation
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


## **Extraire des macros VBA**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules du projet VBA pour afficher les macros.

Ce code C++ montre comment extraire les macros VBA d'une présentation contenant des macros : 
```c++
	// Le chemin du répertoire des documents.
	const String templatePath = u"../templates/VBA.pptm";

	// Charge la présentation contenant la macro
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Vérifie si la présentation contient un projet VBA
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


## **Vérifier si un projet VBA est protégé par mot de passe**

En utilisant la propriété [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) vous pouvez déterminer si les propriétés d’un projet sont protégées par mot de passe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et chargez une présentation qui contient une macro.
2. Vérifiez si la présentation contient un [projet VBA](https://reference.aspose.com/slides/cpp/aspose.slides.vba/vbaproject/).
3. Vérifiez si le projet VBA est protégé par mot de passe afin d’afficher ses propriétés.
```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Vérifie si la présentation contient un projet VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```


## **FAQ**

**Que se passe-t-il avec les macros si j’enregistre la présentation au format PPTX ?**

Les macros seront supprimées car le format PPTX ne prend pas en charge VBA. Pour conserver les macros, choisissez PPTM, PPSM ou POTM.

**Aspose.Slides peut‑il exécuter des macros dans une présentation, par exemple pour actualiser des données ?**

Non. La bibliothèque n’exécute jamais le code VBA ; l’exécution n’est possible que dans PowerPoint avec les paramètres de sécurité appropriés.

**La prise en charge des contrôles ActiveX liés au code VBA est‑elle assurée ?**

Oui, vous pouvez accéder aux [contrôles ActiveX](/slides/fr/cpp/activex/), modifier leurs propriétés et les supprimer. Cela est utile lorsque les macros interagissent avec ActiveX.