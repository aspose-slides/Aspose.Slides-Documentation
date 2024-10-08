---
title: Gérer les listes à puces et numérotées
type: docs
weight: 70
url: /fr/python-net/manage-bullet-and-numbered-lists/
keywords: "Puces, Listes à puces, Nombres, Listes numérotées, Puces d'image, puces multilevel, Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Créer des listes à puces et numérotées dans une présentation PowerPoint en Python"
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même manière que dans Word et d'autres éditeurs de texte. **Aspose.Slides pour Python via .NET** vous permet également d'utiliser des puces et des chiffres dans les diapositives de vos présentations.

### Pourquoi utiliser des listes à puces ?

Les listes à puces vous aident à organiser et à présenter les informations rapidement et efficacement.

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l'attention de vos lecteurs ou spectateurs sur des informations importantes
- permet à vos lecteurs ou spectateurs de rechercher facilement les points clés
- communique et délivre des détails importants de manière efficace.

### Pourquoi utiliser des listes numérotées ?

Les listes numérotées aident également à organiser et à présenter des informations. Idéalement, vous devez utiliser des chiffres (à la place des puces) lorsque l'ordre des éléments (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu'un élément doit être référencé (par exemple, *voir étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) de la procédure **Création de puces** ci-dessous :

1. Créez une instance de la classe de présentation.
2. Effectuez plusieurs tâches (étapes 3 à 14).
3. Sauvegardez la présentation.

## Création de puces

Pour créer une liste à puces, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la diapositive (dans laquelle vous souhaitez ajouter une liste à puces) dans la collection de diapositives via l'objet [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) dans la diapositive sélectionnée.
4. Accédez au [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le [text_frame]().
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
8. Réglez le type de puce sur Symbole, puis définissez le caractère de puce.
9. Configurez le texte du paragraphe.
10. Réglez l'indentation du paragraphe pour définir la puce.
11. Définissez la couleur de la puce.
12. Définissez la hauteur de la puce.
13. Ajoutez le paragraphe créé dans la collection de paragraphes du [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
14. Ajoutez le deuxième paragraphe et répétez les étapes 7-12.
15. Sauvegardez la présentation.

Cet exemple de code en Python—une implémentation des étapes ci-dessus—vous montre comment créer une liste à puces dans une diapositive :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1
    paragraph.paragraph_format.bullet.color.color = draw.Color.red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "Mon texte"

    textFrame.paragraphs.add(paragraph)
    
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

 

## Création de puces d'image

Aspose.Slides pour Python via .NET vous permet de modifier les puces sur les listes à puces. Vous pouvez remplacer les puces par des symboles ou des images personnalisées. Si vous souhaitez ajouter un intérêt visuel à une liste ou attirer encore plus l’attention sur les éléments d'une liste, vous pouvez utiliser votre propre image comme puce.

 {{% alert color="primary" %}} 

Idéalement, si vous avez l'intention de remplacer le symbole de puce régulier par une image, vous voudrez sélectionner une image graphique simple avec un arrière-plan transparent. De telles images fonctionnent mieux comme symboles personnalisés de puce.

Dans tous les cas, l'image que vous choisissez sera réduite à une très petite taille, donc nous vous recommandons vivement de choisir une image qui rend bien (comme remplacement du symbole de puce) dans une liste.

{{% /alert %}} 

Pour créer une puce d'image, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la diapositive souhaitée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Ajoutez une [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) dans la diapositive sélectionnée.
4. Accédez au [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
7. Chargez l'image depuis le disque et ajoutez-la à [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) puis utilisez l'instance [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) qui a été renvoyée par la méthode [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/).
8. Réglez le type de puce sur Image, puis définissez l'image.
9. Configurez le texte du paragraphe.
10. Réglez l'indentation du paragraphe pour définir la puce.
11. Définissez la couleur de la puce.
12. Définissez la hauteur des puces.
13. Ajoutez le paragraphe créé dans la collection de paragraphes du [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
14. Ajoutez le deuxième paragraphe et répétez les étapes 7-13.
15. Sauvegardez la présentation.

Ce code Python vous montre comment créer une puce d'image dans une diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "Mon texte"

    textFrame.paragraphs.add(paragraph)
    
    pres.save("pres-bullets.pptx", slides.export.SaveFormat.PPTX)
```

 

## Création de puces multilevel

Pour créer une liste à puces contenant des éléments à différents niveaux—des listes supplémentaires sous la liste principale—suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la diapositive souhaitée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Ajoutez une [auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) dans la diapositive sélectionnée.
4. Accédez au [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) avec la profondeur fixée à 0.
7. Créez la deuxième instance de paragraphe en utilisant la classe Paragraph et la profondeur fixée à 1.
8. Créez la troisième instance de paragraphe en utilisant la classe Paragraph et la profondeur fixée à 2.
9. Créez la quatrième instance de paragraphe en utilisant la classe Paragraph et la profondeur fixée à 3.
10. Ajoutez les paragraphes créés dans la collection de paragraphes du [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
11. Sauvegardez la présentation.

Ce code, qui est une implémentation des étapes ci-dessus, vous montre comment créer une liste à puces multilevel en Python :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 300, 300)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.depth = 0
    paragraph.text = "Mon texte Profondeur 0"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 0
    paragraph2.text = "Mon texte Profondeur 1"
    textFrame.paragraphs.add(paragraph2)
    
    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "Mon texte Profondeur 2"
    textFrame.paragraphs.add(paragraph3)
    
    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "Mon texte Profondeur 3"
    textFrame.paragraphs.add(paragraph4)
    
    pres.save("pres-bullets2.pptx", slides.export.SaveFormat.PPTX)
```

 

## Création de numéros

Ce code Python vous montre comment créer une liste numérotée dans une diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.text = "Mon texte 1"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Mon texte 2"
    textFrame.paragraphs.add(paragraph2)
    
    pres.save("pres-bullets3.pptx", slides.export.SaveFormat.PPTX)
```