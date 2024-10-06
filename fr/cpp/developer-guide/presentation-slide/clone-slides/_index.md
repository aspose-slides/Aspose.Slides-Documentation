---
title: Cloner des diapositives
type: docs
weight: 40
url: /cpp/clone-slides/
---


## **Cloner une Diapositive dans une Présentation**
Le clonage est le processus de création d'une copie exacte ou d'une réplique de quelque chose. Aspose.Slides pour C++ permet également de créer une copie ou un clone de n'importe quelle diapositive et de l'insérer ensuite dans la présentation actuelle ou toute autre présentation ouverte. Le processus de clonage de diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer la diapositive d'origine. Il existe plusieurs façons possibles de cloner une diapositive :

- Cloner à la fin d'une présentation.
- Cloner à une autre position dans la présentation.
- Cloner à la fin d'une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides pour C++, (une collection d'objets [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)) exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) fournit les méthodes [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) et [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) pour effectuer les types de clonage de diapositives ci-dessus.

## **Cloner à la Fin dans la Présentation**
Si vous souhaitez cloner une diapositive et ensuite l'utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) selon les étapes listées ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en référencant la collection de diapositives exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive à cloner en tant que paramètre à la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. Écrivez le fichier de présentation modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (située à la première position – zéro index – de la présentation) à la fin de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}


## **Cloner à une Autre Position dans la Présentation**
Si vous souhaitez cloner une diapositive et l'utiliser ensuite dans le même fichier de présentation mais à une position différente, utilisez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Instanciez la classe en référencant la collection **Slides** exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive à cloner ainsi que l'index pour la nouvelle position en tant que paramètre à la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index).
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (située à l'index zéro – position 1 – de la présentation) à l'index 1 – Position 2 – de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **Cloner une Diapositive à la Fin d'une Autre Présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en référencant la collection **Slides** exposée par l'objet de présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive de la présentation source en tant que paramètre à la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (de l'index premier de la présentation source) à la fin de la présentation de destination.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **Cloner une Diapositive à une Autre Position dans une Autre Présentation**
Si vous devez cloner une diapositive d'une présentation et l'utiliser dans un autre fichier de présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en référencant la collection Slides exposée par l'objet de présentation de destination.
1. Appelez la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive de la présentation source ainsi que la position désirée comme paramètre à la méthode [InsertClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/insertclone/index).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive (de l'index zéro de la présentation source) à l'index 1 (position 2) de la présentation de destination.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}
## **Cloner une Diapositive à une Position Spécifique dans une Autre Présentation**
Si vous avez besoin de cloner une diapositive avec un maître diapositive d'une présentation et de l'utiliser dans une autre présentation, vous devez d'abord cloner le maître diapositive souhaité de la présentation source vers la présentation de destination. Ensuite, vous devez utiliser ce maître diapositive pour cloner la diapositive avec le maître diapositive. La **AddClone(ISlide, IMasterSlide)** attend le maître diapositive de la présentation de destination plutôt que de la présentation source. Pour cloner la diapositive avec le maître, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) contenant la présentation de destination dans laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu'au maître diapositive.
1. Instanciez la classe [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) en référencant la collection de maîtres exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) exposée par l'objet [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterslidecollection) et passez le maître de la source PPTX à cloner comme paramètre à la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) en établissant la référence à la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) de la présentation de destination.
1. Appelez la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index) exposée par l'objet [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) et passez la diapositive de la présentation source à cloner et le maître diapositive comme paramètre à la méthode [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/index).
1. Écrivez le fichier de présentation de destination modifié.

Dans l'exemple donné ci-dessous, nous avons cloné une diapositive avec maître (située à l'index zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}
## **Cloner une Diapositive à une Section Spécifiée**
Si vous souhaitez cloner une diapositive et ensuite l'utiliser dans le même fichier de présentation mais à une section différente, utilisez la méthode [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a46981dac8b18355531a04a70c70c444b) exposée par l'interface [**ISlideCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection). Aspose.Slides pour C++ permet de cloner une diapositive de la première section et d'insérer ensuite cette diapositive clonée dans la deuxième section de la même présentation.

Le snippet de code suivant vous montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}