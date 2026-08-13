---
title: Управление проектами VBA в презентациях на .NET
linktitle: Презентация через VBA
type: docs
weight: 250
url: /ru/net/presentation-via-vba/
keywords:
- макрос
- VBA
- макрос VBA
- добавить макрос
- удалить макрос
- извлечь макрос
- добавить VBA
- удалить VBA
- извлечь VBA
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и управлять презентациями PowerPoint и OpenDocument через VBA с помощью Aspose.Slides для .NET, чтобы оптимизировать ваш рабочий процесс."
---
## **Введение**

Пространство имён [Aspose.Slides.Vba](https://reference.aspose.com/slides/ru/net/aspose.slides.vba/) содержит классы и интерфейсы для работы с макросами и кодом VBA.

{{% alert title="Примечание" color="warning" %}} 

При конвертации презентации, содержащей макросы, в другой формат файла (PDF, HTML и т.п.), Aspose.Slides игнорирует все макросы (они не переносятся в полученный файл).

Когда вы добавляете макросы в презентацию или сохраняете повторно презентацию, содержащую макросы, Aspose.Slides просто записывает байты макросов.

Aspose.Slides **никогда** не выполняет макросы в презентации.

{{% /alert %}}

## **Добавление VBA‑макросов**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/ru/net/aspose.slides.vba/vbaproject/) , позволяющий создавать проекты VBA (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать интерфейс [IVbaProject](https://reference.aspose.com/slides/ru/net/aspose.slides.vba/ivbaproject/) для управления VBA, встроенным в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) class.
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/ru/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) для добавления нового проекта VBA.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с VBA project.
1. Сохраните презентацию.

This C# code shows you how to add a VBA macro from scratch to a presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// Создаёт экземпляр класса презентации
using (Presentation presentation = new Presentation())
{
    // Создаёт новый проект VBA
    presentation.VbaProject = new VbaProject();

    // Добавляет пустой модуль в проект VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // Устанавливает исходный код модуля
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Создаёт ссылку на <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Создаёт ссылку на Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Добавляет ссылки в проект VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // Сохраняет презентацию
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

Возможно, вам будет интересен **Aspose** [Macro Remover](https://products.aspose.app/slides/ru/remove-macros), бесплатное веб‑приложение для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удаление VBA‑макросов**
С помощью свойства [VbaProject](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/vbaproject/) класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) можно удалить VBA‑макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю Macro и удалите его.
1. Сохраните изменённую презентацию.

This C# code shows you how to remove a VBA macro:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Загружает презентацию, содержащую макрос
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Получает модуль Vba и удаляет его
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Сохраняет презентацию
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Извлечение VBA‑макросов**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Пройдитесь по всем модулям, содержащимся в проекте VBA, чтобы просмотреть макросы.

This C# code shows you how to extract VBA macros from a presentation containing macros:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // Загружает презентацию, содержащую макрос
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Проверяет, содержит ли презентация проект VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Проверка, защищён ли проект VBA паролем**

С помощью свойства [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/ru/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) можно определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA‑проект](https://reference.aspose.com/slides/ru/net/aspose.slides.vba/vbaproject/).
3. Убедитесь, что проект VBA защищён паролем, чтобы просмотреть его свойства.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Проверяет, содержит ли презентация проект VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

### Что происходит с макросами, если я сохраняю презентацию как PPTX?

Макросы будут удалены, потому что формат PPTX не поддерживает VBA. Чтобы сохранить макросы, выберите PPTM, PPSM или POTM.

### Может ли Aspose.Slides выполнять макросы внутри презентации, например, обновлять данные?

Нет. Библиотека никогда не исполняет код VBA; выполнение возможно только внутри PowerPoint при соответствующих настройках безопасности.

### Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?

Да, вы можете получить доступ к существующим [ActiveX controls](/slides/ru/net/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.