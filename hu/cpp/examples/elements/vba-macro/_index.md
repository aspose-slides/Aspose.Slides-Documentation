---
title: VBA makró
type: docs
weight: 150
url: /hu/cpp/examples/elements/vba-macro/
keywords:
- kód példa
- VBA
- makró
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Automatizálja a prezentációkat az Aspose.Slides for C++ segítségével: hozzon létre, futtasson, importáljon és biztosítsa a VBA makrókat PPT, PPTX és ODP formátumokban világos C++ példák segítségével."
---
Ez a cikk bemutatja, hogyan lehet VBA makrókat hozzáadni, elérni és eltávolítani az **Aspose.Slides for C++** használatával.

## **VBA makró hozzáadása**

Készítsen egy prezentációt VBA projekttel és egy egyszerű makrómodullal.

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

## **VBA makró elérése**

Szerezze meg az első modult a VBA projektből.

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

## **VBA makró eltávolítása**

Törölje a modult a VBA projektből.

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