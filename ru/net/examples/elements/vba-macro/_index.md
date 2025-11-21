---
title: VbaMacro
type: docs
weight: 150
url: /ru/net/examples/elements/vba-macro/
keywords:
- пример макроса vba
- добавить макрос vba
- доступ к макросу vba
- удалить макрос vba
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работа с макросами VBA в C# с использованием Aspose.Slides: добавление или изменение проектов и модулей, подпись или удаление макросов, а также сохранение презентаций в форматах PPT, PPTX и ODP."
---

Показывает, как добавлять, получать доступ и удалять макросы VBA с помощью **Aspose.Slides for .NET**.

## Добавление макроса VBA

Создайте презентацию с проектом VBA и простым модулем макроса.
```csharp
static void Add_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```


## Доступ к макросу VBA

Получите первый модуль из проекта VBA.
```csharp
static void Access_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = pres.VbaProject.Modules[0];
}
```


## Удаление макроса VBA

Удалите модуль из проекта VBA.
```csharp
static void Remove_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    pres.VbaProject.Modules.Remove(module);
}
```
