---
title: Клонирование слайдов презентации на Android
linktitle: Клонировать слайды
type: docs
weight: 35
url: /ru/androidjava/clone-slides/
keywords:
- клонировать слайд
- копировать слайд
- сохранить слайд
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Дублирование слайдов PowerPoint с помощью Aspose.Slides для Android. Следуйте нашим понятным примерам кода на Java, чтобы автоматизировать создание PPT за считанные секунды и избавиться от ручной работы."
---

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for Android via Java также позволяет создать копию или клон любого слайда и затем вставить этот клон в текущую или любую другую открытую презентацию. При клонировании слайда создаётся новый слайд, который разработчики могут изменять, не затрагивая оригинал. Существует несколько способов клонирования слайда:

- Клонировать в конец внутри презентации.
- Клонировать в другое положение внутри презентации.
- Клонировать в конец в другой презентации.
- Клонировать в другое положение в другой презентации.
- Клонировать в указанное положение в другой презентации.

В Aspose.Slides for Android via Java (коллекция объектов [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)) , доступная через объект [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), предоставляет методы [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) для выполнения перечисленных видов клонирования слайдов.

## **Клонирование слайда в конец презентации**
Если необходимо клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) согласно следующей последовательности:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите объект [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) через свойство Slides презентации.
3. Вызовите метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте слайд, который нужно клонировать, в качестве параметра.
4. Сохраните изменённый файл презентации.

В примере ниже мы клонировали слайд (находившийся на первой позиции — индекс 0 — презентации) в конец презентации.
```java
// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Клонируйте нужный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Запишите изменённую презентацию на диск
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Клонирование слайда в другое положение внутри презентации**
Если нужно клонировать слайд и использовать его в том же файле презентации, но в другом месте, используйте метод [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите объект [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) у презентации.
3. Вызовите метод [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте слайд для клонирования вместе с индексом новой позиции.
4. Сохраните изменённый документ в формате PPTX.

В примере ниже мы клонировали слайд (находившийся на нулевом индексе — позиция 1 — презентации) в индекс 1 — позиция 2 — презентации.
```java
// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Клонируйте нужный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    // Клонируйте нужный слайд в указанный индекс в той же презентации
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Запишите изменённую презентацию на диск
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Клонирование слайда в конец другой презентации**
Если необходимо клонировать слайд из одной презентации и добавить его в другую презентацию в конец существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащей исходную презентацию.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащей целевую презентацию.
3. Получите объект [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) через коллекцию [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) целевой презентации.
4. Вызовите метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте в него слайд из исходной презентации.
5. Сохраните изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (с первого индекса исходной презентации) в конец целевой презентации.
```java
// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создайте экземпляр класса Presentation для целевой PPTX (куда будет клонироваться слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонируйте нужный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Запишите целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Клонирование слайда в другое положение в другой презентации**
Если необходимо клонировать слайд из одной презентации и разместить его в другой презентации в определённом месте:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) с исходной презентацией.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) с целевой презентацией.
3. Получите объект [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) через коллекцию Slides целевой презентации.
4. Вызовите метод [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации вместе с требуемым индексом позиции.
5. Сохраните изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (с нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.
```java
// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонироваться слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонируйте нужный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Запишите целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Клонирование слайда в конкретном положении в другой презентации**
Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой, сперва нужно склонировать нужный мастер‑слайд из исходной презентации в целевую. Затем используйте этот мастер‑слайд при клонировании слайда. Метод [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) с исходной презентацией.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) с целевой презентацией.
3. Получите доступ к клонируемому слайду вместе с его мастер‑слайдом.
4. Получите объект [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) через коллекцию Masters целевой презентации.
5. Вызовите метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) и передайте мастер‑слайд из исходного PPTX.
6. Получите объект [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) через коллекцию Slides целевой презентации.
7. Вызовите метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) у объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте в него слайд из исходной презентации и мастер‑слайд.
8. Сохраните изменённый файл целевой презентации.

В примере ниже мы клонировали слайд с мастером (находившийся на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.
```java
// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Создайте экземпляр класса Presentation для целевой презентации (куда будет клонироваться слайд)
    Presentation destPres = new Presentation();
    try {
        // Получите ISlide из коллекции слайдов исходной презентации вместе с
        // Мастер‑слайдом
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонируйте нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонируйте нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Клонируйте нужный слайд из исходной презентации с выбранным мастером в конец
        // коллекции слайдов в целевой презентации
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Сохраните целевую презентацию на диск
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Клонирование слайда в конец указанного раздела**
Если нужно клонировать слайд и разместить его в том же файле презентации, но в другом разделе, используйте метод [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) интерфейса [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides for Android via Java позволяет клонировать слайд из первого раздела и вставить его во второй раздел той же презентации.

Следующий фрагмент кода демонстрирует, как клонировать слайд и вставить его в указанный раздел.
```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Сохраните целевую презентацию на диск
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Часто задаваемые вопросы**

**Клонируются ли заметки к спикеру и комментарии рецензентов?**

Да. Страницы заметок и комментарии включаются в клон. Если они не нужны, [удалите их](/slides/ru/androidjava/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, OLE‑встроенной книгой), связь сохраняется как [OLE‑объект](/slides/ru/androidjava/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Можно ли управлять позицией вставки и разделами клона?**

Да. Вы можете вставить клон в конкретный индекс слайда и поместить его в выбранный [раздел](/slides/ru/androidjava/slide-section/). Если целевой раздел отсутствует, создайте его заранее и переместите слайд туда.