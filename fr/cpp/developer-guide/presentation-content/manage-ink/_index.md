---  
title: Gérer l'encre  
type: docs  
weight: 95  
url: /fr/cpp/manage-ink/  
keywords: "Encre dans PowerPoint, outils d'encre, C++ Encre, Dessiner dans PowerPoint, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"  
description: "Utilisez des outils d'encre pour dessiner des objets dans PowerPoint C++"  
---  

PowerPoint fournit la fonction d'encre pour vous permettre de dessiner des figures non standard, qui peuvent être utilisées pour mettre en évidence d'autres objets, montrer des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive.

Aspose.Slides fournit l'interface [Aspose.Slides.Ink](https://reference.aspose.com/slides/cpp/aspose.slides.ink/), qui contient les types nécessaires pour créer et gérer des objets d'encre.

## **Différences entre objets réguliers et objets d'encre**

Les objets sur une diapositive PowerPoint sont généralement représentés par des objets de forme. Un objet de forme, dans sa forme la plus simple, est un conteneur qui définit la zone de l'objet lui-même (son cadre) ainsi que ses propriétés. Celles-ci incluent la taille de la zone du conteneur, la forme du conteneur, l'arrière-plan du conteneur, etc. Pour plus d'informations, voir [Format de mise en page de forme](https://docs.aspose.com/slides/cpp/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsque PowerPoint traite un objet d'encre, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les valeurs standards de `width` et `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traçages d'Inkshape**

Un tracé est un élément de base ou standard utilisé pour enregistrer la trajectoire d'un stylo tandis qu'un utilisateur écrit de l'encre numérique. Les tracés sont des enregistrements qui décrivent des séquences de points connectés.

La forme la plus simple d'encodage spécifie les coordonnées X et Y de chaque point d'échantillon. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle-ci :

![ink_powerpoint2](ink_powerpoint2.png)

## Propriétés de pinceau pour dessiner

Vous pouvez utiliser un pinceau pour dessiner des lignes reliant les points des éléments de tracé. Le pinceau a sa propre couleur et taille, correspondant aux propriétés `Brush.Color` et `Brush.Size`.

### **Définir la couleur du pinceau d'encre**

Ce code C++ vous montre comment définir la couleur d'un pinceau :

```c++  
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Définir la taille du pinceau d'encre**

Ce code C++ vous montre comment définir la taille d'un pinceau :

```c++  
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

En général, la largeur et la hauteur d'un pinceau ne correspondent pas, donc PowerPoint n'affiche pas la taille du pinceau (la section de données est grisée). Mais lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille de cette manière :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet d'encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne prend pas en compte la taille des pinceaux--il suppose toujours que l'épaisseur de la ligne est zéro (voir la dernière image).

Par conséquent, pour déterminer la zone visible de l'ensemble de l'objet d'encre, nous devons prendre en compte la taille du pinceau des objets de tracé. Ici, l'objet cible (l'objet de tracé de texte manuscrit) a été mis à l'échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur (cadre) change, la taille du pinceau reste constante et vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint présente le même comportement lorsqu'il s'agit de textes :

![ink_powerpoint6](ink_powerpoint6.png)

**Lectures complémentaires**

* Pour lire sur les formes en général, voir la section [Formes PowerPoint](https://docs.aspose.com/slides/cpp/powerpoint-shapes/).
* Pour plus d'informations sur les valeurs effectives, voir [Propriétés effectives de forme](https://docs.aspose.com/slides/cpp/shape-effective-properties/#get-effective-font-height-value).