---
title: Gérer les objets d'encre de présentation en C++
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/cpp/manage-ink/
keywords:
  - encre
  - objet d'encre
  - trace d'encre
  - gérer l'encre
  - dessiner l'encre
  - dessin
  - PowerPoint
  - présentation
  - C++
  - Aspose.Slides
description: "Gérez les objets d'encre PowerPoint — créez, modifiez et stylisez l'encre numérique avec Aspose.Slides pour C++. Obtenez des exemples de code pour les traces, la couleur et la taille du pinceau."
---

PowerPoint offre la fonction d'encre pour vous permettre de dessiner des formes non standard, qui peuvent être utilisées pour mettre en évidence d'autres objets, montrer des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive. 

Aspose.Slides fournit l'interface [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/), qui contient les types nécessaires pour créer et gérer les objets d'encre. 

## **Différences entre les objets réguliers et les objets d'encre**

Les objets sur une diapositive PowerPoint sont généralement représentés par des objets forme. Un objet forme, dans sa forme la plus simple, est un conteneur qui définit la zone de l'objet lui‑même (son cadre) ainsi que ses propriétés. Ces dernières incluent la taille de la zone du conteneur, la forme du conteneur, l'arrière‑plan du conteneur, etc. Pour plus d'informations, consultez [Shape Layout Format](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsqu PowerPoint traite un objet d'encre, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les valeurs standard `width` et `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d'Inkshape**

Une trace est un élément de base ou une norme utilisée pour enregistrer la trajectoire d'un stylet lorsqu'un utilisateur écrit de l'encre numérique. Les traces sont des enregistrements qui décrivent des séquences de points connectés. 

La forme d'encodage la plus simple spécifie les coordonnées X et Y de chaque point d'échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Vous pouvez utiliser un pinceau pour tracer des lignes reliant les points des éléments de trace. Le pinceau possède sa propre couleur et taille, correspondant aux propriétés `Brush.Color` et `Brush.Size`. 

### **Définir la couleur du pinceau d'encre**

Ce code C++ montre comment définir la couleur d'un pinceau :
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```


### **Définir la taille du pinceau d'encre** 

Ce code C++ montre comment définir la taille d'un pinceau :
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```


En général, la largeur et la hauteur d'un pinceau ne correspondent pas, donc PowerPoint n'affiche pas la taille du pinceau (la section des données est grisée). Mais lorsque la largeur et la hauteur du pinceau sont identiques, PowerPoint affiche sa taille de cette façon :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet d'encre et examinons les dimensions importantes : 

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne tient pas compte de la taille des pinceaux – il suppose toujours que l'épaisseur de la ligne est nulle (voir la dernière image). 

Par conséquent, pour déterminer la zone visible de l'ensemble de l'objet d'encre, nous devons prendre en compte la taille du pinceau des objets trace. Ici, l'objet cible (l'objet trace du texte manuscrit) a été mis à l'échelle selon la taille du conteneur (cadre). Lorsque la taille du conteneur (cadre) change, la taille du pinceau reste constante et inversement. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint présente le même comportement lorsqu'il traite des textes :

![ink_powerpoint6](ink_powerpoint6.png)

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](https://docs.aspose.com/slides/cpp/powerpoint-shapes/). 
* Pour plus d'informations sur les valeurs effectives, consultez [Shape Effective Properties](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).