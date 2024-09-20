---
title: Презентация через VBA
type: docs
weight: 250
url: /cpp/presentation-via-vba/
keywords: "Макрос, макросы, VBA, VBA макрос, добавить макрос, удалить макрос, добавить VBA, удалить VBA, извлечь макрос, извлечь VBA, макрос PowerPoint, презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Добавляйте, удаляйте и извлекайте макросы VBA в презентациях PowerPoint на C++"
---

Пространство имен [Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/) содержит классы и интерфейсы для работы с макросами и кодом VBA.

{{% alert title="Примечание" color="warning" %}} 

Когда вы конвертируете презентацию, содержащую макросы, в другой формат файла (PDF, HTML и т.д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в итоговый файл).

Когда вы добавляете макросы в презентацию или повторно сохраняете презентацию с макросами, Aspose.Slides просто записывает байты макросов.

Aspose.Slides **никогда** не запускает макросы в презентации.

{{% /alert %}}

## **Добавление макросов VBA**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project), который позволяет вам создавать проекты VBA (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать интерфейс [IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) для управления VBA, встроенной в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) для добавления нового проекта VBA.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с проектом VBA.
1. Сохраните презентацию.

Этот код на C++ показывает, как добавить макрос VBA с нуля в презентацию: 

```c++

// Путь к каталогу документов.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Создает экземпляр класса презентации
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Создает новый проект VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Добавляет пустой модуль в проект VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Устанавливает исходный код модуля
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Создает ссылку на <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Создает ссылку на Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Добавляет ссылки в проект VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Сохраняет презентацию
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);

```

{{% alert color="primary" %}} 

Вы также можете ознакомиться с **Aspose** [Удаление макросов](https://products.aspose.app/slides/remove-macros), это бесплатное веб-приложение, используемое для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удаление макросов VBA**

Используя свойство [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation), вы можете удалить макрос VBA.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю макроса и удалите его.
1. Сохраните измененную презентацию.

Этот код на C++ показывает, как удалить макрос VBA: 

```c++

// Путь к каталогу документов.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Загружает презентацию, содержащую макрос
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Получает доступ к модулю Vba и удаляет его 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Сохраняет презентацию
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);

```

## **Извлечение макросов VBA**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Пройдитесь по всем модулям, содержащимся в проекте VBA, чтобы просмотреть макросы.

Этот код на C++ показывает, как извлечь макросы VBA из презентации, содержащей макросы: 

```c++

	// Путь к каталогу документов.
	const String templatePath = u"../templates/VBA.pptm";

	// Загружает презентацию, содержащую макрос
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Проверяет, содержит ли презентация проект VBA
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```