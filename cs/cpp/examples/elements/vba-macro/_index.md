---
title: VBA makro
type: docs
weight: 150
url: /cs/cpp/examples/elements/vba-macro/
keywords:
- příklad kódu
- VBA
- makro
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Automatizujte prezentace pomocí Aspose.Slides pro C++: vytvářejte, spouštějte, importujte a zabezpečujte VBA makra v PPT, PPTX a ODP pomocí srozumitelných příkladů v C++."
---
Tento článek ukazuje, jak pomocí **Aspose.Slides for C++** přidávat, přistupovat k a odstraňovat VBA makra.

## **Přidat makro VBA**

Vytvořte prezentaci s projektem VBA a jednoduchým modulem makra.

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

## **Přistupovat k makru VBA**

Získejte první modul z projektu VBA.

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

## **Odstranit makro VBA**

Smažte modul z projektu VBA.

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