---
title: "Présentation via VBA"
type: docs
weight: 250
url: /fr/nodejs-java/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, ajouter une macro, supprimer une macro, ajouter VBA, supprimer VBA, extraire une macro, extraire VBA, macro PowerPoint, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Ajouter, supprimer et extraire des macros VBA dans des présentations PowerPoint en JavaScript"
---

{{% alert title="Note" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros vers un autre format de fichier (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas transférées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou que vous réenregistrez une présentation contenant des macros, Aspose.Slides écrit simplement les octets des macros.

Aspose.Slides **jamais** n’exécute les macros dans une présentation.

{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) pour vous permettre de créer des projets VBA (et des références de projet) et de modifier les modules existants. Vous pouvez utiliser la classe [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#VbaProject--) pour ajouter un nouveau projet VBA.
1. Ajoutez un module au VbaProject.
1. Définissez le code source du module.
1. Ajoutez des références à <stdole>.
1. Ajoutez des références à **Microsoft Office**.
1. Associez les références au projet VBA.
1. Enregistrez la présentation.

Ce code JavaScript montre comment ajouter une macro VBA à partir de zéro à une présentation :
```javascript
// Crée une instance de la classe de présentation
let pres = new aspose.slides.Presentation();
try {
    // Crée un nouveau projet VBA
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Ajoute un module vide au projet VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Définit le code source du module
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Crée une référence à <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Crée une référence à Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Ajoute des références au projet VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Enregistre la présentation
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

Vous pouvez consulter **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), une application web gratuite utilisée pour supprimer les macros de documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer des macros VBA**

En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject--) de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et chargez la présentation contenant la macro.
1. Accédez au module Macro et supprimez‑le.
1. Enregistrez la présentation modifiée.

Ce code JavaScript montre comment supprimer une macro VBA :
```javascript
// Charge la présentation contenant la macro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Accède au module Vba et le supprime
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Enregistre la présentation
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Extraire des macros VBA**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules contenus dans le projet VBA pour visualiser les macros.

Ce code JavaScript montre comment extraire les macros VBA d’une présentation contenant des macros :
```javascript
// Charge la présentation contenant la macro
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Vérifie si la présentation contient un projet VBA
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Vérifier si un projet VBA est protégé par mot de passe**

En utilisant la méthode [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected), vous pouvez déterminer si les propriétés d’un projet sont protégées par mot de passe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et chargez une présentation contenant une macro.
2. Vérifiez si la présentation contient un [projet VBA](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/).
3. Vérifiez si le projet VBA est protégé par mot de passe afin de consulter ses propriétés.
```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Vérifier si la présentation contient un projet VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
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

**Aspose.Slides peut‑il exécuter des macros à l’intérieur d’une présentation pour, par exemple, actualiser des données ?**

Non. La bibliothèque n’exécute jamais de code VBA ; l’exécution n’est possible que dans PowerPoint avec les paramètres de sécurité appropriés.

**La prise en charge des contrôles ActiveX liés au code VBA est‑elle disponible ?**

Oui, vous pouvez accéder aux [contrôles ActiveX](/slides/fr/nodejs-java/activex/) existants, modifier leurs propriétés et les supprimer. Ceci est utile lorsque les macros interagissent avec ActiveX.