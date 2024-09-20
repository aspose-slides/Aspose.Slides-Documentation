---
title: Доступ к слайду в презентации
type: docs
weight: 20
url: /java/access-slide-in-presentation/
keywords: "Доступ к презентации PowerPoint, Доступ к слайду, Редактировать свойства слайда, Изменить позицию слайда, Установить номер слайда, индекс, ID, позиция Java, Aspose.Slides"
description: "Получите доступ к слайду PowerPoint по индексу, ID или позиции в Java. Редактируйте свойства слайда"
---

Aspose.Slides позволяет вам получить доступ к слайдам двумя способами: по индексу и по ID.

## **Доступ к слайду по индексу**

Все слайды в презентации располагаются по порядку, начиная с 0. Первый слайд доступен по индексу 0; второй слайд — по индексу 1; и так далее.

Класс Presentation, представляющий файл презентации, предоставляет все слайды в виде коллекции [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) (коллекция объектов [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)). Этот код на Java показывает, как получить доступ к слайду по его индексу: 

```java
// Создает объект Presentation, который представляет файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    // Получает слайд по индексу слайда
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Доступ к слайду по ID**

Каждый слайд в презентации имеет уникальный ID, связанный с ним. Вы можете использовать метод [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-) (предоставленный классом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)), чтобы обратиться к этому ID. Этот код на Java показывает, как предоставить действительный ID слайда и получить доступ к этому слайду через метод [getSlideById](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlideById-long-):

```java
// Создает объект Presentation, который представляет файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    // Получает ID слайда
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Получает доступ к слайду по его ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Изменение позиции слайда**

Aspose.Slides позволяет вам изменить позицию слайда. Например, вы можете указать, чтобы первый слайд стал вторым.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите ссылку на слайд (позицию которого вы хотите изменить) по его индексу.
1. Установите новую позицию для слайда через свойство [setSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#setSlideNumber-int-).
1. Сохраните измененную презентацию.

Этот код на Java демонстрирует операцию, в которой слайд в позиции 1 перемещается в позицию 2: 

```java
// Создает объект Presentation, который представляет файл презентации
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Получает слайд, позиция которого будет изменена
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Устанавливает новую позицию для слайда
    sld.setSlideNumber(2);
    
    // Сохраняет измененную презентацию
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Первый слайд стал вторым; второй слайд стал первым. При изменении позиции слайда другие слайды автоматически подстраиваются.


## **Установка номера слайда**

Используя свойство [setFirstSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (предоставленное классом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)), вы можете указать новый номер для первого слайда в презентации. Эта операция вызывает перерасчет других номеров слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Получите номер слайда.
1. Установите номер слайда.
1. Сохраните измененную презентацию.

Этот код на Java демонстрирует операцию, в которой номер первого слайда устанавливается на 10: 

```java
// Создает объект Presentation, который представляет файл презентации
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Получает номер слайда
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Устанавливает номер слайда
    pres.setFirstSlideNumber(10);
	
    // Сохраняет измененную презентацию
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Если вы предпочитаете пропустить первый слайд, вы можете начать нумерацию со второго слайда (и скрыть нумерацию для первого слайда) таким образом:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Устанавливает номер для первого слайда презентации
    presentation.setFirstSlideNumber(0);

    // Показывает номера слайдов для всех слайдов
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Скрывает номер слайда для первого слайда
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Сохраняет измененную презентацию
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```