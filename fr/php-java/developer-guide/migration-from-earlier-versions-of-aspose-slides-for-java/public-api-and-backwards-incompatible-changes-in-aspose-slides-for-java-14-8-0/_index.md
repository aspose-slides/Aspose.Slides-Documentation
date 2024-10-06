---
title: API Publique et Changements Rétro-Incompatibles dans Aspose.Slides pour PHP via Java 14.8.0
type: docs
weight: 70
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) de classes, méthodes, propriétés, etc., toute nouvelle restriction et autres [changements](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) introduits avec l'API Aspose.Slides pour PHP via Java 14.8.0.

{{% /alert %}} 
## **Changements de l'API Publique**
### **Ajout des Méthodes Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() et setOverlap(byte)**
La méthode Aspose.Slides.Charts.IChartSeries.getOverlap() obtient combien les barres et les colonnes doivent se chevaucher sur les graphiques 2D (dans une plage de -100 à 100).
Cette méthode n'est pas seulement pour des séries spécifiques mais pour toutes les séries du groupe de séries parent - il s'agit de la projection de la propriété de groupe appropriée.

- Utilisez la méthode IChartSeries.getParentSeriesGroup() pour accéder au groupe de séries parent.
- Utilisez les méthodes IChartSeriesGroup.getOverlap() et setOverlap(byte) pour gérer la valeur.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
  $series = $chart->getChartData()->getSeries();
  if (java_values($series->get_Item(0)->getOverlap()) == 0) {
    $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
  }
```
### **Ajout de la Valeur Enum ShapeThumbnailBounds.Appearance**
Cette méthode de création de vignettes de forme permet aux développeurs de générer une vignette de forme dans les limites de son apparence. Elle prend en compte tous les effets de forme. La vignette de forme générée est limitée par les dimensions de la diapositive.

```php
  $pres = new Presentation();
  $st = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail(ShapeThumbnailBounds->Appearance, 1, 1);

```
### **Ajout de la Classe VbaProject et de l'Interface IVbaProject, Changement des Méthodes Presentation.getVbaProject() et setVbaProject(VbaProject)**
Une nouvelle fonctionnalité permet aux développeurs de créer et d'éditer des projets VBA dans une présentation.

```php
  $pres = new Presentation();
  # Créer un nouveau projet VBA
  $pres->setVbaProject(new VbaProject());
  # Ajouter un module vide au projet VBA
  $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
  # Définir le code source du module
  $module->setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");
  # Créer une référence à <stdole>
  $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
  # Créer une référence à Office
  $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
  # Ajouter des références au projet VBA
  $pres->getVbaProject()->getReferences()->add($stdoleReference);
  $pres->getVbaProject()->getReferences()->add($officeReference);
  $pres->save("data\\test.pptm", SaveFormat::Pptm);

```