---
title: "Récupérer et mettre à jour les informations de la présentation en C++"
linktitle: "Informations sur la présentation"
type: docs
weight: 30
url: /fr/cpp/examine-presentation/
keywords:
- "format de présentation"
- "propriétés de la présentation"
- "propriétés du document"
- "obtenir les propriétés"
- "lire les propriétés"
- "changer les propriétés"
- "modifier les propriétés"
- "mettre à jour les propriétés"
- "examiner PPTX"
- "examiner PPT"
- "examiner ODP"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "C++"
- "Aspose.Slides"
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument en C++ pour des analyses plus rapides et des audits de contenu plus intelligents."
---

Aspose.Slides for C++ vous permet d'examiner une présentation afin de découvrir ses propriétés et de comprendre son comportement. 

{{% alert title="Info" color="info" %}}

Les classes [PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) et [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) contiennent les propriétés et les méthodes utilisées dans les opérations présentées ici.

{{% /alert %}} 

## **Vérifier le format d'une présentation**

Avant de travailler sur une présentation, vous pouvez souhaiter savoir dans quel format (PPT, PPTX, ODP et autres) la présentation se trouve actuellement.

Vous pouvez vérifier le format d'une présentation sans la charger. Voir ce code C++ :
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```


## **Obtenir les propriétés de la présentation**

Ce code C++ vous montre comment obtenir les propriétés de la présentation (informations sur la présentation) :
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```


## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) qui vous permet d'apporter des modifications aux propriétés de la présentation.

Supposons que nous ayons une présentation PowerPoint avec les propriétés du document affichées ci-dessous.

![Propriétés du document d'origine de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment modifier certaines propriétés de la présentation :
```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```


Les résultats de la modification des propriétés du document sont affichés ci-dessous.

![Propriétés du document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir plus d'informations sur une présentation et ses attributs de sécurité, vous trouverez ces liens utiles :

- [Vérifier si une présentation est chiffrée](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une présentation est protégée en écriture (lecture seule)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une présentation est protégée par mot de passe avant de la charger](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le mot de passe utilisé pour protéger une présentation](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Comment puis-je vérifier si les polices sont incorporées et lesquelles le sont ?**

Recherchez les [informations sur les polices incorporées](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) au niveau de la présentation, puis comparez ces entrées avec l'ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/) afin d'identifier les polices critiques pour le rendu.

**Comment puis-je rapidement savoir si le fichier contient des diapositives masquées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) et inspectez le [drapeau de visibilité](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/) de chaque diapositive.

**Puis-je détecter si une taille et une orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Comparez la [taille et l'orientation actuelles des diapositives](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slidesize/) avec les préréglages standard ; cela permet d'anticiper le comportement lors de l'impression et de l'exportation.

**Existe-t-il un moyen rapide de savoir si les graphiques font référence à des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), examinez leur [source de données](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), et notez si les données sont internes ou basées sur un lien, y compris les liens brisés.

**Comment puis-je évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l'exportation PDF ?**

Pour chaque diapositive, comptez le nombre d'objets et recherchez les images volumineuses, la transparence, les ombres, les animations et les contenus multimédias ; attribuez un score de complexité approximatif afin de signaler les points chauds potentiels de performance.