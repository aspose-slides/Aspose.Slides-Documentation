---
title: Управление VBA‑проектами в презентациях с помощью Java
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
description: "Узнайте, как создавать и манипулировать презентациями PowerPoint и OpenDocument через VBA с помощью Aspose.Slides для Java, чтобы оптимизировать ваш рабочий процесс."
---
## **Введение**

Aspose.Slides предоставляет классы и интерфейсы для работы с макросами и кодом VBA.

{{% alert title="Примечание" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Добавление VBA‑макросов**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/ru/java/com.aspose.slides/vbaproject/) для создания VBA‑проектов (и ссылок на проекты) и редактирования существующих модулей. Вы можете использовать интерфейс [IVbaProject](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivbaproject/) для управления VBA, встроенным в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/ru/java/com.aspose.slides/vbaproject/#VbaProject--) для добавления нового VBA‑проекта.
1. Добавьте модуль в VbaProject.
1. Задайте исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с VBA‑проектом.
1. Сохраните презентацию.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

Возможно, вам будет интересно посмотреть бесплатное веб‑приложение **Aspose** [Macro Remover](https://products.aspose.app/slides/ru/remove-macros), которое используется для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удаление VBA‑макросов**

Используя свойство [VbaProject](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getVbaProject--) класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation), вы можете удалить VBA‑макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю Macro и удалите его.
1. Сохраните изменённую презентацию.

```java
import com.aspose.slides.*;

// Загружает презентацию, содержащую макрос
Presentation pres = new Presentation("VBA.pptm");
try {
    // Получает доступ к модулю VBA и удаляет его 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Сохраняет презентацию
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Извлечение VBA‑макросов**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация VBA‑проект.
3. Пройдите по всем модулям, содержащимся в VBA‑проекте, чтобы просмотреть макросы.

```java
import com.aspose.slides.*;

// Загружает презентацию, содержащую макрос
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Проверяет, содержит ли презентация проект VBA
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

## **Проверка, защищён ли VBA‑проект паролем**

Используя метод [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ivbaproject/#isPasswordProtected--), вы можете определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA‑проект](https://reference.aspose.com/slides/ru/java/com.aspose.slides/vbaproject/).
3. Проверьте, защищён ли VBA‑проект паролем, чтобы просмотреть его свойства.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Проверяет, содержит ли презентация проект VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Что происходит с макросами, если я сохраняю презентацию как PPTX?

Макросы будут удалены, потому что PPTX не поддерживает VBA. Чтобы сохранить макросы, выберите PPTM, PPSM или POTM.

### Может ли Aspose.Slides выполнять макросы внутри презентации, например, для обновления данных?

Нет. Библиотека никогда не выполняет код VBA; выполнение возможно только внутри PowerPoint при соответствующих настройках безопасности.

### Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?

Да, вы можете получить доступ к существующим [ActiveX controls](/slides/ru/java/activex/), изменить их свойства и удалить их. Это полезно, когда макросы взаимодействуют с ActiveX.