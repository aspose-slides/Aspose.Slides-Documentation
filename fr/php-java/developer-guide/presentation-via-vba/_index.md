---
title: Gérer les projets VBA dans les présentations avec PHP
linktitle: Présentation via VBA
type: docs
weight: 250
url: /fr/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "Découvrez comment générer et manipuler des présentations PowerPoint et OpenDocument via VBA avec Aspose.Slides pour PHP via Java afin d'optimiser votre flux de travail."
---

{{% alert title="Note" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros vers un autre format de fichier (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas transférées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou que vous réenregistrez une présentation contenant des macros, Aspose.Slides écrit simplement les octets des macros.

Aspose.Slides **ne** exécute **jamais** les macros dans une présentation.

{{% /alert %}}

## **Ajouter des macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) pour vous permettre de créer des projets VBA (et des références de projet) et de modifier les modules existants. Vous pouvez utiliser l’interface [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) pour ajouter un nouveau projet VBA.
1. Ajoutez un module au VbaProject.
1. Définissez le code source du module.
1. Ajoutez des références à <stdole>.
1. Ajoutez des références à **Microsoft Office**.
1. Associez les références au projet VBA.
1. Enregistrez la présentation.

Ce code PHP montre comment ajouter une macro VBA depuis le début à une présentation :
```php
  # Crée une instance de la classe de présentation
  $pres = new Presentation();
  try {
    # Crée un nouveau projet VBA
    $pres->setVbaProject(new VbaProject());
    # Ajoute un module vide au projet VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Définit le code source du module
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Crée une référence à <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Crée une référence à Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Ajoute des références au projet VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Enregistre la présentation
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

Vous voudrez peut‑être consulter **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), qui est une application Web gratuite utilisée pour supprimer les macros des documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer les macros VBA**

En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation contenant la macro.
1. Accédez au module Macro et supprimez‑le.
1. Enregistrez la présentation modifiée.

Ce code PHP montre comment supprimer une macro VBA :
```php
  # Charge la présentation contenant la macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Accède au module Vba et le supprime
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Enregistre la présentation
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Extraire les macros VBA**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules du projet VBA pour visualiser les macros.

Ce code PHP montre comment extraire les macros VBA d’une présentation contenant des macros :
```php
  # Charge la présentation contenant la macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Vérifie si la présentation contient un projet VBA
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Vérifier si un projet VBA est protégé par mot de passe**

En utilisant la méthode [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected), vous pouvez déterminer si les propriétés d’un projet sont protégées par mot de passe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et chargez une présentation contenant une macro.
2. Vérifiez si la présentation contient un [VBA project](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/).
3. Vérifiez si le projet VBA est protégé par mot de passe pour afficher ses propriétés.
```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Vérifier si la présentation contient un projet VBA.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Que se passe-t-il avec les macros si j’enregistre la présentation au format PPTX ?**

Les macros seront supprimées car le format PPTX ne prend pas en charge VBA. Pour conserver les macros, choisissez PPTM, PPSM ou POTM.

**Aspose.Slides peut‑il exécuter des macros à l’intérieur d’une présentation, par exemple pour actualiser des données ?**

Non. La bibliothèque n’exécute jamais de code VBA ; l’exécution n’est possible que dans PowerPoint avec les paramètres de sécurité appropriés.

**La manipulation des contrôles ActiveX liés à du code VBA est‑elle supportée ?**

Oui, vous pouvez accéder aux [ActiveX controls](/slides/fr/php-java/activex/), modifier leurs propriétés et les supprimer. Ceci est utile lorsque les macros interagissent avec ActiveX.