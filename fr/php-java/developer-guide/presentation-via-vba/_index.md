---
title: Présentation via VBA
type: docs
weight: 250
url: /fr/php-java/presentation-via-vba/
keywords: "Macro, macros, VBA, macro VBA, ajouter macro, supprimer macro, ajouter VBA, supprimer VBA, extraire macro, extraire VBA, macro PowerPoint, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Ajouter, supprimer et extraire des macros VBA dans des présentations PowerPoint"
---

{{% alert title="Note" color="warning" %}} 

Lorsque vous convertissez une présentation contenant des macros dans un autre format de fichier (PDF, HTML, etc.), Aspose.Slides ignore toutes les macros (les macros ne sont pas transférées dans le fichier résultant).

Lorsque vous ajoutez des macros à une présentation ou que vous sauvegardez à nouveau une présentation contenant des macros, Aspose.Slides écrit simplement les octets des macros.

Aspose.Slides **ne** lance **jamais** les macros dans une présentation.

{{% /alert %}}

## **Ajouter des Macros VBA**

Aspose.Slides fournit la classe [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) pour vous permettre de créer des projets VBA (et des références de projet) et de modifier des modules existants. Vous pouvez utiliser l'interface [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) pour gérer le VBA intégré dans une présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Utilisez le constructeur [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) pour ajouter un nouveau projet VBA.
1. Ajoutez un module au VbaProject.
1. Définissez le code source du module.
1. Ajoutez des références à <stdole>.
1. Ajoutez des références à **Microsoft Office**.
1. Associez les références au projet VBA.
1. Sauvegardez la présentation.

Ce code PHP vous montre comment ajouter une macro VBA à partir de zéro à une présentation :

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
    # Sauvegarde la présentation
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), qui est une application web gratuite utilisée pour supprimer des macros des documents PowerPoint, Excel et Word. 

{{% /alert %}} 

## **Supprimer des Macros VBA**

En utilisant la propriété [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) sous la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), vous pouvez supprimer une macro VBA.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation contenant la macro.
1. Accédez au module Macro et supprimez-le.
1. Sauvegardez la présentation modifiée.

Ce code PHP vous montre comment supprimer une macro VBA :

```php
  # Charge la présentation contenant la macro
  $pres = new Presentation("VBA.pptm");
  try {
    # Accède au module Vba et le supprime
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Sauvegarde la présentation
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extraire des Macros VBA**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation contenant la macro.
2. Vérifiez si la présentation contient un projet VBA.
3. Parcourez tous les modules contenus dans le projet VBA pour afficher les macros.

Ce code PHP vous montre comment extraire des macros VBA d'une présentation contenant des macros :

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