---
title: VBA‑макрос
type: docs
weight: 150
url: /ru/net/examples/elements/vba-macro/
keywords:
- VBA‑макрос
- добавить VBA‑макрос
- получить доступ к VBA‑макросу
- удалить VBA‑макрос
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Автоматизируйте создание презентаций с помощью Aspose.Slides for .NET: создавайте, запускайте, импортируйте и защищайте VBA‑макросы в форматах PPT, PPTX и ODP, используя понятные примеры на C#."
---
В этой статье показано, как добавлять, получать доступ и удалять VBA‑макросы с помощью **Aspose.Slides for .NET**.

## **Добавить VBA‑макрос**

Создайте презентацию с проектом VBA и простым модулем макроса.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Получить доступ к VBA‑макросу**

Получите первый модуль из проекта VBA.

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **Удалить VBA‑макрос**

Удалите модуль из проекта VBA.

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```