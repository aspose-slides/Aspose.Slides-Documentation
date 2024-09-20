---
title: Клонировать слайды
type: docs
weight: 35
url: /androidjava/clone-slides/
---


## **Клонирование слайдов в презентации**
Клонирование — это процесс создания точной копии или реплики чего-либо. Aspose.Slides для Android через Java также позволяет сделать копию или клонировать любой слайд и затем вставить этот клонированный слайд в текущую или любую другую открытую презентацию. Процесс клонирования слайдов создает новый слайд, который может быть изменен разработчиками без изменения оригинального слайда. Существует несколько возможных способов клонирования слайда:

- Клонировать в конце внутри презентации.
- Клонировать в другое место внутри презентации.
- Клонировать в конце в другой презентации.
- Клонировать в другое место в другой презентации.
- Клонировать в определенной позиции в другой презентации.

В Aspose.Slides для Android через Java (коллекция объектов [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)) предоставленная объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) предоставляет методы [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) для выполнения вышеперечисленных типов клонирования слайдов.

## **Клонировать в конце внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) в соответствии с шагами, указанными ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) ссылаясь на коллекцию слайдов, предоставленную объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Вызовите метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте слайд, который необходимо клонировать, в качестве параметра методу [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Запишите измененный файл презентации.

В приведенном ниже примере мы клонировали слайд (находящийся на первом месте — нулевой индекс — презентации) в конец презентации.

```java
// Создание экземпляра класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Клонирование нужного слайда в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Запись измененной презентации на диск
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонировать в другое место внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом месте, используйте метод [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Создайте экземпляр класса, ссылаясь на коллекцию [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) предоставленную объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте слайд, который необходимо клонировать, вместе с индексом для новой позиции в качестве параметра методу [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы клонировали слайд (находящийся на нулевом индексе — позиция 1 — презентации) в индекс 1 — Позиция 2 — презентации.

```java
// Создание экземпляра класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Клонирование нужного слайда в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    // Клонирование нужного слайда в указанный индекс в той же презентации
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Запись измененной презентации на диск
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонировать в конце в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другом файле презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащий презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащий целевую презентацию, в которую будет добавлен слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection), ссылаясь на коллекцию [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) предоставленную объектом Presentation целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации в качестве параметра методу [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) метода.
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд (с первого индекса исходной презентации) в конец целевой презентации.

```java
// Создание экземпляра класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создание экземпляра класса Presentation для целевой PPTX (куда слайд будет клонирован)
    Presentation destPres = new Presentation();
    try {
        // Клонирование нужного слайда из исходной презентации в конец коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Запись целевой презентации на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонировать в другое место в другой презентации**
Если вам нужно клонировать слайд из одной презентации и использовать его в другом файле презентации в определенной позиции:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащей исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащего презентацию, в которую будет добавляться слайд.
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) ссылаясь на коллекцию слайдов, предоставленную объектом Presentation целевой презентации.
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации вместе с желаемой позицией в качестве параметра методу [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

```java
// Создание экземпляра класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создание экземпляра класса Presentation для целевой PPTX (куда слайд будет клонирован)
    Presentation destPres = new Presentation();
    try {
        // Клонирование нужного слайда из исходной презентации в конец коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Запись целевой презентации на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонировать в определенной позиции в другой презентации**
Если вам нужно клонировать слайд с мастер-слайдом из одной презентации и использовать его в другой презентации, сначала необходимо клонировать нужный мастер-слайд из исходной презентации в целевую презентацию. Затем вы должны использовать этот мастер-слайд для клонирования слайда с мастер-слайдом. Метод [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ожидает мастер-слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащего исходную презентацию, из которой будет клонироваться слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), содержащего целевую презентацию, в которую будет клонироваться слайд.
1. Получите слайд, который будет клонироваться, вместе с мастер-слайдом.
1. Создайте экземпляр класса [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection), ссылаясь на коллекцию мастеров, предоставленную объектом [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) объекта [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) и передайте мастер из исходной PPTX, который должен быть клонирован, в качестве параметра метода [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Создайте экземпляр класса [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) ссылаясь на коллекцию слайдов, предоставленную объектом Presentation целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) объекта [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации, который необходимо клонировать, и мастер-слайд в качестве параметров к методу [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) метода.
1. Запишите измененный файл целевой презентации.

В приведенном ниже примере мы клонировали слайд с мастером (находящийся на нулевом индексе исходной презентации) в конец целевой презентации, используя мастер из исходного слайда.

```java
// Создание экземпляра класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Создание экземпляра класса Presentation для целевой презентации (куда слайд будет клонирован)
    Presentation destPres = new Presentation();
    try {
        // Создание ISlide из коллекции слайдов в исходной презентации вместе с
        // мастер-слайдом
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонирование нужного мастер-слайда из исходной презентации в коллекцию мастеров в
        // цели презентации
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонирование нужного мастер-слайда из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Клонирование нужного слайда из исходной презентации с нужным мастером в конец
        // коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Сохранение целевой презентации на диск
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонировать в конце в указанном разделе**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) интерфейса [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides для Android через Java позволяет клонировать слайд из первого раздела и затем вставить этот клонированный слайд во второй раздел той же презентации.

Следующий кодовый фрагмент показывает, как клонировать слайд и вставить клонированный слайд в указанный раздел.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Раздел 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Раздел 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Сохранение целевой презентации на диск
    presentation.save(dataDir + "КлонСлайдаВОпределенныйРаздел.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```