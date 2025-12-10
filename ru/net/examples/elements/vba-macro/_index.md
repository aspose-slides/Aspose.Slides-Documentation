---
title: VbaMacro
type: docs
weight: 150
url: /ru/net/examples/elements/vba-macro/
keywords:
- пример макроса vba
- добавить макрос vba
- получить доступ к макросу vba
- удалить макрос vba
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Работайте с макросами VBA в C# с помощью Aspose.Slides: добавляйте или редактируйте проекты и модули, подписывайте или удаляйте макросы, а также сохраняйте презентации в форматах PPT, PPTX и ODP."
---

Иллюстрирует, как добавлять, получать доступ и удалять макросы VBA с помощью **Aspose.Slides for .NET**.

## **Добавить макрос VBA**

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


## **Получить доступ к макросу VBA**

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


## **Удалить макрос VBA**

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
