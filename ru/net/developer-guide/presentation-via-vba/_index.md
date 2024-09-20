---
title: Презентация через VBA
type: docs
weight: 250
url: /net/presentation-via-vba/
keywords: "Макро, макросы, VBA, VBA макро, добавить макро, удалить макро, добавить VBA, удалить VBA, извлечь макро, извлечь VBA, макро PowerPoint, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавление, удаление и извлечение VBA макросов в презентациях PowerPoint на C# или .NET"
---

Пространство имен [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) содержит классы и интерфейсы для работы с макросами и кодом VBA.

{{% alert title="Примечание" color="warning" %}} 

Когда вы конвертируете презентацию, содержащую макросы, в другой формат файла (PDF, HTML и т. д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в результирующий файл).

Когда вы добавляете макросы в презентацию или сохраняете презентацию, содержащую макросы, Aspose.Slides просто записывает байты для макросов.

Aspose.Slides **никогда** не выполняет макросы в презентации.

{{% /alert %}}

## **Добавить VBA макросы**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/), который позволяет вам создавать VBA проекты (и ссылки на проект) и редактировать существующие модули. Вы можете использовать интерфейс [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) для управления VBA, встроенным в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) для добавления нового VBA проекта.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с VBA проектом.
1. Сохраните презентацию.

Этот код на C# показывает, как добавить VBA макрос с нуля в презентацию:

```c#
    // Создает экземпляр класса презентации
using (Presentation presentation = new Presentation())
{
    // Создает новый VBA проект
    presentation.VbaProject = new VbaProject();

    // Добавляет пустой модуль в VBA проект
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Модуль");
  
    // Устанавливает исходный код модуля
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Создает ссылку на <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Создает ссылку на Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Библиотека объектов Microsoft Office 14.0");

    // Добавляет ссылки в VBA проект
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Сохраняет презентацию
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Вы можете также ознакомиться с **Aspose** [Удалителем макросов](https://products.aspose.app/slides/remove-macros), который является бесплатным веб-приложением для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удалить VBA макросы**
С помощью свойства [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) в классе [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) вы можете удалить VBA макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю макроса и удалите его.
1. Сохраните измененную презентацию.

Этот код на C# показывает, как удалить VBA макрос:

```c#
    // Загружает презентацию, содержащую макрос
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Получает доступ к Vba модулю и удаляет его 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Сохраняет презентацию
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Извлечь VBA макросы**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Переберите все модули, содержащиеся в проекте VBA, чтобы просмотреть макросы.

Этот код на C# показывает, как извлечь VBA макросы из презентации, содержащей макросы:

```c#
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

## **Проверка, защищен ли проект VBA паролем**

Используя свойство [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), вы можете проверить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA проект](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/).
3. Проверьте, защищен ли проект VBA паролем для просмотра свойств проекта.

Этот код на C# демонстрирует операцию:

```c#
using (Presentation pres = new Presentation("VBA.pptm"))
{
    if (pres.VbaProject == null) // Проверяет, содержит ли презентация проект VBA
        return;

    if (pres.VbaProject.IsPasswordProtected)
    {
        Console.WriteLine("Проект VBA '" + pres.VbaProject.Name +
                            "' защищен паролем для просмотра свойств проекта.");
    }
}
```