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
description: "Быстро дублируйте слайды PowerPoint с помощью Aspose.Slides for Java. Следуйте нашим понятным примерам кода, чтобы автоматизировать создание PPT за секунды и избавиться от ручной работы."
---
## **Введение**

Клонирование — это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for Java также позволяет создать копию или клон любого слайда и затем вставить этот клон в текущую или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который разработчики могут изменять, не затрагивая исходный слайд. Существует несколько способов клонирования слайда:

- Клонировать в конец внутри презентации.
- Клонировать в другое положение внутри презентации.
- Клонировать в конец в другой презентации.
- Клонировать в другое положение в другой презентации.
- Клонировать вместе с его мастер‑слайдом в другую презентацию.

In Aspose.Slides for Java (коллекция объектов [ISlide](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlide) ), доступная через объект [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) , предоставляет методы [addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) и [insertClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) , позволяющие выполнять перечисленные типы клонирования слайдов.

## **Клонирование слайда в конец презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) согласно шагам, перечисленным ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Создайте объект [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getSlides--) , ссылаясь на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
3. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getSlides--) и передайте слайд, который нужно клонировать, в качестве параметра.
4. Сохраните изменённый файл презентации.

В приведённом ниже примере мы клонировали слайд (находящийся в первой позиции – индекс 0 – презентации) в конец презентации.

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Клонируйте выбранный слайд в конец коллекции слайдов в той же презентации
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Сохраните изменённую презентацию на диск
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонирование слайда в другое положение внутри презентации**
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другой позиции, используйте метод [insertClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
2. Создайте объект, ссылаясь на коллекцию **Slides** , предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
3. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) , доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getSlides--) и передайте слайд, который нужно клонировать, вместе с индексом новой позиции в качестве параметра.
4. Сохраните изменённую презентацию в формате PPTX.

В приведённом ниже примере мы клонировали слайд (находящийся в индексе 1 – позиция 2 – презентации) в индекс 2 – позицию 3 – презентации.

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Получите коллекцию слайдов в презентации
    ISlideCollection slds = pres.getSlides();

    // Клонируйте выбранный слайд в указанный индекс в той же презентации
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Сохраните изменённую презентацию на диск
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Клонирование слайда в конец другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в файле другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation), содержащий презентацию, из которой будет клонироваться слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation), содержащий целевую презентацию, в которую будет добавлен слайд.
3. Создайте объект [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection) , ссылаясь на коллекцию **Slides** , предоставляемую объектом Presentation целевой презентации.
4. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getSlides--) и передайте в него слайд из исходной презентации.
5. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из первого индекса исходной презентации) в конец целевой презентации.

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонируйте выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Сохраните целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонирование слайда в другое положение в другой презентации**
Если необходимо клонировать слайд из одной презентации и использовать его в файле другой презентации, в определённой позиции:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation), содержащий презентацию, из которой будет клонироваться слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation), содержащий презентацию, в которую будет добавлен слайд.
3. Создайте объект [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getSlides--) , ссылаясь на коллекцию Slides, предоставляемую объектом Presentation целевой презентации.
4. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) , доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getSlides--) и передайте слайд из исходной презентации вместе с требуемой позицией в качестве параметра.
5. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд (из нулевого индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    Presentation destPres = new Presentation();
    try {
        // Клонируйте выбранный слайд из исходной презентации в указанный индекс целевой презентации
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Сохраните целевую презентацию на диск
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Клонирование слайда с его мастер‑слайдом в другую презентацию**
Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно склонировать нужный мастер‑слайд из исходной презентации в целевую. Затем следует использовать этот мастер‑слайд при клонировании слайда с мастер‑слайдом. Метод [addClone(ISlide, IMasterSlide, boolean)] ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастер‑слайдом, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation), содержащий исходную презентацию, из которой будет клонироваться слайд.
2. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation), содержащий целевую презентацию, в которую будет клонироваться слайд.
3. Получите доступ к слайду, который будет клонироваться, вместе с его мастер‑слайдом.
4. Создайте объект [IMasterSlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IMasterSlideCollection) , ссылаясь на коллекцию Masters, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) целевой презентации.
5. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , доступный у объекта [IMasterSlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IMasterSlideCollection) и передайте в него мастер‑слайд из исходного PPTX для клонирования.
6. Создайте объект [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getSlides--) , установив ссылку на коллекцию Slides, предоставляемую объектом [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation) целевой презентации.
7. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , доступный у объекта [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation#getSlides--) и передайте в него слайд из исходной презентации, который нужно клонировать, и мастер‑слайд.
8. Сохраните изменённый файл целевой презентации.

В приведённом ниже примере мы клонировали слайд с мастер‑слайдом (находящийся в нулевом индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд из исходного слайда.

```java
import com.aspose.slides.*;

// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Создайте экземпляр класса Presentation для целевой презентации (куда будет клонирован слайд)
    Presentation destPres = new Presentation();
    try {
        // Получите ISlide из коллекции слайдов исходной презентации вместе с
        // мастер-слайдом
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Клонируйте выбранный мастер-слайд из исходной презентации в коллекцию мастеров в
        // целевой презентации
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Клонируйте выбранный слайд из исходной презентации с нужным мастером в конец
        // коллекции слайдов целевой презентации
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

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
Если вы хотите клонировать слайд и затем использовать его в том же файле презентации, но в другом разделе, используйте метод [addClone](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) , доступный у интерфейса [ISlideCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java позволяет клонировать слайд из первого раздела и затем вставить его во второй раздел той же презентации.

В следующем фрагменте кода показано, как клонировать слайд и вставить клонированный слайд в указанный раздел.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // Сохраните целевую презентацию на диск
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Обеспечение совпадения размера слайдов**

При клонировании слайдов в другую презентацию убедитесь, что размер слайдов целевой презентации совпадает с размером слайдов исходной. Если размеры отличаются, Aspose.Slides не масштабирует автоматически клонированные объекты — их исходные координаты и размеры сохраняются, что может привести к смещению содержимого или выходу за границы слайда.

Вы можете установить размер слайдов целевой презентации, соответствующий размеру исходной, перед клонированием мастер‑слайда и слайда:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Сделайте это перед клонированием мастер‑слайда и слайда.

## **FAQ**

**Клонируются ли заметки выступающего и комментарии рецензента?**

Да. Страница заметок и комментарии рецензента включаются в клон. Если вы их не хотите, [удалите их](/slides/ru/java/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, его форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, с OLE‑встроенной книгой), эта связь сохраняется как [OLE‑объект](/slides/ru/java/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Могу ли я контролировать позицию вставки и разделы для клона?**

Да. Вы можете вставить клон в определённый индекс слайда и поместить его в выбранный [раздел](/slides/ru/java/slide-section/). Если целевой раздел не существует, сначала создайте его, а затем переместите слайд в него.