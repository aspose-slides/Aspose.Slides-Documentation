---
title: VBA макрос
type: docs
weight: 150
url: /ru/cpp/examples/elements/vba-macro/
keywords:
- пример кода
- VBA
- макрос
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Автоматизируйте создание презентаций с помощью Aspose.Slides for C++: создавайте, запускайте, импортируйте и защищайте макросы VBA в PPT, PPTX и ODP, используя понятные примеры на C++."
---
В этой статье демонстрируется, как добавлять, получать доступ и удалять макросы VBA с помощью **Aspose.Slides for C++**.

## **Добавить макрос VBA**

Создайте презентацию с проектом VBA и простым модулем макроса.

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

## **Получить доступ к макросу VBA**

Получите первый модуль из проекта VBA.

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

## **Удалить макрос VBA**

Удалите модуль из проекта VBA.

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