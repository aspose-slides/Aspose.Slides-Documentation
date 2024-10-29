---
title: Клонирование слайдов
type: docs
weight: 35
url: /ru/java/clone-slides/
---

## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего-либо. Aspose.Slides для Java также позволяет создать копию или клон любого слайда и затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайдов создает новый слайд, который может быть изменен разработчиками, не изменяя оригинальный слайд. Существует несколько возможных способов клонирования слайда:

- Клонировать в конце презентации.
- Клонировать в другое место в презентации.
- Клонировать в конце другой презентации.
- Клонировать в другое место в другой презентации.
- Клонировать в определенное место в другой презентации.

В Aspose.Slides для Java (коллекция объектов [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)), предоставляемая объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), имеет методы [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) для выполнения вышеуказанных типов клонирования слайдов.

## **Клонировать в конце презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) согласно приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) ссылаясь на коллекцию слайдов, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Вызовите метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) предоставленный объектом [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) и передайте слайд, который необходимо клонировать, в качестве параметра в метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Запишите измененный файл презентации.

В приведенном ниже примере мы склонировали слайд (находящийся на первой позиции – нулевой индекс – презентации) в конец презентации.

```java
// Создайте экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Клонируйте нужный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Запишите измененную презентацию на диск
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонировать в другое место в презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом месте, используйте метод [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Создайте экземпляр класса, ссылаясь на коллекцию [**Слайды**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) предоставленную объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) предоставленный объектом [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) и передайте слайд, который необходимо клонировать вместе с индексом для нового положения в качестве параметра в метод [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Запишите измененную презентацию как файл PPTX.

В приведенном ниже примере мы склонировали слайд (находящийся на нулевом индексе – позиции 1 – презентации) на индекс 1 – позицию 2 – презентации.

```java
// Создайте экземпляр класса Presentation, представляющий файл презентации
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Клонируйте нужный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    // Клонируйте нужный слайд на указанный индекс в той же презентации
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Запишите измененную презентацию на диск
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонировать в конце другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другом файле презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащий презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащий целевую презентацию, куда будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection), ссылаясь на коллекцию [**Слайды**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) предоставляемую объектом презентации назначения.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) предоставленный объектом [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации в качестве параметра в метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы склонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.

```java
// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонироваться слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонируйте нужный слайд из исходной презентации в конец коллекции слайдов в целевой презентации
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

## **Клонировать в другое место в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другой презентации, в определенном месте:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащий презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) ссылаясь на коллекцию слайдов, предоставляемую объектом презентации назначения.
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) предоставленный объектом [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметра в метод [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы склонировали слайд (из нулевого индекса источника презентации) на индекс 1 (позиция 2) целевой презентации.

```java
// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонироваться слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонируйте нужный слайд из исходной презентации в конец коллекции слайдов в целевой презентации
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

## **Клонировать в указанное место в другой презентации**
Если вам нужно клонировать слайд с мастер-слайдом из одной презентации и использовать его в другой презентации, вам нужно сначала клонировать желаемый мастер-слайд из исходной презентации в целевую презентацию. Затем вы должны использовать этот мастер-слайд для клонирования слайда с мастер-слайдом. Метод [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ожидает мастер-слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation), содержащий целевую презентацию, в которую будет клонироваться слайд.
1. Получите доступ к слайду, который нужно клонировать, вместе с мастер-слайдом.
1. Создайте экземпляр класса [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection), ссылаясь на коллекцию мастеров, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) предоставленный объектом [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) и передайте мастер из исходного PPTX для клонирования в качестве параметра в метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) ссылаясь на коллекцию слайдов, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) предоставленный объектом [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации для клонирования и мастер-слайд в качестве параметра в метод [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы склонировали слайд с мастер-слайдом (находящийся на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер из исходного слайда.

```java
// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Создайте экземпляр класса Presentation для целевой презентации (куда будет клонироваться слайд)
    Presentation destPres = new Presentation();
    try {
        // Создайте экземпляр ISlide из коллекции слайдов в исходной презентации вместе с
        // мастер-слайдом
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонируйте нужный мастер-слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонируйте нужный мастер-слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Клонируйте нужный слайд из исходной презентации с нужным мастером в конец
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

## **Клонировать в конце в указанном разделе**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) предоставленный интерфейсом [**ISlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection). Aspose.Slides для Java позволяет клонировать слайд из первого раздела и затем вставить этот клонированный слайд во второй раздел той же презентации.

Следующий кодовый фрагмент иллюстрирует, как клонировать слайд и вставить клонированный слайд в указанный раздел.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Раздел 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Раздел 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Сохраните целевую презентацию на диск
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```