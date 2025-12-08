---
title: Объединение презентации
type: docs
weight: 40
url: /ru/nodejs-java/merge-presentation/
keywords: "Объединить PowerPoint, PPTX, PPT, комбинировать PowerPoint, объединить презентацию, комбинировать презентацию, Java"
description: "Объединить или комбинировать презентацию PowerPoint в JavaScript"
---

## **Объединение презентаций**

Когда вы объединяете одну презентацию с другой, вы фактически объединяете их слайды в одну презентацию, получая один файл. 

{{% alert title="Info" color="info" %}}

Большинству программ для работы с презентациями (PowerPoint или OpenOffice) не хватает функций, позволяющих пользователям комбинировать презентации таким образом. 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), однако позволяет объединять презентации различными способами. Вы можете объединять презентации со всеми их объектами, стилями, текстами, форматированием, комментариями, анимациями и т.д., не беспокоясь о потере качества или данных.

**См. также**

[Clone Slides](https://docs.aspose.com/slides/nodejs-java/clone-slides/).

{{% /alert %}}

### **Что можно объединять**

С помощью Aspose.Slides вы можете объединять 

* целые презентации. Все слайды из презентаций окажутся в одной презентации
* отдельные слайды. Выбранные слайды окажутся в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т.д.) друг с другом. 

{{% alert title="Note" color="warning" %}} 

Помимо презентаций, Aspose.Slides позволяет объединять другие файлы:

* [Imagess](https://products.aspose.com/slides/nodejs-java/merger/image-to-image/), такие как [JPG в JPG](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-jpg/) или [PNG в PNG](https://products.aspose.com/slides/nodejs-java/merger/png-to-png/)
* Документы, такие как [PDF в PDF](https://products.aspose.com/slides/nodejs-java/merger/pdf-to-pdf/) или [HTML в HTML](https://products.aspose.com/slides/nodejs-java/merger/html-to-html/)
* И два разных файла, такие как [image в PDF](https://products.aspose.com/slides/nodejs-java/merger/image-to-pdf/) [JPG в PDF](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-pdf/) или [TIFF в PDF](https://products.aspose.com/slides/nodejs-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Параметры объединения**

Вы можете задать параметры, определяющие, будет ли

* каждый слайд в получающейся презентации сохраняет уникальный стиль
* для всех слайдов в получающейся презентации используется один и тот же стиль. 

Для объединения презентаций Aspose.Slides предоставляет методы [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (из класса [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)). Существует несколько реализаций методов `addClone`, определяющих параметры процесса объединения презентаций. Каждый объект Presentation имеет коллекцию [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--), поэтому вы можете вызвать метод `addClone` у презентации, в которую хотите добавить слайды.

Метод `addClone` возвращает объект `Slide`, который является клоном исходного слайда. Слайды в результирующей презентации представляют собой простую копию слайдов из исходника. Поэтому вы можете вносить изменения в полученные слайды (например, применять стили, параметры форматирования или макеты), не опасаясь, что исходные презентации будут затронуты. 

## **Объединение презентаций** 

Aspose.Slides предоставляет метод [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) , который позволяет комбинировать слайды, при этом слайды сохраняют свои макеты и стили (параметры по умолчанию).

Этот код на JavaScript демонстрирует, как объединять презентации:
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

Aspose.Slides предоставляет метод [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-), который позволяет комбинировать слайды, одновременно применяя шаблон мастер‑презентации. Таким образом, при необходимости вы можете изменить стиль слайдов в получающейся презентации.

Этот код на JavaScript демонстрирует описанную операцию:
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

Макет слайда для мастер‑слайда определяется автоматически. Когда подходящий макет нельзя определить, если логический параметр `allowCloneMissingLayout` метода `addClone` установлен в true, используется макет исходного слайда. В противном случае будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException). 

{{% /alert %}}

Если вы хотите, чтобы слайды в получающейся презентации имели другой макет, используйте вместо этого метод [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-). 

## **Объединение отдельных слайдов из презентаций**

Объединение отдельных слайдов из нескольких презентаций полезно для создания пользовательских наборов слайдов. Aspose.Slides for Node.js via Java позволяет выбирать и импортировать только нужные вам слайды. API сохраняет форматирование, макет и дизайн оригинальных слайдов.

Следующий код на JavaScript создаёт новую презентацию, добавляет титульные слайды из двух других презентаций и сохраняет результат в файл:
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

Этот код на JavaScript демонстрирует, как комбинировать слайды из презентаций, применяя выбранный вами макет слайда, чтобы получить одну итоговую презентацию:
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

Нельзя объединять презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить 2 презентации с разными размерами слайдов, необходимо изменить размер одной из презентаций, чтобы он соответствовал размеру другой презентации. 

Этот пример кода демонстрирует описанную операцию:
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

Этот код на JavaScript показывает, как объединить конкретный слайд в раздел презентации:
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

**Сохраняются ли заметки выступающего при объединении?**

Да. При клонировании слайдов Aspose.Slides переносит все элементы слайда, включая заметки, форматирование и анимацию.

**Переносятся ли комментарии и их авторы?**

Комментарии, как часть содержимого слайда, копируются вместе со слайдом. Метки авторов комментариев сохраняются как объекты комментариев в полученной презентации.

**Что делать, если исходная презентация защищена паролем?**

Она должна быть [открыта с паролем](/slides/ru/nodejs-java/password-protected-presentation/) через [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/); после загрузки эти слайды можно безопасно клонировать в незащищённый целевой файл (или в защищённый).

**Насколько потокобезопасна операция объединения?**

Не используйте один и тот же объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) из [нескольких потоков](/slides/ru/nodejs-java/multithreading/). Рекомендуемое правило — «один документ — один поток»; разные файлы могут обрабатываться параллельно в отдельных потоках.

## **См. также**

Aspose предоставляет [FREE Online Collage Maker](https://products.aspose.app/slides/collage). С помощью этого онлайн‑сервиса вы можете объединять изображения [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG, создавать [фото‑сетки](https://products.aspose.app/slides/collage/photo-grid) и многое другое.

Посетите [Aspose FREE Online Merger](https://products.aspose.app/slides/merger). Он позволяет объединять презентации PowerPoint в одном формате (например, PPT в PPT, PPTX в PPTX) или между разными форматами (например, PPT в PPTX, PPTX в ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)