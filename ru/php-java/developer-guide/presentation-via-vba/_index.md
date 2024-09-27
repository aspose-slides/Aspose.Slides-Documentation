---
title: Презентация через VBA
type: docs
weight: 250
url: /ru/php-java/presentation-via-vba/
keywords: "Макрос, макросы, VBA, VBA макрос, добавить макрос, удалить макрос, добавить VBA, удалить VBA, извлечь макрос, извлечь VBA, макрос PowerPoint, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Добавьте, удалите и извлеките VBA макросы в презентациях PowerPoint"
---

{{% alert title="Примечание" color="warning" %}} 

Когда вы конвертируете презентацию, содержащую макросы, в другой формат файла (PDF, HTML и т. д.), Aspose.Slides игнорирует все макросы (макросы не переносятся в результирующий файл).

Когда вы добавляете макросы в презентацию или повторно сохраняете презентацию, содержащую макросы, Aspose.Slides просто записывает байты для макросов.

Aspose.Slides **никогда** не выполняет макросы в презентации.

{{% /alert %}}

## **Добавление VBA Макросов**

Aspose.Slides предоставляет класс [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/), который позволяет вам создавать проекты VBA (и ссылки на проекты) и редактировать существующие модули. Вы можете использовать интерфейс [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) для управления VBA, встроенной в презентацию.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) для добавления нового проекта VBA.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с проектом VBA.
1. Сохраните презентацию.

Этот PHP код показывает, как добавить VBA макрос с нуля в презентацию:

```php
  # Создает экземпляр класса презентации
  $pres = new Presentation();
  try {
    # Создает новый VBA проект
    $pres->setVbaProject(new VbaProject());
    # Добавляет пустой модуль в VBA проект
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # Устанавливает исходный код модуля
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # Создает ссылку на <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # Создает ссылку на Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # Добавляет ссылки в проект VBA
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

Вам может быть интересно ознакомиться с **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), который является бесплатным веб-приложением, используемым для удаления макросов из документов PowerPoint, Excel и Word.

{{% /alert %}} 

## **Удаление VBA Макросов**

Используя свойство [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) в классе [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), вы можете удалить VBA макрос.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
1. Получите доступ к модулю макроса и удалите его.
1. Сохраните измененную презентацию.

Этот PHP код показывает, как удалить VBA макрос:

```php
  # Загружает презентацию, содержащую макрос
  $pres = new Presentation("VBA.pptm");
  try {
    # Получает доступ к модулю Vba и удаляет его
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Сохраняет презентацию
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Извлечение VBA Макросов**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Пройдитесь по всем модулям, содержащимся в проекте VBA, чтобы просмотреть макросы.

Этот PHP код показывает, как извлечь VBA макросы из презентации, содержащей макросы:

```php
  # Загружает презентацию, содержащую макрос
  $pres = new Presentation("VBA.pptm");
  try {
    # Проверяет, содержит ли презентация проект VBA
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