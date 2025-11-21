---
title: Презентация через VBA
type: docs
weight: 250
url: /ru/nodejs-java/presentation-via-vba/
keywords: "Макрос, макросы, VBA, макрос VBA, добавить макрос, удалить макрос, добавить VBA, удалить VBA, извлечь макрос, извлечь VBA, макрос PowerPoint, презентация PowerPoint, Java, Aspose.Slides for Node.js via Java"
description: "Добавление, удаление и извлечение VBA‑макросов в презентациях PowerPoint на JavaScript"
---

{{% alert title="Note" color="warning" %}} 

При конвертации презентации, содержащей макросы, в другой формат файла (PDF, HTML и т.д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в полученный файл).

При добавлении макросов в презентацию или повторном сохранении презентации, содержащей макросы, Aspose.Slides просто записывает байты макросов.

Aspose.Slides **никогда** не выполняет макросы в презентации.

{{% /alert %}}

## **Добавить VBA‑макросы**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/), позволяющий создавать VBA‑проекты (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать класс [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) для управления VBA, встроенным в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#VbaProject--) для добавления нового VBA‑проекта.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с VBA‑проектом.
1. Сохраните презентацию.

Этот код JavaScript демонстрирует, как добавить VBA‑макрос с нуля в презентацию:
```javascript
// Создает экземпляр класса презентации
let pres = new aspose.slides.Presentation();
try {
    // Создает новый проект VBA
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Добавляет пустой модуль в проект VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Устанавливает исходный код модуля
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Создает ссылку на <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Создает ссылку на Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Добавляет ссылки в проект VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Сохраняет презентацию
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

Возможно, вам будет интересно попробовать бесплатное веб‑приложение **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), которое используется для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удалить VBA‑макросы**

С помощью свойства [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject--) класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) можно удалить VBA‑макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю Macro и удалите его.
1. Сохраните изменённую презентацию.

Этот код JavaScript демонстрирует, как удалить VBA‑макрос:
```javascript
// Загружает презентацию, содержащую макрос
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Получает модуль VBA и удаляет его
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Сохраняет презентацию
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Извлечь VBA‑макросы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация VBA‑проект.
3. Пройдитесь по всем модулям, содержащимся в VBA‑проекте, чтобы просмотреть макросы.

Этот код JavaScript демонстрирует, как извлечь VBA‑макросы из презентации, содержащей макросы:
```javascript
// Загружает презентацию, содержащую макрос
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Проверяет, содержит ли презентация VBA‑проект
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Проверить, защищён ли VBA‑проект паролем**

С помощью метода [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected) можно определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA‑проект](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/).
3. Проверьте, защищён ли VBA‑проект паролем, чтобы просмотреть его свойства.
```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Проверить, содержит ли презентация VBA‑проект.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Что происходит с макросами, если я сохраняю презентацию как PPTX?**

Макросы будут удалены, поскольку PPTX не поддерживает VBA. Чтобы сохранить макросы, выберите PPTM, PPSM или POTM.

**Может ли Aspose.Slides выполнять макросы внутри презентации, например, обновлять данные?**

Нет. Библиотека никогда не выполняет VBA‑код; выполнение возможно только в PowerPoint при соответствующих настройках безопасности.

**Поддерживается ли работа с элементами управления ActiveX, связанными с VBA‑кодом?**

Да, вы можете получить доступ к существующим [элементам управления ActiveX](/slides/ru/nodejs-java/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.