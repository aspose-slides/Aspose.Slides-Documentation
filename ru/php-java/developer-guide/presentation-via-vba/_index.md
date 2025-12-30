---
title: Управление проектами VBA в презентациях с использованием PHP
linktitle: Презентация через VBA
type: docs
weight: 250
url: /ru/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "Узнайте, как создавать и изменять презентации PowerPoint и OpenDocument с помощью VBA, используя Aspose.Slides для PHP через Java, чтобы оптимизировать ваш рабочий процесс."
---

{{% alert title="Примечание" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Add VBA Macros**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) interface to manage VBA embedded in a presentation.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Используйте конструктор [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) для добавления нового VBA‑проекта.
1. Добавьте модуль в VbaProject.
1. Установите исходный код модуля.
1. Добавьте ссылки на <stdole>.
1. Добавьте ссылки на **Microsoft Office**.
1. Свяжите ссылки с проектом VBA.
1. Сохраните презентацию.

This PHP code shows you how to add a VBA macro from scratch to a presentation:
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

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Remove VBA Macros**

Using the [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) property under the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class, you can remove a VBA macro.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
1. Получите модуль Macro и удалите его.
1. Сохраните изменённую презентацию.

This PHP code shows you how to remove a VBA macro:
```php
  # Загружает презентацию, содержащую макрос
  $pres = new Presentation("VBA.pptm");
  try {
    # Получает модуль Vba и удаляет его
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # Сохраняет презентацию
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Extract VBA Macros**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация проект VBA.
3. Переберите все модули, содержащиеся в проекте VBA, чтобы просмотреть макросы.

This PHP code shows you how to extract VBA macros from a presentation containing macros:
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


## **Check Whether a VBA Project Is Password-Protected**

Using the [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected) method, you can determine whether a project’s properties are password-protected.

1. Создайте экземпляр класса [Presentation](/slides/ru/php-java/aspose.slides/presentation/) и загрузите презентацию, содержащую макрос.
2. Проверьте, содержит ли презентация [VBA project](/slides/ru/php-java/aspose.slides/vbaproject/).
3. Проверьте, защищён ли проект VBA паролем, чтобы просмотреть его свойства.
```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // Проверить, содержит ли презентация проект VBA.
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

Макросы будут удалены, потому что формат PPTX не поддерживает VBA. Чтобы сохранить макросы, выберите PPTM, PPSM или POTM.

**Может ли Aspose.Slides выполнять макросы внутри презентации, например, обновлять данные?**

Нет. Библиотека никогда не исполняет код VBA; выполнение возможно только в PowerPoint при соответствующих настройках безопасности.

**Поддерживается ли работа с элементами управления ActiveX, связанными с кодом VBA?**

Да, вы можете получить доступ к существующим [ActiveX controls](/slides/ru/php-java/activex/), изменять их свойства и удалять их. Это полезно, когда макросы взаимодействуют с ActiveX.