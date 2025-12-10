---
title: Клонирование слайдов презентации в Java
linktitle: Клонировать слайды
type: docs
weight: 35
url: /ru/java/clone-slides/
keywords:
- клонировать слайд
- копировать слайд
- сохранить слайд
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Быстро дублируйте слайды PowerPoint с помощью Aspose.Slides для Java. Следуйте нашим понятным примерам кода, чтобы автоматизировать создание PPT за секунды и избавиться от ручной работы."
---

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for Java также позволяет сделать копию или клон любого слайда и затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который может быть изменён разработчиками без изменения исходного слайда. Существует несколько способов клонирования слайда:

- Клонировать в конец внутри презентации.
- Клонировать в другое положение внутри презентации.
- Клонировать в конец в другой презентации.
- Клонировать в другое положение в другой презентации.
- Клонировать в конкретное положение в другой презентации.

В Aspose.Slides for Java (коллекция объектов [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)) , доступная через объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), предоставляет методы [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-), позволяющие выполнять перечисленные типы клонирования слайдов

## **Клонирование слайда в конец презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) согласно шагам, перечисленным ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Создайте объект [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) , ссылаясь на коллекцию Slides, доступную через объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Вызовите метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , доступный объекту [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) , передав в него слайд, который нужно клонировать, в качестве параметра.
1. Запишите изменённый файл презентации.

В приведённом ниже примере мы клонировали слайд (расположенный на первой позиции – индекс 0 – презентации) в конец презентации.
```java
// Создать экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Клонировать выбранный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Записать изменённую презентацию на диск
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Клонирование слайда в другое положение внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом положении, используйте метод [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Создайте объект, ссылаясь на коллекцию **Slides**, доступную через объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) , доступный объекту [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) , передав в него слайд, который нужно клонировать, вместе с индексом нового положения в качестве параметра.
1. Запишите изменённую презентацию в формате PPTX.

В приведённом ниже примере мы клонировали слайд (расположенный на нулевом индексе – позиция 1 – презентации) в индекс 1 – позицию 2 – презентации.
```java
// Создать экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Клонировать выбранный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    // Клонировать выбранный слайд в указанный индекс в той же презентации
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Записать изменённую презентацию на диск
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Клонирование слайда в конец другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащего презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащего целевую презентацию, в которую будет добавлен слайд.
1. Создайте объект [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) , ссылаясь на коллекцию **Slides**, доступную через объект Presentation целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , доступный объекту [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) , передав в него слайд из исходной презентации в качестве параметра.
1. Запишите изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.
```java
// Создать экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонировать выбранный слайд из исходной презентации в конец коллекции слайдов в целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Записать целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Клонирование слайда в другое положение в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в конкретном положении:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащего презентацию, в которую будет добавлен слайд.
1. Создайте объект [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) , ссылаясь на коллекцию Slides, доступную через объект Presentation целевой презентации.
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) , доступный объекту [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) , передав в него слайд из исходной презентации вместе с желаемым положением в качестве параметра.
1. Запишите изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.
```java
// Создать экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создать экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонировать выбранный слайд из исходной презентации в конец коллекции слайдов в целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Записать целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Клонирование слайда в конкретное положение в другой презентации**
Если вам нужно клонировать слайд с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно клонировать нужный мастер‑слайд из исходной презентации в целевую. Затем используйте этот мастер‑слайд для клонирования слайда с мастер‑слайдом. Метод [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер‑слайдом, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащего целевую презентацию, в которую будет клонироваться слайд.
1. Доступ к слайду, подлежащему клонированию, вместе с его мастер‑слайдом.
1. Создайте объект [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) , ссылаясь на коллекцию Masters, доступную через объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , доступный объекту [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection), передав мастер‑слайд из исходного PPTX в качестве параметра.
1. Создайте объект [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) , установив ссылку на коллекцию Slides, доступную через объект [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , доступный объекту [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) , передав в него слайд из исходной презентации для клонирования и мастер‑слайд в качестве параметра.
1. Запишите изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд с мастер‑слайдом (расположенный на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.
```java
// Создать экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Создать экземпляр класса Presentation для целевой презентации (куда будет клонирован слайд)
    Presentation destPres = new Presentation();
    try {
        // Создать ISlide из коллекции слайдов в исходной презентации вместе с
        // Мастер‑слайдом
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонировать требуемый мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонировать требуемый мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Клонировать требуемый слайд из исходной презентации с нужным мастером в конец
        // коллекции слайдов в целевой презентации
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Сохранить целевую презентацию на диск
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Клонирование слайда в конец указанного раздела**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) , доступный интерфейсу [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java позволяет клонировать слайд из первого раздела и затем вставить его во второй раздел той же презентации.

Следующий фрагмент кода показывает, как клонировать слайд и вставить его в указанный раздел.
```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
    // Сохранить целевую презентацию на диск
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**Клонируются ли заметки докладчика и комментарии рецензентов?**

Да. Страница заметок и комментарии рецензентов включены в клон. Если вы не хотите их, [удалите их](/slides/ru/java/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, встраиваемой OLE‑книгой), связь сохраняется как [OLE‑объект](/slides/ru/java/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Могу ли я управлять позицией вставки и разделами клона?**

Да. Вы можете вставить клон в конкретный индекс слайда и разместить его в выбранном [разделе](/slides/ru/java/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд туда.