---
title: Слияние презентаций
type: docs
weight: 40
url: /androidjava/merge-presentation/
keywords: "Слияние PowerPoint, PPTX, PPT, объединить PowerPoint, слияние презентации, объединить презентацию, Java"
description: "Слияние или объединение презентаций PowerPoint на Java"
---


{{% alert  title="Совет" color="primary" %}} 

Вам может быть интересно попробовать **бесплатное онлайн-приложение** [Merger от Aspose](https://products.aspose.app/slides/merger). Оно позволяет объединять презентации PowerPoint в одном и том же формате (PPT в PPT, PPTX в PPTX и т. д.) и объединять презентации в разных форматах (PPT в PPTX, PPTX в ODP и т. д.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Слияние презентаций**

Когда вы объединяете одну презентацию с другой, вы фактически комбинируете их слайды в единую презентацию, чтобы получить один файл.

{{% alert title="Информация" color="info" %}}

Большинство программ для создания презентаций (PowerPoint или OpenOffice) не имеют функций, позволяющих пользователям объединять презентации таким образом.

Тем не менее, [**Aspose.Slides для Android через Java**](https://products.aspose.com/slides/androidjava/) позволяет вам объединять презентации различными способами. Вы можете объединять презентации со всеми их фигурами, стилями, текстами, форматированием, комментариями, анимациями и т.д., не беспокоясь о потере качества или данных.

**См. также**

[Клонирование слайдов](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Что можно объединить**

С помощью Aspose.Slides вы можете объединить 

* целые презентации. Все слайды из презентаций оказываются в одной презентации
* конкретные слайды. Отобранные слайды оказываются в одной презентации
* презентации в одном формате (PPT в PPT, PPTX в PPTX и т. д.) и в разных форматах (PPT в PPTX, PPTX в ODP и т. д.) с друг другом.

{{% alert title="Примечание" color="warning" %}} 

Кроме презентаций, Aspose.Slides позволяет объединять другие файлы:

* [Изображения](https://products.aspose.com/slides/androidjava/merger/image-to-image/), такие как [JPG в JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) или [PNG в PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* Документы, такие как [PDF в PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) или [HTML в HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* И два разных файла, такие как [изображение в PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/) или [JPG в PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) или [TIFF в PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **Опции слияния**

Вы можете применить параметры, которые определяют, будет ли

* каждый слайд в выходной презентации сохранять уникальный стиль
* использоваться определенный стиль для всех слайдов в выходной презентации. 

Для слияния презентаций Aspose.Slides предоставляет методы [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (из интерфейса [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)). Существует несколько реализаций методов `AddClone`, которые определяют параметры процесса слияния презентаций. Каждый объект Presentation имеет коллекцию [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--), поэтому вы можете вызвать метод `AddClone` из презентации, в которую хотите объединить слайды.

Метод `AddClone` возвращает объект `ISlide`, который является клоном исходного слайда. Слайды в выходной презентации являются просто копией слайдов из источника. Следовательно, вы можете вносить изменения в результирующие слайды (например, применять стили или параметры форматирования или макеты), не беспокоясь о том, что исходные презентации будут затронуты. 

## **Объединение презентаций** 

Aspose.Slides предоставляет метод [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , который позволяет вам объединять слайды, сохраняя их макеты и стили (по умолчанию).

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

## **Объединение презентаций с мастер-слайдом**

Aspose.Slides предоставляет метод [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) , который позволяет вам объединять слайды, применяя шаблон мастер-презентации. Таким образом, если необходимо, вы можете изменить стиль для слайдов в выходной презентации.

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

{{% alert title="Примечание" color="warning" %}} 

Макет слайда для мастер-слайда определяется автоматически. Когда подходящий макет не может быть определен, если булевый параметр `allowCloneMissingLayout` метода `AddClone` установлен в true, используется макет исходного слайда. В противном случае будет выдано исключение [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

Если вы хотите, чтобы слайды в выходной презентации имели другой макет, используйте метод [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) вместо этого при слиянии.

## **Объединение конкретных слайдов из презентаций**

Этот код на Java показывает, как выбрать и объединить конкретные слайды из разных презентаций, чтобы получить одну выходную презентацию:

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

## **Объединение презентаций с макетом слайда**

Этот код на Java показывает, как объединить слайды из презентаций, применяя предпочитаемый макет слайда к ним, чтобы получить одну выходную презентацию:

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

{{% alert title="Примечание" color="warning" %}} 

Вы не можете объединить презентации с разными размерами слайдов. 

{{% /alert %}}

Чтобы объединить 2 презентации с разными размерами слайдов, вам нужно изменить размер одной из презентаций, чтобы его размер соответствовал размеру другой презентации.

Этот образец кода демонстрирует описанную операцию:

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

Этот код на Java показывает, как объединить конкретный слайд в раздел презентации:

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

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет [БЕСПЛАТНОЕ веб-приложение Collage](https://products.aspose.app/slides/collage). С помощью этого онлайн-сервиса вы можете объединить [JPG в JPG](https://products.aspose.app/slides/collage/jpg) или PNG в PNG изображения, создавать [фото-сетки](https://products.aspose.app/slides/collage/photo-grid) и многое другое.

{{% /alert %}}