---
title: Презентация с использованием VBA
type: docs
weight: 250
url: /ru/net/presentation-via-vba/
keywords: "Макрос, макросы, VBA, VBA макрос, добавить макрос, удалить макрос, добавить VBA, удалить VBA, извлечь макрос, извлечь VBA, PowerPoint макрос, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавление, удаление и извлечение VBA‑макросов в презентациях PowerPoint на C# или .NET"
---

Пространство имён [Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) содержит классы и интерфейсы для работы с макросами и кодом VBA.

{{% alert title="Note" color="warning" %}} 

При конвертации презентации, содержащей макросы, в другой формат файла (PDF, HTML и т.п.) Aspose.Slides игнорирует все макросы (они не переносятся в полученный файл).

При добавлении макросов в презентацию или повторном сохранении презентации, содержащей макросы, Aspose.Slides просто записывает байты макросов.

Aspose.Slides **никогда** не выполняет макросы в презентации.

{{% /alert %}}

## **Добавление VBA‑макросов**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) для создания проектов VBA (и их ссылок) и редактирования существующих модулей. Для управления встроенным в презентацию VBA используется интерфейс [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) для добавления нового проекта VBA.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с проектом VBA.
1. Сохраните презентацию.

Этот код на C# показывает, как добавить VBA‑макрос с нуля в презентацию:
```c#
    // Создает экземпляр класса презентации
using (Presentation presentation = new Presentation())
{
    // Создает новый проект VBA
    presentation.VbaProject = new VbaProject();

    // Добавляет пустой модуль в проект VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Устанавливает исходный код модуля
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Создает ссылку на <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Создает ссылку на Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Добавляет ссылки в проект VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Сохраняет презентацию
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


{{% alert color="primary" %}} 

Возможно, вам будет интересен бесплатный веб‑инструмент **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), позволяющий удалять макросы из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удаление VBA‑макросов**
С помощью свойства [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) в классе [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) можно удалить VBA‑макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
1. Получите модуль макроса и удалите его.
1. Сохраните изменённую презентацию.

Этот код на C# показывает, как удалить VBA‑макрос:
```c#
    // Загружает презентацию, содержащую макрос
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Доступ к модулю VBA и его удаление
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Сохраняет презентацию
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **Извлечение VBA‑макросов**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Пройдитесь по всем модулям проекта VBA, чтобы просмотреть макросы.

Этот код на C# показывает, как извлечь VBA‑макросы из презентации, содержащей макросы:
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


## **Проверка, защищён ли проект VBA паролем**

С помощью свойства [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) можно определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA‑проект](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/).
3. Убедитесь, что проект VBA защищён паролем, чтобы просмотреть его свойства.
```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Проверить, содержит ли презентация проект VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```


## **FAQ**

**Что происходит с макросами, если я сохраняю презентацию как PPTX?**

Макросы удаляются, поскольку формат PPTX не поддерживает VBA. Чтобы сохранить макросы, используйте PPTM, PPSM или POTM.

**Может ли Aspose.Slides выполнять макросы внутри презентации, например, обновлять данные?**

Нет. Библиотека никогда не исполняет код VBA; выполнение возможно только в PowerPoint при соответствующих настройках безопасности.

**Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?**

Да, вы можете получать доступ к существующим [ActiveX controls](/slides/ru/net/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.