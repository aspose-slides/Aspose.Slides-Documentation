---
title: Доступ к слайду в презентации
type: docs
weight: 20
url: /ru/nodejs-java/access-slide-in-presentation/
keywords: "Доступ к презентации PowerPoint, Доступ к слайду, Редактирование свойств слайда, Изменение позиции слайда, Установка номера слайда, индекс, ID, позиция Java, Aspose.Slides"
description: "Доступ к слайду PowerPoint по индексу, ID или позиции в JavaScript. Редактирование свойств слайда"
---

Aspose.Slides позволяет получать доступ к слайдам двумя способами: по индексу и по ID.

## **Получение слайда по индексу**

Все слайды в презентации упорядочены численно в соответствии с их позицией, начиная с 0. Первый слайд доступен по индексу 0; второй слайд — по индексу 1; и т.д.

Класс Presentation, представляющий файл презентации, предоставляет все слайды как коллекцию [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) (коллекцию объектов [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)). Этот JavaScript‑код показывает, как получить доступ к слайду по его индексу:
```javascript
// Создает объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Получает доступ к слайду, используя его индекс
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **Получение слайда по ID**

Каждый слайд в презентации имеет уникальный ID. Вы можете использовать метод [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (предоставляемый классом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)) для обращения к этому ID. Этот JavaScript‑код показывает, как передать действительный ID слайда и получить доступ к этому слайду с помощью метода [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-):
```javascript
// Создает объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Получает ID слайда
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Получает доступ к слайду по его ID
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **Изменение позиции слайда**

Aspose.Slides позволяет изменять позицию слайда. Например, вы можете указать, что первый слайд должен стать вторым.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите ссылку на слайд (позицию которого вы хотите изменить) по его индексу
1. Задайте новую позицию слайда с помощью свойства [setSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#setSlideNumber-int-).
1. Сохраните изменённую презентацию.

Этот JavaScript‑код демонстрирует операцию, в которой слайд в позиции 1 перемещается в позицию 2:
```javascript
// Создает объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Получает слайд, позиция которого будет изменена
    var sld = pres.getSlides().get_Item(0);
    // Устанавливает новую позицию для слайда
    sld.setSlideNumber(2);
    // Сохраняет изменённую презентацию
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Первый слайд стал вторым; второй слайд стал первым. При изменении позиции слайда остальные слайды автоматически корректируются.

## **Установка номера слайда**

С помощью свойства [setFirstSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (предоставляемого классом [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)) вы можете задать новый номер для первого слайда в презентации. Эта операция приводит к пере вычислению номеров остальных слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Получите номер слайда.
1. Установите номер слайда.
1. Сохраните изменённую презентацию.

Этот JavaScript‑код демонстрирует операцию, в которой номер первого слайда установлен в 10:
```javascript
// Создает объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Получает номер первого слайда
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Устанавливает номер первого слайда
    pres.setFirstSlideNumber(10);
    // Сохраняет изменённую презентацию
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Если вы хотите пропустить первый слайд, вы можете начать нумерацию со второго слайда (и скрыть нумерацию для первого слайда) следующим образом:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Устанавливает номер для первого слайда презентации
    presentation.setFirstSlideNumber(0);
    // Показывает номера слайдов для всех слайдов
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // Скрывает номер слайда для первого слайда
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // Сохраняет изменённую презентацию
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Соответствует ли номер слайда, видимый пользователем, нулевому индексу коллекции?**

Номер, отображаемый на слайде, может начинаться с произвольного значения (например, 10) и не обязан совпадать с индексом; связь контролируется настройкой [first slide number](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) презентации.

**Влияют ли скрытые слайды на индексацию?**

Да. Скрытый слайд остаётся в коллекции и учитывается при индексации; «скрытый» относится к отображению, а не к его позиции в коллекции.

**Изменяется ли индекс слайда при добавлении или удалении других слайдов?**

Да. Индексы всегда отражают текущий порядок слайдов и пересчитываются при вставке, удалении и перемещении.