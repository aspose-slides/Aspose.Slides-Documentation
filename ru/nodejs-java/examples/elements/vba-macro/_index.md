---
title: VBA‑макрос
type: docs
weight: 150
url: /ru/nodejs-java/examples/elements/vba-macro/
keywords:
- пример кода
- VBA
- макрос
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Автоматизируйте презентации с помощью Aspose.Slides for Node.js via Java: создавайте, импортируйте и защищайте VBA‑макросы в PPT, PPTX и ODP, используя понятные примеры JavaScript."
---
В этой статье демонстрируется, как добавлять, получать доступ и удалять VBA-макросы с помощью **Aspose.Slides for Node.js via Java**.

## **Добавить VBA-макрос**

Создайте презентацию с проектом VBA и простым модулем макроса.

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Получить доступ к VBA-макросу**

Получите первый модуль из проекта VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Предполагая, что презентация содержит как минимум один модуль VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить VBA-макрос**

Удалите модуль из проекта VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Предполагая, что презентация содержит как минимум один модуль VBA.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```