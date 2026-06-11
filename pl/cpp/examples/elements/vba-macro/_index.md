---
title: Makro VBA
type: docs
weight: 150
url: /pl/cpp/examples/elements/vba-macro/
keywords:
- przykład kodu
- VBA
- makro
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Automatyzuj prezentacje za pomocą Aspose.Slides for C++: twórz, uruchamiaj, importuj i zabezpieczaj makra VBA w formatach PPT, PPTX i ODP, korzystając z przejrzystych przykładów C++."
---
Ten artykuł demonstruje, jak dodawać, uzyskiwać dostęp i usuwać makra VBA przy użyciu **Aspose.Slides for C++**.

## **Dodaj makro VBA**

Utwórz prezentację z projektem VBA i prostym modułem makr.

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

## **Uzyskaj dostęp do makra VBA**

Pobierz pierwszy moduł z projektu VBA.

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

## **Usuń makro VBA**

Usuń moduł z projektu VBA.

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