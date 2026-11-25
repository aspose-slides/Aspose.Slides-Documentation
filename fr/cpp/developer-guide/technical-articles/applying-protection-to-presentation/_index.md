---
title: Restreindre les modifications de présentation avec des verrous de forme en C++
linktitle: Restreindre les modifications de présentation
type: docs
weight: 10
url: /fr/cpp/applying-protection-to-presentation/
keywords:
- empêcher les modifications
- protéger contre la modification
- verrouiller la forme
- verrouiller la position
- verrouiller la sélection
- verrouiller le redimensionnement
- verrouiller le groupement
- PowerPoint
- PPTX
- présentation
- C++
- Aspose.Slides
description: "Apprenez comment verrouiller et déverrouiller les formes dans les présentations PPTX avec Aspose.Slides pour C++ afin de restreindre la sélection, le déplacement, le redimensionnement et le groupement."
---
## **Contexte**

Une utilisation courante d'Aspose.Slides for C++ consiste à créer, mettre à jour et enregistrer des présentations PowerPoint (PPTX) dans le cadre d'un flux de travail automatisé. Lorsque les utilisateurs reçoivent ces présentations, restreindre les modifications des formes peut aider à préserver la disposition et le contenu prévus.

Cet article explique comment les formes sont organisées sur les diapositives et comment appliquer et supprimer les verrous de forme dans une présentation PPTX. Ces verrous vous permettent de restreindre des opérations d’édition spécifiques sur des formes individuelles.

## **Composition d'une diapositive**

Une diapositive de présentation est composée d'éléments tels que des formes automatiques, des tableaux, des objets OLE, des formes groupées, des cadres d'image, des cadres vidéo, des connecteurs et d'autres éléments utilisés pour créer une présentation. Dans Aspose.Slides for C++, chaque élément d'une diapositive est représenté par un objet qui implémente l'interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) ou hérite d'une classe qui le fait.

Différents types de forme exposent différentes options de verrouillage. L'interface [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) est l'interface de base pour les verrous de forme. Aspose.Slides for C++ fournit les interfaces de verrouillage suivantes :

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) verrouille les formes automatiques.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) verrouille les formes de connecteur.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) verrouille les objets graphiques.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) verrouille les formes groupées.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) verrouille les cadres d'image.

Pour appliquer des verrous sur une [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), parcourez ses diapositives et définissez les verrous appropriés sur chaque forme prise en charge.

## **Appliquer et supprimer la protection**

Les éditeurs de présentations compatibles utilisent les verrous de forme pour restreindre les opérations d'édition individuelles. Le chiffrement des fichiers et la protection en écriture au niveau du document sont des [paramètres de protection de présentation](/slides/fr/cpp/password-protected-presentation/) distincts.

### **Appliquer la protection aux formes PPTX**

Aspose.Slides for C++ fournit l'interface [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) pour travailler avec les formes sur une diapositive.

L'exemple passe `true` à [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) et [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) pour les formes automatiques, avec des verrous équivalents pour les formes groupées, les connecteurs et les cadres d'image. Les connecteurs utilisent [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) pour le déplacement ; les groupes utilisent également [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) pour restreindre le regroupement.

L'exemple charge une présentation PPTX existante, examine les formes dans la collection de formes de chaque diapositive et enregistre une copie avec ces restrictions appliquées. Les formes qui ne font pas partie des quatre types gérés restent inchangées. La boucle ne parcourt pas les formes enfants à l'intérieur d'un groupe.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Supprimer la protection**

Pour supprimer un verrou de forme, définissez sa valeur sur `false`. L'exemple suivant charge une présentation avec des verrous de forme et supprime les restrictions de sélection, de déplacement et de redimensionnement via [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) et [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/). Il supprime également [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) et enregistre une copie de la présentation. Les autres paramètres de verrouillage restent inchangés.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Conserver un recadrage d'image**

Placez une photo nommée `photo.jpg` dans le répertoire de travail. L'exemple recadre de 12% à gauche et de 8% à droite, puis appelle [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) sur le verrou du cadre d'image pour conserver le recadrage et empêcher tout nouveau recadrage.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto photoBytes = File::ReadAllBytes(u"photo.jpg");
auto photo = presentation->get_Images()->AddImage(photoBytes);

auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, photo);
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_CropLeft(12);
pictureFormat->set_CropRight(8);

auto pictureFrameLock = pictureFrame->get_PictureFrameLock();
pictureFrameLock->set_AspectRatioLocked(false);
pictureFrameLock->set_CropLocked(true);

