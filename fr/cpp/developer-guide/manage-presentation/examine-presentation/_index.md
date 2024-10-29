---
title: Examiner une Présentation - API PowerPoint C++
linktitle: Examiner une Présentation
type: docs
weight: 30
url: /fr/cpp/examine-presentation/
keywords:
- PowerPoint
- présentation
- format de présentation
- propriétés de présentation
- propriétés de document
- obtenir des propriétés
- lire des propriétés
- changer des propriétés
- modifier des propriétés
- PPTX
- PPT
- C++
description: "Lire et modifier les propriétés de présentation PowerPoint en C++"
---

Aspose.Slides pour C++ vous permet d'examiner une présentation pour découvrir ses propriétés et comprendre son comportement.

{{% alert title="Info" color="info" %}}

Les classes [PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) et [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) contiennent les propriétés et méthodes utilisées dans les opérations ici.

{{% /alert %}} 

## **Vérifier un Format de Présentation**

Avant de travailler sur une présentation, vous pourriez vouloir savoir dans quel format (PPT, PPTX, ODP, et autres) la présentation se trouve actuellement.

Vous pouvez vérifier le format d'une présentation sans charger la présentation. Voici ce code C++ :

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

## **Obtenir les Propriétés de Présentation**

Ce code C++ vous montre comment obtenir les propriétés de présentation (informations sur la présentation) :

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Mettre à Jour les Propriétés de Présentation**

Aspose.Slides fournit la méthode [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) qui vous permet d'apporter des modifications aux propriétés de présentation.

Disons que nous avons une présentation PowerPoint avec les propriétés de document montrées ci-dessous.

![Propriétés du document originales de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment modifier certaines propriétés de présentation :

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"Mon titre");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Les résultats des modifications des propriétés de document sont montrés ci-dessous.

![Propriétés de document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens Utiles**

Pour obtenir plus d'informations sur une présentation et ses attributs de sécurité, vous trouverez ces liens utiles :

- [Vérifier si une Présentation est Chiffrée](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une Présentation est Protégée en Écriture (lecture seule)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une Présentation est Protégée par Mot de Passe Avant de la Charger](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le Mot de Passe Utilisé pour Protéger une Présentation](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).