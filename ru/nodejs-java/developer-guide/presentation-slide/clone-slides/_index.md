---
title: Клонирование слайдов презентации в JavaScript
linktitle: Клонировать слайды
type: docs
weight: 35
url: /ru/nodejs-java/clone-slides/
keywords:
- клонировать слайд
- копировать слайд
- сохранять слайд
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Быстро дублируйте слайды PowerPoint с помощью Aspose.Slides for Node.js. Следуйте нашим примерам кода, чтобы автоматизировать создание PPT за секунды и избавиться от ручной работы."
---
## **Введение**

Клонирование — это процесс создания точной копии или реплики чего‑то. Aspose.Slides for Node.js via Java также позволяет создавать копию или клон любого слайда, а затем вставлять этот клонированный слайд в текущую или любую другую открывшуюся презентацию. Процесс клонирования слайда создаёт новый слайд, который разработчики могут изменять, не меняя оригинальный слайд. Существует несколько способов клонирования слайда:

- Клонирование в конец внутри презентации.  
- Клонирование в другое место внутри презентации.  
- Клонирование в конец в другой презентации.  
- Клонирование в другое место в другой презентации.  
- Клонирование в определённую позицию в другой презентации.  

В Aspose.Slides for Node.js via Java (коллекция объектов [Slide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Slide)), предоставляемая объектом [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation), предлагает методы [addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-), позволяющие выполнять перечисленные типы клонирования слайдов.

## **Клонирование в конец внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) согласно шагам, перечисленным ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Создайте экземпляр класса [SlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , ссылаясь на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
3. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) у объекта [SlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , передав в него слайд, который нужно клонировать, в качестве параметра.
4. Запишите изменённый файл презентации.

В примере ниже мы клонировали слайд (находящийся на первой позиции – ноль индекс – презентации) в конец презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создать экземпляр класса Presentation, представляющего файл презентации
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Клонировать нужный слайд в конец коллекции слайдов в той же презентации
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Записать изменённую презентацию на диск
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонирование в другое положение внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другой позиции, используйте метод [insertClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Создайте экземпляр, ссылаясь на коллекцию [**Slides**](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
3. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) у объекта [SlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , передав в него слайд, который нужно клонировать, вместе с индексом новой позиции в качестве параметра.
4. Запишите изменённую презентацию в виде файла PPTX.

В примере ниже мы клонировали слайд (находящийся на индексе 1 – позиция 2 презентации) в индекс 2 – позиция 3 презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создать экземпляр класса Presentation, представляющего файл презентации
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Клонировать нужный слайд в конец коллекции слайдов в той же презентации
    var slds = pres.getSlides();
    // Клонировать нужный слайд в указанный индекс в той же презентации
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Записать изменённую презентацию на диск
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонирование в конец в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation), содержащий презентацию, из которой будет клонирован слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation), содержащий целевую презентацию, в которую будет добавлен слайд.
3. Создайте экземпляр класса [SlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection) , ссылаясь на коллекцию [**Slides**](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , предоставляемую объектом Presentation целевой презентации.
4. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) у объекта [SlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , передав в него слайд из исходной презентации в качестве параметра.
5. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создать экземпляр класса Presentation для загрузки исходного файла презентации
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    var destPres = new aspose.slides.Presentation();
    try {
        // Клонировать нужный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Записать целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонирование в другое положение в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в определённой позиции:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонирован слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation), содержащий презентацию, в которую будет добавлен слайд.
3. Создайте экземпляр класса [SlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , ссылаясь на коллекцию Slides, предоставляемую объектом Presentation целевой презентации.
4. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) у объекта [SlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , передав в него слайд из исходной презентации вместе с желаемой позицией в качестве параметра.
5. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создать экземпляр класса Presentation для загрузки исходного файла презентации
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    var destPres = new aspose.slides.Presentation();
    try {
        // Клонировать нужный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Записать целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонирование в определённую позицию в другой презентации**
Если вам нужно клонировать слайд с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала необходимо клонировать нужный мастер‑слайд из исходной презентации в целевую. Затем этот мастер‑слайд используется для клонирования слайда с мастер‑слайдом. Метод [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонирован слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation), содержащий целевую презентацию, в которую будет клонирован слайд.
3. Получите слайд, подлежащий клонированию, вместе с мастер‑слайдом.
4. Создайте экземпляр класса [MasterSlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/MasterSlideCollection) , ссылаясь на коллекцию Masters, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation) целевой презентации.
5. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) у объекта [MasterSlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/MasterSlideCollection) , передав в него мастер‑слайд из исходного PPTX в качестве параметра.
6. Создайте экземпляр класса [SlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , установив ссылку на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation) целевой презентации.
7. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) у объекта [SlideCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation#getSlides--) , передав в него слайд из исходной презентации, который нужно клонировать, и мастер‑слайд в качестве параметров.
8. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд с мастером (находящийся в нулевом индексе исходной презентации) в конец целевой презентации, используя мастер из исходного слайда.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Создать экземпляр класса Presentation для загрузки исходного файла презентации
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Создать экземпляр класса Presentation для целевой презентации (куда будет клонирован слайд)
    var destPres = new aspose.slides.Presentation();
    try {
        // Получить ISlide из коллекции слайдов исходной презентации вместе с
        // мастер‑слайдом
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Клонировать нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Клонировать нужный слайд из исходной презентации с выбранным мастер‑слайдом в конец
        // коллекции слайдов целевой презентации
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Сохранить целевую презентацию на диск
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонирование в конец в указанном разделе**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [**addClone**](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) , предоставляемый классом [**SlideCollection**](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java делает возможным клонирование слайда из первого раздела и последующее вставление этого клонированного слайда во второй раздел той же презентации.

Следующий фрагмент кода показывает, как клонировать слайд и вставить его в указанный раздел.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Сохранить целевую презентацию на диск
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Обеспечение совпадения размера слайдов**

При клонировании слайдов в другую презентацию убедитесь, что целевая презентация имеет тот же размер слайда, что и исходная. Если размеры слайдов различаются, Aspose.Slides не масштабирует автоматически клонированные объекты — их исходные координаты и размеры сохраняются, что может привести к смещению содержимого или выходу его за границы слайда.

Вы можете установить размер слайда целевой презентации, соответствующий размеру исходной, перед клонированием мастера и слайда:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Сделайте это до клонирования мастера и слайда.

## **FAQ**

**Клонируются ли заметки к спикеру и комментарии рецензентов?**  
Да. Страница с заметками и комментарии рецензентов включаются в клон. Если вы не хотите их, [удалите их](/slides/ru/nodejs-java/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**  
Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, с OLE‑встроенной книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/nodejs-java/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Могу ли я управлять позицией вставки и разделами для клона?**  
Да. Вы можете вставить клон на определённый индекс слайда и разместить его в выбранном [разделе](/slides/ru/nodejs-java/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд в него.