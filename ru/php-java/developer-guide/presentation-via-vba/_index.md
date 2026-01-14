---
title: Управление VBA-проектами в презентациях с использованием PHP
linktitle: Презентация через VBA
type: docs
weight: 250
url: /ru/php-java/presentation-via-vba/
keywords:
- макрос
- VBA
- VBA макрос
- добавить макрос
- удалить макрос
- извлечь макрос
- добавить VBA
- удалить VBA
- извлечь VBA
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и изменять презентации PowerPoint и OpenDocument с помощью VBA, используя Aspose.Slides для PHP через Java, чтобы оптимизировать ваш рабочий процесс."
---

{{% alert title="Note" color="warning" %}} 

Когда вы преобразуете презентацию, содержащую макросы, в другой формат файла (PDF, HTML, и т.д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в получаемый файл).

Когда вы добавляете макросы в презентацию или повторно сохраняете презентацию, содержащую макросы, Aspose.Slides просто записывает байты макросов.

Aspose.Slides **никогда** не запускает макросы в презентации.

{{% /alert %}}

## **Добавить VBA макросы**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/), позволяющий создавать VBA‑проекты (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать класс `VbaProject` для управления VBA, встроенным в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject) для добавления нового VBA‑проекта.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с VBA‑проектом.
1. Сохраните презентацию.

Этот PHP‑код показывает, как добавить VBA‑макрос с нуля в презентацию:
```php
  # Создаёт экземпляр класса презентации
  $pres = new Presentation();
  try {
    # Создаёт новый VBA‑проект
    $pres->setVbaProject(new VbaProject());
    # Добавляет пустой модуль в VBA‑проект
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Устанавливает исходный код модуля
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Создаёт ссылку на <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Создаёт ссылку на Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Добавляет ссылки в VBA‑проект
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # Сохраняет презентацию
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

Возможно, вам будет интересен **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), бесплатное веб‑приложение для удаления макросов из документов PowerPoint, Excel и Word. 

{{% /alert %}} 

## **Удалить VBA макросы**

Используя свойство [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject), доступное в классе [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), вы можете удалить VBA‑макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю макроса и удалите его.
1. Сохраните изменённую презентацию.

Этот PHP‑код показывает, как удалить VBA‑макрос:
```php
  # Загружает презентацию, содержащую макрос
  $pres = new Presentation("VBA.pptm");
  try {
    # Получает доступ к модулю VBA и удаляет его
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Сохраняет презентацию
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Извлечь VBA макросы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация VBA‑проект.
3. Переберите все модули, содержащиеся в VBA‑проекте, чтобы просмотреть макросы.

Этот PHP‑код показывает, как извлечь VBA‑макросы из презентации, содержащей макросы:
```php
  # Загружает презентацию, содержащую макрос
  $pres = new Presentation("VBA.pptm");
  try {
    # Проверяет, содержит ли презентация VBA-проект
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Проверить, защищён ли VBA‑проект паролем**

С помощью метода [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected) вы можете определить, защищены ли свойства проекта паролем.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA проект](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/).
3. Проверьте, защищён ли VBA‑проект паролем, чтобы просмотреть его свойства.
```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Проверяет, содержит ли презентация VBA‑проект.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Что происходит с макросами, если я сохраняю презентацию как PPTX?**

Макросы будут удалены, поскольку формат PPTX не поддерживает VBA. Чтобы сохранить макросы, выбирайте PPTM, PPSM или POTM.

**Может ли Aspose.Slides выполнять макросы внутри презентации, например, обновлять данные?**

Нет. Библиотека никогда не выполняет код VBA; выполнение возможно только в PowerPoint при соответствующих настройках безопасности.

**Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?**

Да, вы можете получить доступ к существующим [ActiveX controls](/slides/ru/php-java/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.