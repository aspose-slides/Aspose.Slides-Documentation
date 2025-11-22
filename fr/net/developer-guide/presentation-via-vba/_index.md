---
title: Présentation via VBA
type: docs
weight: 250
url: /fr/net/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, ajouter une macro, supprimer une macro, ajouter VBA, supprimer VBA, extraire une macro, extraire VBA, macro PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter, supprimer et extraire des macros VBA dans des présentations PowerPoint en C# ou .NET"
---

L'espace de noms [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) contient des classes et des interfaces pour travailler avec les macros et le code VBA.

{{% alert title="Note" color="warning" %}} 
Lorsque vous convertissez une présentation contenant des macros vers un autre format de fichier (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas transférées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou enregistrez à nouveau une présentation contenant des macros, Aspose.Slides écrit simplement les octets des macros.

Aspose.Slides **ne** exécute **jamais** les macros dans une présentation.
{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) permettant de créer des projets VBA (et des références de projet) et de modifier les modules existants. Vous pouvez utiliser l'interface [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) pour ajouter un nouveau projet VBA.
3. Ajoutez un module au VbaProject.
4. Définissez le code source du module.
5. Ajoutez des références à <stdole>.
6. Ajoutez des références à **Microsoft Office**.
7. Associez les références au projet VBA.
8. Enregistrez la présentation.

Ce code C# montre comment ajouter une macro VBA à partir de zéro à une présentation :
```c#
    // Crée une instance de la classe Presentation
using (Presentation presentation = new Presentation())
{
    // Crée un nouveau projet VBA
    presentation.VbaProject = new VbaProject();

    // Ajoute un module vide au projet VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Définit le code source du module
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Crée une référence vers <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Crée une référence vers Office
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
Vous pouvez consulter **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), une application web gratuite permettant de supprimer les macros de documents PowerPoint, Excel et Word. 
{{% /alert %}} 

## **Supprimer des macros VBA**
En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et chargez la présentation contenant la macro.
2. Accédez au module Macro et supprimez-le.
3. Enregistrez la présentation modifiée.

Ce code C# montre comment supprimer une macro VBA :
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
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules du projet VBA pour afficher les macros.

Ce code C# montre comment extraire les macros VBA d’une présentation contenant des macros :
```c#
    // Charge la présentation contenant la macro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Vérifie si la présentation contient un projet VBA
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
En utilisant la propriété [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), vous pouvez déterminer si les propriétés d’un projet sont protégées par mot de passe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et chargez une présentation contenant une macro.
2. Vérifiez si la présentation contient un [projet VBA](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/).
3. Vérifiez si le projet VBA est protégé par mot de passe pour consulter ses propriétés.
```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Vérifie si la présentation contient un projet VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```


## **FAQ**

**Que se passe-t-il avec les macros si j’enregistre la présentation au format PPTX ?**  
Les macros seront supprimées car le format PPTX ne prend pas en charge VBA. Pour conserver les macros, choisissez PPTM, PPSM ou POTM.

**Aspose.Slides peut-il exécuter des macros dans une présentation, par exemple pour actualiser des données ?**  
Non. La bibliothèque n’exécute jamais de code VBA ; l’exécution n’est possible qu’à l’intérieur de PowerPoint avec les paramètres de sécurité appropriés.

**Le travail avec des contrôles ActiveX liés à du code VBA est‑il pris en charge ?**  
Oui, vous pouvez accéder aux [contrôles ActiveX](/slides/fr/net/activex/) existants, modifier leurs propriétés et les supprimer. Cela est utile lorsque les macros interagissent avec ActiveX.