presentation->Save(u"PictureLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`PictureLocked.pptx` enregistre le verrou de recadrage comme `true`. Dans PowerPoint, la commande **Crop** est désactivée lorsque la photo est sélectionnée.

### **Conserver un diagramme groupé**

L'exemple groupe un rectangle et une flèche, puis appelle [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) sur le verrou du groupe pour maintenir les composants du diagramme ensemble. D'autres modifications, comme le déplacement du groupe ou le changement du remplissage d'un composant, restent possibles.

```cpp
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto groupShape = shapes->AddGroupShape();
auto groupShapes = groupShape->get_Shapes();
groupShapes->AddAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
groupShapes->AddAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
groupShape->get_GroupShapeLock()->set_UngroupingLocked(true);

presentation->Save(u"DiagramLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`DiagramLocked.pptx` enregistre le verrou de dégrouper comme `true`. Dans PowerPoint, la commande **Ungroup** est désactivée lorsque le diagramme complet est sélectionné.

### **Rapporter les verrous de forme existants**

Pour examiner un modèle, ouvrez‑le et lisez l'objet de verrouillage de chaque forme. [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) renvoie `true` lorsque tous les drapeaux de cet objet sont désactivés et `false` lorsqu'au moins un est activé. Un groupe et ses enfants possèdent des objets de verrouillage séparés, il faut donc inspecter les enfants même si le groupe n'a aucun verrou.

Cet exemple vérifie le déplacement pour les formes automatiques, les cadres d'image et les groupes, le recadrage pour les images, et le dégrouper pour les groupes. Il rapporte les drapeaux qu'il reconnaît et marque les types de forme qu'il n'inspecte pas.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/list.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <functional>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

std::function<void(SharedPtr<IShapeCollection>, int, String)> inspect;
inspect = [&inspect](SharedPtr<IShapeCollection> shapes, int slideNumber, String prefix)
{
    for (auto&& shape : IterateOver(shapes))
    {
        auto path = prefix + shape->get_Name();
        auto label = String::Format(u"Slide {0} | {1} | {2}", slideNumber, path, shape->GetType().get_Name());
        auto flags = MakeObject<List<String>>();
        auto group = AsCast<IGroupShape>(shape);

        if (group)
        {
            auto locks = group->get_GroupShapeLock();
            if (locks->get_UngroupingLocked()) flags->Add(u"UngroupingLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto picture = AsCast<IPictureFrame>(shape))
        {
            auto locks = picture->get_PictureFrameLock();
            if (locks->get_CropLocked()) flags->Add(u"CropLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto autoShape = AsCast<IAutoShape>(shape))
        {
            if (autoShape->get_AutoShapeLock()->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else
        {
            Console::WriteLine(label + u" | Uninspected");
            continue;
        }

        if (!shape->get_ShapeLock()->get_NoLocks())
        {
            auto restrictions = flags->get_Count() ? String::Join(u", ", flags->ToArray()) : String(u"Active flag not identified");
            Console::WriteLine(label + u" | " + restrictions);
        }

        if (group)
            inspect(group->get_Shapes(), slideNumber, path + u"/");
    }
};

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    inspect(slide->get_Shapes(), slide->get_SlideNumber(), u"");
}
presentation->Dispose();
```

Supposons que la diapositive 1 de `Sample.pptx` contienne un groupe nommé `Layout` avec le dégrouper verrouillé, une image nommée `Photo` à l'intérieur avec le recadrage verrouillé, et un rectangle déverrouillé nommé `Free`. Le rapport ignore `Free` et affiche ces deux lignes :

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Le rapport lit les drapeaux d'édition au niveau de la forme stockés sans les modifier ni enregistrer la présentation. La protection en écriture au niveau du document est un paramètre distinct, et l'application de chaque drapeau dépend de l'éditeur.

### **Conclusion**

Aspose.Slides for C++ vous permet de restreindre des opérations d'édition spécifiques sur des formes individuelles ou d'appliquer les mêmes restrictions sur plusieurs diapositives. Choisissez les verrous pris en charge par chaque type de forme, et définissez leurs valeurs sur `false` lorsque vous devez supprimer ces restrictions.

## **FAQ**

**Puis-je combiner les verrous de forme et la protection par mot de passe dans la même présentation ?**

Oui. Les verrous de forme restreignent des opérations d'édition spécifiques, tandis que la [protection par mot de passe](/slides/fr/cpp/password-protected-presentation/) peut restreindre l'ouverture ou la modification de la présentation. Vous pouvez les utiliser tous les deux dans le même fichier.

**Puis-je restreindre l'édition sur des diapositives spécifiques sans affecter les autres ?**

Oui. Appliquez les verrous uniquement aux formes des diapositives sélectionnées. Cela ne modifie pas les paramètres de verrouillage des autres diapositives.

**Comment puis‑je appliquer des verrous aux formes individuelles à l'intérieur d'un groupe ?**

Parcourez la collection renvoyée par la méthode [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) du groupe et appliquez les verrous appropriés à chaque forme enfant. Répétez l'opération pour les groupes imbriqués, en suivant le parcours de l'exemple de rapport.