---
title: Gérer les projets VBA dans les présentations à l’aide de Java
linktitle: Présentation via VBA
type: docs
weight: 250
url: /fr/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "Découvrez comment générer et manipuler des présentations PowerPoint et OpenDocument via VBA avec Aspose.Slides pour Java afin de simplifier votre flux de travail."
---

{{% alert title="Note" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros vers un format de fichier différent (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas transférées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou que vous réenregistrez une présentation contenant des macros, Aspose.Slides écrit simplement les octets des macros.

Aspose.Slides **jamais** n'exécute les macros dans une présentation.

{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/) pour vous permettre de créer des projets VBA (et des références de projet) et de modifier des modules existants. Vous pouvez utiliser l'interface [IVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/#VbaProject--) pour ajouter un nouveau projet VBA.
1. Ajoutez un module au VbaProject.
1. Définissez le code source du module.
1. Ajoutez des références à <stdole>.
1. Ajoutez des références à **Microsoft Office**.
1. Associez les références au projet VBA.
1. Enregistrez la présentation.

Ce code Java vous montre comment ajouter une macro VBA à partir de zéro à une présentation :
```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Crée un nouveau projet VBA
    pres.setVbaProject(new VbaProject());
    
    // Ajoute un module vide au projet VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Définit le code source du module
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Crée une référence vers <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Crée une référence vers Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Ajoute des références au projet VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Enregistre la présentation
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

Vous pourriez vouloir consulter **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), qui est une application web gratuite utilisée pour supprimer les macros de documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer les macros VBA**

En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getVbaProject--) de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et chargez la présentation contenant la macro.
2. Accédez au module Macro et supprimez-le.
3. Enregistrez la présentation modifiée.

```java
// Charge la présentation contenant la macro
Presentation pres = new Presentation("VBA.pptm");
try {
    // Accède au module VBA et le supprime 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Enregistre la présentation
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Extraire les macros VBA**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules contenus dans le projet VBA pour visualiser les macros.

```java
// Charge la présentation contenant la macro
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Vérifie si la présentation contient un projet VBA
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Vérifier si un projet VBA est protégé par mot de passe**

En utilisant la méthode [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/#isPasswordProtected--), vous pouvez déterminer si les propriétés d’un projet sont protégées par mot de passe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) et chargez une présentation contenant une macro.
2. Vérifiez si la présentation contient un [VBA project](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/).
3. Vérifiez si le projet VBA est protégé par mot de passe pour afficher ses propriétés.
```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Vérifier si la présentation contient un projet VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Que se passe-t-il avec les macros si j’enregistre la présentation au format PPTX ?**

Les macros seront supprimées car le format PPTX ne prend pas en charge VBA. Pour conserver les macros, choisissez PPTM, PPSM ou POTM.

**Aspose.Slides peut-il exécuter des macros à l’intérieur d’une présentation pour, par exemple, actualiser des données ?**

Non. La bibliothèque n’exécute jamais le code VBA ; l’exécution n’est possible que dans PowerPoint avec les paramètres de sécurité appropriés.

**La prise en charge des contrôles ActiveX liés au code VBA est‑elle disponible ?**

Oui, vous pouvez accéder aux [ActiveX controls](/slides/fr/java/activex/), modifier leurs propriétés et les supprimer. Cela est utile lorsque les macros interagissent avec ActiveX.