---
title: VbaMacro
type: docs
weight: 150
url: /ru/php-java/examples/elements/vba-macro/
keywords:
- макрос VBA
- добавить макрос VBA
- получить доступ к макросу VBA
- удалить макрос VBA
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Работайте с макросами VBA в PHP с помощью Aspose.Slides: добавляйте или редактируйте проекты и модули, подписывайте или удаляйте макросы и сохраняйте презентации в форматах PPT, PPTX и ODP."
---
Иллюстрирует, как добавлять, получать доступ и удалять макросы VBA с помощью **Aspose.Slides for PHP via Java**.

## **Добавить макрос VBA**

Создайте презентацию с проектом VBA и простым модулем макроса.

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **Получить доступ к макросу VBA**

Получите первый модуль из проекта VBA.

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить макрос VBA**

Удалите модуль из проекта VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Предполагается, что в проекте VBA есть хотя бы один модуль.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```