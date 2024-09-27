---
title: Объединение Презентаций
type: docs
weight: 40
url: /ru/java/merge-presentation/
keywords: "Объединение PowerPoint, PPTX, PPT, комбинирование PowerPoint, объединение презентации, комбинирование презентации, Java"
description: "Объединение или комбинирование презентаций PowerPoint в Java"
---


{{% alert title="Совет" color="primary" %}} 

Вам может быть интересно ознакомиться с **бесплатным онлайн** приложением [Merger](https://products.aspose.app/slides/merger) от Aspose. Оно позволяет людям объединять презентации PowerPoint в одном и том же формате (PPT в PPT, PPTX в PPTX и т. д.) и объединять презентации в разных форматах (PPT в PPTX, PPTX в ODP и т. д.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Объединение Презентаций**

Когда вы объединяете одну презентацию с другой, вы фактически объединяете их слайды в одной презентации, чтобы получить один файл. 

{{% alert title="Информация" color="info" %}}

Большинство программ для работы с презентациями (PowerPoint или OpenOffice) не имеют функций, позволяющих пользователям объединять презентации таким образом. 

[**Aspose.Slides для Java**](https://products.aspose.com/slides/java/), однако, позволяет объединять презентации различными способами. Вы можете объединять презентации со всеми их фигурами, стилями, текстами, форматированием, комментариями, анимацией и т. д. без необходимости беспокоиться о потере качества или данных. 

**См. также**

[Клонирование слайдов](https://docs.aspose.com/slides/java/clone-slides/). 

{{% /alert %}}

### **Что Можно Объединять**

С помощью Aspose.Slides вы можете объединить 

* целые презентации. Все слайды из презентаций окажутся в одной презентации
* конкретные слайды. Выбранные слайды окажутся в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т. д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т. д.) друг с другом. 

{{% alert title="Примечание" color="warning" %}} 

Помимо презентаций, Aspose.Slides позволяет вам объединять и другие файлы:

* [Изображения](https://products.aspose.com/slides/java/merger/image-to-image/), такие как [JPG в JPG](https://products.aspose.com/slides/java/merger/jpg-to-jpg/) или [PNG в PNG](https://products.aspose.com/slides/java/merger/png-to-png/)
* Документы, такие как [PDF в PDF](https://products.aspose.com/slides/java/merger/pdf-to-pdf/) или [HTML в HTML](https://products.aspose.com/slides/java/merger/html-to-html/)
* А также два различных файла, такие как [изображение в PDF](https://products.aspose.com/slides/java/merger/image-to-pdf/) или [JPG в PDF](https://products.aspose.com/slides/java/merger/jpg-to-pdf/) или [TIFF в PDF](https://products.aspose.com/slides/java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Опции Объединения**

Вы можете применить опции, которые определяют, будет ли 

* каждый слайд в выходной презентации сохранять уникальный стиль
* используется ли один и тот же стиль для всех слайдов в выходной презентации. 

Для объединения презентаций Aspose.Slides предоставляет методы [AddClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (из интерфейса [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)). Существуют несколько реализаций методов `AddClone`, которые определяют параметры процесса объединения презентаций. Каждый объект презентации имеет коллекцию [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--), поэтому вы можете вызвать метод `AddClone` из презентации, в которую хотите объединить слайды. 

Метод `AddClone` возвращает объект `ISlide`, который является клоном исходного слайда. Слайды в выходной презентации просто являются копией слайдов из исходного. Поэтому вы можете вносить изменения в результирующие слайды (например, применять стили или параметры форматирования или макеты) без опасений, что исходные презентации будут затронуты. 

## **Объединение Презентаций** 

Aspose.Slides предоставляет метод [**AddClone(ISlide)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , который позволяет вам объединять слайды, при этом слайды сохраняют свои макеты и стили (параметры по умолчанию). 

Этот код на Java показывает, как объединить презентации:

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

## **Объединение Презентаций с Использованием Мастера Слайдов**

Aspose.Slides предоставляет метод [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) , который позволяет вам объединять слайды, применяя шаблон мастер-слайда презентации. Таким образом, если необходимо, вы можете изменить стиль для слайдов в выходной презентации. 

Этот код на Java демонстрирует описываемую операцию:

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

{{% alert title="Примечание" color="warning" %}} 

Макет слайда для мастера слайдов определяется автоматически. Когда подходящий макет не может быть определен, если булевый параметр `allowCloneMissingLayout` метода `AddClone` установлен в true, для исходного слайда используется его макет. В противном случае будет выброшено исключение [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException). 

{{% /alert %}}

Если вы хотите, чтобы слайды в выходной презентации имели другой макет слайдов, используйте вместо этого метод [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) при объединении. 

## **Объединение Конкретных Слайдов Из Презентаций**

Этот код на Java показывает, как выбрать и объединить определенные слайды из разных презентаций, чтобы получить одну выходную презентацию:

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

## **Объединение Презентаций С Макетом Слайда**

Этот код на Java показывает вам, как объединить слайды из презентаций, применяя предпочтительный макет слайда, чтобы получить одну выходную презентацию:

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

## **Объединение Презентаций С Разными Размером Слайдов**

{{% alert title="Примечание" color="warning" %}} 

Вы не можете объединять презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить 2 презентации с разными размерами слайдов, вам нужно изменить размер одной из презентаций, чтобы ее размер соответствовал размеру другой презентации. 

Этот пример кода демонстрирует описываемую операцию:

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

## **Объединение Слайдов В Секцию Презентации**

Этот код на Java показывает вам, как объединить конкретный слайд в секцию в презентации:

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

Слайд добавляется в конец секции. 

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб-приложение Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн-сервиса вы можете объединять [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG изображения, создавать [фото сетки](https://products.aspose.app/slides/collage/photo-grid) и так далее. 

{{% /alert %}}