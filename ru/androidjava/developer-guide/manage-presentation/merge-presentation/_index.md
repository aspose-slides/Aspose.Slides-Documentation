---
title: Эффективное объединение презентаций на Android
linktitle: Объединить презентации
type: docs
weight: 40
url: /ru/androidjava/merge-presentation/
keywords:
- объединение PowerPoint
- объединение презентаций
- объединение слайдов
- объединение PPT
- объединение PPTX
- объединение ODP
- комбинирование PowerPoint
- комбинирование презентаций
- комбинирование слайдов
- комбинирование PPT
- комбинирование PPTX
- комбинирование ODP
- Android
- Java
- Aspose.Slides
description: "Легко объединяйте презентации PowerPoint (PPT, PPTX) и OpenDocument (ODP) с помощью Aspose.Slides для Android через Java, оптимизируя ваш рабочий процесс."
---

{{% alert  title="Tip" color="primary" %}} 

Возможно, вам будет интересно ознакомиться с **Aspose бесплатным онлайн** [Merger app](https://products.aspose.app/slides/merger). Он позволяет пользователям объединять презентации PowerPoint в одном и том же формате (PPT в PPT, PPTX в PPTX и т.д.) и объединять презентации в разных форматах (PPT в PPTX, PPTX в ODP и т.д.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Объединение презентаций**

Когда вы объединяете одну презентацию с другой, вы фактически комбинируете их слайды в единой презентации, получая один файл. 

{{% alert title="Info" color="info" %}}

Большинство программ для презентаций (PowerPoint или OpenOffice) не имеют функций, позволяющих пользователям объединять презентации таким способом. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), однако, позволяет объединять презентации различными способами. Вы можете объединять презентации со всеми их фигурами, стилями, текстами, форматированием, комментариями, анимациями и т.д., не опасаясь потери качества или данных.

**Смотрите также**

[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Что можно объединять**

С помощью Aspose.Slides вы можете объединять 

* полные презентации. Все слайды из презентаций оказываются в одной презентации
* отдельные слайды. Выбранные слайды оказываются в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т.д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т.д.), объединяя их друг с другом. 

{{% alert title="Note" color="warning" %}} 

Помимо презентаций, Aspose.Slides позволяет объединять другие файлы:

* [Изображения](https://products.aspose.com/slides/androidjava/merger/image-to-image/), такие как [JPG в JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) или [PNG в PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* [Документы](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/), такие как [PDF в PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) или [HTML в HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* И два разных типа файлов, такие как [image to PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) или [JPG в PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) или [TIFF в PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **Параметры объединения**

Вы можете задать параметры, определяющие, будет ли

* каждый слайд в результирующей презентации сохраняет уникальный стиль
* используется конкретный стиль для всех слайдов в результирующей презентации. 

Для объединения презентаций Aspose.Slides предоставляет методы [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (из интерфейса [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)). Существует несколько реализаций методов `AddClone`, определяющих параметры процесса объединения презентаций. Каждый объект Presentation имеет коллекцию [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--), поэтому вы можете вызвать метод `AddClone` у презентации, в которую хотите добавить слайды.

`AddClone` метод возвращает объект `ISlide`, который является клоном исходного слайда. Слайды в результирующей презентации представляют собой простую копию слайдов из исходной презентации. Поэтому вы можете вносить изменения в полученные слайды (например, применять стили, параметры форматирования или макеты), не опасаясь, что исходные презентации будут затронуты. 

## **Объединение презентаций** 

Aspose.Slides предоставляет метод [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , который позволяет объединять слайды, при этом слайды сохраняют свои макеты и стили (параметры по умолчанию).

Этот код на Java показывает, как объединять презентации:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Объединение презентаций с мастер-слайдом** 

Aspose.Slides предоставляет метод [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) , который позволяет объединять слайды, применяя шаблон мастер‑презентации. Таким образом, при необходимости вы можете изменить стиль слайдов в результирующей презентации.

Этот код на Java демонстрирует описанную операцию:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Макет слайда для мастер‑слайда определяется автоматически. Если подходящий макет не может быть определён, и параметр `allowCloneMissingLayout` метода `AddClone` установлен в true, используется макет исходного слайда. В противном случае будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

Если вы хотите, чтобы слайды в результирующей презентации имели другой макет, используйте метод [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) при объединении.

## **Объединение определённых слайдов из презентаций** 

Объединение определённых слайдов из нескольких презентаций полезно для создания пользовательских наборов слайдов. Aspose.Slides for Android via Java позволяет выбирать и импортировать только нужные слайды. API сохраняет форматирование, макет и дизайн оригинальных слайдов.

Ниже приведён код на Java, который создаёт новую презентацию, добавляет титульные слайды из двух других презентаций и сохраняет результат в файл:
```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```


## **Объединение презентаций с макетом слайда** 

Этот код на Java показывает, как объединять слайды из презентаций, применяя к ним желаемый макет слайда, чтобы получить одну итоговую презентацию:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Объединение презентаций с разными размерами слайдов** 

{{% alert title="Note" color="warning" %}} 

Нельзя объединять презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить 2 презентации с разными размерами слайдов, необходимо изменить размер одной из презентаций, чтобы он соответствовал размеру другой презентации. 

Этот пример кода демонстрирует описанную операцию:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Объединение слайдов в раздел презентации** 

Этот код на Java показывает, как объединить определённый слайд с разделом в презентации:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


Слайд добавляется в конец раздела. 

{{% alert title="Tip" color="primary" %}}

Aspose предоставляет бесплатное веб‑приложение [FREE Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн‑сервиса вы можете объединять изображения [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG, создавать [фото‑решётки](https://products.aspose.app/slides/collage/photo-grid) и т.д. 

{{% /alert %}}

## **FAQ**

**Есть ли ограничения на количество слайдов при объединении презентаций?**

Нет строгих ограничений. Aspose.Slides может обрабатывать большие файлы, но производительность зависит от размера и ресурсов системы. Для очень больших презентаций рекомендуется использовать 64‑разрядную JVM и выделять достаточный объём памяти heap.

**Можно ли объединять презентации с вложенными видео или аудио?**

Да, Aspose.Slides сохраняет мультимедийный контент, встроенный в слайды, но итоговая презентация может стать заметно больше.

**Будут ли шрифты сохранены при объединении презентаций?**

Да. Шрифты, используемые в исходных презентациях, сохраняются в результирующем файле, при условии, что они установлены в системе или [встроены](/slides/ru/androidjava/embedded-font/).