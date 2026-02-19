---
title: Macro VBA
type: docs
weight: 150
url: /fr/cpp/examples/elements/vba-macro/
keywords:
- exemple de code
- VBA
- macro
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Automatisez les présentations avec Aspose.Slides pour C++ : créez, exécutez, importez et sécurisez des macros VBA dans PPT, PPTX et ODP à l'aide d'exemples C++ clairs."
---
Cet article montre comment ajouter, accéder et supprimer des macros VBA à l'aide de **Aspose.Slides for C++**.

## **Ajouter une macro VBA**
Créez une présentation avec un projet VBA et un module de macro simple.

```cpp
static void AddVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->Dispose();
}
```

## **Accéder à une macro VBA**
Récupérez le premier module du projet VBA.

```cpp
static void AccessVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    auto firstModule = presentation->get_VbaProject()->get_Module(0);

    presentation->Dispose();
}
```

## **Supprimer une macro VBA**
Supprimez un module du projet VBA.

```cpp
static void RemoveVbaMacro()
{
    auto presentation = MakeObject<Presentation>();

    presentation->set_VbaProject(MakeObject<VbaProject>());

    auto module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");
    module->set_SourceCode(u"Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

    presentation->get_VbaProject()->get_Modules()->Remove(module);

    presentation->Dispose();
}
```