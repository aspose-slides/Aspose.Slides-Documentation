---
title: Удалить слайд из презентации
type: docs
weight: 30
url: /ru/androidjava/remove-slide-from-presentation/
keywords: "Удалить слайд, Удалить слайд, PowerPoint, Презентация, Java, Aspose.Slides"
description: "Удалить слайд из PowerPoint по ссылке или индексу в Java"

---

Если слайд (или его содержимое) становится избыточным, вы можете удалить его. Aspose.Slides предоставляет класс [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), который инкапсулирует [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/), который является хранилищем для всех слайдов в презентации. Используя указатели (ссылка или индекс) для известного объекта [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/), вы можете указать слайд, который хотите удалить.

## **Удалить слайд по ссылке**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд, который вы хотите удалить, через его ID или индекс.
1. Удалите указанный слайд из презентации.
1. Сохраните измененную презентацию. 

Этот код на Java показывает, как удалить слайд через его ссылку:

```java
// Создайте объект Presentation, который представляет файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    // Получает доступ к слайду через его индекс в коллекции слайдов
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Удаляет слайд через его ссылку
    pres.getSlides().remove(slide);
    
    // Сохраняет измененную презентацию
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Удалить слайд по индексу**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Удалите слайд из презентации по его индексной позиции.
1. Сохраните измененную презентацию. 

Этот код на Java показывает, как удалить слайд через его индекс:

```java
// Создает объект Presentation, который представляет файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    // Удаляет слайд по его индексу
    pres.getSlides().removeAt(0);
    
    // Сохраняет измененную презентацию
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Удалить неиспользуемый макет слайда**

Aspose.Slides предоставляет метод [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (из класса [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)), который позволяет вам удалить нежелательные и неиспользуемые макетные слайды. Этот код на Java показывает, как удалить макет слайда из презентации PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удалить неиспользуемый мастер-слайд**

Aspose.Slides предоставляет метод [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (из класса [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)), который позволяет вам удалить нежелательные и неиспользуемые мастер-слайды. Этот код на Java показывает, как удалить мастер-слайд из презентации PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```