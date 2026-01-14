---
title: Gérer les contrôles ActiveX dans les présentations avec PHP
linktitle: ActiveX
type: docs
weight: 80
url: /fr/php-java/activex/
keywords:
- ActiveX
- Contrôle ActiveX
- gérer ActiveX
- ajouter ActiveX
- modifier ActiveX
- lecteur multimédia
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour PHP via Java exploite ActiveX pour automatiser et améliorer les présentations PowerPoint, offrant aux développeurs un contrôle puissant sur les diapositives."
---

{{% alert color="primary" %}} 

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides pour PHP via Java vous permet d’ajouter et de gérer des contrôles ActiveX, mais ils sont un peu plus compliqués à gérer par rapport aux formes de présentation normales. Nous avons implémenté la prise en charge de l’ajout du contrôle actif Media Player dans Aspose.Slides. Notez que les contrôles ActiveX ne sont pas des formes ; ils ne font pas partie du [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/). Ils font partie du [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) distinct à la place. Dans ce sujet, nous vous montrerons comment travailler avec eux.

{{% /alert %}} 

## **Ajouter un contrôle ActiveX Media Player à une diapositive**
Pour ajouter un contrôle ActiveX Media Player, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et générez une instance de présentation vide.  
2. Accédez à la diapositive cible dans [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
3. Ajoutez le contrôle ActiveX Media Player à l’aide de la méthode [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/addcontrol/) exposée par [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/).  
4. Accédez au contrôle ActiveX Media Player et définissez le chemin vidéo à l’aide de ses propriétés.  
5. Enregistrez la présentation au format PPTX.  

Ce code d’exemple, basé sur les étapes ci‑dessus, montre comment ajouter le contrôle ActiveX Media Player à une diapositive :
```php
  # Créer une instance de présentation vide
  $pres = new Presentation();
  try {
    # Ajouter le contrôle ActiveX Media Player
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Accéder au contrôle ActiveX Media Player et définir le chemin vidéo
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Enregistrer la présentation
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Modifier un contrôle ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java 7.1.0 et les versions ultérieures sont dotés de composants pour gérer les contrôles ActiveX. Vous pouvez accéder au contrôle ActiveX déjà ajouté dans votre présentation et le modifier ou le supprimer via ses propriétés.

{{% /alert %}} 

Pour gérer un contrôle ActiveX simple tel qu’une zone de texte et un bouton de commande simple sur une diapositive, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) et chargez la présentation contenant des contrôles ActiveX.  
2. Obtenez une référence de diapositive par son indice.  
3. Accédez aux contrôles ActiveX de la diapositive en accédant au [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/).  
4. Accédez au contrôle ActiveX TextBox1 à l’aide de l’objet [Control](https://reference.aspose.com/slides/php-java/aspose.slides/control/).  
5. Modifiez les propriétés du contrôle ActiveX TextBox1 qui comprennent le texte, la police, la hauteur de police et la position du cadre.  
6. Accédez au deuxième contrôle d’accès appelé CommandButton1.  
7. Modifiez la légende du bouton, la police et la position.  
8. Déplacez la position des cadres des contrôles ActiveX.  
9. Écrivez la présentation modifiée dans un fichier PPTX.  

Ce code d’exemple, basé sur les étapes ci‑dessus, montre comment gérer un contrôle ActiveX simple :
```php
  # Accéder à la présentation avec les contrôles ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Accéder à la première diapositive de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # modifier le texte du TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Modifier l'image de substitution. PowerPoint remplacera cette image lors de l'activation ActiveX,
      # donc parfois il est acceptable de laisser l'image inchangée.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Modifier la légende du bouton
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Modifier la substitution
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # déplacer de 100 points vers le bas
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # supprimer les contrôles
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Aspose.Slides conserve‑t‑il les contrôles ActiveX lors de la lecture et de la réenregistrement s’ils ne peuvent pas être exécutés dans le runtime Java ?**  
Oui. Aspose.Slides les considère comme faisant partie de la présentation et peut lire/modifier leurs propriétés et leurs cadres ; il n’est pas nécessaire d’exécuter les contrôles eux‑mêmes pour les conserver.

**En quoi les contrôles ActiveX diffèrent‑ils des objets OLE dans une présentation ?**  
Les contrôles ActiveX sont des contrôles interactifs gérés (boutons, zones de texte, lecteur multimédia), tandis que [OLE](/slides/fr/php-java/manage-ole/) désigne des objets d’application intégrés (par exemple, une feuille de calcul Excel). Ils sont stockés et traités différemment et possèdent des modèles de propriétés distincts.

**Les événements ActiveX et les macros VBA fonctionnent‑ils si le fichier a été modifié par Aspose.Slides ?**  
Aspose.Slides préserve le balisage et les métadonnées existants ; cependant, les événements et les macros ne s’exécutent que dans PowerPoint sous Windows lorsque la sécurité le permet. La bibliothèque n’exécute pas le VBA.