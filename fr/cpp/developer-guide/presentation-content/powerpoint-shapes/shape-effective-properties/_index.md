---
title: Obtenir les propriétés effectives des formes à partir des présentations en C++
linktitle: Propriétés effectives
type: docs
weight: 50
url: /fr/cpp/shape-effective-properties/
keywords:
- propriétés de forme
- propriétés de la caméra
- rig d'éclairage
- forme biseautée
- cadre de texte
- style de texte
- hauteur de police
- format de remplissage
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour C++ calcule et applique les propriétés effectives des formes pour un rendu précis de PowerPoint."
---

Dans ce sujet, nous aborderons les propriétés **effectives** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion.
1. Dans le style de texte de forme prototype sur la diapositive de mise en page ou maître (si la forme de cadre de texte de la portion en possède une).
1. Dans les paramètres de texte globaux de la présentation.

alors ces valeurs sont appelées valeurs **locales**. À chaque niveau, les valeurs **locales** peuvent être définies ou omises. Mais finalement, quand l'application doit savoir à quoi doit ressembler la portion, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **GetEffective()** du format local.

L'exemple suivant montre comment obtenir les valeurs effectives.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}


## **Obtenir les propriétés effectives d'une caméra**
Aspose.Slides for C++ permet aux développeurs d'obtenir les propriétés effectives de la caméra. À cet effet, la classe **CameraEffectiveData** a été ajoutée à Aspose.Slides. La classe CameraEffectiveData représente un objet immuable qui contient les propriétés effectives de la caméra. Une instance de la classe **CameraEffectiveData** est utilisée dans le cadre de la classe **ThreeDFormatEffectiveData**, qui constitue une paire de valeurs effectives pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés effectives pour la caméra.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Obtenir les propriétés effectives d'un Light Rig**
Aspose.Slides for C++ permet aux développeurs d'obtenir les propriétés effectives d'un Light Rig. À cet effet, la classe **LightRigEffectiveData** a été ajoutée à Aspose.Slides. La classe LightRigEffectiveData représente un objet immuable qui contient les propriétés effectives du Light Rig. Une instance de la classe **LightRigEffectiveData** est utilisée dans le cadre de la classe **ThreeDFormatEffectiveData**, qui constitue une paire de valeurs effectives pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés effectives pour le Light Rig.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Obtenir les propriétés effectives d'une forme biseautée**
Aspose.Slides for C++ permet aux développeurs d'obtenir les propriétés effectives d'une forme biseautée. À cet effet, la classe **ShapeBevelEffectiveData** a été ajoutée à Aspose.Slides. La classe ShapeBevelEffectiveData représente un objet immuable qui contient les propriétés de relief de face de la forme. Une instance de la classe **ShapeBevelEffectiveData** est utilisée dans le cadre de la classe **ThreeDFormatEffectiveData**, qui constitue une paire de valeurs effectives pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés effectives pour la forme biseautée.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Obtenir les propriétés effectives d'un cadre de texte**
Aspose.Slides for C++ vous permet d'obtenir les propriétés effectives d'un cadre de texte. À cet effet, la classe **TextFrameFormatEffectiveData** a été ajoutée à Aspose.Slides et contient les propriétés de formatage effectif du cadre de texte.

L'exemple de code suivant montre comment obtenir les propriétés de formatage effectif du cadre de texte.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Obtenir les propriétés effectives d'un style de texte**
Aspose.Slides for C++ vous permet d'obtenir les propriétés effectives d'un style de texte. À cet effet, la classe **TextStyleEffectiveData** a été ajoutée à Aspose.Slides et contient les propriétés effectives du style de texte.

L'exemple de code suivant montre comment obtenir les propriétés effectives du style de texte.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Obtenir la valeur effective de la hauteur de police**
Aspose.Slides for C++ vous permet d'obtenir les propriétés effectives de la hauteur de police. Voici le code illustrant la modification de la valeur effective de la hauteur de police d'une portion après avoir défini des valeurs locales de hauteur de police à différents niveaux de la structure de la présentation.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Obtenir le format de remplissage effectif d'un tableau**
Aspose.Slides for C++ vous permet d'obtenir le format de remplissage effectif pour différentes parties logiques d'un tableau. À cet effet, l'interface **IFillFormatEffectiveData** a été ajoutée à Aspose.Slides et contient les propriétés de remplissage effectif. Veuillez noter que le format de cellule a toujours une priorité supérieure à celui de ligne, une ligne a une priorité supérieure à celle de colonne et la colonne a une priorité supérieure à celle du tableau entier.

Ainsi, les propriétés **CellFormatEffectiveData** sont finalement toujours utilisées pour dessiner le tableau. L'exemple de code suivant montre comment obtenir le format de remplissage effectif pour différentes parties logiques d'un tableau.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}

## **FAQ**

**Comment savoir si j'ai obtenu un "instantané" plutôt qu'un "objet vivant", et quand dois-je relire les propriétés effectives ?**  
Les objets EffectiveData sont des instantanés immuables des valeurs calculées au moment de l'appel. Si vous modifiez les paramètres locaux ou hérités de la forme, récupérez à nouveau les données effectives pour obtenir les valeurs mises à jour.

**Le fait de modifier la diapositive de mise en page/maître affecte-t-il les propriétés effectives déjà récupérées ?**  
Oui, mais uniquement après les avoir relues. Un objet EffectiveData déjà obtenu ne se met pas à jour automatiquement ; il faut le demander de nouveau après avoir modifié la mise en page ou le maître.

**Puis-je modifier des valeurs via EffectiveData ?**  
Non. EffectiveData est en lecture seule. Effectuez les changements dans les objets de formatage locaux (forme/texte/3D, etc.), puis récupérez à nouveau les valeurs effectives.

**Que se passe-t-il si une propriété n'est pas définie au niveau de la forme, ni dans la mise en page/maître, ni dans les paramètres globaux ?**  
La valeur effective est déterminée par le mécanisme par défaut (valeurs par défaut de PowerPoint/Aspose.Slides). Cette valeur résolue fait partie de l'instantané EffectiveData.

**À partir d'une valeur de police effective, puis-je déterminer quel niveau a fourni la taille ou la police de caractères ?**  
Pas directement. EffectiveData renvoie la valeur finale. Pour en trouver la source, examinez les valeurs locales au niveau de la portion/paragraphes/cadre de texte et les styles de texte au niveau de la mise en page/maître/präsentation pour voir où la première définition explicite apparaît.

**Pourquoi les valeurs EffectiveData ressemblent parfois identiquement aux valeurs locales ?**  
Parce que la valeur locale s'est avérée être la valeur finale (aucune héritage de niveau supérieur n'a été nécessaire). Dans ce cas, la valeur effective correspond à la valeur locale.

**Quand devrais-je utiliser les propriétés effectives, et quand devrais-je travailler uniquement avec les locales ?**  
Utilisez EffectiveData lorsque vous avez besoin du résultat « tel qu'affiché » après l'application de tous les héritages (par ex., pour aligner les couleurs, les retraits ou les tailles). Si vous devez modifier le formatage à un niveau spécifique, modifiez les propriétés locales puis, si nécessaire, relisez EffectiveData pour vérifier le résultat.