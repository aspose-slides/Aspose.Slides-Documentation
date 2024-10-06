---
title: Présentation via VBA
type: docs
weight: 250
url: /net/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, ajouter macro, supprimer macro, ajouter VBA, supprimer VBA, extraire macro, extraire VBA, macro PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter, supprimer et extraire des macros VBA dans des présentations PowerPoint en C# ou .NET"
---

Le namespace [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) contient des classes et des interfaces pour travailler avec des macros et du code VBA.

{{% alert title="Remarque" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros dans un format de fichier différent (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas transférées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou enregistrez à nouveau une présentation contenant des macros, Aspose.Slides écrit simplement les octets pour les macros.

Aspose.Slides **n'exécute jamais** les macros dans une présentation.

{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) pour vous permettre de créer des projets VBA (et des références de projet) et d'éditer des modules existants. Vous pouvez utiliser l'interface [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) pour ajouter un nouveau projet VBA.
1. Ajoutez un module au VbaProject.
1. Définissez le code source du module.
1. Ajoutez des références à <stdole>.
1. Ajoutez des références à **Microsoft Office**.
1. Associez les références au projet VBA.
1. Enregistrez la présentation.

Ce code C# vous montre comment ajouter une macro VBA à partir de zéro dans une présentation :

```c#
    // Crée une instance de la classe présentation
using (Presentation presentation = new Presentation())
{
    // Crée un nouveau projet VBA
    presentation.VbaProject = new VbaProject();

    // Ajoute un module vide au projet VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Définit le code source du module
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Crée une référence à <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Crée une référence à Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Ajoute des références au projet VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Enregistre la présentation
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), qui est une application web gratuite utilisée pour supprimer des macros des documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer des macros VBA**
En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) de la classe [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et chargez la présentation contenant la macro.
1. Accédez au module Macro et supprimez-le.
1. Enregistrez la présentation modifiée.

Ce code C# vous montre comment supprimer une macro VBA :

```c#
    // Charge la présentation contenant la macro
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Accède au module Vba et le supprime 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Enregistre la présentation
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Extraire des macros VBA**
1. Créez une instance de la [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules contenus dans le projet VBA pour visualiser les macros.

Ce code C# vous montre comment extraire des macros VBA d'une présentation contenant des macros :

```c#
    // Charge la présentation contenant la macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Vérifie si la Présentation contient un projet VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Vérifier si un projet VBA est protégé par mot de passe**

En utilisant la propriété [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), vous pouvez vérifier si les propriétés du projet sont protégées par un mot de passe.

1. Créez une instance de la [Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un [projet VBA](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/).
3. Vérifiez si le projet VBA est protégé par un mot de passe pour afficher les propriétés du projet.

Ce code C# démontre l'opération :

```c#
using (Presentation pres = new Presentation("VBA.pptm"))
{
    if (pres.VbaProject == null) // Vérifie si la Présentation contient un projet VBA
        return;

    if (pres.VbaProject.IsPasswordProtected)
    {
        Console.WriteLine("Le projet VBA '" + pres.VbaProject.Name +
                            "' est protégé par mot de passe pour visualiser les propriétés du projet.");
    }
}
```