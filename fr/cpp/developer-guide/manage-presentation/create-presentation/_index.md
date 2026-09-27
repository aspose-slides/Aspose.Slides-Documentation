---
title: Créer des présentations en C++
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/cpp/create-presentation/
keywords:
- créer une présentation
- nouvelle présentation
- créer PPT
- nouveau PPT
- créer PPTX
- nouveau PPTX
- créer ODP
- nouveau ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Créer des présentations en C++ avec Aspose.Slides — produire des fichiers PPT, PPTX et ODP, profiter du support OpenDocument et les enregistrer programmatiquement pour des résultats fiables."
---
## **Aperçu**

Cet article montre comment créer une présentation dans Aspose.Slides, ajouter une zone de texte à sa première diapositive et enregistrer le résultat dans un fichier. Une courte FAQ à la fin couvre les questions courantes sur les formats, les modèles, la taille des diapositives, les unités, l'utilisation de la mémoire, le multithreading, la licence, les signatures numériques et la prise en charge de VBA.

Avant de commencer, ajoutez Aspose.Slides à votre projet : depuis NuGet dans un projet Visual Studio sous Windows, ou à partir du package ZIP avec CMake sous Linux. Voir [Installation](/slides/fr/cpp/installation/).

## **Créer une présentation PowerPoint**

Pour créer une présentation et placer une zone de texte sur sa première diapositive, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Une nouvelle présentation contient déjà une diapositive vide.
1. Récupérez cette diapositive avec la méthode [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) et son indice, 0.
1. Ajoutez un rectangle avec la méthode [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/), et définissez son texte avec la méthode [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/).
1. Enregistrez la présentation au format PPTX avec la méthode [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Le coin supérieur gauche du rectangle se trouve à 50 points du bord gauche et à 50 points du bord supérieur de la diapositive, et le rectangle a une largeur de 400 points et une hauteur de 100 points. Le programme enregistre *hello.pptx* dans son répertoire de travail, avec une diapositive contenant le rectangle et son texte. Sans licence, Aspose.Slides ajoute également un filigrane d'évaluation à chaque diapositive enregistrée ; voir [Licensing](/slides/fr/cpp/licensing/).

## **FAQ**

### Dans quels formats puis-je enregistrer une nouvelle présentation ?

Vous pouvez enregistrer au format [PPTX, PPT et ODP](/slides/fr/cpp/save-presentation/), et exporter vers [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/fr/cpp/convert-powerpoint-to-xps/), [HTML](/slides/fr/cpp/convert-powerpoint-to-html/), [SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/), et [images](/slides/fr/cpp/convert-powerpoint-to-png/), entre autres.

### Puis-je démarrer à partir d'un modèle (POTX/POTM) et enregistrer en PPTX standard ?

Oui. Chargez le modèle et enregistrez-le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/cpp/supported-file-formats/).

### Comment contrôler la taille/ratio d'aspect d'une diapositive lors de la création d'une présentation ?

Définissez la [taille de la diapositive](/slides/fr/cpp/slide-size/) (y compris les préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l'échelle.

### En quelles unités les tailles et coordonnées sont-elles mesurées ?

En points : 1 pouce équivaut à 72 unités.

### Comment gérer de très grandes présentations (avec de nombreux fichiers multimédias) afin de réduire l'utilisation de la mémoire ?

Utilisez les [stratégies de gestion des BLOB](/slides/fr/cpp/manage-blob/), limitez le stockage en mémoire en exploitant des fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que les flux purement en mémoire.

### Puis-je créer/enregistrer des présentations en parallèle ?

Vous ne pouvez pas manipuler la même instance de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) depuis [multiple threads](/slides/fr/cpp/multithreading/). Exécutez des instances séparées et isolées par thread ou processus.

### Comment supprimer le filigrane d'évaluation et les limitations ?

[Appliquez une licence](/slides/fr/cpp/licensing/) une fois par processus. Le XML de licence doit rester intact, et la configuration de la licence doit être synchronisée si plusieurs threads sont impliqués.

### Puis-je signer numériquement le PPTX que je crée ?

Oui. Les [signatures numériques](/slides/fr/cpp/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

### Les macros (VBA) sont-elles prises en charge dans les présentations créées ?

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/cpp/presentation-via-vba/) et enregistrer des fichiers avec macro tels que PPTM/PPSM.