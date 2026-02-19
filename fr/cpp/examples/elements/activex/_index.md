---
title: ActiveX
type: docs
weight: 200
url: /fr/cpp/examples/elements/activex/
keywords:
- exemple de code
- ActiveX
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Voir les exemples ActiveX d'Aspose.Slides pour C++ : insérer, configurer et contrôler des objets ActiveX dans les présentations PPT et PPTX avec du code C++ clair."
---
Cet article montre comment ajouter, accéder, supprimer et configurer des contrôles ActiveX dans une présentation en utilisant **Aspose.Slides for C++**.

## **Ajouter un contrôle ActiveX**

Insérez un nouveau contrôle ActiveX et, éventuellement, définissez ses propriétés.

```cpp
static void AddActiveX()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ajouter un nouveau contrôle ActiveX.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

    // Définir éventuellement certaines propriétés.
    control->get_Properties()->Add(u"Value", u"Default text");

    presentation->Save(u"add_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Accéder à un contrôle ActiveX**

Lisez les informations du premier contrôle ActiveX sur la diapositive.

```cpp
static void AccessActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Accéder au premier contrôle ActiveX.
        auto control = slide->get_Control(0);

        Console::WriteLine(u"Control Name: {0}", control->get_Name());
        Console::WriteLine(u"Value: {0}", control->get_Property(u"Value"));
    }

    presentation->Dispose();
}
```

## **Supprimer un contrôle ActiveX**

Supprimez un contrôle ActiveX existant de la diapositive.

```cpp
static void RemoveActiveX()
{
    auto presentation = MakeObject<Presentation>(u"add_activex.pptm");
    auto slide = presentation->get_Slide(0);

    if (slide->get_Controls()->get_Count() > 0)
    {
        // Supprimer le premier contrôle ActiveX.
        slide->get_Controls()->RemoveAt(0);
    }

    presentation->Save(u"removed_activex.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```

## **Définir les propriétés ActiveX**

Ajoutez un contrôle et configurez plusieurs propriétés ActiveX.

```cpp
static void SetActiveXProperties()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ajouter un contrôle Windows Media Player et configurer les propriétés.
    auto control = slide->get_Controls()->AddControl(ControlType::WindowsMediaPlayer, 50, 50, 150, 50);
    control->set_Property(u"Caption", u"Click Me");
    control->set_Property(u"Enabled", u"true");

    presentation->Save(u"set_activex_props.pptm", SaveFormat::Pptm);
    presentation->Dispose();
}
```