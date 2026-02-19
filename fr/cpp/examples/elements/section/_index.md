---
title: Section
type: docs
weight: 90
url: /fr/cpp/examples/elements/section/
keywords:
- exemple de code
- section
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Gérez les sections de diapositives dans Aspose.Slides for C++ : créez, renommez, réorganisez et regroupez les diapositives avec des exemples C++ pour PPT, PPTX et ODP."
---
Exemples de gestion des sections de présentation — ajouter, accéder, supprimer et renommer les sections de façon programmatique à l’aide de **Aspose.Slides for C++**.

## **Ajouter une section**

Créez une section qui commence à une diapositive spécifique.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Spécifiez la diapositive qui marque le début de la section.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Accéder à une section**

Lisez les informations de la section à partir d’une présentation.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Accédez à une section par index.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Supprimer une section**

Supprimez une section précédemment ajoutée.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Supprimez la première section.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Renommer une section**

Modifiez le nom d’une section existante.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```