---
title: Gérer les projets VBA dans les présentations en .NET
linktitle: Présentation via VBA
type: docs
weight: 250
url: /fr/net/presentation-via-vba/
keywords:
- macro
- VBA
- macro VBA
- ajouter macro
- supprimer macro
- extraire macro
- ajouter VBA
- supprimer VBA
- extraire VBA
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment générer et manipuler des présentations PowerPoint et OpenDocument via VBA avec Aspose.Slides pour .NET afin d'optimiser votre flux de travail."
---
## **Introduction**

L'espace de noms [Aspose.Slides.Vba](https://reference.aspose.com/slides/fr/net/aspose.slides.vba/) contient des classes et des interfaces permettant de travailler avec les macros et le code VBA.

{{% alert title="Note" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros vers un autre format de fichier (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas transférées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou que vous réenregistrez une présentation contenant des macros, Aspose.Slides écrit simplement les octets des macros.

Aspose.Slides **ne** exécute **jamais** les macros d’une présentation.

{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/fr/net/aspose.slides.vba/vbaproject/) pour vous permettre de créer des projets VBA (et des références de projet) et de modifier les modules existants. Vous pouvez utiliser l'interface [IVbaProject](https://reference.aspose.com/slides/fr/net/aspose.slides.vba/ivbaproject/) pour gérer le VBA intégré dans une présentation.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) .
1. Utiliser le constructeur de [VbaProject](https://reference.aspose.com/slides/fr/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) pour ajouter un nouveau projet VBA.
1. Ajouter un module au VbaProject.
1. Définir le code source du module.
1. Ajouter des références à <stdole>.
1. Ajouter des références à **Microsoft Office**.
1. Associer les références au projet VBA.
1. Enregistrer la présentation.

Ce code C# vous montre comment ajouter une macro VBA à partir de zéro à une présentation :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

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
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

Vous pourriez être intéressé par le [Macro Remover](https://products.aspose.app/slides/fr/remove-macros) d’**Aspose**, une application web gratuite permettant de supprimer les macros des documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer des macros VBA**
En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/vbaproject/) de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) , vous pouvez supprimer une macro VBA.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et charger la présentation contenant la macro.
1. Accéder au module Macro et le supprimer.
1. Enregistrer la présentation modifiée.

Ce code C# vous montre comment supprimer une macro VBA :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Charge la présentation contenant la macro
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Accède au module Vba et le supprime
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Enregistre la présentation
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Extraire des macros VBA**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et charger la présentation contenant la macro.
2. Vérifier si la présentation contient un projet VBA.
3. Parcourir tous les modules du projet VBA pour afficher les macros.

Ce code C# vous montre comment extraire des macros VBA d’une présentation contenant des macros :

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

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

En utilisant la propriété [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/fr/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) , vous pouvez déterminer si les propriétés d’un projet sont protégées par mot de passe.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et charger une présentation contenant une macro.
2. Vérifier si la présentation contient un [projet VBA](https://reference.aspose.com/slides/fr/net/aspose.slides.vba/vbaproject/).
3. Vérifier si le projet VBA est protégé par mot de passe pour afficher ses propriétés.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Vérifier si la présentation contient un projet VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

### Que se passe-t-il avec les macros si j’enregistre la présentation au format PPTX ?

Les macros seront supprimées car le format PPTX ne prend pas en charge VBA. Pour conserver les macros, choisissez PPTM, PPSM ou POTM.

### Aspose.Slides peut‑il exécuter des macros à l’intérieur d’une présentation pour, par exemple, actualiser des données ?

Non. La bibliothèque n’exécute jamais de code VBA ; l’exécution n’est possible qu’à l’intérieur de PowerPoint avec les paramètres de sécurité appropriés.

### Le travail avec des contrôles ActiveX liés à du code VBA est‑il pris en charge ?

Oui, vous pouvez accéder aux [contrôles ActiveX](/slides/fr/net/activex/), modifier leurs propriétés et les supprimer. Ceci est utile lorsque les macros interagissent avec des contrôles ActiveX.