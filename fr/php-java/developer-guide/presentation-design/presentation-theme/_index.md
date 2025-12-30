---
title: Gestion des thèmes de présentation en PHP
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/php-java/presentation-theme/
keywords:
- Thème PowerPoint
- Thème de présentation
- Thème de diapositive
- Définir le thème
- Modifier le thème
- Gérer le thème
- Couleur du thème
- Palette supplémentaire
- Police du thème
- Style du thème
- Effet du thème
- PowerPoint
- OpenDocument
- Présentation
- PHP
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour PHP via Java afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité de marque cohérente."
---

Un thème de présentation définit les propriétés des éléments de conception. Lorsque vous sélectionnez un thème de présentation, vous choisissez essentiellement un ensemble spécifique d'éléments visuels et leurs propriétés.

Dans PowerPoint, un thème comprend des couleurs, [polices](/slides/fr/php-java/powerpoint-fonts/), [styles d’arrière‑plan](/slides/fr/php-java/presentation-background/), et des effets.

![theme-constituents](theme-constituents.png)

## **Modifier la couleur du thème**

Un thème PowerPoint utilise un ensemble de couleurs spécifiques pour différents éléments d’une diapositive. Si vous n’aimez pas les couleurs, vous les modifiez en appliquant de nouvelles couleurs au thème. Pour vous permettre de sélectionner une nouvelle couleur de thème, Aspose.Slides fournit des valeurs dans l’énumération [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor).

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Vous pouvez déterminer la valeur effective de la couleur résultante de cette manière :

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```


Pour illustrer davantage l’opération de changement de couleur, nous créons un autre élément et lui attribuons la couleur d’accent (provenant de l’opération initiale). Puis nous modifions la couleur dans le thème :

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```


La nouvelle couleur est appliquée automatiquement aux deux éléments.

### **Définir la couleur du thème à partir d’une palette supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur principale du thème(1), des couleurs de la palette supplémentaire(2) sont générées. Vous pouvez alors définir et récupérer ces couleurs de thème.

![additional-palette-colors](additional-palette-colors.png)

**1** - Couleurs principales du thème  

**2** - Couleurs de la palette supplémentaire.

Ce code PHP montre une opération où les couleurs de la palette supplémentaire sont obtenues à partir de la couleur principale du thème, puis utilisées dans les formes :

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Accent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Accent 4, Plus clair 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Accent 4, Plus clair 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Accent 4, Plus clair 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Accent 4, Plus sombre 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Accent 4, Plus sombre 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Modifier la police du thème**

Pour vous permettre de sélectionner des polices pour les thèmes et d’autres usages, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux utilisés dans PowerPoint) :

* **+mn-lt** - Police du corps Latin (Police Latin mineure)
* **+mj-lt** - Police du titre Latin (Police Latin majeure)
* **+mn-ea** - Police du corps Asiatique de l'Est (Police Asiatique de l'Est mineure)
* **+mj-ea** - Police du corps Asiatique de l'Est (Police Asiatique de l'Est majeure)

Ce code PHP montre comment attribuer la police Latin à un élément du thème :

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```


Ce code PHP montre comment modifier la police du thème de la présentation :

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```


La police de toutes les zones de texte sera mise à jour.

{{% alert color="primary" title="TIP" %}} 
Vous voudrez peut-être consulter [polices PowerPoint](/slides/fr/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Modifier le style d’arrière‑plan du thème**

Par défaut, l’application PowerPoint propose 12 arrière‑plans prédéfinis, mais seules 3 de ces 12 arrière‑plans sont enregistrés dans une présentation typique. 

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans l’application PowerPoint, vous pouvez exécuter ce code PHP pour connaître le nombre d’arrière‑plans prédéfinis dans la présentation :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" %}} 
En utilisant la propriété [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) de la classe [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme), vous pouvez ajouter ou accéder au style d’arrière‑plan dans un thème PowerPoint.
{{% /alert %}} 

Ce code PHP montre comment définir l’arrière‑plan d’une présentation :

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```


**Guide d’index** : 0 correspond à « aucun remplissage ». L’index commence à 1.

{{% alert color="primary" title="TIP" %}} 
Vous voudrez peut-être consulter [Arrière‑plan PowerPoint](/slides/fr/php-java/presentation-background/).
{{% /alert %}}

## **Modifier l’effet du thème**

Un thème PowerPoint contient généralement 3 valeurs pour chaque tableau de styles. Ces tableaux sont combinés en ces 3 effets : subtil, modéré et intense. Par exemple, voici le résultat lorsque les effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant les 3 propriétés ([FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)) de la classe [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme), vous pouvez modifier les éléments d’un thème (de façon encore plus flexible que les options de PowerPoint).

Ce code PHP montre comment changer un effet de thème en modifiant des parties d’éléments :

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Les changements résultants dans la couleur de remplissage, le type de remplissage, l’effet d’ombre, etc. :

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Puis‑je appliquer un thème à une seule diapositive sans modifier le masque ?**

Oui. Aspose.Slides prend en charge les substitutions de thème au niveau de la diapositive, vous permettant d’appliquer un thème local uniquement à cette diapositive tout en conservant le thème du masque inchangé (via le [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/)).

**Quel est le moyen le plus sûr de transférer un thème d’une présentation à une autre ?**

[Cloner les diapositives](/slides/fr/php-java/clone-slides/) avec leur masque dans la présentation cible. Cela préserve le masque original, les mises en page et le thème associé afin que l’apparence reste cohérente.

**Comment puis‑je voir les valeurs « effectives » après toutes les héritages et surcharges ?**

Utilisez les « vues effectives » de l’API [/slides/php-java/shape-effective-properties/] pour le thème/couleur/police/effet. Elles renvoient les propriétés résolues et définitives après l’application du masque ainsi que les éventuelles surcharges locales.