---
title: Эффективное объединение презентаций в JavaScript
linktitle: Объединить презентации
type: docs
weight: 40
url: /ru/nodejs-java/merge-presentation/
keywords:
- объединить PowerPoint
- объединить презентации
- объединить слайды
- объединить PPT
- объединить PPTX
- объединить ODP
- комбинировать PowerPoint
- комбинировать презентации
- комбинировать слайды
- комбинировать PPT
- комбинировать PPTX
- комбинировать ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Легко объединяйте презентации PowerPoint (PPT, PPTX) и OpenDocument (ODP) на JavaScript с помощью Aspose.Slides для Node.js, упрощая ваш рабочий процесс."
---

## **Объединение презентаций**

Когда вы объединяете одну презентацию с другой, вы фактически комбинируете их слайды в одну презентацию, получая один файл. 

{{% alert title="Info" color="info" %}}

Большинство программ для презентаций (PowerPoint или OpenOffice) не имеют функций, позволяющих пользователям объединять презентации таким образом. 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) однако позволяет объединять презентации различными способами. Вы можете объединять презентации со всеми их объектами, стилями, текстом, форматированием, комментариями, анимациями и т.д., не опасаясь потери качества или данных.

**См. также**

[Clone Slides](https://docs.aspose.com/slides/nodejs-java/clone-slides/).

{{% /alert %}}

### **Что можно объединять**

С помощью Aspose.Slides вы можете объединять

* целые презентации. Все слайды из презентаций оказываются в одной презентации
* отдельные слайды. Выбранные слайды оказываются в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т.д.) друг с другом. 

### **Параметры объединения**

Вы можете задать параметры, определяющие, будет ли

* каждый слайд в результирующей презентации сохранять уникальный стиль
* один конкретный стиль применяться ко всем слайдам в результирующей презентации. 

Для объединения презентаций Aspose.Slides предоставляет методы [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (из класса [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)). Существует несколько перегрузок методов `addClone`, определяющих параметры процесса объединения презентаций. Каждый объект Presentation имеет коллекцию [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--), поэтому вы можете вызвать метод `addClone` у презентации, в которую хотите добавить слайды.

`addClone` возвращает объект `Slide`, являющийся клоном исходного слайда. Слайды в результирующей презентации являются просто копией слайдов из исходной презентации. Поэтому вы можете вносить изменения в полученные слайды (например, применять стили, параметры форматирования или макеты), не беспокоясь о влиянии на исходные презентации. 

## **Объединение презентаций** 

Aspose.Slides предоставляет метод [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) , позволяющий объединять слайды, при этом слайды сохраняют свои макеты и стили (параметры по умолчанию).

Этот код JavaScript демонстрирует, как объединить презентации:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Объединение презентаций с мастер‑слайдом**

Aspose.Slides предоставляет метод [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) , позволяющий объединять слайды с применением шаблона мастер‑презентации. Таким образом, при необходимости вы можете изменить стиль слайдов в результирующей презентации.

Этот код JavaScript демонстрирует описанную операцию:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 

Макет слайда для мастер‑слайда определяется автоматически. Если подходящий макет нельзя определить, и параметр `allowCloneMissingLayout` метода `addClone` установлен в true, используется макет исходного слайда. В противном случае будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException). 

{{% /alert %}}

Если вы хотите, чтобы слайды в результирующей презентации имели иной макет, используйте метод [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) при объединении.

## **Объединение конкретных слайдов из презентаций**

Объединение конкретных слайдов из нескольких презентаций полезно для создания пользовательских наборов слайдов. Aspose.Slides for Node.js via Java позволяет выбирать и импортировать только необходимые слайды. API сохраняет форматирование, макет и дизайн оригинальных слайдов.

Следующий код JavaScript создает новую презентацию, добавляет титульные слайды из двух других презентаций и сохраняет результат в файл:
```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```

```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```


## **Объединение презентаций с макетом слайда**

Этот код JavaScript демонстрирует, как объединять слайды из презентаций, применяя к ним выбранный вами макет слайда, чтобы получить одну результирующую презентацию:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Объединение презентаций с разными размерами слайдов**

{{% alert title="Note" color="warning" %}} 

Невозможно объединять презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить две презентации с разными размерами слайдов, необходимо изменить размер одной из презентаций, чтобы её размер соответствовал размеру другой.

Пример кода демонстрирует описанную операцию:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Объединение слайдов в раздел презентации**

Этот код JavaScript демонстрирует, как объединить конкретный слайд в раздел презентации:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


Слайд добавляется в конец раздела. 

## **FAQ**

**Сохраняются ли заметки докладчика при объединении?**

Да. При клонировании слайдов Aspose.Slides переносит все элементы слайда, включая заметки, форматирование и анимацию.

**Переносятся ли комментарии и их авторы?**

Комментарии, как часть содержимого слайда, копируются вместе со слайдом. Метки авторов комментариев сохраняются как объекты комментариев в результирующей презентации.

**Что делать, если исходная презентация защищена паролем?**

Её необходимо [открыть с паролем](/slides/ru/nodejs-java/password-protected-presentation/) с помощью [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/); после загрузки эти слайды можно безопасно клонировать в незапароленный файл‑цель (или в защищённый файл).

**Насколько потокобезопасна операция объединения?**

Не используйте один и тот же объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/nodejs-java/multithreading/). Рекомендуемое правило: «один документ — один поток»; разные файлы могут обрабатываться параллельно в отдельных потоках.

## **Смотрите также**

Aspose предоставляет [БЕСПЛАТНЫЙ онлайн‑создатель коллажей](https://products.aspose.app/slides/collage). С помощью этого онлайн‑сервиса вы можете объединять изображения [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG, создавать [фото‑гриды](https://products.aspose.app/slides/collage/photo-grid) и многое другое.

Ознакомьтесь с [Aspose FREE Online Merger](https://products.aspose.app/slides/merger). Он позволяет объединять презентации PowerPoint в одном формате (например, PPT в PPT, PPTX в PPTX) или в разных форматах (например, PPT в PPTX, PPTX в ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)