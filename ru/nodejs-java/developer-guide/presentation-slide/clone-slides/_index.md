---
title: Клонирование слайдов
type: docs
weight: 35
url: /ru/nodejs-java/clone-slides/
---

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for Node.js via Java также позволяет создать копию или клон любого слайда и затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который разработчики могут изменять, не меняя оригинальный слайд. Существует несколько способов клонирования слайда:

- Клонировать в конец в пределах презентации.  
- Клонировать в другую позицию в пределах презентации.  
- Клонировать в конец в другой презентации.  
- Клонировать в другую позицию в другой презентации.  
- Клонировать в определённую позицию в другой презентации.  

В Aspose.Slides for Node.js via Java (коллекция объектов [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) ), доступная через объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), предоставляет методы [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-), позволяющие выполнять перечисленные типы клонирования слайдов.

## **Клонирование в конец в пределах презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) согласно приведённым ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Создайте объект [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) , получив доступ к коллекции Slides, доступной через объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
3. Вызовите метод [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) , передав в него слайд, который необходимо клонировать.  
4. Сохраните изменённый файл презентации.  

В примере ниже мы клонировали слайд (находящийся на первой позиции – нулевой индекс – презентации) в конец презентации.  
```javascript
// Создайте объект класса Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Клонируйте нужный слайд в конец коллекции слайдов той же презентации
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Сохраните изменённую презентацию на диск
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Клонирование в другую позицию в пределах презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другой позиции, используйте метод [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Создайте объект, ссылаясь на коллекцию **Slides** ([Presentation#getSlides--](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)), доступную через объект [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
3. Вызовите метод [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) , передав в него слайд, который необходимо клонировать, а также индекс новой позиции.  
4. Сохраните изменённую презентацию в формате PPTX.  

В примере ниже мы клонировали слайд (находящийся на нулевом индексе – позиция 1 – презентации) в индекс 1 – позицию 2 презентации.  
```javascript
// Создайте объект класса Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Клонируйте нужный слайд в конец коллекции слайдов той же презентации
    var slds = pres.getSlides();
    // Клонируйте нужный слайд в указанный индекс в той же презентации
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Сохраните изменённую презентацию на диск
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Клонирование в конец в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащий презентацию, из которой будет клонироваться слайд.  
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащий целевую презентацию, в которую будет добавлен слайд.  
3. Создайте объект [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) , получив доступ к коллекции **Slides** ([Presentation#getSlides--](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)) объекта целевой презентации.  
4. Вызовите метод [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) , передав в него слайд из исходной презентации.  
5. Сохраните изменённый файл целевой презентации.  

В примере ниже мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.  
```javascript
// Создайте объект класса Presentation для загрузки исходного файла презентации
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создайте объект класса Presentation для целевой PPTX (куда будет клонирован слайд)
    var destPres = new aspose.slides.Presentation();
    try {
        // Клонируйте нужный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Сохраните целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Клонирование в другую позицию в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации, в определённой позиции:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.  
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащий презентацию, в которую будет добавлен слайд.  
3. Создайте объект [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) , получив доступ к коллекции Slides объекта целевой презентации.  
4. Вызовите метод [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) , передав в него слайд из исходной презентации и желаемую позицию.  
5. Сохраните изменённый файл целевой презентации.  

В примере ниже мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.  
```javascript
// Создайте объект класса Presentation для загрузки исходного файла презентации
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создайте объект класса Presentation для целевой PPTX (куда будет клонирован слайд)
    var destPres = new aspose.slides.Presentation();
    try {
        // Клонируйте нужный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Сохраните целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Клонирование в определённую позицию в другой презентации**
Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно клонировать нужный мастер‑слайд из исходной презентации в целевую. Затем следует использовать этот мастер‑слайд при клонировании слайда. Метод [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер‑слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.  
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), содержащий целевую презентацию, в которую будет клонироваться слайд.  
3. Получите слайд, который нужно клонировать, вместе с его мастер‑слайдом.  
4. Создайте объект [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) , получив доступ к коллекции Masters объекта целевой презентации.  
5. Вызовите метод [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) у объекта [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection), передав в него мастер‑слайд из исходного PPTX, который необходимо клонировать.  
6. Создайте объект [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) , получив доступ к коллекции Slides объекта целевой презентации.  
7. Вызовите метод [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) у объекта [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--), передав в него слайд из исходной презентации и мастер‑слайд в качестве параметров.  
8. Сохраните изменённый файл целевой презентации.  

В примере ниже мы клонировали слайд с мастер‑слайдом (находящийся на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.  
```javascript
// Создайте объект класса Presentation для загрузки исходного файла презентации
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Создайте объект класса Presentation для целевой презентации (куда будет клонирован слайд)
    var destPres = new aspose.slides.Presentation();
    try {
        // Получите объект ISlide из коллекции слайдов исходной презентации вместе с
        // мастер‑слайдом
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Клонируйте нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Клонируйте нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        var iSlide = masters.addClone(SourceMaster);
        // Клонируйте нужный слайд из исходной презентации с нужным мастером в конец
        // коллекции слайдов целевой презентации
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Сохраните целевую презентацию на диск
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Клонирование в конец в указанном разделе**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) объекта [**SlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java позволяет клонировать слайд из первого раздела и вставлять его во второй раздел той же презентации.

Ниже приведён фрагмент кода, показывающий, как клонировать слайд и вставить его в указанный раздел.  
```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Сохраните целевую презентацию на диск
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Клонируются ли примечания к выступающим и комментарии рецензентов?**  
Да. Страница заметок и комментарии рецензентов включаются в клон. Если вы не хотите их, [удалите их](/slides/ru/nodejs-java/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**  
Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, рабочей книгой OLE), эта связь сохраняется как [OLE‑объект](/slides/ru/nodejs-java/manage-ole/). После переноса между файлами проверьте доступность данных и поведение обновления.

**Могу ли я контролировать позицию вставки и разделы клона?**  
Да. Вы можете вставить клон в конкретный индекс слайда и разместить его в выбранном [разделе](/slides/ru/nodejs-java/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд.