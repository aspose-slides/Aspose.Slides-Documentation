---
title: Презентация через VBA
type: docs
weight: 250
url: /ru/java/presentation-via-vba/
keywords: "Макрос, макросы, VBA, VBA макрос, добавить макрос, удалить макрос, добавить VBA, удалить VBA, извлечь макрос, извлечь VBA, макрос PowerPoint, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Добавление, удаление и извлечение VBA макросов в презентациях PowerPoint на Java"
---

{{% alert title="Примечание" color="warning" %}} 

Когда вы конвертируете презентацию, содержащую макросы, в другой формат файла (PDF, HTML и т. д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в результирующий файл).

Когда вы добавляете макросы в презентацию или сохраняете уже содержащую макросы презентацию, Aspose.Slides просто записывает байты для макросов.

Aspose.Slides **никогда** не выполняет макросы в презентации.

{{% /alert %}}

## **Добавить VBA Макросы**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/), который позволяет вам создавать VBA проекты (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать интерфейс [IVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/) для управления VBA, встроенным в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/#VbaProject--), чтобы добавить новый VBA проект.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с VBA проектом.
1. Сохраните презентацию.

Этот код на Java показывает, как добавить VBA макрос с нуля в презентацию:

```java
// Создает экземпляр класса презентации
Presentation pres = new Presentation();
try {
    // Создает новый VBA проект
    pres.setVbaProject(new VbaProject());
    
    // Добавляет пустой модуль в VBA проект
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Устанавливает исходный код модуля
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Создает ссылку на <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Создает ссылку на Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Библиотека объектов Microsoft Office 14.0");
    
    // Добавляет ссылки в VBA проект
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Сохраняет презентацию
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Вам может быть интересно взглянуть на **Aspose** [Удаление макросов](https://products.aspose.app/slides/remove-macros), бесплатное веб-приложение, используемое для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удалить VBA Макросы**

Используя свойство [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getVbaProject--) класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), вы можете удалить VBA макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю макроса и удалите его.
1. Сохраните измененную презентацию.

Этот код на Java показывает, как удалить VBA макрос:

```java
// Загружает презентацию, содержащую макрос
Presentation pres = new Presentation("VBA.pptm");
try {
    // Получает доступ к модулю Vba и удаляет его 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Сохраняет презентацию
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Извлечь VBA Макросы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация VBA проект.
3. Переберите все модули, содержащиеся в VBA проекте, чтобы просмотреть макросы.

Этот код на Java показывает, как извлечь VBA макросы из презентации, содержащей макросы:

```java
// Загружает презентацию, содержащую макрос
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Проверяет, содержит ли презентация VBA проект
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```