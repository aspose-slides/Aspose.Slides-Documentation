---
title: Доступ к слайду в презентации
type: docs
weight: 20
url: /androidjava/access-slide-in-presentation/
keywords: "Доступ к PowerPoint презентации, Доступ к слайду, Изменение свойств слайда, Изменение позиции слайда, Установка номера слайда, индекса, ID, позиции Java, Aspose.Slides"
description: "Доступ к слайду PowerPoint по индексу, ID или позиции в Java. Изменение свойств слайда"
---

Aspose.Slides позволяет получать доступ к слайдам двумя способами: по индексу и по ID.

## **Доступ к слайду по индексу**

Все слайды в презентации располагаются в числовом порядке в зависимости от позиции слайда, начиная с 0. Первый слайд доступен по индексу 0; второй слайд — по индексу 1; и так далее.

Класс Presentation, представляющий файл презентации, предоставляет все слайды в коллекции [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) (коллекция объектов [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)). Этот код на Java показывает, как получить доступ к слайду по его индексу:

```java
// Создает объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("demo.pptx");
try {
    // Получает слайд, используя его индекс
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Доступ к слайду по ID**

Каждый слайд в презентации имеет уникальный ID. Вы можете использовать метод [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (предоставляемый классом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)), чтобы получить доступ к этому ID. Этот код на Java показывает, как указать действительный ID слайда и получить доступ к этому слайду через метод [getSlideById](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlideById-long-):

```java
// Создает объект Presentation, представляющий файл презентации
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

Aspose.Slides позволяет вам изменять позицию слайда. Например, вы можете указать, что первый слайд должен стать вторым.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите ссылку на слайд (позицию которого вы хотите изменить) по его индексу.
1. Установите новую позицию для слайда через свойство [setSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).
1. Сохраните измененную презентацию.

Этот код на Java демонстрирует операцию, в которой слайд на позиции 1 перемещается на позицию 2:

```java
// Создает объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Получает слайд, позицию которого нужно изменить
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Устанавливает новую позицию для слайда
    sld.setSlideNumber(2);
    
    // Сохраняет измененную презентацию
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Первый слайд стал вторым; второй слайд стал первым. Когда вы изменяете позицию слайда, другие слайды автоматически корректируются.

## **Установка номера слайда**

С помощью свойства [setFirstSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (предоставляемого классом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)) вы можете указать новый номер для первого слайда в презентации. Эта операция приводит к перерасчету номеров других слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Получите номер слайда.
1. Установите номер слайда.
1. Сохраните измененную презентацию.

Этот код на Java демонстрирует операцию, в которой номер первого слайда устанавливается на 10:

```java
// Создает объект Presentation, представляющий файл презентации
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

Если вы хотите пропустить первый слайд, вы можете начать нумерацию со второго слайда (и скрыть нумерацию для первого слайда) следующим образом:

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