---
title: Управление VBA‑проектами в презентациях с использованием Java
linktitle: Презентация через VBA
type: docs
weight: 250
url: /ru/java/presentation-via-vba/
keywords:
- макрос
- VBA
- VBA‑макрос
- добавить макрос
- удалить макрос
- извлечь макрос
- добавить VBA
- удалить VBA
- извлечь VBA
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и изменять презентации PowerPoint и OpenDocument с помощью VBA, используя Aspose.Slides для Java, чтобы оптимизировать ваш рабочий процесс."
---

{{% alert title="Note" color="warning" %}} 
При конвертации презентации, содержащей макросы, в другой формат файла (PDF, HTML и т.д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в полученный файл).

Когда вы добавляете макросы в презентацию или сохраняете заново презентацию, содержащую макросы, Aspose.Slides просто записывает байты макросов.

Aspose.Slides **никогда** не запускает макросы в презентации.
{{% /alert %}}

## **Добавить VBA‑макросы**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/), позволяющий создавать VBA‑проекты (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать интерфейс [IVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/) для управления VBA, встроенным в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/#VbaProject--) для добавления нового VBA‑проекта.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Ассоциируйте ссылки с VBA‑проекта.
1. Сохраните презентацию.

Этот код на Java показывает, как добавить VBA‑макрос с нуля в презентацию:
```java
// Создаёт экземпляр класса презентации
Presentation pres = new Presentation();
try {
    // Создаёт новый VBA‑проект
    pres.setVbaProject(new VbaProject());
    
    // Добавляет пустой модуль в VBA‑проект
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Устанавливает исходный код модуля
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Создаёт ссылку на <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Создаёт ссылку на Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Добавляет ссылки в VBA‑проект
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Сохраняет презентацию
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
Возможно, вам будет интересно ознакомиться с **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) — бесплатным веб‑приложением для удаления макросов из документов PowerPoint, Excel и Word. 
{{% /alert %}} 

## **Удалить VBA‑макросы**

Используя свойство [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getVbaProject--) класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation), вы можете удалить VBA‑макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
2. Получите доступ к модулю Macro и удалите его.
3. Сохраните изменённую презентацию.

Этот код на Java показывает, как удалить VBA‑макрос:
```java
// Загружает презентацию, содержащую макрос
Presentation pres = new Presentation("VBA.pptm");
try {
    // Получает модуль VBA и удаляет его 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Сохраняет презентацию
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Извлечь VBA‑макросы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация VBA‑проект.
3. Пройдитесь по всем модулям, содержащимся в VBA‑проекте, чтобы просмотреть макросы.

Этот код на Java показывает, как извлечь VBA‑макросы из презентации, содержащей макросы:
```java
// Загружает презентацию, содержащую макрос
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Проверяет, содержит ли презентация VBA‑проект
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


## **Проверить, защищён ли VBA‑проект паролем**

С помощью метода [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) можно определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA‑проект](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/).
3. Проверьте, защищён ли VBA‑проект паролем, чтобы просмотреть его свойства.
```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Проверяет, содержит ли презентация VBA‑проект.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **Часто задаваемые вопросы**

**Что происходит с макросами, если сохранить презентацию как PPTX?**  
Макросы будут удалены, так как PPTX не поддерживает VBA. Чтобы сохранить макросы, выбирайте форматы PPTM, PPSM или POTM.

**Может ли Aspose.Slides выполнять макросы внутри презентации, например, для обновления данных?**  
Нет. Библиотека никогда не исполняет код VBA; выполнение возможно только в PowerPoint при соответствующих настройках безопасности.

**Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?**  
Да, вы можете получать доступ к существующим [элементам управления ActiveX](/slides/ru/java/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.