---
title: Gérer la forme SmartArt
type: docs
weight: 20
url: /fr/cpp/manage-smartart-shape/
---


## **Créer une forme SmartArt**
Aspose.Slides pour C++ facilite maintenant l'ajout de formes SmartArt personnalisées dans leurs diapositives depuis le début. Aspose.Slides pour C++ a fourni l'API la plus simple pour créer des formes SmartArt de la manière la plus facile. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Écrivez la présentation modifiée en tant que fichier PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **Accéder à la forme SmartArt dans la diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de présentation. Dans le code d'exemple, nous traverserons chaque forme à l'intérieur de la diapositive et vérifierons si c'est une forme SmartArt. Si la forme est de type SmartArt, nous la casterons en une instance SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Accéder à la forme SmartArt avec un type de mise en page particulier**
Le code d'échantillon suivant aidera à accéder à la forme SmartArt avec un LayoutType particulier. Veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lorsque la forme SmartArt est ajoutée.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Traversez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et casté la forme sélectionnée en SmartArt si c'est du SmartArt.
- Vérifiez la forme SmartArt avec un LayoutType particulier et effectuez ce qui est nécessaire par la suite.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **Changer le style de la forme SmartArt**
Le code d'exemple suivant aidera à accéder à la forme SmartArt avec un LayoutType particulier.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Traversez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et casté la forme sélectionnée en SmartArt si c'est du SmartArt.
- Trouvez la forme SmartArt avec un style particulier.
- Définissez le nouveau style pour la forme SmartArt.
- Enregistrez la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **Changer le style de couleur de la forme SmartArt**
Dans cet exemple, nous allons apprendre à changer le style de couleur pour n'importe quelle forme SmartArt. Dans le code d'exemple suivant, nous accéderons à la forme SmartArt avec un style de couleur particulier et changerons son style.

- Créez une instance de la classe `Presentation` et chargez la présentation avec la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Traversez chaque forme à l'intérieur de la première diapositive.
- Vérifiez si la forme est de type SmartArt et casté la forme sélectionnée en SmartArt si c'est du SmartArt.
- Trouvez la forme SmartArt avec un style de couleur particulier.
- Définissez le nouveau style de couleur pour la forme SmartArt.
- Enregistrez la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}