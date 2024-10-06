---
title: Propriétés Effectives des Formes
type: docs
weight: 50
url: /cpp/shape-effective-properties/
---


Dans ce sujet, nous allons discuter des propriétés **effectives** et **locales**. Lorsque nous définissons des valeurs directement à ces niveaux

1. Dans les propriétés de portion sur la diapositive de la portion.
1. Dans le style de texte de forme prototype sur la mise en page ou la diapositive maître (si la forme de cadre de texte de la portion en a une).
1. Dans les paramètres de texte globaux de la présentation.

ces valeurs sont appelées valeurs **locales**. À chaque niveau, les valeurs **locales** peuvent être définies ou omises. Mais finalement, lorsque l'application doit savoir à quoi la portion doit ressembler, elle utilise les valeurs **effectives**. Vous pouvez obtenir les valeurs effectives en utilisant la méthode **GetEffective()** à partir du format local.

L'exemple suivant montre comment obtenir des valeurs effectives.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}


## **Obtenir les Propriétés Effectives de la Caméra**
Aspose.Slides pour C++ permet aux développeurs d'obtenir les propriétés effectives de la caméra. À cette fin, la classe **CameraEffectiveData** a été ajoutée dans Aspose.Slides. La classe CameraEffectiveData représente un objet immuable contenant les propriétés effectives de la caméra. Une instance de la classe **CameraEffectiveData** est utilisée dans le cadre de la classe **ThreeDFormatEffectiveData** qui est une paire de valeurs effectives pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés effectives pour la caméra.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Obtenir les Propriétés Effectives de l'Éclairage**
Aspose.Slides pour C++ permet aux développeurs d'obtenir les propriétés effectives de l'Éclairage. À cette fin, la classe **LightRigEffectiveData** a été ajoutée dans Aspose.Slides. La classe LightRigEffectiveData représente un objet immuable contenant les propriétés effectives de l'éclairage. Une instance de la classe **LightRigEffectiveData** est utilisée dans le cadre de la classe **ThreeDFormatEffectiveData** qui est une paire de valeurs effectives pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés effectives pour l'Éclairage.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Obtenir les Propriétés Effectives de la Forme Biseautée**
Aspose.Slides pour C++ permet aux développeurs d'obtenir les propriétés effectives de la Forme Biseautée. À cette fin, la classe **ShapeBevelEffectiveData** a été ajoutée dans Aspose.Slides. La classe ShapeBevelEffectiveData représente un objet immuable contenant les propriétés de relief de la face de la forme. Une instance de la classe **ShapeBevelEffectiveData** est utilisée dans le cadre de la classe **ThreeDFormatEffectiveData** qui est une paire de valeurs effectives pour la classe ThreeDFormat.

L'exemple de code suivant montre comment obtenir les propriétés effectives pour la Forme Biseautée.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Obtenir les Propriétés Effectives du Cadre de Texte**
En utilisant Aspose.Slides pour C++, vous pouvez obtenir les propriétés effectives du Cadre de Texte. À cette fin, la classe **TextFrameFormatEffectiveData** a été ajoutée dans Aspose.Slides qui contient des propriétés de formatage effectives du cadre de texte.

L'exemple de code suivant montre comment obtenir les propriétés de formatage effectives du cadre de texte.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Obtenir les Propriétés Effectives du Style de Texte**
En utilisant Aspose.Slides pour C++, vous pouvez obtenir les propriétés effectives du Style de Texte. À cette fin, la classe **TextStyleEffectiveData** a été ajoutée dans Aspose.Slides qui contient des propriétés de style de texte effectives.

L'exemple de code suivant montre comment obtenir les propriétés effectives du style de texte.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Obtenir la Valeur Effective de la Hauteur de Police**
En utilisant Aspose.Slides pour C++, vous pouvez obtenir les propriétés effectives de la Hauteur de Police. Voici le code montrant la valeur effective de la hauteur de police de la portion changeant après avoir défini des valeurs de hauteur de police locales sur différents niveaux de structure de présentation.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Obtenir le Format de Remplissage Effectif pour le Tableau**
En utilisant Aspose.Slides pour C++, vous pouvez obtenir le format de remplissage effectif pour différentes parties logiques du tableau. À cette fin, l'interface **IFillFormatEffectiveData** a été ajoutée dans Aspose.Slides qui contient des propriétés de formatage de remplissage effectives. Veuillez noter que le formatage des cellules a toujours une priorité plus élevée que le formatage des lignes, une ligne a une priorité plus élevée qu'une colonne et une colonne a une priorité plus élevée que l'ensemble du tableau.

Ainsi, les propriétés de **CellFormatEffectiveData** sont toujours utilisées pour dessiner le tableau. L'exemple de code suivant montre comment obtenir le format de remplissage effectif pour différentes parties logiques du tableau.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}