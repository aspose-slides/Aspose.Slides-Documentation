---
title: Управление проектами VBA в презентациях с помощью C++
linktitle: Презентация через VBA
type: docs
weight: 250
url: /ru/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "Узнайте, как создавать и управлять презентациями PowerPoint и OpenDocument через VBA с помощью Aspose.Slides для C++, чтобы оптимизировать ваш рабочий процесс."
---
## **Введение**

Пространство имён [Aspose.Slides.Vba](https://reference.aspose.com/slides/ru/cpp/namespace/aspose.slides.vba/) содержит классы и интерфейсы для работы с макросами и кодом VBA.

{{% alert title="Note" color="warning" %}} 

При конвертации презентации, содержащей макросы, в другой формат файла (PDF, HTML и т.д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в полученный файл).

Когда вы добавляете макросы в презентацию или сохраняете заново презентацию, содержащую макросы, Aspose.Slides просто записывает байты макросов.

Aspose.Slides **никогда** не выполняет макросы в презентации.

{{% /alert %}}

## **Добавить VBA‑макросы**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.vba.vba_project), позволяющий создавать проекты VBA (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать интерфейс [IVbaProject](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.vba.i_vba_project/) чтобы управлять VBA, встроенным в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) для добавления нового проекта VBA.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с проектом VBA.
1. Сохраните презентацию.

Этот пример кода на C++ показывает, как добавить VBA‑макрос с нуля в презентацию: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// Путь к каталогу документов.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Создаёт экземпляр класса презентации
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Создаёт новый проект VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Добавляет пустой модуль в проект VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Устанавливает исходный код модуля
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Создаёт ссылку на <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Создаёт ссылку на Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Добавляет ссылки в проект VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Сохраняет презентацию
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 

Вам может быть интересен **Aspose** [Macro Remover](https://products.aspose.app/slides/ru/remove-macros) — бесплатное веб‑приложение для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удалить VBA‑макросы**

Используя свойство [VbaProject](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) в классе [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation), вы можете удалить VBA‑макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю Macro и удалите его.
1. Сохраните изменённую презентацию.

Этот пример кода на C++ показывает, как удалить VBA‑макрос: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// Путь к каталогу документов.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Загружает презентацию, содержащую макрос
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Получает модуль Vba и удаляет его
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Сохраняет презентацию
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Извлечь VBA‑макросы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/class/aspose.slides.presentation) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Пройдитесь по всем модулям, содержащимся в проекте VBA, чтобы просмотреть макросы.

Этот пример кода на C++ показывает, как извлечь VBA‑макросы из презентации, содержащей макросы: 

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

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

## **Проверить, защищён ли проект VBA паролем**

С помощью свойства [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/ru/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) можно определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA‑проект](https://reference.aspose.com/slides/ru/cpp/aspose.slides.vba/vbaproject/).
3. Проверьте, защищён ли проект VBA паролем, чтобы просмотреть его свойства.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Проверить, содержит ли презентация проект VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

### Что происходит с макросами, если я сохраняю презентацию как PPTX?

Макросы будут удалены, поскольку формат PPTX не поддерживает VBA. Чтобы сохранить макросы, выбирайте PPTM, PPSM или POTM.

### Может ли Aspose.Slides выполнять макросы внутри презентации, например, обновлять данные?

Нет. Библиотека никогда не выполняет код VBA; выполнение возможно только в PowerPoint при соответствующих настройках безопасности.

### Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?

Да, вы можете получить доступ к существующим [элементам управления ActiveX](/slides/ru/cpp/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.